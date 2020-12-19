using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Peak.Can.Basic;
using TPCANHandle = System.Byte;

namespace Cebora
{
    class PowerSource
    {
        private byte mDeviceId;
        private TPCANHandle mChannel;
        private TPCANBaudrate mBaudrate;
        private TPCANType mHwType;
        private byte mState;
        private Signal<int> mDigitalSignals;
        private Signal<double> mAnalogSignals;
        private Signal<int> mRobotDigitalSignals;
        private Signal<double> mRobotAnalogSignals;
        private System.Collections.ArrayList mLastMsgsList;

        private static System.Timers.Timer mHeatbeatTimer;
        private static System.Timers.Timer mReadingTimer;

        // Properties
        public Signal<int> DigitalSignals
        {
            get { return mDigitalSignals; }
        }
        public Signal<double> AnalogSignals
        {
            get { return mAnalogSignals; }
        }
        public Signal<int> RobotDigitalSignals
        {
            get { return mRobotDigitalSignals; }
        }


        public PowerSource(byte deviceId, TPCANHandle channel, TPCANBaudrate baudrate, TPCANType hwType)
        {
            mDeviceId = deviceId;
            mChannel = channel;
            mBaudrate = baudrate;
            mHwType = hwType;

            mDigitalSignals = new Signal<int>();
            mDigitalSignals["CommunicationReady"] = 0;
            mDigitalSignals["PowerSourceReady"] = 0;
            mDigitalSignals["CollisionProtection"] = 0;
            mDigitalSignals["ProcessActive"] = 0;
            mDigitalSignals["CurrentFlow"] = 0;
            mDigitalSignals["ErrorNumber"] = 0;
            mDigitalSignals["PulseSync"] = 0;
            mDigitalSignals["PilotArc"] = 0;
            mDigitalSignals["StickingRemedied"] = 0;
            mDigitalSignals["WireAvailable"] = 0;
            mDigitalSignals["MainCurrent"] = 0;

            mAnalogSignals = new Signal<double>();
            mAnalogSignals["A0"] = 0; // Welding Voltage Measured 0 ~ 100 V.
            mAnalogSignals["A1"] = 0; // Welding Current Measured 0 ~ 1000 A.
            mAnalogSignals["A2"] = 0; // Motor Current Measured 0,0 ~ 5.0 A.
            mAnalogSignals["A3"] = 0; // Wire Feed Speed Actual Value -12,5 ~ +12,5 m/min.
            mAnalogSignals["A4"] = 0; // Plasma gas flow 0.2 ~ 10.0 l/min.
            mAnalogSignals["A5"] = 0; // Shield gas flow 5.0 ~ 30.0 l/min.

            mRobotDigitalSignals = new Signal<int>();
            mRobotDigitalSignals["ArcOn"] = 0;
            mRobotDigitalSignals["RobotReady"] = 1;
            mRobotDigitalSignals["OperationMode"] = 0;
            mRobotDigitalSignals["AnalogSwapMode"] = 0;
            mRobotDigitalSignals["ProtocolMode"] = 0;
            mRobotDigitalSignals["GasTest"] = 0;
            mRobotDigitalSignals["WireInching"] = 0;
            mRobotDigitalSignals["WireRetract"] = 0;
            mRobotDigitalSignals["SourceErrorReset"] = 1;
            mRobotDigitalSignals["TouchSensing"] = 0;
            mRobotDigitalSignals["BlowThrough"] = 0;
            mRobotDigitalSignals["JobNumber"] = 0;
            mRobotDigitalSignals["WeldingSimulation"] = 0;
            mRobotDigitalSignals["AnalogSetPoint0"] = 0;
            mRobotDigitalSignals["AnalogSetPoint1"] = 0;
            mRobotDigitalSignals["AnalogSetPoint2"] = 0;
            mRobotDigitalSignals["AnalogSetPoint3"] = 0;
            mRobotDigitalSignals["AnalogSetPoint4"] = 0;
            mRobotDigitalSignals["AnalogSetPoint5"] = 0;
            mRobotDigitalSignals["DCACDisable"] = 0;
            mRobotDigitalSignals["PulseOffOn"] = 0;
            mRobotDigitalSignals["DCAC"] = 0;
            mRobotDigitalSignals["Pulse"] = 0;
            mRobotDigitalSignals["PilotArcStart"] = 0;
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
            }
            else
            {
                byte[] data = { 0x01, mDeviceId };
                Write("000", data);

                Update();

                StartTimers();
            }
            return result;
        }

        public void Reset()
        {
            byte[] resetNode = { 0x81, mDeviceId };
            byte[] resetCommunication = { 0x82, mDeviceId };
            byte[] data = { 0x01, mDeviceId };

            Write("000", resetNode);
            Write("000", resetCommunication);
            Write("000", data);
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
            Write(Convert.ToString(701).ToUpper(), data);
        }

