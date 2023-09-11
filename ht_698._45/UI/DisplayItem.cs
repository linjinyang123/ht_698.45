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
    public partial class DisplayItem : Form
    {
        public static List<ListViewItem> DisplayItems = new List<ListViewItem>();
        public DisplayItem()
        {
            this.InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = new TreeNode();
                TreeNode node2 = new TreeNode();
                for (int i = 0; i < this.tv_disItem.Nodes.Count; i++)
                {
                    node = this.tv_disItem.Nodes[i];
                    for (int j = 0; j < node.GetNodeCount(false); j++)
                    {
                        ListViewItem item = new ListViewItem();
                        node2 = node.Nodes[j];
                        string[] strArray = node2.Text.Split(new char[] { ':' });
                        if (node2.Checked)
                        {
                            item.Text = (this.lsv_Dis.Items.Count + 1).ToString();
                            item.SubItems.Add(node2.ToolTipText.ToString());
                            item.SubItems.Add(node2.Tag.ToString().Substring(0, 2));
                            item.SubItems.Add(strArray[1]);
                            this.lsv_Dis.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.lsv_Dis.Items.Count - 1; i >= 0; i--)
                {
                    this.lsv_Dis.Items.Remove(this.lsv_Dis.Items[i]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = new ListViewItem();
                if (this.lsv_Dis.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要移动的项!");
                }
                else
                {
                    for (int i = 0; i < this.lsv_Dis.Items.Count; i++)
                    {
                        if (this.lsv_Dis.Items[i].Selected && (i != (this.lsv_Dis.Items.Count - 1)))
                        {
                            item = this.lsv_Dis.Items[i];
                            this.lsv_Dis.Items.Remove(this.lsv_Dis.Items[i]);
                            this.lsv_Dis.Items.Insert(i + 1, item);
                            return;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            for (int i = 0; i < this.lsv_Dis.Items.Count; i++)
            {
                DisplayItems.Add(this.lsv_Dis.Items[i]);
            }
            base.Close();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.lsv_Dis.Items.Count; i++)
                {
                    if (this.lsv_Dis.Items[i].Selected)
                    {
                        this.lsv_Dis.Items.Remove(this.lsv_Dis.Items[i]);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = new ListViewItem();
                if (this.lsv_Dis.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要移动的项!");
                }
                else
                {
                    for (int i = 0; i < this.lsv_Dis.Items.Count; i++)
                    {
                        if (this.lsv_Dis.Items[i].Selected && (i != 0))
                        {
                            item = this.lsv_Dis.Items[i];
                            this.lsv_Dis.Items.Remove(this.lsv_Dis.Items[i]);
                            this.lsv_Dis.Items.Insert(i - 1, item);
                            return;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private bool DBtoTree(string code)
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            this.tv_disItem.Nodes.Clear();
            DataTable table = new DataTable();
            string str = "";
            string str2 = "";
            try
            {
                table = DBConnect.Result("select Class_OAD,Class_num,Class_name,Class_sort,OAD_or_Road from display where Class_OAD like '" + code + "%'", "DisplayItems");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][2].ToString() == "") || (table.Rows[i][2].ToString() == " "))
                    {
                        str = table.Rows[i][0].ToString();
                        str2 = "----";
                    }
                    else
                    {
                        str = table.Rows[i][0].ToString();
                        str2 = table.Rows[i][1].ToString() + table.Rows[i][4].ToString();
                    }
                    if (table.Rows[i][3].ToString().Length == 2)
                    {
                        node = this.tv_disItem.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str;
                        node.Tag = str2;
                    }
                    else if (table.Rows[i][3].ToString().Length == 3)
                    {
                        if (code == "")
                        {
                            node2 = node.Nodes.Add(table.Rows[i][0].ToString() + ":" + table.Rows[i][2].ToString());
                            node2.ToolTipText = str;
                            node2.Tag = str2;
                        }
                        else
                        {
                            node3 = this.tv_disItem.Nodes.Add(table.Rows[i][0].ToString() + ":" + table.Rows[i][2].ToString());
                            node3.ToolTipText = str;
                            node3.Tag = str2;
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

        private void DisplayItem_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.DBtoTree("");
            DBConnect.DBClose();
        }

        private void txt_Help_TextChanged(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.DBtoTree(this.txt_Help.Text);
            DBConnect.DBClose();
        }
    }
}
