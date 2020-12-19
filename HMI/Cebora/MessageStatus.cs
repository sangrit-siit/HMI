using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Peak.Can.Basic;
namespace Cebora
{
    class MessageStatus
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
    }
}
