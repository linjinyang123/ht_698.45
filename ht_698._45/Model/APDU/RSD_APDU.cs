using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class RSD_APDU
    {
        public byte PIID { get; set; }
        public OAD mOAD { get; set; }
        public byte RequestType { get; set; }
        public RSD _RSD { get; set; }
        public int GetSize()
        {
            return GetByte().Length;
        }
        public byte[] GetByte()
        {
            List<byte> list = new List<byte>();
            list.Add(5);
            list.Add(RequestType);
            list.Add(PIID);
            list.AddRange(mOAD.GetBytes());
            list.AddRange(_RSD.GetByte());
            return list.ToArray();
        }
    }
}