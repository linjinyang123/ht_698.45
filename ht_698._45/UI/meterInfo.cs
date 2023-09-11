using DevExpress.XtraTreeList.Nodes;
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
    public partial class meterInfo : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private CheckBox[] chkArray1 = new CheckBox[6];
        private TextBox[] txtArray1 = new TextBox[6];
        private CheckBox[] chkArray2 = new CheckBox[10];
        private TextBox[] txtArray2 = new TextBox[10];
        private CheckBox[] chkArray3 = new CheckBox[8];
        private TextBox[] txtArray3 = new TextBox[5];
        public meterInfo(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            this.InitArray();
        }
    
        private void bt_设置_Click(object sender, EventArgs e)
        {
            this.treeList_批量.PostEditor();
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            new List<string>();
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x3e8);
            string str7 = "43000A00";
            cData = "";
            for (int i = 0; i < this.treeList_批量.Nodes.Count; i++)
            {
                cData = cData + "51" + this.treeList_批量.Nodes[i].GetDisplayText("上报通道OAD").PadLeft(8, '0').Substring(0, 8);
            }
            cData = "01" + this.treeList_批量.Nodes.Count.ToString("X2") + cData;
            linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), str7 + cData, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str7, cData, PublicVariable.TimeTag, ref splitFlag);
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
            PublicVariable.Info = "上报通道" + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
        }

        private void btn_Exit1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btn_Exit2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btn_Exit3_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btn_Read_P1_Click(object sender, EventArgs e)
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
                    string[] strArray = new string[] { "43000301", "43000302", "43000303", "43000304", "43000305", "43000306" };
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        cData = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray1[i] != null) && this.chkArray1[i].Checked) && this.chkArray1[i].Visible)
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
                            PublicVariable.Info = "版本信息-" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (flag)
                            {
                                this.txtArray1[i].Text = parseData;
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
                    string[] strArray = new string[] { "410B0200", "41040200", "41050200", "41060200", "41070200", "41080200", "41110200", "40100200", "41060300", "41060400" };
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        cData = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray2[i] != null) && this.chkArray2[i].Checked) && this.chkArray2[i].Visible)
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
                            PublicVariable.Info = this.chkArray2[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (flag)
                            {
                                this.txtArray2[i].Text = parseData;
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
                    string[] strArray = new string[] { "43000200", "43000400", "43000700", "43000800", "43000900", "43000500", "43000600", "43000A00" };
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        int num2;
                        int num3;
                        int num4;
                        int num5;
                        cData = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray3[i] == null) || !this.chkArray3[i].Checked) || !this.chkArray3[i].Visible)
                        {
                            continue;
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
                        PublicVariable.Info = this.chkArray3[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            switch (i)
                            {
                                case 0:
                                case 1:
                                    this.txtArray3[i].Text = parseData;
                                    break;

                                case 2:
                                    this.tb_2.Text = (parseData == "00") ? "False" : "True";
                                    break;

                                case 3:
                                    this.tb_3.Text = (parseData == "00") ? "False" : "True";
                                    break;

                                case 4:
                                    this.tb_4.Text = (parseData == "00") ? "False" : "True";
                                    break;

                                case 5:
                                    this.dgv_子设备列表.Rows.Clear();
                                    num2 = parseData.Length / 4;
                                    num3 = 0;
                                    goto Label_03A6;

                                case 6:
                                    this.dgv_规约列表.Rows.Clear();
                                    this.dgv_规约列表.Rows.Add(1);
                                    this.dgv_规约列表.Rows[0].Cells[1].Value = parseData;
                                    break;

                                case 7:
                                    this.dgv_上报通道.Rows.Clear();
                                    num4 = parseData.Length / 8;
                                    num5 = 0;
                                    goto Label_049A;
                            }
                        }
                        continue;
                    Label_032A:
                        this.dgv_子设备列表.Rows.Add(1);
                        this.dgv_子设备列表.Rows[num3].Cells[0].Value = (num3 + 1).ToString();
                        this.dgv_子设备列表.Rows[num3].Cells[1].Value = parseData.Substring(0, 4);
                        parseData = parseData.Substring(4);
                        num3++;
                    Label_03A6:
                        if (num3 < num2)
                        {
                            goto Label_032A;
                        }
                        continue;
                    Label_041E:
                        this.dgv_上报通道.Rows.Add(1);
                        this.dgv_上报通道.Rows[num5].Cells[0].Value = (num5 + 1).ToString();
                        this.dgv_上报通道.Rows[num5].Cells[1].Value = parseData.Substring(0, 8);
                        parseData = parseData.Substring(8);
                        num5++;
                    Label_049A:
                        if (num5 < num4)
                        {
                            goto Label_041E;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    PublicVariable.Info = exception.Message;
                    PublicVariable.IsReading = false;
                    PublicVariable.Info_Color = "Red";
                }
                finally
                {
                    PublicVariable.IsReading = false;
                }
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string data = "";
                    bool splitFlag = false;
                    string[] strArray = new string[] { "43000301", "43000302", "43000303", "43000304", "43000305", "43000306" };
                    byte[] buffer = new byte[] { 10, 10, 10, 10, 10, 10 };
                    byte[] buffer2 = new byte[] { 2, 2, 3, 2, 3, 4 };
                    new List<string>();
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        data = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray1[i] != null) && this.chkArray1[i].Checked) && this.chkArray1[i].Visible)
                        {
                            data = this.txtArray1[i].Text;
                            data = Protocol.From_Type_GetData(buffer[i], buffer2[i], ref data);
                            linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + data, PublicVariable.TimeTag);
                            switch (PublicVariable.link_Math)
                            {
                                case Link_Math.纯明文操作:
                                    flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], data, PublicVariable.TimeTag, ref splitFlag);
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
                            PublicVariable.Info = "版本信息-" + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (!flag)
                            {
                                PublicVariable.IsReading = false;
                                return;
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

        private void btn_Write_Page2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string data = "";
                    bool splitFlag = false;
                    string[] strArray = new string[] { "410B0200", "41040200", "41050200", "41060200", "41070200", "41080200", "41110200", "40100200", "41060300", "41060400" };
                    byte[] buffer = new byte[] { 10, 10, 10, 10, 10, 10, 10, 0x11, 10, 10 };
                    byte[] buffer2 = new byte[] { 0x10, 3, 3, 3, 2, 2, 8, 1, 0x10, 0x10 };
                    new List<string>();
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        data = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray2[i] != null) && this.chkArray2[i].Checked) && this.chkArray2[i].Visible)
                        {
                            data = this.txtArray2[i].Text;
                            data = Protocol.From_Type_GetData(buffer[i], buffer2[i], ref data);
                            linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + data, PublicVariable.TimeTag);
                            switch (PublicVariable.link_Math)
                            {
                                case Link_Math.纯明文操作:
                                    flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], data, PublicVariable.TimeTag, ref splitFlag);
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
                            PublicVariable.Info = this.chkArray2[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (!flag)
                            {
                                PublicVariable.IsReading = false;
                                return;
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

        private void btn_Write_Page3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string data = "";
                    bool splitFlag = false;
                    string[] strArray = new string[] { "43000200", "43000400", "43000700", "43000800", "43000900" };
                    byte[] buffer = new byte[] { 10, 0x1c, 3, 3, 3 };
                    byte[] buffer2 = new byte[] { 0x10, 7, 1, 1, 1 };
                    new List<string>();
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        data = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray3[i] == null) || !this.chkArray3[i].Checked) || !this.chkArray3[i].Visible)
                        {
                            continue;
                        }
                        switch (i)
                        {
                            case 0:
                            case 1:
                                data = this.txtArray3[i].Text;
                                goto Label_01AE;

                            case 2:
                                if (this.tb_2.Text != "True")
                                {
                                    break;
                                }
                                data = "01";
                                goto Label_01AE;

                            case 3:
                                if (this.tb_3.Text != "True")
                                {
                                    goto Label_0181;
                                }
                                data = "01";
                                goto Label_01AE;

                            case 4:
                                if (this.tb_4.Text != "True")
                                {
                                    goto Label_01A8;
                                }
                                data = "01";
                                goto Label_01AE;

                            default:
                                goto Label_01AE;
                        }
                        data = "00";
                        goto Label_01AE;
                    Label_0181:
                        data = "00";
                        goto Label_01AE;
                    Label_01A8:
                        data = "00";
                    Label_01AE:
                        data = Protocol.From_Type_GetData(buffer[i], buffer2[i], ref data);
                        linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + data, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], data, PublicVariable.TimeTag, ref splitFlag);
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
                        PublicVariable.Info = this.chkArray3[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (!flag)
                        {
                            PublicVariable.IsReading = false;
                            return;
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

        private void btn_清空_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            new List<string>();
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x3e8);
            string str7 = "43000A00";
            cData = "0100";
            linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), str7 + cData, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str7, cData, PublicVariable.TimeTag, ref splitFlag);
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
            PublicVariable.Info = "上报通道" + (flag ? "清空成功" : "清空失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList_批量.Nodes.Count > 1)
                {
                    this.treeList_批量.DeleteNode(this.treeList_批量.Nodes.LastNode);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_添加_Click(object sender, EventArgs e)
        {
            try
            {
                this.treeList_批量.PostEditor();
                this.treeList_批量.BeginUnboundLoad();
                TreeListNode parentNode = null;
                this.treeList_批量.AppendNode(new object[] { "" }, parentNode);
                this.treeList_批量.ExpandAll();
                this.treeList_批量.EndUnboundLoad();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chx_All_P1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chx_All_P1.Checked)
            {
                for (int i = 0; i < this.chkArray1.Length; i++)
                {
                    if ((this.chkArray1[i] != null) && this.chkArray1[i].Visible)
                    {
                        this.chkArray1[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.chkArray1.Length; i++)
                {
                    if ((this.chkArray1[i] != null) && this.chkArray1[i].Visible)
                    {
                        this.chkArray1[i].Checked = false;
                    }
                }
            }
        }

        private void chx_All_P2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chx_All_P2.Checked)
            {
                for (int i = 0; i < this.chkArray2.Length; i++)
                {
                    if ((this.chkArray2[i] != null) && this.chkArray2[i].Visible)
                    {
                        this.chkArray2[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.chkArray2.Length; i++)
                {
                    if ((this.chkArray2[i] != null) && this.chkArray2[i].Visible)
                    {
                        this.chkArray2[i].Checked = false;
                    }
                }
            }
        }

        private void chx_All_P3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chx_All_P3.Checked)
            {
                for (int i = 0; i < this.chkArray3.Length; i++)
                {
                    if ((this.chkArray3[i] != null) && this.chkArray3[i].Visible)
                    {
                        this.chkArray3[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.chkArray3.Length; i++)
                {
                    if ((this.chkArray3[i] != null) && this.chkArray3[i].Visible)
                    {
                        this.chkArray3[i].Checked = false;
                    }
                }
            }
        }
        private void InitArray()
        {
            this.chkArray1[0] = this.chk_0;
            this.chkArray1[1] = this.chk_1;
            this.chkArray1[2] = this.chk_2;
            this.chkArray1[3] = this.chk_3;
            this.chkArray1[4] = this.chk_4;
            this.chkArray1[5] = this.chk_5;
            this.txtArray1[0] = this.txt_0;
            this.txtArray1[1] = this.txt_1;
            this.txtArray1[2] = this.txt_2;
            this.txtArray1[3] = this.txt_3;
            this.txtArray1[4] = this.txt_4;
            this.txtArray1[5] = this.txt_5;
            this.chkArray2[0] = this.ch_0;
            this.chkArray2[1] = this.ch_1;
            this.chkArray2[2] = this.ch_2;
            this.chkArray2[3] = this.ch_3;
            this.chkArray2[4] = this.ch_4;
            this.chkArray2[5] = this.ch_5;
            this.chkArray2[6] = this.ch_6;
            this.chkArray2[7] = this.ch_7;
            this.chkArray2[8] = this.ch_8;
            this.chkArray2[9] = this.ch_9;
            this.txtArray2[0] = this.tx_0;
            this.txtArray2[1] = this.tx_1;
            this.txtArray2[2] = this.tx_2;
            this.txtArray2[3] = this.tx_3;
            this.txtArray2[4] = this.tx_4;
            this.txtArray2[5] = this.tx_5;
            this.txtArray2[6] = this.tx_6;
            this.txtArray2[7] = this.tx_7;
            this.txtArray2[8] = this.tx_8;
            this.txtArray2[9] = this.tx_9;
            this.chkArray3[0] = this.chb_0;
            this.chkArray3[1] = this.chb_1;
            this.chkArray3[2] = this.chb_2;
            this.chkArray3[3] = this.chb_3;
            this.chkArray3[4] = this.chb_4;
            this.chkArray3[5] = this.chb_5;
            this.chkArray3[6] = this.chb_6;
            this.chkArray3[7] = this.chb_7;
            this.txtArray3[0] = this.tb_0;
            this.txtArray3[1] = this.tb_1;
            this.txtArray3[2] = this.tb_2;
            this.txtArray3[3] = this.tb_3;
            this.txtArray3[4] = this.tb_4;
        }

        private void tb_2_Click(object sender, EventArgs e)
        {
            this.tb_2.Text = (this.tb_2.Text == "False") ? "True" : "False";
        }

        private void tb_3_Click(object sender, EventArgs e)
        {
            this.tb_3.Text = (this.tb_3.Text == "False") ? "True" : "False";
        }

        private void tb_4_Click(object sender, EventArgs e)
        {
            this.tb_4.Text = (this.tb_4.Text == "False") ? "True" : "False";
        }
    }
}
