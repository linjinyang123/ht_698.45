using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.OleDb;
using System.Threading;
using System.Data.Odbc;
using System.Data.SqlClient;
namespace ht_698._45
{
    class comdata
    {
        public static byte[] wrtbyt = new byte[256];   //与电表通讯
        public static byte[] wrtbyt1 = new byte[256];  //载波通讯
        public static byte[] wrtbyt2 = new byte[256];  //与夹具通讯
        public static byte[] wrtbyt3 = new byte[256];  //与功耗通讯
        public static SerialPort mysp1;//与电表通讯
        public static SerialPort mysp2;//与夹具通讯
        public static SerialPort mysp3;//载波通讯
        public static SerialPort mysp4;//功耗表通讯
        public static int circle = 1;
        public static int bzflag = 0;
        public static int comtime = 6;
        public static string bzdata1 = " ";
        public static string bzdata2 = " ";
        public static string bzdata3 = " ";
        public static string bzdata4 = " ";
        public static string bzdata5 = " ";
        public static string bzdata6 = " ";

        public static int Zbys = 0;//载波延时时间

        public static string Dpcs = " ";

        public static byte[] readbyt = new byte[512];//返回字节流     与电表通讯
        public static byte[] readbyt1 = new byte[512];//返回字节流     载波通讯
        public static byte[] readbyt2 = new byte[512];//返回字节流    与夹具通讯
        public static byte[] readbyt3 = new byte[512];//返回字节流    与功耗通讯

        public static int[] dataitem = new int[92];//选择的数据项
        public static string[] bh = new string[500];//选择抄读的表号
        public static int bhlenth = 0;//选择抄读的表号

        public static string[] bh1 = new string[500];//选择抄读的表号
        public static int bhlenth1 = 0;//选择抄读的表号

        public static string[] bh2 = new string[500];//选择抄读的表号
        public static int bhlenth2 = 0;//选择抄读的表号

        public static string[] bh3 = new string[500];//选择抄读的表号
        public static int bhlenth3 = 0;//选择抄读的表号

        public static int myzt = 2;//密钥状态1正式密钥0测试密钥2无身份认证
        public static int sbzt = 2;//加密器状态1密码机0  无设备2

        public static string[] bh4 = new string[500];//选择抄读的表号
        public static int bhlenth4 = 0;//选择抄读的表号
        public static string passwd = "123456";//选择抄读的表号
        public static string code = "00000000";//选择抄读的表号
        public static string rstring;
        public static string[,] compdata = new string[1000, 1000];
        public static int[,] compflag = new int[1000, 1000];

        public static int HXZnum = 1;
        public static string timecluflag;

        public static string bytetohex(byte[] s, int a)
        {
            string p = "";
            for (int i = 0; i < a; i++)
            {
                switch (s[i])
                {
                    case 0x00: p = p + "0"; break;
                    case 0x01: p = p + "1"; break;
                    case 0x02: p = p + "2"; break;
                    case 0x03: p = p + "3"; break;
                    case 0x04: p = p + "4"; break;
                    case 0x05: p = p + "5"; break;
                    case 0x06: p = p + "6"; break;
                    case 0x07: p = p + "7"; break;
                    case 0x08: p = p + "8"; break;
                    case 0x09: p = p + "9"; break;
                    case 0x0A: p = p + "A"; break;
                    case 0x0B: p = p + "B"; break;
                    case 0x0C: p = p + "C"; break;
                    case 0x0D: p = p + "D"; break;
                    case 0x0E: p = p + "E"; break;
                    case 0x0F: p = p + "F"; break;
                }
            }
            return p;
        }

        //16进制string-->int
        private static int sConvert(string s)
        {
            int a = System.Convert.ToInt16(s, 16);
            return a;
        }

        //编码
        public static byte[] Data_Encode(byte[] data, int begin, int len)
        {
            int i;
            for (i = begin; i < len; i++)
            {
                data[i] += (byte)(0x33);
            }
            return data;
        }

