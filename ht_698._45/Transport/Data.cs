using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class Data
    {
        public byte DAR { get; set; }
        public byte DataSize { get; set; }
        public string DataValue { get; set; }
        public byte DataType { get; set; }

        public byte[] GetBytes()
        {
            List<byte> list = new List<byte>();
            list.Add(DataType);
            list.AddRange(_Convert._ToBytes(DataValue, false));
            return list.ToArray();
        }

        public byte getType(OAD mOAD)
        {
            string strOAD = mOAD.mOAD._ToString(false);
            byte temp = 0;
            switch (strOAD)
            {
                case "40020200":
                    temp = 9;
                    DataSize = 8;
                    break;

                case "40010200":
                case "40030200":
                    temp = 9;
                    DataSize = 6;
                    break;

                case "43000400":
                    temp = 28;
                    break;

                case "41030200":
                    temp = 10;
                    DataSize = 32;
                    break;

                case "F3010401":
                    temp = 17;
                    break;
            }
            return temp;
        }

        public string Encrypt(byte dataType, string data)
        {
            string temp = "";
            switch (dataType)
            {
                ///日期
                case 28:
                    temp = temp + _Convert._ToHex16(data.Substring(0, 4));//年
                    temp = temp + _Convert._ToHex16(data.Substring(4, 2));//月
                    temp = temp + _Convert._ToHex16(data.Substring(6, 2));//日
                    temp = temp + _Convert._ToHex16(data.Substring(8, 2));//时
                    temp = temp + _Convert._ToHex16(data.Substring(10, 2));//分
                    temp = temp + _Convert._ToHex16(data.Substring(12, 2));//秒
                    break;

                case 9:
                    temp = Convert.ToString(DataSize, 16).PadLeft(2, '0') + data.PadLeft(DataSize * 2, '0');
                    break;

                case 10:
                    var dataByte = System.Text.Encoding.ASCII.GetBytes(data);
                    foreach (byte b in dataByte)
                    {
                        temp = temp + Convert.ToString(Convert.ToInt32(b), 16);
                    }
                    while (temp.Length / 2 < DataSize)
                    {
                        temp = temp + "00";
                    }
                    temp = Convert.ToString(DataSize, 16).PadLeft(2, '0') + temp;
                    break;

                case 17:
                    temp = _Convert._ToHex16(data).PadLeft(2, '0');
                    break;
            }
            return temp;
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }

        public int GetDataType()
        {
            throw new NotImplementedException();
        }

        public string Parse(ref List<byte> list, ref Data mData)
        {
            var mDataType = list[0];
            list.RemoveAt(0);
            mData.DataType = mDataType;
            byte[] bData;
            string strData = "";
            switch (mDataType)
            {
                case 1:
                    var mDataSize = list[0];
                    strData = "";
                    list.RemoveAt(0);
                    for (int i = 0; i < mDataSize; i++)
                    {
                        strData = strData + "#" + Parse(ref list, ref mData);
                    }
                    mData.DataValue = strData;
                    break;

                case 2:
                    mDataSize = list[0];
                    strData = "";
                    list.RemoveAt(0);
                    for (int i = 0; i < mDataSize; i++)
                    {
                        strData = strData + "#" + Parse(ref list, ref mData);
                    }
                    mData.DataValue = strData;
                    break;

                case 3:
                    mDataSize = 1;
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 4:
                    mDataSize = list[0];
                    list.RemoveAt(0);
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize / 8];
                    list.CopyTo(0, bData, 0, mDataSize / 8);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize / 8);
                    break;

                case 5:
                    mDataSize = 4;
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 6:
                    mDataSize = 4;
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 9:
                    mDataSize = list[0];
                    list.RemoveAt(0);
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 10:
                    mDataSize = list[0];
                    strData = "";
                    list.RemoveAt(0);
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    strData = strData + _Convert._CharToString(bData, false);
                    mData.DataValue = strData;
                    list.RemoveRange(0, mDataSize);
                    break;

                case 16:
                    mDataSize = 2;
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 17:
                    mData.DataValue = Convert.ToString(list[0], 10).PadLeft(2, '0');
                    list.RemoveAt(0);
                    break;

                case 18:
                    mDataSize = 2;
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 22:
                    mDataSize = 1;
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 28:
                    bData = new byte[2];
                    list.CopyTo(0, bData, 0, 2);
                    string year = bData._ToString(false);
                    year = _Convert._ToHex10(year);
                    list.RemoveRange(0, 2);

                    string mon = Convert.ToString(list[0]).PadLeft(2, '0');
                    list.RemoveAt(0);
                    string day = Convert.ToString(list[0]).PadLeft(2, '0');
                    list.RemoveAt(0);
                    string hour = Convert.ToString(list[0]).PadLeft(2, '0');
                    list.RemoveAt(0);
                    string min = Convert.ToString(list[0]).PadLeft(2, '0');
                    list.RemoveAt(0);
                    string sec = "";
                    if (list[0] == 0xff)
                        sec = "FF";
                    else
                        sec = Convert.ToString(list[0]).PadLeft(2, '0');
                    list.RemoveAt(0);
                    mData.DataValue = year + mon + day + hour + min + sec;
                    break;

                case 81:
                    mDataSize = 4;
                    mData.DataSize = mDataSize;
                    bData = new byte[mDataSize];
                    list.CopyTo(0, bData, 0, mDataSize);
                    mData.DataValue = bData._ToString(false);
                    list.RemoveRange(0, mDataSize);
                    break;

                case 91:
                    mDataSize = list[0];
                    list.RemoveAt(0);
                    if (mDataSize == 0x00)
                    {
                        mDataSize = 4;
                        mData.DataSize = mDataSize;
                        bData = new byte[mDataSize];
                        list.CopyTo(0, bData, 0, mDataSize);
                        mData.DataValue = bData._ToString(false);
                        list.RemoveRange(0, mDataSize);
                    }
                    else
                    {
                        mDataSize = 4;
                        mData.DataSize = mDataSize;
                        bData = new byte[mDataSize];
                        list.CopyTo(0, bData, 0, mDataSize);
                        mData.DataValue = bData._ToString(false);
                        list.RemoveRange(0, mDataSize);

                        mDataSize = list[0];
                        list.RemoveAt(0);
                        for (int i = 0; i < mDataSize; i++)
                        {
                            mData.DataSize = 4;
                            bData = new byte[4];
                            list.CopyTo(0, bData, 0, 4);
                            mData.DataValue = mData.DataValue + "#" + bData._ToString(false);
                            list.RemoveRange(0, 4);
                        }
                    }
                    break;

                default:
                    break;
            }
            return mData.DataValue;
        }
    }
}