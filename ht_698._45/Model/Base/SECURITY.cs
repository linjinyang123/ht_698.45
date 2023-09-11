using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class SECURITY
    {
        public byte CHOICEType { get; set; }
        public string SECURITY_Data { get; set; }
        public SID_MAC mSID_MAC { get; set; }

        public byte[] GetBytes()
        {
            List<byte> list = new List<byte>();
            list.Add((byte)(SECURITY_Data.Length / 2));
            list.AddRange(_Convert._ToBytes(SECURITY_Data, false));
            list.Add(CHOICEType);
            list.AddRange(mSID_MAC.GetBytes());
            return list.ToArray();
        }
    }
}