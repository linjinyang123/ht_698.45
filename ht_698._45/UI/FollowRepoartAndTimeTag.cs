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
    public partial class FollowRepoartAndTimeTag : Form
    {
        public FollowRepoartAndTimeTag()
        {
            this.InitializeComponent();
        }
        private void CreateNodes_记录表(TreeList tl, string Rercord_OAD, string rel_Num, List<string> Rel_RCSD, string Record_Num, List<List<List<string>>> list_ParseData_多级)
        {
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select ref_PropertyTag,RCSD_OAD,RCSD_Name,RCSD_Dot,RCSD_txt from record_display where ref_PropertyTag='2' or ref_PropertyTag='22'", "treeTable");
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node2 = tl.AppendNode(new object[] { "跟随上报信息域", Rercord_OAD }, parentNode);
            TreeListNode node3 = tl.AppendNode(new object[] { "", Rercord_OAD }, node2);
            TreeListNode node4 = tl.AppendNode(new object[] { "", "关联属性列表共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "列", "" }, node3);
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
                object[] nodeData = new object[] { "", "第" + ((i + 1)).ToString() + "列", Rel_RCSD[i], list[i] };
                tl.AppendNode(nodeData, node4);
            }
            tl.AppendNode(new object[] { "", "记录（行）表共" + Record_Num + "行" }, node3);
            //TreeListNode node5 = new TreeListNode();
            //TreeListNode node6 = new TreeListNode();
            //new TreeListNode();
            TreeListNode node5 ;
            TreeListNode node6 ;
            for (int j = 0; j < list_ParseData_多级.Count; j++)
            {
                object[] nodeData = new object[] { "", "第" + ((j + 1)).ToString() + "条记录", "", "" };
                node5 = tl.AppendNode(nodeData, node3);
                for (int k = 0; k < list_ParseData_多级[j].Count; k++)
                {
                    string[] strArray = list2[k].Split(new char[] { ',' });
                    string[] strArray2 = list3[k].Split(new char[] { ',' });
                    object[] objArray7 = new object[] { "", "第" + ((k + 1)).ToString() + "列", "共" + list_ParseData_多级[j][k].Count.ToString() + "项", list[k] };
                    node6 = tl.AppendNode(objArray7, node5);
                    for (int m = 0; m < list_ParseData_多级[j][k].Count; m++)
                    {
                        if (strArray.Length > m)
                        {
                            if ((strArray[m] != "") && (strArray2.Length > m))
                            {
                                tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])), strArray2[m] }, node6);
                            }
                            else if ((strArray[m] != "") && (strArray2.Length <= m))
                            {
                                tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])), "" }, node6);
                            }
                            else if (strArray2.Length > m)
                            {
                                tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]), strArray2[m] }, node6);
                            }
                            else
                            {
                                tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node6);
                            }
                        }
                        else if (strArray2.Length > m)
                        {
                            tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]), strArray2[m] }, node6);
                        }
                        else
                        {
                            tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node6);
                        }
                    }
                }
            }
            tl.ExpandToLevel(0);
            tl.EndUnboundLoad();
            DBConnect.DBClose();
        }
        private void Follow_LoadNormal(List<string> follow_OADNormal, List<string> follow_DataNormal, List<string> follow_TimeTag, string follow_OADRercord)
        {
            TreeListNode node2;
            TreeListNode node3;
            DBConnect.DBOpen();
            DataTable table = new DataTable();
            table = DBConnect.Result("select Record_OI,Record_name from follow_collection ", "treeTable");
            bool flag = false;
            bool flag2 = false;
            this.tl_跟随.BeginUnboundLoad();
            TreeListNode parentNode = null;
            if (follow_OADNormal.Count != 0)
            {
                node2 = this.tl_跟随.AppendNode(new object[] { "跟随上报信息域", "", "" }, parentNode);
                for (int i = 0; i < follow_OADNormal.Count; i++)
                {
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        if (follow_OADNormal[i].Substring(0, 4) == table.Rows[j][0].ToString())
                        {
                            flag = true;
                            node3 = this.tl_跟随.AppendNode(new object[] { follow_OADNormal[i], "", table.Rows[j][1].ToString() }, node2);
                            for (int k = 0; k < table.Rows.Count; k++)
                            {
                                if (follow_DataNormal[i].Substring(0, 4) == table.Rows[k][0].ToString())
                                {
                                    flag2 = true;
                                    if (follow_OADNormal[i].Substring(0, 4) == "3320")
                                    {
                                        if (follow_DataNormal.Count > 1)
                                        {
                                            for (int m = 0; m < (follow_DataNormal.Count - 1); m++)
                                            {
                                                this.tl_跟随.AppendNode(new object[] { "", follow_DataNormal[m], table.Rows[k][1].ToString() }, node3);
                                            }
                                        }
                                        else
                                        {
                                            this.tl_跟随.AppendNode(new object[] { "", follow_DataNormal[0], table.Rows[k][1].ToString() }, node3);
                                        }
                                    }
                                    else
                                    {
                                        this.tl_跟随.AppendNode(new object[] { "", follow_DataNormal[follow_DataNormal.Count - 1], table.Rows[k][1].ToString() }, node3);
                                    }
                                    break;
                                }
                                flag2 = false;
                            }
                            if (!flag2)
                            {
                                this.tl_跟随.AppendNode(new object[] { "", follow_DataNormal[i], "" }, node3);
                            }
                            break;
                        }
                        flag = false;
                    }
                    if (!flag)
                    {
                        node3 = this.tl_跟随.AppendNode(new object[] { follow_OADNormal[i], "请在数据库添加文字说明..." }, node2);
                    }
                }
            }
            if (follow_TimeTag.Count != 0)
            {
                string[] strArray = new string[] { "年月日时分秒", "间隔单位", "间隔" };
                node2 = this.tl_跟随.AppendNode(new object[] { "时间标签" }, parentNode);
                for (int i = 0; i < follow_TimeTag.Count; i++)
                {
                    node3 = this.tl_跟随.AppendNode(new object[] { "", follow_TimeTag[i], strArray[i] }, node2);
                }
            }
            if (PublicVariable.follow_OADRercord != "")
            {
                this.CreateNodes_记录表(this.tl_跟随, PublicVariable.follow_OADRercord, PublicVariable.follow_rel_NumRercord, PublicVariable.follow_Rel_RCSDRercord, PublicVariable.follow_RecordNumRercord, PublicVariable.follow_DataRercord);
            }
            this.tl_跟随.ExpandAll();
            this.tl_跟随.EndUnboundLoad();
            DBConnect.DBClose();
        }

        private void FollowRepoartAndTimeTag_Load(object sender, EventArgs e)
        {
            this.Follow_LoadNormal(PublicVariable.follow_OADNormal, PublicVariable.follow_DataNormal, PublicVariable.follow_TimeTag, PublicVariable.follow_OADRercord);
        }
    }
}
