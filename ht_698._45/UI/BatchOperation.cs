using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ht_698._45.UI
{
    public partial class BatchOperation : Form
    {
        private bool bIsStop;
        private bool bIsXunhuan;
        public BatchOperation(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        private bool Action(TreeListNode tl_node)
        {
            bool flag3;
            try
            {
                bool flag = false;
                string cData = "";
                bool splitFlag = false;
                string data = "";
                List<string> frameData = new List<string>();
                string dataType = "";
                string dataLen = "";
                string timeText = "";
                string str6 = "";
                string str7 = "";
                string parseData = "";
                List<string> list2 = new List<string>();
                string linkdata = "";
                string mAC = "";
                StringBuilder cOutData = new StringBuilder(0x7d0);
                data = "";
                cData = "";
                frameData.Clear();
                dataType = tl_node.GetDisplayText("数据类型集合").Replace(",", "");
                dataLen = tl_node.GetDisplayText("数据长度集合").Replace(",", "");
                str7 = tl_node.GetDisplayText("数据OAD").Replace(",", "");
                data = tl_node.GetDisplayText("参数").Replace(",", "");
                cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
                timeText = "08330101000000010010";
                linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), str7 + cData, timeText);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str7, cData, timeText, ref splitFlag);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str6, ref str7, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str6, ref str7, ref splitFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                this.CreateNodes_操作_设置(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str7, parseData, flag);
                flag3 = flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
                PublicVariable.IsReading = false;
                flag3 = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
            return flag3;
        }
        private void CreateNodes_操作_设置(string add, TreeList tl, TreeListNode tl_node, string OAD_Buff, string ParseData, bool flag)
        {
            TreeListNode parentNode = null;
            tl.AppendNode(new object[] { add, OAD_Buff + "-" + tl_node.GetDisplayText("对象名称"), ParseData, flag ? "成功" : "失败" }, parentNode);
        }

        private void Add_导入_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Title = "Excel文件",
                    FileName = "",
                    InitialDirectory = Application.StartupPath + @"\操作方案",
                    Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls",
                    ValidateNames = true,
                    CheckFileExists = true,
                    CheckPathExists = true,
                    RestoreDirectory = true
                };
                string path = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                }
                if (path == "")
                {
                    MessageBox.Show("没有选择Excel文件！无法进行数据导入");
                }
                else if (this.EcxelToDatalistView(path))
                {
                    this.btn_Begin.Enabled = true;
                    this.chk_All.Checked = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool EcxelToDatalistView(string path)
        {
            try
            {
                OleDbConnection selectConnection = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;data source=" + path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'");
                selectConnection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM  [Sheet1$];", selectConnection);
                DataSet dataSet = new DataSet("CodeName");
                adapter.Fill(dataSet, "CodeName");
                DataTable table = dataSet.Tables[0];
                this.lsv_Add.Items.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string text = table.Rows[i][0].ToString().PadLeft(12, '0');
                    ListViewItem item = new ListViewItem();
                    item.Text = (this.lsv_Add.Items.Count + 1).ToString();
                    item.SubItems.Add(text);
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    this.lsv_Add.Items.Add(item);
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void BatchOperation_Load(object sender, EventArgs e)
        {
            RepositoryItemComboBox item = new RepositoryItemComboBox();
            item.Items.AddRange(new string[] { "设置", "抄读", "操作", "ESAM回抄", "ESAM更新" });
            this.treeList_批操作.RepositoryItems.Add(item);
            this.treeList_批操作.Columns[3].ColumnEdit = item;
            this.txt_Count.Enabled = false;
            this.txt_delay.Enabled = false;
            this.btn_Stop.Enabled = false;
            this.txt_zaiboAdd.Enabled = false;
            this.btn_ad.Enabled = false;
            this.btn_Remove.Enabled = false;
        }

        private void btn_ad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_zaiboAdd.Text != "")
                {
                    string text = this.txt_zaiboAdd.Text.PadLeft(12, '0');
                    ListViewItem item = new ListViewItem();
                    item.Text = (this.lsv_Add.Items.Count + 1).ToString();
                    item.SubItems.Add(text);
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    this.lsv_Add.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            string address = PublicVariable.Address;
            if (!PublicVariable.IsReading)
            {
                PublicVariable.IsReading = true;
                try
                {
                    if (!CommParam.comPort.IsOpen)
                    {
                        CommParam.comPort.OpenPort();
                    }
                    if (Protocol.GetRequestNormal("40010200", "43", "45AAAAAAAAAAAA", PublicVariable.Client_Add, ref cData, false, ref splitFlag))
                    {
                        bool flag3 = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                        if (flag3)
                        {
                            PublicVariable.Address = (((parseData.Length / 2) - 1)).ToString("X2") + parseData;
                            this.txt_Add.Text = parseData;
                        }
                        this.label_Info.Text = PublicVariable.Info = "地址" + (flag3 ? "读取成功" : ("读取失败--" + PublicVariable.DARInfo));
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                        if (splitFlag)
                        {
                            PublicVariable.SplitFlag = true;
                        }
                        else
                        {
                            PublicVariable.SplitFlag = false;
                        }
                    }
                    else
                    {
                        PublicVariable.Address = address;
                        this.label_Info.Text = "读取地址失败";
                        PublicVariable.Info_Color = "Red";
                    }
                    PublicVariable.Info = this.label_Info.Text;
                    PublicVariable.ChangedFlag = true;
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
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            string address = "";
            int[] numArray = new int[this.lsv_Add.Items.Count];
            int[] numArray2 = new int[this.lsv_Add.Items.Count];
            int count = 0;
            this.btn_Stop.Enabled = true;
            try
            {
                this.tl_显示.ClearNodes();
                this.bIsXunhuan = true;
                bool flag = false;
                for (int i = 0; i < this.lsv_Add.Items.Count; i++)
                {
                    numArray[i] = 0;
                    numArray2[i] = 0;
                }
                int num3 = Convert.ToInt32(this.txt_Count.Text);
                while (this.bIsXunhuan)
                {
                    if (this.bIsStop)
                    {
                        return;
                    }
                    this.bIsXunhuan = this.chk_Xunhuan.Checked;
                    num3--;
                    if (this.chk_Xunhuan.Checked)
                    {
                        if (num3 < 0)
                        {
                            return;
                        }
                        this.txt_Count.Text = num3.ToString();
                    }
                    if (num3 <= 0)
                    {
                        this.bIsXunhuan = false;
                    }
                    if (this.chk_Zaibo.Checked)
                    {
                        count = this.lsv_Add.Items.Count;
                        if (count == 0)
                        {
                            MessageBox.Show("请添加表地址");
                            address = PublicVariable.Address;
                            return;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                    for (int j = 0; j < this.treeList_批操作.Nodes.Count; j++)
                    {
                        if (this.treeList_批操作.Nodes[j].Checked)
                        {
                            for (int k = 0; k < count; k++)
                            {
                                if (this.bIsStop)
                                {
                                    return;
                                }
                                if (this.chk_Zaibo.Checked)
                                {
                                    if (count == 0)
                                    {
                                        MessageBox.Show("请添加表地址");
                                        address = PublicVariable.Address;
                                        return;
                                    }
                                    address = PublicVariable.Address;
                                    PublicVariable.Address = (((this.lsv_Add.Items[k].SubItems[1].Text.PadLeft(12, '0').Length / 2) - 1)).ToString("X2") + this.lsv_Add.Items[k].SubItems[1].Text.ToString().PadLeft(12, '0');
                                    numArray[k]++;
                                }
                                switch (this.treeList_批操作.Nodes[j].GetDisplayText("操作标志"))
                                {
                                    case "抄读":
                                        flag = this.ReadFlag(this.treeList_批操作.Nodes[j]);
                                        break;

                                    case "设置":
                                        flag = this.Set(this.treeList_批操作.Nodes[j]);
                                        break;

                                    case "操作":
                                        flag = this.Action(this.treeList_批操作.Nodes[j]);
                                        break;

                                    case "ESAM回抄":
                                        flag = this.Read_ESAM(this.treeList_批操作.Nodes[j]);
                                        break;

                                    case "ESAM更新":
                                        flag = this.Write_ESAM更新(this.treeList_批操作.Nodes[j]);
                                        break;

                                    case "特殊645指令":
                                        flag = this.Special_645_Command(this.treeList_批操作.Nodes[j]);
                                        break;
                                }
                                if (!flag && this.chk_Zaibo.Checked)
                                {
                                    numArray2[k]++;
                                }
                                if (this.chk_Xunhuan.Checked)
                                {
                                    Thread.Sleep(Convert.ToInt32(this.txt_delay.Text));
                                    Application.DoEvents();
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
                this.bIsStop = false;
                this.btn_Stop.Enabled = false;
                if (this.chk_Zaibo.Checked)
                {
                    PublicVariable.Address = address;
                    for (int i = 0; i < count; i++)
                    {
                        if (numArray[i] == 0)
                        {
                            break;
                        }
                        this.lsv_Add.Items[i].SubItems[2].Text = (((float)(numArray[i] - numArray2[i])) / ((float)numArray[i])).ToString("#.##%");
                        this.lsv_Add.Items[i].SubItems[3].Text = numArray2[i].ToString();
                        this.lsv_Add.Items[i].SubItems[4].Text = numArray[i].ToString();
                    }
                }
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            new NewBatch().ShowDialog();
        }
        private bool EcxelToDataGridView(string path)
        {
            try
            {
                TreeListNode parentNode = null;
                OleDbConnection selectConnection = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;data source=" + path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'");
                selectConnection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM  [Sheet1$];", selectConnection);
                DataSet dataSet = new DataSet("CodeName");
                adapter.Fill(dataSet, "CodeName");
                DataTable table = dataSet.Tables[0];
                this.treeList_批操作.ClearNodes();
                for (int i = 0; i < (table.Rows.Count - 1); i++)
                {
                    this.treeList_批操作.AppendNode(new object[] { table.Rows[i][0].ToString(), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), table.Rows[i][6].ToString(), table.Rows[i][7].ToString() }, parentNode);
                    this.treeList_批操作.Nodes[i].Tag = table.Rows[i][5].ToString();
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Title = "Excel文件",
                    FileName = "",
                    InitialDirectory = Application.StartupPath + @"\操作方案",
                    Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls",
                    ValidateNames = true,
                    CheckFileExists = true,
                    CheckPathExists = true,
                    RestoreDirectory = true
                };
                string path = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                    this.Text = "批操作";
                    this.Text = this.Text + dialog.FileName;
                }
                if (path == "")
                {
                    MessageBox.Show("没有选择Excel文件！无法进行数据导入");
                }
                else if (this.EcxelToDataGridView(path))
                {
                    this.btn_Begin.Enabled = true;
                    this.chk_All.Checked = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsv_Add.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要删除序列");
                }
                else
                {
                    for (int i = 0; i < this.lsv_Add.Items.Count; i++)
                    {
                        if (this.lsv_Add.Items[i].Selected)
                        {
                            this.lsv_Add.Items.Remove(this.lsv_Add.Items[i]);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            this.bIsStop = true;
            PublicVariable.IsReading = false;
        }

        private void btn_比对_Click(object sender, EventArgs e)
        {
            int count = 0;
            string address = "";
            try
            {
                this.btn_Stop.Enabled = true;
                this.tl_显示.ClearNodes();
                if (!this.bIsStop && !PublicVariable.IsReading)
                {
                    if (this.chk_Zaibo.Checked)
                    {
                        count = this.lsv_Add.Items.Count;
                    }
                    else
                    {
                        count = 1;
                    }
                    for (int i = 0; i < this.treeList_批操作.Nodes.Count; i++)
                    {
                        if (this.bIsStop)
                        {
                            return;
                        }
                        if (this.treeList_批操作.Nodes[i].Checked)
                        {
                            for (int j = 0; j < count; j++)
                            {
                                if (this.bIsStop)
                                {
                                    return;
                                }
                                if (this.chk_Zaibo.Checked)
                                {
                                    if (count == 0)
                                    {
                                        MessageBox.Show("请添加表地址");
                                        return;
                                    }
                                    address = PublicVariable.Address;
                                    PublicVariable.Address = (((this.lsv_Add.Items[j].SubItems[1].Text.PadLeft(12, '0').Length / 2) - 1)).ToString("X2") + this.lsv_Add.Items[j].SubItems[1].Text.ToString().PadLeft(12, '0');
                                }
                                string displayText = this.treeList_批操作.Nodes[i].GetDisplayText("操作标志");
                                if (displayText != null)
                                {
                                    if (displayText != "抄读")
                                    {
                                        if (displayText == "设置")
                                        {
                                            goto Label_01CF;
                                        }
                                        if (displayText == "操作")
                                        {
                                            goto Label_01DC;
                                        }
                                        if (displayText == "ESAM回抄")
                                        {
                                            goto Label_01E9;
                                        }
                                    }
                                    else
                                    {
                                        this.ReadFlag(this.treeList_批操作.Nodes[i], this.treeList_批操作.Nodes[i].GetDisplayText("参数"));
                                    }
                                }
                                continue;
                            Label_01CF:
                                MessageBox.Show("请检查操作方式，“设置”操作不适应于参数比对！");
                                continue;
                            Label_01DC:
                                MessageBox.Show("请检查操作方式，“操作”不适应于参数比对！");
                                continue;
                            Label_01E9:
                                this.Read_ESAM(this.treeList_批操作.Nodes[i], this.treeList_批操作.Nodes[i].GetDisplayText("参数"));
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
                this.bIsStop = false;
                if (this.chk_Zaibo.Checked)
                {
                    PublicVariable.Address = address;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PublicVariable.ExportToExcel("操作结果", false, "操作结果", new IPrintable[] { this.tl_显示 });
        }

        private void chk_All_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chk_All.Checked)
                {
                    this.treeList_批操作.CheckAll();
                }
                else
                {
                    this.treeList_批操作.UncheckAll();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chk_Xunhuan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.bIsXunhuan = this.chk_Xunhuan.Checked;
                this.txt_Count.Enabled = this.chk_Xunhuan.Checked;
                this.txt_delay.Enabled = this.chk_Xunhuan.Checked;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chk_Zaibo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chk_Zaibo.Checked)
                {
                    this.btn_Add.Enabled = false;
                    this.txt_Add.Enabled = false;
                    this.txt_zaiboAdd.Enabled = true;
                    this.btn_ad.Enabled = true;
                    this.btn_Remove.Enabled = true;
                }
                else
                {
                    this.btn_Add.Enabled = true;
                    this.txt_Add.Enabled = true;
                    this.txt_zaiboAdd.Enabled = false;
                    this.btn_ad.Enabled = false;
                    this.btn_Remove.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool CompareData(TreeListNode tl_node, string ParseData)
        {
            string displayText = tl_node.GetDisplayText("数据OAD");
            string str2 = "";
            string str3 = "";
            switch (displayText)
            {
                case "40020200":
                    str3 = tl_node.GetDisplayText("参数").PadLeft(8, '0');
                    break;

                case "40030200":
                    str3 = tl_node.GetDisplayText("参数").PadLeft(6, '0');
                    break;

                case "401C0200":
                    str3 = tl_node.GetDisplayText("参数").PadLeft(3, '0');
                    break;

                case "401D0200":
                    str3 = tl_node.GetDisplayText("参数").PadLeft(3, '0');
                    break;

                case "401E0200":
                    {
                        string[] strArray = tl_node.GetDisplayText("参数").Split(new char[] { ',' });
                        str3 = Convert.ToInt32((float)(float.Parse(strArray[0]) * 100f)).ToString().PadLeft(8, '0') + Convert.ToInt32((float)(float.Parse(strArray[1]) * 100f)).ToString().PadLeft(8, '0');
                        break;
                    }
                case "400A0200":
                case "400B0200":
                    str3 = tl_node.GetDisplayText("参数").PadLeft(10, '0');
                    break;

                case "401A0200":
                case "401B0200":
                    {
                        string[] strArray2 = tl_node.GetDisplayText("参数").Split(new char[] { ',' });
                        for (int i = 0; i < 6; i++)
                        {
                            str3 = str3 + Convert.ToInt32((float)(float.Parse(strArray2[i]) * 100f)).ToString().PadLeft(8, '0');
                        }
                        for (int j = 6; j < 13; j++)
                        {
                            str3 = str3 + Convert.ToInt32((float)(float.Parse(strArray2[j]) * 10000f)).ToString().PadLeft(8, '0');
                        }
                        for (int k = 13; k < 0x19; k++)
                        {
                            str3 = str3 + strArray2[k];
                        }
                        break;
                    }
                case "40180200":
                case "40190200":
                    {
                        string[] strArray3 = tl_node.GetDisplayText("参数").Split(new char[] { ',' });
                        for (int i = 0; i < 0x20; i++)
                        {
                            str3 = str3 + Convert.ToInt32((float)(float.Parse(strArray3[i]) * 10000f)).ToString().PadLeft(8, '0');
                        }
                        break;
                    }
            }
            if ((((displayText.Substring(0, 4) == "4002") || (displayText.Substring(0, 4) == "4003")) || ((displayText.Substring(0, 4) == "401C") || (displayText.Substring(0, 4) == "401D"))) || ((displayText.Substring(0, 4) == "400A") || (displayText.Substring(0, 4) == "400B")))
            {
                switch (displayText.Substring(0, 4))
                {
                    case "4002":
                        str2 = ParseData.Substring(0, 0x10).ToString();
                        break;

                    case "4003":
                        str2 = ParseData.Substring(0, 12).ToString();
                        break;

                    case "401C":
                        str2 = ParseData.Substring(0, 6).ToString();
                        break;

                    case "401D":
                        str2 = ParseData.Substring(0, 6).ToString();
                        break;

                    case "400A":
                        str2 = ParseData.Substring(0, 10).ToString();
                        break;

                    case "400B":
                        str2 = ParseData.Substring(0, 10).ToString();
                        break;
                }
            }
            else if (displayText.Substring(0, 4) == "401E")
            {
                str2 = "";
                if (displayText.Substring(4, 4) == "0200")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        str2 = str2 + ParseData.Substring(0, 8);
                        ParseData = ParseData.Substring(8);
                    }
                }
                else
                {
                    str2 = ParseData.Substring(0, 8);
                }
            }
            else if ((displayText.Substring(0, 4) == "4018") || (displayText.Substring(0, 4) == "4019"))
            {
                if ((displayText.Substring(4, 4) == "0200") && (ParseData.Length >= 0x100))
                {
                    for (int i = 0; i < 0x20; i++)
                    {
                        str2 = str2 + ParseData.Substring(0, 8);
                        ParseData = ParseData.Substring(8);
                    }
                }
                else
                {
                    str2 = str2 + ParseData.Substring(0, 8);
                }
            }
            else if ((displayText.Substring(0, 4) == "401A") || (displayText.Substring(0, 4) == "401B"))
            {
                for (int i = 0; i < 6; i++)
                {
                    str2 = str2 + ParseData.Substring(0, 8);
                    ParseData = ParseData.Substring(8);
                }
                for (int j = 6; j < 13; j++)
                {
                    str2 = str2 + ParseData.Substring(0, 8);
                    ParseData = ParseData.Substring(8);
                }
                for (int k = 0; k < 4; k++)
                {
                    str2 = str2 + ParseData.Substring(0, 2) + ParseData.Substring(2, 2) + ParseData.Substring(4, 2);
                    ParseData = ParseData.Substring(6);
                }
            }
            return (str2 == str3);
        }

        private bool CompareData(TreeListNode tl_node, List<string> List_ParseData_抄读, string Linkdata_buff)
        {
            string[] strArray = tl_node.GetDisplayText("换算(小数位)").Split(new char[] { ',' });
            string[] strArray2 = tl_node.GetDisplayText("数据类型集合").Split(new char[] { ',' });
            string[] strArray3 = tl_node.GetDisplayText("数据长度集合").Split(new char[] { ',' });
            string displayText = tl_node.GetDisplayText("数据OAD");
            List<string> list = new List<string>();
            list.AddRange(tl_node.GetDisplayText("参数").Split(new char[] { ','}));
            //list.AddRange(tl_node.GetDisplayText("参数").Split(new char[] { ',', 0xff0c }));//有问题
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            string str2 = "";
            string str3 = "";
            for (int i = 0; i < strArray2.Length; i++)
            {
                if ((strArray2[i] != "02") && (strArray2[i] != "01"))
                {
                    list3.Add(strArray3[i]);
                    list2.Add(strArray2[i]);
                }
            }
            if (((displayText.Substring(0, 4) == "4014") || (displayText.Substring(0, 4) == "4015")) || ((displayText.Substring(0, 4) == "4016") || (displayText.Substring(0, 4) == "4017")))
            {
                str3 = tl_node.GetDisplayText("参数").Replace(",", "");
            }
            else
            {
                for (int j = 0; j < list3.Count; j++)
                {
                    if ((((list2[j] != "04") && (list2[j] != "09")) && ((list2[j] != "10") && (list2[j] != "26"))) && (list2[j] != "28"))
                    {
                        if (list[j] != "FF")
                        {
                            double num14 = Convert.ToDouble(list[j].Trim().PadLeft(Convert.ToByte(list3[j]) * 2, '0')) * Math.Pow(10.0, Convert.ToDouble(strArray[j]));
                            str3 = str3 + num14.ToString().PadLeft(Convert.ToByte(list3[j]) * 2, '0');
                        }
                        else
                        {
                            str3 = str3 + list[j].PadLeft(Convert.ToByte(list3[j]) * 2, '0');
                        }
                    }
                    else if ((list2[j] == "10") || (list2[j] == "04"))
                    {
                        str3 = str3 + tl_node.GetDisplayText("参数").Split(new char[] { ',' })[j];
                    }
                    else
                    {
                        str3 = str3 + tl_node.GetDisplayText("参数").Split(new char[] { ',' })[j].PadLeft(Convert.ToByte(list3[j]) * 2, '0');
                    }
                }
            }
            if (List_ParseData_抄读.Count == 1)
            {
                str2 = List_ParseData_抄读[0];
            }
            else if ((List_ParseData_抄读.Count > 1) && (displayText.Substring(6, 2) != "00"))
            {
                if (displayText.Substring(0, 4) == "4011")
                {
                    if (List_ParseData_抄读.Count >= 2)
                    {
                        str2 = List_ParseData_抄读[0] + List_ParseData_抄读[1];
                    }
                    else
                    {
                        str2 = List_ParseData_抄读[0];
                    }
                }
                else if ((displayText.Substring(0, 4) == "4014") || (displayText.Substring(0, 4) == "4015"))
                {
                    if (List_ParseData_抄读.Count >= 3)
                    {
                        str2 = List_ParseData_抄读[0] + List_ParseData_抄读[1] + List_ParseData_抄读[2];
                    }
                    else
                    {
                        str2 = List_ParseData_抄读[0];
                    }
                }
                else if ((displayText.Substring(0, 4) == "4016") || (displayText.Substring(0, 4) == "4017"))
                {
                    str2 = "";
                    if (List_ParseData_抄读.Count >= 3)
                    {
                        for (int j = 0; j < (List_ParseData_抄读.Count / 3); j++)
                        {
                            str2 = str2 + List_ParseData_抄读[3 * j] + List_ParseData_抄读[(3 * j) + 1] + List_ParseData_抄读[(3 * j) + 2];
                        }
                    }
                    else
                    {
                        str2 = List_ParseData_抄读[0];
                    }
                    str3 = str3.Substring(0, str2.Length);
                }
                else if (displayText.Substring(0, 4) == "4116")
                {
                    if (List_ParseData_抄读.Count >= 2)
                    {
                        str2 = List_ParseData_抄读[0] + List_ParseData_抄读[1];
                    }
                    else
                    {
                        str2 = List_ParseData_抄读[0];
                    }
                }
            }
            else if ((List_ParseData_抄读.Count > 1) && (displayText.Substring(6, 2) == "00"))
            {
                if (displayText == "40110200")
                {
                    for (int j = 0; j < (List_ParseData_抄读.Count / 2); j++)
                    {
                        str2 = str2 + List_ParseData_抄读[2 * j] + List_ParseData_抄读[(2 * j) + 1];
                    }
                    str3 = str3.Substring(0, str2.Length);
                }
                else if ((displayText.Substring(0, 4) == "4014") || (displayText.Substring(0, 4) == "4015"))
                {
                    for (int j = 0; j < (List_ParseData_抄读.Count / 3); j++)
                    {
                        str2 = str2 + List_ParseData_抄读[3 * j] + List_ParseData_抄读[(3 * j) + 1] + List_ParseData_抄读[(3 * j) + 2];
                    }
                    str3 = str3.Substring(0, str2.Length);
                }
                else if ((displayText.Substring(0, 4) == "4016") || (displayText.Substring(0, 4) == "4017"))
                {
                    string str4 = Linkdata_buff.Substring(0x12, 2);
                    string str5 = Linkdata_buff.Substring(0x16, 2);
                    str2 = "";
                    for (int j = 0; j < Convert.ToByte(str4, 0x10); j++)
                    {
                        for (int k = 0; k < Convert.ToByte(str5, 0x10); k++)
                        {
                            str2 = str2 + List_ParseData_抄读[((j * 3) * Convert.ToByte(str5, 0x10)) + (3 * k)] + List_ParseData_抄读[((j * 3) * Convert.ToByte(str5, 0x10)) + ((3 * k) + 1)] + List_ParseData_抄读[((j * 3) * Convert.ToByte(str5, 0x10)) + ((3 * k) + 2)];
                        }
                    }
                    str3 = str3.Substring(0, str2.Length);
                }
                else if ((displayText.Substring(0, 4) == "4018") || (displayText.Substring(0, 4) == "4019"))
                {
                    for (int j = 0; j < List_ParseData_抄读.Count; j++)
                    {
                        str2 = str2 + List_ParseData_抄读[j];
                    }
                    str3 = str3.Substring(0, str2.Length);
                }
                else if ((displayText.Substring(0, 4) == "401A") || (displayText.Substring(0, 4) == "401B"))
                {
                    str2 = "";
                    for (int j = 0; j < 6; j++)
                    {
                        str2 = str2 + List_ParseData_抄读[j];
                    }
                    for (int k = 6; k < 13; k++)
                    {
                        str2 = str2 + List_ParseData_抄读[k];
                    }
                    for (int m = 0; m < 4; m++)
                    {
                        str2 = str2 + List_ParseData_抄读[13 + (3 * m)] + List_ParseData_抄读[(13 + (3 * m)) + 1] + List_ParseData_抄读[(13 + (3 * m)) + 2];
                    }
                    str3 = str3.Substring(0, str2.Length);
                }
                else if (displayText.Substring(0, 4) == "4116")
                {
                    str2 = "";
                    for (int j = 0; j < (List_ParseData_抄读.Count / 2); j++)
                    {
                        str2 = str2 + List_ParseData_抄读[2 * j] + List_ParseData_抄读[(2 * j) + 1];
                    }
                    str3 = str3.Substring(0, str2.Length);
                }
                else
                {
                    str2 = "";
                    for (int j = 0; j < List_ParseData_抄读.Count; j++)
                    {
                        str2 = str2 + List_ParseData_抄读[j];
                    }
                }
            }
            return (str2 == str3);
        }
        private void CreateNodes_ERR(string add, TreeList tl, TreeListNode tl_node, string OAD_Buff, string dis_errString, bool flag)
        {
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node2 = tl.AppendNode(new object[] { add, OAD_Buff + "-" + tl_node.GetDisplayText("对象名称") }, parentNode);
            tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), dis_errString, flag ? "成功" : "失败", "" }, node2);
            tl.ExpandAll();
            tl.EndUnboundLoad();
        }
        private void CreateNodes_变量(string add, TreeList tl, TreeListNode tl_node, string OAD_Buff, List<string> List_ParseData, bool flag)
        {
            TreeListNode node3;
            string[] strArray = tl_node.Tag.ToString().Split(new char[] { ',' });
            string[] strArray2 = tl_node.GetDisplayText("换算(小数位)").Split(new char[] { ',' });
            string[] strArray4 = new string[] { "当日电压合格率", "当月电压合格率" };
            TreeListNode parentNode = null;
            TreeListNode node2 = tl.AppendNode(new object[] { add, OAD_Buff + "-" + tl_node.GetDisplayText("对象名称") }, parentNode);
            if (List_ParseData.Count == 1)
            {
                tl.BeginUnboundLoad();
                if (OAD_Buff.Substring(4, 4) == "0100")
                {
                    node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0], flag ? "成功" : "失败", strArray[0] }, node2);
                }
                else
                {
                    node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), PublicVariable.GetFloatstrFromBCDStr(List_ParseData[0], Convert.ToInt16(strArray2[0])), flag ? "成功" : "失败", strArray[0] }, node2);
                }
                tl.EndUnboundLoad();
            }
            else
            {
                string[] strArray3;
                TreeListNode node4;
                TreeListNode node5;
                tl.BeginUnboundLoad();
                node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), "", "", tl_node.GetDisplayText("对象名称") }, node2);
                if (((OAD_Buff == "21310200") || (OAD_Buff == "21320200")) || (OAD_Buff == "21330200"))
                {
                    tl.BeginUnboundLoad();
                    for (int i = 0; i < 2; i++)
                    {
                        node5 = tl.AppendNode(new object[] { "", strArray4[i] }, node3);
                        for (int j = (i * List_ParseData.Count) / 2; j < (((i + 1) * List_ParseData.Count) / 2); j++)
                        {
                            strArray3 = strArray[j].Split(new char[] { ':' });
                            if (strArray3.Length > 1)
                            {
                                node4 = tl.AppendNode(new object[] { "", strArray3[0], PublicVariable.GetFloatstrFromBCDStr(List_ParseData[j], Convert.ToInt16(strArray2[j])), flag ? "成功" : "失败", strArray3[1] }, node5);
                            }
                            else
                            {
                                node4 = tl.AppendNode(new object[] { "", strArray3[0], PublicVariable.GetFloatstrFromBCDStr(List_ParseData[j], Convert.ToInt16(strArray2[j])), flag ? "成功" : "失败" }, node5);
                            }
                        }
                    }
                    tl.EndUnboundLoad();
                }
                else if ((OAD_Buff.Substring(0, 4) == "2140") || (OAD_Buff.Substring(0, 4) == "2141"))
                {
                    for (int i = 0; i < (List_ParseData.Count / 2); i++)
                    {
                        tl.BeginUnboundLoad();
                        if (List_ParseData.Count > 2)
                        {
                            node4 = tl.AppendNode(new object[] { "", strArray[2 * i], "", "", "" }, node3);
                            node5 = tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), flag ? "成功" : "失败", strArray[2 * i] }, node4);
                            tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), "", strArray[(2 * i) + 1] }, node4);
                        }
                        else
                        {
                            node4 = tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), flag ? "成功" : "失败", strArray[2 * i] }, node3);
                            node5 = tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), flag ? "成功" : "失败", strArray[(2 * i) + 1] }, node3);
                        }
                        tl.EndUnboundLoad();
                    }
                }
                else
                {
                    tl.BeginUnboundLoad();
                    for (int i = 0; i < List_ParseData.Count; i++)
                    {
                        strArray3 = strArray[i].Split(new char[] { ':' });
                        if (strArray3.Length > 1)
                        {
                            node4 = tl.AppendNode(new object[] { "", strArray3[0], PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], Convert.ToInt16(strArray2[i])), flag ? "成功" : "失败", strArray3[1] }, node3);
                        }
                        else
                        {
                            node4 = tl.AppendNode(new object[] { "", strArray3[0], PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], Convert.ToInt16(strArray2[i])), flag ? "成功" : "失败" }, node3);
                        }
                    }
                    tl.EndUnboundLoad();
                }
            }
            tl.ExpandAll();
        }

        private void CreateNodes_参变量(string add, TreeList tl, TreeListNode tl_node, string OAD_Buff, string Linkdata_buff, List<string> List_ParseData, bool flag)
        {
            TreeListNode node3;
            string[] strArray = tl_node.Tag.ToString().Split(new char[] { ',' });
            string[] strArray2 = tl_node.GetDisplayText("换算(小数位)").Split(new char[] { ',' });
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node2 = tl.AppendNode(new object[] { add, OAD_Buff + "-" + tl_node.GetDisplayText("对象名称") }, parentNode);
            if (List_ParseData.Count == 1)
            {
                if (OAD_Buff.Substring(4, 4) == "0100")
                {
                    node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0], flag ? "成功" : "失败", strArray[0] }, node2);
                }
                else
                {
                    node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), PublicVariable.GetFloatstrFromBCDStr(List_ParseData[0], Convert.ToInt16(strArray2[0])), flag ? "成功" : "失败", strArray[0] }, node2);
                }
            }
            else if ((List_ParseData.Count > 1) && (OAD_Buff.Substring(6, 2) != "00"))
            {
                if (OAD_Buff.Substring(0, 4) == "4011")
                {
                    if (List_ParseData.Count >= 2)
                    {
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0] + "(" + List_ParseData[1] + ")", flag ? "成功" : "失败", tl_node.GetDisplayText("对象名称") }, node2);
                    }
                    else
                    {
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0], flag ? "成功" : "失败" }, node2);
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "4014") || (OAD_Buff.Substring(0, 4) == "4015"))
                {
                    if (List_ParseData.Count >= 3)
                    {
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0] + "-" + List_ParseData[1] + "(" + List_ParseData[2] + ")", flag ? "成功" : "失败", tl_node.GetDisplayText("对象名称") }, node2);
                    }
                    else
                    {
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0], flag ? "成功" : "失败" }, node2);
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "4016") || (OAD_Buff.Substring(0, 4) == "4017"))
                {
                    if (List_ParseData.Count >= 3)
                    {
                        for (int i = 0; i < (List_ParseData.Count / 3); i++)
                        {
                            object[] nodeData = new object[] { "", "时段 " + ((i + 1)).ToString(), List_ParseData[3 * i] + List_ParseData[(3 * i) + 1] + "(" + List_ParseData[(3 * i) + 2] + ")", flag ? "成功" : "失败" };
                            node3 = tl.AppendNode(nodeData, node2);
                        }
                    }
                    else
                    {
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0], flag ? "成功" : "失败" }, node2);
                    }
                }
                else if (OAD_Buff.Substring(0, 4) == "4116")
                {
                    if (List_ParseData.Count >= 2)
                    {
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0] + List_ParseData[1], flag ? "成功" : "失败" }, node2);
                    }
                    else
                    {
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), List_ParseData[0], flag ? "成功" : "失败" }, node2);
                    }
                }
            }
            else if ((List_ParseData.Count > 1) && (OAD_Buff.Substring(6, 2) == "00"))
            {
                TreeListNode node4;
                node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), "", flag ? "成功" : "失败", tl_node.GetDisplayText("对象名称") }, node2);
                if (OAD_Buff == "40110200")
                {
                    for (int i = 0; i < (List_ParseData.Count / 2); i++)
                    {
                        object[] nodeData = new object[] { "", tl_node.GetDisplayText("对象名称") + ((i + 1)).ToString(), List_ParseData[2 * i] + "(" + List_ParseData[(2 * i) + 1] + ")", "", "年月日周时段表" };
                        node4 = tl.AppendNode(nodeData, node3);
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "4014") || (OAD_Buff.Substring(0, 4) == "4015"))
                {
                    for (int i = 0; i < (List_ParseData.Count / 3); i++)
                    {
                        object[] nodeData = new object[] { "", tl_node.GetDisplayText("对象名称") + ((i + 1)).ToString(), List_ParseData[3 * i] + "-" + List_ParseData[(3 * i) + 1] + "(" + List_ParseData[(3 * i) + 2] + ")", "", "月日时段表" };
                        node4 = tl.AppendNode(nodeData, node3);
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "4016") || (OAD_Buff.Substring(0, 4) == "4017"))
                {
                    string str = Linkdata_buff.Substring(0x12, 2);
                    string str2 = Linkdata_buff.Substring(0x16, 2);
                    for (int i = 0; i < Convert.ToByte(str, 0x10); i++)
                    {
                        object[] nodeData = new object[] { "", tl_node.GetDisplayText("对象名称") + ((i + 1)).ToString() };
                        node4 = tl.AppendNode(nodeData, node3);
                        for (int j = 0; j < Convert.ToByte(str2, 0x10); j++)
                        {
                            object[] objArray16 = new object[] { "", "时段 " + ((j + 1)).ToString(), List_ParseData[((i * 3) * Convert.ToByte(str2, 0x10)) + (3 * j)] + List_ParseData[((i * 3) * Convert.ToByte(str2, 0x10)) + ((3 * j) + 1)] + "(" + List_ParseData[((i * 3) * Convert.ToByte(str2, 0x10)) + ((3 * j) + 2)] + ")", "" };
                            tl.AppendNode(objArray16, node4);
                        }
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "4018") || (OAD_Buff.Substring(0, 4) == "4019"))
                {
                    for (int i = 0; i < List_ParseData.Count; i++)
                    {
                        object[] nodeData = new object[] { "", tl_node.GetDisplayText("对象名称") + ((i + 1)).ToString(), PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], 4), "", "元/kWh" };
                        node4 = tl.AppendNode(nodeData, node3);
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "401A") || (OAD_Buff.Substring(0, 4) == "401B"))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        object[] nodeData = new object[] { "", "阶梯值" + ((i + 1)).ToString(), PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], 2), "", "kWh" };
                        node4 = tl.AppendNode(nodeData, node3);
                    }
                    for (int j = 6; j < 13; j++)
                    {
                        object[] nodeData = new object[] { "", "阶梯电价" + (((j - 6) + 1)).ToString(), PublicVariable.GetFloatstrFromBCDStr(List_ParseData[j], 4), "", "元/kWh" };
                        node4 = tl.AppendNode(nodeData, node3);
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        object[] nodeData = new object[] { "", "阶梯结算日" + ((k + 1)).ToString(), List_ParseData[13 + (3 * k)] + List_ParseData[(13 + (3 * k)) + 1] + List_ParseData[(13 + (3 * k)) + 2], "", "月日时" };
                        node4 = tl.AppendNode(nodeData, node3);
                    }
                }
                else if (OAD_Buff.Substring(0, 4) == "4116")
                {
                    for (int i = 0; i < (List_ParseData.Count / 2); i++)
                    {
                        object[] nodeData = new object[] { "", "结算日" + ((i + 1)).ToString(), List_ParseData[2 * i] + List_ParseData[(2 * i) + 1] };
                        node4 = tl.AppendNode(nodeData, node3);
                    }
                }
                else
                {
                    for (int i = 0; i < List_ParseData.Count; i++)
                    {
                        string[] strArray3 = strArray[i].Split(new char[] { ':' });
                        if (strArray3.Length > 1)
                        {
                            node4 = tl.AppendNode(new object[] { "", strArray3[0], PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], Convert.ToInt16(strArray2[i])), "", strArray3[1] }, node3);
                        }
                        else
                        {
                            node4 = tl.AppendNode(new object[] { "", strArray3[0], PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], Convert.ToInt16(strArray2[i])) }, node3);
                        }
                    }
                }
            }
            tl.ExpandAll();
            tl.EndUnboundLoad();
        }
        private void CreateNodes_厂内(string add, TreeList tl, TreeListNode tl_node, string dis_err, bool flag)
        {
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node2 = tl.AppendNode(new object[] { add, "645特殊命令-" + tl_node.GetDisplayText("对象名称") }, parentNode);
            tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), dis_err, flag ? "成功" : "失败", "" }, node2);
            tl.ExpandAll();
            tl.EndUnboundLoad();
        }

        private void CreateNodes_电量(string add, TreeList tl, TreeListNode tl_node, string OAD_Buff, List<string> List_ParseData, bool flag)
        {
            TreeListNode node2;
            string displayText = "";
            displayText = tl_node.GetDisplayText("换算(小数位)");
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            if (List_ParseData.Count <= 1)
            {
                string[] strArray = tl_node.Tag.ToString().Split(new char[] { ',' })[0].Split(new char[] { ':' });
                string[] strArray3 = displayText.Split(new char[] { ',' });
                node2 = tl.AppendNode(new object[] { add, OAD_Buff + "-" + tl_node.GetDisplayText("对象名称") }, parentNode);
                if (displayText == "")
                {
                    if (strArray.Length > 1)
                    {
                        tl.AppendNode(new object[] { "", "", List_ParseData[0], flag ? "成功" : "失败", strArray[1] }, node2);
                    }
                    else
                    {
                        tl.AppendNode(new object[] { "", "", List_ParseData[0], flag ? "成功" : "失败", strArray[0] }, node2);
                    }
                }
                else if (strArray.Length > 1)
                {
                    tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[0], Convert.ToInt16(strArray3[0])), flag ? "成功" : "失败", strArray[1] }, node2);
                }
                else
                {
                    tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[0], Convert.ToInt16(strArray3[0])), flag ? "成功" : "失败", strArray[0] }, node2);
                }
            }
            else
            {
                string[] strArray5 = tl_node.Tag.ToString().Split(new char[] { ',' });
                string[] strArray6 = displayText.Split(new char[] { ',' });
                node2 = tl.AppendNode(new object[] { add, OAD_Buff + tl_node.GetDisplayText("对象名称") }, parentNode);
                for (int i = 0; i < List_ParseData.Count; i++)
                {
                    string[] strArray4;
                    if (List_ParseData.Count > strArray5.Length)
                    {
                        strArray4 = strArray5[0].Split(new char[] { ':' });
                    }
                    strArray4 = strArray5[i].Split(new char[] { ':' });
                    if (displayText != "")
                    {
                        tl.AppendNode(new object[] { "", strArray4[0], PublicVariable.GetFloatstrFromBCDStr(List_ParseData[i], Convert.ToInt16(strArray6[i])), flag ? "成功" : "失败", strArray4[1] }, node2);
                    }
                    else
                    {
                        tl.AppendNode(new object[] { "", strArray4[0], List_ParseData[i], flag ? "成功" : "失败", strArray4[1] }, node2);
                    }
                }
            }
            tl.ExpandAll();
            tl.EndUnboundLoad();
        }

        private void CreateNodes_回抄(string add, TreeList tl, TreeListNode tl_node, string OAD_Buff, string ParseData, bool flag)
        {
            TreeListNode node3;
            string[] strArray = tl_node.Tag.ToString().Split(new char[] { ',' });
            string[] strArray2 = tl_node.GetDisplayText("换算(小数位)").Split(new char[] { ',' });
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node2 = tl.AppendNode(new object[] { add, OAD_Buff + "-" + tl_node.GetDisplayText("对象名称") }, parentNode);
            if ((((OAD_Buff.Substring(0, 4) == "4002") || (OAD_Buff.Substring(0, 4) == "4003")) || ((OAD_Buff.Substring(0, 4) == "401C") || (OAD_Buff.Substring(0, 4) == "401D"))) || ((OAD_Buff.Substring(0, 4) == "400A") || (OAD_Buff.Substring(0, 4) == "400B")))
            {
                switch (OAD_Buff.Substring(0, 4))
                {
                    case "4002":
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), ParseData.Substring(0, 0x10).ToString(), flag ? "成功" : "失败", strArray[0] }, node2);
                        break;

                    case "4003":
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), ParseData.Substring(0, 12).ToString(), flag ? "成功" : "失败", strArray[0] }, node2);
                        break;

                    case "401C":
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), ParseData.Substring(0, 6).ToString(), flag ? "成功" : "失败", strArray[0] }, node2);
                        break;

                    case "401D":
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), ParseData.Substring(0, 6).ToString(), flag ? "成功" : "失败", strArray[0] }, node2);
                        break;

                    case "400A":
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), ParseData.Substring(0, 10).ToString(), flag ? "成功" : "失败", strArray[0] }, node2);
                        break;

                    case "400B":
                        node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), ParseData.Substring(0, 10).ToString(), flag ? "成功" : "失败", strArray[0] }, node2);
                        break;
                }
            }
            else
            {
                node3 = tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), "", flag ? "成功" : "失败", tl_node.GetDisplayText("对象名称") }, node2);
                if (OAD_Buff.Substring(0, 4) == "401E")
                {
                    if (OAD_Buff.Substring(4, 4) == "0200")
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            string[] strArray3 = strArray[0].Split(new char[] { ':' });
                            tl.AppendNode(new object[] { "", strArray3[0], PublicVariable.GetFloatstrFromBCDStr(ParseData.Substring(0, 8), Convert.ToInt16(strArray2[i])), "", strArray3[1] }, node3);
                            ParseData = ParseData.Substring(8);
                        }
                    }
                    else
                    {
                        tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), PublicVariable.GetFloatstrFromBCDStr(ParseData.Substring(0, 8), Convert.ToInt16(strArray2[0])), "", strArray[0] }, node3);
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "4018") || (OAD_Buff.Substring(0, 4) == "4019"))
                {
                    if ((OAD_Buff.Substring(4, 4) == "0200") && (ParseData.Length >= 0x100))
                    {
                        for (int i = 0; i < 0x20; i++)
                        {
                            object[] nodeData = new object[] { "", tl_node.GetDisplayText("对象名称") + ((i + 1)).ToString(), PublicVariable.GetFloatstrFromBCDStr(ParseData.Substring(0, 8), Convert.ToInt16(strArray2[0])), "", "元/kWh" };
                            tl.AppendNode(nodeData, node3);
                            ParseData = ParseData.Substring(8);
                        }
                    }
                    else
                    {
                        tl.AppendNode(new object[] { "", tl_node.GetDisplayText("对象名称"), PublicVariable.GetFloatstrFromBCDStr(ParseData.Substring(0, 8), Convert.ToInt16(strArray2[0])), "", strArray[0] }, node3);
                    }
                }
                else if ((OAD_Buff.Substring(0, 4) == "401A") || (OAD_Buff.Substring(0, 4) == "401B"))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        object[] nodeData = new object[] { "", "阶梯值" + ((i + 1)).ToString(), PublicVariable.GetFloatstrFromBCDStr(ParseData.Substring(0, 8), 2), "", "kWh" };
                        tl.AppendNode(nodeData, node3);
                        ParseData = ParseData.Substring(8);
                    }
                    for (int j = 6; j < 13; j++)
                    {
                        object[] nodeData = new object[] { "", "阶梯电价" + (((j - 6) + 1)).ToString(), PublicVariable.GetFloatstrFromBCDStr(ParseData.Substring(0, 8), 4), "", "元/kWh" };
                        tl.AppendNode(nodeData, node3);
                        ParseData = ParseData.Substring(8);
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        object[] nodeData = new object[] { "", "阶梯结算日" + ((k + 1)).ToString(), ParseData.Substring(0, 2) + ParseData.Substring(2, 2) + ParseData.Substring(4, 2), "", "月日时" };
                        tl.AppendNode(nodeData, node3);
                        ParseData = ParseData.Substring(6);
                    }
                }
            }
            tl.ExpandAll();
            tl.EndUnboundLoad();
        }

        private void CreateNodes_需量(string add, TreeList tl, TreeListNode tl_node, string OAD_Buff, List<string> List_ParseData, bool flag)
        {
            TreeListNode node3;
            string[] strArray = tl_node.Tag.ToString().Split(new char[] { ',' });
            string[] strArray2 = tl_node.GetDisplayText("换算(小数位)").Split(new char[] { ',' });
            tl.BeginUnboundLoad();
            TreeListNode parentNode = null;
            TreeListNode node2 = tl.AppendNode(new object[] { add, OAD_Buff + "-" + tl_node.GetDisplayText("对象名称") }, parentNode);
            if (List_ParseData.Count == 1)
            {
                node3 = tl.AppendNode(new object[] { "", strArray[0], List_ParseData[0], "", flag ? "成功" : "失败", strArray[0] }, node2);
            }
            else
            {
                string[] strArray3 = tl_node.GetDisplayText("对象名称").Split(new char[] { '\\' });
                node3 = tl.AppendNode(new object[] { "", strArray3[strArray3.Length - 1] }, node2);
                for (int i = 0; i < (List_ParseData.Count / 2); i++)
                {
                    TreeListNode node4;
                    if (List_ParseData.Count > 2)
                    {
                        node4 = tl.AppendNode(new object[] { "", strArray[2 * i], "", "", "" }, node3);
                        tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), flag ? "成功" : "失败", strArray[2 * i] }, node4);
                        tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), flag ? "成功" : "失败", strArray[(2 * i) + 1] }, node4);
                    }
                    else
                    {
                        node4 = tl.AppendNode(new object[] { "", "", PublicVariable.GetFloatstrFromBCDStr(List_ParseData[2 * i], Convert.ToInt16(strArray2[2 * i])), flag ? "成功" : "失败", strArray[2 * i] }, node3);
                        tl.AppendNode(new object[] { "", "", PublicVariable.GetStringstrFromBCDStr(List_ParseData[(2 * i) + 1]), flag ? "成功" : "失败", strArray[(2 * i) + 1] }, node3);
                    }
                }
            }
            tl.ExpandAll();
            tl.EndUnboundLoad();
        }
        private bool Read_ESAM(TreeListNode tl_node)
        {
            bool flag3;
            try
            {
                if (PublicVariable.IsReading)
                {
                    return false;
                }
                PublicVariable.IsReading = true;
                bool flag = false;
                bool spliteFlag = false;
                string parseData = "";
                string linkdata = "";
                string mAC = "";
                string str4 = "";
                string str5 = "";
                List<string> list = new List<string>();
                StringBuilder cOutData = new StringBuilder(0x3e8);
                string displayText = tl_node.GetDisplayText("数据OAD");
                string str7 = "F1000300";
                parseData = "";
                linkdata = "";
                list.Clear();
                cOutData.Clear();
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.ESAM_Math_纯明文_Read(str7, displayText, ref parseData, ref list, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.ESAM_Math_明文_RN_Read("00", "01", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.ESAM_Math_明文_SIDMAC_Read("00", "00", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.ESAM_Math_密文_SID_Read("01", "03", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.ESAM_Math_密文_SID_MAC_Read("01", "00", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (flag)
                {
                    if (cOutData.ToString() != "")
                    {
                        parseData = cOutData.ToString();
                    }
                    this.CreateNodes_回抄(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, displayText, parseData, flag);
                }
                flag3 = flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
                PublicVariable.IsReading = false;
                flag3 = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
            return flag3;
        }

        private void Read_ESAM(TreeListNode tl_node, string ParseData_比对)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    bool spliteFlag = false;
                    string parseData = "";
                    string linkdata = "";
                    string mAC = "";
                    string str4 = "";
                    string str5 = "";
                    List<string> list = new List<string>();
                    StringBuilder cOutData = new StringBuilder(0x3e8);
                    string displayText = tl_node.GetDisplayText("数据OAD");
                    string str7 = "F1000300";
                    parseData = "";
                    linkdata = "";
                    list.Clear();
                    cOutData.Clear();
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.ESAM_Math_纯明文_Read(str7, displayText, ref parseData, ref list, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.ESAM_Math_明文_RN_Read("00", "01", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.ESAM_Math_明文_SIDMAC_Read("00", "00", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.ESAM_Math_密文_SID_Read("01", "03", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.ESAM_Math_密文_SID_MAC_Read("01", "00", str7, displayText, ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str4, ref spliteFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag ? "-抄读成功" : "-抄读失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    bool flag3 = false;
                    if (flag)
                    {
                        if (cOutData.ToString() != "")
                        {
                            parseData = cOutData.ToString();
                        }
                        flag3 = this.CompareData(tl_node, parseData);
                        PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag3 ? "-比对成功" : "-比对失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                        this.CreateNodes_回抄(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, displayText, parseData, flag3);
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

        private bool ReadFlag(TreeListNode tl_node)
        {
            try
            {
                bool flag = false;
                string cData = "";
                bool splitFlag = false;
                string str2 = "";
                string str3 = "";
                List<string> parseData = new List<string>();
                string linkdata = "";
                string str5 = "";
                string mAC = "";
                StringBuilder cOutData = new StringBuilder(0x7d0);
                string displayText = tl_node.GetDisplayText("数据OAD");
                cData = "";
                parseData.Clear();
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), displayText, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol_2.GetRequestNormal(displayText, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, ref str3, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                        str5 = cData;
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol_2.Math_明文_RN("00", "01", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                        str5 = linkdata;
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol_2.Math_明文_SIDMAC("00", "00", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                        str5 = cOutData.ToString();
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol_2.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        str5 = cOutData.ToString();
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol_2.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        str5 = cOutData.ToString();
                        break;
                }
                PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (flag)
                {
                    switch (str3.Substring(0, 1))
                    {
                        case "0":
                            this.CreateNodes_电量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, parseData, flag);
                            break;

                        case "1":
                            this.CreateNodes_需量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, parseData, flag);
                            break;

                        case "2":
                            this.CreateNodes_变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, parseData, flag);
                            break;

                        case "3":
                            this.CreateNodes_参变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, str5, parseData, flag);
                            break;

                        case "4":
                            this.CreateNodes_参变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, str5, parseData, flag);
                            break;

                        case "8":
                            this.CreateNodes_参变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, str5, parseData, flag);
                            break;
                    }
                }
                else
                {
                    string dARInfo = "";
                    if (parseData.Count == 0)
                    {
                        dARInfo = "无返回";
                    }
                    else
                    {
                        dARInfo = PublicVariable.DARInfo;
                    }
                    this.CreateNodes_ERR(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, dARInfo, flag);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void ReadFlag(TreeListNode tl_node, string ParseData_比对)
        {
            try
            {
                bool flag = false;
                string cData = "";
                bool splitFlag = false;
                string str2 = "";
                string str3 = "";
                List<string> parseData = new List<string>();
                string linkdata = "";
                string str5 = "";
                string mAC = "";
                StringBuilder cOutData = new StringBuilder(200);
                string displayText = tl_node.GetDisplayText("数据OAD");
                cData = "";
                parseData.Clear();
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), displayText, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol_2.GetRequestNormal(displayText, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, ref str3, ref parseData, PublicVariable.TimeTag, ref splitFlag);
                        str5 = cData;
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol_2.Math_明文_RN("00", "01", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                        str5 = linkdata;
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol_2.Math_明文_SIDMAC("00", "00", ref linkdata, ref str3, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                        str5 = cOutData.ToString();
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol_2.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        str5 = cOutData.ToString();
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol_2.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                        str5 = cOutData.ToString();
                        break;
                }
                PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag ? "-抄读成功" : "-抄读失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                bool flag3 = false;
                if (flag)
                {
                    flag3 = this.CompareData(tl_node, parseData, str5);
                    PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag3 ? "-比对成功" : "-比对失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag3 ? "Blue" : "Red";
                    switch (str3.Substring(0, 1))
                    {
                        case "0":
                            this.CreateNodes_电量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, parseData, flag3);
                            return;

                        case "1":
                            this.CreateNodes_需量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, parseData, flag3);
                            return;

                        case "2":
                            this.CreateNodes_变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, parseData, flag3);
                            return;

                        case "3":
                            this.CreateNodes_参变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, str5, parseData, flag3);
                            return;

                        case "4":
                            this.CreateNodes_参变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, str5, parseData, flag3);
                            return;

                        case "8":
                            this.CreateNodes_参变量(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, str5, parseData, flag);
                            return;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Set(TreeListNode tl_node)
        {
            bool flag3;
            try
            {
                bool flag = false;
                string cData = "";
                bool splitFlag = false;
                string data = "";
                List<string> frameData = new List<string>();
                string str3 = "";
                string str4 = "";
                string parseData = "";
                List<string> list2 = new List<string>();
                string linkdata = "";
                string mAC = "";
                StringBuilder cOutData = new StringBuilder(0x7d0);
                string dataType = tl_node.GetDisplayText("数据类型集合").Replace(",", "");
                string dataLen = tl_node.GetDisplayText("数据长度集合").Replace(",", "");
                string str10 = tl_node.GetDisplayText("数据OAD").Replace(",", "");
                List<string> list3 = new List<string>();
                list3.AddRange(tl_node.GetDisplayText("参数").Split(new char[] { ','}));
                //list3.AddRange(tl_node.GetDisplayText("参数").Split(new char[] { ',', 0xff0c }));
                string[] strArray = tl_node.GetDisplayText("换算(小数位)").Split(new char[] { ',' });
                string[] strArray2 = tl_node.GetDisplayText("数据类型集合").Split(new char[] { ',' });
                string[] strArray3 = tl_node.GetDisplayText("数据长度集合").Split(new char[] { ',' });
                List<string> list4 = new List<string>();
                List<string> list5 = new List<string>();
                for (int i = 0; i < strArray2.Length; i++)
                {
                    if ((strArray2[i] != "02") && (strArray2[i] != "01"))
                    {
                        list5.Add(strArray3[i]);
                        list4.Add(strArray2[i]);
                    }
                }
                data = "";
                if (((str10.Substring(0, 4) == "4014") || (str10.Substring(0, 4) == "4015")) || ((str10.Substring(0, 4) == "4016") || (str10.Substring(0, 4) == "4017")))
                {
                    data = tl_node.GetDisplayText("参数").Replace(",", "");
                }
                else
                {
                    for (int j = 0; j < list5.Count; j++)
                    {
                        if ((((list4[j] != "04") && (list4[j] != "09")) && ((list4[j] != "10") && (list4[j] != "26"))) && (list4[j] != "28"))
                        {
                            if (list3[j] != "FF")
                            {
                                double num3 = Convert.ToDouble(list3[j].Trim().PadLeft(Convert.ToByte(list5[j]) * 2, '0')) * Math.Pow(10.0, Convert.ToDouble(strArray[j]));
                                data = data + num3.ToString().PadLeft(Convert.ToByte(list5[j]) * 2, '0');
                            }
                            else
                            {
                                data = data + list3[j].PadLeft(Convert.ToByte(list5[j]) * 2, '0');
                            }
                        }
                        else if ((list4[j] == "10") || (list4[j] == "04"))
                        {
                            data = data + tl_node.GetDisplayText("参数").Split(new char[] { ',' })[j];
                        }
                        else
                        {
                            data = data + tl_node.GetDisplayText("参数").Split(new char[] { ',' })[j].PadLeft(Convert.ToByte(list5[j]) * 2, '0');
                        }
                    }
                }
                cData = "";
                frameData.Clear();
                cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), str10 + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str10, cData, PublicVariable.TimeTag, ref splitFlag);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                this.CreateNodes_操作_设置(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str10, parseData, flag);
                flag3 = flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
                PublicVariable.IsReading = false;
                flag3 = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
            return flag3;
        }

        private bool Special_645_Command(TreeListNode tl_node)
        {
            try
            {
                bool flag = false;
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68" + tl_node.GetDisplayText("参数");
                dataFrame = dataFrame + InnerCommand.CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                string str3 = "";
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    flag = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "进入厂内" + (flag ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
                if (!flag && (dataRegion.Length != 0))
                {
                    str3 = "进厂失败！";
                }
                else if (!flag && (dataRegion.Length == 0))
                {
                    str3 = "无返回";
                }
                this.CreateNodes_厂内(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, flag);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
                return false;
            }
        }

        private void tl_显示_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "结果(比对)")
            {
                if (e.Node.GetDisplayText("结果(比对)") == "成功")
                {
                    e.Appearance.BackColor = Color.Aqua;
                    e.Appearance.Options.UseBackColor = true;
                }
                else if (e.Node.GetDisplayText("结果(比对)") == "失败")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.Options.UseBackColor = true;
                }
            }
        }

        private void treeList_批操作_DoubleClick(object sender, EventArgs e)
        {
            this.treeList_批操作.CheckAll();
        }

        private void txt_Count_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar != '\b') && ((e.KeyChar < '0') || (e.KeyChar > '9')))
                {
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool Write_ESAM更新(TreeListNode tl_node)
        {
            bool flag3;
            if (PublicVariable.IsReading)
            {
                return false;
            }
            PublicVariable.IsReading = true;
            try
            {
                string str8;
                string[] strArray2;
                int num;
                string str9;
                string[] strArray3;
                int num4;
                bool flag = false;
                string cData = "";
                bool spliteFlag = false;
                string str2 = "";
                string str3 = "";
                string parseData = "";
                List<string> list = new List<string>();
                string displayText = tl_node.GetDisplayText("数据OAD");
                string str6 = "F1000400";
                string mAC = "";
                StringBuilder cOutData = new StringBuilder(0x3e8);
                cData = "";
                parseData = "";
                list.Clear();
                switch (displayText)
                {
                    case "40020200":
                        cData = displayText + "08" + tl_node.GetDisplayText("参数").PadLeft(8, '0');
                        goto Label_042C;

                    case "40030200":
                        cData = displayText + tl_node.GetDisplayText("数据长度集合").PadLeft(2, '0') + tl_node.GetDisplayText("参数").PadLeft(6, '0');
                        goto Label_042C;

                    case "401C0200":
                        cData = displayText + tl_node.GetDisplayText("数据长度集合").PadLeft(2, '0') + tl_node.GetDisplayText("参数").PadLeft(3, '0');
                        goto Label_042C;

                    case "401D0200":
                        cData = displayText + tl_node.GetDisplayText("数据长度集合").PadLeft(2, '0') + tl_node.GetDisplayText("参数").PadLeft(3, '0');
                        goto Label_042C;

                    case "401E0200":
                        {
                            string[] strArray = tl_node.GetDisplayText("参数").Split(new char[] { ',' });
                            cData = displayText + "08" + Convert.ToInt32((float)(float.Parse(strArray[0]) * 100f)).ToString().PadLeft(8, '0') + Convert.ToInt32((float)(float.Parse(strArray[1]) * 100f)).ToString().PadLeft(8, '0');
                            goto Label_042C;
                        }
                    case "400A0200":
                    case "400B0200":
                        cData = displayText + tl_node.GetDisplayText("数据长度集合").PadLeft(2, '0') + tl_node.GetDisplayText("参数").PadLeft(10, '0');
                        goto Label_042C;

                    case "401A0200":
                    case "401B0200":
                        str8 = "";
                        strArray2 = tl_node.GetDisplayText("参数").Split(new char[] { ',' });
                        num = 0;
                        goto Label_033C;

                    case "40180200":
                    case "40190200":
                        str9 = "";
                        strArray3 = tl_node.GetDisplayText("参数").Split(new char[] { ',' });
                        num4 = 0;
                        goto Label_0417;

                    default:
                        goto Label_042C;
                }
            Label_0306:
                str8 = str8 + Convert.ToInt32((float)(float.Parse(strArray2[num]) * 100f)).ToString().PadLeft(8, '0');
                num++;
            Label_033C:
                if (num < 6)
                {
                    goto Label_0306;
                }
                for (int i = 6; i < 13; i++)
                {
                    str8 = str8 + Convert.ToInt32((float)(float.Parse(strArray2[i]) * 10000f)).ToString().PadLeft(8, '0');
                }
                for (int j = 13; j < 0x19; j++)
                {
                    str8 = str8 + strArray2[j];
                }
                cData = displayText + "40" + str8;
                goto Label_042C;
            Label_03E1:
                str9 = str9 + Convert.ToInt32((float)(float.Parse(strArray3[num4]) * 10000f)).ToString().PadLeft(8, '0');
                num4++;
            Label_0417:
                if (num4 < 0x20)
                {
                    goto Label_03E1;
                }
                cData = displayText + "80" + str9;
            Label_042C:
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.ESAM_Math_纯明文_Write(str6, cData, ref parseData, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.ESAM_Math_明文_RN_Write("00", "01", str6, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.ESAM_Math_明文_SIDMAC_Write("00", "00", str6, ref cData, ref parseData, ref list, ref mAC, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.ESAM_Math_密文_SID_Write("01", "03", str6, ref cData, ref parseData, ref list, ref mAC, ref str2, ref str3, ref spliteFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.ESAM_Math_密文_SID_MAC_Write("01", "00", str6, ref cData, ref parseData, ref list, ref mAC, ref str2, ref str3, ref spliteFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = tl_node.GetDisplayText("对象名称") + (flag ? "-更新成功" : "-更新失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                this.CreateNodes_操作_设置(PublicVariable.Address.Substring(2, 12), this.tl_显示, tl_node, str3, parseData, flag);
                flag3 = flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
                PublicVariable.IsReading = false;
                flag3 = false;
            }
            finally
            {
                PublicVariable.IsReading = false;
            }
            return flag3;
        }


    }
}
