using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using ht_698._45.Model.Base;
namespace ht_698._45
{
    //端口类操作
    class PortClass
    {
        public const byte Head = 0x68;
        public const byte End = 0x16;
        public string itemComName;
        public static SerialPort serialPortRS485 = new SerialPort();//485通道
        public static SerialPort serialPortZB = new SerialPort();//载波通道
        public static SerialPort serialPortJJ = new SerialPort();//夹具通道
        public static SerialPort serialPortGH = new SerialPort();//功耗表通道
        public static SerialPort serialPortHW = new SerialPort();//红外通道
        OperationClass DataOp_Class = new OperationClass();
        PublicClass Dt_Class = new PublicClass();
        public byte[] byteSend = new byte[16];
        public byte[] byteRecive = new byte[0];
        SocketApiClass SocketApi_Class = new SocketApiClass();

        /// <summary>
        /// 打开与关闭串口连接
        /// </summary>
        /// <returns>结果</returns>
        public bool PortConnect()
        {
            Parity pParity;
            bool isOpen = true;
            try
            {
                #region [RS485]
                if (serialPortRS485.IsOpen)
                {
                    serialPortRS485.Close();
                    serialPortRS485.Dispose();
                }
                serialPortRS485.PortName = PortInfo.PortName;
                pParity = (Parity)Enum.Parse(typeof(Parity), PortInfo.ParityName);
                serialPortRS485.BaudRate = Convert.ToInt32(PortInfo.BaudRatName); ;
                serialPortRS485.DataBits = 8;
                serialPortRS485.Parity = pParity;
                serialPortRS485.StopBits = StopBits.One;
                serialPortRS485.ReadTimeout = 1000;
                serialPortRS485.WriteTimeout = 1000;
                serialPortRS485.Handshake = Handshake.None;
                serialPortRS485.ReceivedBytesThreshold = 10;
                serialPortRS485.RtsEnable = true;
                if (!serialPortRS485.IsOpen)
                {
                    serialPortRS485.Open();
                    serialPortRS485.RtsEnable = true;
                }
                else
                    isOpen = false;
                #endregion
            }
            catch
            {
                isOpen = false;
            }
            return isOpen;
        }

        /// <summary>
        /// 写参数编码
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string WriteData_EncryPtion()
        {
            string enWriteData = "";
            string data = Dt_Class.Data;
            int dataLen = Dt_Class.DataLen;
            switch (Dt_Class.DataFlag)
            {
                #region [ASCII 码]
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
                    while (data.Length < dataLen)
                    {
                        data = data + "\0";
                    }
                    char[] datChar = data.ToCharArray();
                    for (int dataCount = 0; dataCount < data.Length; dataCount++)
                    {
                        enWriteData = enWriteData + Convert.ToString(((int)datChar[dataCount]), 16).PadLeft(2, '0');//转成ASCII码
                    }
                    break;
                #endregion

                #region [时 段 数 据]
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
                    while (data.Length > 5)
                    {
                        enWriteData = data.Substring(0, 6) + enWriteData;
                        data = data.Substring(6, data.Length - 6);
                    }
                    break;
                #endregion

                #region [循环显示内容]
                case "04040101":
                case "04040102":
                case "04040103":
                case "04040104":
                case "04040105":
                case "04040106":
                case "04040107":
                case "04040108":
                case "04040109":
                case "0404010A":
                case "0404010B":
                case "0404010C":
                case "0404010D":
                case "0404010E":
                case "0404010F":
                case "04040110":
                case "04040112":
                case "04040111":

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
                case "04040213":
                case "04040214":
                case "04040215":
                case "04040216":
                    enWriteData = data.Substring(8, 2) + data.Substring(0, 8);

                    break;
                #endregion

                default:
                    enWriteData = data.PadLeft(dataLen, '0');
                    break;
            }
            return enWriteData;
        }

