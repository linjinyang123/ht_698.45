using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class Action_Cipher_APDU
    {
        public const byte SECURITY_Type = 0x01;
        public const byte APDU_Type = 0x07;
        public OAD mOAD { get; set; }
        public SID mSID { get; set; }
        public string mCipher_Data { get; set; }
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
            list.Add(0x02);
            list.Add(0x02);
            list.Add(0x09);
            list.Add(0x10);
            list.AddRange(_Convert._ToBytes(mCipher_Data, false));
            list.Add(0x5d);
            list.AddRange(mSID.GetBytes());
            return list.ToArray();
        }
    }
}