        public void Update()
        {
            bool invertBin = true;
            string[] binaryArrstr = new string[64];
            string[] binaryArrstrRev = new string[64];
            binaryArrstr[0] = mRobotDigitalSignals["ArcOn"] == 1 ? "1" : "0";  //1 active
            binaryArrstr[1] = mRobotDigitalSignals["RobotReady"] == 1 ? "1" : "0";  //Bit = 0 : The robot control disables the power source putting it in a stop condition. “rob” message is blinking

            switch (mRobotDigitalSignals["OperationMode"])
            {
                case 0:
                    // "010 Job Selection";
                    binaryArrstr[2] = "0"; //bit 0
                    binaryArrstr[3] = "1";
                    binaryArrstr[4] = "0";
                    break;
                case 1:
                    // "011 Parameter Selection";
                    binaryArrstr[2] = "1"; //bit 0
                    binaryArrstr[3] = "1";
                    binaryArrstr[4] = "0";
                    break;
                case 2:
                    // "110 TIG";
                    binaryArrstr[2] = "0"; //bit 0
                    binaryArrstr[3] = "1";
                    binaryArrstr[4] = "1";
                    break;
            }

            binaryArrstr[5] = "0";//Reserved (set to 0)
            binaryArrstr[6] = mRobotDigitalSignals["AnalogSwapMode"] == 1 ? "1" : "0";
            binaryArrstr[7] = mRobotDigitalSignals["ProtocolMode"] == 1 ? "1" : "0"; //0 : minimum = 0 and maximum = 65535 , 1: binary value with sign (16-bit)

            binaryArrstr[8] = mRobotDigitalSignals["GasTest"] == 1 ? "1" : "0";

            binaryArrstr[9] = mRobotDigitalSignals["WireInching"] == 1 ? "1" : "0";
            binaryArrstr[10] = mRobotDigitalSignals["WireRetract"] == 1 ? "1" : "0";
            binaryArrstr[11] = mRobotDigitalSignals["SourceErrorReset"] == 1 ? "1" : "0";

            binaryArrstr[12] = mRobotDigitalSignals["TouchSensing"] == 1 ? "1" : "0";
            binaryArrstr[13] = mRobotDigitalSignals["BlowThrough"] == 1 ? "1" : "0";

            binaryArrstr[14] = "0";//Not used
            binaryArrstr[15] = "0";//Reserved (set to 0)


            long Jobvalue = long.Parse(mRobotDigitalSignals["JobNumber"].ToString());
            string JobBinary = Convert.ToString(Jobvalue, 2);
            if (JobBinary.Length != 8)
            {
                int AddZero = 8 - JobBinary.Length;
                for (int j = 0; j < AddZero; j++)
                {
                    JobBinary = "0" + JobBinary;
                }
            }

            if (JobBinary.Length == 8)
            {
                string retBuf = JobBinary;

                binaryArrstr[16] = retBuf.Substring(7, 1);
                binaryArrstr[17] = retBuf.Substring(6, 1);
                binaryArrstr[18] = retBuf.Substring(5, 1);
                binaryArrstr[19] = retBuf.Substring(4, 1);
                binaryArrstr[20] = retBuf.Substring(3, 1);
                binaryArrstr[21] = retBuf.Substring(2, 1);
                binaryArrstr[22] = retBuf.Substring(1, 1);
                binaryArrstr[23] = retBuf.Substring(0, 1);

            }


            binaryArrstr[24] = "0";//Not used
            binaryArrstr[25] = "0";//Not used
            binaryArrstr[26] = "0";//Not used
            binaryArrstr[27] = "0";//Not used
            binaryArrstr[28] = "0";//Not used
            binaryArrstr[29] = "0";//Not used
            binaryArrstr[30] = "0";//Not used

            binaryArrstr[31] = mRobotDigitalSignals["WeldingSimulation"] == 1 ? "1" : "0";

            binaryArrstr[32] = mRobotDigitalSignals["AnalogSetPoint0"] == 1 ? "1" : "0";
            binaryArrstr[33] = mRobotDigitalSignals["AnalogSetPoint1"] == 1 ? "1" : "0";
            binaryArrstr[34] = mRobotDigitalSignals["AnalogSetPoint2"] == 1 ? "1" : "0";
            binaryArrstr[35] = mRobotDigitalSignals["AnalogSetPoint3"] == 1 ? "1" : "0";
            binaryArrstr[36] = mRobotDigitalSignals["AnalogSetPoint4"] == 1 ? "1" : "0";
            binaryArrstr[37] = mRobotDigitalSignals["AnalogSetPoint5"] == 1 ? "1" : "0";


            binaryArrstr[38] = "1";//Reserved (set to 1)
            binaryArrstr[39] = "1";//Reserved (set to 1)



            binaryArrstr[40] = mRobotDigitalSignals["DCACDisable"] == 1 ? "1" : "0";

            binaryArrstr[41] = "0";//Not used
            binaryArrstr[42] = "0";//Not used

            binaryArrstr[43] = mRobotDigitalSignals["PulseOffOn"] == 1 ? "1" : "0";

            binaryArrstr[44] = "0";//Not used
            binaryArrstr[45] = "0";//Not used
            binaryArrstr[46] = "0";//Not used
            binaryArrstr[47] = "0";//Not used

            binaryArrstr[48] = mRobotDigitalSignals["DCAC"] == 1 ? "1" : "0";

            binaryArrstr[49] = "0";//Not used
            binaryArrstr[50] = "0";//Not used

            binaryArrstr[51] = mRobotDigitalSignals["Pulse"] == 1 ? "1" : "0";

            binaryArrstr[52] = "0";//Not used
            binaryArrstr[53] = "0";//Not used
            binaryArrstr[54] = "0";//Not used

            binaryArrstr[55] = mRobotDigitalSignals["PilotArcStart"] == 1 ? "1" : "0"; //Pilot arc Start

            binaryArrstr[56] = "0";//Not used
            binaryArrstr[57] = "0";//Not used
            binaryArrstr[58] = "0";//Not used
            binaryArrstr[59] = "0";//Not used
            binaryArrstr[60] = "0";//Not used
            binaryArrstr[61] = "0";//Not used
            binaryArrstr[62] = "0";//Not used

            binaryArrstr[63] = "0";//Reserved (set to 0)

            for (int i = 0; i < 64; i++)
            {
                if (invertBin)
                {
                    binaryArrstrRev[63 - i] = binaryArrstr[i];
                }
                else
                {
                    binaryArrstrRev[i] = binaryArrstr[i];
                }
            }

            StringBuilder builder = new StringBuilder();
            foreach (string value in binaryArrstrRev)
            {
                builder.Append(value);
                // builder.Append('.');
            }

            string binarystr = builder.ToString();
            if (binarystr.Length == 64)
            {
                // txtBinary.Text = binarystr;
                long value = Convert.ToInt64(binarystr, 2);

                string HexStr = Convert.ToString(value, 16).ToUpper();
                // txtHexadecimal.Text = HexStr;

                if (HexStr.Length != (8 * 2))
                {
                    int AddZero = (8 * 2) - HexStr.Length;
                    for (int j = 0; j < AddZero; j++)
                    {
                        HexStr = "0" + HexStr;
                    }
                }
                string retBuf = HexStr;

                string Data0 = retBuf.Substring(14, 2);
                string Data1 = retBuf.Substring(12, 2);
                string Data2 = retBuf.Substring(10, 2);
                string Data3 = retBuf.Substring(8, 2);
                string Data4 = retBuf.Substring(6, 2);
                string Data5 = retBuf.Substring(4, 2);
                string Data6 = retBuf.Substring(2, 2);
                string Data7 = retBuf.Substring(0, 2);

                byte[] CANMsg = new byte[8];
                CANMsg[0] = Convert.ToByte(Data0, 16);
                CANMsg[1] = Convert.ToByte(Data1, 16);
                CANMsg[2] = Convert.ToByte(Data2, 16);
                CANMsg[3] = Convert.ToByte(Data3, 16);
                CANMsg[4] = Convert.ToByte(Data4, 16);
                CANMsg[5] = Convert.ToByte(Data5, 16);
                CANMsg[6] = Convert.ToByte(Data6, 16);
                CANMsg[7] = Convert.ToByte(Data7, 16);

                Write(Convert.ToString(200 + (int)mDeviceId).ToUpper(), CANMsg);
            }
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
            }

