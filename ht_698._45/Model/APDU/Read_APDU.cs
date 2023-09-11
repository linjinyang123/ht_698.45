using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class Read_APDU
    {
        public byte PIID { get; set; }
        public List<OAD> list_OAD { get; set; }
        public byte RequestType { get; set; }
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
            if (list_OAD.Count == 1)
                list.AddRange(list_OAD[0].GetBytes());
            else
            {
                list.Add((byte)list_OAD.Count);
                foreach (OAD mOAD in list_OAD)
                {
                    list.AddRange(mOAD.GetBytes());
                }
            }
            return list.ToArray();
        }
    }
}