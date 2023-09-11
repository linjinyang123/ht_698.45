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
    public partial class Event : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private bool bIsStop;
        public Event(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        private void CreateNodes_关联属性表(TreeList tl, TreeNode node, string OAD_Buff, List<List<string>> List_ParseData_二级)
        {
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select ref_PropertyTag,RCSD_OAD,RCSD_Name from record_display where ref_PropertyTag='2'", "treeTable");
            List<string> list = new List<string>();
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node3 = tl.AppendNode(new object[] { node.FullPath, OAD_Buff, "", "", node.Text }, parentNode);
            TreeListNode node4 = tl.AppendNode(new object[] { "", "", "共" + List_ParseData_二级.Count.ToString() + "列", "", "", "关联属性列表共" + List_ParseData_二级.Count.ToString() + "列" }, node3);
            for (int i = 0; i < List_ParseData_二级.Count; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (List_ParseData_二级[i][0] == table.Rows[j][1].ToString())
                    {
                        list.Add(table.Rows[j][2].ToString());
                        break;
                    }
                }
                if (list.Count != (i + 1))
                {
                    list.Add("请在数据库添加属性说明！");
                }
                object[] nodeData = new object[] { "", "", "", "第" + ((i + 1)).ToString() + "列", "共" + List_ParseData_二级[i].Count.ToString() + "项", list[i] };
                TreeListNode node5 = tl.AppendNode(nodeData, node4);
                for (int k = 0; k < List_ParseData_二级[i].Count; k++)
                {
                    tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData_二级[i][k]), "" }, node5);
                }
            }
            tl.ExpandToLevel(0);
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }

        private void CreateNodes_记录表(TreeList tl, TreeNode node, string Rercord_OAD, string rel_Num, List<string> Rel_RCSD, string Record_Num, List<List<List<string>>> list_ParseData_多级)
        {
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select ref_PropertyTag,RCSD_OAD,RCSD_Name,RCSD_Dot,RCSD_txt from record_display where ref_PropertyTag='2' or ref_PropertyTag='22'", "treeTable");
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node3 = tl.AppendNode(new object[] { node.FullPath, Rercord_OAD, "", "", node.Text }, parentNode);
            TreeListNode node4 = tl.AppendNode(new object[] { "", "", "共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "列", "", "", "关联属性列表共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "列" }, node3);
            for (int i = 0; i < Rel_RCSD.Count; i++)
            {
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    if (Rel_RCSD[i] == table.Rows[k][1].ToString())
                    {
                        list.Add(table.Rows[k][2].ToString());
                        list2.Add(table.Rows[k][3].ToString());
                        list3.Add(table.Rows[k][4].ToString());
                        break;
                    }
                }
                if (list.Count != (i + 1))
                {
                    list.Add("请添加数据库相关说明！");
                    list2.Add("");
                    list3.Add("");
                }
                object[] nodeData = new object[] { "", "", "", "第" + ((i + 1)).ToString() + "列", Rel_RCSD[i], list[i] };
                tl.AppendNode(nodeData, node4);
            }
            tl.AppendNode(new object[] { "", "", "共" + Record_Num + "条", "", "", "记录（行）表共" + Record_Num + "行" }, node3);
            //TreeListNode node5 = new TreeListNode();
            //TreeListNode node6 = new TreeListNode();
            //new TreeListNode();
            TreeListNode node5 ;
            TreeListNode node6 ;
            //new TreeListNode();
            for (int j = 0; j < list_ParseData_多级.Count; j++)
            {
                object[] nodeData = new object[] { "", "", "", "第" + ((j + 1)).ToString() + "条记录", "", "" };
                node5 = tl.AppendNode(nodeData, node3);
                for (int k = 0; k < list_ParseData_多级[j].Count; k++)
                {
                    string[] strArray = list2[k].Split(new char[] { ',' });
                    string[] strArray2 = list3[k].Split(new char[] { ',' });
                    object[] objArray6 = new object[] { "", "", "", "第" + ((k + 1)).ToString() + "列", "共" + list_ParseData_多级[j][k].Count.ToString() + "项", list[k] };
                    node6 = tl.AppendNode(objArray6, node5);
                    for (int m = 0; m < list_ParseData_多级[j][k].Count; m++)
                    {
                        if (strArray.Length > m)
                        {
                            if ((strArray[m] != "") && (strArray2.Length > m))
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])), strArray2[m] }, node6);
                            }
                            else if ((strArray[m] != "") && (strArray2.Length <= m))
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])), "" }, node6);
                            }
                            else if (strArray2.Length > m)
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]), strArray2[m] }, node6);
                            }
                            else
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node6);
                            }
                        }
                        else if (strArray2.Length > m)
                        {
                            tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]), strArray2[m] }, node6);
                        }
                        else
                        {
                            tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node6);
                        }
                    }
                }
            }
            tl.ExpandToLevel(0);
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }

        private void CreateNodes_记录表1(TreeList tl, TreeNode node, string Rercord_OAD, string rel_Num, List<string> Rel_RCSD, string Record_Num, List<List<List<string>>> list_ParseData_多级)
        {
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select ref_PropertyTag,RCSD_OAD,RCSD_Name,RCSD_Dot,RCSD_txt from record_display where ref_PropertyTag='2' or ref_PropertyTag='22'", "treeTable");
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            string item = "";
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node3 = tl.AppendNode(new object[] { node.FullPath, Rercord_OAD, "", "", node.Text }, parentNode);
            TreeListNode node4 = tl.AppendNode(new object[] { "", "", "共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "列", "", "", "关联属性列表共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "列" }, node3);
            for (int i = 0; i < Rel_RCSD.Count; i++)
            {
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    if (Rel_RCSD[i] == table.Rows[k][1].ToString())
                    {
                        list.Add(table.Rows[k][2].ToString());
                        list2.Add(table.Rows[k][3].ToString());
                        list3.Add(table.Rows[k][4].ToString());
                        break;
                    }
                }
                if ((((Rel_RCSD[i] == "33140207") || (Rel_RCSD[i].Substring(0, 4) == "4014")) || ((Rel_RCSD[i].Substring(0, 4) == "4015") || (Rel_RCSD[i].Substring(0, 4) == "4016"))) || (((Rel_RCSD[i].Substring(0, 4) == "4017") || (Rel_RCSD[i].Substring(0, 4) == "4116")) || ((Rel_RCSD[i].Substring(0, 4) == "401A") || (Rel_RCSD[i].Substring(0, 4) == "401B"))))
                {
                    for (int m = 0; m < list_ParseData_多级.Count; m++)
                    {
                        int num4 = 0;
                        int num5 = 0;
                        int num6 = 0;
                        int num7 = 0;
                        if (Rel_RCSD[i].Substring(0, 4) == "4116")
                        {
                            num4 = 2;
                        }
                        else
                        {
                            num4 = 3;
                        }
                        if ((Rel_RCSD[i].Substring(0, 4) == "401A") || (Rel_RCSD[i].Substring(0, 4) == "401B"))
                        {
                            num7 = 13;
                            num5 = ((list_ParseData_多级[m][i].Count - 13) / num4) + 13;
                        }
                        else
                        {
                            num5 = list_ParseData_多级[m][i].Count / num4;
                        }
                        for (int n = num7 + num6; n < num5; n++)
                        {
                            item = "";
                            for (int num9 = 0; num9 < num4; num9++)
                            {
                                item = item + list_ParseData_多级[m][i][n];
                                list_ParseData_多级[m][i].RemoveAt(n);
                            }
                            list_ParseData_多级[m][i].Insert(n, item);
                            num6++;
                        }
                    }
                }
                if (list.Count != (i + 1))
                {
                    list.Add("请添加数据库相关说明！");
                    list2.Add("");
                    list3.Add("");
                }
                object[] nodeData = new object[] { "", "", "", "第" + ((i + 1)).ToString() + "列", Rel_RCSD[i], list[i] };
                tl.AppendNode(nodeData, node4);
            }
            tl.AppendNode(new object[] { "", "", "共" + Record_Num + "条", "", "", "记录（行）表共" + Record_Num + "行" }, node3);
            //TreeListNode node5 = new TreeListNode();
            //TreeListNode node6 = new TreeListNode();
            //new TreeListNode();
            TreeListNode node5 ;
            TreeListNode node6 ;
           // new TreeListNode();
            for (int j = 0; j < list_ParseData_多级.Count; j++)
            {
                object[] nodeData = new object[] { "", "", "", "第" + ((j + 1)).ToString() + "条记录", "", "" };
                node5 = tl.AppendNode(nodeData, node3);
                for (int k = 0; k < list_ParseData_多级[j].Count; k++)
                {
                    string[] strArray = list2[k].Split(new char[] { ',' });
                    string[] strArray2 = list3[k].Split(new char[] { ',' });
                    object[] objArray6 = new object[] { "", "", "", "第" + ((k + 1)).ToString() + "列", "共" + list_ParseData_多级[j][k].Count.ToString() + "项", list[k] };
                    node6 = tl.AppendNode(objArray6, node5);
                    for (int m = 0; m < list_ParseData_多级[j][k].Count; m++)
                    {
                        if (strArray.Length > m)
                        {
                            if ((strArray[m] != "") && (strArray2.Length > m))
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])), strArray2[m] }, node6);
                            }
                            else if ((strArray[m] != "") && (strArray2.Length <= m))
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])), "" }, node6);
                            }
                            else if (strArray2.Length > m)
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]), strArray2[m] }, node6);
                            }
                            else
                            {
                                tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node6);
                            }
                        }
                        else if (strArray2.Length > m)
                        {
                            tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]), strArray2[m] }, node6);
                        }
                        else
                        {
                            tl.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node6);
                        }
                    }
                }
            }
            tl.ExpandToLevel(0);
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }

        private void CreateNodes_属性(TreeList tl, TreeNode node, string OAD_Buff, List<List<string>> List_ParseData_二级)
        {
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select Record_OI,ref_PropertyTag,Record_Property,RCSD_Name,RCSD_dot,RCSD_txt from record_display where Record_OI='" + OAD_Buff.Substring(0, 4) + "'and ref_PropertyTag='3'", "treeTable");
            string str = "";
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (OAD_Buff.Substring(4, 2) == table.Rows[i][2].ToString())
                {
                    str = table.Rows[i][3].ToString();
                    string[] strArray = table.Rows[i][5].ToString().Split(new char[] { ',' });
                    string[] strArray2 = table.Rows[i][4].ToString().Split(new char[] { ',' });
                    TreeListNode node3 = tl.AppendNode(new object[] { node.FullPath, OAD_Buff, "", "", table.Rows[i][3].ToString() }, parentNode);
                    TreeListNode node4 = tl.AppendNode(new object[] { "", "", "共" + List_ParseData_二级.Count.ToString() + "项", "", "", str }, node3);
                    for (int j = 0; j < List_ParseData_二级.Count; j++)
                    {
                        object[] nodeData = new object[] { "", "", "", "第" + ((j + 1)).ToString() + "项", "", "" };
                        TreeListNode node5 = this.treeList.AppendNode(nodeData, node4);
                        for (int k = 0; k < List_ParseData_二级[j].Count; k++)
                        {
                            if (((node.Tag.ToString() == "024") && (OAD_Buff.Substring(4, 2) == "05")) || ((node.Tag.ToString() == "07") && (OAD_Buff.Substring(4, 2) == "06")))
                            {
                                PublicVariable.GetFloatstrFromBCDStr(List_ParseData_二级[j][k], Convert.ToInt16(strArray2[k]));
                                this.treeList.AppendNode(new object[] { "", "", "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData_二级[j][k], Convert.ToInt16(strArray2[k])), strArray[(2 * j) + k] }, node5);
                            }
                            else if (((((node.Tag.ToString() == "024") && (OAD_Buff.Substring(4, 2) == "0B")) || ((node.Tag.ToString() == "024") && (OAD_Buff.Substring(4, 2) == "0F"))) || (((node.Tag.ToString() == "024") && (OAD_Buff.Substring(4, 2) == "0C")) || ((node.Tag.ToString() == "07") && (OAD_Buff.Substring(4, 2) == "08")))) || (((node.Tag.ToString() == "07") && (OAD_Buff.Substring(4, 2) == "09")) || ((node.Tag.ToString() == "07") && (OAD_Buff.Substring(4, 2) == "0B"))))
                            {
                                this.treeList.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData_二级[j][k]), strArray[Convert.ToInt16(List_ParseData_二级[j][k])] }, node5);
                            }
                            else
                            {
                                this.treeList.AppendNode(new object[] { "", "", "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData_二级[j][k]), strArray[(List_ParseData_二级[j].Count * j) + k] }, node5);
                            }
                        }
                    }
                    break;
                }
            }
            tl.ExpandToLevel(0);
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }

        private bool Event_DBtoTreeView()
        {
            TreeNode node = new TreeNode();
            TreeNode node2 = new TreeNode();
            TreeNode node3 = new TreeNode();
            TreeNode node4 = new TreeNode();
            new TreeNode();
            this.treeView_Event.Nodes.Clear();
            string str = "24";
            string str2 = "7";
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            try
            {
                table = DBConnect.Result("select OB_Class,OB_OI,OB_Name,OB_Unit_Type from tree where OB_Class='" + str + "'or OB_Class='" + str2 + "'or OB_OI LIKE '30%'", "treeTable1");
                table2 = DBConnect.Result("select class_id,class_property,class_name,class_OAD_Last2byte,property_Or_Method from interface where class_id='7'or class_id='24'", "treeTable2");
                int count = table.Rows.Count;
                if (count == 0)
                {
                    return false;
                }
                for (int i = 0; i < count; i++)
                {
                    if ((table.Rows[i][1].ToString() == "") || (table.Rows[i][1].ToString() == " "))
                    {
                        str3 = "----";
                        str4 = "----";
                    }
                    else
                    {
                        str3 = table.Rows[i][1].ToString();
                        str4 = table.Rows[i][0].ToString();
                    }
                    if (table.Rows[i][1].ToString().Length == 2)
                    {
                        node = this.treeView_Event.Nodes.Add(table.Rows[i][2].ToString());
                        node.ToolTipText = str3;
                        node.Tag = str4;
                    }
                    else if (table.Rows[i][1].ToString().Length == 4)
                    {
                        node2 = node.Nodes.Add(table.Rows[i][2].ToString());
                        node2.ToolTipText = str3;
                        node2.Tag = str4;
                        for (int j = 0; j < table2.Rows.Count; j++)
                        {
                            str5 = str3 + table2.Rows[j][3].ToString();
                            str6 = table2.Rows[j][4].ToString() + table2.Rows[j][0].ToString();
                            if (table2.Rows[j][1].ToString().Length == 1)
                            {
                                if (table.Rows[i][0].ToString() == table2.Rows[j][0].ToString())
                                {
                                    node3 = node2.Nodes.Add(table2.Rows[j][2].ToString());
                                    node3.ToolTipText = str5;
                                    node3.Tag = str6;
                                }
                            }
                            else if (table2.Rows[j][1].ToString().Length == 2)
                            {
                                if (table.Rows[i][0].ToString() == table2.Rows[j][0].ToString())
                                {
                                    node4 = node3.Nodes.Add(table2.Rows[j][2].ToString());
                                    node4.ToolTipText = str5;
                                    node4.Tag = str6;
                                }
                                if ((str3 == "3000") && (table2.Rows[j][1].ToString() == "12"))
                                {
                                    node4 = node3.Nodes.Add("失压统计");
                                    node4.ToolTipText = "30000D00";
                                    node4.Tag = "024";
                                }
                                if ((str3 == "3027") && (table2.Rows[j][1].ToString() == "10"))
                                {
                                    node4 = node3.Nodes.Add("非法插卡总次数");
                                    node4.ToolTipText = "30271D00";
                                    node4.Tag = "07";
                                }
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
        private bool RCSD_toTree()
        {
            try
            {
                DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "选择"
                };
                string str = "2";
                DataTable table = new DataTable();
                table = DBConnect.Result("select ref_PropertyTag,RCSD_OAD,RCSD_Name from record_display where ref_PropertyTag='" + str + "'", "treeTable1");
                this.dataGridView1.DataSource = table;
                this.dataGridView1.Columns[0].HeaderText = "序号";
                this.dataGridView1.Columns[0].Width = 0x23;
                this.dataGridView1.Columns[1].HeaderText = "OAD";
                this.dataGridView1.Columns[1].Width = 0x36;
                this.dataGridView1.Columns[2].HeaderText = "说明";
                this.dataGridView1.Columns[2].Width = 230;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
                this.dataGridView1.Columns.Insert(0, dataGridViewColumn);
                this.dataGridView1.Columns[0].Width = 0x23;
                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception exception)
            {
                PublicVariable.IsReading = false;
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return true;
        }
        private void Event_Load(object sender, EventArgs e)
        {
            DBConnect.DBOpen();
            this.Event_DBtoTreeView();
            this.RCSD_toTree();
            DBConnect.DBClose();
        }
        private void ReadFlag(TreeNode node)
        {
            bool flag = false;
            bool splitFlag = false;
            string str = "";
            List<List<string>> parseData = new List<List<string>>();
            string linkdata = "";
            string mAC = "";
            string outData = "";
            string toolTipText = node.ToolTipText;
            string str6 = "";
            string str7 = "";
            string str8 = "";
            byte n = 0;
            byte num2 = 0;
            string str9 = "";
            int num3 = 0;
            List<string> list2 = new List<string>();
            if ((((toolTipText.Substring(4, 4) == "0200") && (node.Tag.ToString() == "07")) || ((toolTipText.Substring(4, 4) == "0600") && (node.Tag.ToString() == "024"))) || ((((toolTipText.Substring(4, 4) == "0700") && (node.Tag.ToString() == "024")) || ((toolTipText.Substring(4, 4) == "0800") && (node.Tag.ToString() == "024"))) || ((toolTipText.Substring(4, 4) == "0900") && (node.Tag.ToString() == "024"))))
            {
                outData = "";
                if (this.tabControl2.SelectedTab == this.tabPage3)
                {
                    num2 = 1;
                    str9 = this.txt_Sele1_OAD.Text.PadLeft(8, '0');
                    str6 = this.txt_Data.Text.PadRight(14, '0');
                    str7 = "";
                    n = 0;
                    num3 = 1;
                }
                else if (this.tabControl2.SelectedTab == this.tabPage4)
                {
                    num2 = 2;
                    str9 = this.txt_Sele2_OAD.Text.PadLeft(8, '0');
                    str6 = this.txt_StartData.Text.PadRight(14, '0');
                    str7 = this.txt_EndData.Text.PadRight(14, '0');
                    str8 = this.cmb_间隔单位.SelectedIndex.ToString("X2") + this.tbx_间隔.Text.PadLeft(4, '0').Substring(0, 4);
                    n = 0;
                    num3 = 1;
                }
                else if ((this.tabControl2.SelectedTab == this.tabPage5) && this.rd_上n次.Checked)
                {
                    num2 = 9;
                    str9 = "";
                    str6 = "";
                    str7 = "";
                    n = Convert.ToByte(this.txt_N.Text.PadLeft(2, '0'), 10);
                    num3 = 1;
                }
                else if ((this.tabControl2.SelectedTab == this.tabPage5) && this.rd_前n次.Checked)
                {
                    num2 = 9;
                    str9 = "";
                    str6 = "";
                    str7 = "";
                    n = 1;
                    num3 = Convert.ToInt16(this.textBox2.Text, 10);
                }
                for (int i = 0; i < num3; i++)
                {
                    for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                    {
                        if ((this.dataGridView1.Rows[j].Cells[0].Value != null) && ((bool)this.dataGridView1.Rows[j].Cells[0].Value))
                        {
                            list2.Add(this.dataGridView1.Rows[j].Cells[2].Value.ToString());
                        }
                    }
                    string str10 = Protocol_2.Get_RSD(num2, str9, 0x1c, 7, ref str6, 0x1c, 7, ref str7, 0x54, 3, ref str8, n);
                    string str11 = Protocol_2.Get_RCSD((byte)list2.Count, 0, list2, "", 0, "");
                    linkdata = Protocol.MakeLink_Data("05", "03", PublicVariable.PIID_R.ToString("X2"), toolTipText + str10 + str11, PublicVariable.TimeTag);
                    string str12 = "";
                    string str13 = "";
                    List<string> list3 = new List<string>();
                    string str14 = "";
                    List<List<List<string>>> list4 = new List<List<List<string>>>();
                    list2.Clear();
                    outData = "";
                    StringBuilder cOutData = new StringBuilder(0x7d0);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol_2.GetRequestRecord("43", PublicVariable.Address, PublicVariable.Client_Add, toolTipText, str10, str11, ref outData, PublicVariable.TimeTag, ref splitFlag, ref str12, ref str13, ref list3, ref str14, ref list4);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol_2.Math_明文_RN("00", "01", ref linkdata, ref str12, ref str13, ref list3, ref str14, ref list4, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol_2.Math_明文_SIDMAC("00", "00", ref linkdata, ref str12, ref str13, ref list3, ref str14, ref list4, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol_2.Math_密文_SID("01", "03", ref linkdata, ref str12, ref str13, ref list3, ref str14, ref list4, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol_2.Math_密文_SID_MAC("01", "00", ref linkdata, ref str12, ref str13, ref list3, ref str14, ref list4, ref mAC, ref splitFlag, ref cOutData);
                            break;
                    }
                    if (flag)
                    {
                        if (((str12 == "30170200") || (str12 == "30180200")) || ((str12 == "301A0200") || (str12 == "30250200")))
                        {
                            this.CreateNodes_记录表1(this.treeList, node, str12, str13, list3, str14, list4);
                        }
                        else
                        {
                            this.CreateNodes_记录表(this.treeList, node, str12, str13, list3, str14, list4);
                        }
                    }
                    PublicVariable.Info = node.FullPath + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    this.textBox2.Text = n.ToString();
                    if (this.rd_前n次.Checked)
                    {
                        n = (byte)(n + 1);
                    }
                }
            }
            else if ((node.Tag.ToString() != "07") && (node.Tag.ToString() != "024"))
            {
                MessageBox.Show("请执行设置");
            }
            else
            {
                outData = "";
                StringBuilder cOutData = new StringBuilder(0x7d0);
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), toolTipText, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol_2.GetRequestNormal(toolTipText, "43", PublicVariable.Address, PublicVariable.Client_Add, ref outData, ref str, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol_2.Math_明文_RN("00", "01", ref linkdata, ref str, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol_2.Math_明文_SIDMAC("00", "00", ref linkdata, ref str, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol_2.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref str, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol_2.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref str, ref mAC, ref splitFlag, ref cOutData);
                        break;
                }
                if (flag)
                {
                    if (((toolTipText.Substring(4, 4) == "0300") && (node.Tag.ToString() == "07")) || ((toolTipText.Substring(4, 4) == "0200") && (node.Tag.ToString() == "024")))
                    {
                        this.CreateNodes_关联属性表(this.treeList, node, str, parseData);
                    }
                    else
                    {
                        this.CreateNodes_属性(this.treeList, node, str, parseData);
                    }
                }
                PublicVariable.Info = node.FullPath + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
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

        private void SetMethod(TreeNode node)
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
            string toolTipText = node.ToolTipText;
            string timetext = "";
            if ((node.Tag.ToString() != "17") && (node.Tag.ToString() != "124"))
            {
                MessageBox.Show("请执行抄读！");
            }
            else
            {
                string str9 = toolTipText.Substring(4, 4);
                if (str9 != null)
                {
                    if (str9 == "0100")
                    {
                        cData = "0F00";
                        timetext = "08330C1F00000000000A ";
                    }
                    else if (str9 == "0200")
                    {
                        cData = "0F00";
                    }
                    else if (str9 != "0300")
                    {
                        if (str9 == "0400")
                        {
                            cData = "51" + this.txt_OAD_添加.Text.PadLeft(8, '0');
                        }
                        else if (str9 == "0500")
                        {
                            cData = "51" + this.txt_删除OAD.Text.PadLeft(8, '0');
                        }
                    }
                }
            }
            if (toolTipText.Substring(4, 4) == "0100")
            {
                linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), toolTipText + cData, "08330C1F00000000000A ");
            }
            else
            {
                linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), toolTipText + cData, PublicVariable.TimeTag);
            }
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    if (toolTipText.Substring(4, 4) != "0100")
                    {
                        flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, toolTipText, cData, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                        break;
                    }
                    flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, toolTipText, cData, ref parseData, timetext, ref splitFlag);
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
            PublicVariable.Info = node.FullPath + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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

        private void tb_Stop_Click(object sender, EventArgs e)
        {
            this.bIsStop = true;
            PublicVariable.IsReading = false;
        }

        private void tb_单项设置_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    this.bIsStop = false;
                    for (int i = 0; i < this.treeView_Event.GetNodeCount(false); i++)
                    {
                        TreeNode node = this.treeView_Event.Nodes[i];
                        if (node.Checked && (this.treeView_Event.GetNodeCount(false) == 0))
                        {
                            if (this.bIsStop)
                            {
                                return;
                            }
                            if (node.ToolTipText.Length != 8)
                            {
                                continue;
                            }
                            this.SetMethod(node);
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
                                this.SetMethod(node2);
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
                                    this.SetMethod(node3);
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
                                            this.SetMethod(node4);
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
                                                    this.SetMethod(node5);
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
            }
        }

        private void tb_导出Excel_Click(object sender, EventArgs e)
        {
            PublicVariable.ExportToExcel("事件记录", false, "事件记录", new IPrintable[] { this.treeList });
        }

        private void tbl_单项抄读_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    this.bIsStop = false;
                    this.treeList.ClearNodes();
                    for (int i = 0; i < this.treeView_Event.GetNodeCount(false); i++)
                    {
                        TreeNode node = this.treeView_Event.Nodes[i];
                        if (node.Checked && (this.treeView_Event.GetNodeCount(false) == 0))
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
                                    if (node4.Checked && (node4.GetNodeCount(false) == 0))
                                    {
                                        if (this.bIsStop)
                                        {
                                            return;
                                        }
                                        if (node4.ToolTipText.Length != 8)
                                        {
                                            continue;
                                        }
                                        this.ReadFlag(node4);
                                    }
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
            catch (Exception exception)
            {
                PublicVariable.IsReading = false;
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
        }

        private void treeView_Event_AfterCheck(object sender, TreeViewEventArgs e)
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

        private void tsb_展开_Click(object sender, EventArgs e)
        {
            if (this.tsb_展开.Text == "节点展开")
            {
                this.treeList.ExpandAll();
                this.tsb_展开.Text = "节点收起";
            }
            else if (this.tsb_展开.Text == "节点收起")
            {
                this.treeList.CollapseAll();
                this.tsb_展开.Text = "节点展开";
            }
        }

        private void tb_Exit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (e.RowIndex != -1))
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.dataGridView1.Rows[e.RowIndex].Cells[0];
                if (Convert.ToBoolean(cell.Value))
                {
                    cell.Value = false;
                }
                else
                {
                    cell.Value = true;
                }
            }
        }

    }
}
