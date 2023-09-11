using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class Action_APDU
    {
        public const byte APDU_Type = 0x07;
        public OAD mOAD { get; set; }
        public SID mSID { get; set; }
        public string mCipher_Data { get; set; }
        public byte[] date = new byte[] { 0x01, 0x07, 0xE2, 0x08, 0x1E, 0x12, 0x11, 0x0A, 0x05, 0x00, 0x02 };
        public int GetSize()
        {
            return GetByte().Length;
        }
        public byte[] GetByte()
        {
            List<byte> list = new List<byte>();
            list.Add(APDU_Type);
            list.Add(0x01);
            list.Add(0x01);
            list.AddRange(mOAD.GetBytes());
            list.Add(0x00);
            list.AddRange(date);
            return list.ToArray();
        }
    }
}