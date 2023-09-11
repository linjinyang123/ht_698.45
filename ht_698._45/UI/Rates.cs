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
    public partial class Rates : Form
    {

        private FollowRepoartAndTimeTag followForm;
        private IniFile iniFile = new IniFile(Application.StartupPath + @"\Tariff_rate.ini");
        private CheckBox[] cbArray = new CheckBox[9];
        private CheckBox[] cb_sdbArray = new CheckBox[8];
        private TextBox[] txtArray = new TextBox[5];
        private ListBox[] lsbArray = new ListBox[8];
        private bool bCopy;
        private string[] strTemp_Sdb = new string[14];
        private string[,] L_Sd = new string[8, 14];
        private string[] L_Sq = new string[14];
        private string[] L_Ggjr = new string[0xfe];
        private int L_iFls = 0x20;
        private int L_iGgjr;
        private int L_iGgjrs = 0xfe;
        private int L_iSd;
        private int L_iSdb = 1;
        private int L_iSdbs = 8;
        private int L_iSds = 14;
        private int L_iSq;
        private int L_iSqs = 14;
        private int L_iZxSd;
        public Rates(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            this.InitBox();
        }
        private void AddSd()
        {
            string item = "";
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    this.lsbArray[i].Items.Clear();
                }
                for (int j = 0; j < this.L_iSdbs; j++)
                {
                    for (int k = 0; k < this.L_iSds; k++)
                    {
                        item = this.L_Sd[j, k].Substring(0, 2) + ":" + this.L_Sd[j, k].Substring(2, 2) + "(" + this.L_Sd[j, k].Substring(4, 2) + ")";
                        this.lsbArray[j].Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "AddSd" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_WeekSet_Click(object sender, EventArgs e)
        {
            Weekset weekset = new Weekset(this.txt_Zxr.Text);
            if (weekset.ShowDialog() == DialogResult.OK)
            {
                this.txt_Zxr.Text = weekset.Tag.ToString();
            }
        }

        private void cb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_All.Checked)
            {
                this.cbx_时区时段数.Checked = true;
                this.cbx_5.Checked = true;
                this.cbx_6.Checked = true;
                this.cbx_7.Checked = true;
                this.cbx_8.Checked = true;
                this.cbx_时段表.Checked = true;
                this.cb_时区表.Checked = true;
                this.cb_假日.Checked = true;
            }
            else
            {
                this.cbx_时区时段数.Checked = false;
                this.cbx_5.Checked = false;
                this.cbx_6.Checked = false;
                this.cbx_7.Checked = false;
                this.cbx_8.Checked = false;
                this.cbx_时段表.Checked = false;
                this.cb_时区表.Checked = false;
                this.cb_假日.Checked = false;
            }
        }

        private void cbx_Fl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SddataToListBox();
        }

        private void cbx_Sdb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SqdataToListBox();
        }

        private void cbx_Sdb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GgjrdataToListBox();
        }

        private void cbx_时段表_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbx_时段表.Checked)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        this.cb_sdbArray[i].Checked = true;
                        this.cb_sdbArray[i].Enabled = false;
                    }
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        this.cb_sdbArray[i].Checked = false;
                        this.cb_sdbArray[i].Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void cbx_时区时段数_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbx_时区时段数.Checked)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        this.cbArray[i].Checked = true;
                        this.cbArray[i].Enabled = false;
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        this.cbArray[i].Checked = false;
                        this.cbArray[i].Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 复制时段表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copy_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 14; i++)
                {
                    this.strTemp_Sdb[i] = this.L_Sd[this.L_iSdb - 1, i];
                }
                this.bCopy = true;
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "Copy_Click" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtp_Ggjr_ValueChanged(object sender, EventArgs e)
        {
            this.GgjrdataToListBox();
        }

        private void dtp_Sq_ValueChanged(object sender, EventArgs e)
        {
            this.SqdataToListBox();
        }

        private void dtp_Time_ValueChanged(object sender, EventArgs e)
        {
            this.SddataToListBox();
        }
        private void GetFromIni()
        {
            string str = "";
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int m = 0; m < 14; m++)
                    {
                        str = this.iniFile.IniReadValue("SDB_" + i.ToString(), "SD" + m.ToString());
                        if (str == "")
                        {
                            str = "000001";
                        }
                        this.L_Sd[i, m] = str;
                    }
                }
                for (int j = 0; j < 14; j++)
                {
                    str = this.iniFile.IniReadValue("SQ", "SQ" + j.ToString());
                    if (str == "")
                    {
                        str = "010101";
                    }
                    this.L_Sq[j] = str;
                }
                for (int k = 0; k < 0xfe; k++)
                {
                    str = this.iniFile.IniReadValue("GGJR", "GGJR" + k.ToString());
                    if (str == "")
                    {
                        str = "201201010101";
                    }
                    this.L_Ggjr[k] = str;
                }
                str = this.iniFile.IniReadValue("SQSD", "Sqs");
                if (str == "")
                {
                    str = "14";
                }
                this.L_iSqs = Convert.ToInt32(str, 10);
                this.txt_0.Text = str;
                str = this.iniFile.IniReadValue("SQSD", "Sdbs");
                if (str == "")
                {
                    str = "8";
                }
                this.L_iSdbs = Convert.ToInt32(str, 10);
                this.txt_1.Text = str;
                str = this.iniFile.IniReadValue("SQSD", "Sds");
                if (str == "")
                {
                    str = "14";
                }
                this.L_iSds = Convert.ToInt32(str, 10);
                this.txt_2.Text = str;
                str = this.iniFile.IniReadValue("SQSD", "WeekSet");
                if (str == "")
                {
                    str = "00";
                }
                this.txt_Zxr.Text = str;
                str = this.iniFile.IniReadValue("SQSD", "Fls");
                if (str == "")
                {
                    str = "4";
                }
                this.L_iFls = Convert.ToInt32(str, 10);
                this.txt_3.Text = str;
                str = this.iniFile.IniReadValue("SQSD", "Ggjr");
                if (str == "")
                {
                    str = "0";
                }
                this.L_iGgjrs = Convert.ToInt32(str, 10);
                this.txt_4.Text = str;
                str = this.iniFile.IniReadValue("SQSD", "Zx");
                if (str == "")
                {
                    str = "1";
                }
                this.L_iZxSd = Convert.ToInt32(str, 10);
                this.txt_ZxSd.Text = str;
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "GetFromIni" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GgjrdataToListBox()
        {
            string str = "";
            string item = "";
            int num = 0;
            switch (this.dtp_Ggjr.Value.DayOfWeek.ToString())
            {
                case "Monday":
                    str = "01";
                    break;

                case "Tuesday":
                    str = "02";
                    break;

                case "Wednesday":
                    str = "03";
                    break;

                case "Thursday":
                    str = "04";
                    break;

                case "Friday":
                    str = "05";
                    break;

                case "Saturday":
                    str = "06";
                    break;

                case "Sunday":
                    str = "00";
                    break;
            }
            if (this.cbx_Sdb2.Text.Trim() == "")
            {
                str = str + "01";
            }
            else
            {
                str = str + this.cbx_Sdb2.Text.Trim().PadLeft(2, '0');
            }
            this.L_Ggjr[this.L_iGgjr] = this.dtp_Ggjr.Value.Year.ToString().PadLeft(4, '0') + this.dtp_Ggjr.Value.Month.ToString().PadLeft(2, '0') + this.dtp_Ggjr.Value.Day.ToString().PadLeft(2, '0') + str;
            this.lsb_Ggjr.Items.Clear();
            for (int i = 0; i < this.L_iGgjrs; i++)
            {
                num = i + 1;
                item = "第" + num.ToString() + "假日: " + this.L_Ggjr[i].Substring(0, 4) + "-" + this.L_Ggjr[i].Substring(4, 2) + "-" + this.L_Ggjr[i].Substring(6, 2) + "-" + this.L_Ggjr[i].Substring(8, 2) + "(" + this.L_Ggjr[i].Substring(10, 2) + ")";
                this.lsb_Ggjr.Items.Add(item);
            }
            this.lsb_Ggjr.SelectedIndex = this.L_iGgjr;
        }

        private void InitBox()
        {
            this.cbArray[0] = this.cbx_0;
            this.cbArray[1] = this.cbx_1;
            this.cbArray[2] = this.cbx_2;
            this.cbArray[3] = this.cbx_3;
            this.cbArray[4] = this.cbx_4;
            this.cbArray[5] = this.cbx_5;
            this.cbArray[6] = this.cbx_6;
            this.cbArray[7] = this.cbx_7;
            this.cbArray[8] = this.cbx_8;
            this.txtArray[0] = this.txt_0;
            this.txtArray[1] = this.txt_1;
            this.txtArray[2] = this.txt_2;
            this.txtArray[3] = this.txt_3;
            this.txtArray[4] = this.txt_4;
            this.cb_sdbArray[0] = this.cb_sdb0;
            this.cb_sdbArray[1] = this.cb_sdb1;
            this.cb_sdbArray[2] = this.cb_sdb2;
            this.cb_sdbArray[3] = this.cb_sdb3;
            this.cb_sdbArray[4] = this.cb_sdb4;
            this.cb_sdbArray[5] = this.cb_sdb5;
            this.cb_sdbArray[6] = this.cb_sdb6;
            this.cb_sdbArray[7] = this.cb_sdb7;
            this.lsbArray[0] = this.lsb_sdb1;
            this.lsbArray[1] = this.lsb_sdb2;
            this.lsbArray[2] = this.lsb_sdb3;
            this.lsbArray[3] = this.lsb_sdb4;
            this.lsbArray[4] = this.lsb_sdb5;
            this.lsbArray[5] = this.lsb_sdb6;
            this.lsbArray[6] = this.lsb_sdb7;
            this.lsbArray[7] = this.lsb_sdb8;
        }

        private void lsb_Ggjr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                string str2 = "";
                string str3 = "";
                this.L_iGgjr = this.lsb_Ggjr.SelectedIndex;
                if (this.L_iGgjr != -1)
                {
                    str = this.L_Ggjr[this.L_iGgjr].Substring(0, 4);
                    str2 = this.L_Ggjr[this.L_iGgjr].Substring(4, 2);
                    str3 = this.L_Ggjr[this.L_iGgjr].Substring(6, 2);
                    this.L_Ggjr[this.L_iGgjr].Substring(8, 2);
                    for (int i = 0; i < this.cbx_Sdb2.Items.Count; i++)
                    {
                        if (this.cbx_Sdb2.Items[i].ToString().PadLeft(2, '0') == this.L_Ggjr[this.L_iGgjr].Substring(10, 2))
                        {
                            this.cbx_Sdb2.SelectedIndex = i;
                            break;
                        }
                    }
                    if (this.L_Ggjr[this.L_iGgjr].Substring(0, 4) == "FFFF")
                    {
                        str = "2016";
                    }
                    if (this.L_Ggjr[this.L_iGgjr].Substring(4, 2) == "FF")
                    {
                        str2 = "06";
                    }
                    if (this.L_Ggjr[this.L_iGgjr].Substring(5, 2) == "FF")
                    {
                        str3 = "06";
                    }
                    this.dtp_Ggjr.Text = str + "-" + str2 + "-" + str3;
                    this.lsb_Ggjr.SelectedIndex = this.L_iGgjr;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_Ggjr_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 1;
                this.L_iSd = this.lsb_sdb1.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb1.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb1.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sdb1_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 2;
                this.L_iSd = this.lsb_sdb2.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb2.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb2.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sbd2_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 3;
                this.L_iSd = this.lsb_sdb3.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb3.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb3.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sbd3_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 4;
                this.L_iSd = this.lsb_sdb4.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb4.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb4.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sbd4_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 5;
                this.L_iSd = this.lsb_sdb5.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb5.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb5.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sbd5_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 6;
                this.L_iSd = this.lsb_sdb6.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb6.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb6.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sbd6_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 7;
                this.L_iSd = this.lsb_sdb7.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb7.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb7.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sbd7_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_sdb8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = "";
                this.L_iSdb = 8;
                this.L_iSd = this.lsb_sdb8.SelectedIndex;
                if (this.L_iSd != -1)
                {
                    sText = this.lsb_sdb8.SelectedItem.ToString();
                    this.ShowText(sText);
                    this.lsb_sdb8.SelectedIndex = this.L_iSd;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_sbd8_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsb_Sq_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                string str2 = "";
                this.L_iSq = this.lsb_Sq.SelectedIndex;
                if (this.L_iSq != -1)
                {
                    str = this.L_Sq[this.L_iSq].Substring(0, 2);
                    str2 = this.L_Sq[this.L_iSq].Substring(2, 2);
                    for (int i = 0; i < this.cbx_Sdb1.Items.Count; i++)
                    {
                        if (this.cbx_Sdb1.Items[i].ToString().PadLeft(2, '0') == this.L_Sq[this.L_iSq].Substring(4, 2))
                        {
                            this.cbx_Sdb1.SelectedIndex = i;
                            break;
                        }
                    }
                    if (this.L_Sq[this.L_iSq].Substring(0, 2) == "00")
                    {
                        str = "01";
                    }
                    if (this.L_Sq[this.L_iSq].Substring(2, 2) == "00")
                    {
                        str2 = "01";
                    }
                    this.dtp_Sq.Text = str + "-" + str2;
                    this.lsb_Sq.SelectedIndex = this.L_iSq;
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "lsb_Ggjr_SelectedIndexChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// 黏贴时段表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Paste_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.bCopy)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        this.L_Sd[this.L_iSdb - 1, i] = this.strTemp_Sdb[i];
                    }
                    this.lsbArray[this.L_iSdb - 1].Items.Clear();
                    string item = "";
                    for (int j = 0; j < this.L_iSds; j++)
                    {
                        item = "";
                        item = this.L_Sd[this.L_iSdb - 1, j].Substring(0, 2) + ":" + this.L_Sd[this.L_iSdb - 1, j].Substring(2, 2) + "(" + this.L_Sd[this.L_iSdb - 1, j].Substring(4, 2) + ")";
                        this.lsbArray[this.L_iSdb - 1].Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "mnu_Paste_Click" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Rates_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PublicVariable.IsReading)
            {
                if (MessageBox.Show("正在通讯中，您要强行退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                    PublicVariable.IsReading = false;
                    this.SaveToIni();
                }
            }
            else
            {
                this.SaveToIni();
            }
        }

        private void Rates_Load(object sender, EventArgs e)
        {
            this.GetFromIni();
        }
        private void SaveToIni()
        {
            try
            {
                this.iniFile.IniWriteValue("SQSD", "Sdbs", this.txt_1.Text.Trim());
                this.iniFile.IniWriteValue("SQSD", "Sds", this.txt_2.Text.Trim());
                this.iniFile.IniWriteValue("SQSD", "Sqs", this.txt_0.Text.Trim());
                this.iniFile.IniWriteValue("SQSD", "Ggjr", this.txt_4.Text.Trim());
                this.iniFile.IniWriteValue("SQSD", "Fls", this.txt_3.Text.Trim());
                this.iniFile.IniWriteValue("SQSD", "Zx", this.txt_ZxSd.Text.Trim());
                this.iniFile.IniWriteValue("SQSD", "WeekSet", this.txt_Zxr.Text.Trim());
                for (int i = 0; i < 8; i++)
                {
                    for (int m = 0; m < 14; m++)
                    {
                        this.iniFile.IniWriteValue("SDB_" + i.ToString(), "SD" + m.ToString(), this.L_Sd[i, m]);
                    }
                }
                for (int j = 0; j < 14; j++)
                {
                    this.iniFile.IniWriteValue("SQ", "SQ" + j.ToString(), this.L_Sq[j]);
                }
                for (int k = 0; k < 0xfe; k++)
                {
                    this.iniFile.IniWriteValue("GGJR", "GGJR" + k.ToString(), this.L_Ggjr[k]);
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "SaveToIni" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SddataToListBox()
        {
            try
            {
                string str = "";
                string item = "";
                if (this.cbx_Fl.Text.Trim() == "")
                {
                    str = "01";
                }
                else
                {
                    str = this.cbx_Fl.Text.Trim().PadLeft(2, '0');
                }
                this.L_Sd[this.L_iSdb - 1, this.L_iSd] = this.dtp_Time.Value.Hour.ToString().PadLeft(2, '0') + this.dtp_Time.Value.Minute.ToString().PadLeft(2, '0') + str;
                for (int i = 0; i < this.L_iSdbs; i++)
                {
                    this.lsbArray[i].Items.Clear();
                    for (int j = 0; j < this.L_iSds; j++)
                    {
                        item = this.L_Sd[i, j].Substring(0, 2) + ":" + this.L_Sd[i, j].Substring(2, 2) + "(" + this.L_Sd[i, j].Substring(4, 2) + ")";
                        this.lsbArray[i].Items.Add(item);
                    }
                }
                this.lsbArray[this.L_iSdb - 1].SelectedIndex = this.L_iSd;
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "SddataToListBox" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ShowText(string sText)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            try
            {
                str3 = (sText.Substring(6, 2) == "FF") ? "01" : sText.Substring(6, 2);
                for (int i = 0; i < this.cbx_Fl.Items.Count; i++)
                {
                    if (this.cbx_Fl.Items[i].ToString().PadLeft(2, '0') == str3)
                    {
                        this.cbx_Fl.SelectedIndex = i;
                        break;
                    }
                }
                str = (sText.Substring(0, 2) == "FF") ? "00" : sText.Substring(0, 2);
                str2 = (sText.Substring(2, 2) == "FF") ? "00" : sText.Substring(3, 2);
                str3 = str + ":" + str2 + ":00";
                this.dtp_Time.Text = str3;
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "ShowText" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SqdataToListBox()
        {
            string str = "";
            string item = "";
            int num = 0;
            if (this.cbx_Sdb1.Text.Trim() == "")
            {
                str = "01";
            }
            else
            {
                str = this.cbx_Sdb1.Text.Trim().PadLeft(2, '0');
            }
            this.L_Sq[this.L_iSq] = this.dtp_Sq.Value.Month.ToString().PadLeft(2, '0') + this.dtp_Sq.Value.Day.ToString().PadLeft(2, '0') + str;
            this.lsb_Sq.Items.Clear();
            for (int i = 0; i < this.L_iSqs; i++)
            {
                num = i + 1;
                item = "第" + num.ToString() + "时区: " + this.L_Sq[i].Substring(0, 2) + "-" + this.L_Sq[i].Substring(2, 2) + "(" + this.L_Sq[i].Substring(4, 2) + ")";
                this.lsb_Sq.Items.Add(item);
            }
            this.lsb_Sq.SelectedIndex = this.L_iSq;
        }

        private void tbn_单属性设置_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                string cData = "";
                bool splitFlag = false;
                string data = "";
                string dataType = "021717171717";
                string dataLen = "050101010101";
                string str5 = "";
                string str6 = "";
                string parseData = "";
                List<string> list = new List<string>();
                string linkdata = "";
                string mAC = "";
                StringBuilder cOutData = new StringBuilder(0x7d0);
                string str10 = "400C0200";
                List<string> frameData = new List<string>();
                if (((this.cbx_时区时段数 != null) && this.cbx_时区时段数.Visible) && this.cbx_时区时段数.Checked)
                {
                    cData = "";
                    parseData = "";
                    list.Clear();
                    for (int k = 0; k < 5; k++)
                    {
                        data = data + this.txtArray[k].Text.PadLeft(2, '0');
                    }
                    cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
                    linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), str10 + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str10, cData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.cbx_时区时段数.Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
                else
                {
                    string[] strArray = new string[] { "400C0201", "400C0202", "400C0203", "400C0204", "400C0205" };
                    byte num2 = 0x11;
                    byte num3 = 1;
                    for (int k = 0; k < 5; k++)
                    {
                        if (((this.cbArray[k] == null) || !this.cbArray[k].Visible) || !this.cbArray[k].Checked)
                        {
                            continue;
                        }
                        cData = "";
                        data = "";
                        frameData.Clear();
                        parseData = "";
                        list.Clear();
                        data = this.txtArray[k].Text.PadLeft(2, '0');
                        cData = Protocol.From_Type_GetData(num2, num3, ref data);
                        linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[k] + cData, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[k], cData, PublicVariable.TimeTag, ref splitFlag);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = this.cbArray[k].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
                string[] strArray2 = new string[] { "40090200", "40080200", "40130200", "40120200" };
                byte num5 = 0;
                byte num6 = 0;
                for (int i = 5; i < (5 + strArray2.Length); i++)
                {
                    if ((!this.cbArray[i].Checked || !this.cbArray[i].Visible) || (this.cbArray[i] == null))
                    {
                        continue;
                    }
                    parseData = "";
                    list.Clear();
                    cData = "";
                    data = "";
                    frameData.Clear();
                    switch (i)
                    {
                        case 5:
                            num5 = 0x1c;
                            num6 = 5;
                            data = this.msT_Sdbqh.Text.Substring(0, this.msT_Sdbqh.Text.LastIndexOf("年")).PadLeft(4, '0') + this.msT_Sdbqh.Text.Substring(this.msT_Sdbqh.Text.IndexOf("年") + 1, 2).PadLeft(2, '0') + this.msT_Sdbqh.Text.Substring(this.msT_Sdbqh.Text.IndexOf("月") + 1, 2).PadLeft(2, '0') + this.msT_Sdbqh.Text.Substring(this.msT_Sdbqh.Text.IndexOf("日") + 1, 2).PadLeft(2, '0') + this.msT_Sdbqh.Text.Substring(this.msT_Sdbqh.Text.IndexOf("时") + 1, 2).PadLeft(2, '0') + "00";
                            break;

                        case 6:
                            num5 = 0x1c;
                            num6 = 5;
                            data = this.msT_Sqbqh.Text.Substring(0, this.msT_Sqbqh.Text.LastIndexOf("年")).PadLeft(4, '0') + this.msT_Sqbqh.Text.Substring(this.msT_Sqbqh.Text.IndexOf("年") + 1, 2).PadLeft(2, '0') + this.msT_Sqbqh.Text.Substring(this.msT_Sqbqh.Text.IndexOf("月") + 1, 2).PadLeft(2, '0') + this.msT_Sqbqh.Text.Substring(this.msT_Sqbqh.Text.IndexOf("日") + 1, 2).PadLeft(2, '0') + this.msT_Sqbqh.Text.Substring(this.msT_Sqbqh.Text.IndexOf("时") + 1, 2).PadLeft(2, '0') + "00";
                            break;

                        case 7:
                            num5 = 0x11;
                            num6 = 1;
                            data = this.txt_ZxSd.Text.PadLeft(2, '0');
                            break;

                        case 8:
                            num5 = 4;
                            num6 = 8;
                            data = this.txt_Zxr.Text.PadLeft(2, '0');
                            break;
                    }
                    cData = Protocol.From_Type_GetData(num5, num6, ref data);
                    linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray2[i - 5] + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray2[i - 5], cData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = this.cbArray[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
                string[] strArray3 = new string[8];
                string text = "";
                for (int j = 0; j < this.cb_sdbArray.Length; j++)
                {
                    if ((!this.cb_sdbArray[j].Visible || (this.cb_sdbArray[j] == null)) || (!this.cb_sdbArray[j].Checked || (this.lsbArray[j].Items.Count == 0)))
                    {
                        continue;
                    }
                    if (this.rad_Sd1.Checked)
                    {
                        strArray3 = new string[] { "40160201", "40160202", "40160203", "40160204", "40160205", "40160206", "40160207", "40160208" };
                        text = this.rad_Sd1.Text;
                    }
                    else
                    {
                        strArray3 = new string[] { "40170201", "40170202", "40170203", "40170204", "40170205", "40170206", "40170207", "40170208" };
                        text = this.rad_Sd2.Text;
                    }
                    cData = "";
                    dataType = "";
                    dataLen = "";
                    data = "";
                    frameData.Clear();
                    parseData = "";
                    list.Clear();
                    for (int k = 0; k < this.L_iSds; k++)
                    {
                        dataType = dataType + "02171717";
                        dataLen = dataLen + "03010101";
                        cData = cData + this.L_Sd[j, k];
                    }
                    dataType = "01" + dataType;
                    dataLen = this.L_iSds.ToString("D2") + dataLen;
                    cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref cData, ref frameData);
                    linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray3[j] + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray3[j], cData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = text + this.cb_sdbArray[j].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
                string str12 = "";
                if ((this.cb_时区表 != null) && this.cb_时区表.Checked)
                {
                    if (this.rad_Sq1.Checked)
                    {
                        str12 = "40140200";
                        text = this.rad_Sq1.Text;
                    }
                    else
                    {
                        str12 = "40150200";
                        text = this.rad_Sq2.Text;
                    }
                    parseData = "";
                    list.Clear();
                    cData = "";
                    dataType = "";
                    dataLen = "";
                    data = "";
                    frameData.Clear();
                    for (int k = 0; k < this.L_iSqs; k++)
                    {
                        dataType = dataType + "02171717";
                        dataLen = dataLen + "03010101";
                        cData = cData + this.L_Sq[k];
                    }
                    dataType = "01" + dataType;
                    dataLen = this.L_iSqs.ToString("D2") + dataLen;
                    cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref cData, ref frameData);
                    linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), str12 + cData, PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str12, cData, PublicVariable.TimeTag, ref splitFlag);
                            break;

                        case Link_Math.明文_RN:
                            flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.明文_SID_MAC:
                            flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID:
                            flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;

                        case Link_Math.密文_SID_MAC:
                            flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                            break;
                    }
                    PublicVariable.Info = text + this.cb_时区表.Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
                string str13 = "";
                if ((this.cb_假日.Visible && (this.cb_假日 != null)) && this.cb_假日.Checked)
                {
                    for (int k = 0; k < this.L_iGgjrs; k++)
                    {
                        cData = "";
                        dataType = "022617";
                        dataLen = "020501";
                        data = "";
                        frameData.Clear();
                        parseData = "";
                        list.Clear();
                        str13 = "401102" + ((k + 1)).ToString("X2");
                        cData = this.L_Ggjr[k];
                        cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref cData, ref frameData);
                        linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), str13 + cData, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, str13, cData, PublicVariable.TimeTag, ref splitFlag);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str5, ref str6, ref splitFlag, ref cOutData);
                                break;
                        }
                        string[] strArray12 = new string[] { "第", (k + 1).ToString(), "假日", flag ? "设置成功" : "设置失败", PublicVariable.DARInfo, PublicVariable.MAC_Info };
                        PublicVariable.Info = string.Concat(strArray12);
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

        private void tbn_单项抄读_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    List<string> list = new List<string>();
                    string data = "400C0200";
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(0xbb8);
                    if ((this.cbx_时区时段数.Checked && this.cbx_时区时段数.Visible) && (this.cbx_时区时段数 != null))
                    {
                        cData = "";
                        parseData = "";
                        list.Clear();
                        linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), data, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.GetRequestNormal(data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                                if (flag)
                                {
                                    flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                                }
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
                        PublicVariable.Info = this.cbx_时区时段数.Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                this.txtArray[j].Text = parseData.Substring(0, 2);
                                parseData = parseData.Substring(2);
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
                    else
                    {
                        string[] strArray = new string[] { "400C0201", "400C0202", "400C0203", "400C0204", "400C0205" };
                        for (int j = 0; j < 5; j++)
                        {
                            if (((this.cbArray[j] == null) || !this.cbArray[j].Checked) || !this.cbArray[j].Visible)
                            {
                                continue;
                            }
                            cData = "";
                            parseData = "";
                            list.Clear();
                            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[j], PublicVariable.TimeTag);
                            switch (PublicVariable.link_Math)
                            {
                                case Link_Math.纯明文操作:
                                    flag = Protocol.GetRequestNormal(strArray[j], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                                    if (flag)
                                    {
                                        flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                                    }
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
                            PublicVariable.Info = this.cbArray[j].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (flag)
                            {
                                this.txtArray[j].Text = parseData.Substring(0, 2);
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
                    string[] strArray2 = new string[] { "40090200", "40080200", "40130200", "40120200" };
                    for (int i = 5; i < (5 + strArray2.Length); i++)
                    {
                        if ((!this.cbArray[i].Checked || !this.cbArray[i].Visible) || (this.cbArray[i] == null))
                        {
                            continue;
                        }
                        cData = "";
                        parseData = "";
                        list.Clear();
                        linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray2[i - 5], PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.GetRequestNormal(strArray2[i - 5], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                                if (flag)
                                {
                                    flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                                }
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
                        PublicVariable.Info = this.cbArray[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            switch (i)
                            {
                                case 5:
                                    this.msT_Sdbqh.Text = parseData.Substring(0, 4) + "年" + parseData.Substring(4, 2) + "月" + parseData.Substring(6, 2) + "日" + parseData.Substring(8, 2) + "时" + parseData.Substring(10, 2) + "分";
                                    break;

                                case 6:
                                    this.msT_Sqbqh.Text = parseData.Substring(0, 4) + "年" + parseData.Substring(4, 2) + "月" + parseData.Substring(6, 2) + "日" + parseData.Substring(8, 2) + "时" + parseData.Substring(10, 2) + "分";
                                    break;

                                case 7:
                                    this.txt_ZxSd.Text = parseData;
                                    break;

                                case 8:
                                    this.txt_Zxr.Text = parseData;
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
                    string str8 = "";
                    string text = "";
                    string item = "";
                    if ((this.cbx_时段表 != null) && this.cbx_时段表.Checked)
                    {
                        for (int j = 0; j < this.lsbArray.Length; j++)
                        {
                            this.lsbArray[j].Items.Clear();
                        }
                        if (this.rad_Sd1.Checked)
                        {
                            str8 = "40160200";
                            text = this.rad_Sd1.Text;
                        }
                        else
                        {
                            str8 = "40170200";
                            text = this.rad_Sd2.Text;
                        }
                        cData = "";
                        parseData = "";
                        list.Clear();
                        linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), str8, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.GetRequestNormal(str8, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                                if (flag)
                                {
                                    flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                                }
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                cData = linkdata;
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;
                        }
                        PublicVariable.Info = text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag && (cData.Length >= 0x16))
                        {
                            string str11 = cData.Substring(0x12, 2);
                            string str12 = cData.Substring(0x16, 2);
                            for (int k = 0; k < Convert.ToByte(str11, 0x10); k++)
                            {
                                for (int m = 0; m < Convert.ToByte(str12, 0x10); m++)
                                {
                                    item = parseData.Substring(0, 2) + ":" + parseData.Substring(2, 2) + "(" + parseData.Substring(4, 2) + ")";
                                    this.L_Sd[k, m] = parseData.Substring(0, 6);
                                    parseData = parseData.Substring(6);
                                    this.lsbArray[k].Items.Add(item);
                                }
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
                    else
                    {
                        string[] strArray3 = new string[8];
                        for (int j = 0; j < this.cb_sdbArray.Length; j++)
                        {
                            if ((this.cb_sdbArray[j] == null) || !this.cb_sdbArray[j].Checked)
                            {
                                continue;
                            }
                            this.lsbArray[j].Items.Clear();
                            if (this.rad_Sd1.Checked)
                            {
                                strArray3 = new string[] { "40160201", "40160202", "40160203", "40160204", "40160205", "40160206", "40160207", "40160208" };
                                text = this.rad_Sd1.Text;
                            }
                            else
                            {
                                strArray3 = new string[] { "40170201", "40170202", "40170203", "40170204", "40170205", "40170206", "40170207", "40170208" };
                                text = this.rad_Sd2.Text;
                            }
                            cData = "";
                            parseData = "";
                            list.Clear();
                            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray3[j], PublicVariable.TimeTag);
                            switch (PublicVariable.link_Math)
                            {
                                case Link_Math.纯明文操作:
                                    flag = Protocol.GetRequestNormal(strArray3[j], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                                    if (flag)
                                    {
                                        flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                                    }
                                    break;

                                case Link_Math.明文_RN:
                                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                    cData = linkdata;
                                    break;

                                case Link_Math.明文_SID_MAC:
                                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                    cData = cOutData.ToString();
                                    break;

                                case Link_Math.密文_SID:
                                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                    cData = cOutData.ToString();
                                    break;

                                case Link_Math.密文_SID_MAC:
                                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                    cData = cOutData.ToString();
                                    break;
                            }
                            PublicVariable.Info = this.cb_sdbArray[j].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                            if (flag && (parseData.Length >= 0x12))
                            {
                                string str13 = cData.Substring(0x12, 2);
                                for (int k = 0; k < Convert.ToByte(str13, 0x10); k++)
                                {
                                    item = parseData.Substring(0, 2) + ":" + parseData.Substring(2, 2) + "(" + parseData.Substring(4, 2) + ")";
                                    this.L_Sd[j, k] = parseData.Substring(0, 6);
                                    parseData = parseData.Substring(6);
                                    this.lsbArray[j].Items.Add(item);
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
                    string str14 = "";
                    if ((this.cb_时区表 != null) && this.cb_时区表.Checked)
                    {
                        this.lsb_Sq.Items.Clear();
                        if (this.rad_Sq1.Checked)
                        {
                            str14 = "40140200";
                        }
                        else
                        {
                            str14 = "40150200";
                        }
                        cData = "";
                        parseData = "";
                        list.Clear();
                        linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), str14, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.GetRequestNormal(str14, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                                if (flag)
                                {
                                    flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                                }
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                cData = linkdata;
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;
                        }
                        PublicVariable.Info = this.cb_时区表.Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag && (cData.Length >= 0x12))
                        {
                            string str15 = cData.Substring(0x12, 2);
                            for (int j = 0; j < Convert.ToByte(str15, 0x10); j++)
                            {
                                item = string.Concat(new object[] { "第", j + 1, "时区: ", parseData.Substring(0, 2), "-", parseData.Substring(2, 2), "(", parseData.Substring(4, 2), ")" });
                                this.L_Sq[j] = parseData.Substring(0, 6);
                                parseData = parseData.Substring(6);
                                this.lsb_Sq.Items.Add(item);
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
                    string str16 = "40110200";
                    if ((this.cb_假日 != null) && this.cb_假日.Checked)
                    {
                        this.lsb_Ggjr.Items.Clear();
                        cData = "";
                        parseData = "";
                        list.Clear();
                        linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), str16, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.GetRequestNormal(str16, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                                if (flag)
                                {
                                    flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                                }
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                cData = linkdata;
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str2, ref str3, ref splitFlag, ref cOutData);
                                cData = cOutData.ToString();
                                break;
                        }
                        PublicVariable.Info = this.cb_假日.Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag && (cData.Length >= 0x12))
                        {
                            string str17 = cData.Substring(0x12, 2);
                            for (int j = 0; j < Convert.ToByte(str17, 0x10); j++)
                            {
                                item = string.Concat(new object[] { "第", j + 1, "假日: ", parseData.Substring(0, 4), "-", parseData.Substring(4, 2), "-", parseData.Substring(6, 2), "-", parseData.Substring(8, 2), "(", parseData.Substring(10, 2), ")" });
                                this.L_Ggjr[j] = parseData.Substring(0, 12);
                                parseData = parseData.Substring(12);
                                this.lsb_Ggjr.Items.Add(item);
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

        private void txt_0_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            string item = "";
            try
            {
                if (this.txt_0.Text.Trim() == "")
                {
                    this.txt_0.Text = "0";
                }
                else if (!PublicVariable.isCheckout(this.txt_0.Text.Trim(), "N"))
                {
                    MessageBox.Show("数据类型错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.txt_0.Text = "1";
                }
                else
                {
                    this.L_iSqs = Convert.ToInt32(this.txt_0.Text.Trim(), 10);
                    if (this.L_iSqs > 14)
                    {
                        MessageBox.Show("年时区数不能超过15", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.txt_0.Text = "1";
                    }
                    else
                    {
                        this.lsb_Sq.Items.Clear();
                        for (int i = 0; i < this.L_iSqs; i++)
                        {
                            num = i + 1;
                            item = "第" + num.ToString() + "时区: " + this.L_Sq[i].Substring(0, 2) + "-" + this.L_Sq[i].Substring(2, 2) + "(" + this.L_Sq[i].Substring(4, 2) + ")";
                            this.lsb_Sq.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "txt_Sqs_TextChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_1.Text.Trim() == "")
                {
                    this.txt_1.Text = "0";
                }
                else if (!PublicVariable.isCheckout(this.txt_1.Text.Trim(), "N"))
                {
                    MessageBox.Show("数据类型错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.txt_1.Text = "1";
                }
                else
                {
                    this.L_iSdbs = Convert.ToInt16(this.txt_1.Text);
                    if (this.L_iSdbs > 8)
                    {
                        MessageBox.Show("0<日时段表数<9", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txt_1.Text = "1";
                    }
                    else
                    {
                        this.cbx_Sdb1.Items.Clear();
                        this.cbx_Sdb2.Items.Clear();
                        for (int i = 0; i < this.L_iSdbs; i++)
                        {
                            this.cbx_Sdb1.Items.Add(i + 1);
                            this.cbx_Sdb2.Items.Add(i + 1);
                        }
                        this.AddSd();
                    }
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "txt_Sdb_TextChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_2.Text.Trim() == "")
                {
                    this.txt_2.Text = "";
                }
                else if (!PublicVariable.isCheckout(this.txt_2.Text.Trim(), "N"))
                {
                    MessageBox.Show("数据类型错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.txt_2.Text = "1";
                }
                else
                {
                    this.L_iSds = Convert.ToInt16(this.txt_2.Text);
                    if (this.L_iSds > 14)
                    {
                        MessageBox.Show("0<日时段数<15", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txt_2.Text = "1";
                    }
                    else
                    {
                        this.AddSd();
                    }
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "txt_Sds_TextChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.isCheckout(this.txt_3.Text.Trim(), "N"))
                {
                    MessageBox.Show("数据类型错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.txt_3.Text = "1";
                }
                else
                {
                    this.L_iFls = Convert.ToInt32(this.txt_3.Text);
                    if (this.L_iFls > 0x20)
                    {
                        this.txt_3.Text = "1";
                        MessageBox.Show("0<费率数<32", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.cbx_Fl.Items.Clear();
                        for (int i = 0; i < this.L_iFls; i++)
                        {
                            this.cbx_Fl.Items.Add(i + 1);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "txt_Fls_TextChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_4_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            string item = "";
            try
            {
                if (this.txt_4.Text.Trim() == "")
                {
                    this.txt_4.Text = "0";
                }
                else if (!PublicVariable.isCheckout(this.txt_4.Text.Trim(), "N"))
                {
                    MessageBox.Show("数据类型错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.txt_4.Text = "1";
                }
                else
                {
                    this.L_iGgjrs = Convert.ToInt32(this.txt_4.Text.Trim(), 10);
                    if ((this.L_iGgjrs > 0xfe) && (this.L_iGgjrs < 0))
                    {
                        MessageBox.Show("0 < 公共假日 < 255", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.txt_4.Text = "1";
                    }
                    else
                    {
                        this.lsb_Ggjr.Items.Clear();
                        for (int i = 0; i < this.L_iGgjrs; i++)
                        {
                            num = i + 1;
                            item = "第" + num.ToString() + "假日: " + this.L_Ggjr[i].Substring(0, 4) + "-" + this.L_Ggjr[i].Substring(4, 2) + "-" + this.L_Ggjr[i].Substring(6, 2) + "-" + this.L_Ggjr[i].Substring(8, 2) + "(" + this.L_Ggjr[i].Substring(10, 2) + ")";
                            this.lsb_Ggjr.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "txt_Sqs_TextChanged" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
