using DevExpress.XtraEditors.Repository;
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
    public partial class NewBatch : Form
    {
        public NewBatch()
        {
            this.InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string toolTipText = "";
                for (int i = 0; i < this.tv_Batch.GetNodeCount(false); i++)
                {
                    TreeNode node = this.tv_Batch.Nodes[i];
                    if (node.Checked && ((node.ToolTipText.Length == 8) || (node.ToolTipText == "特殊645指令")))
                    {
                        toolTipText = node.ToolTipText;
                        if (toolTipText == "")
                        {
                            continue;
                        }
                        this.showToDataGridView(toolTipText, node);
                    }
                    for (int j = 0; j < node.GetNodeCount(false); j++)
                    {
                        TreeNode node2 = node.Nodes[j];
                        if (node2.Checked && ((node2.ToolTipText.Length == 8) || (node2.ToolTipText == "特殊645指令")))
                        {
                            toolTipText = node2.ToolTipText;
                            if (toolTipText == "")
                            {
                                continue;
                            }
                            this.showToDataGridView(toolTipText, node2);
                        }
                        for (int k = 0; k < node2.GetNodeCount(false); k++)
                        {
                            TreeNode node3 = node2.Nodes[k];
                            if (node3.Checked && ((node3.ToolTipText.Length == 8) || (node3.ToolTipText == "特殊645指令")))
                            {
                                toolTipText = node3.ToolTipText;
                                if (toolTipText == "")
                                {
                                    continue;
                                }
                                this.showToDataGridView(toolTipText, node3);
                            }
                            for (int m = 0; m < node3.GetNodeCount(false); m++)
                            {
                                TreeNode node4 = node3.Nodes[m];
                                if (node4.Checked && ((node4.ToolTipText.Length == 8) || (node4.ToolTipText == "特殊645指令")))
                                {
                                    toolTipText = node4.ToolTipText;
                                    if (toolTipText == "")
                                    {
                                        continue;
                                    }
                                    this.showToDataGridView(toolTipText, node4);
                                }
                                for (int n = 0; n < node4.GetNodeCount(false); n++)
                                {
                                    TreeNode node5 = node4.Nodes[n];
                                    if (node5.Checked && ((node5.ToolTipText.Length == 8) || (node5.ToolTipText == "特殊645指令")))
                                    {
                                        toolTipText = node5.ToolTipText;
                                        if (toolTipText != "")
                                        {
                                            this.showToDataGridView(toolTipText, node5);
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
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.treeList1.ClearNodes();
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            try
            {
                this.treeList1.Columns["对象名称"].SortOrder = SortOrder.None;
                TreeListNode focusedNode = this.treeList1.FocusedNode;
                this.treeList1.BeginUpdate();
                int nodeIndex = this.treeList1.GetNodeIndex(focusedNode.NextNode);
                this.treeList1.SetNodeIndex(focusedNode, nodeIndex);
                this.treeList1.EndUpdate();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                this.treeList1.DeleteSelectedNodes();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            PublicVariable.ExportToExcel("**", false, "Sheet1", new IPrintable[] { this.treeList1 });
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            try
            {
                this.treeList1.Columns["对象名称"].SortOrder = SortOrder.None;
                TreeListNode focusedNode = this.treeList1.FocusedNode;
                this.treeList1.BeginUpdate();
                int nodeIndex = this.treeList1.GetNodeIndex(focusedNode.PrevNode);
                this.treeList1.SetNodeIndex(focusedNode, nodeIndex);
                this.treeList1.EndUpdate();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private bool data_DBtoTreeView(string class_id)
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            TreeNode node4 = new TreeNode();
            TreeNode node5 = new TreeNode();
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            try
            {
                table = DBConnect.Result("select OB_Class,OB_OI,OB_Name,OB_Unit_Type from batch_tree where OB_Class='" + class_id + "'", "treeTable1");
                table2 = DBConnect.Result("select class_id,class_property,class_name,class_OAD_Last2byte,class_unit_0,class_unit_1 from batch_interface where class_id='" + class_id + "'", "treeTable2");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][1].ToString() == "") || (table.Rows[i][1].ToString() == " "))
                    {
                        str = "----";
                        str2 = "----";
                    }
                    else
                    {
                        str = table.Rows[i][1].ToString();
                        str2 = table.Rows[i][0].ToString();
                    }
                    if (table.Rows[i][1].ToString().Length == 1)
                    {
                        node = this.tv_Batch.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str;
                        node.Tag = str2;
                    }
                    else if (table.Rows[i][1].ToString().Length == 2)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][2].ToString());
                        node2.ToolTipText = str;
                        node2.Tag = str2;
                    }
                    else if (table.Rows[i][1].ToString().Length == 4)
                    {
                        node3 = node2.Nodes.Add(table.Rows[i][2].ToString());
                        node3.ToolTipText = str;
                        node3.Tag = str2;
                        for (int j = 0; j < table2.Rows.Count; j++)
                        {
                            str3 = str + table2.Rows[j][3].ToString();
                            if (table.Rows[i][3].ToString() == "0")
                            {
                                str4 = table2.Rows[j][4].ToString();
                            }
                            else if (table.Rows[i][3].ToString() == "1")
                            {
                                str4 = table2.Rows[j][5].ToString();
                            }
                            if (table2.Rows[j][1].ToString().Length == 2)
                            {
                                node4 = node3.Nodes.Add(table2.Rows[j][2].ToString());
                                node4.ToolTipText = str3;
                                node4.Tag = str4;
                            }
                            else if (table2.Rows[j][1].ToString().Length == 4)
                            {
                                node5 = node4.Nodes.Add(table2.Rows[j][2].ToString());
                                node5.ToolTipText = str3;
                                node5.Tag = str4;
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

        private void NewBatch_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.tv_Batch.Nodes.Clear();
            this.data_DBtoTreeView("1");
            this.data_DBtoTreeView("2");
            this.Variable_DBtoTreeView();
            this.Param_DBtoTreeView();
            this.SpecialCommangtoTreeView();
            DBConnect.DBClose();
            RepositoryItemComboBox item = new RepositoryItemComboBox();
            item.Items.AddRange(new string[] { "设置", "抄读", "操作", "ESAM回抄", "ESAM更新" });
            this.treeList1.RepositoryItems.Add(item);
            this.treeList1.Columns[3].ColumnEdit = item;
        }
        private bool Param_DBtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            TreeNode node4 = new TreeNode();
            new TreeNode();
            DataTable table = new DataTable();
            string str = "";
            string str2 = "";
            try
            {
                table = DBConnect.Result("select tree_sort, class_OAD,class_name,class_unit from param where tree_sort LIKE '4%' or tree_sort LIKE '5%' or tree_sort LIKE '6%'", "treeTable1");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][0].ToString() == "") || (table.Rows[i][0].ToString() == " "))
                    {
                        str = "----";
                        str2 = "----";
                    }
                    else
                    {
                        str = table.Rows[i][1].ToString();
                        str2 = table.Rows[i][3].ToString();
                    }
                    if (table.Rows[i][0].ToString().Length == 1)
                    {
                        node = this.tv_Batch.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str;
                        node.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 5)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][2].ToString());
                        node2.ToolTipText = str;
                        node2.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 6)
                    {
                        node3 = node2.Nodes.Add(table.Rows[i][2].ToString());
                        node3.ToolTipText = str;
                        node3.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 7)
                    {
                        node4 = node3.Nodes.Add(table.Rows[i][2].ToString());
                        node4.ToolTipText = str;
                        node4.Tag = str2;
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

        private void showToDataGridView(string node_OAD, TreeNode node)
        {
            try
            {
                TreeListNode parentNode = null;
                DBConnect.DBOpen();
                if ((node_OAD.Substring(0, 1) == "0") || (node_OAD.Substring(0, 1) == "1"))
                {
                    string[] strArray = node.FullPath.Split(new char[] { '\\' });
                    string str2 = "";
                    if (strArray.Length == 4)
                    {
                        str2 = strArray[2] + @"\" + strArray[3];
                    }
                    else if (strArray.Length == 5)
                    {
                        str2 = strArray[2] + @"\" + strArray[4];
                    }
                    string str3 = "";
                    if (node_OAD.Substring(0, 1) == "0")
                    {
                        str3 = "1";
                    }
                    else
                    {
                        str3 = "2";
                    }
                    DataTable table = DBConnect.Result("select class_name,class_OAD_Last2byte,Write_Or_Read_Or_Action,class_dot,class_id from batch_interface where class_OAD_Last2byte='" + node_OAD.Substring(4, 4) + "'and class_id='" + str3 + "'", "tree");
                    if (table.Rows.Count != 0)
                    {
                        this.treeList1.BeginUnboundLoad();
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            this.treeList1.AppendNode(new object[] { str2, node_OAD, "", table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), node.Tag.ToString() }, parentNode);
                        }
                        this.treeList1.EndUnboundLoad();
                    }
                }
                else if (node_OAD.Substring(0, 1) == "2")
                {
                    DataTable table2 = DBConnect.Result("select class_OAD,class_name,class_dot from Variable where class_OAD='" + node_OAD + "'", "tree");
                    if (table2.Rows.Count != 0)
                    {
                        this.treeList1.BeginUnboundLoad();
                        for (int i = 0; i < table2.Rows.Count; i++)
                        {
                            this.treeList1.AppendNode(new object[] { table2.Rows[i][1].ToString(), node_OAD, "", "抄读", table2.Rows[i][2].ToString(), node.Tag.ToString() }, parentNode);
                        }
                        this.treeList1.EndUnboundLoad();
                    }
                }
                else if (((node_OAD.Substring(0, 1) == "4") || (node_OAD.Substring(0, 1) == "8")) || (node_OAD.Substring(0, 1) == "3"))
                {
                    DataTable table3 = DBConnect.Result("select class_OAD,class_name,class_dot,Ac_flag,class_type_coll,class_Len_coll,class_data from param where class_OAD='" + node_OAD + "'", "tree");
                    if (table3.Rows.Count != 0)
                    {
                        this.treeList1.BeginUnboundLoad();
                        for (int i = 0; i < table3.Rows.Count; i++)
                        {
                            this.treeList1.AppendNode(new object[] { table3.Rows[i][1].ToString(), node_OAD, table3.Rows[i][6].ToString(), table3.Rows[i][3].ToString(), table3.Rows[i][2].ToString(), node.Tag.ToString(), table3.Rows[i][4].ToString(), table3.Rows[i][5].ToString() }, parentNode);
                        }
                        this.treeList1.EndUnboundLoad();
                    }
                }
                else if (node_OAD == "特殊645指令")
                {
                    DataTable table4 = DBConnect.Result("select CommandFlag,operater_name,data_Region,tree_sort,compare_data from Special_command where tree_sort='" + node.Tag + "'", "tree");
                    if (table4.Rows.Count != 0)
                    {
                        this.treeList1.BeginUnboundLoad();
                        for (int i = 0; i < table4.Rows.Count; i++)
                        {
                            this.treeList1.AppendNode(new object[] { table4.Rows[i][1].ToString(), node_OAD, table4.Rows[i][2].ToString(), node_OAD }, parentNode);
                        }
                        this.treeList1.EndUnboundLoad();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                DBConnect.DBClose();
            }
        }
        private bool SpecialCommangtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            DataTable table = new DataTable();
            new DataTable();
            string str = "";
            string str2 = "";
            try
            {
                table = DBConnect.Result("select tree_sort,CommandFlag,operater_name from Special_command where tree_sort LIKE '9%'", "treeTable1");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][0].ToString() == "") || (table.Rows[i][0].ToString() == " "))
                    {
                        str = "----";
                        str2 = "----";
                    }
                    else
                    {
                        str = table.Rows[i][1].ToString();
                        str2 = table.Rows[i][0].ToString();
                    }
                    if (table.Rows[i][0].ToString().Length == 1)
                    {
                        node = this.tv_Batch.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str;
                        node.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 2)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][2].ToString());
                        node2.ToolTipText = str;
                        node2.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 3)
                    {
                        node3 = node2.Nodes.Add(table.Rows[i][2].ToString());
                        node3.ToolTipText = str;
                        node3.Tag = str2;
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

        private bool Variable_DBtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            TreeNode node4 = new TreeNode();
            TreeNode node5 = new TreeNode();
            DataTable table = new DataTable();
            new DataTable();
            string str = "";
            string str2 = "";
            try
            {
                table = DBConnect.Result("select tree_sort, class_OAD,class_name,class_unit from Variable where tree_sort LIKE '2%' or tree_sort LIKE '3%'", "treeTable1");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][0].ToString() == "") || (table.Rows[i][0].ToString() == " "))
                    {
                        str = "----";
                        str2 = "----";
                    }
                    else
                    {
                        str = table.Rows[i][1].ToString();
                        str2 = table.Rows[i][3].ToString();
                    }
                    if (table.Rows[i][0].ToString().Length == 1)
                    {
                        node = this.tv_Batch.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str;
                        node.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 2)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][2].ToString());
                        node2.ToolTipText = str;
                        node2.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 3)
                    {
                        node3 = node2.Nodes.Add(table.Rows[i][2].ToString());
                        node3.ToolTipText = str;
                        node3.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 4)
                    {
                        node4 = node3.Nodes.Add(table.Rows[i][2].ToString());
                        node4.ToolTipText = str;
                        node4.Tag = str2;
                    }
                    else if (table.Rows[i][0].ToString().Length == 5)
                    {
                        node5 = node4.Nodes.Add(table.Rows[i][2].ToString());
                        node5.ToolTipText = str;
                        node5.Tag = str2;
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
    }
}
