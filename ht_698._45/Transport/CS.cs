using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class CS
    {
        static ushort[] fcstab = null;
        static CS()
        {
            #region [生成加密数据表]
            uint b, v, P = 0x8408;
            int i;
            fcstab = new ushort[256];
            for (b = 0; ; )
            {
                v = b;
                for (i = 8; i-- > 0; )
                    v = (v & 1) > 0 ? (v >> 1) ^ P : v >> 1;
                fcstab[b] = (ushort)v;
                if (++b == 256)
                    break;
            }
            #endregion
        }
        private CS()
        {

        }
        public static ushort[] FcsTable { get { return fcstab; } }

        /// <summary>
        /// 计算fcs
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="begin"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte[] PPPFCS16(ICollection<byte> cp, int begin, int len)
        {
            return BitConverter.GetBytes(PPPFCS16(PPPINITFCS16, cp, begin, len));
        }

        /// <summary>
        /// 根据给定的 fcs 和 data 计算新的 fcs
        /// </summary>
        /// <param name="fcs"></param>
        /// <param name="cp"></param>
        /// <param name="bengin"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static ushort PPPFCS16(ushort fcs, ICollection<byte> cp, int bengin, int len)
        {
            if (cp == null)
                throw new NullReferenceException("cp");
            if ((bengin + len) > cp.Count)
                throw new IndexOutOfRangeException("cp");

            for (int i = 0; i < len; i++)//cp[bengin + i]
            {
                var s1 = (fcs >> 8);
                var s2 = (fcs ^ cp.ElementAt(bengin + i));
                var s3 = s2 & 0xFF;
                var s4 = fcstab[s3];
                var s5 = s1 ^ s4;
                var s6 = (ushort)(s5);
                fcs = (ushort)((fcs >> 8) ^ fcstab[(fcs ^ cp.ElementAt(bengin + i)) & 0xFF]);
            }
            return fcs ^= 0xFFFF;
        }

        public const ushort PPPINITFCS16 = 0xFFFF;
        public const ushort PPPGOODFCS16 = 0xF0B8;
    }
}