using System;
namespace ht_698._45
{
    

    public class DataReceivedEventArgs : EventArgs
    {
        public string DataReceived;
        public byte[] DataRecv;

        public DataReceivedEventArgs(string m_DataReceived)
        {
            this.DataReceived = m_DataReceived;
        }

        public DataReceivedEventArgs(byte[] m_DataRecv)
        {
            this.DataRecv = m_DataRecv;
        }
    }
}