        //解码
        public static byte[] Data_Decode(byte[] data, int begin, int len)
        {
            int i;
            for (i = begin; i < len; i++)
            {
                data[i] -= (byte)(0x33);
            }
            return data;
        }

        //校验和
        private static byte checksum(byte[] buf, int begin, int len)
        {
            byte temp = 0;

            for (int i = begin; i < len; i++)
            {
                temp += buf[i];
            }
            return temp;
        }

        public static string senddata(byte[] wrtdata, int len)
        {
            int i = 0, j;
            byte[] cc = new byte[5];

            wrtbyt = Data_Encode(wrtdata, 10, len);
            wrtbyt[len] = (byte)checksum(wrtbyt, 0, len);
            wrtbyt[len + 1] = 0x16;

            try
            {
                if (!mysp1.IsOpen)
                    mysp1.Open();
                mysp1.Write(wrtbyt, 0, len + 2);//发送数据
                mysp1.DiscardInBuffer();

                for (j = 0; j < 6; j++)
                {
                    Thread.Sleep(100);
                    Application.DoEvents();
                }

                readbyt = new byte[mysp1.BytesToRead];
                mysp1.Read(readbyt, 0, readbyt.Length);//接受数据
                //补发数据 
                if ((readbyt.Length == 0) || (readbyt == null))
                {
                    mysp1.Write(wrtbyt, 0, len + 2);//发送数据
                    mysp1.DiscardInBuffer();

                    for (j = 0; j < 8; j++)
                    {
                        Thread.Sleep(100);
                        Application.DoEvents();
                    }

                    readbyt = new byte[mysp1.BytesToRead];
                    mysp1.Read(readbyt, 0, readbyt.Length);
                }
                mysp1.DiscardInBuffer();
                mysp1.DiscardOutBuffer();
                //  mysp1.Close();
                mysp1.Dispose();
            }
            catch
            {
                rstring = "0";
                return rstring;
            }

            if (readbyt == null)
            {
                rstring = "0";
                return rstring;
            }
            else
            {
                try
                {
                    while (readbyt[i] != 0x68)
                    {
                        i = i + 1;
                    }
                    readbyt = Data_Decode(readbyt, i + 10, readbyt.Length - 2);
                    if ((readbyt[i + 8] == 0x91))//读参数
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x94))//设置参数
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x83))//设置参数
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x9C))//设置参数
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x93))//读通信地址
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x95))//写通信地址
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x98))//修改密码
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x97))//修改密码
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x99))//最大需量清零
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x9A))//电表清零
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x9B))//事件清零
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x9F))//初始化
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0xAB))//工序检测
                    {
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else if ((readbyt[i + 8] == 0x1E))//厂内软件版本号
                    {
                        readbyt = Data_Encode(readbyt, i + 10, readbyt.Length - 2);
                        timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                        rstring = "1";// 成功应答
                        return rstring;
                    }
                    else
                    {
                        rstring = "0";
                        return rstring;
                    }
                }
                catch
                {
                    rstring = "0";
                    return rstring;
                }
            }
        }
        public static string rtnReadDP(string bnum, string savedata, byte di0, byte di1, byte di2, byte di3)
        {
            int j, i = 0, a = 0;
            string s = "";
            byte[] aa = new byte[512];
            byte[] cc = new byte[512];

            try
            {
                wrtbyt2[0] = 0x68;
                wrtbyt2[1] = (byte)(sConvert(bnum.Substring(10, 2)));
                wrtbyt2[2] = (byte)(sConvert(bnum.Substring(8, 2)));
                wrtbyt2[3] = (byte)(sConvert(bnum.Substring(6, 2)));
                wrtbyt2[4] = (byte)(sConvert(bnum.Substring(4, 2)));
                wrtbyt2[5] = (byte)(sConvert(bnum.Substring(2, 2)));
                wrtbyt2[6] = (byte)(sConvert(bnum.Substring(0, 2)));
                wrtbyt2[7] = 0x68;
                wrtbyt2[10] = di0;
                wrtbyt2[11] = di1;
                wrtbyt2[12] = di2;
                wrtbyt2[13] = di3;
                wrtbyt2[8] = 0x11;
                wrtbyt2[9] = 0x04;
                wrtbyt2[14] = (byte)checksum(wrtbyt2, 0, 14);
                wrtbyt2[15] = 0x16;

                try
                {
                    if (!mysp2.IsOpen)
                        mysp2.Open();

                    if (di0 == 0x99 && di1 == 0xBB && di2 == 0x99 && di3 == 0xBB)//蜂鸣
                        mysp2.Write(wrtbyt2, 0, 17);//发送数据

                    else
                        mysp2.Write(wrtbyt2, 0, 16);//发送数据

                    mysp2.DiscardInBuffer();

                    for (j = 0; j < 4; j++)
                    {
                        Thread.Sleep(100);
                        Application.DoEvents();
                    }

                    readbyt2 = new byte[mysp2.BytesToRead];
                    mysp2.Read(readbyt2, 0, readbyt2.Length);//接受数据
                    mysp2.DiscardInBuffer();
                    mysp2.DiscardOutBuffer();
                    mysp2.Close();
                    mysp2.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    rstring = "0";
                    return rstring;
                }

                if (readbyt2 == null)
                {
                    MessageBox.Show("超时！！");
                    rstring = "0";
                    return rstring;
                }

                else
                {
                    try
                    {
                        while (readbyt2[i] != 0x68)
                        {
                            i = i + 1;
                        }
                        readbyt2 = Data_Decode(readbyt2, i + 10, readbyt2.Length - 2);
                        if ((readbyt2[i + 8] == 0x91))//读参数
                        {
                            a = readbyt2.Length - 4 - 10 - i - 2;
                            for (j = 0; j < a; j++)
                            {
                                aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt2[i + 14] & 0xF0) >> 4) + '0');
                                aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt2[i + 14] & 0x0F)) + '0');
                                if (aa[(a - j) * 2 - 2] > '9')
                                    aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt2[i + 14] & 0xF0) >> 4) - 10 + 'A');
                                if (aa[(a - j) * 2 - 1] > '9')
                                    aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt2[i + 14] & 0x0F)) - 10 + 'A');
                                i = i + 1;
                            }
                            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                            s = encoding.GetString(aa).Substring(0, a * 2);
                            if (savedata == s)
                                return "success";
                            else
                                return s;
                        }
                        else if ((readbyt2[i + 8] == 0x37))//清电平
                        {
                            timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                            rstring = "1";// 成功应答
                            return rstring;
                        }
                        else if ((readbyt2[i + 8] == 0x38))//读电平标志
                        {
                            a = readbyt2.Length - 4 - 10 - i - 2;
                            for (j = 0; j < a; j++)
                            {
                                aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt2[i + 14] & 0xF0) >> 4) + '0');
                                aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt2[i + 14] & 0x0F)) + '0');
                                if (aa[(a - j) * 2 - 2] > '9')
                                    aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt2[i + 14] & 0xF0) >> 4) - 10 + 'A');
                                if (aa[(a - j) * 2 - 1] > '9')
                                    aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt2[i + 14] & 0x0F)) - 10 + 'A');
                                i = i + 1;
                            }
                            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                            s = encoding.GetString(aa).Substring(0, a * 2);
                            if (savedata == s)
                                return "success";
                            else
                                return s;
                        }
                        else if ((readbyt2[i + 8] == 0x39))//夹具蜂鸣器 响
                        {
                            timecluflag = System.DateTime.Now.ToString("u").Substring(0, 19);
                            rstring = "1";// 成功应答
                            return rstring;
                        }
                        else
                        {
                            rstring = "0";//错误应答
                            return rstring;
                        }
                    }
                    catch
                    {
                        rstring = "0";
                        return rstring;
                    }
                }
            }
            catch
            {
                return "0";
            }
        }

        //验证数据
        public static string rtnRead1(string bnum, string savedata, byte di0, byte di1, byte di2, byte di3)  //电表通讯
        {
            int j, i = 0, a = 0;
            string s = "";
            byte[] aa = new byte[512];
            byte[] cc = new byte[512];

            try
            {
                wrtbyt[0] = 0x68;
                wrtbyt[1] = (byte)(sConvert(bnum.Substring(10, 2)));
                wrtbyt[2] = (byte)(sConvert(bnum.Substring(8, 2)));
                wrtbyt[3] = (byte)(sConvert(bnum.Substring(6, 2)));
                wrtbyt[4] = (byte)(sConvert(bnum.Substring(4, 2)));
                wrtbyt[5] = (byte)(sConvert(bnum.Substring(2, 2)));
                wrtbyt[6] = (byte)(sConvert(bnum.Substring(0, 2)));

                wrtbyt[7] = 0x68;
                wrtbyt[8] = 0x11;
                wrtbyt[9] = 0x04;
                wrtbyt[10] = di0;
                wrtbyt[11] = di1;
                wrtbyt[12] = di2;
                wrtbyt[13] = di3;
                wrtbyt[14] = (byte)checksum(wrtbyt, 0, 14);
                wrtbyt[15] = 0x16;

                try
                {
                    if (!mysp1.IsOpen)
                        mysp1.Open();

                    mysp1.Write(wrtbyt, 0, 16);//发送数据
                    mysp1.DiscardInBuffer();

                    for (j = 0; j < 4; j++)
                    {
                        Thread.Sleep(100);
                        Application.DoEvents();
                    }

                    readbyt = new byte[mysp1.BytesToRead];
                    mysp1.Read(readbyt, 0, readbyt.Length);//接受数据
                    ////补发数据 
                    //if ((readbyt.Length == 0) || (readbyt == null))
                    //{
                    //    mysp1.Write(wrtbyt, 0, 16);
                    //    mysp1.DiscardInBuffer();

                    //    for (j = 0; j < 6; j++)
                    //    {
                    //        Thread.Sleep(100);
                    //        Application.DoEvents();
                    //    }

                    //    readbyt = new byte[mysp1.BytesToRead];
                    //    mysp1.Read(readbyt, 0, readbyt.Length);
                    //}
                    mysp1.DiscardInBuffer();
                    mysp1.DiscardOutBuffer();
                    mysp1.Close();
                    mysp1.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    rstring = "0";
                    return rstring;
                }

                if (readbyt == null)
                {
                    MessageBox.Show("超时！！");
                    rstring = "0";
                    return rstring;
                }

                else
                {
                    try
                    {
                        while (readbyt[i] != 0x68)
                        {
                            i = i + 1;
                        }
                        readbyt = Data_Decode(readbyt, i + 10, readbyt.Length - 2);
                        if ((readbyt[i + 8] == 0x91))//读参数
                        {
                            a = readbyt.Length - 4 - 10 - i - 2;
                            for (j = 0; j < a; j++)
                            {
                                aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt[i + 14] & 0xF0) >> 4) + '0');
                                aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt[i + 14] & 0x0F)) + '0');
                                if (aa[(a - j) * 2 - 2] > '9')
                                    aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt[i + 14] & 0xF0) >> 4) - 10 + 'A');
                                if (aa[(a - j) * 2 - 1] > '9')
                                    aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt[i + 14] & 0x0F)) - 10 + 'A');
                                i = i + 1;
                            }
                            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                            s = encoding.GetString(aa).Substring(0, a * 2);
                            return s;
                        }
                        else
                        {
                            rstring = "0";//错误应答
                            return rstring;
                        }
                    }
                    catch
                    {
                        rstring = "0";
                        return rstring;
                    }
                }
            }
            catch
            {
                return "0";
            }
        }

        public static string SendZBG(string bnum)//设置载波为高位
        {
            int j, i = 0;

            byte[] aa = new byte[512];
            byte[] cc = new byte[512];
            try
            {
                wrtbyt1[0] = 0x68;
                wrtbyt1[1] = (byte)(sConvert(bnum.Substring(10, 2)));
                wrtbyt1[2] = (byte)(sConvert(bnum.Substring(8, 2)));
                wrtbyt1[3] = (byte)(sConvert(bnum.Substring(6, 2)));
                wrtbyt1[4] = (byte)(sConvert(bnum.Substring(4, 2)));
                wrtbyt1[5] = (byte)(sConvert(bnum.Substring(2, 2)));
                wrtbyt1[6] = (byte)(sConvert(bnum.Substring(0, 2)));

                wrtbyt1[7] = 0x68;
                wrtbyt1[8] = 0x04;
                wrtbyt1[9] = 0x0a;
                wrtbyt1[10] = 0x88;
                wrtbyt1[11] = 0x8d;
                wrtbyt1[12] = 0x85;
                wrtbyt1[13] = 0x76;

                wrtbyt1[14] = 0x7f;
                wrtbyt1[15] = 0x83;
                wrtbyt1[16] = 0x47;
                wrtbyt1[17] = 0x53;
                wrtbyt1[18] = 0x3b;
                wrtbyt1[19] = 0x36;
                wrtbyt1[20] = (byte)checksum(wrtbyt1, 0, 20);
                wrtbyt1[21] = 0x16;

                try
                {
                    if (!mysp3.IsOpen)
                        mysp3.Open();

                    Application.DoEvents();
                    mysp3.Write(wrtbyt1, 0, 22);//发送数据
                    mysp3.DiscardInBuffer();

                    for (j = 0; j < Zbys; j++)
                    {
                        Thread.Sleep(1000);
                        Application.DoEvents();
                    }

                    readbyt1 = new byte[mysp3.BytesToRead];
                    mysp3.Read(readbyt1, 0, readbyt1.Length);//接受数据
                    ////补发数据 
                    //if ((readbyt1.Length == 0) || (readbyt1 == null))
                    //{
                    //    mysp3.Write(wrtbyt1, 0, 33);
                    //    mysp3.DiscardInBuffer();

                    //    for (j = 0; j < Zbys + 2; j++)
                    //    {
                    //        Thread.Sleep(1000);
                    //        Application.DoEvents();
                    //    }

                    //    readbyt1 = new byte[mysp3.BytesToRead];
                    //    mysp3.Read(readbyt1, 0, readbyt1.Length);
                    //}
                    mysp3.DiscardInBuffer();
                    mysp3.DiscardOutBuffer();
                    //mysp3.Close();
                    //mysp3.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    rstring = "0";
                    return rstring;
                }

                if (readbyt1 == null)
                {
                    MessageBox.Show("超时！！");
                    rstring = "0";
                    return rstring;
                }

                else
                {
                    try
                    {
                        while (readbyt1[i] != 0x68)
                        {
                            i = i + 1;
                        }
                        readbyt1 = Data_Decode(readbyt1, i + 10, readbyt1.Length - 2);
                        if ((readbyt1[i + 8] == 0x84))//成功
                        {
                            rstring = "1";
                            return rstring;
                        }
                        else
                        {
                            rstring = "0";//错误应答
                            return rstring;
                        }
                    }
                    catch
                    {
                        rstring = "0";
                        return rstring;
                    }
                }
            }
            catch
            {
                return "0";
            }
        }

        public void DataReceived() { }

        public static string rtnReadGH(string bnum, byte di0, byte di1, byte di2, byte di3)//载波
        {
            int j, i = 0, a = 0;
            string s = "";
            byte[] aa = new byte[512];
            byte[] cc = new byte[512];
            try
            {
                wrtbyt3[0] = 0x68;
                wrtbyt3[1] = (byte)(sConvert(bnum.Substring(10, 2)));
                wrtbyt3[2] = (byte)(sConvert(bnum.Substring(8, 2)));
                wrtbyt3[3] = (byte)(sConvert(bnum.Substring(6, 2)));
                wrtbyt3[4] = (byte)(sConvert(bnum.Substring(4, 2)));
                wrtbyt3[5] = (byte)(sConvert(bnum.Substring(2, 2)));
                wrtbyt3[6] = (byte)(sConvert(bnum.Substring(0, 2)));

                wrtbyt3[7] = 0x68;
                wrtbyt3[8] = 0x11;
                wrtbyt3[9] = 0x04;
                wrtbyt3[10] = di0;
                wrtbyt3[11] = di1;
                wrtbyt3[12] = di2;
                wrtbyt3[13] = di3;
                wrtbyt3[14] = (byte)checksum(wrtbyt3, 0, 14);
                wrtbyt3[15] = 0x16;

                try
                {
                    if (!mysp4.IsOpen)
                        mysp4.Open();

                    Application.DoEvents();

                    mysp4.Write(wrtbyt3, 0, 16);//发送数据

                    mysp4.DiscardInBuffer();

                    for (j = 0; j < 5; j++)
                    {
                        Thread.Sleep(100);
                        Application.DoEvents();
                        if (mysp4.BytesToRead > 0)
                            break;
                    }

                    Thread.Sleep(100);
                    readbyt3 = new byte[mysp4.BytesToRead];
                    mysp4.Read(readbyt3, 0, readbyt3.Length);

                    ////补发数据 
                    if ((readbyt3.Length == 0) || (readbyt3 == null))
                    {
                        mysp4.Write(wrtbyt3, 0, 16);
                        mysp4.DiscardInBuffer();

                        for (j = 0; j < 10; j++)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();
                            if (mysp4.BytesToRead > 0)
                                break;
                        }

                        readbyt3 = new byte[mysp4.BytesToRead];
                        mysp4.Read(readbyt3, 0, readbyt3.Length);
                    }
                    mysp4.DiscardInBuffer();
                    mysp4.DiscardOutBuffer();
                    mysp4.Close();
                    mysp4.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    rstring = "ERR";
                    return rstring;
                }

                if (readbyt3 == null)
                {
                    MessageBox.Show("超时！！");
                    rstring = "ERR";
                    return rstring;
                }

                else
                {
                    try
                    {
                        while (readbyt3[i] != 0x68)
                        {
                            i = i + 1;
                        }
                        readbyt3 = Data_Decode(readbyt3, i + 10, readbyt3.Length - 2);
                        if ((readbyt3[i + 8] == 0x91))//读参数
                        {
                            a = readbyt3.Length - 4 - 10 - i - 2;
                            for (j = 0; j < a; j++)
                            {
                                aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt3[i + 14] & 0xF0) >> 4) + '0');
                                aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt3[i + 14] & 0x0F)) + '0');
                                if (aa[(a - j) * 2 - 2] > '9')
                                    aa[(a - j) * 2 - 2] = (byte)(((comdata.readbyt3[i + 14] & 0xF0) >> 4) - 10 + 'A');
                                if (aa[(a - j) * 2 - 1] > '9')
                                    aa[(a - j) * 2 - 1] = (byte)(((comdata.readbyt3[i + 14] & 0x0F)) - 10 + 'A');
                                i = i + 1;
                            }
                            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                            s = encoding.GetString(aa).Substring(0, a * 2);
                            return s;
                        }
                        else
                        {
                            rstring = "ERR";//错误应答
                            return rstring;
                        }
                    }
                    catch
                    {
                        rstring = "ERR";
                        return rstring;
                    }
                }
            }
            catch
            {
                rstring = "ERR";
                return rstring;
            }
        }

        public static string rtnReadZB(string bnum, string savedata, byte di0, byte di1, byte di2, byte di3)//载波
        {
            int j, i = 0;
            string s = "";
            byte[] aa = new byte[512];
            byte[] cc = new byte[512];
            try
            {
                wrtbyt1[0] = 0x68;
                wrtbyt1[1] = (byte)(sConvert(bnum.Substring(10, 2)));
                wrtbyt1[2] = (byte)(sConvert(bnum.Substring(8, 2)));
                wrtbyt1[3] = (byte)(sConvert(bnum.Substring(6, 2)));
                wrtbyt1[4] = (byte)(sConvert(bnum.Substring(4, 2)));
                wrtbyt1[5] = (byte)(sConvert(bnum.Substring(2, 2)));
                wrtbyt1[6] = (byte)(sConvert(bnum.Substring(0, 2)));

                wrtbyt1[7] = 0x68;
                wrtbyt1[8] = 0x11;
                wrtbyt1[9] = 0x04;
                wrtbyt1[10] = di0;
                wrtbyt1[11] = di1;
                wrtbyt1[12] = di2;
                wrtbyt1[13] = di3;
                wrtbyt1[14] = (byte)checksum(wrtbyt1, 0, 14);
                wrtbyt1[15] = 0x16;

                try
                {
                    if (!mysp3.IsOpen)
                        mysp3.Open();

                    Application.DoEvents();

                    mysp3.Write(wrtbyt1, 0, 16);//发送数据

                    mysp3.DiscardInBuffer();

                    for (j = 0; j < Zbys * 10; j++)
                    {
                        Thread.Sleep(100);
                        Application.DoEvents();
                        if (mysp3.BytesToRead > 0)
                            break;
                    }

                    Thread.Sleep(100);
                    readbyt1 = new byte[mysp3.BytesToRead];
                    mysp3.Read(readbyt1, 0, readbyt1.Length);

                    ////补发数据 
                    if ((readbyt1.Length == 0) || (readbyt1 == null))
                    {
                        mysp3.Write(wrtbyt1, 0, 16);
                        mysp3.DiscardInBuffer();

                        for (j = 0; j < (Zbys + 2) * 10; j++)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();
                            if (mysp3.BytesToRead > 0)
                                break;
                        }

                        readbyt1 = new byte[mysp3.BytesToRead];
                        mysp3.Read(readbyt1, 0, readbyt1.Length);
                    }
                    mysp3.DiscardInBuffer();
                    mysp3.DiscardOutBuffer();
                    mysp3.Close();
                    mysp3.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    rstring = "0";
                    return rstring;
                }

                if (readbyt1 == null)
                {
                    MessageBox.Show("超时！！");
                    rstring = "0";
                    return rstring;
                }

                else
                {
                    try
                    {
                        while (readbyt1[i] != 0x68)
                        {
                            i = i + 1;
                        }
                        //readbyt1 = Data_Decode(readbyt1, i + 10, readbyt1.Length - 2);
                        if ((readbyt1[i + 8] == 0x91))//读参数
                        {
                            int aaa = readbyt1.Length;

                            for (int bbb = 0; bbb < aaa; bbb++)
                            {
                                string xx = Convert.ToString(readbyt1[bbb], 16);
                                if (xx.Length < 2)
                                    xx = "0" + xx;
                                s = s + " " + xx;
                            }
                            return s;
                        }
                        else
                        {
                            rstring = "0";//错误应答
                            return rstring;
                        }
                    }
                    catch
                    {
                        rstring = "0";
                        return rstring;
                    }
                }
            }
            catch
            {
                return "0";
            }
        }

        public static string rtnReadZB1(string bnum, string savedata, byte di0, byte di1, byte di2, byte di3)//载波
        {
            int j, i = 0;
            string s = "";
            byte[] aa = new byte[512];
            byte[] cc = new byte[512];
            try
            {
                wrtbyt1[0] = 0x5a;
                wrtbyt1[1] = 0x03;
                wrtbyt1[2] = 0x00;
                wrtbyt1[3] = 0x15;
                wrtbyt1[4] = 0x01;
                wrtbyt1[5] = 0x00;
                wrtbyt1[6] = 0x01;
                wrtbyt1[7] = 0xfe;
                wrtbyt1[8] = 0xfe;

                wrtbyt1[9] = 0x68;
                wrtbyt1[10] = (byte)(sConvert(bnum.Substring(10, 2)));
                wrtbyt1[11] = (byte)(sConvert(bnum.Substring(8, 2)));
                wrtbyt1[12] = (byte)(sConvert(bnum.Substring(6, 2)));
                wrtbyt1[13] = (byte)(sConvert(bnum.Substring(4, 2)));
                wrtbyt1[14] = (byte)(sConvert(bnum.Substring(2, 2)));
                wrtbyt1[15] = (byte)(sConvert(bnum.Substring(0, 2)));

                wrtbyt1[16] = 0x68;
                wrtbyt1[17] = 0x11;
                wrtbyt1[18] = 0x04;
                wrtbyt1[19] = di0;
                wrtbyt1[20] = di1;
                wrtbyt1[21] = di2;
                wrtbyt1[22] = di3;
                wrtbyt1[23] = (byte)checksum(wrtbyt1, 9, 23);
                wrtbyt1[24] = 0x16;
                wrtbyt1[25] = (byte)checksum(wrtbyt1, 0, 25);
                wrtbyt1[26] = 0x16;

                try
                {
                    if (!mysp3.IsOpen)
                        mysp3.Open();
                    Application.DoEvents();
                    mysp3.Write(wrtbyt1, 0, 27);//发送数据
                    mysp3.DiscardInBuffer();

                    for (j = 0; j < Zbys; j++)
                    {
                        Thread.Sleep(1000);
                        Application.DoEvents();
                    }
                    Thread.Sleep(100);
                    readbyt1 = new byte[mysp3.BytesToRead];
                    mysp3.Read(readbyt1, 0, readbyt1.Length);//接受数据
                    ////补发数据 
                    //if ((readbyt1.Length == 0) || (readbyt1 == null))
                    //{
                    //    mysp3.Write(wrtbyt1, 0, 27);
                    //    mysp3.DiscardInBuffer();

                    //    for (j = 0; j < Zbys + 2; j++)
                    //    {
                    //        Thread.Sleep(1000);
                    //        Application.DoEvents();
                    //    }

                    //    readbyt1 = new byte[mysp3.BytesToRead];
                    //    mysp3.Read(readbyt1, 0, readbyt1.Length);
                    //}
                    mysp3.DiscardInBuffer();
                    mysp3.DiscardOutBuffer();
                    mysp3.Close();
                    mysp3.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    rstring = "0";
                    return rstring;
                }

                if (readbyt1 == null)
                {
                    MessageBox.Show("超时！！");
                    rstring = "0";
                    return rstring;
                }

                else
                {
                    try
                    {
                        while (readbyt1[i] != 0x68)
                        {
                            i = i + 1;
                        }
                        //readbyt1 = Data_Decode(readbyt1, i + 10, readbyt1.Length - 2);
                        if ((readbyt1[i + 8] == 0x91))//读参数
                        {
                            int aaa = readbyt1.Length;

                            for (int bbb = 0; bbb < aaa; bbb++)
                            {
                                string xx = Convert.ToString(readbyt1[bbb], 16);
                                if (xx.Length < 2)
                                    xx = "0" + xx;
                                s = s + " " + xx;
                            }
                            return s;
                        }
                        else
                        {
                            rstring = "0";//错误应答
                            return rstring;
                        }
                    }
                    catch
                    {
                        rstring = "0";
                        return rstring;
                    }
                }
            }
            catch
            {
                return "0";
            }
        }
    }
}