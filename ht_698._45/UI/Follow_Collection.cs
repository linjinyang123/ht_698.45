using DevExpress.XtraTreeList;
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
    public partial class Follow_Collection : Form
    {
        private FollowRepoartAndTimeTag followForm;
        Form_Main form_main = new Form_Main();
        private string sele_type = "10";
        public Follow_Collection(Form_Main parent)
        {
            form_main = parent;
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "meterInfo")
                {
                    form.Activate();
                    return;
                }
            }
            new meterInfo(form_main).Show();
            //meterInfo meter = meterInfo.CreateForm();
            //meter.Show();
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            List<string> list = new List<string>();
            List<string> parseData = new List<string>();
            byte sEQOfOAD = 0;
            string data = "";
            for (int i = 0; i < this.dgv_follow.Rows.Count; i++)
            {
                this.dgv_follow.EndEdit();
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[i].Cells[0];
                if (Convert.ToBoolean(cell.Value))
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    data = data + this.dgv_follow.Rows[i].Cells[0].ToolTipText;
                }
            }
            cData = "";
            parseData.Clear();
            string linkdata = "";
            string str5 = "";
            string str6 = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            linkdata = Protocol.MakeLink_Data("05", "02", PublicVariable.PIID_R.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormalList(sEQOfOAD, data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormalList(cData, ref str2, ref list, ref parseData);
                    }
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多项属性" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag || (parseData.Count != 0))
            {
                int num3 = 0;
                for (int j = 0; j < this.dgv_follow.Rows.Count; j++)
                {
                    DataGridViewCheckBoxCell cell2 = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[j].Cells[0];
                    if (!Convert.ToBoolean(cell2.Value))
                    {
                        goto Label_0696;
                    }
                    string str8 = parseData[num3];
                    if (str8 != null)
                    {
                        if (str8 != "00")
                        {
                            if (str8 == "01")
                            {
                                goto Label_03BF;
                            }
                            if (str8 == "02")
                            {
                                goto Label_0488;
                            }
                            if (str8 == "03")
                            {
                                goto Label_0551;
                            }
                            if (str8 == "")
                            {
                                goto Label_0617;
                            }
                        }
                        else
                        {
                            this.dgv_follow.Rows[j].Cells[4].Value = "关闭";
                            this.dgv_follow.Rows[j].Cells[2].Value = false;
                            this.dgv_follow.Rows[j].Cells[3].Value = false;
                            this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                            this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.White;
                        }
                    }
                    goto Label_068B;
                Label_03BF:
                    this.dgv_follow.Rows[j].Cells[4].Value = "开启";
                    this.dgv_follow.Rows[j].Cells[2].Value = true;
                    this.dgv_follow.Rows[j].Cells[3].Value = false;
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Aqua;
                    goto Label_068B;
                Label_0488:
                    this.dgv_follow.Rows[j].Cells[4].Value = "开启";
                    this.dgv_follow.Rows[j].Cells[2].Value = false;
                    this.dgv_follow.Rows[j].Cells[3].Value = true;
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Aqua;
                    goto Label_068B;
                Label_0551:
                    this.dgv_follow.Rows[j].Cells[4].Value = "开启";
                    this.dgv_follow.Rows[j].Cells[2].Value = true;
                    this.dgv_follow.Rows[j].Cells[3].Value = true;
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Aqua;
                    goto Label_068B;
                Label_0617:
                    this.dgv_follow.Rows[j].Cells[4].Value = "失败";
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Red;
                Label_068B:
                    num3++;
                    continue;
                Label_0696:
                    this.dgv_follow.Rows[j].Cells[4].Value = "";
                    this.dgv_follow.Rows[j].Cells[2].Value = false;
                    this.dgv_follow.Rows[j].Cells[3].Value = false;
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.White;
                }
            }
            else
            {
                for (int j = 0; j < parseData.Count; j++)
                {
                    this.dgv_follow.Rows[j].Cells[4].Value = "抄读失败";
                    this.dgv_follow.Rows[j].Cells[2].Value = false;
                    this.dgv_follow.Rows[j].Cells[3].Value = false;
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Red;
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

        private void btn_read_上报方式_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            List<string> list = new List<string>();
            List<string> parseData = new List<string>();
            byte sEQOfOAD = 0;
            string data = "";
            for (int i = 0; i < this.dgv_follow.Rows.Count; i++)
            {
                this.dgv_follow.EndEdit();
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[i].Cells[0];
                if (Convert.ToBoolean(cell.Value))
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    data = data + this.dgv_follow.Rows[i].Cells[0].Tag;
                }
            }
            cData = "";
            parseData.Clear();
            string linkdata = "";
            string str5 = "";
            string str6 = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            linkdata = Protocol.MakeLink_Data("05", "02", PublicVariable.PIID_R.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormalList(sEQOfOAD, data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormalList(cData, ref str2, ref list, ref parseData);
                    }
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多项属性" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag || (parseData.Count != 0))
            {
                int num3 = 0;
                for (int j = 0; j < this.dgv_follow.Rows.Count; j++)
                {
                    DataGridViewCheckBoxCell cell2 = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[j].Cells[0];
                    if (!Convert.ToBoolean(cell2.Value))
                    {
                        goto Label_053E;
                    }
                    string str8 = parseData[num3];
                    if (str8 != null)
                    {
                        if (str8 != "00")
                        {
                            if (str8 == "01")
                            {
                                goto Label_03A0;
                            }
                            if (str8 == "")
                            {
                                goto Label_046C;
                            }
                        }
                        else
                        {
                            this.dgv_follow.Rows[j].Cells[5].Value = "主动上报";
                            this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                            this.dgv_follow.Rows[j].Cells[5].Style.BackColor = Color.White;
                            this.dgv_follow.Rows[j].Cells[6].Value = "读取成功";
                            this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.Aqua;
                        }
                    }
                    goto Label_0533;
                Label_03A0:
                    this.dgv_follow.Rows[j].Cells[5].Value = "跟随上报";
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[5].Style.BackColor = Color.Olive;
                    this.dgv_follow.Rows[j].Cells[6].Value = "读取成功";
                    this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.Aqua;
                    goto Label_0533;
                Label_046C:
                    this.dgv_follow.Rows[j].Cells[5].Value = "失败";
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[5].Style.BackColor = Color.Red;
                    this.dgv_follow.Rows[j].Cells[6].Value = "读取失败";
                    this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.Red;
                Label_0533:
                    num3++;
                    continue;
                Label_053E:
                    this.dgv_follow.Rows[j].Cells[5].Value = "";
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[5].Style.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[6].Value = "";
                    this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.White;
                }
            }
            else
            {
                for (int j = 0; j < this.dgv_follow.Rows.Count; j++)
                {
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[6].Value = "读取失败";
                    this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.Red;
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

        private void btn_set_Click(object sender, EventArgs e)
        {
            byte sEQOfOAD = 0;
            string data = "";
            string str2 = "";
            bool splitFlag = false;
            new List<string>();
            bool flag2 = false;
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < this.dgv_follow.Rows.Count; i++)
            {
                this.dgv_follow.EndEdit();
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[i].Cells[0];
                if (Convert.ToBoolean(cell.Value))
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    str2 = "";
                    if (!((bool)this.dgv_follow.Rows[i].Cells[2].Value) && !((bool)this.dgv_follow.Rows[i].Cells[3].Value))
                    {
                        str2 = "00";
                    }
                    else if (((bool)this.dgv_follow.Rows[i].Cells[2].Value) && !((bool)this.dgv_follow.Rows[i].Cells[3].Value))
                    {
                        str2 = "01";
                    }
                    else if (!((bool)this.dgv_follow.Rows[i].Cells[2].Value) && ((bool)this.dgv_follow.Rows[i].Cells[3].Value))
                    {
                        str2 = "02";
                    }
                    else if (((bool)this.dgv_follow.Rows[i].Cells[2].Value) && ((bool)this.dgv_follow.Rows[i].Cells[3].Value))
                    {
                        str2 = "03";
                    }
                    data = data + this.dgv_follow.Rows[i].Cells[0].ToolTipText + "16" + str2;
                }
            }
            linkdata = Protocol.MakeLink_Data("06", "02", PublicVariable.PIID_W.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag2 = Protocol.SetRequestNormalList(sEQOfOAD, "43", PublicVariable.Address, PublicVariable.Client_Add, data, ref list, PublicVariable.TimeTag, ref splitFlag);
                    break;

                case Link_Math.明文_RN:
                    flag2 = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag2 = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag2 = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag2 = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多属性设置" + (flag2 ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            if (flag2 || (list.Count != 0))
            {
                int num3 = 0;
                for (int j = 0; j < this.dgv_follow.Rows.Count; j++)
                {
                    DataGridViewCheckBoxCell cell2 = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[j].Cells[0];
                    if (Convert.ToBoolean(cell2.Value))
                    {
                        if (list[num3] == "00")
                        {
                            this.dgv_follow.Rows[j].Cells[4].Value = "成功";
                            this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                            this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Aqua;
                        }
                        else
                        {
                            this.dgv_follow.Rows[j].Cells[4].Value = "失败";
                            this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                            this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Red;
                        }
                        num3++;
                    }
                    else
                    {
                        this.dgv_follow.Rows[j].Cells[4].Value = "";
                        this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.White;
                    }
                }
            }
            else
            {
                for (int j = 0; j < this.dgv_follow.Rows.Count; j++)
                {
                    this.dgv_follow.Rows[j].Cells[4].Value = "失败";
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[4].Style.BackColor = Color.Red;
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

        private void btn_set_上报方式_Click(object sender, EventArgs e)
        {
            byte sEQOfOAD = 0;
            string data = "";
            string str2 = "";
            bool splitFlag = false;
            new List<string>();
            bool flag2 = false;
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < this.dgv_follow.Rows.Count; i++)
            {
                this.dgv_follow.EndEdit();
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[i].Cells[0];
                if (Convert.ToBoolean(cell.Value))
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    str2 = "";
                    if (this.dgv_follow.Rows[i].Cells[5].Value != null)
                    {
                        if (this.dgv_follow.Rows[i].Cells[5].Value.ToString() == "主动上报")
                        {
                            str2 = "00";
                        }
                        else if (this.dgv_follow.Rows[i].Cells[5].Value.ToString() == "跟随上报")
                        {
                            str2 = "01";
                        }
                    }
                    else
                    {
                        str2 = "00";
                    }
                    data = string.Concat(new object[] { data, this.dgv_follow.Rows[i].Cells[0].Tag, "16", str2 });
                }
            }
            linkdata = Protocol.MakeLink_Data("06", "02", PublicVariable.PIID_W.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag2 = Protocol.SetRequestNormalList(sEQOfOAD, "43", PublicVariable.Address, PublicVariable.Client_Add, data, ref list, PublicVariable.TimeTag, ref splitFlag);
                    break;

                case Link_Math.明文_RN:
                    flag2 = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag2 = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag2 = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag2 = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多属性设置" + (flag2 ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            if (flag2 || (list.Count != 0))
            {
                int num3 = 0;
                for (int j = 0; j < this.dgv_follow.Rows.Count; j++)
                {
                    DataGridViewCheckBoxCell cell2 = (DataGridViewCheckBoxCell)this.dgv_follow.Rows[j].Cells[0];
                    if (Convert.ToBoolean(cell2.Value))
                    {
                        if (list[num3] == "00")
                        {
                            this.dgv_follow.Rows[j].Cells[6].Value = "设置成功";
                            this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                            this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.Aqua;
                        }
                        else
                        {
                            this.dgv_follow.Rows[j].Cells[6].Value = "设置失败";
                            this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                            this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.Red;
                        }
                        num3++;
                    }
                    else
                    {
                        this.dgv_follow.Rows[j].Cells[6].Value = "";
                        this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.White;
                        this.dgv_follow.Rows[j].Cells[5].Value = "";
                        this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        this.dgv_follow.Rows[j].Cells[5].Style.BackColor = Color.White;
                    }
                }
            }
            else
            {
                for (int j = 0; j < this.dgv_follow.Rows.Count; j++)
                {
                    this.dgv_follow.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    this.dgv_follow.Rows[j].Cells[6].Value = "设置失败";
                    this.dgv_follow.Rows[j].Cells[6].Style.BackColor = Color.Red;
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

        private void btn_上报列表_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    this.lsv_上报列表.ClearNodes();
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    List<string> parseData = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    string data = "33200300";
                    cData = "";
                    parseData.Clear();
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol_2.GetRequestNormal(data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, ref str3, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol_2.Math_明文_RN("00", "01", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol_2.Math_明文_SIDMAC("00", "00", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol_2.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol_2.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.btn_上报列表.Text + "--" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        this.CreateNodes_显示(this.lsv_上报列表, parseData);
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

        private void btn_新增列表_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    this.lsv_上报列表.ClearNodes();
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    List<string> parseData = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    string data = "33200200";
                    cData = "";
                    parseData.Clear();
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol_2.GetRequestNormal(data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, ref str3, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol_2.Math_明文_RN("00", "01", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol_2.Math_明文_SIDMAC("00", "00", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol_2.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol_2.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.btn_新增列表.Text + "--" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        this.CreateNodes_显示新增(this.lsv_上报列表, parseData);
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
        private void CreateNodes_显示(TreeList tl, List<string> List_ParseData)
        {
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select Record_OI,Record_name from follow_collection ", "treeTable1");
            bool flag = false;
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            for (int i = 0; i < List_ParseData.Count; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (List_ParseData[i] == table.Rows[j][0].ToString())
                    {
                        flag = true;
                        object[] nodeData = new object[] { (i + 1).ToString(), List_ParseData[i], table.Rows[j][1].ToString() };
                        tl.AppendNode(nodeData, parentNode);
                        break;
                    }
                    flag = false;
                }
                if (!flag)
                {
                    object[] nodeData = new object[] { (i + 1).ToString(), List_ParseData[i], "请在数据库添加文字说明..." };
                    tl.AppendNode(nodeData, parentNode);
                }
            }
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }
        private void CreateNodes_显示新增(TreeList tl, List<string> List_ParseData)
        {
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select Record_OI,Record_name from follow_collection ", "treeTable1");
            bool flag = false;
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            for (int i = 0; i < List_ParseData.Count; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (List_ParseData[i].Substring(0, 4) == table.Rows[j][0].ToString())
                    {
                        flag = true;
                        object[] nodeData = new object[] { (i + 1).ToString(), List_ParseData[i], table.Rows[j][1].ToString() };
                        tl.AppendNode(nodeData, parentNode);
                        break;
                    }
                    flag = false;
                }
                if (!flag)
                {
                    object[] nodeData = new object[] { (i + 1).ToString(), List_ParseData[i], "请在数据库添加文字说明..." };
                    tl.AppendNode(nodeData, parentNode);
                }
            }
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }

        private void btn_新增上报跟随_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    this.lsv_上报列表.ClearNodes();
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    List<string> parseData = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    string data = "33200201";
                    cData = "";
                    parseData.Clear();
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol_2.GetRequestNormal(data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, ref str3, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol_2.Math_明文_RN("00", "01", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol_2.Math_明文_SIDMAC("00", "00", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol_2.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol_2.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.btn_新增上报跟随.Text + "--" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        this.CreateNodes_显示新增(this.lsv_上报列表, parseData);
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

        private void dgv_follow_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((this.dgv_follow.CurrentCell.ColumnIndex == 5) && (this.dgv_follow.CurrentCell.Value != null))
            {
                if (this.dgv_follow.CurrentCell.Value.ToString() == "主动上报")
                {
                    this.dgv_follow.CurrentCell.Value = "跟随上报";
                }
                else if (this.dgv_follow.CurrentCell.Value.ToString() == "跟随上报")
                {
                    this.dgv_follow.CurrentCell.Value = "主动上报";
                }
            }
        }

        private void Follow_Collection_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.Load_DB();
            DBConnect.DBClose();
        }
        private void Load_DB()
        {
            DataTable table = new DataTable();
            table = DBConnect.Result("select Record_class,Record_OI,Record_name,Record_type,Record_class1 from follow_collection ", "treeTable1");
            int count = table.Rows.Count;
            int num2 = -1;
            for (int i = 0; i < count; i++)
            {
                string[] strArray = table.Rows[i][3].ToString().Split(new char[] { ',' });
                for (int j = 0; j < strArray.Length; j++)
                {
                    if (strArray[j] == this.sele_type)
                    {
                        num2++;
                        this.dgv_follow.Rows.Add(1);
                        this.dgv_follow.Rows[num2].Cells[2].Value = false;
                        this.dgv_follow.Rows[num2].Cells[3].Value = false;
                        this.dgv_follow.Rows[num2].Cells[1].Value = table.Rows[i][1].ToString() + "--" + table.Rows[i][2].ToString();
                        this.dgv_follow.Rows[num2].Cells[0].Value = true;
                        this.dgv_follow.Rows[num2].Cells[0].ToolTipText = table.Rows[i][1].ToString() + table.Rows[i][0].ToString() + "00";
                        this.dgv_follow.Rows[num2].Cells[0].Tag = table.Rows[i][1].ToString() + table.Rows[i][4].ToString() + "00";
                        break;
                    }
                }
            }
        }

        private void rb_单本地_CheckedChanged(object sender, EventArgs e)
        {
            this.sele_type = "11";
            this.dgv_follow.Rows.Clear();
            DBConnect.DBOpen();
            this.Load_DB();
            DBConnect.DBClose();
        }

        private void rb_单远程_CheckedChanged(object sender, EventArgs e)
        {
            this.sele_type = "10";
            this.dgv_follow.Rows.Clear();
            DBConnect.DBOpen();
            this.Load_DB();
            DBConnect.DBClose();
        }

        private void rb_三本地_CheckedChanged(object sender, EventArgs e)
        {
            this.sele_type = "31";
            this.dgv_follow.Rows.Clear();
            DBConnect.DBOpen();
            this.Load_DB();
            DBConnect.DBClose();
        }

        private void rb_三远程_CheckedChanged(object sender, EventArgs e)
        {
            this.sele_type = "30";
            this.dgv_follow.Rows.Clear();
            DBConnect.DBOpen();
            this.Load_DB();
            DBConnect.DBClose();
        }
    }
}
