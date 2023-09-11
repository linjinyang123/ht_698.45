using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public static class _Convert
    {
        public static string _CharToString(this IEnumerable<byte> data, bool Resevers = true)
        {
            /// <summary>
            /// char数组转为十六进制字符串
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>

            string tempString = "";
            foreach (byte b in data)
            {
                tempString += Convert.ToString(Convert.ToChar(Convert.ToInt32(b)));
            }
            tempString = tempString.Replace("\0", "");
            tempString = tempString.Replace(" ", "");
            tempString.Trim();
            return tempString;
        }

        public static string _ToString(this IEnumerable<byte> data, bool Resevers = true)
        {
            StringBuilder sb = new StringBuilder();
            if (Resevers)
                data = data.Reverse();
            foreach (var d in data)
            {
                sb.AppendFormat("{0:X2}", d);
            }
            return Convert.ToString(sb);
        }

        public static byte[] _ToBytes(ulong value)
        {
            var temp = Convert.ToString(Convert.ToInt32(value), 16);
            return new byte[] { _ToByte(temp.Substring(0, 2)), _ToByte(temp.Substring(2, 2)) };
        }

        public static string _ToHex16(string value)
        {
            int tempCount = value.Length;
            var temp = Convert.ToString(Convert.ToInt32(value), 16).PadLeft(tempCount, '0');
            return temp;
        }

        public static DateTime _ToDateTime(string value)
        {
            DateTime temp = new DateTime();
            value = string.Format("{0}/{1}/{2} {3}:{4}:{5}", value.Substring(0, 4), value.Substring(4, 2), value.Substring(6, 2), value.Substring(8, 2), value.Substring(10, 2), value.Substring(12, 2));
            temp = Convert.ToDateTime(value);
            return temp;
        }

        public static string _ToHex10(string value)
        {
            int tempCount = value.Length;
            var temp = Convert.ToString(Convert.ToInt32(value, 16)).PadLeft(tempCount, '0');
            return temp;
        }

        public static byte[] _ToBytes(string value, bool Resevers = true)
        {
            List<byte> list = new List<byte>();
            var count = value.Length / 2;
            for (int i = 0; i < count; i++)
            {
                list.Add(_ToByte(value.Substring(i * 2, 2)));
            }
            if (Resevers)
                list.Reverse();
            return list.ToArray();
        }

        public static byte _ToByte(string value)
        {
            var temp = Convert.ToByte(Convert.ToInt32(value, 16));
            return temp;
        }
    }
}