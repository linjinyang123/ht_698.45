using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class RSD
    {
        Selector _Selector9 = new Selector9();
        public byte RSDType { get; set; }
        public byte[] GetByte()
        {
            List<byte> list = new List<byte>();
            list.Add(RSDType);
            list.AddRange(_Selector9.GetByte());
            return list.ToArray();
        }
    }
    public interface Selector
    {
        byte[] GetByte();
    }
    public class Selector9 : Selector
    {
        public byte _count { get; set; }
        public byte[] GetByte()
        {
            List<byte> list = new List<byte>();
            list.Add(0x09);
            list.Add(_count);
            return list.ToArray();
        }
    }
}