            Console.WriteLine("COBID: 0x{0:X}\t LEN: {1}\t DATA: {2}", msg.ID, msg.LEN, BitConverter.ToString(msg.DATA));

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
            double Map(double value, double fromSrouce, double toSource, double fromTarget, double toTarget) => (value - fromSrouce) / (toSource - fromSrouce) * (toTarget - fromTarget) + fromTarget;
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
                        mDigitalSignals["PowerSourceReady"] = retBuf.Substring(2, 1) == "1" ? 1 : 0;
                        mDigitalSignals["CollisionProtection"] = retBuf.Substring(3, 1) == "1" ? 1 : 0;
                        mDigitalSignals["MainCurrent"] = retBuf.Substring(4, 1) == "1" ? 1 : 0;
                        mDigitalSignals["ProcessActive"] = retBuf.Substring(5, 1) == "1" ? 1 : 0;

                        if (retBuf.Substring(6, 1) == "1")//Not Use
                        {
                        }

                        mDigitalSignals["CurrentFlow"] = retBuf.Substring(6, 1) == "1" ? 1 : 0;
                    }

                    mDigitalSignals["ErrorNumber"] = (int)value2;

                    if (Binary3.Length == 8)
                    {
                        string retBuf = Binary3;
                        mDigitalSignals["PulseSync"] = retBuf.Substring(0, 1) == "1" ? 1 : 0;
                        mDigitalSignals["PilotArc"] = retBuf.Substring(7, 1) == "1" ? 1 : 0;
                    }

                    if (Binary4.Length == 8)
                    {
                        string retBuf = Binary4;
                        mDigitalSignals["StickingRemedied"] = retBuf.Substring(0, 1) == "1" ? 1 : 0;
                        mDigitalSignals["WireAvailable"] = retBuf.Substring(3, 1) == "1" ? 1 : 0;
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
    }
}
