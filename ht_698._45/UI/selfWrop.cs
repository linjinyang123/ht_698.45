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
    public partial class selfWrop : Form
    {
        private FollowRepoartAndTimeTag followForm;
        public selfWrop(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void btn_添加OAD_Click(object sender, EventArgs e)
        {
            this.rtxt_构造器.Text = this.rtxt_构造器.Text + this.txt_OAD.Text.PadLeft(8, '0') + " ";
        }

        private void btn_添加服务_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { this.rtxt_构造器.Text, (this.cbx_服务.SelectedIndex + 5).ToString("X2"), (this.cbx_服务类型.SelectedIndex + 1).ToString("X2"), PublicVariable.PIID_R.ToString("X2"), " " };
            this.rtxt_构造器.Text = string.Concat(strArray);
        }

        private void btn_添加时间_Click(object sender, EventArgs e)
        {
            this.rtxt_构造器.Text = this.rtxt_构造器.Text + "01" + Convert.ToInt32(this.txt_时间标签.Text.Substring(0, 4), 10).ToString("X4") + Convert.ToInt32(this.txt_时间标签.Text.Substring(4, 2), 10).ToString("X2") + Convert.ToInt32(this.txt_时间标签.Text.Substring(6, 2), 10).ToString("X2") + Convert.ToInt32(this.txt_时间标签.Text.Substring(8, 2), 10).ToString("X2") + Convert.ToInt32(this.txt_时间标签.Text.Substring(10, 2), 10).ToString("X2") + Convert.ToInt32(this.txt_时间标签.Text.Substring(12, 2), 10).ToString("X2") + " ";
            this.rtxt_构造器.Text = this.rtxt_构造器.Text + this.cmb_间隔单位.SelectedIndex.ToString("X2") + Convert.ToInt32(this.txt_间隔值.Text.PadLeft(4, '0'), 10).ToString("X4") + " ";
        }

        private void btn_执行_Click(object sender, EventArgs e)
        {
            string str45;
            bool responseNext = false;
            bool bExtend = false;
            string linkData = "";
            string str3 = "";
            string str4 = "";
            List<string> list = new List<string>();
            List<List<string>> listData = new List<List<string>>();
            string followReportAndTime = "";
            List<string> list3 = new List<string>();
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            string str7 = "";
            string str8 = "";
            string str9 = "";
            List<string> list4 = new List<string>();
            List<string> list5 = new List<string>();
            List<List<string>> list6 = new List<List<string>>();
            List<string> list7 = new List<string>();
            List<List<List<List<string>>>> parseData = new List<List<List<List<string>>>>();
            string cData = this.rtxt_构造器.Text.Trim();
            if (this.chk_时间标签.Checked)
            {
                cData = this.rtxt_构造器.Text.Replace(" ", "");
            }
            else
            {
                cData = this.rtxt_构造器.Text.Replace(" ", "") + "00";
            }
            list.Clear();
            list3.Clear();
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    {
                        short num2 = (short)((8 + (PublicVariable.Address.Length / 2)) + (cData.Length / 2));
                        if (Protocol.OrigDLT698Wrap(num2.ToString("X4"), this.txt_control.Text.PadLeft(2, '0'), PublicVariable.Address, PublicVariable.Client_Add, cData, false))
                        {
                            CommParam.comPort.comPort_DataReceived();
                        }
                        if ((PublicVariable.RecDataString.Length <= 0) || !Protocol.RecIsProtocol(PublicVariable.RecDataString, ref linkData, ref bExtend))
                        {
                            goto Label_1A1E;
                        }
                        str45 = cData.Substring(0, 2);
                        if (str45 != null)
                        {
                            if (str45 != "05")
                            {
                                if (str45 == "06")
                                {
                                    str45 = cData.Substring(2, 2);
                                    if (str45 != null)
                                    {
                                        if (str45 != "01")
                                        {
                                            if (str45 == "02")
                                            {
                                                byte num = 0;
                                                responseNext = Protocol.SetResponseNormalList_wrop(linkData, ref str3, ref num, ref list3, ref list, ref followReportAndTime);
                                                if (responseNext)
                                                {
                                                    this.CreateNodes(list3, list);
                                                }
                                                break;
                                            }
                                            if (str45 == "03")
                                            {
                                                string str16 = "";
                                                List<string> list11 = new List<string>();
                                                List<string> list12 = new List<string>();
                                                List<bool> list13 = new List<bool>();
                                                List<bool> list14 = new List<bool>();
                                                List<string> list15 = new List<string>();
                                                List<List<string>> list16 = new List<List<string>>();
                                                responseNext = Protocol.SetThenGetResponseNormalList(linkData, ref str3, ref str16, ref list11, ref list15, ref list12, ref list16, ref list13, ref list14);
                                                if (responseNext)
                                                {
                                                    this.CreateNodes(str16, list11, list15, list12, list16);
                                                }
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            responseNext = Protocol.SetResponseNormal(linkData, ref str3, ref str4, ref followReportAndTime);
                                            if (responseNext)
                                            {
                                                this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                            }
                                        }
                                    }
                                    break;
                                }
                                if (str45 == "07")
                                {
                                    str45 = cData.Substring(2, 2);
                                    if (str45 != null)
                                    {
                                        if (str45 != "01")
                                        {
                                            if (str45 == "02")
                                            {
                                                string str17 = "";
                                                List<string> list17 = new List<string>();
                                                List<string> list18 = new List<string>();
                                                List<string> list19 = new List<string>();
                                                responseNext = Protocol.ActionResponseNormalList(linkData, ref str17, ref list17, ref list18, ref list19);
                                                if (responseNext)
                                                {
                                                    this.CreateNodes(list17, list18, list19);
                                                }
                                                break;
                                            }
                                            if (str45 == "03")
                                            {
                                                string str18 = "";
                                                List<string> list20 = new List<string>();
                                                List<string> list21 = new List<string>();
                                                List<string> list22 = new List<string>();
                                                List<string> list23 = new List<string>();
                                                List<List<string>> list24 = new List<List<string>>();
                                                List<bool> list25 = new List<bool>();
                                                List<bool> list26 = new List<bool>();
                                                responseNext = Protocol.ActionThenGetResponseNormalList(linkData, ref str18, ref list20, ref list21, ref list22, ref list23, ref list24, ref list25, ref list26);
                                                if (responseNext)
                                                {
                                                    this.CreateNodes(str18, list20, list21, list22, list23, list24);
                                                }
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            responseNext = Protocol.ActionResponseNormal(linkData, ref str3, ref str4, ref followReportAndTime);
                                            if (responseNext)
                                            {
                                                this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                switch (cData.Substring(2, 2))
                                {
                                    case "01":
                                        responseNext = Protocol_2.GetResponseNormal(linkData, ref str3, ref str4, ref list);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str4, list);
                                        }
                                        goto Label_0598;

                                    case "02":
                                        responseNext = Protocol_2.GetResponseNormalList(linkData, ref str3, ref list3, ref listData, this.tl_解析);
                                        goto Label_0598;

                                    case "03":
                                        {
                                            string str11 = "";
                                            string str12 = "";
                                            List<string> list9 = new List<string>();
                                            string str13 = "";
                                            List<List<List<string>>> list10 = new List<List<List<string>>>();
                                            responseNext = Protocol_2.GetResponseRecord(linkData, ref str11, ref str12, ref list9, ref str13, ref list10);
                                            if (responseNext)
                                            {
                                                this.CreateNodes(str11, str12, list9, str13, list10);
                                            }
                                            goto Label_0598;
                                        }
                                    case "04":
                                        responseNext = Protocol_2.GetResponseRecordList(linkData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str9, list4, list5, list6, list7, parseData);
                                        }
                                        goto Label_0598;

                                    case "05":
                                        {
                                            string str14 = "";
                                            responseNext = Protocol_2.GetResponseNext(linkData, ref str14);
                                            this.CreateNodes("内容", str14);
                                            goto Label_0598;
                                        }
                                    case "06":
                                        {
                                            string str15 = "";
                                            responseNext = Protocol_2.GetResponseMD5(linkData, ref str4, ref str15);
                                            if (responseNext)
                                            {
                                                this.CreateNodes(str4, str15);
                                            }
                                            goto Label_0598;
                                        }
                                }
                            }
                        }
                        break;
                    }
                case Link_Math.明文_RN:
                    str45 = cData.Substring(0, 2);
                    if (str45 != null)
                    {
                        if (str45 == "05")
                        {
                            switch (cData.Substring(2, 2))
                            {
                                case "01":
                                    responseNext = Protocol_2.Math_明文_RN("00", "01", ref cData, ref str4, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, list);
                                    }
                                    break;

                                case "02":
                                    responseNext = Protocol.Math_明文_RN("00", "01", ref cData, ref str4, ref list3, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(list3, list);
                                    }
                                    break;

                                case "03":
                                    {
                                        string str19 = "";
                                        string str20 = "";
                                        List<string> list27 = new List<string>();
                                        string str21 = "";
                                        List<List<List<string>>> list28 = new List<List<List<string>>>();
                                        responseNext = Protocol_2.Math_明文_RN("00", "01", ref cData, ref str19, ref str20, ref list27, ref str21, ref list28, ref mAC, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str19, str20, list27, str21, list28);
                                        }
                                        break;
                                    }
                                case "04":
                                    responseNext = Protocol_2.Math_明文_RN("00", "01", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str9, list4, list5, list6, list7, parseData);
                                    }
                                    break;

                                case "05":
                                    responseNext = Protocol_2.Math_明文_RN("00", "01", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes("内容", str8);
                                    }
                                    break;

                                case "06":
                                    responseNext = Protocol_2.Math_明文_RN("00", "01", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str7, str8);
                                    }
                                    break;
                            }
                        }
                        else if (str45 == "06")
                        {
                            str45 = cData.Substring(2, 2);
                            if (str45 != null)
                            {
                                if (str45 == "01")
                                {
                                    responseNext = Protocol.Math_明文_RN("00", "01", ref cData, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                    }
                                }
                                else if (str45 == "02")
                                {
                                    responseNext = Protocol.Math_明文_RN("00", "01", ref cData, ref str4, ref list3, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(list3, list);
                                    }
                                }
                                else if (str45 == "03")
                                {
                                    List<string> list29 = new List<string>();
                                    List<string> list30 = new List<string>();
                                    List<bool> list31 = new List<bool>();
                                    List<bool> list32 = new List<bool>();
                                    string str22 = "";
                                    List<string> list33 = new List<string>();
                                    List<string> list34 = new List<string>();
                                    List<List<string>> list35 = new List<List<string>>();
                                    responseNext = Protocol.Math_明文_RN("00", "01", ref cData, ref str22, ref list29, ref list33, ref list34, ref list30, ref list35, ref list31, ref list32, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str22, list29, list33, list30, list35);
                                    }
                                }
                            }
                        }
                        else if ((str45 == "07") && ((str45 = cData.Substring(2, 2)) != null))
                        {
                            if (str45 == "01")
                            {
                                responseNext = Protocol.Math_明文_RN("00", "01", ref cData, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                }
                            }
                            else if (str45 == "02")
                            {
                                List<string> list36 = new List<string>();
                                List<string> list37 = new List<string>();
                                List<bool> list38 = new List<bool>();
                                List<bool> list39 = new List<bool>();
                                string str23 = "";
                                List<string> list40 = new List<string>();
                                List<string> list41 = new List<string>();
                                List<List<string>> list42 = new List<List<string>>();
                                responseNext = Protocol.Math_明文_RN("00", "01", ref cData, ref str23, ref list36, ref list40, ref list41, ref list37, ref list42, ref list38, ref list39, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(list36, list40, list41);
                                }
                            }
                            else if (str45 == "03")
                            {
                                List<string> list43 = new List<string>();
                                List<string> list44 = new List<string>();
                                List<bool> list45 = new List<bool>();
                                List<bool> list46 = new List<bool>();
                                string str24 = "";
                                List<string> list47 = new List<string>();
                                List<string> list48 = new List<string>();
                                List<List<string>> list49 = new List<List<string>>();
                                responseNext = Protocol.Math_明文_RN("00", "01", ref cData, ref str24, ref list43, ref list47, ref list48, ref list44, ref list49, ref list45, ref list46, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(str24, list43, list47, list48, list44, list49);
                                }
                            }
                        }
                    }
                    goto Label_1A1E;

                case Link_Math.明文_SID_MAC:
                    str45 = cData.Substring(0, 2);
                    if (str45 != null)
                    {
                        if (str45 == "05")
                        {
                            switch (cData.Substring(2, 2))
                            {
                                case "01":
                                    responseNext = Protocol_2.Math_明文_SIDMAC("00", "00", ref cData, ref str4, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, list);
                                    }
                                    break;

                                case "02":
                                    responseNext = Protocol.Math_明文_SIDMAC("00", "00", ref cData, ref str4, ref list3, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(list3, list);
                                    }
                                    break;

                                case "03":
                                    {
                                        string str25 = "";
                                        string str26 = "";
                                        List<string> list50 = new List<string>();
                                        string str27 = "";
                                        List<List<List<string>>> list51 = new List<List<List<string>>>();
                                        responseNext = Protocol_2.Math_明文_SIDMAC("00", "00", ref cData, ref str25, ref str26, ref list50, ref str27, ref list51, ref mAC, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str25, str26, list50, str27, list51);
                                        }
                                        break;
                                    }
                                case "04":
                                    responseNext = Protocol_2.Math_明文_SIDMAC("00", "00", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str9, list4, list5, list6, list7, parseData);
                                    }
                                    break;

                                case "05":
                                    responseNext = Protocol_2.Math_明文_SIDMAC("00", "00", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes("内容", str8);
                                    }
                                    break;

                                case "06":
                                    responseNext = Protocol_2.Math_明文_SIDMAC("00", "00", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str7, str8);
                                    }
                                    break;
                            }
                        }
                        else if (str45 == "06")
                        {
                            str45 = cData.Substring(2, 2);
                            if (str45 != null)
                            {
                                if (str45 == "01")
                                {
                                    responseNext = Protocol.Math_明文_SIDMAC("00", "00", ref cData, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                    }
                                }
                                else if (str45 == "02")
                                {
                                    responseNext = Protocol.Math_明文_SIDMAC("00", "00", ref cData, ref str4, ref list3, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(list3, list);
                                    }
                                }
                                else if (str45 == "03")
                                {
                                    List<string> list52 = new List<string>();
                                    List<string> list53 = new List<string>();
                                    List<bool> list54 = new List<bool>();
                                    List<bool> list55 = new List<bool>();
                                    string str28 = "";
                                    List<string> list56 = new List<string>();
                                    List<string> list57 = new List<string>();
                                    List<List<string>> list58 = new List<List<string>>();
                                    responseNext = Protocol.Math_明文_SIDMAC("00", "00", ref cData, ref str28, ref list52, ref list56, ref list57, ref list53, ref list58, ref list54, ref list55, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str28, list52, list56, list53, list58);
                                    }
                                }
                            }
                        }
                        else if ((str45 == "07") && ((str45 = cData.Substring(2, 2)) != null))
                        {
                            if (str45 == "01")
                            {
                                responseNext = Protocol.Math_明文_SIDMAC("00", "00", ref cData, ref followReportAndTime, ref list, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                }
                            }
                            else if (str45 == "02")
                            {
                                List<string> list59 = new List<string>();
                                List<string> list60 = new List<string>();
                                List<bool> list61 = new List<bool>();
                                List<bool> list62 = new List<bool>();
                                string str29 = "";
                                List<string> list63 = new List<string>();
                                List<string> list64 = new List<string>();
                                List<List<string>> list65 = new List<List<string>>();
                                responseNext = Protocol.Math_明文_SIDMAC("00", "00", ref cData, ref str29, ref list59, ref list63, ref list64, ref list60, ref list65, ref list61, ref list62, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(list59, list63, list64);
                                }
                            }
                            else if (str45 == "03")
                            {
                                List<string> list66 = new List<string>();
                                List<string> list67 = new List<string>();
                                List<bool> list68 = new List<bool>();
                                List<bool> list69 = new List<bool>();
                                string str30 = "";
                                List<string> list70 = new List<string>();
                                List<string> list71 = new List<string>();
                                List<List<string>> list72 = new List<List<string>>();
                                responseNext = Protocol.Math_明文_SIDMAC("00", "00", ref cData, ref str30, ref list66, ref list70, ref list71, ref list67, ref list72, ref list68, ref list69, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(str30, list66, list70, list71, list67, list72);
                                }
                            }
                        }
                    }
                    goto Label_1A1E;

                case Link_Math.密文_SID:
                    str45 = cData.Substring(0, 2);
                    if (str45 != null)
                    {
                        if (str45 == "05")
                        {
                            switch (cData.Substring(2, 2))
                            {
                                case "01":
                                    responseNext = Protocol_2.Math_密文_SID("01", "03", ref cData, ref list, ref mAC, ref str3, ref str4, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, list);
                                    }
                                    break;

                                case "02":
                                    responseNext = Protocol.Math_密文_SID("01", "03", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref list3, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(list3, list);
                                    }
                                    break;

                                case "03":
                                    {
                                        string str31 = "";
                                        string str32 = "";
                                        List<string> list73 = new List<string>();
                                        string str33 = "";
                                        List<List<List<string>>> list74 = new List<List<List<string>>>();
                                        responseNext = Protocol_2.Math_密文_SID("01", "03", ref cData, ref str31, ref str32, ref list73, ref str33, ref list74, ref mAC, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str31, str32, list73, str33, list74);
                                        }
                                        break;
                                    }
                                case "04":
                                    responseNext = Protocol_2.Math_密文_SID("01", "03", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str9, list4, list5, list6, list7, parseData);
                                    }
                                    break;

                                case "05":
                                    responseNext = Protocol_2.Math_密文_SID("01", "03", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes("内容", str8);
                                    }
                                    break;

                                case "06":
                                    responseNext = Protocol_2.Math_密文_SID("01", "03", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str7, str8);
                                    }
                                    break;
                            }
                        }
                        else if (str45 == "06")
                        {
                            str45 = cData.Substring(2, 2);
                            if (str45 != null)
                            {
                                if (str45 == "01")
                                {
                                    responseNext = Protocol.Math_密文_SID("01", "03", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                    }
                                }
                                else if (str45 == "02")
                                {
                                    responseNext = Protocol.Math_密文_SID("01", "03", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref list3, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(list3, list);
                                    }
                                }
                                else if (str45 == "03")
                                {
                                    List<string> list75 = new List<string>();
                                    List<string> list76 = new List<string>();
                                    List<bool> list77 = new List<bool>();
                                    List<bool> list78 = new List<bool>();
                                    string str34 = "";
                                    List<string> list79 = new List<string>();
                                    List<string> list80 = new List<string>();
                                    List<List<string>> list81 = new List<List<string>>();
                                    responseNext = Protocol.Math_密文_SID("01", "03", ref cData, ref str34, ref list75, ref list79, ref list80, ref list76, ref list81, ref list77, ref list78, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str34, list75, list79, list76, list81);
                                    }
                                }
                            }
                        }
                        else if ((str45 == "07") && ((str45 = cData.Substring(2, 2)) != null))
                        {
                            if (str45 == "01")
                            {
                                responseNext = Protocol.Math_密文_SID("01", "03", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                }
                            }
                            else if (str45 == "02")
                            {
                                List<string> list82 = new List<string>();
                                List<string> list83 = new List<string>();
                                List<bool> list84 = new List<bool>();
                                List<bool> list85 = new List<bool>();
                                string str35 = "";
                                List<string> list86 = new List<string>();
                                List<string> list87 = new List<string>();
                                List<List<string>> list88 = new List<List<string>>();
                                responseNext = Protocol.Math_密文_SID("01", "03", ref cData, ref str35, ref list82, ref list86, ref list87, ref list83, ref list88, ref list84, ref list85, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(list82, list86, list87);
                                }
                            }
                            else if (str45 == "03")
                            {
                                List<string> list89 = new List<string>();
                                List<string> list90 = new List<string>();
                                List<bool> list91 = new List<bool>();
                                List<bool> list92 = new List<bool>();
                                string str36 = "";
                                List<string> list93 = new List<string>();
                                List<string> list94 = new List<string>();
                                List<List<string>> list95 = new List<List<string>>();
                                responseNext = Protocol.Math_密文_SID("01", "03", ref cData, ref str36, ref list89, ref list93, ref list94, ref list90, ref list95, ref list91, ref list92, ref mAC, ref bExtend, ref cOutData);
                                if (responseNext)
                                {
                                    this.CreateNodes(str36, list89, list93, list94, list90, list95);
                                }
                            }
                        }
                    }
                    goto Label_1A1E;

                case Link_Math.密文_SID_MAC:
                    switch (cData.Substring(0, 2))
                    {
                        case "05":
                            switch (cData.Substring(2, 2))
                            {
                                case "01":
                                    responseNext = Protocol_2.Math_密文_SID_MAC("01", "00", ref cData, ref list, ref mAC, ref str3, ref str4, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, list);
                                    }
                                    break;

                                case "02":
                                    responseNext = Protocol.Math_密文_SID_MAC("01", "00", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref list3, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(list3, list);
                                    }
                                    break;

                                case "03":
                                    {
                                        string str37 = "";
                                        string str38 = "";
                                        List<string> list96 = new List<string>();
                                        string str39 = "";
                                        List<List<List<string>>> list97 = new List<List<List<string>>>();
                                        responseNext = Protocol_2.Math_密文_SID_MAC("01", "00", ref cData, ref str37, ref str38, ref list96, ref str39, ref list97, ref mAC, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str37, str38, list96, str39, list97);
                                        }
                                        break;
                                    }
                                case "04":
                                    responseNext = Protocol_2.Math_密文_SID_MAC("01", "00", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str9, list4, list5, list6, list7, parseData);
                                    }
                                    break;

                                case "05":
                                    responseNext = Protocol_2.Math_密文_SID_MAC("01", "00", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes("内容", str8);
                                    }
                                    break;

                                case "06":
                                    responseNext = Protocol_2.Math_密文_SID_MAC("01", "00", ref cData, ref str9, ref list4, ref list5, ref list6, ref list7, ref parseData, ref str7, ref str8, ref mAC, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str7, str8);
                                    }
                                    break;
                            }
                            break;

                        case "06":
                            str45 = cData.Substring(2, 2);
                            if (str45 != null)
                            {
                                if (str45 != "01")
                                {
                                    if (str45 == "02")
                                    {
                                        responseNext = Protocol.Math_密文_SID_MAC("01", "00", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref list3, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(list3, list);
                                        }
                                        break;
                                    }
                                    if (str45 == "03")
                                    {
                                        List<string> list98 = new List<string>();
                                        List<string> list99 = new List<string>();
                                        List<bool> list100 = new List<bool>();
                                        List<bool> list101 = new List<bool>();
                                        string str40 = "";
                                        List<string> list102 = new List<string>();
                                        List<string> list103 = new List<string>();
                                        List<List<string>> list104 = new List<List<string>>();
                                        responseNext = Protocol.Math_密文_SID_MAC("01", "00", ref cData, ref str40, ref list98, ref list102, ref list103, ref list99, ref list104, ref list100, ref list101, ref mAC, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str40, list98, list102, list99, list104);
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    responseNext = Protocol.Math_密文_SID_MAC("01", "00", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                    }
                                }
                            }
                            break;

                        case "07":
                            str45 = cData.Substring(2, 2);
                            if (str45 != null)
                            {
                                if (str45 != "01")
                                {
                                    if (str45 == "02")
                                    {
                                        List<string> list105 = new List<string>();
                                        List<string> list106 = new List<string>();
                                        List<bool> list107 = new List<bool>();
                                        List<bool> list108 = new List<bool>();
                                        string str41 = "";
                                        List<string> list109 = new List<string>();
                                        List<string> list110 = new List<string>();
                                        List<List<string>> list111 = new List<List<string>>();
                                        responseNext = Protocol.Math_密文_SID_MAC("01", "00", ref cData, ref str41, ref list105, ref list109, ref list110, ref list106, ref list111, ref list107, ref list108, ref mAC, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(list105, list109, list110);
                                        }
                                        break;
                                    }
                                    if (str45 == "03")
                                    {
                                        List<string> list112 = new List<string>();
                                        List<string> list113 = new List<string>();
                                        List<bool> list114 = new List<bool>();
                                        List<bool> list115 = new List<bool>();
                                        string str42 = "";
                                        List<string> list116 = new List<string>();
                                        List<string> list117 = new List<string>();
                                        List<List<string>> list118 = new List<List<string>>();
                                        responseNext = Protocol.Math_密文_SID_MAC("01", "00", ref cData, ref str42, ref list112, ref list116, ref list117, ref list113, ref list118, ref list114, ref list115, ref mAC, ref bExtend, ref cOutData);
                                        if (responseNext)
                                        {
                                            this.CreateNodes(str42, list112, list116, list117, list113, list118);
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    responseNext = Protocol.Math_密文_SID_MAC("01", "00", ref cData, ref followReportAndTime, ref list, ref mAC, ref str3, ref str4, ref bExtend, ref cOutData);
                                    if (responseNext)
                                    {
                                        this.CreateNodes(str4, responseNext ? "00--成功" : "01--失败");
                                    }
                                }
                            }
                            break;
                    }
                    goto Label_1A1E;

                default:
                    goto Label_1A1E;
            }
        Label_0598:
            PublicVariable.SplitFlag = bExtend;
            PublicVariable.ChangedFlag = true;
        Label_1A1E:
            PublicVariable.Info = (responseNext ? "成功" : "失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = responseNext ? "Blue" : "Red";
            PublicVariable.ChangedFlag = true;
            string str43 = "->" + PublicVariable.SendDataString;
            string str44 = "<-" + PublicVariable.RecDataString;
            this.rTxt_RecAndSend.AppendText("===============================================\r\n");
            this.rTxt_RecAndSend.AppendText(str43 + "\r\n");
            this.rTxt_RecAndSend.AppendText(str44 + "\r\n");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.rtxt_构造器.Text = "";
        }

        private void btn_数据类型添加_Click(object sender, EventArgs e)
        {
            int length = this.tree_数据类型.SelectedNode.Text.Length;
            this.rtxt_构造器.Text = this.rtxt_构造器.Text + Convert.ToInt32(this.tree_数据类型.SelectedNode.Text.Substring(length - 2, 2), 10).ToString("X2");
        }

        private void cbx_服务_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbx_服务.SelectedIndex == 0)
            {
                this.cbx_服务类型.Items.Clear();
                this.cbx_服务类型.Items.AddRange(new object[] { "GetRequestNormal-01", "GetRequestNormalList-02", "GetRequestRecord-03", "GetRequestRecordList-04", "GetRequestNext-05", "GetRequestMD5-06" });
                this.cbx_服务类型.SelectedIndex = 0;
            }
            else if (this.cbx_服务.SelectedIndex == 1)
            {
                this.cbx_服务类型.Items.Clear();
                this.cbx_服务类型.Items.AddRange(new object[] { "SetRequestNormal-01", "SetRequestNormalList-02", "SetThenGetRequestNormalList-03" });
                this.cbx_服务类型.SelectedIndex = 0;
            }
            else if (this.cbx_服务.SelectedIndex == 2)
            {
                this.cbx_服务类型.Items.Clear();
                this.cbx_服务类型.Items.AddRange(new object[] { "ActionRequest-01", "ActionRequestList-02", "ActionThenGetRequestNormalList-03" });
                this.cbx_服务类型.SelectedIndex = 0;
            }
        }

        private void chk_con_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_con.Checked)
            {
                this.txt_control.Enabled = false;
            }
            else
            {
                this.txt_control.Enabled = true;
            }
        }

        private void chk_时间标签_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_时间标签.Checked)
            {
                this.txt_时间标签.Enabled = true;
                this.cmb_间隔单位.Enabled = true;
                this.txt_间隔值.Enabled = true;
                this.btn_添加时间.Enabled = true;
            }
            else
            {
                this.txt_时间标签.Enabled = false;
                this.cmb_间隔单位.Enabled = false;
                this.txt_间隔值.Enabled = false;
                this.btn_添加时间.Enabled = false;
            }
        }
        private void CreateNodes(List<string> list_OAD, List<string> List_ParseData)
        {
            TreeListNode parentNode = null;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            for (int i = 0; i < list_OAD.Count; i++)
            {
                TreeListNode node2 = this.tl_解析.AppendNode(new object[] { list_OAD[i] }, parentNode);
                this.tl_解析.AppendNode(new object[] { "", List_ParseData[i] + "--" + ((DAR)Convert.ToInt16(List_ParseData[i], 0x10)).ToString() }, node2);
            }
            this.tl_解析.EndUnboundLoad();
        }

        private void CreateNodes(string str_OAD, List<string> List_ParseData)
        {
            TreeListNode parentNode = null;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            TreeListNode node2 = this.tl_解析.AppendNode(new object[] { str_OAD }, parentNode);
            for (int i = 0; i < List_ParseData.Count; i++)
            {
                this.tl_解析.AppendNode(new object[] { "", List_ParseData[i] }, node2);
            }
            this.tl_解析.EndUnboundLoad();
        }

        private void CreateNodes(string str_OAD, string ParseData)
        {
            TreeListNode parentNode = null;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            TreeListNode node2 = this.tl_解析.AppendNode(new object[] { str_OAD }, parentNode);
            this.tl_解析.AppendNode(new object[] { "", ParseData }, node2);
            this.tl_解析.EndUnboundLoad();
        }

        private void CreateNodes(List<string> list_OAD, List<string> list_DAR, List<string> List_ParseData)
        {
            TreeListNode parentNode = null;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            for (int i = 0; i < list_OAD.Count; i++)
            {
                TreeListNode node2 = this.tl_解析.AppendNode(new object[] { list_OAD[i] }, parentNode);
                this.tl_解析.AppendNode(new object[] { "", list_DAR[i] + "--" + ((DAR)Convert.ToInt16(list_DAR[i], 0x10)).ToString() }, node2);
                if (List_ParseData[i] != "")
                {
                    for (int j = 0; j < List_ParseData.Count; j++)
                    {
                        this.tl_解析.AppendNode(new object[] { "操作返回数据", List_ParseData[i] }, node2);
                    }
                }
            }
            this.tl_解析.EndUnboundLoad();
        }

        private void CreateNodes(string SEQ_of_Pro, List<string> list_OMD_Action, List<string> list_DAR, List<string> list_OAD_Read, List<List<string>> list_Re_ParseData_Read)
        {
            TreeListNode parentNode = null;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            for (int i = 0; i < Convert.ToInt16(SEQ_of_Pro, 0x10); i++)
            {
                object[] nodeData = new object[] { "第" + ((i + 1)).ToString() + "组" };
                TreeListNode node3 = this.tl_解析.AppendNode(nodeData, parentNode);
                TreeListNode node4 = this.tl_解析.AppendNode(new object[] { "Action_Data" }, node3);
                TreeListNode node2 = this.tl_解析.AppendNode(new object[] { list_OMD_Action[i] }, node4);
                this.tl_解析.AppendNode(new object[] { "", list_DAR[i] + "--" + ((DAR)Convert.ToInt16(list_DAR[i], 0x10)).ToString() }, node2);
                node4 = this.tl_解析.AppendNode(new object[] { "Read_Data" }, node3);
                node2 = this.tl_解析.AppendNode(new object[] { list_OAD_Read[i] }, node4);
                for (int j = 0; j < list_Re_ParseData_Read[i].Count; j++)
                {
                    this.tl_解析.AppendNode(new object[] { "", list_Re_ParseData_Read[i][j] }, node2);
                }
            }
            this.tl_解析.EndUnboundLoad();
        }

        private void CreateNodes(string Rercord_OAD, string rel_Num, List<string> Rel_RCSD, string Record_Num, List<List<List<string>>> list_ParseData_多级)
        {
            TreeListNode parentNode = null;
            TreeListNode node4;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            TreeListNode node2 = this.tl_解析.AppendNode(new object[] { Rercord_OAD }, parentNode);
            TreeListNode node3 = this.tl_解析.AppendNode(new object[] { "共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "关联属性" }, node2);
            for (int i = 0; i < Convert.ToInt16(rel_Num, 0x10); i++)
            {
                node4 = this.tl_解析.AppendNode(new object[] { "", Rel_RCSD[i] }, node3);
            }
            node3 = this.tl_解析.AppendNode(new object[] { "共" + Convert.ToInt16(Record_Num, 0x10).ToString() + "记录" }, node2);
            for (int j = 0; j < list_ParseData_多级.Count; j++)
            {
                object[] nodeData = new object[] { "第" + ((j + 1)).ToString() + "条记录" };
                node4 = this.tl_解析.AppendNode(nodeData, node3);
                for (int k = 0; k < list_ParseData_多级[j].Count; k++)
                {
                    object[] objArray6 = new object[1];
                    string[] strArray = new string[] { "第", (k + 1).ToString(), "列,共", list_ParseData_多级[j][k].Count.ToString(), "项" };
                    objArray6[0] = string.Concat(strArray);
                    this.tl_解析.AppendNode(objArray6, node4);
                    for (int m = 0; m < list_ParseData_多级[j][k].Count; m++)
                    {
                        if (list_ParseData_多级[j][k][m] == "")
                        {
                            list_ParseData_多级[j][k][m] = "NULL";
                        }
                        this.tl_解析.AppendNode(new object[] { "", list_ParseData_多级[j][k][m] }, node4);
                    }
                }
            }
            this.tl_解析.EndUnboundLoad();
        }

        private void CreateNodes(string getRecord_Num, List<string> Rercord_OAD, List<string> rel_Num, List<List<string>> Rel_RCSD, List<string> Record_Num, List<List<List<List<string>>>> list_ParseData_多级)
        {
            TreeListNode parentNode = null;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            for (int i = 0; i < Convert.ToInt16(getRecord_Num, 0x10); i++)
            {
                TreeListNode node4;
                TreeListNode node2 = this.tl_解析.AppendNode(new object[] { Rercord_OAD[i] }, parentNode);
                TreeListNode node3 = this.tl_解析.AppendNode(new object[] { "共" + Convert.ToInt16(rel_Num[i], 0x10).ToString() + "关联属性" }, node2);
                for (int j = 0; j < Convert.ToInt16(rel_Num[i], 0x10); j++)
                {
                    node4 = this.tl_解析.AppendNode(new object[] { "", Rel_RCSD[i][j] }, node3);
                }
                node3 = this.tl_解析.AppendNode(new object[] { "共" + Convert.ToInt16(Record_Num[i], 0x10).ToString() + "记录" }, node2);
                if (list_ParseData_多级.Count >= (i + 1))
                {
                    for (int k = 0; k < Convert.ToInt16(Record_Num[i], 0x10); k++)
                    {
                        object[] nodeData = new object[] { "第" + ((k + 1)).ToString() + "条记录" };
                        node4 = this.tl_解析.AppendNode(nodeData, node3);
                        for (int m = 0; m < list_ParseData_多级[i][k].Count; m++)
                        {
                            object[] objArray6 = new object[1];
                            string[] strArray = new string[] { "第", (m + 1).ToString(), "列,共", list_ParseData_多级[i][k][m].Count.ToString(), "项" };
                            objArray6[0] = string.Concat(strArray);
                            this.tl_解析.AppendNode(objArray6, node4);
                            for (int n = 0; n < list_ParseData_多级[i][k][m].Count; n++)
                            {
                                if (list_ParseData_多级[i][k][m][n] == "")
                                {
                                    list_ParseData_多级[i][k][m][n] = "NULL";
                                }
                                this.tl_解析.AppendNode(new object[] { "", list_ParseData_多级[i][k][m][n] }, node4);
                            }
                        }
                    }
                }
            }
            this.tl_解析.EndUnboundLoad();
        }

        private void CreateNodes(string SEQ_of_Pro, List<string> list_OMD_Action, List<string> list_DAR, List<string> Re_ParseData_Action, List<string> list_OAD_Read, List<List<string>> list_Re_ParseData_Read)
        {
            TreeListNode parentNode = null;
            this.tl_解析.ClearNodes();
            this.tl_解析.BeginUnboundLoad();
            for (int i = 0; i < Convert.ToInt16(SEQ_of_Pro, 0x10); i++)
            {
                object[] nodeData = new object[] { "第" + ((i + 1)).ToString() + "组" };
                TreeListNode node3 = this.tl_解析.AppendNode(nodeData, parentNode);
                TreeListNode node4 = this.tl_解析.AppendNode(new object[] { "Action_Data" }, node3);
                TreeListNode node2 = this.tl_解析.AppendNode(new object[] { list_OMD_Action[i] }, node4);
                this.tl_解析.AppendNode(new object[] { "", list_DAR[i] + "--" + ((DAR)Convert.ToInt16(list_DAR[i], 0x10)).ToString() }, node2);
                if (Re_ParseData_Action[i] != "")
                {
                    for (int k = 0; k < Re_ParseData_Action.Count; k++)
                    {
                        this.tl_解析.AppendNode(new object[] { "操作返回数据", Re_ParseData_Action[i] }, node2);
                    }
                }
                node4 = this.tl_解析.AppendNode(new object[] { "Read_Data" }, node3);
                node2 = this.tl_解析.AppendNode(new object[] { list_OAD_Read[i] }, node4);
                for (int j = 0; j < list_Re_ParseData_Read[i].Count; j++)
                {
                    this.tl_解析.AppendNode(new object[] { "", list_Re_ParseData_Read[i][j] }, node2);
                }
            }
            this.tl_解析.EndUnboundLoad();
        }

        private void rTxt_RecAndSend_DoubleClick(object sender, EventArgs e)
        {
            this.rTxt_RecAndSend.Text = "";
        }

        private void selfWrop_Load(object sender, EventArgs e)
        {
            this.cbx_服务.SelectedIndex = 0;
            this.cmb_间隔单位.SelectedIndex = 0;
        }
    }
}
