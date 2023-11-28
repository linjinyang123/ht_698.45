using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using EncryptServerConnect;
using ht_698._45.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace ht_698._45
{
    internal class PublicVariable
    {
        private static ushort[] crctab16 = new ushort[] { 
            0, 0x1189, 0x2312, 0x329b, 0x4624, 0x57ad, 0x6536, 0x74bf, 0x8c48, 0x9dc1, 0xaf5a, 0xbed3, 0xca6c, 0xdbe5, 0xe97e, 0xf8f7,
            0x1081, 0x108, 0x3393, 0x221a, 0x56a5, 0x472c, 0x75b7, 0x643e, 0x9cc9, 0x8d40, 0xbfdb, 0xae52, 0xdaed, 0xcb64, 0xf9ff, 0xe876,
            0x2102, 0x308b, 0x210, 0x1399, 0x6726, 0x76af, 0x4434, 0x55bd, 0xad4a, 0xbcc3, 0x8e58, 0x9fd1, 0xeb6e, 0xfae7, 0xc87c, 0xd9f5,
            0x3183, 0x200a, 0x1291, 0x318, 0x77a7, 0x662e, 0x54b5, 0x453c, 0xbdcb, 0xac42, 0x9ed9, 0x8f50, 0xfbef, 0xea66, 0xd8fd, 0xc974,
            0x4204, 0x538d, 0x6116, 0x709f, 0x420, 0x15a9, 0x2732, 0x36bb, 0xce4c, 0xdfc5, 0xed5e, 0xfcd7, 0x8868, 0x99e1, 0xab7a, 0xbaf3,
            0x5285, 0x430c, 0x7197, 0x601e, 0x14a1, 0x528, 0x37b3, 0x263a, 0xdecd, 0xcf44, 0xfddf, 0xec56, 0x98e9, 0x8960, 0xbbfb, 0xaa72,
            0x6306, 0x728f, 0x4014, 0x519d, 0x2522, 0x34ab, 0x630, 0x17b9, 0xef4e, 0xfec7, 0xcc5c, 0xddd5, 0xa96a, 0xb8e3, 0x8a78, 0x9bf1,
            0x7387, 0x620e, 0x5095, 0x411c, 0x35a3, 0x242a, 0x16b1, 0x738, 0xffcf, 0xee46, 0xdcdd, 0xcd54, 0xb9eb, 0xa862, 0x9af9, 0x8b70,
            0x8408, 0x9581, 0xa71a, 0xb693, 0xc22c, 0xd3a5, 0xe13e, 0xf0b7, 0x840, 0x19c9, 0x2b52, 0x3adb, 0x4e64, 0x5fed, 0x6d76, 0x7cff,
            0x9489, 0x8500, 0xb79b, 0xa612, 0xd2ad, 0xc324, 0xf1bf, 0xe036, 0x18c1, 0x948, 0x3bd3, 0x2a5a, 0x5ee5, 0x4f6c, 0x7df7, 0x6c7e,
            0xa50a, 0xb483, 0x8618, 0x9791, 0xe32e, 0xf2a7, 0xc03c, 0xd1b5, 0x2942, 0x38cb, 0xa50, 0x1bd9, 0x6f66, 0x7eef, 0x4c74, 0x5dfd,
            0xb58b, 0xa402, 0x9699, 0x8710, 0xf3af, 0xe226, 0xd0bd, 0xc134, 0x39c3, 0x284a, 0x1ad1, 0xb58, 0x7fe7, 0x6e6e, 0x5cf5, 0x4d7c,
            0xc60c, 0xd785, 0xe51e, 0xf497, 0x8028, 0x91a1, 0xa33a, 0xb2b3, 0x4a44, 0x5bcd, 0x6956, 0x78df, 0xc60, 0x1de9, 0x2f72, 0x3efb,
            0xd68d, 0xc704, 0xf59f, 0xe416, 0x90a9, 0x8120, 0xb3bb, 0xa232, 0x5ac5, 0x4b4c, 0x79d7, 0x685e, 0x1ce1, 0xd68, 0x3ff3, 0x2e7a,
            0xe70e, 0xf687, 0xc41c, 0xd595, 0xa12a, 0xb0a3, 0x8238, 0x93b1, 0x6b46, 0x7acf, 0x4854, 0x59dd, 0x2d62, 0x3ceb, 0xe70, 0x1ff9,
            0xf78f, 0xe606, 0xd49d, 0xc514, 0xb1ab, 0xa022, 0x92b9, 0x8330, 0x7bc7, 0x6a4e, 0x58d5, 0x495c, 0x3de3, 0x2c6a, 0x1ef1, 0xf78
        };
        public static bool BeginRecState = false;
        public static bool RecTimeOutFlag = false;
        public static long SendTimeTicks = 0L;
        public static long RecOverTicks = 0L;
        public static string RecDataString = "";
        public static string SendDataString = "";
        public static string ComInfo = null;
        public static string Info = "";
        public static string Info_Color = "";
        public static string MAC_Info = "";
        public static string ComName = null;
        public static bool ChangedFlag = false;
        public static float comTicks = 0f;
        public static int WaitDataRevTime = 0x3e8;
        public static bool FE_Flag = true;
        public static byte FE_Number = 0;
        public static bool RaomaFlag = false;
        public static int sumOfbit = 0x200;
        public static string Address = "05111111111111";
        public static string address = "111111111111";
        public static string Client_Add = "A1";
        public static bool IsReading = false;
        public static bool TimeTag = false;
        public static string TimeText = "20990101000000000001";
        public static byte PIID_R = 0;
        public static byte PIID_W = 0;
        public static bool SplitFlag = false;
        public static string DARInfo = "";
        public static string IP = "";
        public static string port = "";
        public static string timeOut = "";
        public static bool LinkRoadFlag = false;
        public static bool IsLink = false;
        public static string ESAM_ID = "";
        public static string Meter_NO = "";
        public static string cDiv = "";
        public static int Key_State = 0;
        public static int Counter = 0;
        public static StringBuilder cOutSessionKey = new StringBuilder(200);
        public static bool ConnetionFlag = false;
        public static Link_Math link_Math;
        public static Logical_Address logical_Address;
        public static List<string> follow_OADNormal = new List<string>();
        public static List<string> follow_DataNormal = new List<string>();
        public static string follow_OADRercord = "";
        public static string follow_rel_NumRercord = "";
        public static List<string> follow_Rel_RCSDRercord = new List<string>();
        public static string follow_RecordNumRercord = "";
        public static List<List<List<string>>> follow_DataRercord = new List<List<List<string>>>();
        public static List<string> follow_TimeTag = new List<string>();
        public static Encrypt encrypt = new Encrypt();
        public static bool isDisplay = false;
        public static string nowTime = "";
        public static bool isBt_InfraredOn = false;
        public static bool isBt_ConnctionOn = false;
        public static bool isBt_ConnctionCutOn = false;
        public static bool isBt_协商失效 = false;
        public static string[] disBuff = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

        public static string ASCIIHexstrTostr(string hexstring)
        {
            string str = "";
            Encoding encoding = Encoding.GetEncoding("GB2312");
            byte[] bytes = new byte[hexstring.Length / 2];
            for (int i = 0; i < (hexstring.Length / 2); i++)
            {
                bytes = new byte[] { Convert.ToByte("0x" + hexstring.Substring(i * 2, 2), 0x10) };
                //32~126,其中32是空格;48～57为0到9十个阿拉伯数字;65～90为26个大写英文字母;97～122号为26个小写英文字母;其余为一些标点符号、运算符号等
                if (bytes[0] > 32 && bytes[0] < 127 && !((bytes[0] > 32 && bytes[0] < 45) || (bytes[0] > 45 && bytes[0] < 48) || (bytes[0] > 57 && bytes[0] < 65) || (bytes[0] > 90 && bytes[0] < 97) || (bytes[0] > 122 && bytes[0] < 127)))
                    str = str + encoding.GetString(bytes);
            }
            return (str = str.Replace("\0", ""));
        }

        public static string BackString(string sData)
        {
            int length = sData.Length;
            string str = "";
            if (length <= 0)
            {
                return "";
            }
            if ((length % 2) != 0)
            {
                return "";
            }
            for (int i = 0; i < (length / 2); i++)
            {
                str = sData.Substring(2 * i, 2) + str;
            }
            return str;
        }

        public static string ByteToHex(byte[] comByte)
        {
            string str = "";
            if (comByte != null)
            {
                for (int i = 0; i < comByte.Length; i++)
                {
                    str = str + comByte[i].ToString("X2") + " ";
                }
            }
            return str;
        }

        public static string calc_Octlen(int length)
        {
            string str = "";
            if ((length / 2) <= 0x7f)
            {
                int num = length / 2;
                return num.ToString("X2");
            }
            //str = $"{length / 2:X}";
            str=string.Format("{0:X}",length / 2);
            if ((str.Length % 2) == 0)
            {
                //return ("8" + $"{(str.Length / 2):X1}" + str);
                return ("8" + string.Format("{0:X1}",str.Length / 2)+ str);
            }
           // return ("8" + $"{((str.Length + 1) / 2):X1}" + str.PadLeft(str.Length + 1, '0'));
             return ("8" + string.Format("{0:X1}",(str.Length + 1) / 2) + str.PadLeft(str.Length + 1, '0'));
        }

        public static string calc_Octlen(string str)
        {
            try
            {
                int num = -1;
                int length = -1;
                int num3 = str.Length / 2;
                if (num3 <= 0x7f)
                {
                    return num3.ToString("X2");
                }
                //length = $"{num3:X}".Length;
                length = string.Format("{0:X}",num3).Length;
                if ((length % 2) == 0)
                {
                    num = length / 2;
                }
                else
                {
                    num = 1 + (length / 2);
                }
                int num4 = num | 0x80;
                int num5 = 2 * num;
                return (num4.ToString("X2") + num3.ToString("X" + num5.ToString()));
            }
            catch (Exception exception)
            {
                string caption = "错误";
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "00";
            }
        }

        public static void ExportToExcel(string title, bool isPageForEachLink, string sheetName, params IPrintable[] printables)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                FileName = title,
                Title = "导出Excel",
                Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls",
                InitialDirectory = Application.StartupPath + @"\操作方案"
            };
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                string fileName = dialog.FileName;
                CompositeLinkBase link = new CompositeLinkBase(new PrintingSystemBase());
                foreach (IPrintable printable in printables)
                {
                   PrintableComponentLinkBase val = new PrintableComponentLinkBase {
                        Component = printable
                    };
                    link.Links.Add(val);
                }
                if (isPageForEachLink)
                {
                    link.CreatePageForEachLink();
                }
                if (string.IsNullOrEmpty(sheetName))
                {
                    sheetName = "Sheet";
                }
                try
                {
                    for (int i = 1; File.Exists(fileName); i++)
                    {
                        if (fileName.Contains(")."))
                        {
                            int startIndex = fileName.LastIndexOf("(");
                            int length = (fileName.LastIndexOf(").") - fileName.LastIndexOf("(")) + 2;
                            fileName = fileName.Replace(fileName.Substring(startIndex, length), string.Format("{0}.",i));
                        }
                        else
                        {
                            fileName = fileName.Replace(".", string.Format("{0}.", i));
                        }
                    }
                    if (fileName.LastIndexOf(".xlsx") >= (fileName.Length - 5))
                    {
                        XlsxExportOptions options = new XlsxExportOptions {
                            SheetName = sheetName
                        };
                        if (isPageForEachLink)
                        {
                            options.ExportMode = XlsxExportMode.SingleFilePageByPage;
                        }
                        link.ExportToXlsx(fileName, options);
                    }
                    else
                    {
                        XlsExportOptions options = new XlsExportOptions {
                            SheetName = sheetName
                        };
                        if (isPageForEachLink)
                        {
                            options.ExportMode = XlsExportMode.SingleFile;
                        }
                        link.ExportToXls(fileName, options);
                    }
                    if (XtraMessageBox.Show("保存成功，是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        Process.Start(fileName);
                    }
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message);
                }
            }
        }
        /// <summary>
        /// CRC校验算法
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetCrc16(byte[] bytes)
        {
            uint num = 0xffff;
            int length = bytes.Length;
            for (int i = 0; i < length; i++)
            {
                num = (num >> 8) ^ crctab16[(int) ((IntPtr) ((num ^ bytes[i]) & 0xff))];
            }
            num ^= 0xffff;
            return string.Format("{0:X4}",num);
        }

        public static string GetCrc16ByBit(byte[] bytes)
        {
            uint num = 0xffff;
            string str = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                num ^= bytes[i];
                for (int j = 0; j < 8; j++)
                {
                    str = Convert.ToString((long) num, 2);
                    if (str[str.Length - 1] == '0')
                    {
                        num = num >> 1;
                    }
                    else
                    {
                        num = num >> 1;
                        num ^= 0x1021;
                    }
                }
            }
            return Convert.ToString((long) num, 0x10);
        }

        public static string GetFloatstrFromBCDStr(string sTmp2, int iDot)
        {
            try
            {
                if (sTmp2 == "")
                {
                    return "NULL";
                }
                if ((iDot != 0) && (sTmp2 != "F".PadLeft(sTmp2.Length, 'F')))
                {
                    string str = "00000000";
                    double num = 0.0;
                    num = ((double) Convert.ToInt32(sTmp2, 10)) / Math.Pow(10.0, (double) iDot);
                    sTmp2 = string.Format("{0:#0." + str.Substring(0, iDot) + "}", num);
                }
                return sTmp2;
            }
            catch (Exception exception)
            {
                Info = "警告：数据中带有16进制码!" + exception.Message;
                Info_Color = "Red";
                return "0";
            }
        }

        public static string GetFloatstrFromBCDStr(string sTmp2, string sDot)
        {
            try
            {
                int length = 0;
                if (sTmp2 == "")
                {
                    return "NULL";
                }
                if (sDot != "")
                {
                    length = Convert.ToInt16(sDot);
                    if ((length != 0) && (sTmp2 != "F".PadLeft(sTmp2.Length, 'F')))
                    {
                        string str = "00000000";
                        double num2 = 0.0;
                        num2 = ((double) Convert.ToInt32(sTmp2, 10)) / Math.Pow(10.0, (double) length);
                        sTmp2 = string.Format("{0:#0." + str.Substring(0, length) + "}", num2);
                    }
                    return sTmp2;
                }
                return sTmp2;
            }
            catch (Exception exception)
            {
                Info = "警告：数据中带有16进制码!" + exception.Message;
                Info_Color = "Red";
                return "0";
            }
        }

        public static string GetHFCS(string strFrame) 
        {
            return GetCrc16(HexToByte(strFrame));
        }
        public static string GetStringstrFromBCDStr(string sTmp2)
        {
            try
            {
                if (sTmp2 == "")
                {
                    return "NULL";
                }
                return sTmp2;
            }
            catch (Exception exception)
            {
                Info = "警告：数据中带有16进制码!" + exception.Message;
                Info_Color = "Red";
                return "0";
            }
        }

        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");
            byte[] buffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(msg.Substring(i, 2), 0x10);
            }
            return buffer;
        }

        public static bool isCheckout(string sText, string sTag)
        {
            bool flag = true;
            try
            {
                switch (sTag)
                {
                    case "N":
                        for (byte i = 0; i < sText.Length; i = (byte) (i + 1))
                        {
                            flag = char.IsNumber(sText, i);
                            if (!flag)
                            {
                                break;
                            }
                        }
                        break;
                }
                return flag;
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "isCheckout" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return flag;
            }
        }

        public static bool IsCrc16Valid(byte[] bytes)
        {
            uint num = 0xffff;
            int length = bytes.Length;
            for (int i = 0; i < length; i++)
            {
                num = (num >> 8) ^ crctab16[(int) ((IntPtr) ((num ^ bytes[i]) & 0xff))];
            }
            return (num == 0xf0b8);
        }
    }
}

