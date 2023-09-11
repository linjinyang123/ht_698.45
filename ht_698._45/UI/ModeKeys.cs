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
    public partial class ModeKeys : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private TextBox[] txtArray = new TextBox[7];
        private CheckBox[] chkArray = new CheckBox[3];
        public ModeKeys(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void btn_Read_Page1_Click(object sender, EventArgs e)
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
                    string data = "20150400";
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
                    PublicVariable.Info = "跟随上报模式字-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        int num = -1;
                        int num2 = -1;
                        num = Convert.ToInt32(parseData, 0x10);
                        num2 = num & 0x40000000;
                        this.txt_0.Text = (num2 == 0) ? "不上报" : "上报";
                        if (num2 != 0)
                        {
                            this.txt_0.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_0.BackColor = Color.White;
                        }
                        num2 = num & 0x10000000;
                        this.txt_1.Text = (num2 == 0) ? "不上报" : "上报";
                        if (num2 != 0)
                        {
                            this.txt_1.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_1.BackColor = Color.White;
                        }
                        num2 = num & 0x4000000;
                        this.txt_2.Text = (num2 == 0) ? "不上报" : "上报";
                        if (num2 != 0)
                        {
                            this.txt_2.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_2.BackColor = Color.White;
                        }
                        num2 = num & 0x800000;
                        this.txt_3.Text = (num2 == 0) ? "不上报" : "上报";
                        if (num2 != 0)
                        {
                            this.txt_3.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_3.BackColor = Color.White;
                        }
                        num2 = num & 0x400000;
                        this.txt_4.Text = (num2 == 0) ? "不上报" : "上报";
                        if (num2 != 0)
                        {
                            this.txt_4.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_4.BackColor = Color.White;
                        }
                        num2 = num & 0x20000;
                        this.txt_5.Text = (num2 == 0) ? "不上报" : "上报";
                        if (num2 != 0)
                        {
                            this.txt_5.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_5.BackColor = Color.White;
                        }
                        num2 = num & 0x10000;
                        this.txt_6.Text = (num2 == 0) ? "不上报" : "上报";
                        if (num2 != 0)
                        {
                            this.txt_6.BackColor = Color.Red;
                        }
                        else
                        {
                            this.txt_6.BackColor = Color.White;
                        }
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
                    string[] strArray = new string[] { "41120200", "41130200", "41140200" };
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        cData = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray[i] != null) && this.chkArray[i].Checked) && this.chkArray[i].Visible)
                        {
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
                            PublicVariable.Info = this.chkArray[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (flag)
                            {
                                if (i == 0)
                                {
                                    switch (parseData)
                                    {
                                        case "80":
                                            this.cbx_Yg.SelectedIndex = 0;
                                            break;

                                        case "20":
                                            this.cbx_Yg.SelectedIndex = 1;
                                            break;

                                        case "A0":
                                            this.cbx_Yg.SelectedIndex = 2;
                                            break;

                                        case "90":
                                            this.cbx_Yg.SelectedIndex = 3;
                                            break;

                                        case "60":
                                            this.cbx_Yg.SelectedIndex = 4;
                                            break;

                                        case "50":
                                            this.cbx_Yg.SelectedIndex = 5;
                                            break;
                                    }
                                }
                                if (i == 1)
                                {
                                    this.txt_Wg1.Text = parseData;
                                }
                                if (i == 2)
                                {
                                    this.txt_Wg2.Text = parseData;
                                }
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

        private void btn_Write_Page1_Click(object sender, EventArgs e)
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
                    string str5 = "20150400";
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
                        if (this.txtArray[i].Text == "上报")
                        {
                            num |= numArray[i];
                        }
                    }
                    data = num.ToString("X").PadLeft(8, '0');
                    cData = Protocol.From_Type_GetData(dataType, dataLen, ref data);
                    parseData = "";
                    list.Clear();
                    linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_R.ToString("X2"), str5 + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.ActionRequest("06", "43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = "跟随上报模式字-" + (flag ? "设置成功" : "设置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
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

        private void btn_Write_Page2_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string data = "";
                    List<string> list = new List<string>();
                    string[] strArray = new string[] { "41120200", "41130200", "41140200" };
                    string str3 = "";
                    string str4 = "";
                    string parseData = "";
                    List<string> list2 = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    byte dataType = 4;
                    byte dataLen = 8;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (((this.chkArray[i] == null) || !this.chkArray[i].Visible) || !this.chkArray[i].Checked)
                        {
                            continue;
                        }
                        data = "";
                        switch (i)
                        {
                            case 0:
                                switch (this.cbx_Yg.SelectedIndex)
                                {
                                    case 0:
                                        data = "80";
                                        goto Label_0160;

                                    case 1:
                                        data = "20";
                                        goto Label_0160;

                                    case 2:
                                        data = "A0";
                                        goto Label_0160;

                                    case 3:
                                        data = "90";
                                        goto Label_0160;

                                    case 4:
                                        data = "60";
                                        goto Label_0160;

                                    case 5:
                                        data = "50";
                                        goto Label_0160;
                                }
                                break;

                            case 1:
                                data = this.txt_Wg1.Text.PadLeft(2, '0');
                                break;

                            case 2:
                                data = this.txt_Wg2.Text.PadLeft(2, '0');
                                break;
                        }
                    Label_0160:
                        cData = "";
                        list.Clear();
                        cData = Protocol.From_Type_GetData(dataType, dataLen, ref data);
                        linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + cData, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], cData, PublicVariable.TimeTag, ref splitFlag);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = this.chkArray[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (!flag)
                        {
                            PublicVariable.IsReading = false;
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

        private void btn_多功能端子_read_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    string str8;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string data = "F2070200";
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
                    PublicVariable.Info = "多功能端子状态-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag && ((str8 = parseData) != null))
                    {
                        if (str8 != "00")
                        {
                            if (str8 == "01")
                            {
                                goto Label_01F1;
                            }
                            if (str8 == "02")
                            {
                                goto Label_0203;
                            }
                        }
                        else
                        {
                            this.txt_多功能端子.Text = "秒脉冲 00";
                        }
                    }
                    return;
                Label_01F1:
                    this.txt_多功能端子.Text = "需量周期 01";
                    return;
                Label_0203:
                    this.txt_多功能端子.Text = "时段投切 02";
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

        private void btn_多功能端子_write_Click(object sender, EventArgs e)
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
                    string str5 = "F2077F00";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    string data = "";
                    string dataType = "028122";
                    string dataLen = "020401";
                    frameData.Clear();
                    data = "F2070201" + this.cbx_多功能端子.SelectedIndex.ToString("X2");
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
                    PublicVariable.Info = "多功能端子输出-" + (flag ? "配置成功" : "配置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void btn_继电器_read_Click(object sender, EventArgs e)
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
                    string data = "F2050200";
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
                    PublicVariable.Info = "继电器输出状态-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        this.txt_继电器_3.Text = (parseData.Substring(parseData.Length - 2, 2) == "00") ? "接入(00)" : "未接入(01)";
                        this.txt_继电器_2.Text = (parseData.Substring(parseData.Length - 4, 2) == "00") ? "脉冲式(00)" : "保持式(01)";
                        this.txt_继电器_1.Text = (parseData.Substring(parseData.Length - 6, 2) == "00") ? "合闸(00)" : "跳闸(01)";
                        this.txt_继电器_0.Text = parseData.Substring(0, parseData.Length - 6);
                        this.textEdit1.Text = parseData.Substring(0, parseData.Length - 6);
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

        private void btn_继电器_write_Click(object sender, EventArgs e)
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
                    string str5 = "F2057F00";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    string data = "";
                    string dataType = "028122";
                    string dataLen = "020401";
                    frameData.Clear();
                    data = "F2050201" + this.cbx_继电器属性.SelectedIndex.ToString("X2");
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
                    PublicVariable.Info = "继电器属性-" + (flag ? "配置成功" : "配置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Wg_ModeForm form = new Wg_ModeForm(0, this.txt_Wg1.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.txt_Wg1.Text = form.Tag.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wg_ModeForm form = new Wg_ModeForm(1, this.txt_Wg2.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.txt_Wg2.Text = form.Tag.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                    string data = "20150500";
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
                    PublicVariable.Info = "跟随上报模式字上报方式-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        switch (parseData)
                        {
                            case "00":
                                this.rd_主动.Checked = true;
                                this.rd_主动.BackColor = Color.Aquamarine;
                                this.rd_跟随.BackColor = Color.Transparent;
                                break;

                            case "01":
                                this.rd_跟随.Checked = true;
                                this.rd_跟随.BackColor = Color.Aquamarine;
                                this.rd_主动.BackColor = Color.Transparent;
                                break;
                        }
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

        private void button4_Click(object sender, EventArgs e)
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
                    string str5 = "20150500";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    cData = "";
                    string data = "";
                    byte dataType = 0x16;
                    byte dataLen = 1;
                    if (this.rd_主动.Checked)
                    {
                        data = "00";
                    }
                    else if (this.rd_跟随.Checked)
                    {
                        data = "01";
                    }
                    cData = Protocol.From_Type_GetData(dataType, dataLen, ref data);
                    parseData = "";
                    list.Clear();
                    linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_R.ToString("X2"), str5 + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.ActionRequest("06", "43", PublicVariable.Address, PublicVariable.Client_Add, str5, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = "跟随上报模式字上报方式-" + (flag ? "设置成功" : "设置失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
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
            box.Text = (box.Text == "上报") ? "不上报" : "上报";
        }
        private void initArray()
        {
            this.chkArray[0] = this.chk_0;
            this.chkArray[1] = this.chk_1;
            this.chkArray[2] = this.chk_2;
            this.txtArray[0] = this.txt_0;
            this.txtArray[1] = this.txt_1;
            this.txtArray[2] = this.txt_2;
            this.txtArray[3] = this.txt_3;
            this.txtArray[4] = this.txt_4;
            this.txtArray[5] = this.txt_5;
            this.txtArray[6] = this.txt_6;
            for (int i = 0; i < this.txtArray.Length; i++)
            {
                this.txtArray[i].Click += new EventHandler(this.ChangeState);
                this.txtArray[i].Text = "上报";
                this.txtArray[i].Enabled = true;
            }
        }

        private void ModeKeys_Load(object sender, EventArgs e)
        {
            this.initArray();
            this.cbx_Yg.SelectedIndex = 0;
            this.cbx_多功能端子.SelectedIndex = 0;
            this.cbx_继电器属性.SelectedIndex = 0;
        }
    }
}
