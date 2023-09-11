using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class SID_MAC
    {
        public SID mSID { get; set; }
        public MAC mMAC { get; set; }
        public byte[] GetBytes()
        {
            List<byte> list = new List<byte>();
            list.AddRange(mSID.GetBytes());
            list.AddRange(mMAC.GetBytes());
            return list.ToArray();
        }
    }
}