        /// <summary>
        /// 读参数
        /// </summary>
        /// <returns>结果</returns>
        public string ReadPort_Data()
        {
            byteRecive = new byte[0];
            byteSend = new byte[16];
            string receiveString = "";
            try
            {
                if (serialPortRS485.IsOpen == false)
                    serialPortRS485.Open();

                byteSend[0] = 0x68;
                for (int i = 1; i < 7; i++)
                {
                    byteSend[i] = Convert.ToByte(Convert.ToInt32(Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2), 16));
                }
                byteSend[7] = 0x68;
                byteSend[8] = 0x11;
                byteSend[9] = 0x04;
                byteSend[10] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(6, 2), 16));
                byteSend[11] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(4, 2), 16));
                byteSend[12] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(2, 2), 16));
                byteSend[13] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(0, 2), 16));
                byteSend = DataOp_Class.Data_EncryPtion(byteSend, 10, 14);
                byteSend[14] = DataOp_Class.Data_Summtion(byteSend, 0, 14);
                byteSend[15] = 0x16;
                serialPortRS485.DiscardInBuffer();
                serialPortRS485.Write(byteSend, 0, byteSend.Length);
                

                //for (int i = 0; i < 10; i++)
                //{
                //    Thread.Sleep(10);
                //    if (serialPortRS485.BytesToRead > 0)
                //        break;
                //
                //    Application.DoEvents();
                //}

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(50);
                    if (serialPortRS485.BytesToRead > 0)
                    {
                        int count = serialPortRS485.BytesToRead;
                        Thread.Sleep(20);
                        while (serialPortRS485.BytesToRead - count > 0)
                        {
                            count = serialPortRS485.BytesToRead;
                            Thread.Sleep(20);
                        }
                        break;
                    }
                    Application.DoEvents();
                }

                Application.DoEvents();
                var bytesToRead = serialPortRS485.BytesToRead;
                byteRecive = new byte[serialPortRS485.BytesToRead];
                serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                serialPortRS485.Dispose();
                serialPortRS485.Close();

                string ss = "";

                for (int i = 0; i < byteRecive.Length; i++)
                {
                    ss += (byteRecive[i]).ToString("X2");
                }
                string cc = byteSend._ToString(false);
                receiveString = DataOp_Class.DataByte_Decode(byteRecive);

                return receiveString;
            }
            catch
            {
                INIClass.SaveLog(Dt_Class.Bh + ":" + byteRecive._ToString(false));
                receiveString = "err";
                return receiveString;
            }
        }

        public List<byte> ReadPort_Data_698(byte[] byteSend)
        {
            byteRecive = new byte[0];

            List<string> listBuffer = new List<string>();
            try
            {
                if (serialPortRS485.IsOpen == false)
                    serialPortRS485.Open();

                serialPortRS485.DiscardInBuffer();

                string ss1 = byteSend._ToString(false);

                serialPortRS485.Write(byteSend, 0, byteSend.Length);

                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(50);
                    if (serialPortRS485.BytesToRead > 0)
                    {
                        int count = serialPortRS485.BytesToRead;
                        Thread.Sleep(20);
                        while (serialPortRS485.BytesToRead - count > 0)
                        {
                            count = serialPortRS485.BytesToRead;
                            Thread.Sleep(20);
                        }
                        break;
                    }
                    Application.DoEvents();
                }

                Application.DoEvents();
                var bytesToRead = serialPortRS485.BytesToRead;
                byteRecive = new byte[serialPortRS485.BytesToRead];
                serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                serialPortRS485.Dispose();
                serialPortRS485.Close();
                List<byte> listByte = new List<byte>();

                string ss = byteRecive._ToString(false);

                listByte.AddRange(byteRecive);
                return listByte;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 写后读比对参数
        /// </summary>
        /// <returns>结果</returns>
        public string WReadPort_Data()
        {
            byteRecive = new byte[0];
            byteSend = new byte[16];
            string receiveString = "";
            try
            {
                #region 选择通讯口
                switch (itemComName)
                {
                    case "RS485通信":
                        if (serialPortRS485.IsOpen == false)
                        {
                            serialPortRS485.Open();
                        }
                        break;

                    case "载波通信":
                        if (serialPortZB.IsOpen == false)
                        {
                            serialPortZB.Open();
                        }
                        break;

                    case "功耗表通信":
                        if (serialPortGH.IsOpen == false)
                        {
                            serialPortGH.Open();
                        }
                        break;

                    case "夹具通信":
                        if (serialPortJJ.IsOpen == false)
                        {
                            serialPortJJ.Open();
                        }
                        break;

                    case "红外通信":
                        if (serialPortHW.IsOpen == false)
                        {
                            serialPortHW.Open();
                        }
                        break;
                }
                #endregion

                byteSend[0] = 0x68;
                for (int i = 1; i < 7; i++)
                {
                    byteSend[i] = Convert.ToByte(Convert.ToInt32(Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2), 16));
                }
                byteSend[7] = 0x68;
                byteSend[8] = 0x11;
                byteSend[9] = 0x04;
                byteSend[10] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(6, 2), 16));
                byteSend[11] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(4, 2), 16));
                byteSend[12] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(2, 2), 16));
                byteSend[13] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(0, 2), 16));
                byteSend = DataOp_Class.Data_EncryPtion(byteSend, 10, 14);
                byteSend[14] = DataOp_Class.Data_Summtion(byteSend, 0, 14);
                byteSend[15] = 0x16;
                int bytesToRead;

                #region COM口通讯
                switch (itemComName)
                {
                    case "RS485通信":
                        #region RS485通信
                        serialPortRS485.DiscardInBuffer();
                        serialPortRS485.Write(byteSend, 0, 16);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortRS485.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500);
                        Application.DoEvents();
                        bytesToRead = serialPortRS485.BytesToRead;
                        byteRecive = new byte[serialPortRS485.BytesToRead];
                        serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                        serialPortRS485.Dispose();
                        serialPortRS485.Close();
                        #endregion
                        break;

                    case "载波通信":
                        #region 载波通信
                        serialPortZB.DiscardInBuffer();
                        serialPortZB.Write(byteSend, 0, 16);
                        for (int i = 0; i < 50; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortZB.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(1000);
                        Application.DoEvents();
                        bytesToRead = serialPortZB.BytesToRead;
                        byteRecive = new byte[serialPortZB.BytesToRead];
                        serialPortZB.Read(byteRecive, 0, serialPortZB.BytesToRead);
                        serialPortZB.Dispose();
                        serialPortZB.Close();
                        #endregion
                        break;

                    case "功耗表通信":
                        #region 功耗表通信
                        serialPortGH.DiscardInBuffer();
                        serialPortGH.Write(byteSend, 0, 16);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortGH.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500);
                        Application.DoEvents();
                        bytesToRead = serialPortGH.BytesToRead;
                        byteRecive = new byte[serialPortGH.BytesToRead];
                        serialPortGH.Read(byteRecive, 0, serialPortGH.BytesToRead);
                        serialPortGH.Dispose();
                        serialPortGH.Close();
                        #endregion
                        break;

                    case "夹具通信":
                        #region 夹具通信
                        serialPortJJ.DiscardInBuffer();
                        serialPortJJ.Write(byteSend, 0, 16);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortJJ.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500);
                        Application.DoEvents();
                        bytesToRead = serialPortJJ.BytesToRead;
                        byteRecive = new byte[serialPortJJ.BytesToRead];
                        serialPortJJ.Read(byteRecive, 0, serialPortJJ.BytesToRead);
                        serialPortJJ.Dispose();
                        serialPortJJ.Close();
                        #endregion
                        break;

                    case "红外通信":
                        #region 红外通信
                        serialPortHW.DiscardInBuffer();
                        serialPortHW.Write(byteSend, 0, 16);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortHW.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500);
                        Application.DoEvents();
                        bytesToRead = serialPortHW.BytesToRead;
                        byteRecive = new byte[serialPortHW.BytesToRead];
                        serialPortHW.Read(byteRecive, 0, serialPortHW.BytesToRead);
                        serialPortHW.Dispose();
                        serialPortHW.Close();
                        #endregion
                        break;
                }
                #endregion

                receiveString = DataOp_Class.DataTByte_Decode(byteRecive);
                return receiveString;
            }
            catch
            {
                receiveString = "err";
                return receiveString;
            }
        }

        /// <summary>
        /// （安全认证）
        /// </summary>
        /// <param name="di3">di3</param>
        /// <returns>结果</returns>
        public void SafetyWritePort_Data_698(string bhString, ref bool result)
        {
            //if (Dt_Class.BlnSafety)
            //{
            //    return;
            //}
            Dt_Class.PutDiv = "0000" + bhString;
            string receiveString = "";
            //#region 取随机数1,密文1
            //string input = Dt_Class.PutDiv;
            //bool safetyDataString = SocketApi_Class.doTerminal_Formal_GetR1();
            //#endregion

            try
            {
                #region 选择通讯口
                switch (itemComName)
                {
                    case "RS485通信":
                        if (serialPortRS485.IsOpen == false)
                        {
                            serialPortRS485.Open();
                        }
                        break;
                }
                #endregion

                #region 取ESMA信息
                string byteSendString = "28 00 43 05 ";

                for (int i = 1; i < 7; i++)
                {
                    string bh1 = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                    byteSendString = byteSendString + bh1 + " ";
                }
                byteSendString = byteSendString + "11 ";
                string crc16Code = CRC16Util.getCrc16Code(byteSendString);

                byteSendString = byteSendString + crc16Code.Substring(2, 2) + " " + crc16Code.Substring(0, 2);
                byteSendString = byteSendString + " 05 02 00 05 F1 00 02 00 F1 00 04 00 F1 00 05 00 F1 00 06 00 F1 00 07 00 00 ";
                crc16Code = CRC16Util.getCrc16Code(byteSendString);
                byteSendString = byteSendString + crc16Code.Substring(2, 2) + " " + crc16Code.Substring(0, 2);
                byteSendString = "68 " + byteSendString + " 16";
                byteSendString = byteSendString.Replace(" ", "").Trim();
                byteSend = CRC16Util.HexString2Bytes(byteSendString);
                #endregion

                int bytesToRead;

                #region COM口通讯
                switch (itemComName)
                {

                    case "RS485通信":
                        #region RS485通信
                        serialPortRS485.DiscardInBuffer();
                        serialPortRS485.Write(byteSend, 0, byteSend.Length);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortRS485.BytesToRead > 0)
                                break;
                            Application.DoEvents();
                        }
                        Thread.Sleep(800);
                        Application.DoEvents();
                        bytesToRead = serialPortRS485.BytesToRead;
                        byteRecive = new byte[serialPortRS485.BytesToRead];
                        serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                        serialPortRS485.Dispose();
                        serialPortRS485.Close();
                        #endregion
                        break;
                }
                #endregion

                receiveString = DataOp_Class.DataByte_Decode698(byteRecive);

                #region 获取主站会话协商数据
                string cESAMID = receiveString.Substring(0, 16);
                Dt_Class.CESAMID = cESAMID;
                string cASCTR = receiveString.Substring(receiveString.Length - 24, 8);
                cASCTR = Convert.ToString(Convert.ToInt32(cASCTR, 16) + 1, 16).PadLeft(8, '0');//+1
                Dt_Class.CASCTR = cASCTR;
                result = SocketApi_Class.doObj_Meter_Formal_InitSession(0, cESAMID, cASCTR, "01");
                #endregion

                if (!result)
                    return;

                #region 选择通讯口
                switch (itemComName)
                {
                    case "RS485通信":
                        if (serialPortRS485.IsOpen == false)
                            serialPortRS485.Open();
                        break;
                }
                #endregion

                #region 建立连接
                byteSendString = "";
                byteSendString = "5E 00 43 05 ";
                for (int i = 1; i < 7; i++)
                {
                    string bh1 = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                    byteSendString = byteSendString + bh1 + " ";
                }
                byteSendString = byteSendString + "11 ";
                crc16Code = CRC16Util.getCrc16Code(byteSendString);
                byteSendString = byteSendString + crc16Code.Substring(2, 2) + " " + crc16Code.Substring(0, 2);
                byteSendString = byteSendString + " 02 03 ";
                byteSendString = byteSendString + "00 16 ";
                byteSendString = byteSendString + "FF FF FF FF C0 00 00 00 ";
                byteSendString = byteSendString + "FF FE C4 00 00 00 00 00 00 00 00 00 00 00 00 00 ";
                byteSendString = byteSendString + "02 00 ";
                byteSendString = byteSendString + "02 00 ";
                byteSendString = byteSendString + "01 ";
                byteSendString = byteSendString + "07 D0 ";
                byteSendString = byteSendString + "00 00 1C 20 ";
                byteSendString = byteSendString + "02 ";

                #region 对称加密
                string temp = Dt_Class.COutSessionInit;
                byteSendString = byteSendString + CRC16Util.String10ToString16((temp.Length / 2).ToString()) + " ";
                for (int i = 0; i < temp.Length / 2; i++)
                {
                    byteSendString = byteSendString + temp.Substring(i * 2, 2) + " ";
                }
                temp = Dt_Class.COutSign;

                byteSendString = byteSendString + CRC16Util.String10ToString16((temp.Length / 2).ToString()) + " ";
                for (int i = 0; i < temp.Length / 2; i++)
                {
                    byteSendString = byteSendString + temp.Substring(i * 2, 2) + " ";
                }
                #endregion

                byteSendString = byteSendString + "00 ";
                crc16Code = CRC16Util.getCrc16Code(byteSendString);
                byteSendString = byteSendString + crc16Code.Substring(2, 2) + " " + crc16Code.Substring(0, 2);
                byteSendString = "68 " + byteSendString + " 16";//发送帧
                byteSendString = byteSendString.Replace(" ", "").Trim();
                byteSend = CRC16Util.HexString2Bytes(byteSendString);

                #region COM口通讯
                switch (itemComName)
                {
                    case "RS485通信":
                        #region RS485通信
                        serialPortRS485.DiscardInBuffer();
                        serialPortRS485.Write(byteSend, 0, byteSend.Length);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortRS485.BytesToRead > 0)
                                break;
                            Application.DoEvents();
                        }
                        Thread.Sleep(800);
                        Application.DoEvents();
                        bytesToRead = serialPortRS485.BytesToRead;
                        byteRecive = new byte[serialPortRS485.BytesToRead];
                        serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                        serialPortRS485.Dispose();
                        serialPortRS485.Close();
                        #endregion
                        break;
                }
                #endregion
                string byteReciveString = CRC16Util.stringArrayToString(byteRecive);//返回帧
                receiveString = DataOp_Class.DataByte_Decode698(byteRecive);
                #endregion

                if (receiveString == "err")
                {
                    result = false;
                    return;
                }

                #region 主站会话协商验证
                result = SocketApi_Class.doObj_Meter_Formal_VerifySession(0, Dt_Class.CESAMID, Dt_Class.COutRandHost, Dt_Class.ServerRan, Dt_Class.ServerSignature);
                #endregion

                if (!result)
                    return;
                Dt_Class.BlnSafety = true;
            }
            catch
            {
                result = false;
                return;
            }
        }



        /// <summary>
        /// 写参数
        /// </summary>
        /// <param name="di3">di3</param>
        /// <returns>结果</returns>
        public string WritePort_Data()
        {
            byteSend = new byte[0];
            byteRecive = new byte[0];

            string data = WriteData_EncryPtion();
            Dt_Class.EnWriteData = data;
            byteSend = new byte[24 + data.Length / 2];
            string receiveString = "";
            try
            {
                #region 选择通讯口
                if (serialPortRS485.IsOpen == false)
                    serialPortRS485.Open();
                #endregion

                byteSend[0] = 0x68;
                for (int i = 1; i < 7; i++)
                {
                    string bh1 = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                    byteSend[i] = Convert.ToByte(Convert.ToInt32(bh1, 16));
                }
                byteSend[7] = 0x68;
                byteSend[8] = 0x14;
                byteSend[9] = Convert.ToByte(12 + data.Length / 2);
                byteSend[10] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(6, 2), 16));
                byteSend[11] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(4, 2), 16));
                byteSend[12] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(2, 2), 16));
                byteSend[13] = Convert.ToByte(Convert.ToInt32(Dt_Class.DataFlag.Substring(0, 2), 16));
                byteSend[14] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(0, 2), 16));
                byteSend[15] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(2, 2), 16));
                byteSend[16] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(4, 2), 16));
                byteSend[17] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(6, 2), 16));
                byteSend[18] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(0, 2), 16));
                byteSend[19] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(2, 2), 16));
                byteSend[20] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(4, 2), 16));
                byteSend[21] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(6, 2), 16));
                for (int i = 0; i < data.Length / 2; i++)
                {
                    byteSend[22 + i] = Convert.ToByte(Convert.ToInt32(data.Substring(data.Length / 2 * 2 - 2 - i * 2, 2), 16));
                }
                byteSend = DataOp_Class.Data_EncryPtion(byteSend, 10, 22 + data.Length / 2);
                byteSend[22 + data.Length / 2] = DataOp_Class.Data_Summtion(byteSend, 0, 22 + data.Length / 2);
                byteSend[23 + data.Length / 2] = 0x16;
                int bytesToRead;

                #region RS485通信
                serialPortRS485.DiscardInBuffer();
                serialPortRS485.Write(byteSend, 0, 23 + data.Length / 2 + 1);
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    if (serialPortRS485.BytesToRead > 0)
                        break;
                    Application.DoEvents();
                }
                Thread.Sleep(400);
                Application.DoEvents();
                bytesToRead = serialPortRS485.BytesToRead;
                byteRecive = new byte[serialPortRS485.BytesToRead];
                serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                serialPortRS485.Dispose();
                serialPortRS485.Close();
                #endregion

                receiveString = DataOp_Class.DataByte_Decode(byteRecive);
                return receiveString;
            }
            catch
            {
                receiveString = "err";
                return receiveString;
            }
        }

        /// <summary>
        /// 特殊类参数
        /// </summary>
        /// <param name="sendByte">发送帧</param>
        /// <param name="len">帧长度</param>
        /// <returns>结果</returns>
        public string RWSpecialPort_Data()
        {
            byteSend = new byte[0];
            byteRecive = new byte[0];
            int len = 0;
            string receiveString = "";
            itemComName = Dt_Class.ItemComName;
            try
            {
                string data = Dt_Class.Data;

                if (serialPortRS485.IsOpen == false)
                    serialPortRS485.Open();

                switch (Dt_Class.DataName)
                {
                    #region 读厂内软件版本号
                    case "读厂内软件版本号":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1e;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0x05;
                        byteSend[11] = 0xEE;
                        byteSend[12] = 0xEE;
                        byteSend[13] = 0x3E;
                        len = 14;
                        break;
                    #endregion

                    #region 写厂内软件版本号(ASCII码)
                    case "写厂内软件版本号(ASCII码)":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1e;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0x05;
                        byteSend[11] = 0xEE;
                        byteSend[12] = 0xEE;
                        byteSend[13] = 0x3E;
                        len = 14;
                        break;
                    #endregion

                    #region 初 始 化
                    case "初始化":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1f;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0x13;
                        byteSend[11] = 0x14;
                        byteSend[12] = 0x54;
                        byteSend[13] = 0x80;
                        len = 14;
                        break;
                    #endregion

                    #region 定时冻结时间
                    case "定时冻结时间":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x16;
                        byteSend[9] = 0x04;
                        byteSend[10] = Convert.ToByte(Convert.ToInt32(data.Substring(6, 2), 16));
                        byteSend[11] = Convert.ToByte(Convert.ToInt32(data.Substring(4, 2), 16));
                        byteSend[12] = Convert.ToByte(Convert.ToInt32(data.Substring(2, 2), 16));
                        byteSend[13] = Convert.ToByte(Convert.ToInt32(data.Substring(0, 2), 16));
                        len = 14;
                        break;
                    #endregion

                    #region 开编程键
                    case "开编程键":
                        byteSend = new byte[15];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1f;
                        byteSend[9] = 0x03;
                        byteSend[10] = 0x0f;
                        byteSend[11] = 0x55;
                        byteSend[12] = 0xff;

                        len = 13;
                        break;
                    #endregion

                    #region 程序校验和
                    case "程序校验和":
                        byteSend = new byte[15];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1f;
                        byteSend[9] = 0x01;
                        byteSend[10] = 0x15;

                        len = 11;
                        break;
                    #endregion

                    #region 关编程键
                    case "关编程键":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1f;
                        byteSend[9] = 0x03;
                        byteSend[10] = 0x0F;
                        byteSend[11] = 0xAA;
                        byteSend[12] = 0x00;

                        len = 13;
                        break;
                    #endregion

                    #region 电表清零
                    case "电表清零":
                        byteSend = new byte[20];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1A;

                        byteSend[10] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(0, 2), 16));
                        byteSend[11] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(2, 2), 16));
                        byteSend[12] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(4, 2), 16));
                        byteSend[13] = Convert.ToByte(Convert.ToInt32(Dt_Class.PassWord.Substring(6, 2), 16));
                        byteSend[14] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(0, 2), 16));
                        byteSend[15] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(2, 2), 16));
                        byteSend[16] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(4, 2), 16));
                        byteSend[17] = Convert.ToByte(Convert.ToInt32(Dt_Class.Code.Substring(6, 2), 16));

                        byteSend[9] = 0x08;
                        len = 18;
                        break;
                    #endregion

                    #region 读取功耗
                    case "读取功耗":
                        Thread.Sleep(4000);
                        byteSend = new byte[20];
                        byteSend[0] = 0x68;
                        byteSend[1] = 0x88;
                        byteSend[2] = 0x88;
                        byteSend[3] = 0x88;
                        byteSend[4] = 0x88;
                        byteSend[5] = 0x88;
                        byteSend[6] = 0x88;
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x11;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0x00;
                        byteSend[11] = 0x01;
                        byteSend[12] = 0x03;
                        byteSend[13] = 0x02;
                        len = 14;
                        break;
                    #endregion

                    #region 厂内编号
                    case "厂内编号":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x20;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0xe3;
                        byteSend[11] = 0x04;
                        byteSend[12] = 0x00;
                        byteSend[13] = 0x04;
                        len = 14;
                        break;
                    #endregion

                    #region 读工序合格标记
                    case "读工序合格标记":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x2a;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0xE4;
                        byteSend[11] = 0x04;
                        byteSend[12] = 0x00;
                        byteSend[13] = 0x04;
                        len = 14;
                        break;
                    #endregion

                    #region 写工序合格标记
                    case "写工序合格标记":
                        byteSend = new byte[25];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x2B;
                        byteSend[9] = 0x0C;
                        byteSend[10] = 0xE4;
                        byteSend[11] = 0x04;
                        byteSend[12] = 0x00;
                        byteSend[13] = 0x04;
                        byteSend[14] = Convert.ToByte(Convert.ToInt32(data.Substring(0, 2), 16));
                        byteSend[15] = Convert.ToByte(Convert.ToInt32(data.Substring(2, 2), 16));
                        byteSend[16] = Convert.ToByte(Convert.ToInt32(data.Substring(4, 2), 16));
                        byteSend[17] = Convert.ToByte(Convert.ToInt32(data.Substring(6, 2), 16));
                        byteSend[18] = Convert.ToByte(Convert.ToInt32(data.Substring(0, 2), 16));
                        byteSend[19] = Convert.ToByte(Convert.ToInt32(data.Substring(2, 2), 16));
                        byteSend[20] = Convert.ToByte(Convert.ToInt32(data.Substring(4, 2), 16));
                        byteSend[21] = Convert.ToByte(Convert.ToInt32(data.Substring(6, 2), 16));

                        len = 22;
                        break;
                    #endregion

                    #region  清电平
                    case "清电平":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = "AA";
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x11;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0x11;
                        byteSend[11] = 0x10;
                        byteSend[12] = 0x10;
                        byteSend[13] = 0x10;
                        len = 14;
                        break;
                    #endregion

                    #region 电平检测
                    case "电平检测":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = "AA";
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x11;
                        byteSend[9] = 0x04;
                        byteSend[10] = 0x11;
                        byteSend[11] = 0x10;
                        byteSend[12] = 0x10;
                        byteSend[13] = 0x10;
                        len = 14;
                        break;
                    #endregion

                    #region  判断内部程序是否合格
                    case "判断内部程序是否合格":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1f;
                        byteSend[9] = 0x01;
                        byteSend[10] = 0x15;

                        len = 11;
                        break;
                    #endregion

                    #region  读载波复位模式字
                    case "读载波复位模式字":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1f;
                        byteSend[9] = 0x01;
                        byteSend[10] = 0x16;

                        len = 11;
                        break;
                    #endregion

                    #region  写载波复位模式字
                    case "写载波复位模式字（厂内扩展命令）":
                        byteSend = new byte[16];
                        byteSend[0] = 0x68;
                        for (int i = 1; i < 7; i++)
                        {
                            string bh = Dt_Class.Bh.Substring(10 - (i - 1) * 2, 2);
                            byteSend[i] = Convert.ToByte(Convert.ToInt32(bh, 16));
                        }
                        byteSend[7] = 0x68;
                        byteSend[8] = 0x1f;
                        byteSend[9] = 0x02;
                        byteSend[10] = 0x17;
                        byteSend[11] = Convert.ToByte(Convert.ToInt32(data.Substring(0, 2), 16));
                        len = 11;
                        break;
                    #endregion
                }

                byteSend = DataOp_Class.Data_EncryPtion(byteSend, 10, len);
                byteSend[len] = DataOp_Class.Data_Summtion(byteSend, 0, len);
                byteSend[len + 1] = 0x16;

                #region COM口通讯
                int bytesToRead = 0;
                serialPortRS485.DiscardInBuffer();
                serialPortRS485.Write(byteSend, 0, len + 2);
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    if (serialPortRS485.BytesToRead > 0)
                        break;
                    Application.DoEvents();
                }
                Thread.Sleep(500);
                Application.DoEvents();
                bytesToRead = serialPortRS485.BytesToRead;
                byteRecive = new byte[serialPortRS485.BytesToRead];
                serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                serialPortRS485.Dispose();
                serialPortRS485.Close();
                #endregion

                receiveString = DataOp_Class.DataTByte_Decode(byteRecive);
                return receiveString;
            }
            catch
            {
                receiveString = "err";
                return receiveString;
            }
        }

        /// <summary>
        /// 写特殊参数(无回帧)
        /// </summary>
        /// <param name="sendByte">发送帧</param>
        /// <param name="len">帧长度</param>
        public string BoardTime_Data(byte[] sendByte, int len)
        {
            byteSend = new byte[len + 3];
            string receiveString = "";
            try
            {
                #region 选择通讯口
                switch (itemComName)
                {
                    case "RS485通信":
                        if (serialPortRS485.IsOpen == false)
                        {
                            serialPortRS485.Open();
                        }
                        break;

                    case "载波通信":
                        if (serialPortZB.IsOpen == false)
                        {
                            serialPortZB.Open();
                        }
                        break;

                    case "功耗表通信":
                        if (serialPortGH.IsOpen == false)
                        {
                            serialPortGH.Open();
                        }
                        break;

                    case "夹具通信":
                        if (serialPortJJ.IsOpen == false)
                        {
                            serialPortJJ.Open();
                        }
                        break;

                    case "红外通信":
                        if (serialPortHW.IsOpen == false)
                        {
                            serialPortHW.Open();
                        }
                        break;
                }
                #endregion

                for (int i = 0; i < len + 1; i++)
                {
                    byteSend[i] = sendByte[i];
                }

                byteSend = DataOp_Class.Data_EncryPtion(byteSend, 10, len + 1);
                byteSend[len + 1] = DataOp_Class.Data_Summtion(byteSend, 0, len + 1);
                byteSend[len + 2] = 0x16;

                #region COM口通讯
                int bytesToRead = 0;
                switch (itemComName)
                {

                    case "RS485通信":
                        #region RS485通信
                        serialPortRS485.DiscardInBuffer();
                        serialPortRS485.Write(byteSend, 0, len + 2);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortRS485.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500); Application.DoEvents();
                        bytesToRead = serialPortRS485.BytesToRead;
                        byteRecive = new byte[serialPortRS485.BytesToRead];
                        serialPortRS485.Read(byteRecive, 0, serialPortRS485.BytesToRead);
                        serialPortRS485.Dispose();
                        serialPortRS485.Close();
                        #endregion
                        break;

                    case "载波通信":
                        #region 载波通信
                        serialPortZB.DiscardInBuffer();
                        serialPortZB.Write(byteSend, 0, len + 2);
                        for (int i = 0; i < 50; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortZB.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(1000); Application.DoEvents();
                        bytesToRead = serialPortZB.BytesToRead;
                        byteRecive = new byte[serialPortZB.BytesToRead];
                        serialPortZB.Read(byteRecive, 0, serialPortZB.BytesToRead);
                        serialPortZB.Dispose();
                        serialPortZB.Close();
                        #endregion
                        break;

                    case "功耗表通信":
                        #region 功耗表通信
                        serialPortGH.DiscardInBuffer();
                        serialPortGH.Write(byteSend, 0, len + 2);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortGH.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500); Application.DoEvents();
                        bytesToRead = serialPortGH.BytesToRead;
                        byteRecive = new byte[serialPortGH.BytesToRead];
                        serialPortGH.Read(byteRecive, 0, serialPortGH.BytesToRead);
                        serialPortGH.Dispose();
                        serialPortGH.Close();
                        #endregion
                        break;

                    case "夹具通信":
                        #region 夹具通信
                        serialPortJJ.DiscardInBuffer();
                        serialPortJJ.Write(byteSend, 0, len + 2);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortJJ.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500); Application.DoEvents();
                        bytesToRead = serialPortJJ.BytesToRead;
                        byteRecive = new byte[serialPortJJ.BytesToRead];
                        serialPortJJ.Read(byteRecive, 0, serialPortJJ.BytesToRead);
                        serialPortJJ.Dispose();
                        serialPortJJ.Close();
                        #endregion
                        break;

                    case "红外通信":
                        #region 红外通信
                        serialPortHW.DiscardInBuffer();
                        serialPortHW.Write(byteSend, 0, len + 2);
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(100);
                            if (serialPortHW.BytesToRead > 0)
                            {
                                break;
                            }
                            Application.DoEvents();
                        }
                        Thread.Sleep(500); Application.DoEvents();
                        bytesToRead = serialPortHW.BytesToRead;
                        byteRecive = new byte[serialPortHW.BytesToRead];
                        serialPortHW.Read(byteRecive, 0, serialPortHW.BytesToRead);
                        serialPortHW.Dispose();
                        serialPortHW.Close();
                        #endregion
                        break;
                }
                #endregion

                Thread.Sleep(100);
                return "1";
            }
            catch
            {
                receiveString = "err";
                return receiveString;
            }
        }
    }
}