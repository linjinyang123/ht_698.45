using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class Write_Cipher_APDU
    {
        public const byte SECURITY_Type = 0x01;
        public SECURITY mSECURITY { get; set; }
        public int GetSize()
        {
            int sdsd = GetByte().Length;
            return GetByte().Length;
        }
        public byte[] GetByte()
        {
            List<byte> list = new List<byte>();
            list.Add(0x10);
            list.Add(SECURITY_Type);
            list.AddRange(mSECURITY.GetBytes());
            return list.ToArray();
        }
    }
}