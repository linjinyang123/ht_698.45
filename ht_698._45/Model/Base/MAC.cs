using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class MAC
    {
        public string mMAC { get; set; }
        public byte[] GetBytes()
        {
            List<byte> list = new List<byte>();
            list.Add((byte)(mMAC.Length / 2));
            list.AddRange(_Convert._ToBytes(mMAC, false));
            return list.ToArray();
        }
    }
}