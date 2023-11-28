using EncryptServerConnect;
using ht_698._45.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ht_698._45.UI
{
    public partial class Connection : Form
    {
        private bool isOpen_Connection_dir;
        private TextBox[] txtEsamArray = new TextBox[7];
        public Connection(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        /// <summary>
        /// 读取通讯地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_R_Click(object sender, EventArgs e)
        {
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            string address = PublicVariable.Address;
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    if (!CommParam.comPort.IsOpen)
                    {
                        CommParam.comPort.OpenPort();
                    }
                    if (Protocol.GetRequestNormal("40010200", "43", (PublicVariable.logical_Address == Logical_Address.计量芯 ? "55AAAAAAAAAAAA" : "45AAAAAAAAAAAA"), PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            PublicVariable.Address = (PublicVariable.logical_Address == Logical_Address.计量芯 ? "1" + (((parseData.Length / 2) - 1)) .ToString(): (((parseData.Length / 2) - 1)).ToString("X2")) + parseData;
                            this.txb_Address.Text = parseData;
                            PublicVariable.address = parseData;
                        }
                        this.label_Info.Text = PublicVariable.Info = "地址" + (flag3 ? "读取成功" : ("读取失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                        if (splitFlag)
                        {
                            PublicVariable.SplitFlag = true;
                        }
                        else
                        {
                            PublicVariable.SplitFlag = false;
                        }
                    }
                    else
                    {
                        PublicVariable.Address = address;
                        this.label_Info.Text = "读取地址失败";
                        PublicVariable.Info_Color = "Red";
                    }
                    PublicVariable.Info = this.label_Info.Text;
                    PublicVariable.ChangedFlag = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    PublicVariable.Info = exception.Message;
                    PublicVariable.Info_Color = "Red";
                    PublicVariable.IsReading = false;
                }
                finally
                {
                    PublicVariable.IsReading = false;
                }
            }
        }
        /// <summary>
        /// 应用连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connection_Click(object sender, EventArgs e)
        {
            try
            {
                if (PublicVariable.IsReading)
                {
                    return;
                }
                PublicVariable.IsReading = true;
                this.txt_Verify.Text = "";
                this.txt_Link.Text = "";
                StringBuilder builder = new StringBuilder(100);
                StringBuilder builder2 = new StringBuilder(200);
                StringBuilder builder3 = new StringBuilder(100);
                List<string> cData = new List<string>();
                StringBuilder cOutData = new StringBuilder(400);
                int num = -1;
                bool flag = false;
                if (!PublicVariable.LinkRoadFlag)//判断网络直连（内网）
                {
                    if (PublicVariable.IsLink)//判断服务连接状态
                    {
                        flag = false;
                        object[] str = new object[] { PublicVariable.Key_State, PublicVariable.cDiv, (PublicVariable.Counter + 1).ToString("X8"), "01" };
                        if(EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.InitSession, ref builder, ref builder2, ref builder3, str))
                        {
                            flag = false;
                            if (!this.CONNECT_Request(builder2, builder3, ref cData))
                            {
                                goto Label_0207;//无条件跳转
                            }
                            flag = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifySession, ref cOutData, new object[] { PublicVariable.Key_State, PublicVariable.cDiv, builder, cData[0], cData[1] });
                            if (flag)
                            {
                                if (cOutData.Length >= 0x160)
                                {
                                    goto Label_0207;
                                }
                                MessageBox.Show("获取会话向量失败");
                            }
                            else
                            {
                                MessageBox.Show("获取会话向量失败");
                            }
                        }
                        else
                        {
                            MessageBox.Show("密钥获取失败");
                        }
                        return;
                    }
                }
                else
                {
                    if (PublicVariable.IsLink)
                    {
                        PublicVariable.IsLink = false;
                        EncryptServerConnect.CloseEncryptServer698();
                    }
                    num = this.isOpen_Connection_dir ? 0 : 1;
                    if (num == 0)
                    {
                        num = SocketApi.Obj_Meter_Formal_InitSession(PublicVariable.Key_State, PublicVariable.cDiv, (PublicVariable.Counter + 1).ToString("X8"), "01", builder, builder2, builder3);
                        if (num == 0)
                        {
                            num = -1;
                            if (this.CONNECT_Request(builder2, builder3, ref cData))
                            {
                                num = SocketApi.Obj_Meter_Formal_VerifySession(PublicVariable.Key_State, PublicVariable.cDiv, builder, cData[0], cData[1], cOutData);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("请连接加密机！");
                    }
                }
            Label_0207:
                if ((num == 0) || flag)
                {
                    PublicVariable.ConnetionFlag = true;
                    this.txt_Verify.Text = "会话协商验证成功";
                    this.txt_Link.Text = "建立应用连接成功";
                    this.txt_Verify.BackColor = Color.Aqua;
                    this.txt_Link.BackColor = Color.Aqua;
                    this.txt_Session.BackColor = Color.Aqua;
                    PublicVariable.cOutSessionKey = cOutData;
                    this.btn_Disconnect.Enabled = true;
                    this.tb_协商失效.Enabled = true;
                }
                else
                {
                    PublicVariable.ConnetionFlag = false;
                    this.txt_Verify.Text = "会话协商验证失败";
                    this.txt_Link.Text = "建立应用连接失败";
                    this.txt_Verify.BackColor = Color.Red;
                    this.txt_Link.BackColor = Color.Red;
                    this.txt_Session.BackColor = Color.Red;
                }
                PublicVariable.Info = "建立会话协商" + (((num == 0) || flag) ? "成功  " : "失败");
                PublicVariable.Info_Color = ((num == 0) || flag) ? "Blue" : "Red";
            }
            catch (Exception exception)
            {
                PublicVariable.IsReading = false;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                bool timeTag = false;
                string cData = "";
                PublicVariable.PIID_R = (byte)(PublicVariable.PIID_R + 1);
                cData = "03" + PublicVariable.PIID_R.ToString("X2") + "00";
                short num = (short)(15 + (cData.Length / 2));
                if (Protocol.OrigDLT698Wrap(num.ToString("X4"), "43", PublicVariable.Address, PublicVariable.Client_Add, cData, timeTag))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.Info = "断开连接失败";
                    PublicVariable.Info_Color = "Red";
                }
                string linkData = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    if (Protocol.RecIsProtocol(PublicVariable.RecDataString, ref linkData, ref bExtend))
                    {
                        if (linkData.Substring(4, 2) == "00")
                        {
                            PublicVariable.ConnetionFlag = false;
                            PublicVariable.Info = "断开连接成功";
                            PublicVariable.Info_Color = "Blue";
                            this.txt_Verify.Text = "协商验证已失效";
                            this.txt_Link.Text = "协商已失效";
                            this.txt_Session.Text = "断开连接成功";
                            this.txt_Verify.BackColor = Color.Red;
                            this.txt_Link.BackColor = Color.Red;
                            this.txt_Session.BackColor = Color.Red;
                            this.btn_Disconnect.Enabled = false;
                            this.tb_协商失效.Enabled = false;
                        }
                        PublicVariable.SplitFlag = bExtend;
                        PublicVariable.ChangedFlag = true;
                    }
                    else
                    {
                        PublicVariable.Info = "断开连接失败";
                        PublicVariable.Info_Color = "Red";
                    }
                }
                else
                {
                    PublicVariable.Info = "断开连接失败";
                    PublicVariable.Info_Color = "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_ESAM_R_Click(object sender, EventArgs e)
        {
            try
            {
                this.InitTxt();
                bool flag = false;
                bool splitFlag = false;
                string str = "F1000200F1000400F1000700F1000500F1000600F100030040020200";
                string cData = "";
                string str3 = "";
                List<string> list = new List<string>();
                List<string> parseData = new List<string>();
                PublicVariable.DARInfo = "";
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    flag = Protocol.GetRequestNormalList(7, str, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        bool flag3 = Protocol.GetResponseNormalList(cData, ref str3, ref list, ref parseData);
                        if (flag3)
                        {
                            for (int i = 0; i < parseData.Count; i++)
                            {
                                if (i == 2)
                                {
                                    this.txtEsamArray[i].Text = parseData[i].ToString().Substring(0, 8);
                                }
                                else
                                {
                                    this.txtEsamArray[i].Text = parseData[i].ToString();
                                }
                            }
                            PublicVariable.ESAM_ID = this.txtEsamArray[0].Text.PadLeft(0x10, '0');
                            PublicVariable.Meter_NO = this.txtEsamArray[6].Text.PadLeft(0x10, '0');
                            PublicVariable.Counter = Convert.ToInt32(this.txtEsamArray[2].Text);
                            if (this.txtEsamArray[1].Text.Substring(0, 9) != "7FFFFFFFF")
                            {
                                PublicVariable.Key_State = 0;
                                PublicVariable.cDiv = PublicVariable.ESAM_ID;
                            }
                            else
                            {
                                PublicVariable.Key_State = 1;
                                PublicVariable.cDiv = PublicVariable.Meter_NO;
                            }
                            if (this.txt5.Text == "00000000")
                            {
                                this.txt_Verify.Text = "未协商或已失效";
                                this.txt_Link.Text = "未协商或已失效";
                                this.txt_Session.Text = "未协商或已失效";
                                this.txt_Verify.BackColor = Color.Red;
                                this.txt_Link.BackColor = Color.Red;
                                this.txt_Session.BackColor = Color.Red;
                            }
                        }
                        PublicVariable.Info = "ESAM信息" + (flag3 ? "读取成功  " : "读取失败--") + PublicVariable.DARInfo;
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    }
                    else
                    {
                        PublicVariable.Info = "ESAM信息" + (flag ? "读取成功  " : "读取失败--") + PublicVariable.DARInfo;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    }
                    PublicVariable.IsReading = false;
                }
            }
            catch (Exception exception)
            {
                PublicVariable.IsReading = false;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void InitTxt()
        {
            this.txtEsamArray[0] = this.txt1;
            this.txtEsamArray[1] = this.txt2;
            this.txtEsamArray[2] = this.txt3;
            this.txtEsamArray[3] = this.txt4;
            this.txtEsamArray[4] = this.txt5;
            this.txtEsamArray[5] = this.txt6;
            this.txtEsamArray[6] = this.txt7;
        }

        private void btn_RemainTime_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    PublicVariable.DARInfo = "";
                    string cData = "";
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    bool splitFlag = false;
                    if (Protocol.GetRequestNormal("F1000600", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            this.txt_RemainTime.Text = Convert.ToInt32(parseData).ToString("D8");
                        }
                        PublicVariable.Info = "会话剩余时间抄读" + (flag3 ? "成功" : ("失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    }
                    else
                    {
                        PublicVariable.Info = "会话剩余时间失败";
                        PublicVariable.Info_Color = "Red";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.IsReading = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void btn_时效设置_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    bool flag = false;
                    string linkdata = "";
                    bool splitFlag = false;
                    string str3 = "";
                    string str4 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string str6 = "F1000900";
                    string mAC = "";
                    string outData = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    if (Protocol.Get_Math_密文_SID_会话时效设置(Convert.ToInt32(this.txt_会话门限.Text, 10).ToString("X8").PadLeft(8, '0'), ref outData))
                    {
                        linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), str6 + outData, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str6, outData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;
                        }
                    }
                    PublicVariable.Info = this.btn_时效设置.Text + "--" + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (!flag)
                    {
                        PublicVariable.IsReading = false;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    PublicVariable.Info = exception.Message;
                    PublicVariable.Info_Color = "Red";
                    PublicVariable.IsReading = false;
                }
                finally
                {
                    PublicVariable.IsReading = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    PublicVariable.DARInfo = "";
                    string cData = "";
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    bool splitFlag = false;
                    if (Protocol.GetRequestNormal("F1001100", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            this.textBox1.Text = Convert.ToInt32(parseData).ToString("D2");
                        }
                        PublicVariable.Info = "身份认证启用读取" + (flag3 ? "成功" : ("失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    }
                    else
                    {
                        PublicVariable.Info = "身份认证启用读取失败";
                        PublicVariable.Info_Color = "Red";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.IsReading = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    List<string> frameData = new List<string>();
                    string str5 = "";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    string data = "";
                    string dataType = "";
                    string dataLen = "";
                    string action = "";
                    action = "06";
                    dataType = "10";
                    dataLen = "04";
                    str5 = "44010200";
                    data = this.txt_PassWord.Text.PadLeft(8, '0');
                    frameData.Clear();
                    cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
                    parseData = "";
                    list.Clear();
                    linkdata = Protocol.MakeLink_Data(action, "01", PublicVariable.PIID_R.ToString("X2"), str5 + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.button2.Text + "--" + (flag ? "设置成功" : "设置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    PublicVariable.Info = exception.Message;
                    PublicVariable.Info_Color = "Red";
                    PublicVariable.IsReading = false;
                }
                finally
                {
                    PublicVariable.IsReading = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    PublicVariable.DARInfo = "";
                    string cData = "";
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    bool splitFlag = false;
                    if (Protocol.GetRequestNormal("F1001200", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            this.textBox2.Text = parseData;
                        }
                        PublicVariable.Info = "终端地址读取" + (flag3 ? "成功" : ("失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    }
                    else
                    {
                        PublicVariable.Info = "终端地址读取失败";
                        PublicVariable.Info_Color = "Red";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.IsReading = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    PublicVariable.DARInfo = "";
                    string cData = "";
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    bool splitFlag = false;
                    if (Protocol.GetRequestNormal("F1001300", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            this.textBox3.Text = Convert.ToInt32(parseData).ToString("D8");
                        }
                        PublicVariable.Info = "终端广播计数器" + (flag3 ? "成功" : ("失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    }
                    else
                    {
                        PublicVariable.Info = "终端广播计数器失败";
                        PublicVariable.Info_Color = "Red";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.IsReading = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string[] strArray = new string[] { "F1000E00" };
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                cData = "";
                parseData = "";
                list.Clear();
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[i], PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.GetRequestNormal(strArray[i], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                        if (flag)
                        {
                            flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        }
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        break;
                }
                this.textBox23.Text = flag ? parseData : "";
                PublicVariable.Info = "红外时效" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string[] strArray = new string[] { "F1000F00" };
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                cData = "";
                parseData = "";
                list.Clear();
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[i], PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.GetRequestNormal(strArray[i], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                        if (flag)
                        {
                            flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        }
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        break;
                }
                this.textBox24.Text = flag ? parseData : "";
                PublicVariable.Info = "红外认证剩余时间" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string data = "";
            string[] strArray = new string[] { "F1000E00" };
            byte[] buffer = new byte[] { 6 };
            byte[] buffer2 = new byte[] { 4 };
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                cData = "";
                data = this.textBox25.Text;
                cData = Protocol.From_Type_GetData(buffer[i], buffer2[i], ref data);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], cData, PublicVariable.TimeTag, ref splitFlag);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = "红外时效" + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    PublicVariable.DARInfo = "";
                    string cData = "";
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    bool splitFlag = false;
                    if (Protocol.GetRequestNormal("F1001400", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            this.textBox4.Text = Convert.ToInt32(parseData).ToString("D8");
                        }
                        PublicVariable.Info = "终端与电表会话计数器" + (flag3 ? "成功" : ("失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    }
                    else
                    {
                        PublicVariable.Info = "终端与电表会话计数器失败";
                        PublicVariable.Info_Color = "Red";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.IsReading = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    PublicVariable.DARInfo = "";
                    string cData = "";
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    bool splitFlag = false;
                    if (Protocol.GetRequestNormal("F1001500", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            this.textBox5.Text = Convert.ToInt32(parseData.Substring(0, 8)).ToString("D8");
                            this.textBox6.Text = Convert.ToInt32(parseData.Substring(8)).ToString("D8");
                        }
                        PublicVariable.Info = "终端会话门限" + (flag3 ? "成功" : ("失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    }
                    else
                    {
                        PublicVariable.Info = "终端会话门限失败";
                        PublicVariable.Info_Color = "Red";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.IsReading = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }
        /// <summary>
        /// 应用连接请求
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="cData"></param>
        /// <returns></returns>
        public bool CONNECT_Request(StringBuilder str1, StringBuilder str2, ref List<string> cData)
        {
            try
            {
                PublicVariable.PIID_R = (byte)(PublicVariable.PIID_R + 1);
                bool bExtend = false;
                bool flag2 = false;
                string linkData = "";
                string str3 = "";
                string str5 = "02";//应用连接请求
                str3 = str5 + PublicVariable.PIID_R.ToString("X2") + this.txt8.Text.PadLeft(4, '0') + this.txt9.Text.PadLeft(0x10, '0') + this.txt10.Text.PadLeft(0x20, '0') + Convert.ToInt16(this.txt11.Text).ToString("X4") + Convert.ToInt16(this.txt12.Text).ToString("X4") + Convert.ToInt16(this.txt13.Text).ToString("X2") + Convert.ToInt16(this.txt14.Text).ToString("X4") + Convert.ToInt32(this.txt15.Text).ToString("X8") + this.cbx_Security.SelectedIndex.ToString("X2");
                if ((this.cbx_Security.SelectedIndex == 2) || (this.cbx_Security.SelectedIndex == 3))//一般密码或者对称连接
                {
                    object[] objArray = new object[] { str3, (str1.Length / 2).ToString("X2"), str1, (str2.Length / 2).ToString("X2"), str2 };
                    str3 = string.Concat(objArray);
                }
                else if (this.cbx_Security.SelectedIndex == 1)//公共连接
                {
                    str3 = str3 + this.txt_PassWord.Text.PadLeft(8, '0');
                }
                else//数字签名
                {
                    int selectedIndex = this.cbx_Security.SelectedIndex;
                }
                str3 = str3 + "00";
                short num9 = (short)(15 + (str3.Length / 2));
                if (Protocol.OrigDLT698Wrap(num9.ToString("X4"), "43", PublicVariable.Address, PublicVariable.Client_Add, str3, false))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.Info = "连接失败";
                    PublicVariable.Info_Color = "Red";
                    return false;
                }
                if ((PublicVariable.RecDataString.Length > 0x10) && Protocol.RecIsProtocol(PublicVariable.RecDataString, ref linkData, ref bExtend))
                {
                    flag2 = this.CONNECT_Response(linkData, ref cData);
                    PublicVariable.SplitFlag = bExtend;
                    PublicVariable.ChangedFlag = true;
                    return flag2;
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }
        private bool ConnectResponseInfo(string str, ref List<string> cData)
        {
            try
            {
                string str2 = "";
                str2 = str.Substring(0, 2);
                this.txt_Session.Text = ((ConnectResult)Convert.ToByte(str2, 0x10)).ToString();
                str = str.Substring(2);
                string str3 = str.Substring(0, 2);
                byte[] buffer = new byte[2];
                if (str3 == "01")
                {
                    str = str.Substring(2);
                    for (int i = 0; i < 2; i++)
                    {
                        buffer[i] = Convert.ToByte(str.Substring(0, 2), 0x10);
                        cData.Add(str.Substring(2, buffer[i] * 2));
                        str = str.Substring(2 + (buffer[i] * 2));
                    }
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }
        /// <summary>
        /// 应用连接应答
        /// </summary>
        /// <param name="str"></param>
        /// <param name="cData"></param>
        /// <returns></returns>
        public bool CONNECT_Response(string str, ref List<string> cData)
        {
            try
            {
                List<string> list = new List<string>();
                byte[] buffer = new byte[] { 1, 0x20, 2, 8, 0x10, 2, 2, 1, 2, 4 };
                if (str.Length >= 150)
                {
                    str = str.Substring(2);
                    for (int i = 0; i < 10; i++)
                    {
                        list.Add(str.Substring(0, buffer[i] * 2));
                        str = str.Substring(buffer[i] * 2);
                    }
                    return this.ConnectResponseInfo(str, ref cData);
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        private void Connection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PublicVariable.isBt_InfraredOn = this.tl_红外认证.Enabled;
                PublicVariable.isBt_ConnctionOn = this.btn_Connection.Enabled;
                PublicVariable.isBt_ConnctionCutOn = this.btn_Disconnect.Enabled;
                PublicVariable.isBt_协商失效 = this.tb_协商失效.Enabled;
                PublicVariable.disBuff[0] = this.txb_Address.Text;
                PublicVariable.disBuff[1] = this.txt1.Text;
                PublicVariable.disBuff[2] = this.txt2.Text;
                PublicVariable.disBuff[3] = this.txt3.Text;
                PublicVariable.disBuff[4] = this.txt4.Text;
                PublicVariable.disBuff[5] = this.txt5.Text;
                PublicVariable.disBuff[6] = this.txt6.Text;
                PublicVariable.disBuff[7] = this.txt7.Text;
                PublicVariable.disBuff[8] = this.txt_Session.Text;
                PublicVariable.disBuff[9] = this.txt_Verify.Text;
                PublicVariable.disBuff[10] = this.txt_Link.Text;
                PublicVariable.disBuff[11] = this.txt_RemainTime.Text;
                PublicVariable.disBuff[12] = this.textBox24.Text;
                PublicVariable.disBuff[13] = this.textBox23.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            this.cbx_Security.SelectedIndex = 2;
            this.tl_红外认证.Enabled = PublicVariable.isBt_InfraredOn;
            this.btn_Connection.Enabled = PublicVariable.isBt_ConnctionOn;
            this.btn_Disconnect.Enabled = PublicVariable.isBt_ConnctionCutOn;
            this.tb_协商失效.Enabled = PublicVariable.isBt_协商失效;
            this.txb_Address.Text = PublicVariable.disBuff[0];
            this.txt1.Text = PublicVariable.disBuff[1];
            this.txt2.Text = PublicVariable.disBuff[2];
            this.txt3.Text = PublicVariable.disBuff[3];
            this.txt4.Text = PublicVariable.disBuff[4];
            this.txt5.Text = PublicVariable.disBuff[5];
            this.txt6.Text = PublicVariable.disBuff[6];
            this.txt7.Text = PublicVariable.disBuff[7];
            this.txt_Session.Text = PublicVariable.disBuff[8];
            this.txt_Verify.Text = PublicVariable.disBuff[9];
            this.txt_Link.Text = PublicVariable.disBuff[10];
            this.txt_RemainTime.Text = PublicVariable.disBuff[11];
            this.textBox24.Text = PublicVariable.disBuff[12];
            this.textBox23.Text = PublicVariable.disBuff[13];
        }
        [DllImport("SocketAPI.dll", EntryPoint = "Meter_Formal_InfraredAuth", CallingConvention = CallingConvention.StdCall)]
        public static extern int InfraredAuthNet(int Flag, [MarshalAs(UnmanagedType.LPStr)] string PutDiv, [MarshalAs(UnmanagedType.LPStr)] string PutEsamNo, [MarshalAs(UnmanagedType.LPStr)] string PutRand1, [MarshalAs(UnmanagedType.LPStr)] string PutRand1Endata, [MarshalAs(UnmanagedType.LPStr)] string PutRand2, [MarshalAs(UnmanagedType.LPStr)] StringBuilder PutRand2Endata);
        [DllImport("SocketAPI.dll", EntryPoint = "Meter_Formal_InfraredRand", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int InfraredRandNet([MarshalAs(UnmanagedType.LPStr)] StringBuilder OutRand1);

        private void tb_协商失效_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    List<string> list2 = new List<string>();
                    string str5 = "";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    for (int i = 0; i < 1; i++)
                    {
                        str5 = "F1000500";
                        cData = "00";
                        linkdata = "0701" + PublicVariable.PIID_W.ToString("X2") + str5 + cData + "00";
                        list2.Clear();
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = "协商失效_" + (flag ? "设置成功" : "设置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        this.tb_协商失效.Enabled = !flag;
                        if (flag)
                        {
                            this.txt_Verify.Text = "协商已失效";
                            this.txt_Link.Text = "协商已失效";
                            this.txt_Session.Text = "协商已失效";
                            this.txt_Verify.BackColor = Color.Red;
                            this.txt_Link.BackColor = Color.Red;
                            this.txt_Session.BackColor = Color.Red;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    PublicVariable.Info = exception.Message;
                    PublicVariable.Info_Color = "Red";
                    PublicVariable.IsReading = false;
                }
                finally
                {
                    PublicVariable.IsReading = false;
                }
            }
        }

        private void tl_红外认证_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    StringBuilder cOutData = new StringBuilder(0x20);
                    StringBuilder builder2 = new StringBuilder(0x200);
                    string str = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    bool flag = false;
                    bool splitFlag = false;
                    if (!PublicVariable.LinkRoadFlag)
                    {
                        if (PublicVariable.IsLink)
                        {
                            bool flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.InfraredRand, ref cOutData, new object[0]);
                            if (flag3)
                            {
                                str = ((cOutData.Length / 2)).ToString("X2") + cOutData.ToString();
                                flag3 = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, "F1000B00", "57" + str, ref list, PublicVariable.TimeTag, ref splitFlag);
                                if (flag3)
                                {
                                    string str3 = cOutData.ToString();
                                    string str4 = "0000" + list[0].ToString();
                                    string str5 = list[1].ToString();
                                    string str6 = list[2].ToString();
                                    string str7 = list[3].ToString();
                                    flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.InfraredAuth, ref builder2, new object[] { 0, str4, str5, str3, str6, str7 });
                                    if (flag3)
                                    {
                                        flag3 = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, "F1000C00", "09" + ((builder2.Length / 2)).ToString("X2") + builder2.ToString(), ref parseData, PublicVariable.TimeTag, ref splitFlag);
                                    }
                                }
                            }
                            PublicVariable.Info = "红外认证" + (flag3 ? "成功" : ("失败--" + PublicVariable.DARInfo));
                            PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                        }
                        else
                        {
                            PublicVariable.Info = "红外请求失败";
                            PublicVariable.Info_Color = "Red";
                            if (!this.isOpen_Connection_dir)
                            {
                                MessageBox.Show("请连接加密机！");
                            }
                        }
                    }
                    else if ((InfraredRandNet(cOutData) == 0) && this.isOpen_Connection_dir)
                    {
                        str = ((cOutData.Length / 2)).ToString("X2") + cOutData.ToString();
                        if (Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, "F1000B00", "57" + str, ref list, PublicVariable.TimeTag, ref splitFlag))
                        {
                            string str8 = cOutData.ToString();
                            string putDiv = "0000" + list[0].ToString();
                            string putEsamNo = list[1].ToString();
                            string str11 = list[2].ToString();
                            string str12 = list[3].ToString();
                            int num2 = InfraredAuthNet(0, putDiv, putEsamNo, str8, str11, str12, builder2);
                            if (num2 == 0)
                            {
                                flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, "F1000C00", "09" + ((builder2.Length / 2)).ToString("X2") + builder2.ToString(), ref parseData, PublicVariable.TimeTag, ref splitFlag);
                                PublicVariable.Info = "红外认证" + (flag ? "成功" : ("失败--" + PublicVariable.DARInfo));
                                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            }
                            else
                            {
                                PublicVariable.Info = "红外认证" + ((num2 == 0) ? "成功" : ("失败--" + PublicVariable.DARInfo));
                                PublicVariable.Info_Color = (num2 == 0) ? "Blue" : "Red";
                            }
                        }
                        else
                        {
                            PublicVariable.Info = "红外请求失败";
                            PublicVariable.Info_Color = "Red";
                        }
                    }
                    else
                    {
                        PublicVariable.Info = "红外请求失败";
                        PublicVariable.Info_Color = "Red";
                        if (!this.isOpen_Connection_dir)
                        {
                            MessageBox.Show("请连接加密机！");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                PublicVariable.IsReading = false;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.LinkRoadFlag)
                {
                    EncryptServerConnect.CloseEncryptServer698();
                    PublicVariable.IsLink = false;
                    Thread.Sleep(0x3e8);
                    if (!PublicVariable.IsLink)
                    {
                        bool flag = EncryptServerConnect.ConnectEncryptServer698(PublicVariable.IP, Convert.ToUInt16(PublicVariable.port));
                        if (!flag)
                        {
                            MessageBox.Show("无法连接服务器，请检查网络及配置");
                        }
                        else
                        {
                            PublicVariable.IsLink = true;
                            this.tl_红外认证.Enabled = true;
                            this.btn_Connection.Enabled = true;
                            this.isOpen_Connection_dir = false;
                            PublicVariable.Info = "连接加密机" + (flag ? "_成功" : "_失败");
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        }
                    }
                }
                else
                {
                    int num = SocketApi.ConnectDevice(PublicVariable.IP, PublicVariable.port, PublicVariable.timeOut);
                    int num2 = SocketApi2.ConnectDevice(PublicVariable.IP, PublicVariable.port, PublicVariable.timeOut);
                    if ((num == 0) && (num2 == 0))
                    {
                        this.isOpen_Connection_dir = true;
                        this.tl_红外认证.Enabled = true;
                        this.btn_Connection.Enabled = true;
                        PublicVariable.IsLink = false;
                    }
                    PublicVariable.Info = "连接加密机" + ((num == 0) ? "_成功" : "_失败");
                    PublicVariable.Info_Color = (num == 0) ? "Blue" : "Red";
                }
            }
            catch (Exception exception)
            {
                this.isOpen_Connection_dir = false;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void txb_Address_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PublicVariable.Address = (PublicVariable.logical_Address==Logical_Address.计量芯?"15":"05") + this.txb_Address.Text.PadLeft(12, '0');
                PublicVariable.address = this.txb_Address.Text.PadLeft(12, '0');
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
      
    }
}
