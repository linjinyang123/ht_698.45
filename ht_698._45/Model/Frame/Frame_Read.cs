﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    public class Frame_Read
    {
        public const byte Head = 0x68;
        public const byte End = 0x16;
        public byte CA { get; set; }
        public byte[] SA { get; set; }
        public byte SA_TYPE { get; set; }

        /// <summary>
        /// 控制字
        /// </summary>
        public byte C { get; set; }
        public Read_APDU mAPDU { get; set; }
        public byte Time = 0;

        /// <summary>
        /// 帧长度
        /// </summary>
        public ushort Length
        {
            get
            {
                return (ushort)(1 + SA.Length + 1 + 1 + mAPDU.GetSize() + 1 + 4 + 2);
            }
        }

        /// <summary>
        /// 帧头校验
        /// </summary>
        public ushort HCS
        {
            get
            {
                List<byte> list = new List<byte>();
                list.AddRange(BitConverter.GetBytes(Length));
                list.Add(C);
                list.Add(SA_TYPE);
                list.AddRange(SA);
                list.Add(CA);
                return BitConverter.ToUInt16(CS.PPPFCS16(list.ToArray(), 0, list.Count), 0);
            }
        }

        /// <summary>
        /// 帧尾校验
        /// </summary>
        public ushort FCS
        {
            get
            {
                List<byte> list = new List<byte>();
                list.AddRange(BitConverter.GetBytes(Length));
                list.Add(C);
                list.Add(SA_TYPE);
                list.AddRange(SA);
                list.Add(CA);
                list.AddRange(BitConverter.GetBytes(HCS));
                list.AddRange(mAPDU.GetByte());
                list.Add(Time);
                return BitConverter.ToUInt16(CS.PPPFCS16(list.ToArray(), 0, list.Count), 0);
            }
        }

        public byte[] GetBytes()
        {
            List<byte> list = new List<byte>();

            list.Add(Head);
            list.AddRange(BitConverter.GetBytes(Length));
            list.Add(C);
            list.Add(SA_TYPE);
            list.AddRange(SA);
            list.Add(CA);
            list.AddRange(BitConverter.GetBytes(HCS));
            list.AddRange(mAPDU.GetByte());
            list.Add(Time);
            list.AddRange(BitConverter.GetBytes(FCS));
            list.Add(End);
            return list.ToArray();
        }

        /// <summary>
        /// 解析返回帧
        /// </summary>
        /// <param name="list"></param>
        /// <param name="code"></param>
        /// <param name="data"></param>
        public void ParseFrame(List<byte> list, out string code, out List<string> data, out bool result)
        {
            result = true;

            code = "";
            data = new List<string>();
            try
            {
                while (list[0] == 0xfe)
                {
                    string a = list._ToString(false);
                    list.RemoveAt(0);
                }

                if (list[0] != 0x68)
                {
                    code = "帧头不是68" + list[0];
                    result = false;
                    data = null;
                    return;
                }
                list.RemoveAt(0);
                if (list[list.Count - 1] != 0x16)
                {
                    code = "帧尾不是16" + list[list.Count];
                    result = false;
                    data = null;
                    return;
                }

                list.RemoveAt(list.Count - 1);

                var length = (Convert.ToInt32(new byte[] { list[0], list[1] }._ToString(), 16));//字节长度

                //if (length != list.Count)
                //{
                //    code = "长度不正确" + length.ToString();
                //    result = false;
                //    data = null;
                //    return;
                //}
                list.RemoveRange(0, 2);
                C = list[0];//控制字
                list.RemoveAt(0);

                list.RemoveAt(0);//05

                list.RemoveRange(0, 6);//移除表地址

                list.RemoveRange(0, 1);//移除客户机地址

                ushort mHCS = (ushort)(Convert.ToInt32(new byte[] { list[0], list[1] }._ToString(), 16));
                //if (mHCS != HCS) 
                //{
                //    code = "帧头校验不合格" + mHCS;
                //    result = false;
                //    return;
                //}
                list.RemoveRange(0, 2);//帧头校验
                ParseAPDU(list, ref code, ref data, ref result);
            }
            catch
            {
                result = false;
            }
        }

        public void ParseGET_Respone(List<byte> list, ref string code, ref List<string> data, ref bool result)
        {
            var getResponse = list[0];
            list.RemoveAt(0);
            switch (getResponse)
            {
                //读取单个对象属性
                case 0x01:
                    list.RemoveAt(0);

                    list.RemoveRange(0, 4);

                    Data mData = new Data();
                    mData.DAR = list[0]; list.RemoveAt(0);
                    if (mData.DAR != 0x01)
                    {
                        result = false;
                        return;
                    }
                    var dataParse = mData.Parse(ref list, ref mData);
                    mData.DataValue = dataParse;
                    data.Add(dataParse);
                    break;

                case 0x02:
                    list.RemoveAt(0);
                    var mCount = (int)list[0];
                    list.RemoveAt(0);
                    for (int i = 0; i < mCount; i++)
                    {
                        list.RemoveRange(0, 4);
                        mData = new Data();
                        mData.DAR = list[0];
                        if (mData.DAR != 0x01)
                        {
                            result = false;
                            return;
                        }
                        list.RemoveAt(0);
                        dataParse = mData.Parse(ref list, ref mData);
                        mData.DataValue = dataParse;
                        data.Add(dataParse);
                    }
                    break;

                case 0x03:
                    list.RemoveAt(0);
                    list.RemoveRange(0, 4);

                    var mCount1 = (int)list[0];
                    list.RemoveAt(0);
                    list.RemoveAt(0);
                    for (int i = 0; i < mCount1; i++)
                    {
                        list.RemoveRange(0, 4);
                        mData = new Data();
                        mData.DAR = list[0];
                        if (mData.DAR != 0x01)
                        {
                            result = false;
                            return;
                        }
                        list.RemoveAt(0);
                        list.RemoveAt(0);
                        list.RemoveRange(list.Count - 2, 2);
                        dataParse = mData.Parse(ref list, ref mData);
                        mData.DataValue = dataParse;
                        data.Add(dataParse);
                    }
                    break;

                case 0x04: break;

                case 0x05: break;

                default:
                    code = "GET_Response出错";
                    result = false;
                    return;
            }
        }

        public void ParseAPDU(List<byte> list, ref string code, ref List<string> data, ref bool result)
        {
            var ServerAPDU = list[0];
            list.RemoveAt(0);
            switch (ServerAPDU)
            {
                case 0x82:
                    if (ServerAPDU != 0x82)
                    {
                        code = "ServerAPDU出错";
                        result = false;
                        return;
                    }
                    break;

                case 0x83:
                    if (ServerAPDU != 0x83)
                    {
                        code = "ServerAPDU出错";
                        result = false;
                        return;
                    }
                    break;

                case 0x85:
                    if (ServerAPDU != 0x85)
                    {
                        code = "ServerAPDU出错";
                        result = false;
                        return;
                    }
                    break;

                case 0x86:
                    if (ServerAPDU != 0x85)
                    {
                        code = "ServerAPDU出错";
                        result = false;
                        return;
                    }
                    break;

                case 0x87:
                    if (ServerAPDU != 0x82)
                    {
                        code = "ServerAPDU出错";
                        result = false;
                        return;
                    }
                    break;

                default:
                    code = "ClientAPDU出错";
                    result = false;
                    return;
            }
            ParseGET_Respone(list, ref code, ref data, ref result);
        }
    }
}