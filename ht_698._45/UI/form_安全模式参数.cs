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
    public partial class form_安全模式参数 : Form
    {
        private FollowRepoartAndTimeTag followForm;
        public form_安全模式参数(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void btn_Read_显示_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    this.lsv_显示安全参数.ClearNodes();
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
                    string data = "F1010300";
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
                    PublicVariable.Info = this.groupBox2.Text + "--" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        this.CreateNodes_显示(this.lsv_显示安全参数, parseData);
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

        private void btn_Set_显示_Click(object sender, EventArgs e)
        {
            try
            {
                this.lsv_显示安全参数.PostEditor();
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    bool splitFlag = false;
                    string cData = "";
                    string str2 = "F1018100";
                    string str3 = this.lsv_显示安全参数.Nodes.Count.ToString("D2");
                    string str4 = "";
                    string str5 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x7d0);
                    cData = "";
                    string str9 = "";
                    string str10 = "";
                    cData = "01" + str3;
                    for (int i = 0; i < this.lsv_显示安全参数.Nodes.Count; i++)
                    {
                        str9 = this.lsv_显示安全参数.Nodes[i].GetDisplayText("对象标识OAD").Trim();
                        str10 = this.lsv_显示安全参数.Nodes[i].GetDisplayText("安全模式(HEX)").Trim();
                        cData = cData + "020250" + str9.PadLeft(4, '0') + "12" + str10.PadLeft(4, '0');
                    }
                    linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), str2 + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str2, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str4, ref str5, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str4, ref str5, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = "显示安全模式参数--" + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void btn_单项增加_Click(object sender, EventArgs e)
        {
            string str = "F1017F00";
            string str2 = "";
            str2 = "";
            str2 = "020250" + this.txt_OI2.Text.PadLeft(4, '0') + "12" + this.txt_安全.Text.PadLeft(4, '0');
            this.com_ActionMath(this.btn_单项增加, str, str2);
        }

        private void btn_复位_Click(object sender, EventArgs e)
        {
            string str = "F1010100";
            string str2 = "";
            str2 = "";
            str2 = "0F00";
            this.com_ActionMath(this.btn_复位, str, str2);
        }

        private void btn_关闭安全_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                string str = "F1010200";
                string parseData = "";
                bool spliteFlag = false;
                flag = this.Math_comm_操作("06", "01", str, "1600", ref parseData, this.btn_关闭安全, ref spliteFlag);
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

        private void btn_开启安全_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                string str = "F1010200";
                string parseData = "";
                bool spliteFlag = false;
                flag = this.Math_comm_操作("06", "01", str, "1601", ref parseData, this.btn_开启安全, ref spliteFlag);
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

        private void btn_删除_Click(object sender, EventArgs e)
        {
            string str = "F1018000";
            string str2 = "";
            str2 = "";
            str2 = "50" + this.txt_OI.Text.PadLeft(4, '0');
            this.com_ActionMath(this.btn_删除, str, str2);
        }

        private void btn安全读取_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "F1010200";
                string parseData = "";
                bool spliteFlag = false;
                if (this.Math_comm_操作("05", "01", str, "", ref parseData, this.btn安全读取, ref spliteFlag))
                {
                    this.textBox1.Text = (parseData == "00") ? "已关闭" : "已启用";
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
        private void com_ActionMath(object sender, string str_OAD, string str_data)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    bool splitFlag = false;
                    string str = "";
                    string str2 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x7d0);
                    linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), str_OAD + str_data, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str_OAD, str_data, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str, ref str2, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str, ref str2, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = ((Button)sender).Text + "--" + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            if (List_ParseData.Count != 0)
            {
                for (int i = 0; i < (List_ParseData.Count / 2); i++)
                {
                    object[] nodeData = new object[] { (i + 1).ToString(), List_ParseData[i * 2], Convert.ToInt32(List_ParseData[(2 * i) + 1], 10).ToString("X") };
                    tl.AppendNode(nodeData, parentNode);
                }
            }
            else
            {
                tl.AppendNode(new object[] { "", "NULL", "NULL" }, parentNode);
            }
            tl.EndUnboundLoad();
        }
        private bool Math_comm_操作(string str_操作方式, string 操作属性, string str_OAD, string data_输入, ref string ParseData, object disButton, ref bool SpliteFlag)
        {
            if (PublicVariable.IsReading)
            {
                return false;
            }
            PublicVariable.IsReading = true;
            bool flag = false;
            string cData = "";
            string str2 = "";
            string str3 = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            cData = "";
            list.Clear();
            linkdata = Protocol.MakeLink_Data(str_操作方式, 操作属性, PublicVariable.PIID_R.ToString("X2"), str_OAD + data_输入, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    if (str_操作方式 != "05")
                    {
                        if (str_操作方式 == "06")
                        {
                            flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str_OAD, data_输入, PublicVariable.TimeTag, ref SpliteFlag);
                        }
                        break;
                    }
                    flag = Protocol.GetRequestNormal(str_OAD, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref SpliteFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref ParseData);
                    }
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref ParseData, ref list, ref mAC, ref SpliteFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref ParseData, ref list, ref mAC, ref SpliteFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref ParseData, ref list, ref mAC, ref str2, ref str3, ref SpliteFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref ParseData, ref list, ref mAC, ref str2, ref str3, ref SpliteFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = ((Button)disButton).Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            return flag;
        }

        private void tlb_删除_Click(object sender, EventArgs e)
        {
            this.lsv_显示安全参数.DeleteSelectedNodes();
        }

        private void tlb_增加_Click(object sender, EventArgs e)
        {
            TreeListNode parentNode = null;
            object[] nodeData = new object[] { (this.lsv_显示安全参数.Nodes.Count + 1).ToString() };
            this.lsv_显示安全参数.AppendNode(nodeData, parentNode);
        }
    }
}
