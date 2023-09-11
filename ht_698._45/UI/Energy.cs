
using DevExpress.XtraPrinting;
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
    public partial class Energy : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private bool bIsStop;
        public Energy(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        private bool Energy_DBtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            TreeNode node4 = new TreeNode();
            TreeNode node5 = new TreeNode();
            this.tree_电能.Nodes.Clear();
            string str = "1";
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            try
            {
                table = DBConnect.Result("select OB_Class,OB_OI,OB_Name,OB_Unit_Type from tree where OB_Class='" + str + "'or OB_OI LIKE '0%'", "treeTable1");
                table2 = DBConnect.Result("select class_id,class_property,class_name,class_OAD_Last2byte,class_unit_0,class_unit_1 from interface where class_id='1'", "treeTable2");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][1].ToString() == "") || (table.Rows[i][1].ToString() == " "))
                    {
                        str2 = "----";
                        str3 = "----";
                    }
                    else
                    {
                        str2 = table.Rows[i][1].ToString();
                        str3 = table.Rows[i][0].ToString();
                    }
                    if (table.Rows[i][1].ToString().Length == 1)
                    {
                        node = this.tree_电能.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str2;
                        node.Tag = str3;
                    }
                    else if (table.Rows[i][1].ToString().Length == 2)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][2].ToString());
                        node2.ToolTipText = str2;
                        node2.Tag = str3;
                    }
                    else if (table.Rows[i][1].ToString().Length == 4)
                    {
                        node3 = node2.Nodes.Add(table.Rows[i][2].ToString());
                        node3.ToolTipText = str2;
                        node3.Tag = str3;
                        for (int j = 0; j < table2.Rows.Count; j++)
                        {
                            str4 = str2 + table2.Rows[j][3].ToString();
                            if (table.Rows[i][3].ToString() == "0")
                            {
                                str5 = table2.Rows[j][4].ToString();
                            }
                            else if (table.Rows[i][3].ToString() == "1")
                            {
                                str5 = table2.Rows[j][5].ToString();
                            }
                            if (table2.Rows[j][1].ToString().Length == 2)
                            {
                                node4 = node3.Nodes.Add(table2.Rows[j][2].ToString());
                                node4.ToolTipText = str4;
                                node4.Tag = str5;
                            }
                            else if (table2.Rows[j][1].ToString().Length == 4)
                            {
                                node5 = node4.Nodes.Add(table2.Rows[j][2].ToString());
                                node5.ToolTipText = str4;
                                node5.Tag = str5;
                            }
                        }
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

        private void Energy_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.Energy_DBtoTreeView();
            DBConnect.DBClose();
        }
        private void ReadFlag(TreeNode node)
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            List<string> parseData = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x3e8);
            string toolTipText = node.ToolTipText;
            string str7 = "";
            cData = "";
            parseData.Clear();
            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), toolTipText, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol_2.GetRequestNormal(toolTipText, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, ref str3, ref parseData, PublicVariable.TimeTag, ref splitFlag);
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
            PublicVariable.Info = node.FullPath + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            str7 = DBConnect.Result("select class_OAD_Last2byte,class_dot,class_id from interface where class_OAD_Last2byte='" + toolTipText.Substring(4, 4) + "'and class_id='1'", "treeTable").Rows[0][1].ToString();
            this.lsv_电能量.BeginUnboundLoad();
            TreeListNode parentNode = null;
            if (flag)
            {
                TreeListNode node3;
                if (parseData.Count <= 1)
                {
                    string[] strArray = node.Tag.ToString().Split(new char[] { ',' })[0].Split(new char[] { ':' });
                    string[] strArray3 = str7.Split(new char[] { ',' });
                    node3 = this.lsv_电能量.AppendNode(new object[] { node.FullPath, toolTipText }, parentNode);
                    if (str7 == "")
                    {
                        if (strArray.Length > 1)
                        {
                            this.lsv_电能量.AppendNode(new object[] { "", "", parseData[0], strArray[1] }, node3);
                        }
                        else
                        {
                            this.lsv_电能量.AppendNode(new object[] { "", "", parseData[0], strArray[0] }, node3);
                        }
                    }
                    else if (strArray.Length > 1)
                    {
                        this.lsv_电能量.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(parseData[0], Convert.ToInt16(strArray3[0])), strArray[1] }, node3);
                    }
                    else
                    {
                        this.lsv_电能量.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(parseData[0], Convert.ToInt16(strArray3[0])), strArray[0] }, node3);
                    }
                }
                else
                {
                    string[] strArray5 = node.Tag.ToString().Split(new char[] { ',' });
                    string[] strArray6 = str7.Split(new char[] { ',' });
                    node3 = this.lsv_电能量.AppendNode(new object[] { node.FullPath, toolTipText }, parentNode);
                    for (int i = 0; i < parseData.Count; i++)
                    {
                        string[] strArray4;
                        if (parseData.Count > strArray5.Length)
                        {
                            strArray4 = strArray5[0].Split(new char[] { ':' });
                        }
                        strArray4 = strArray5[i].Split(new char[] { ':' });
                        if (str7 != "")
                        {
                            this.lsv_电能量.AppendNode(new object[] { strArray4[0], "", PublicVariable.GetFloatstrFromBCDStr(parseData[i], Convert.ToInt16(strArray6[i])), strArray4[1] }, node3);
                        }
                        else
                        {
                            this.lsv_电能量.AppendNode(new object[] { strArray4[0], "", parseData[i], strArray4[1] }, node3);
                        }
                    }
                }
            }
            this.lsv_电能量.ExpandAll();
            this.lsv_电能量.EndUnboundLoad();
            DBConnect.DBClose();
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

        private void tlb_Excel_Click(object sender, EventArgs e)
        {
            PublicVariable.ExportToExcel("电能量数据", false, "电能量", new IPrintable[] { this.lsv_电能量 });
        }

        private void tlb_Exit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void tlb_Read_Click(object sender, EventArgs e)
        {
            try
            {
                string b= "1";
                if (!PublicVariable.IsReading)
                {
                    this.bIsStop = false;
                    this.lsv_电能量.ClearNodes();
                    for (int i = 0; i < this.tree_电能.GetNodeCount(false); i++)
                    {
                        TreeNode node = this.tree_电能.Nodes[i];
                        if (node.Checked && (this.tree_电能.GetNodeCount(false) == 0))
                        {
                            if (this.bIsStop)
                            {
                                return;
                            }
                            if (node.ToolTipText.Length != 8)
                            {
                                continue;
                            }
                            this.ReadFlag(node);
                        }
                        for (int j = 0; j < node.GetNodeCount(false); j++)
                        {
                            TreeNode node2 = node.Nodes[j];
                            if (node2.Checked && (node2.GetNodeCount(false) == 0))
                            {
                                if (this.bIsStop)
                                {
                                    return;
                                }
                                if (node2.ToolTipText.Length != 8)
                                {
                                    continue;
                                }
                                this.ReadFlag(node2);
                            }
                            for (int k = 0; k < node2.GetNodeCount(false); k++)
                            {
                                TreeNode node3 = node2.Nodes[k];
                                if (node3.Checked && (node3.GetNodeCount(false) == 0))
                                {
                                    if (this.bIsStop)
                                    {
                                        return;
                                    }
                                    if (node3.ToolTipText.Length != 8)
                                    {
                                        continue;
                                    }
                                    this.ReadFlag(node3);
                                }
                                for (int m = 0; m < node3.GetNodeCount(false); m++)
                                {
                                    TreeNode node4 = node3.Nodes[m];
                                    if (node4.Checked)
                                    {
                                        if (this.bIsStop)
                                        {
                                            return;
                                        }
                                        if (node4.ToolTipText.Length == 8)
                                        {
                                            this.ReadFlag(node4);
                                        }
                                    }
                                    else
                                    {
                                        for (int n = 0; n < node4.GetNodeCount(false); n++)
                                        {
                                            TreeNode node5 = node4.Nodes[n];
                                            if (node5.Checked && (node5.GetNodeCount(false) == 0))
                                            {
                                                if (this.bIsStop)
                                                {
                                                    return;
                                                }
                                                if (node5.ToolTipText.Length == 8)
                                                {
                                                    this.ReadFlag(node5);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                PublicVariable.IsReading = false;
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                PublicVariable.IsReading = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void tlb_Stop_Click(object sender, EventArgs e)
        {
            this.bIsStop = true;
            PublicVariable.IsReading = false;
        }
        private void tree_电能_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            try
            {
                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
