using DevExpress.XtraPrinting;
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
    public partial class demand : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private bool bIsStop;
        public demand(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        private void CreateNodes_需量(TreeList tl, TreeNode node, string OAD_Buff, List<string> List_ParseData)
        {
            TreeListNode node4;
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select class_OAD_Last2byte,class_dot,class_id from interface where class_OAD_Last2byte='" + OAD_Buff.Substring(4, 4) + "'and class_id='2'", "treeTable");
            string[] strArray = node.Tag.ToString().Split(new char[] { ',' });
            string[] strArray2 = table.Rows[0][1].ToString().Split(new char[] { ',' });
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node3 = tl.AppendNode(new object[] { node.FullPath, OAD_Buff }, parentNode);
            if (List_ParseData.Count == 1)
            {
                node4 = tl.AppendNode(new object[] { strArray[0], "", List_ParseData[0], strArray[0] }, node3);
            }
            else
            {
                node4 = tl.AppendNode(new object[] { node.Text }, node3);
                for (int i = 0; i < (List_ParseData.Count / 2); i++)
                {
                    TreeListNode node5;
                    if (List_ParseData.Count > 2)
                    {
                        node5 = tl.AppendNode(new object[] { strArray[2 * i], "", "", "" }, node4);
                        tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), strArray[2 * i] }, node5);
                        tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), strArray[(2 * i) + 1] }, node5);
                    }
                    else
                    {
                        node5 = tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), strArray[2 * i] }, node4);
                        tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), strArray[(2 * i) + 1] }, node4);
                    }
                }
            }
            tl.ExpandAll();
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }
        private bool Demand_DBtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            TreeNode node4 = new TreeNode();
            TreeNode node5 = new TreeNode();
            this.tree_需量.Nodes.Clear();
            string str = "2";
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            try
            {
                table = DBConnect.Result("select OB_Class,OB_OI,OB_Name,OB_Unit_Type from tree where OB_Class='" + str + "'or OB_OI LIKE '1%'", "treeTable1");
                table2 = DBConnect.Result("select class_id,class_property,class_name,class_OAD_Last2byte,class_unit_0,class_unit_1 from interface where class_id='2'", "treeTable2");
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
                        node = this.tree_需量.Nodes.Add(table.Rows[i][2].ToString());
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

        private void demand_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.Demand_DBtoTreeView();
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
            if (flag)
            {
                this.CreateNodes_需量(this.lsv_需量, node, str3, parseData);
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

        private void tlb_Excel_Click(object sender, EventArgs e)
        {
            PublicVariable.ExportToExcel("需量数据", false, "需量", new IPrintable[] { this.lsv_需量 });
        }

        private void tlb_Exit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void tlb_Read_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    this.bIsStop = false;
                    this.lsv_需量.ClearNodes();
                    for (int i = 0; i < this.tree_需量.GetNodeCount(false); i++)
                    {
                        TreeNode node = this.tree_需量.Nodes[i];
                        if (node.Checked && (this.tree_需量.GetNodeCount(false) == 0))
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

        private void tree_需量_AfterCheck(object sender, TreeViewEventArgs e)
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
