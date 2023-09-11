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
    public partial class display : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private CheckBox[] chkArray = new CheckBox[4];
        private bool bIsStop;
        private string str_查看方式_OAD = "";
        public display(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void btn_查看_Click(object sender, EventArgs e)
        {
            if (this.rd_循环.Checked && !this.rd_按键.Checked)
            {
                this.str_查看方式_OAD = "F3000500";
            }
            else
            {
                this.str_查看方式_OAD = "F3010500";
            }
            this.SetMethod(this.str_查看方式_OAD, (Button)sender);
        }

        private void btn_电能表显示项目_Click(object sender, EventArgs e)
        {
            TreeListNode parentNode = null;
            DisplayItem item = new DisplayItem();
            if (item.ShowDialog() == DialogResult.OK)
            {
                this.lsv_显示.ClearNodes();
                this.txt_当前对象数.Text = DisplayItem.DisplayItems.Count.ToString();
                for (int i = 0; i < DisplayItem.DisplayItems.Count; i++)
                {
                    object[] nodeData = new object[] { (i + 1).ToString(), DisplayItem.DisplayItems[i].SubItems[1].Text, DisplayItem.DisplayItems[i].SubItems[2].Text, DisplayItem.DisplayItems[i].SubItems[3].Text };
                    this.lsv_显示.AppendNode(nodeData, parentNode);
                }
                DisplayItem.DisplayItems.Clear();
            }
        }

        private void btn_全屏_Click(object sender, EventArgs e)
        {
            if (this.rd_循环.Checked && !this.rd_按键.Checked)
            {
                this.str_查看方式_OAD = "F3000600";
            }
            else
            {
                this.str_查看方式_OAD = "F3010600";
            }
            this.SetMethod(this.str_查看方式_OAD, (Button)sender);
        }

        private void btn_上翻_Click(object sender, EventArgs e)
        {
            if (this.rd_循环.Checked && !this.rd_按键.Checked)
            {
                this.str_查看方式_OAD = "F3000400";
            }
            else
            {
                this.str_查看方式_OAD = "F3010400";
            }
            this.SetMethod(this.str_查看方式_OAD, (Button)sender);
        }
        private void CreateNodes_显示(TreeList tl, List<string> List_ParseData)
        {
            try
            {
                DBConnect.DBOpen();
                DataTable table = new DataTable();
                table = DBConnect.Result("select Class_OAD,Class_num,Class_name from display ", "treeTable");
                bool flag = false;
                TreeListNode parentNode = null;
                for (int i = 0; i < (List_ParseData.Count / 2); i++)
                {
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        if ((List_ParseData[i * 2] + List_ParseData[(2 * i) + 1]) == (table.Rows[j][0].ToString() + table.Rows[j][1].ToString()))
                        {
                            tl.BeginUnboundLoad();
                            flag = true;
                            object[] nodeData = new object[] { (i + 1).ToString(), List_ParseData[i * 2], List_ParseData[(2 * i) + 1], table.Rows[j][2].ToString() };
                            tl.AppendNode(nodeData, parentNode);
                            tl.EndUnboundLoad();
                            break;
                        }
                        flag = false;
                    }
                    if (!flag)
                    {
                        tl.BeginUnboundLoad();
                        object[] nodeData = new object[] { (i + 1).ToString(), List_ParseData[i * 2], List_ParseData[(2 * i) + 1], "请在数据库添加文字说明..." };
                        tl.AppendNode(nodeData, parentNode);
                        tl.EndUnboundLoad();
                    }
                }
                DBConnect.DBClose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
                PublicVariable.IsReading = false;
            }
        }
        private bool dispaly_DBtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            DataTable table = new DataTable();
            new DataTable();
            string str = "";
            string str2 = "";
            try
            {
                table = DBConnect.Result("select Class_sort,Class_OAD, Class_num,Class_name,OAD_or_Road from display", "treeTable1");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][0].ToString() == "") || (table.Rows[i][0].ToString() == " "))
                    {
                        str = "--";
                        str2 = "--";
                    }
                    else
                    {
                        str = table.Rows[i][1].ToString();
                        str2 = table.Rows[i][2].ToString() + table.Rows[i][4].ToString();
                    }
                    if (table.Rows[i][0].ToString().Length == 2)
                    {
                        node = this.tree_液晶查看.Nodes.Add(table.Rows[i][3].ToString());
                        node.Tag = str;
                        node.ToolTipText = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 3)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][3].ToString());
                        node2.Tag = str;
                        node2.ToolTipText = str2;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void display_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.dispaly_DBtoTreeView();
            DBConnect.DBClose();
            this.chkArray[0] = this.chk_0;
            this.chkArray[1] = this.chk_1;
            this.chkArray[2] = this.chk_2;
            this.chkArray[3] = this.chk_3;
        }
        private void SetMethod(string OAD_str, Button btn)
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
            StringBuilder cOutData = new StringBuilder(200);
            switch (OAD_str)
            {
                case "F3000300":
                case "F3010300":
                    cData = "00";
                    goto Label_0255;

                case "F3000400":
                case "F3010400":
                    cData = "00";
                    goto Label_0255;

                case "F3000500":
                case "F3010500":
                    {
                        string[] strArray = this.txt_OAD_查看.Text.Split(new char[] { ',' });
                        cData = "";
                        cData = "02035B" + this.txt_OADorRoad.Text.PadLeft(2, '0') + strArray[0];
                        if (this.txt_OADorRoad.Text == "01")
                        {
                            cData = cData + ((strArray.Length - 1)).ToString("X2");
                            for (int i = 1; i < strArray.Length; i++)
                            {
                                cData = cData + strArray[i];
                            }
                        }
                        break;
                    }
                case "F3000600":
                case "F3010600":
                    cData = "12" + Convert.ToInt16(this.txt_全屏时间.Text.PadLeft(8, '0'), 10).ToString("X4");
                    goto Label_0255;

                default:
                    goto Label_0255;
            }
            cData = cData + "11" + this.txt_序号.Text.PadLeft(2, '0') + "12" + Convert.ToInt16(this.txt_查看时间.Text.PadLeft(8, '0'), 10).ToString("X4");
        Label_0255:
            linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), OAD_str + cData, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, OAD_str, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
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
            PublicVariable.Info = btn.Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (!flag)
            {
                PublicVariable.IsReading = false;
            }
        }

        private void tlb_close_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void tlb_Read_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    string[] strArray;
                    this.lsv_显示.ClearNodes();
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
                    if (this.rd_循显.Checked && !this.rd_键显.Checked)
                    {
                        strArray = new string[] { "F3000100", "F3000300", "F3000400", "F3000200" };
                    }
                    else
                    {
                        strArray = new string[] { "F3010100", "F3010300", "F3010400", "F3010200" };
                    }
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (this.bIsStop)
                        {
                            return;
                        }
                        cData = "";
                        parseData.Clear();
                        if ((this.chkArray[i] != null) && this.chkArray[i].Checked)
                        {
                            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[i], PublicVariable.TimeTag);
                            switch (PublicVariable.link_Math)
                            {
                                case Link_Math.纯明文操作:
                                    flag = Protocol_2.GetRequestNormal(strArray[i], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, ref str3, ref parseData, PublicVariable.TimeTag, ref splitFlag);
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
                            PublicVariable.Info = this.chkArray[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (flag)
                            {
                                switch (i)
                                {
                                    case 0:
                                        this.txt_逻辑名.Text = parseData[0];
                                        break;

                                    case 1:
                                        this.txt_显示时间.Text = parseData[0];
                                        break;

                                    case 2:
                                        this.txt_当前对象数.Text = parseData[0];
                                        this.txt_最大对象数.Text = parseData[1];
                                        break;

                                    case 3:
                                        this.CreateNodes_显示(this.lsv_显示, parseData);
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

        private void tlb_Set_Click(object sender, EventArgs e)
        {
            try
            {
                this.lsv_显示.PostEditor();
                if (!PublicVariable.IsReading)
                {
                    string[] strArray;
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string data = "";
                    if (this.rd_循显.Checked && !this.rd_键显.Checked)
                    {
                        strArray = new string[] { "F3000100", "F3000300", "F3000401", "F3000200" };
                    }
                    else
                    {
                        strArray = new string[] { "F3010100", "F3010300", "F3010401", "F3010200" };
                    }
                    string str3 = this.lsv_显示.Nodes.Count.ToString("D2");
                    string[] strArray2 = new string[] { "80", "18", "17", "01029117" };
                    for (int i = 1; i < Convert.ToInt16(str3, 10); i++)
                    {
                        strArray2[3] = strArray2[3] + "029117";
                    }
                    string[] strArray3 = new string[] { "02", "02", "01", str3 + "020101" };
                    for (int j = 1; j < Convert.ToInt16(str3, 10); j++)
                    {
                        strArray3[3] = strArray3[3] + "020101";
                    }
                    List<string> frameData = new List<string>();
                    string str4 = "";
                    string str5 = "";
                    string parseData = "";
                    List<string> list2 = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0x7d0);
                    for (int k = 0; k < 4; k++)
                    {
                        string str9;
                        string str10;
                        int num4;
                        if ((this.chkArray[k] == null) || !this.chkArray[k].Checked)
                        {
                            continue;
                        }
                        switch (k)
                        {
                            case 0:
                                data = this.txt_逻辑名.Text.PadLeft(4, '0');
                                goto Label_034B;

                            case 1:
                                data = this.txt_显示时间.Text.PadLeft(4, '0');
                                goto Label_034B;

                            case 2:
                                data = this.txt_当前对象数.Text.PadLeft(2, '0');
                                goto Label_034B;

                            case 3:
                                data = "";
                                str9 = "";
                                str10 = "";
                                num4 = 0;
                                goto Label_0334;

                            default:
                                goto Label_034B;
                        }
                    Label_0271:
                        str9 = this.lsv_显示.Nodes[num4].GetDisplayText("对象标识OAD").Replace(",", "").Trim();
                        str10 = this.lsv_显示.Nodes[num4].GetDisplayText("显示项").Trim();
                        if (str9.Length == 8)
                        {
                            data = data + "00" + str9 + str10;
                        }
                        else if ((str9.Length % 8) == 0)
                        {
                            data = data + "01" + str9.Substring(0, 8);
                            str9 = str9.Substring(8);
                            data = data + ((str9.Length / 8)).ToString("X2") + str9 + str10;
                        }
                        num4++;
                    Label_0334:
                        if (num4 < this.lsv_显示.Nodes.Count)
                        {
                            goto Label_0271;
                        }
                    Label_034B:
                        cData = "";
                        frameData.Clear();
                        cData = Protocol.From_Type_GetData(ref strArray2[k], ref strArray3[k], ref data, ref frameData);
                        linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[k] + cData, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[k], cData, PublicVariable.TimeTag, ref splitFlag);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str4, ref str5, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str4, ref str5, ref splitFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = this.chkArray[k].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void tlb_Stop_Click(object sender, EventArgs e)
        {
            this.bIsStop = true;
            PublicVariable.IsReading = false;
        }

        private void tlb_删除_Click(object sender, EventArgs e)
        {
            this.lsv_显示.DeleteSelectedNodes();
            this.txt_当前对象数.Text = this.lsv_显示.Nodes.Count.ToString();
        }

        private void tlb_增加_Click(object sender, EventArgs e)
        {
            TreeListNode parentNode = null;
            object[] nodeData = new object[] { (this.lsv_显示.Nodes.Count + 1).ToString() };
            this.lsv_显示.AppendNode(nodeData, parentNode);
        }

        private void tree_液晶查看_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = new TreeNode();
            selectedNode = this.tree_液晶查看.SelectedNode;
            if (selectedNode.ToolTipText != "")
            {
                this.txt_OAD_查看.Text = selectedNode.Tag.ToString();
                this.txt_序号.Text = selectedNode.ToolTipText.Substring(0, 2);
                this.txt_OADorRoad.Text = selectedNode.ToolTipText.Substring(2, 2);
            }
        }

        private void 下翻_Click(object sender, EventArgs e)
        {
            if (this.rd_循环.Checked && !this.rd_按键.Checked)
            {
                this.str_查看方式_OAD = "F3000300";
            }
            else
            {
                this.str_查看方式_OAD = "F3010300";
            }
            this.SetMethod(this.str_查看方式_OAD, (Button)sender);
        }
    }
}
