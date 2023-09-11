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
    public partial class Advanced : Form
    {
        private CheckBox[] chkArray = new CheckBox[3];
        private FollowRepoartAndTimeTag followForm;
        public Advanced(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void Advanced_Load(object sender, EventArgs e)
        {
            this.cbx_Clear.SelectedIndex = 0;
            this.cmb_间隔单位.SelectedIndex = 0;
            this.cbx_端口.SelectedIndex = 0;
            this.cbx_波特率.SelectedIndex = 6;
            this.cbx_效验码.SelectedIndex = 2;
            this.cbx_数据位.SelectedIndex = 3;
            this.cbx_停止位.SelectedIndex = 0;
            this.cbx_流控.SelectedIndex = 0;
            this.cbx_端口功能.SelectedIndex = 0;
            this.InitArray();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btn_Write_Click(object sender, EventArgs e)
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
                    string timeText = "";
                    string address = "";
                    for(int i = 0; i < 3; i++)
                    {
                        if ((!this.chkArray[i].Visible || (this.chkArray[i] == null)) || !this.chkArray[i].Checked)
                        {
                            continue;
                        }
                        if (i == 0)
                        {
                            action = "07";
                            dataType = "28";
                            dataLen = "07";
                            str5 = "40007F00";
                            data = this.dateTimePicker1.Value.ToString("yyyyMMddHHmmss");
                        }
                        else if (i == 1)
                        {
                            action = "06";
                            dataType = "10";
                            dataLen = "04";
                            str5 = "44010200";
                            data = this.txt_NewPassword.Text.PadLeft(8, '0');
                        }
                        else if (i == 2)
                        {
                            action = "07";
                            switch (this.cbx_Clear.SelectedIndex)
                            {
                                case 0:
                                    dataType = "00";
                                    dataLen = "00";
                                    str5 = "43000300";
                                    break;

                                case 1:
                                    dataType = "00";
                                    dataLen = "00";
                                    str5 = "43000400";
                                    break;

                                case 2:
                                    dataType = "00";
                                    dataLen = "00";
                                    str5 = "43000500";
                                    break;

                                case 3:
                                    dataType = "00";
                                    dataLen = "00";
                                    str5 = "43000600";
                                    break;
                            }
                            if (this.rd_无时标.Checked)
                            {
                                data = "";
                            }
                            else
                            {
                                timeText = string.Format("{0:X4}",Convert.ToInt32(this.tb_时间.Text.Substring(0, 4))) + string.Format("{0:X2}",Convert.ToInt16(this.tb_时间.Text.Substring(4, 2))) + string.Format("{0:X2}",Convert.ToInt16(this.tb_时间.Text.Substring(6, 2))) + string.Format("{0:X2}",Convert.ToInt16(this.tb_时间.Text.Substring(8, 2)))+ string.Format("{0:X2}",Convert.ToInt16(this.tb_时间.Text.Substring(10, 2)))+ string.Format("{0:X2}",Convert.ToInt16(this.tb_时间.Text.Substring(12, 2))) + this.cmb_间隔单位.SelectedIndex.ToString("X2") + string.Format("{0:X4}",Convert.ToInt32(this.tbx_间隔.Text.PadLeft(4, '0').Substring(0, 4)));
                                data = "";
                            }
                        }
                        frameData.Clear();
                        cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
                        parseData = "";
                        list.Clear();
                        if ((i == 2) && this.rd_有时标.Checked)
                        {
                            linkdata = Protocol.MakeLink_Data(action, "01", PublicVariable.PIID_R.ToString("X2"), str5 + cData, true, timeText);
                        }
                        else
                        {
                            linkdata = Protocol.MakeLink_Data(action, "01", PublicVariable.PIID_R.ToString("X2"), str5 + cData, PublicVariable.TimeTag);
                        }
                        address = PublicVariable.Address;
                        if ((this.chk_实际地址.Visible && (this.chk_实际地址 != null)) && (!this.chk_实际地址.Checked && this.chk_广播.Checked))
                        {
                            PublicVariable.Address = "C0AA";
                        }
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                if (i != 0)
                                {
                                    break;
                                }
                                flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                                goto Label_0591;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                goto Label_0591;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                goto Label_0591;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                goto Label_0591;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                goto Label_0591;

                            default:
                                goto Label_0591;
                        }
                        if (i == 1)
                        {
                            flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, PublicVariable.TimeTag, ref splitFlag);
                        }
                        else if ((i == 2) && this.rd_有时标.Checked)
                        {
                            flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, timeText, ref splitFlag);
                        }
                        else if ((i == 2) && this.rd_无时标.Checked)
                        {
                            flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                        }
                    Label_0591:
                        PublicVariable.Address = address;
                        if (i == 0)
                        {
                            PublicVariable.Info = this.chkArray[i].Text + "已发送-" + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = "Blue";
                        }
                        else
                        {
                            PublicVariable.Info = this.chkArray[i].Text + (flag ? "设置成功" : "设置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        }
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

        private void btn_波特率_read_Click(object sender, EventArgs e)
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
                    string data = "";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    switch (this.cbx_端口.SelectedIndex)
                    {
                        case 0:
                            data = "F2010201";
                            break;

                        case 1:
                            data = "F2010202";
                            break;

                        case 2:
                            data = "F2090200";
                            break;

                        case 3:
                            data = "F2020200";
                            break;

                        case 4:
                            data = "F20902FD";
                            break;
                    }
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
                    PublicVariable.Info = this.cbx_端口.Text + "波特率-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        if ((this.cbx_端口.SelectedIndex == 0) || (this.cbx_端口.SelectedIndex == 1))
                        {
                            this.cbx_端口功能.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 2, 2));
                            this.cbx_流控.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 4, 2));
                            this.cbx_停止位.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 6, 2)) - 1;
                            this.cbx_数据位.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 8, 2)) - 5;
                            this.cbx_效验码.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 10, 2));
                            this.cbx_波特率.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 12, 2));
                            this.txt_描述符.Text = parseData.Substring(0, parseData.Length - 12);
                        }
                        else if (this.cbx_端口.SelectedIndex == 2)
                        {
                            this.txt_版本信息.Text = "";
                            if (parseData.Length >= 0x20)
                            {
                                this.txt_版本信息.Text = "厂商代码: " + parseData.Substring(parseData.Length - 0x16, 4) + "\r\n芯片代码: " + parseData.Substring(parseData.Length - 0x12, 4) + "\r\n版本日期: " + parseData.Substring(parseData.Length - 14, 10) + "\r\n软件版本: " + parseData.Substring(parseData.Length - 4, 4);
                                parseData = parseData.Substring(0, parseData.Length - 0x16);
                            }
                            this.cbx_流控.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 2, 2));
                            this.cbx_停止位.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 4, 2)) - 1;
                            this.cbx_数据位.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 6, 2)) - 5;
                            this.cbx_效验码.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 8, 2));
                            this.cbx_波特率.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 10, 2));
                            this.txt_描述符.Text = parseData.Substring(0, parseData.Length - 10);
                        }
                        else if (this.cbx_端口.SelectedIndex == 3)
                        {
                            this.label10.Visible = false;
                            this.cbx_端口功能.Visible = false;
                            this.cbx_流控.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 2, 2));
                            this.cbx_停止位.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 4, 2)) - 1;
                            this.cbx_数据位.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 6, 2)) - 5;
                            this.cbx_效验码.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 8, 2));
                            this.cbx_波特率.SelectedIndex = Convert.ToInt16(parseData.Substring(parseData.Length - 10, 2));
                            this.txt_描述符.Text = parseData.Substring(0, parseData.Length - 10);
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

        private void btn_波特率_write_Click(object sender, EventArgs e)
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
                    switch (this.cbx_端口.SelectedIndex)
                    {
                        case 0:
                            dataType = "02819522";
                            dataLen = "03040501";
                            str5 = "F2017F00";
                            break;

                        case 1:
                            dataType = "02819522";
                            dataLen = "03040501";
                            str5 = "F2017F00";
                            break;

                        case 2:
                            dataType = "028195";
                            dataLen = "020405";
                            str5 = "F2098000";
                            break;

                        case 3:
                            dataType = "028195";
                            dataLen = "020405";
                            str5 = "F2027F00";
                            break;

                        case 4:
                            dataType = "028195";
                            dataLen = "020405";
                            str5 = "F20902FD";
                            break;
                    }
                    frameData.Clear();
                    string[] strArray = new string[] { this.txt_端口号.Text.PadLeft(8, '0').Substring(0, 8), this.cbx_波特率.SelectedIndex.ToString("X2"), this.cbx_效验码.SelectedIndex.ToString("X2"), (this.cbx_数据位.SelectedIndex + 5).ToString("X2"), (this.cbx_停止位.SelectedIndex + 1).ToString("X2"), this.cbx_流控.SelectedIndex.ToString("X2") };
                    data = string.Concat(strArray);
                    cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
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
                    PublicVariable.Info = this.cbx_端口.Text + "波特率-" + (flag ? "配置成功" : "配置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void cbx_端口_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbx_端口.SelectedIndex == 0) || (this.cbx_端口.SelectedIndex == 1))
            {
                this.label10.Visible = true;
                this.cbx_端口功能.Visible = true;
                this.label12.Visible = false;
                this.txt_版本信息.Visible = false;
                if (this.cbx_端口.SelectedIndex == 0)
                {
                    this.txt_端口号.Text = "F2010201";
                }
                else
                {
                    this.txt_端口号.Text = "F2010202";
                }
            }
            else if (this.cbx_端口.SelectedIndex == 2)
            {
                this.label10.Visible = false;
                this.cbx_端口功能.Visible = false;
                this.label12.Visible = true;
                this.txt_版本信息.Visible = true;
                this.txt_端口号.Text = "F2090201";
            }
            else if (this.cbx_端口.SelectedIndex == 3)
            {
                this.label10.Visible = false;
                this.cbx_端口功能.Visible = false;
                this.label12.Visible = false;
                this.txt_版本信息.Visible = false;
                this.txt_端口号.Text = "F2020201";
            }
            else if (this.cbx_端口.SelectedIndex == 4)
            {
                this.label10.Visible = false;
                this.cbx_端口功能.Visible = false;
                this.label12.Visible = false;
                this.txt_版本信息.Visible = false;
                this.txt_端口号.Text = "F20902FD";
            }
        }

        private void chb_系统时间_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chb_系统时间.Checked)
            {
                this.timer1.Enabled = true;
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }

        private void checkBoxShiZhongTongbu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxShiZhongTongbu.Checked)
            {
                this.timer1.Enabled = true;
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }
        private void InitArray()
        {
            this.chkArray[0] = this.chk_广播;
            this.chkArray[1] = this.chk_密码;
            this.chkArray[2] = this.chk_清零;
        }

        private void tb_时间_TextChanged(object sender, EventArgs e)
        {
            if (this.chb_系统时间.Checked)
            {
                this.tb_时间.Text = this.tb_时间.Text.PadRight(14, '0');
                PublicVariable.TimeText = Convert.ToInt32(this.tb_时间.Text.Substring(0, 4), 10).ToString("X4") + Convert.ToInt32(this.tb_时间.Text.Substring(4, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(6, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(8, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(10, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(12, 2), 10).ToString("X2") + this.cmb_间隔单位.SelectedIndex.ToString("X2") + Convert.ToInt32(this.tbx_间隔.Text.PadLeft(4, '0'), 10).ToString("X4");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Now;
            this.tb_时间.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
