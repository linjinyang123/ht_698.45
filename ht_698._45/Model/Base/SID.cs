using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class SID
    {
        public string Identification { get; set; }
        public string Additionnal_Data { get; set; }
        public byte[] GetBytes()
        {
            List<byte> list = new List<byte>();

            list.AddRange(_Convert._ToBytes(Identification, false));
            list.Add((byte)(Additionnal_Data.Length / 2));
            list.AddRange(_Convert._ToBytes(Additionnal_Data, false));
            return list.ToArray();
        }
    }
}