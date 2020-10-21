using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

using Peak.Can.Basic;
using TPCANHandle = System.Byte;

namespace PowerSource
{
    public class Cebora : Object
    {
        private byte mDeviceId;
        private TPCANHandle mChannel;
        private TPCANBaudrate mBaudrate;
        private TPCANType mHwType;
        private byte mState;
        private Signal<int> mDigitalSignals;
        private Signal<double> mAnalogSignals;
        private System.Collections.ArrayList mLastMsgsList;

        private static System.Timers.Timer mHeatbeatTimer;
        private static System.Timers.Timer mReadingTimer;

        public Cebora(byte deviceId, TPCANHandle channel, TPCANBaudrate baudrate, TPCANType hwType)
        {
            mDeviceId = deviceId;
            mChannel = channel;
            mBaudrate = baudrate;
            mHwType = hwType;

            mDigitalSignals = new Signal<int>(this);
            mDigitalSignals["CommunicationReady"]=0;
            mDigitalSignals["PowerSourceReady"]=0;
            mDigitalSignals["CollisionProtection"]=0;
            mDigitalSignals["ProcessActive"]=0;
            mDigitalSignals["CurrentFlow"]=0;
            mDigitalSignals["ErrorNumber"]=0;
            mDigitalSignals["PulseSync"]=0;
            mDigitalSignals["PilotArc"]=0;
            mDigitalSignals["StickingRemedied"]=0;
            mDigitalSignals["WireAvailable"]=0;
            mDigitalSignals["MainCurrent"]=0;
            
            mAnalogSignals = new Signal<double>(this);
            mAnalogSignals["A0"]=0; // Welding Voltage Measured 0 ~ 100 V.
            mAnalogSignals["A1"]=0; // Welding Current Measured 0 ~ 1000 A.
            mAnalogSignals["A2"]=0; // Motor Current Measured 0,0 ~ 5.0 A.
            mAnalogSignals["A3"]=0; // Wire Feed Speed Actual Value -12,5 ~ +12,5 m/min.
            mAnalogSignals["A4"]=0; // Plasma gas flow 0.2 ~ 10.0 l/min.
            mAnalogSignals["A5"]=0; // Shield gas flow 5.0 ~ 30.0 l/min.
        }
        public Signal<int> DigitalSignals
        {
            get { return mDigitalSignals; }
        }
        public Signal<double> AnalogSignals
        {
            get{ return mAnalogSignals; }
        }
        public TPCANStatus Init()
        {
            TPCANStatus result;
            StringBuilder strMsg;

            result = PCANBasic.Initialize(mChannel, mBaudrate);

            if (result != TPCANStatus.PCAN_ERROR_OK)
            {
                strMsg = new StringBuilder(256);
                PCANBasic.GetErrorText(result, 0, strMsg);
                MessageBox.Show(strMsg.ToString());
            }
            else
            {
                MessageBox.Show("PCAN-USB was initialized successfully!");

                // Turn the power source oparationa on
                byte[] data = {0x01, mDeviceId};
                Write("000", data);

                //
                data = new byte[8];
                data[0] = 0x02;
                Write("202", data);
                StartTimers();
            }

            return result;
        }

        private void StartTimers()
        {
            mHeatbeatTimer = new System.Timers.Timer(100);
            mHeatbeatTimer.Elapsed += HeartBeat;
            mHeatbeatTimer.AutoReset = true;
            mHeatbeatTimer.Enabled = true;

            mReadingTimer = new System.Timers.Timer(100);
            mReadingTimer.Elapsed += Read;
            mReadingTimer.AutoReset = true;
            mReadingTimer.Enabled = true;
        }

        private void HeartBeat(Object source, ElapsedEventArgs e)
        {
            byte[] data = new byte[1];
            data[0] = Convert.ToByte("05", 16);
            Write("701", data);
        }

        public void Update()
        { 

        }

        public void Write(string id, byte[] data) 
        {
            TPCANStatus result;
            TPCANMsg msg;

            msg = new TPCANMsg();

            msg.ID = Convert.ToUInt32(id, 16);
            msg.LEN = Convert.ToByte(data.Length);
            msg.DATA = new byte[8];
            msg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;

            for (int i = 0; i < msg.LEN; i++)
                msg.DATA[i] = data[i];
            
            PCANBasic.Write(mChannel, ref msg);

            result = PCANBasic.Write(mChannel, ref msg);

            if (result != TPCANStatus.PCAN_ERROR_OK)
            {
                StringBuilder strMsg = new StringBuilder(256);
                PCANBasic.GetErrorText(result, 0, strMsg);
                //Console.WriteLine(strMsg.ToString());
            }

        }

