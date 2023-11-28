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
    public partial class Variable : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private bool bIsStop;
        public Variable(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        private void CreateNodes_变量(TreeList tl, TreeNode node, string OAD_Buff, List<string> List_ParseData)
        {
            TreeListNode node4;
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select class_OAD,class_dot,class_unit,class_name,class_Type from Variable where class_OAD='" + OAD_Buff + "'", "treeTable");
            string[] strArray = table.Rows[0][2].ToString().Split(new char[] { ',' });
            string[] strArray2 = table.Rows[0][1].ToString().Split(new char[] { ',' });
            string[] strArray4 = table.Rows[0][4].ToString().Split(new char[] { ',' });
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node3 = tl.AppendNode(new object[] { node.FullPath, OAD_Buff, "", "" }, parentNode);
            if (List_ParseData.Count == 1)
            {
                if (OAD_Buff.Substring(4, 4) == "0100")
                {
                    node4 = tl.AppendNode(new object[] { node.Text, "", List_ParseData[0], strArray[0] }, node3);
                }
                else
                {
                    node4 = tl.AppendNode(new object[] { node.Text, "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[0], Convert.ToInt16(strArray2[0])), strArray[0] }, node3);
                }
            }
            else
            {
                string[] strArray3;
                TreeListNode node5;
                TreeListNode node6;
                node4 = tl.AppendNode(new object[] { node.Text, "", "", table.Rows[0][3].ToString() }, node3);
                if (((OAD_Buff == "21310200") || (OAD_Buff == "21320200")) || (OAD_Buff == "21330200"))
                {
                    for (int i = 0; i < 2; i++)
                    {
                        node6 = tl.AppendNode(new object[] { strArray4[i] }, node4);
                        for (int j = (i * List_ParseData.Count) / 2; j < (((i + 1) * List_ParseData.Count) / 2); j++)
                        {
                            strArray3 = strArray[j].Split(new char[] { ':' });
                            if (strArray3.Length > 1)
                            {
                                node5 = tl.AppendNode(new object[] { strArray3[0], "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[j], Convert.ToInt16(strArray2[j])), strArray3[1] }, node6);
                            }
                            else
                            {
                                node5 = tl.AppendNode(new object[] { strArray3[0], "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[j], Convert.ToInt16(strArray2[j])) }, node6);
                            }
                        }
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "2140") || (OAD_Buff.Substring(0, 4) == "2141"))
                {
                    for (int i = 0; i < (List_ParseData.Count / 2); i++)
                    {
                        if (List_ParseData.Count > 2)
                        {
                            node5 = tl.AppendNode(new object[] { strArray[2 * i], "", "", "" }, node4);
                            node6 = tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), strArray[2 * i] }, node5);
                            tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), strArray[(2 * i) + 1] }, node5);
                        }
                        else
                        {
                            node5 = tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), strArray[2 * i] }, node4);
                            node6 = tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), strArray[(2 * i) + 1] }, node4);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < List_ParseData.Count; i++)
                    {
                        strArray3 = strArray[i].Split(new char[] { ':' });
                        if (strArray3.Length > 1)
                        {
                            node5 = tl.AppendNode(new object[] { strArray3[0], "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], Convert.ToInt16(strArray2[i])), strArray3[1] }, node4);
                        }
                        else
                        {
                            node5 = tl.AppendNode(new object[] { strArray3[0], "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], Convert.ToInt16(strArray2[i])) }, node4);
                        }
                    }
                }
            }
            tl.ExpandAll();
            tl.EndUnboundLoad();
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
            StringBuilder cOutData = new StringBuilder(200);
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
                this.CreateNodes_变量(this.lsv_变量, node, str3, parseData);
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
            PublicVariable.ExportToExcel("变量数据", false, "变量", new IPrintable[] { this.lsv_变量 });
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
                    this.lsv_变量.ClearNodes();
                    for (int i = 0; i < this.tree_变量.GetNodeCount(false); i++)
                    {
                        TreeNode node = this.tree_变量.Nodes[i];
                        if (node.Checked && (this.tree_变量.GetNodeCount(false) == 0))
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

        private void tree_变量_AfterCheck(object sender, TreeViewEventArgs e)
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
        private bool Variable_DBtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            TreeNode node4 = new TreeNode();
            TreeNode node5 = new TreeNode();
            this.tree_变量.Nodes.Clear();
            DataTable table = new DataTable();
            new DataTable();
            string str = "";
            try
            {
                table = DBConnect.Result("select tree_sort, class_OAD,class_name from Variable where tree_sort LIKE '2%' or tree_sort LIKE '3%'", "treeTable1");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for(int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][0].ToString() == "") || (table.Rows[i][0].ToString() == " "))
                    {
                        str = "----";
                    }
                    else
                    {
                        str = table.Rows[i][1].ToString();
                    }
                    if (table.Rows[i][0].ToString().Length == 1)
                    {
                        node = this.tree_变量.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str;
                    }
                    else if (table.Rows[i][0].ToString().Length == 2)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][2].ToString());
                        node2.ToolTipText = str;
                    }
                    else if (table.Rows[i][0].ToString().Length == 3)
                    {
                        node3 = node2.Nodes.Add(table.Rows[i][2].ToString());
                        node3.ToolTipText = str;
                    }
                    else if (table.Rows[i][0].ToString().Length == 4)
                    {
                        node4 = node3.Nodes.Add(table.Rows[i][2].ToString());
                        node4.ToolTipText = str;
                    }
                    else if (table.Rows[i][0].ToString().Length == 5)
                    {
                        node4.Nodes.Add(table.Rows[i][2].ToString()).ToolTipText = str;
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

        private void Variable_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.Variable_DBtoTreeView();
            DBConnect.DBClose();
        }

        private void tsb_展开_Click(object sender, EventArgs e)
        {
            if (this.tsb_展开.Text == "节点展开")
            {
                this.lsv_变量.ExpandAll();
                this.tsb_展开.Text = "节点收起";
            }
            else if (this.tsb_展开.Text == "节点收起")
            {
                this.lsv_变量.CollapseAll();
                this.tsb_展开.Text = "节点展开";
            }
        }
    }
}
