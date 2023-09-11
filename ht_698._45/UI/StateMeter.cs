using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ht_698._45.UI
{
    public partial class StateMeter : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private TextBox[] txtCount = new TextBox[0x41];
        private TextBox[] txtArray = new TextBox[7];
        public StateMeter(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            this.InitArray();
        }

        private void btn_Read_page4_Click(object sender, EventArgs e)
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
                    string data = "40220200";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    parseData = "";
                    list.Clear();
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.GetRequestNormal(data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = "插卡状态字-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        switch ((Convert.ToInt32(parseData, 0x10) & 0xc000))
                        {
                            case 0:
                                this.txt_CardState.Text = "未知";
                                return;

                            case 0x4000:
                                this.txt_CardState.Text = "失败";
                                return;

                            case 0x8000:
                                this.txt_CardState.Text = "成功";
                                return;
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

        private void btn_Exit_page1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btn_Read_page1_Click(object sender, EventArgs e)
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
                    string data = "20140200";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    parseData = "";
                    list.Clear();
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.GetRequestNormal(data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = "运行状态字-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        this.Explain_状态字(parseData);
                        if ((PublicVariable.follow_OADNormal.Count != 0) || (PublicVariable.follow_OADRercord != ""))
                        {
                            if ((this.followForm == null) || this.followForm.IsDisposed)
                            {
                                this.followForm = new FollowRepoartAndTimeTag();
                                this.followForm.Show(this);
                            }
                            else
                            {
                                this.followForm.Dispose();
                                this.followForm = new FollowRepoartAndTimeTag();
                                this.followForm.Show(this);
                            }
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
        private void Explain_状态字(string str)
        {
            int num = -1;
            string str2 = str.Substring(0, 4);
            int num2 = -1;
            num = Convert.ToInt32(str2, 0x10);
            num2 = num & 0x4000;
            this.txt_0.Text = (num2 == 0) ? "滑差" : "区间";
            if (num2 != 0)
            {
                this.txt_0.BackColor = Color.Red;
            }
            else
            {
                this.txt_0.BackColor = Color.White;
            }
            num2 = num & 0x2000;
            this.txt_1.Text = (num2 == 0) ? "正常" : "欠压";
            if (num2 != 0)
            {
                this.txt_1.BackColor = Color.Red;
            }
            else
            {
                this.txt_1.BackColor = Color.White;
            }
            num2 = num & 0x1000;
            this.txt_2.Text = (num2 == 0) ? "正常" : "欠压";
            if (num2 != 0)
            {
                this.txt_2.BackColor = Color.Red;
            }
            else
            {
                this.txt_2.BackColor = Color.White;
            }
            num2 = num & 0x800;
            this.txt_3.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_3.BackColor = Color.Red;
            }
            else
            {
                this.txt_3.BackColor = Color.White;
            }
            num2 = num & 0x400;
            this.txt_4.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_4.BackColor = Color.Red;
            }
            else
            {
                this.txt_4.BackColor = Color.White;
            }
            num2 = num & 0x80;
            this.txt_5.Text = (num2 == 0) ? "正常" : "错误";
            if (num2 != 0)
            {
                this.txt_5.BackColor = Color.Red;
            }
            else
            {
                this.txt_5.BackColor = Color.White;
            }
            num2 = num & 0x40;
            this.txt_6.Text = (num2 == 0) ? "正常" : "错误";
            if (num2 != 0)
            {
                this.txt_6.BackColor = Color.Red;
            }
            else
            {
                this.txt_6.BackColor = Color.White;
            }
            num2 = num & 8;
            this.txt_7.Text = (num2 == 0) ? "正常" : "错误";
            if (num2 != 0)
            {
                this.txt_7.BackColor = Color.Red;
            }
            else
            {
                this.txt_7.BackColor = Color.White;
            }
            num2 = num & 4;
            this.txt_8.Text = (num2 == 0) ? "正常" : "错误";
            if (num2 != 0)
            {
                this.txt_8.BackColor = Color.Red;
            }
            else
            {
                this.txt_8.BackColor = Color.White;
            }
            num2 = num & 2;
            this.txt_9.Text = (num2 == 0) ? "正常" : "错误";
            if (num2 != 0)
            {
                this.txt_9.BackColor = Color.Red;
            }
            else
            {
                this.txt_9.BackColor = Color.White;
            }
            num2 = num & 1;
            this.txt_10.Text = (num2 == 0) ? "正常" : "错误";
            if (num2 != 0)
            {
                this.txt_10.BackColor = Color.Red;
            }
            else
            {
                this.txt_10.BackColor = Color.White;
            }
            num = Convert.ToInt32(str.Substring(4, 4), 0x10);
            num2 = num & 0x8000;
            this.txt_11.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_11.BackColor = Color.Red;
            }
            else
            {
                this.txt_11.BackColor = Color.White;
            }
            num2 = num & 0x4000;
            this.txt_12.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_12.BackColor = Color.Red;
            }
            else
            {
                this.txt_12.BackColor = Color.White;
            }
            num2 = num & 0x2000;
            this.txt_13.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_13.BackColor = Color.Red;
            }
            else
            {
                this.txt_13.BackColor = Color.White;
            }
            num2 = num & 0x800;
            this.txt_14.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_14.BackColor = Color.Red;
            }
            else
            {
                this.txt_14.BackColor = Color.White;
            }
            num2 = num & 0x400;
            this.txt_15.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_15.BackColor = Color.Red;
            }
            else
            {
                this.txt_15.BackColor = Color.White;
            }
            num2 = num & 0x200;
            this.txt_16.Text = (num2 == 0) ? "正向" : "反向";
            if (num2 != 0)
            {
                this.txt_16.BackColor = Color.Red;
            }
            else
            {
                this.txt_16.BackColor = Color.White;
            }
            num = Convert.ToInt32(str.Substring(8, 4), 0x10);
            switch ((num & 0x6000))
            {
                case 0:
                    this.txt_17.Text = "主电源";
                    this.txt_17.BackColor = Color.White;
                    break;

                case 0x4000:
                    this.txt_17.Text = "辅助电源";
                    this.txt_17.BackColor = Color.Red;
                    break;

                case 0x2000:
                    this.txt_17.Text = "电池供电";
                    this.txt_17.BackColor = Color.Red;
                    break;
            }
            num2 = num & 0x1000;
            this.txt_18.Text = (num2 == 0) ? "失效" : "有效";
            if (num2 != 0)
            {
                this.txt_18.BackColor = Color.Red;
            }
            else
            {
                this.txt_18.BackColor = Color.White;
            }
            num2 = num & 0x800;
            this.txt_19.Text = (num2 == 0) ? "通" : "断";
            if (num2 != 0)
            {
                this.txt_19.BackColor = Color.Red;
            }
            else
            {
                this.txt_19.BackColor = Color.White;
            }
            num2 = num & 0x200;
            this.txt_20.Text = (num2 == 0) ? "通" : "断";
            if (num2 != 0)
            {
                this.txt_20.BackColor = Color.Red;
            }
            else
            {
                this.txt_20.BackColor = Color.White;
            }
            num2 = num & 0x100;
            this.txt_21.Text = (num2 == 0) ? "无" : "有";
            if (num2 != 0)
            {
                this.txt_21.BackColor = Color.Red;
            }
            else
            {
                this.txt_21.BackColor = Color.White;
            }
            switch ((num & 0xc0))
            {
                case 0:
                    this.txt_22.Text = "非预付费表";
                    this.txt_22.BackColor = Color.White;
                    break;

                case 0x80:
                    this.txt_22.Text = "电量型预付费";
                    this.txt_22.BackColor = Color.Red;
                    break;

                case 0x40:
                    this.txt_22.Text = "电费型预付费";
                    this.txt_22.BackColor = Color.Red;
                    break;
            }
            num2 = num & 8;
            this.txt_23.Text = (num2 == 0) ? "非保电" : "保电";
            if (num2 != 0)
            {
                this.txt_23.BackColor = Color.Red;
            }
            else
            {
                this.txt_23.BackColor = Color.White;
            }
            num2 = num & 4;
            this.txt_24.Text = (num2 == 0) ? "失效" : "有效";
            if (num2 != 0)
            {
                this.txt_24.BackColor = Color.Red;
            }
            else
            {
                this.txt_24.BackColor = Color.White;
            }
            num2 = num & 2;
            this.txt_25.Text = (num2 == 0) ? "开户" : "未开户";
            if (num2 != 0)
            {
                this.txt_25.BackColor = Color.Red;
            }
            else
            {
                this.txt_25.BackColor = Color.White;
            }
            num2 = num & 1;
            this.txt_26.Text = (num2 == 0) ? "开户" : "未开户";
            if (num2 != 0)
            {
                this.txt_26.BackColor = Color.Red;
            }
            else
            {
                this.txt_26.BackColor = Color.White;
            }
            num = Convert.ToInt32(str.Substring(12, 4), 0x10);
            num2 = num & 0x8000;
            this.txt_27.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_27.BackColor = Color.Red;
            }
            else
            {
                this.txt_27.BackColor = Color.White;
            }
            num2 = num & 0x4000;
            this.txt_28.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_28.BackColor = Color.Red;
            }
            else
            {
                this.txt_28.BackColor = Color.White;
            }
            num2 = num & 0x2000;
            this.txt_29.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_29.BackColor = Color.Red;
            }
            else
            {
                this.txt_29.BackColor = Color.White;
            }
            num2 = num & 0x1000;
            this.txt_30.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_30.BackColor = Color.Red;
            }
            else
            {
                this.txt_30.BackColor = Color.White;
            }
            num2 = num & 0x800;
            this.txt_31.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_31.BackColor = Color.Red;
            }
            else
            {
                this.txt_31.BackColor = Color.White;
            }
            num2 = num & 0x400;
            this.txt_32.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_32.BackColor = Color.Red;
            }
            else
            {
                this.txt_32.BackColor = Color.White;
            }
            num2 = num & 0x200;
            this.txt_33.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_33.BackColor = Color.Red;
            }
            else
            {
                this.txt_33.BackColor = Color.White;
            }
            num2 = num & 0x100;
            this.txt_34.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_34.BackColor = Color.Red;
            }
            else
            {
                this.txt_34.BackColor = Color.White;
            }
            num2 = num & 0x80;
            this.txt_35.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_35.BackColor = Color.Red;
            }
            else
            {
                this.txt_35.BackColor = Color.White;
            }
            num = Convert.ToInt32(str.Substring(0x10, 4), 0x10);
            num2 = num & 0x8000;
            this.txt_36.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_36.BackColor = Color.Red;
            }
            else
            {
                this.txt_36.BackColor = Color.White;
            }
            num2 = num & 0x4000;
            this.txt_37.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_37.BackColor = Color.Red;
            }
            else
            {
                this.txt_37.BackColor = Color.White;
            }
            num2 = num & 0x2000;
            this.txt_38.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_38.BackColor = Color.Red;
            }
            else
            {
                this.txt_38.BackColor = Color.White;
            }
            num2 = num & 0x1000;
            this.txt_39.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_39.BackColor = Color.Red;
            }
            else
            {
                this.txt_39.BackColor = Color.White;
            }
            num2 = num & 0x800;
            this.txt_40.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_40.BackColor = Color.Red;
            }
            else
            {
                this.txt_40.BackColor = Color.White;
            }
            num2 = num & 0x400;
            this.txt_41.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_41.BackColor = Color.Red;
            }
            else
            {
                this.txt_41.BackColor = Color.White;
            }
            num2 = num & 0x200;
            this.txt_42.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_42.BackColor = Color.Red;
            }
            else
            {
                this.txt_42.BackColor = Color.White;
            }
            num2 = num & 0x100;
            this.txt_43.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_43.BackColor = Color.Red;
            }
            else
            {
                this.txt_43.BackColor = Color.White;
            }
            num2 = num & 0x80;
            this.txt_44.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_44.BackColor = Color.Red;
            }
            else
            {
                this.txt_44.BackColor = Color.White;
            }
            num = Convert.ToInt32(str.Substring(20, 4), 0x10);
            num2 = num & 0x8000;
            this.txt_45.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_45.BackColor = Color.Red;
            }
            else
            {
                this.txt_45.BackColor = Color.White;
            }
            num2 = num & 0x4000;
            this.txt_46.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_46.BackColor = Color.Red;
            }
            else
            {
                this.txt_46.BackColor = Color.White;
            }
            num2 = num & 0x2000;
            this.txt_47.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_47.BackColor = Color.Red;
            }
            else
            {
                this.txt_47.BackColor = Color.White;
            }
            num2 = num & 0x1000;
            this.txt_48.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_48.BackColor = Color.Red;
            }
            else
            {
                this.txt_48.BackColor = Color.White;
            }
            num2 = num & 0x800;
            this.txt_49.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_49.BackColor = Color.Red;
            }
            else
            {
                this.txt_49.BackColor = Color.White;
            }
            num2 = num & 0x400;
            this.txt_50.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_50.BackColor = Color.Red;
            }
            else
            {
                this.txt_50.BackColor = Color.White;
            }
            num2 = num & 0x200;
            this.txt_51.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_51.BackColor = Color.Red;
            }
            else
            {
                this.txt_51.BackColor = Color.White;
            }
            num2 = num & 0x100;
            this.txt_52.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_52.BackColor = Color.Red;
            }
            else
            {
                this.txt_52.BackColor = Color.White;
            }
            num2 = num & 0x80;
            this.txt_53.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_53.BackColor = Color.Red;
            }
            else
            {
                this.txt_53.BackColor = Color.White;
            }
            num = Convert.ToInt32(str.Substring(0x18, 4), 0x10);
            num2 = num & 0x8000;
            this.txt_54.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_54.BackColor = Color.Red;
            }
            else
            {
                this.txt_54.BackColor = Color.White;
            }
            num2 = num & 0x4000;
            this.txt_55.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_55.BackColor = Color.Red;
            }
            else
            {
                this.txt_55.BackColor = Color.White;
            }
            num2 = num & 0x2000;
            this.txt_56.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_56.BackColor = Color.Red;
            }
            else
            {
                this.txt_56.BackColor = Color.White;
            }
            num2 = num & 0x1000;
            this.txt_57.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_57.BackColor = Color.Red;
            }
            else
            {
                this.txt_57.BackColor = Color.White;
            }
            num2 = num & 0x800;
            this.txt_58.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_58.BackColor = Color.Red;
            }
            else
            {
                this.txt_58.BackColor = Color.White;
            }
            num2 = num & 0x400;
            this.txt_59.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_59.BackColor = Color.Red;
            }
            else
            {
                this.txt_59.BackColor = Color.White;
            }
            num2 = num & 0x200;
            this.txt_60.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_60.BackColor = Color.Red;
            }
            else
            {
                this.txt_60.BackColor = Color.White;
            }
            num2 = num & 0x100;
            this.txt_61.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_61.BackColor = Color.Red;
            }
            else
            {
                this.txt_61.BackColor = Color.White;
            }
            num2 = num & 0x80;
            this.txt_62.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_62.BackColor = Color.Red;
            }
            else
            {
                this.txt_62.BackColor = Color.White;
            }
            num2 = num & 0x40;
            this.txt_63.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_63.BackColor = Color.Red;
            }
            else
            {
                this.txt_63.BackColor = Color.White;
            }
            num2 = num & 0x20;
            this.txt_64.Text = (num2 == 0) ? "未出现" : "出现";
            if (num2 != 0)
            {
                this.txt_64.BackColor = Color.Red;
            }
            else
            {
                this.txt_64.BackColor = Color.White;
            }
        }

        private void btn_Read_Page2_Click(object sender, EventArgs e)
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
                    string data = "20150200";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    parseData = "";
                    list.Clear();
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.GetRequestNormal(data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = "跟随上报状态字-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        int num = -1;
                        int num2 = -1;
                        num = Convert.ToInt32(parseData, 0x10);
                        num2 = num & 0x40000000;
                        this.txt_65.Text = (num2 == 0) ? "未发生" : "发生";
                        if (num2 != 0)
                        {
                            this.txt_65.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_65.BackColor = Color.White;
                        }
                        num2 = num & 0x10000000;
                        this.txt_66.Text = (num2 == 0) ? "未发生" : "发生";
                        if (num2 != 0)
                        {
                            this.txt_66.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_66.BackColor = Color.White;
                        }
                        num2 = num & 0x4000000;
                        this.txt_67.Text = (num2 == 0) ? "未发生" : "发生";
                        if (num2 != 0)
                        {
                            this.txt_67.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_67.BackColor = Color.White;
                        }
                        num2 = num & 0x800000;
                        this.txt_68.Text = (num2 == 0) ? "未发生" : "发生";
                        if (num2 != 0)
                        {
                            this.txt_68.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_68.BackColor = Color.White;
                        }
                        num2 = num & 0x400000;
                        this.txt_69.Text = (num2 == 0) ? "未发生" : "发生";
                        if (num2 != 0)
                        {
                            this.txt_69.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_69.BackColor = Color.White;
                        }
                        num2 = num & 0x20000;
                        this.txt_70.Text = (num2 == 0) ? "未发生" : "发生";
                        if (num2 != 0)
                        {
                            this.txt_70.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_70.BackColor = Color.White;
                        }
                        num2 = num & 0x10000;
                        this.txt_71.Text = (num2 == 0) ? "未发生" : "发生";
                        if (num2 != 0)
                        {
                            this.txt_71.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_71.BackColor = Color.White;
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

        private void btn_Read_Page3_Click(object sender, EventArgs e)
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
                    int[] numArray = new int[] { 0x40000000, 0x10000000, 0x4000000, 0x800000, 0x400000, 0x20000, 0x10000 };
                    string str5 = "20157F00";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    int num = 0;
                    cData = "";
                    string data = "";
                    byte dataType = 4;
                    byte dataLen = 0x20;
                    for (int i = 0; i < 7; i++)
                    {
                        if (this.txtArray[i].Text == "清零")
                        {
                            num |= numArray[i];
                        }
                    }
                    data = num.ToString("X").PadLeft(8, '0');
                    cData = Protocol.From_Type_GetData(dataType, dataLen, ref data);
                    parseData = "";
                    list.Clear();
                    linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), str5 + cData, PublicVariable.TimeTag);
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
                    PublicVariable.Info = "跟随上报状态字-" + (flag ? "复位成功" : "复位失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
        private void ChangeState(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = (box.Text == "清零") ? "不清零" : "清零";
        }
        private void InitArray()
        {
            this.txtCount[0] = this.txt_0;
            this.txtCount[1] = this.txt_1;
            this.txtCount[2] = this.txt_2;
            this.txtCount[3] = this.txt_3;
            this.txtCount[4] = this.txt_4;
            this.txtCount[5] = this.txt_5;
            this.txtCount[6] = this.txt_6;
            this.txtCount[7] = this.txt_7;
            this.txtCount[8] = this.txt_8;
            this.txtCount[9] = this.txt_9;
            this.txtCount[10] = this.txt_10;
            this.txtCount[11] = this.txt_11;
            this.txtCount[12] = this.txt_12;
            this.txtCount[13] = this.txt_13;
            this.txtCount[14] = this.txt_14;
            this.txtCount[15] = this.txt_15;
            this.txtCount[0x10] = this.txt_16;
            this.txtCount[0x11] = this.txt_17;
            this.txtCount[0x12] = this.txt_18;
            this.txtCount[0x13] = this.txt_19;
            this.txtCount[20] = this.txt_20;
            this.txtCount[0x15] = this.txt_21;
            this.txtCount[0x16] = this.txt_22;
            this.txtCount[0x17] = this.txt_23;
            this.txtCount[0x18] = this.txt_24;
            this.txtCount[0x19] = this.txt_25;
            this.txtCount[0x1a] = this.txt_26;
            this.txtCount[0x1b] = this.txt_27;
            this.txtCount[0x1c] = this.txt_28;
            this.txtCount[0x1d] = this.txt_29;
            this.txtCount[30] = this.txt_30;
            this.txtCount[0x1f] = this.txt_31;
            this.txtCount[0x20] = this.txt_32;
            this.txtCount[0x21] = this.txt_33;
            this.txtCount[0x22] = this.txt_34;
            this.txtCount[0x23] = this.txt_35;
            this.txtCount[0x24] = this.txt_36;
            this.txtCount[0x25] = this.txt_37;
            this.txtCount[0x26] = this.txt_38;
            this.txtCount[0x27] = this.txt_39;
            this.txtCount[40] = this.txt_40;
            this.txtCount[0x29] = this.txt_41;
            this.txtCount[0x2a] = this.txt_42;
            this.txtCount[0x2b] = this.txt_43;
            this.txtCount[0x2c] = this.txt_44;
            this.txtCount[0x2d] = this.txt_45;
            this.txtCount[0x2e] = this.txt_46;
            this.txtCount[0x2f] = this.txt_47;
            this.txtCount[0x30] = this.txt_48;
            this.txtCount[0x31] = this.txt_49;
            this.txtCount[50] = this.txt_50;
            this.txtCount[0x33] = this.txt_51;
            this.txtCount[0x34] = this.txt_52;
            this.txtCount[0x35] = this.txt_53;
            this.txtCount[0x36] = this.txt_54;
            this.txtCount[0x37] = this.txt_55;
            this.txtCount[0x38] = this.txt_56;
            this.txtCount[0x39] = this.txt_57;
            this.txtCount[0x3a] = this.txt_58;
            this.txtCount[0x3b] = this.txt_59;
            this.txtCount[60] = this.txt_60;
            this.txtCount[0x3d] = this.txt_61;
            this.txtCount[0x3e] = this.txt_62;
            this.txtCount[0x3f] = this.txt_63;
            this.txtCount[0x40] = this.txt_64;
            this.txtArray[0] = this.tx_0;
            this.txtArray[1] = this.tx_1;
            this.txtArray[2] = this.tx_2;
            this.txtArray[3] = this.tx_3;
            this.txtArray[4] = this.tx_4;
            this.txtArray[5] = this.tx_5;
            this.txtArray[6] = this.tx_6;
            for (int i = 0; i < this.txtArray.Length; i++)
            {
                this.txtArray[i].Click += new EventHandler(this.ChangeState);
                this.txtArray[i].Text = "清零";
                this.txtArray[i].Enabled = true;
            }
        }

        private void btb_Exit4_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
