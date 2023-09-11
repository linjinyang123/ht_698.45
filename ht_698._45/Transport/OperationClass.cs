using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    //数据处理
    class OperationClass
    {
        PublicClass Dt_Class = new PublicClass();

        /// <summary>
        /// 累加和
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <param name="beginAdd">帧起始位置</param>
        /// <param name="endAdd">帧结束位置</param>
        /// <returns>解析后的帧</returns>
        public byte Data_Summtion(byte[] enData, int beginAdd, int endAdd)
        {
            byte sumByte = 0x00;
            for (int i = 0; i < (endAdd - beginAdd); i++)
            {
                sumByte += enData[i];
            }
            return sumByte;
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <param name="beginAdd">帧起始位置</param>
        /// <param name="endAdd">帧结束位置</param>
        /// <returns>解析后的帧</returns>
        public byte[] Data_EncryPtion(byte[] enData, int beginAdd, int endAdd)
        {
            for (int i = 0; i < (endAdd - beginAdd); i++)
            {
                enData[beginAdd + i] += 0x33;
            }
            return enData;
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <param name="beginAdd">帧起始位置</param>
        /// <param name="endAdd">帧结束位置</param>
        /// <returns>解析后的帧</returns>
        public byte[] Data_Decode(byte[] enData, int beginAdd, int endAdd)
        {
            for (int i = 0; i < (endAdd - beginAdd); i++)
            {
                enData[beginAdd + i] -= 0x33;
            }
            return enData;
        }

        /// <summary>
        /// 解帧数据
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <returns>解析值</returns>
        public string DataByte_Decode(byte[] enData)
        {
            string receiveString = "";
            int byteCount = 0;
            while (enData[byteCount] != 0x68)
            {
                byteCount++;
            }
            Data_Decode(enData, byteCount + 10, enData.Length - 2);

            string ss = "";

            for (int i = 0; i < enData.Length; i++)
            {
                ss += (enData[i]).ToString("X2");
            }

            switch (enData[byteCount + 8])
            {
                case 0x83:
                case 0x91:
                    //取出返回数组的数据值
                    int dataCount = Convert.ToInt32(enData[byteCount + 9] - 4);
                    byte[] dataBytes = new byte[dataCount];
                    try
                    {
                        for (int i = 0; i < dataCount; i++)
                        {
                            dataBytes[i] = enData[byteCount + 14 + i];
                        }
                    }
                    catch
                    {
                        receiveString = "err";
                    }
                    receiveString = ReadData_Decode(dataBytes);
                    break;
                case 0x94:
                    receiveString = "1";
                    break;
                default:
                    receiveString = "err";
                    break;
            }
            return receiveString;
        }

        /// <summary>
        /// 解帧数据(698)
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <returns>解析值</returns>
        public string DataByte_Decode698(byte[] enData)
        {
            string receiveString = "";
            int byteCount = 0;
            while (enData[byteCount] != 0x68)
            {
                byteCount++;
            }
            //取出返回数组的数据值
            int dataCount = Convert.ToInt32(enData.Length - byteCount - 2);//去结束位和起始位
            byte[] dataBytes = new byte[dataCount];
            try
            {
                for (int i = 0; i < dataCount; i++)
                {
                    dataBytes[i] = enData[byteCount + i + 1];
                }
            }
            catch
            { 
                receiveString = "err"; 
            }
            receiveString = ReadData_Decode698(dataBytes);
            return receiveString;
        }

        /// <summary>
        ///  串口调试
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <returns>解析值</returns>
        public string ByteTest_Decode(byte[] enData)
        {
            string receiveString = "";
            int byteCount = 0;
            while (enData[byteCount] != 0x68)
            {
                byteCount++;
            }
            Data_Decode(enData, byteCount + 10, enData.Length - 2);

            foreach (byte showItem in enData)
            {
                if (Convert.ToString(showItem, 16).Length < 2)
                    receiveString = receiveString + " " + "0" + Convert.ToString(showItem, 16);
                else
                    receiveString = receiveString + " " + Convert.ToString(showItem, 16);
            }
            return receiveString;
        }

        /// <summary>
        /// 根据标识解析
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <returns>解析值</returns>
        public string ReadData_Decode698(byte[] enData)
        {
            bool jyResult = true;
            string receiveString = "err";
            try
            {
                string dataResult = "";
                string DataFlag = Dt_Class.DataFlag;

                foreach (byte showItem in enData)
                {
                    if (Convert.ToString(showItem, 16).Length < 2)
                        dataResult = dataResult + " " + "0" + Convert.ToString(showItem, 16);
                    else
                        dataResult = dataResult + " " + Convert.ToString(showItem, 16);
                }

                #region [判 断 校 验 码]
                dataResult = dataResult.Replace(" ", "").Trim();
                string crc16Code = CRC16Util.getCrc16Code(dataResult.Substring(0, 22));
                string rCrc16Code = (dataResult.Substring(24, 2) + dataResult.Substring(22, 2)).ToUpper();
                if (rCrc16Code == crc16Code)
                {
                    crc16Code = CRC16Util.getCrc16Code(dataResult.Substring(0, dataResult.Length - 4));
                    rCrc16Code = (dataResult.Substring(dataResult.Length - 2, 2) + dataResult.Substring(dataResult.Length - 4, 2)).ToUpper();
                    if (rCrc16Code == crc16Code)
                        jyResult = true;
                    else
                        jyResult = false;
                }
                else
                    jyResult = false;
                #endregion

                if (jyResult)
                {
                    int flagInt = 0;
                    receiveString = "";

                    #region [解 析]
                    dataResult = dataResult.Substring(26, dataResult.Length - 26);
                    string flag = dataResult.Substring(0, 2);
                    dataResult = dataResult.Substring(2, dataResult.Length - 2);
                    switch (flag)
                    {
                        #region 85(GET-Response)
                        case "85":
                            flag = dataResult.Substring(0, 2);
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                            switch (flag)
                            {
                                #region 结构体数组
                                case "02":
                                    flag = dataResult.Substring(0, 2);
                                    dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                    if (flag == "00" || flag == "01" || flag == "02" || flag == "03" || flag == "04" || flag == "05" || flag == "06" || flag == "07")
                                    {
                                        flag = dataResult.Substring(0, 2);
                                        dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                        int intFlagSum = Convert.ToInt32(flag);
                                        for (int flagCount = 0; flagCount < intFlagSum; flagCount++)
                                        {
                                            //OAD
                                            flag = dataResult.Substring(0, 8);
                                            dataResult = dataResult.Substring(8, dataResult.Length - 8);
                                            //DATA
                                            flag = dataResult.Substring(0, 2);
                                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                            //数据类型
                                            flag = dataResult.Substring(0, 2);
                                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                            switch (flag)
                                            {
                                                #region octet-string
                                                case "09":
                                                    flag = dataResult.Substring(0, 2);
                                                    dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                                    receiveString = receiveString + dataResult.Substring(0, Convert.ToInt32(flag, 16) * 2);
                                                    dataResult = dataResult.Substring(Convert.ToInt32(flag, 16) * 2, dataResult.Length - Convert.ToInt32(flag, 16) * 2);
                                                    break;
                                                #endregion

                                                #region double
                                                case "06":
                                                    receiveString = receiveString + dataResult.Substring(0, 8).ToString().PadLeft(8, '0');
                                                    dataResult = dataResult.Substring(8, dataResult.Length - 8);
                                                    break;
                                                #endregion

                                                #region structure(结构数组)
                                                case "02":
                                                    //个数
                                                    flag = dataResult.Substring(0, 2);
                                                    dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                                    for (int szCount = 0; szCount < Convert.ToInt32(flag, 16); szCount++)
                                                    {
                                                        flag = dataResult.Substring(0, 2);
                                                        dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                                        switch (flag)
                                                        {
                                                            #region double
                                                            case "06":
                                                                receiveString = receiveString + dataResult.Substring(0, 8).ToString().PadLeft(8, '0');
                                                                dataResult = dataResult.Substring(8, dataResult.Length - 8);
                                                                break;
                                                            #endregion
                                                        }

                                                    }
                                                    break;
                                                #endregion
                                            }


                                        }
                                    }
                                    else
                                    {
                                        receiveString = "err";
                                    }
                                    break;
                                #endregion

                                default:
                                    receiveString = "err";
                                    break;
                            }
                            break;
                        #endregion

                        #region 82(CONNECT-Response)
                        case "82":
                            flag = dataResult.Substring(0, 2);//PIID
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);

                            flag = dataResult.Substring(0, 8);//厂家代码
                            dataResult = dataResult.Substring(8, dataResult.Length - 8);
                            byte[] flagByte = CRC16Util.StringToByteArray(flag);
                            Dt_Class.ManufacturerCode = CRC16Util.CharArrayToHexString(flagByte);

                            flag = dataResult.Substring(0, 8);//软件版本号
                            dataResult = dataResult.Substring(8, dataResult.Length - 8);
                            flagByte = CRC16Util.StringToByteArray(flag);
                            Dt_Class.SoftwareVersionNumber = CRC16Util.CharArrayToHexString(flagByte);

                            flag = dataResult.Substring(0, 12);//软件版本日期
                            dataResult = dataResult.Substring(12, dataResult.Length - 12);
                            flagByte = CRC16Util.StringToByteArray(flag);
                            Dt_Class.SoftwareVersionDate = CRC16Util.CharArrayToHexString(flagByte);

                            flag = dataResult.Substring(0, 8);//硬件版本号
                            dataResult = dataResult.Substring(8, dataResult.Length - 8);
                            flagByte = CRC16Util.StringToByteArray(flag);
                            Dt_Class.HardwareVersionNumber = CRC16Util.CharArrayToHexString(flagByte);

                            flag = dataResult.Substring(0, 12);//硬件版本日期
                            dataResult = dataResult.Substring(12, dataResult.Length - 12);
                            flagByte = CRC16Util.StringToByteArray(flag);
                            Dt_Class.HardwareVersionDate = CRC16Util.CharArrayToHexString(flagByte);

                            flag = dataResult.Substring(0, 16);//厂家扩展信息
                            dataResult = dataResult.Substring(16, dataResult.Length - 16);
                            flagByte = CRC16Util.StringToByteArray(flag);
                            Dt_Class.VendorExtension = CRC16Util.CharArrayToHexString(flagByte);

                            flag = dataResult.Substring(0, 4);//期望的应用层协议版本号
                            dataResult = dataResult.Substring(4, dataResult.Length - 4);

                            flag = dataResult.Substring(0, 16);//协议一致性
                            dataResult = dataResult.Substring(16, dataResult.Length - 16);
                            flag = dataResult.Substring(0, 32);//功能一致性
                            dataResult = dataResult.Substring(32, dataResult.Length - 32);
                            flag = dataResult.Substring(0, 4);//发送最大尺寸
                            dataResult = dataResult.Substring(4, dataResult.Length - 4);
                            flag = dataResult.Substring(0, 4);//接受最大尺寸
                            dataResult = dataResult.Substring(4, dataResult.Length - 4);
                            flag = dataResult.Substring(0, 2);//接受最大窗体尺寸
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                            flag = dataResult.Substring(0, 4);//可处理最大APDU尺寸
                            dataResult = dataResult.Substring(4, dataResult.Length - 4);
                            flag = dataResult.Substring(0, 8);//连接超时
                            dataResult = dataResult.Substring(8, dataResult.Length - 8);
                            flag = dataResult.Substring(0, 2);//连接响应对象（0为允许建立连接）
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                            flag = dataResult.Substring(0, 2);//认证附加信息（0表示无，1表示有密文数据）
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                            if (flag == "01")
                            {
                                flagInt = 0;

                                flag = dataResult.Substring(0, 2);//服务器随机数长度
                                dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                flagInt = Convert.ToInt32(flag, 16);
                                flag = dataResult.Substring(0, flagInt * 2);//服务器随机数数据
                                dataResult = dataResult.Substring(flagInt * 2, dataResult.Length - flagInt * 2);
                                Dt_Class.ServerRan = flag;

                                flag = dataResult.Substring(0, 2);//服务器签名长度
                                dataResult = dataResult.Substring(2, dataResult.Length - 2);
                                flagInt = Convert.ToInt32(flag, 16);
                                flag = dataResult.Substring(0, flagInt * 2);//服务器签名数据
                                dataResult = dataResult.Substring(flagInt * 2, dataResult.Length - flagInt * 2);
                                Dt_Class.ServerSignature = flag;
                            }
                            flag = dataResult.Substring(0, 2);//没有上报
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                            flag = dataResult.Substring(0, 2);//没有时间标签
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);
                            receiveString = "riget";

                            break;
                        #endregion

                        #region 82(CONNECT-Response)
                        case "90":
                            flagInt = 0;
                            flag = dataResult.Substring(0, 2);//SECURITY_Response
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);

                            flag = dataResult.Substring(0, 2);//密文数据长度
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);

                            flagInt = Convert.ToInt32(flag, 16);
                            flag = dataResult.Substring(0, flagInt * 2);//密文数据
                            dataResult = dataResult.Substring(flagInt * 2, dataResult.Length - flagInt * 2);
                            Dt_Class.COutData = flag;

                            flag = dataResult.Substring(0, 4);//数据MAC
                            dataResult = dataResult.Substring(4, dataResult.Length - 4);

                            flag = dataResult.Substring(0, 2);//MAC数据长度
                            dataResult = dataResult.Substring(2, dataResult.Length - 2);

                            flagInt = Convert.ToInt32(flag, 16);
                            flag = dataResult.Substring(0, flagInt * 2);//MAC数据
                            dataResult = dataResult.Substring(flagInt * 2, dataResult.Length - flagInt * 2);
                            Dt_Class.COutMAC = flag;
                            receiveString = "riget";
                            break;
                        #endregion
                        default:
                            receiveString = "err";
                            break;
                    }
                    #endregion
                }
                else
                    receiveString = "err";
            }
            catch
            {
                receiveString = "err";
            }
            return receiveString;
        }

        /// <summary>
        /// 根据标识解析
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <returns>解析值</returns>
        public string ReadData_Decode(byte[] enData)
        {
            try
            {
                string receiveString = "";
                string dataResult = "";
                string DataFlag = Dt_Class.DataFlag;
                DateTime ClearTime;
                DateTime currentTime;//当前时间
                TimeSpan cha;//时差

                #region 根据标示解析
                switch (DataFlag.ToUpper().Trim())
                {
                    case "00000000":
                    case "00000100":
                    case "00000200":
                    case "00000300":
                    case "00000400":
                    case "00010000":
                    case "00010100":
                    case "00010200":
                    case "00010300":
                    case "00010400":
                    case "00020000":
                    case "00020100":
                    case "00020200":
                    case "00020300":
                    case "00020400":
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        receiveString = string.Format("{0}.{1}", receiveString.Substring(0, 6), receiveString.Substring(6, 2));
                        break;

                    #region 时段数据
                    case "04010001":
                    case "04010002":
                    case "04010003":
                    case "04010004":
                    case "04010005":
                    case "04010006":
                    case "04010007":
                    case "04010008":
                    case "04020001":
                    case "04020002":
                    case "04020003":
                    case "04020004":
                    case "04020005":
                    case "04020006":
                    case "04020007":
                    case "04020008":
                    case "04010000":
                    case "04020000":
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        string receiveValue = "";
                        while (receiveString.Length > 5)
                        {
                            receiveValue = receiveString.Substring(0, 6) + receiveValue;
                            receiveString = receiveString.Substring(6, receiveString.Length - 6);
                        }
                        receiveString = receiveValue;
                        break;
                    #endregion

                    #region ASCII码值
                    case "04000403"://资产管理编码(ASCII码)
                    case "04000404"://额定电压(ASCII码)
                    case "04000405"://额定电流(ASCII码)
                    case "04000406"://最大电流(ASCII码)	
                    case "04000407"://有功准确度等级(ASCII码)	
                    case "0400040B"://电表型号(ASCII码)	
                    case "0400040C"://生产日期(ASCII码)
                    case "0400040D"://协议版本号(ASCII码)	
                    case "04800001"://软件版本号(ASCII码)
                    case "04800002"://硬件版本号(ASCII码)	
                    case "04800003"://厂家编号(ASCII码)	
                        foreach (byte b in enData)
                        {
                            char data = Convert.ToChar(Convert.ToInt32(Convert.ToString(b).PadLeft(2, '0')));
                            receiveString = data + receiveString;
                        }
                        break;
                    #endregion

                    #region 电压
                    case "02010100"://电压
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        receiveString = receiveString.Substring(0, 3) + "." + receiveString.Substring(3, 1);
                        break;
                    #endregion

                    #region 日期及星期及时间
                    case "0400010C":
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        dataResult = "20" + receiveString.Substring(0, 6) + receiveString.Substring(8, 6);
                        ClearTime = new DateTime(Convert.ToInt16(dataResult.Substring(0, 4)), Convert.ToInt16(dataResult.Substring(4, 2)), Convert.ToInt16(dataResult.Substring(6, 2)), Convert.ToInt16(dataResult.Substring(8, 2)), Convert.ToInt16(dataResult.Substring(10, 2)), Convert.ToInt16(dataResult.Substring(12, 2)));


                        receiveString = ClearTime.ToString("yyyy-MM-dd HH:mm:ss");

                        break;
                    #endregion

                    #region 读开盖记录
                    case "03300D01":
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        receiveString = receiveString.Substring(receiveString.Length - 24, 12) + "#" + receiveString.Substring(receiveString.Length - 12, 12);
                        break;
                    #endregion

                    #region 电表清零记录
                    case "03300101":
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        receiveString = receiveString.Substring(receiveString.Length - 12, 12);
                        if (receiveString != "000000000000")
                        {
                            dataResult = "20" + receiveString;
                            ClearTime = new DateTime(Convert.ToInt16(dataResult.Substring(0, 4)), Convert.ToInt16(dataResult.Substring(4, 2)), Convert.ToInt16(dataResult.Substring(6, 2)), Convert.ToInt16(dataResult.Substring(8, 2)), Convert.ToInt16(dataResult.Substring(10, 2)), Convert.ToInt16(dataResult.Substring(12, 2)));
                            currentTime = DateTime.Now;
                            cha = ClearTime.Subtract(currentTime).Duration(); ;
                            receiveString = cha.TotalHours.ToString();
                        }
                        else
                        {
                            receiveString = "err";
                        }


                        break;
                    #endregion

                    #region 循环显示内容
                    case "04040101":
                    case "04040102":
                    case "04040103":
                    case "04040201":
                    case "04040202":
                    case "04040203":
                    case "04040204":
                    case "04040205":
                    case "04040206":
                    case "04040207":
                    case "04040208":
                    case "04040209":
                    case "0404020A":
                    case "0404020B":
                    case "0404020C":
                    case "0404020D":
                    case "0404020E":
                    case "0404020F":
                    case "04040210":
                    case "04040211":
                    case "04040212":
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        receiveString = receiveString.Substring(2, 8) + receiveString.Substring(0, 2);

                        break;
                    #endregion

                    #region 常规参数
                    default:
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }

                        break;
                    #endregion
                }
                #endregion

                return receiveString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 解析（特殊类参数）
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <returns>解析值</returns>
        public string ReadTData_Decode(byte[] enData)
        {
            try
            {
                string receiveString = "";

                switch (Dt_Class.DataName)
                {
                    case "读取功耗":
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        receiveString = receiveString.Substring(0, 2) + "." + receiveString.Substring(2, 2);
                        break;
                    case "读厂内软件版本号":
                        Data_EncryPtion(enData, 0, enData.Length);

                        for (int byteCount = 0; byteCount < 32; byteCount++)
                        {
                            char data = Convert.ToChar(Convert.ToInt32(Convert.ToString(enData[byteCount]).PadLeft(2, '0')));
                            receiveString = receiveString + data;
                        }
                        receiveString = receiveString.Substring(0, 32);
                        break;
                    default:
                        foreach (byte b in enData)
                        {
                            string data = Convert.ToString(b, 16).PadLeft(2, '0');
                            receiveString = data + receiveString;
                        }
                        break;
                }
                return receiveString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 特殊类参数解帧数据
        /// </summary>
        /// <param name="enData">解析帧</param>
        /// <returns>解析值</returns>
        public string DataTByte_Decode(byte[] enData)
        {
            int dataCount = 0;
            byte[] dataBytes;
            string receiveString = "";
            int byteCount = 0;
            while (enData[byteCount] != 0x68)
            {
                byteCount++;
            }
            Data_Decode(enData, byteCount + 10, enData.Length - 2);
            switch (enData[byteCount + 8])
            {
                case 0x1e:
                    //取出返回数组的数据值
                    dataCount = Convert.ToInt32(enData[byteCount + 9]);
                    dataBytes = new byte[32];
                    for (int i = 0; i < 32; i++)
                    {
                        dataBytes[i] = enData[byteCount + 14 + i];
                    }
                    receiveString = ReadTData_Decode(dataBytes);
                    break;
                case 0xAA:
                case 0xA0:
                    if (Dt_Class.DataName == "厂内编号")
                    {
                        //取出返回数组的数据值
                        dataCount = Convert.ToInt32(enData[byteCount + 9]);
                        dataBytes = new byte[dataCount];
                        for (int i = 0; i < dataCount; i++)
                        {
                            dataBytes[i] = enData[byteCount + 10 + i];
                        }
                        receiveString = ReadTData_Decode(dataBytes);
                    }
                    else
                    {
                        dataCount = Convert.ToInt32(enData[byteCount + 9]);
                        dataBytes = new byte[dataCount - 4];
                        for (int i = 0; i < dataCount - 4; i++)
                        {
                            dataBytes[i] = enData[byteCount + 14 + i];
                        }
                        receiveString = ReadTData_Decode(dataBytes);
                    }
                    break;
                case 0xA1:
                case 0x91:
                    //取出返回数组的数据值
                    dataCount = Convert.ToInt32(enData[byteCount + 9]);
                    dataBytes = new byte[dataCount - 4];
                    for (int i = 0; i < dataCount - 4; i++)
                    {
                        dataBytes[i] = enData[byteCount + 14 + i];
                    }
                    receiveString = ReadTData_Decode(dataBytes);
                    break;
                case 0xA4:
                case 0x99:
                case 0x9A:
                case 0xAB:
                case 0x9B:
                case 0x9C:
                case 0x96:
                    receiveString = "1";
                    break;
                case 0x9F:
                    if (Dt_Class.DataRW == "1")
                        receiveString = "1";
                    else
                    {
                        //取出返回数组的数据值
                        dataCount = Convert.ToInt32(enData[byteCount + 9]);
                        dataBytes = new byte[dataCount];
                        for (int i = 0; i < dataCount; i++)
                        {
                            dataBytes[i] = enData[byteCount + 10 + i];
                        }
                        receiveString = ReadTData_Decode(dataBytes);
                    }
                    break;
                default:
                    receiveString = "err";
                    break;
            }
            return receiveString;
        }

        /// <summary>
        /// 16进制转换为10进制
        /// </summary>
        /// <param name="data">解析数据</param>
        /// <returns>转换值</returns>
        public string Turn16to10(string data)
        {
            return data;
        }
    }
}