        private void Read(Object source, ElapsedEventArgs e)
        {
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;

            // We read at least one time the queue looking for messages.
            // If a message is found, we look again trying to find more.
            // If the queue is empty or an error occurr, we get out from
            // the dowhile statement.
            //			
            do
            {
                // We execute the "Read" function of the PCANBasic                
                //
                stsResult = PCANBasic.Read(mChannel, out CANMsg, out CANTimeStamp);
                // A message was received
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                {
                    Console.WriteLine("COBID: 0x{0:X}\t LEN: {1}\t DATA: {2}", CANMsg.ID, CANMsg.LEN, BitConverter.ToString(CANMsg.DATA));
                    MessageStatus msg = DecodeMessage(CANMsg, CANTimeStamp);
                }
            } while (mReadingTimer.Enabled && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY)));
        }

        private MessageStatus DecodeMessage(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp)
        {
            double Map(double value, double fromSrouce, double toSource, double fromTarget, double toTarget)=> (value-fromSrouce)/(toSource-fromSrouce)*(toTarget-fromTarget)+fromTarget;
            MessageStatus StsMsg = new MessageStatus(theMsg, itsTimeStamp, 0);

            string retID = StsMsg.IdString;
            string retLEN = theMsg.LEN.ToString();
            string retDATA = StsMsg.DataString.Trim();

            char[] splitter = { ' ' };
            string[] arData = retDATA.Split(splitter);

            string ret1 = "";
            string ret2 = "";
            string ret3 = "";
            string ret4 = "";

            long value1 = 0;
            long value2 = 0;
            long value3 = 0;
            long value4 = 0;

            #region ID = 0x180
            if (StsMsg.IdString == "182h")
            {
                if (retLEN == "4")
                {
                    ret1 = arData[0];
                    ret2 = arData[1];
                    ret3 = arData[2];
                    ret4 = arData[3];

                    //Convert To Long
                    value1 = Convert.ToInt64(ret1, 16);
                    value2 = Convert.ToInt64(ret2, 16);
                    value3 = Convert.ToInt64(ret3, 16);
                    value4 = Convert.ToInt64(ret4, 16);

                    #region Convert To Binary
                    string Binary1 = Convert.ToString(value1, 2);
                    string Binary2 = Convert.ToString(value2, 2); //Error Number
                    string Binary3 = Convert.ToString(value3, 2);
                    string Binary4 = Convert.ToString(value4, 2);

                    if (Binary1.Length != 8)
                    {
                        int AddZero = 8 - Binary1.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary1 = "0" + Binary1;
                        }
                    }

                    if (Binary2.Length != 8)
                    {
                        int AddZero = 8 - Binary2.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary2 = "0" + Binary2;
                        }
                    }

                    if (Binary3.Length != 8)
                    {
                        int AddZero = 8 - Binary3.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary3 = "0" + Binary3;
                        }
                    }

                    if (Binary4.Length != 8)
                    {
                        int AddZero = 8 - Binary4.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary4 = "0" + Binary4;
                        }
                    }
                    #endregion Convert To Binary

                    #region Check Bit Data
                    if (Binary1.Length == 8)
                    {
                        string retBuf = Binary1;

                        if (retBuf.Substring(0, 1) == "1")//Reserved
                        {
                        }

                        mDigitalSignals["CommunicationReady"] = retBuf.Substring(1, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(1, 1) == "1")//Communication Ready
                        {
                            Pic_Com_Ready.Image = PicOn.Image;
                            Status_CommunicationReady = true;

                            Pic_Com_State.Image = PicOn.Image;
                            // ParentForm.Pic_Com_State.Image = PicOn.Image;
                        }
                        else
                        {
                            Pic_Com_Ready.Image = PicOff.Image;
                            Status_CommunicationReady = false;

                            Pic_Com_State.Image = PicOff.Image;
                            //ParentForm.Pic_Com_State.Image = PicOff.Image;
                        }
                        */
                        mDigitalSignals["PowerSourceReady"] = retBuf.Substring(2, 1) == "1" ? 1 : 0;
                        /*  
                        if (retBuf.Substring(2, 1) == "1")//Power Source Ready
                        {
                            Pic_Power_Source_Ready.Image = PicOn.Image;
                            Status_PowerSourceReady = true;

                            Pic_Power_Source_State.Image = PicOn.Image;
                            // ParentForm.Pic_Power_Source_State.Image = PicOn.Image;

                        }
                        else
                        {
                            Pic_Power_Source_Ready.Image = PicOff.Image;
                            Status_PowerSourceReady = false;

                            Pic_Power_Source_State.Image = PicOff.Image;
                            //ParentForm.Pic_Power_Source_State.Image = PicOff.Image;
                        }
                        */
                        mDigitalSignals["CollisionProtection"] = retBuf.Substring(3, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(3, 1) == "1")//Collision Protection.
                        {
                            Pic_Collision_Protection.Image = PicOn.Image;
                            Status_CollisionProtection = true;
                        }
                        else
                        {
                            Pic_Collision_Protection.Image = PicOff.Image;
                            Status_CollisionProtection = false;
                        }
                        */
                        mDigitalSignals["MainCurrent"] = retBuf.Substring(4, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(4, 1) == "1") //Main Current
                        {
                            Pic_Main_Current.Image = PicOn.Image;
                            Status_MainCurrent = true;

                        }
                        else
                        {
                            Pic_Main_Current.Image = PicOff.Image;
                            Status_MainCurrent = false;
                        }
                        */
                        mDigitalSignals["ProcessActive"] = retBuf.Substring(5, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(5, 1) == "1")//Process Active
                        {
                            Pic_Process_Active.Image = PicOn.Image;
                            Status_ProcessActive = true;

                            Pic_Process_Active_Status.Image = PicOn.Image;
                            //ParentForm.Pic_Process_Active_Status.Image = PicOn.Image;
                        }
                        else
                        {
                            Pic_Process_Active.Image = PicOff.Image;
                            Status_ProcessActive = false;

                            Pic_Process_Active_Status.Image = PicOff.Image;
                            // ParentForm.Pic_Process_Active_Status.Image = PicOff.Image;
                        }
                        */
                        
                        if (retBuf.Substring(6, 1) == "1")//Not Use
                        {
                        }

                        mDigitalSignals["CurrentFlow"] = retBuf.Substring(6, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(7, 1) == "1")//Current Flow
                        {
                            Pic_Current_Flow.Image = PicOn.Image;
                            Status_CurrentFlow = true;

                            Pic_Current_Flow_Status.Image = PicOn.Image;
                        }
                        else
                        {
                            Pic_Current_Flow.Image = PicOff.Image;
                            Status_CurrentFlow = false;

                            Pic_Current_Flow_Status.Image = PicOff.Image;
                        }
                        */
                    }

                    mDigitalSignals["ErrorNum"] = Convert.ToInt16(value2);
                    /*
                    txtErrorNum.Text = value2.ToString();
                    ErrorNumber = value2.ToString();
                    */

                    if (Binary3.Length == 8)
                    {
                        string retBuf = Binary3;
                        mDigitalSignals["PulseSync"] = retBuf.Substring(0, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(0, 1) == "1")//Pulse Sync
                        {
                            Pic_Pulse_Sync.Image = PicOn.Image;
                            Status_PulseSync = true;
                        }
                        else
                        {
                            Pic_Pulse_Sync.Image = PicOff.Image;
                            Status_PulseSync = false;
                        }
                        */
                        mDigitalSignals["PilotArc"] = retBuf.Substring(7, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(7, 1) == "1")//Pilot Arc
                        {
                            Pic_Pilot_Arc.Image = PicOn.Image;
                            Status_PilotArc = true;
                        }
                        else
                        {
                            Pic_Pilot_Arc.Image = PicOff.Image;
                            Status_PilotArc = false;
                        }
                        */
                    }

                    if (Binary4.Length == 8)
                    {
                        string retBuf = Binary4;
                        mDigitalSignals["StickingRemedied"] = retBuf.Substring(0, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(0, 1) == "1")//Sticking Remedied
                        {
                            Pic_Sticking_Remedied.Image = PicOn.Image;
                            Status_StickingRemedied = true;
                        }
                        else
                        {
                            Pic_Sticking_Remedied.Image = PicOff.Image;
                            Status_StickingRemedied = false;
                        }
                        */
                        mDigitalSignals["WireAvailable"] = retBuf.Substring(3, 1) == "1" ? 1 : 0;
                        /*
                        if (retBuf.Substring(3, 1) == "1")//Wire Available.
                        {
                            Pic_Wire_Available.Image = PicOn.Image;
                            Status_WireAvailable = true;
                        }
                        else
                        {
                            Pic_Wire_Available.Image = PicOff.Image;
                            Status_WireAvailable = false;
                        }
                        */
                    }
                    #endregion Check Bit Data
                }
            }
            #endregion ID = 0x180
            #region ID = 0x280
            if (StsMsg.IdString == "282h")
            {
                if (retLEN == "8")
                {
                    #region  A0 Cal
                    ret1 = arData[0];
                    ret2 = arData[1];
                    value1 = Convert.ToInt64(ret1, 16);
                    value2 = Convert.ToInt64(ret2, 16);

                    string Binary1 = Convert.ToString(value1, 2);
                    string Binary2 = Convert.ToString(value2, 2);


                    if (Binary1.Length != 8)
                    {
                        int AddZero = 8 - Binary1.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary1 = "0" + Binary1;
                        }
                    }

                    if (Binary2.Length != 8)
                    {
                        int AddZero = 8 - Binary2.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary2 = "0" + Binary2;
                        }
                    }

                    string BinaryA0 = Binary2 + Binary1;
                    long valueA0 = Convert.ToInt64(BinaryA0, 2);
                    double retmap = Map(Convert.ToDouble(valueA0), 0, 65536, 0, 100); //0-100V
                    mAnalogSignals["A0"] = retmap;
                    /*
                    txtVoltageMea.Text = retmap.ToString("0.000");
                    txtVoltageMea_status.Text = retmap.ToString("0.000");
                    TxtA0Measure.Text = "Value : " + valueA0.ToString() + ", Binary : " + BinaryA0;
                    */
                    #endregion  A0 Cal

                    #region  A1 Cal
                    ret1 = arData[2];
                    ret2 = arData[3];
                    value1 = Convert.ToInt64(ret1, 16);
                    value2 = Convert.ToInt64(ret2, 16);

                    Binary1 = Convert.ToString(value1, 2);
                    Binary2 = Convert.ToString(value2, 2);


                    if (Binary1.Length != 8)
                    {
                        int AddZero = 8 - Binary1.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary1 = "0" + Binary1;
                        }
                    }

                    if (Binary2.Length != 8)
                    {
                        int AddZero = 8 - Binary2.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary2 = "0" + Binary2;
                        }
                    }

                    string BinaryA1 = Binary2 + Binary1;
                    long valueA1 = Convert.ToInt64(BinaryA1, 2);
                    retmap = Map(Convert.ToDouble(valueA1), 0, 65536, 0, 500); //0-500A
                    mAnalogSignals["A1"] = retmap;
                    /*
                    txtCurrentMea.Text = retmap.ToString("0.000");
                    txtCurrentMea_status.Text = retmap.ToString("0.000");
                    TxtA1Measure.Text = "Value : " + valueA1.ToString() + ", Binary : " + BinaryA1;
                    */
                    #endregion  A1 Cal

                    #region  A2 Cal
                    ret1 = arData[4];
                    ret2 = arData[5];
                    value1 = Convert.ToInt64(ret1, 16);
                    value2 = Convert.ToInt64(ret2, 16);

                    Binary1 = Convert.ToString(value1, 2);
                    Binary2 = Convert.ToString(value2, 2);


                    if (Binary1.Length != 8)
                    {
                        int AddZero = 8 - Binary1.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary1 = "0" + Binary1;
                        }
                    }

                    if (Binary2.Length != 8)
                    {
                        int AddZero = 8 - Binary2.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary2 = "0" + Binary2;
                        }
                    }

                    string BinaryA2 = Binary2 + Binary1;
                    long valueA2 = Convert.ToInt64(BinaryA2, 2);
                    retmap = Map(Convert.ToDouble(valueA2), 0, 65536, 0, 5); //0-5A
                    mAnalogSignals["A2"] = retmap;
                    /*
                    txtMotorCurrent.Text = retmap.ToString("0.000");
                    txtMotorCurrent_Mea.Text = txtMotorCurrent.Text;
                    TxtA2Measure.Text = "Value : " + valueA2.ToString() + ", Binary : " + BinaryA2;
                    */
                    #endregion  A2 Cal

                    #region  A3 Cal

                    ret1 = arData[6];
                    ret2 = arData[7];
                    value1 = Convert.ToInt64(ret1, 16);
                    value2 = Convert.ToInt64(ret2, 16);

                    Binary1 = Convert.ToString(value1, 2);
                    Binary2 = Convert.ToString(value2, 2);


                    if (Binary1.Length != 8)
                    {
                        int AddZero = 8 - Binary1.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary1 = "0" + Binary1;
                        }
                    }

                    if (Binary2.Length != 8)
                    {
                        int AddZero = 8 - Binary2.Length;
                        for (int j = 0; j < AddZero; j++)
                        {
                            Binary2 = "0" + Binary2;
                        }
                    }

                    string BinaryA3 = Binary2 + Binary1;
                    long valueA3 = Convert.ToInt64(BinaryA3, 2);
                    retmap = Map(Convert.ToDouble(valueA3), 0, 65536, -12.5, 12.5);
                    mAnalogSignals["A3"] = retmap;
                    /*
                    txtWireFeedSpeed.Text = retmap.ToString("0.000");
                    txtWireFeedSpeed_Mea.Text = txtWireFeedSpeed.Text;
                    TxtA3Measure.Text = "Value : " + valueA3.ToString() + ", Binary : " + BinaryA3;
                    */
                    #endregion  A3 Cal

                }
            }
            #endregion ID = 0x280
            
            #region ID = 0x380
            if (StsMsg.IdString == "382h")
            {
                if (retLEN == "8")
                {
                    ret1 = arData[0];

                }
            }
            #endregion ID = 0x380
            
            #region ID = 0x702
            if (StsMsg.IdString == "702h")
            {
                if (retLEN == "1")
                {
                   ret1 = arData[0];
                   mState = Convert.ToByte(ret1, 16);
                }
            }
            #endregion ID = 0x702
            return StsMsg;
        }


    }// End Class PowerSource
    public class Signal<T>
    {
        private Cebora mCebora;
        private Dictionary<string, T> mSignals = new Dictionary<string, T>();

        public T this[string key]
        {
            get { return mSignals[key]; }
            set { mSignals[key] = value; }
        }

        public Signal(Cebora cebora)
        {
            mCebora = cebora;
        }
    }

    public class MessageStatus
    {
        private TPCANMsg m_Msg;
        private TPCANTimestamp m_TimeStamp;
        private TPCANTimestamp m_oldTimeStamp;
        private int m_iIndex;
        private int m_Count;
        private bool m_bShowPeriod;
        private bool m_bWasChanged;

        public MessageStatus(TPCANMsg canMsg, TPCANTimestamp canTimestamp, int listIndex)
        {
            m_Msg = canMsg;
            m_TimeStamp = canTimestamp;
            m_oldTimeStamp = canTimestamp;
            m_iIndex = listIndex;
            m_Count = 1;
            m_bShowPeriod = true;
            m_bWasChanged = false;
        }
        public void Update(TPCANMsg canMsg, TPCANTimestamp canTimestamp)
        {
            m_Msg = canMsg;
            m_oldTimeStamp = m_TimeStamp;
            m_TimeStamp = canTimestamp;
            m_bWasChanged = true;
            m_Count += 1;
        }
        public TPCANMsg CANMsg
        {
            get { return m_Msg; }
        }
        public TPCANTimestamp Timestamp
        {
            get { return m_TimeStamp; }
        }
        public int Position
        {
            get { return m_iIndex; }
        }
        public string TypeString
        {
            get { return GetMsgTypeString(); }
        }
        public string IdString
        {
            get { return GetIdString(); }
        }
        public string DataString
        {
            get { return GetDataString(); }
        }
        public int Count
        {
            get { return m_Count; }
        }
        public bool ShowingPeriod
        {
            get { return m_bShowPeriod; }
            set
            {
                if (m_bShowPeriod ^ value)
                {
                    m_bShowPeriod = value;
                    m_bWasChanged = true;
                }
            }
        }
        public bool MarkedAsUpdated
        {
            get { return m_bWasChanged; }
            set { m_bWasChanged = value; }
        }
        public string TimeString
        {
            get { return GetTimeString(); }
        }
        private string GetTimeString()
        {
            double fTime;

            fTime = m_TimeStamp.millis + (m_TimeStamp.micros / 1000.0);
            if (m_bShowPeriod)
                fTime -= (m_oldTimeStamp.millis + (m_oldTimeStamp.micros / 1000.0));
            return fTime.ToString("F1");
        }
        private string GetDataString()
        {
            string strTemp;

            strTemp = "";

            if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";
            else
                for (int i = 0; i < m_Msg.LEN; i++)
                    strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);

            return strTemp;
        }
        private string GetIdString()
        {
            // We format the ID of the message and show it
            //
            if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                return string.Format("{0:X8}h", m_Msg.ID);
            else
                return string.Format("{0:X3}h", m_Msg.ID);
        }
        private string GetMsgTypeString()
        {
            string strTemp;

            if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                strTemp = "EXTENDED";
            else
                strTemp = "STANDARD";

            if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                strTemp += "/RTR";

            return strTemp;
        }
    } // End Class MessageStatus
}