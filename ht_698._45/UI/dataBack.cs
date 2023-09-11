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
    public partial class dataBack : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private CheckBox[] cbxArray = new CheckBox[9];
        private TextBox[] txtArray = new TextBox[8];
        public dataBack(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            this.dgv_JtValue.Columns[1].DefaultCellStyle.Format = "{0:D2}";
            this.Init();
        }

        private void btn_ESAM读取_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    bool spliteFlag = false;
                    string parseData = "";
                    string linkdata = "";
                    string mAC = "";
                    string str4 = "";
                    string str5 = "";
                    List<string> list = new List<string>();
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    string[] strArray = new string[] { "40020200", "40030200", "401C0200", "401D0200", "401E0200", "400A0200", "400B0200" };
                    string str6 = "F1000300";
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if ((!this.cbxArray[i].Visible || (this.cbxArray[i] == null)) || !this.cbxArray[i].Checked)
                        {
                            continue;
                        }
                        parseData = "";
                        linkdata = "";
                        list.Clear();
                        cOutData.Clear();
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.ESAM_Math_纯明文_Read(str6, strArray[i], ref parseData, ref list, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.ESAM_Math_明文_RN_Read("00", "01", str6, strArray[i], ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.ESAM_Math_明文_SIDMAC_Read("00", "00", str6, strArray[i], ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.ESAM_Math_密文_SID_Read("01", "03", str6, strArray[i], ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.ESAM_Math_密文_SID_MAC_Read("01", "00", str6, strArray[i], ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = this.cbxArray[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            if (cOutData.ToString() != "")
                            {
                                parseData = cOutData.ToString();
                            }
                            switch (i)
                            {
                                case 0:
                                    this.txtArray[i].Text = parseData.Substring(0, 0x10).ToString();
                                    break;

                                case 1:
                                    this.txtArray[i].Text = parseData.Substring(0, 12).ToString();
                                    break;

                                case 2:
                                    this.txtArray[i].Text = parseData.Substring(0, 6).ToString();
                                    break;

                                case 3:
                                    this.txtArray[i].Text = parseData.Substring(0, 6).ToString();
                                    break;

                                case 4:
                                    this.txtArray[4].Text = (((double)Convert.ToInt32(parseData.Substring(0, 8), 10)) / Math.Pow(10.0, 2.0)).ToString();
                                    parseData = parseData.Substring(8);
                                    this.txtArray[5].Text = (((double)Convert.ToInt32(parseData.Substring(0, 8), 10)) / Math.Pow(10.0, 2.0)).ToString();
                                    break;

                                case 5:
                                    this.txtArray[6].Text = parseData.Substring(0, 10).ToString();
                                    break;

                                case 6:
                                    this.txtArray[7].Text = parseData.Substring(0, 10).ToString();
                                    break;
                            }
                        }
                    }
                    string str7 = "";
                    string text = "";
                    if (((this.cbx_Jtdj != null) && this.cbx_Jtdj.Visible) && this.cbx_Jtdj.Checked)
                    {
                        if (this.rad_dq.Checked)
                        {
                            str7 = "401A0200";
                            text = this.rad_dq.Text;
                        }
                        else
                        {
                            str7 = "401B0200";
                            text = this.rad_by.Text;
                        }
                        parseData = "";
                        linkdata = "";
                        list.Clear();
                        cOutData.Clear();
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.ESAM_Math_纯明文_Read(str6, str7, ref parseData, ref list, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.ESAM_Math_明文_RN_Read("00", "01", str6, str7, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.ESAM_Math_明文_SIDMAC_Read("00", "00", str6, str7, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.ESAM_Math_密文_SID_Read("01", "03", str6, str7, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.ESAM_Math_密文_SID_MAC_Read("01", "00", str6, str7, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = text + this.cbx_Jtdj.Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                this.dgv_JtValue.Rows[j].Cells[1].Value = (Convert.ToDouble(parseData.Substring(0, 8)) / Math.Pow(10.0, 2.0)).ToString("0.00");
                                parseData = parseData.Substring(8);
                            }
                            for (int k = 6; k < 13; k++)
                            {
                                this.dgv_JtValue.Rows[k].Cells[1].Value = (Convert.ToDouble(parseData.Substring(0, 8)) / Math.Pow(10.0, 4.0)).ToString("F4");
                                parseData = parseData.Substring(8);
                            }
                            for (int m = 13; m < 0x11; m++)
                            {
                                this.dgv_JtValue.Rows[m].Cells[1].Value = parseData.Substring(0, 6);
                                parseData = parseData.Substring(6);
                            }
                        }
                    }
                    string str9 = "";
                    text = "";
                    if (((this.cbx_FLdj != null) && this.cbx_FLdj.Visible) && this.cbx_FLdj.Checked)
                    {
                        if (this.rad_dq.Checked)
                        {
                            str9 = "40180200";
                            text = this.rad_dq.Text;
                        }
                        else
                        {
                            str9 = "40190200";
                            text = this.rad_by.Text;
                        }
                        parseData = "";
                        linkdata = "";
                        list.Clear();
                        cOutData.Clear();
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.ESAM_Math_纯明文_Read(str6, str9, ref parseData, ref list, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.ESAM_Math_明文_RN_Read("00", "01", str6, str9, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.ESAM_Math_明文_SIDMAC_Read("00", "00", str6, str9, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.ESAM_Math_密文_SID_Read("01", "03", str6, str9, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.ESAM_Math_密文_SID_MAC_Read("01", "00", str6, str9, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = text + this.cbx_FLdj.Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag && (parseData.Length == 0x108))
                        {
                            for (int j = 0; j < 0x20; j++)
                            {
                                this.dgv_FlValue.Rows[j].Cells[1].Value = (Convert.ToDouble(parseData.Substring(0, 8)) / Math.Pow(10.0, 4.0)).ToString("0.0000");
                                parseData = parseData.Substring(8);
                            }
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

        private void btn_ESAM更新_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    bool flag = false;
                    string cData = "";
                    bool spliteFlag = false;
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string[] strArray = new string[] { "40020200", "40030200", "401C0200", "401D0200", "401E0200", "400A0200", "400B0200", "401A0200", "40180200" };
                    string str5 = "F1000400";
                    byte[] buffer = new byte[] { 8, 6, 3, 3, 4, 5, 5, 0x40, 0x80 };
                    string mAC = "";
                    string text = "";
                    int length = 0;
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string str8;
                        int num3;
                        string str9;
                        int num6;
                        text = "";
                        cData = "";
                        parseData = "";
                        list.Clear();
                        if (((this.cbxArray[i] == null) || !this.cbxArray[i].Checked) || !this.cbxArray[i].Visible)
                        {
                            continue;
                        }
                        switch (i)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                                length = this.txtArray[i].Text.PadLeft(buffer[i] * 2, '0').Length;
                                cData = strArray[i] + buffer[i].ToString("X2") + this.txtArray[i].Text.PadLeft(buffer[i] * 2, '0').Substring(length - (buffer[i] * 2), buffer[i] * 2);
                                goto Label_0613;

                            case 4:
                                cData = strArray[i] + ((buffer[i] * 2)).ToString("X2") + Convert.ToInt32((float)(float.Parse(this.txtArray[4].Text) * 100f)).ToString().PadLeft(8, '0') + Convert.ToInt32((float)(float.Parse(this.txtArray[5].Text) * 100f)).ToString().PadLeft(8, '0');
                                goto Label_0613;

                            case 5:
                            case 6:
                                cData = strArray[i] + buffer[i].ToString("X2") + this.txtArray[i + 1].Text.PadLeft(buffer[i] * 2, '0');
                                goto Label_0613;

                            case 7:
                                str8 = "";
                                if (!this.rad_dq.Checked)
                                {
                                    break;
                                }
                                strArray[i] = "401A0200";
                                text = this.rad_dq.Text;
                                goto Label_02D4;

                            case 8:
                                str9 = "";
                                if (!this.rad_dq.Checked)
                                {
                                    goto Label_0528;
                                }
                                strArray[i] = "40180200";
                                text = this.rad_dq.Text;
                                goto Label_053F;

                            default:
                                goto Label_0613;
                        }
                        strArray[i] = "401B0200";
                        text = this.rad_by.Text;
                    Label_02D4:
                        num3 = 0;
                        while (num3 < 6)
                        {
                            if (this.dgv_JtValue.Rows[num3].Cells[1].Value == null)
                            {
                                this.dgv_JtValue.Rows[num3].Cells[1].Value = "0.00";
                            }
                            str8 = str8 + Convert.ToInt32((float)(float.Parse(this.dgv_JtValue.Rows[num3].Cells[1].Value.ToString()) * 100f)).ToString().PadLeft(8, '0');
                            num3++;
                        }
                        for (int j = 6; j < 13; j++)
                        {
                            if (this.dgv_JtValue.Rows[j].Cells[1].Value == null)
                            {
                                this.dgv_JtValue.Rows[j].Cells[1].Value = "0.0000";
                            }
                            str8 = str8 + Convert.ToInt32((float)(float.Parse(this.dgv_JtValue.Rows[j].Cells[1].Value.ToString()) * 10000f)).ToString().PadLeft(8, '0');
                        }
                        for (int k = 13; k < 0x11; k++)
                        {
                            if (this.dgv_JtValue.Rows[k].Cells[1].Value == null)
                            {
                                this.dgv_JtValue.Rows[k].Cells[1].Value = "FFFFFF";
                            }
                            str8 = str8 + this.dgv_JtValue.Rows[k].Cells[1].Value.ToString().PadLeft(6, '0');
                        }
                        cData = strArray[i] + buffer[i].ToString("X2") + str8;
                        goto Label_0613;
                    Label_0528:
                        strArray[i] = "40190200";
                        text = this.rad_by.Text;
                    Label_053F:
                        num6 = 0;
                        while (num6 < 0x20)
                        {
                            if (this.dgv_FlValue.Rows[num6].Cells[1].Value == null)
                            {
                                this.dgv_FlValue.Rows[num6].Cells[1].Value = "0.0000";
                            }
                            str9 = str9 + Convert.ToInt32((float)(float.Parse(this.dgv_FlValue.Rows[num6].Cells[1].Value.ToString()) * 10000f)).ToString().PadLeft(8, '0');
                            num6++;
                        }
                        cData = strArray[i] + buffer[i].ToString("X2") + str9;
                    Label_0613:
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.ESAM_Math_纯明文_Write(str5, cData, ref parseData, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.ESAM_Math_明文_RN_Write("00", "01", str5, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.ESAM_Math_明文_SIDMAC_Write("00", "00", str5, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.ESAM_Math_密文_SID_Write("01", "03", str5, ref cData, ref parseData, ref list, ref mAC, ref str2, ref str3, ref spliteFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.ESAM_Math_密文_SID_MAC_Write("01", "00", str5, ref cData, ref parseData, ref list, ref mAC, ref str2, ref str3, ref spliteFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = text + this.cbxArray[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void btn_参数读取_Click(object sender, EventArgs e)
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
                    string[] strArray = new string[] { "40020200", "40030200", "401C0200", "401D0200", "401E0200", "400A0200", "400B0200", "401A0200", "40180200" };
                    string linkdata = "";
                    string mAC = "";
                    string text = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        int num2;
                        int num5;
                        int num6;
                        double num11;
                        cData = "";
                        parseData = "";
                        list.Clear();
                        if (((this.cbxArray[i] == null) || !this.cbxArray[i].Checked) || !this.cbxArray[i].Visible)
                        {
                            continue;
                        }
                        text = "";
                        switch (i)
                        {
                            case 7:
                                if (this.rad_dq.Checked)
                                {
                                    strArray[7] = "401A0200";
                                    text = this.rad_dq.Text;
                                }
                                else
                                {
                                    strArray[7] = "401B0200";
                                    text = this.rad_by.Text;
                                }
                                break;

                            case 8:
                                if (this.rad_dq.Checked)
                                {
                                    strArray[8] = "40180200";
                                    text = this.rad_dq.Text;
                                }
                                else
                                {
                                    strArray[8] = "40190200";
                                    text = this.rad_by.Text;
                                }
                                break;
                        }
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
                        PublicVariable.Info = text + this.cbxArray[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            switch (i)
                            {
                                case 0:
                                case 1:
                                case 2:
                                case 3:
                                    this.txtArray[i].Text = parseData;
                                    break;

                                case 4:
                                    this.txtArray[4].Text = (((double)Convert.ToInt32(parseData.Substring(0, 8), 10)) / Math.Pow(10.0, 2.0)).ToString();
                                    parseData = parseData.Substring(8);
                                    this.txtArray[5].Text = (((double)Convert.ToInt32(parseData.Substring(0, 8), 10)) / Math.Pow(10.0, 2.0)).ToString();
                                    break;

                                case 5:
                                    this.txtArray[6].Text = parseData.ToString();
                                    break;

                                case 6:
                                    this.txtArray[7].Text = parseData.ToString();
                                    break;

                                case 7:
                                    num2 = 0;
                                    goto Label_0474;

                                case 8:
                                    num5 = parseData.Length / 8;
                                    num6 = 0;
                                    goto Label_0573;
                            }
                        }
                        goto Label_05EA;
                    Label_040E:
                        num11 = Convert.ToDouble(parseData.Substring(0, 8)) / Math.Pow(10.0, 2.0);
                        this.dgv_JtValue.Rows[num2].Cells[1].Value = num11.ToString("0.00");
                        parseData = parseData.Substring(8);
                        num2++;
                    Label_0474:
                        if (num2 < 6)
                        {
                            goto Label_040E;
                        }
                        for (int j = 6; j < 13; j++)
                        {
                            this.dgv_JtValue.Rows[j].Cells[1].Value = (Convert.ToDouble(parseData.Substring(0, 8)) / Math.Pow(10.0, 4.0)).ToString("F4");
                            parseData = parseData.Substring(8);
                        }
                        for (int k = 13; k < 0x11; k++)
                        {
                            this.dgv_JtValue.Rows[k].Cells[1].Value = parseData.Substring(0, 6);
                            parseData = parseData.Substring(6);
                        }
                        goto Label_05EA;
                    Label_0546:
                        this.dgv_FlValue.Rows[num6].Cells[1].Value = "";
                        num6++;
                    Label_0573:
                        if (num6 < 0x20)
                        {
                            goto Label_0546;
                        }
                        for (int m = 0; m < num5; m++)
                        {
                            this.dgv_FlValue.Rows[m].Cells[1].Value = (Convert.ToDouble(parseData.Substring(0, 8)) / Math.Pow(10.0, 4.0)).ToString("0.0000");
                            parseData = parseData.Substring(8);
                        }
                    Label_05EA:
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

        private void btn_户号表号_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string parseData = "";
                    string str4 = "";
                    List<string> list = new List<string>();
                    List<string> list2 = new List<string>();
                    byte sEQOfOAD = 2;
                    string data = "4003020040020200";
                    cData = "";
                    parseData = "";
                    list2.Clear();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    linkdata = Protocol.MakeLink_Data("05", "02", PublicVariable.PIID_R.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.GetRequestNormalList(sEQOfOAD, data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                            if (flag)
                            {
                                flag = Protocol.GetResponseNormalList(cData, ref str2, ref list, ref list2);
                            }
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str2, ref str4, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str2, ref str4, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.btn_户号表号.Text + (flag ? "成功" : "失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        this.txt_户号.Text = list2[0];
                        this.txt_表号.Text = list2[1];
                        PublicVariable.Meter_NO = this.txt_表号.Text.PadLeft(0x10, '0');
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

        private void btn_密钥版本_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                bool flag = false;
                string cData = "";
                bool splitFlag = false;
                string str2 = "";
                string str3 = "";
                string parseData = "";
                flag = Protocol.GetRequestNormal("F1000400", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                if (flag)
                {
                    flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                    this.txt_密钥版本.Text = parseData;
                }
                PublicVariable.Info = this.btn_密钥版本.Text + (flag ? " 读取成功" : " 读取失败--") + PublicVariable.DARInfo;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                PublicVariable.IsReading = false;
            }
        }

        private void btn_密钥更新_Click(object sender, EventArgs e)
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
                    string mAC = "";
                    string str6 = "";
                    int num = -1;
                    StringBuilder cOutData = new StringBuilder(200);
                    string str7 = "F1000700";
                    if (Protocol.GetRequestNormal("40020200", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag) && Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData))
                    {
                        PublicVariable.Meter_NO = parseData.PadLeft(0x10, '0');
                        if (this.rdb_私钥.Checked)
                        {
                            num = 1;
                            str6 = "私钥";
                        }
                        else
                        {
                            num = 0;
                            str6 = "公钥";
                        }
                        flag = Protocol.ESAM_Math_密钥更新_SID_MAC("01", "00", str7, num, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                        PublicVariable.Info = this.btn_密钥更新.Text + "->" + str6 + (flag ? " 成功" : " 失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
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

        private void btn_钱包初始化_Click(object sender, EventArgs e)
        {
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    bool flag = false;
                    bool spliteFlag = false;
                    string str = "";
                    string str2 = "";
                    string parseData = "";
                    string mAC = "";
                    string str5 = "F1000A00";
                    int taskType = 9;
                    List<string> list = new List<string>();
                    StringBuilder cOutData = new StringBuilder(200);
                    string cData = Convert.ToInt32((float)(float.Parse(this.txt_预置金额.Text) * 100f)).ToString("X").PadLeft(8, '0');
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.Math_纯明文_钱包初始化(str5, taskType, cData, ref parseData, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN_钱包初始化("00", "01", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC_钱包初始化("00", "00", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID_钱包初始化("01", "03", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref str, ref str2, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC_钱包初始化("01", "00", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref str, ref str2, ref spliteFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.btn_钱包初始化.Text + (flag ? "成功" : "失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void btn_钱包读取_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                string cData = "";
                bool splitFlag = false;
                string str2 = "";
                string str3 = "";
                string parseData = "";
                List<string> list = new List<string>();
                string data = "202C0200";
                string linkdata = "";
                string mAC = "";
                StringBuilder cOutData = new StringBuilder(200);
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
                PublicVariable.Info = "钱包文件" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (flag)
                {
                    this.txt_购电金额.Text = (((double)Convert.ToInt32(parseData.Substring(0, 8), 10)) / Math.Pow(10.0, 2.0)).ToString("F2");
                    parseData = parseData.Substring(8);
                    this.txt_购电次数.Text = parseData;
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

        private void btn_执行购电_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    bool spliteFlag = false;
                    string str = "";
                    string str2 = "";
                    string parseData = "";
                    string mAC = "";
                    string str5 = "F1000600";
                    int taskType = -1;
                    List<string> list = new List<string>();
                    StringBuilder cOutData = new StringBuilder(200);
                    if (this.cbx_操作类型.SelectedIndex == 0)
                    {
                        parseData = "00";
                        taskType = 10;
                    }
                    else if (this.cbx_操作类型.SelectedIndex == 1)
                    {
                        parseData = "01";
                        taskType = 10;
                    }
                    else if (this.cbx_操作类型.SelectedIndex == 2)
                    {
                        parseData = "02";
                        taskType = 11;
                    }
                    string cData = Convert.ToInt32((float)(float.Parse(this.txt_金额.Text) * 100f)).ToString("X").PadLeft(8, '0') + this.txt_次数.Text.PadLeft(8, '0') + this.txt_户号.Text.PadLeft(12, '0');
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.Math_纯明文_钱包初始化(str5, taskType, cData, ref parseData, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN_钱包初始化("00", "01", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC_钱包初始化("00", "00", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID_钱包初始化("01", "03", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref str, ref str2, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC_钱包初始化("01", "00", str5, taskType, ref cData, ref parseData, ref list, ref mAC, ref str, ref str2, ref spliteFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.cbx_操作类型.Text + (flag ? "成功" : "失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
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

        private void dataBack_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbx_操作类型.SelectedIndex = 0;
                for (int i = 0; i < 6; i++)
                {
                    this.dgv_JtValue.Rows.Add(1);
                    this.dgv_JtValue.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    this.dgv_JtValue.Rows[i].Cells[0].Value = "阶梯值" + ((i + 1)).ToString();
                    this.dgv_JtValue.Rows[i].Cells[1].Value = "";
                }
                for (int j = 6; j < 13; j++)
                {
                    this.dgv_JtValue.Rows.Add(1);
                    this.dgv_JtValue.Rows[j].HeaderCell.Value = ((j - 6) + 1).ToString();
                    this.dgv_JtValue.Rows[j].Cells[0].Value = "阶梯电价" + (((j - 6) + 1)).ToString();
                    this.dgv_JtValue.Rows[j].Cells[1].Value = "";
                }
                for (int k = 13; k < 0x11; k++)
                {
                    this.dgv_JtValue.Rows.Add(1);
                    this.dgv_JtValue.Rows[k].HeaderCell.Value = ((k - 13) + 1).ToString();
                    this.dgv_JtValue.Rows[k].Cells[0].Value = "阶梯结算日" + (((k - 13) + 1)).ToString();
                    this.dgv_JtValue.Rows[k].Cells[1].Value = "";
                }
                this.dgv_FlValue.Rows.Clear();
                for (int m = 0; m < 0x20; m++)
                {
                    this.dgv_FlValue.Rows.Add(1);
                    this.dgv_FlValue.Rows[m].HeaderCell.Value = (m + 1).ToString();
                    this.dgv_FlValue.Rows[m].Cells[0].Value = "费率电价" + ((m + 1)).ToString();
                    this.dgv_FlValue.Rows[m].Cells[1].Value = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Init()
        {
            this.cbxArray[0] = this.cbx_0;
            this.cbxArray[1] = this.cbx_1;
            this.cbxArray[2] = this.cbx_2;
            this.cbxArray[3] = this.cbx_3;
            this.cbxArray[4] = this.cbx_4;
            this.cbxArray[5] = this.cbx_5;
            this.cbxArray[6] = this.cbx_6;
            this.cbxArray[7] = this.cbx_Jtdj;
            this.cbxArray[8] = this.cbx_FLdj;
            this.txtArray[0] = this.txt_0;
            this.txtArray[1] = this.txt_1;
            this.txtArray[2] = this.txt_2;
            this.txtArray[3] = this.txt_3;
            this.txtArray[4] = this.txt_4;
            this.txtArray[5] = this.txt_5;
            this.txtArray[6] = this.txt_6;
            this.txtArray[7] = this.txt_7;
        }
    }
}
