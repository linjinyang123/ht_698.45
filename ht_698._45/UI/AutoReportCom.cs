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
    public partial class AutoReportCom : Form
    {
        private IniFile iniFile = new IniFile(Application.StartupPath + @"\Comm_Info.ini");
        public AutoReportCom()
        {
            this.InitializeComponent();
        }

        private void AutoReportCom_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.SaveInfoToIni();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AutoReportCom_Load(object sender, EventArgs e)
        {
            SerialPortUtil.SetPortNameValues(this.comboBoxSerialName);
            if (this.comboBoxSerialName.Items.Count == 0)
            {
                MessageBox.Show("没有发现串口！");
            }
            this.comboBoxSerialName.SelectedIndex = 0;
            this.comboBoxBaudRate.SelectedIndex = 2;
            this.GetFromIni();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GetFromIni()
        {
            try
            {
                string str = "";
                str = this.iniFile.IniReadValue("ATUOCOM", "com");
                if (str == "")
                {
                    str = "COM1";
                }
                this.comboBoxSerialName.Text = str;
                str = this.iniFile.IniReadValue("ATUOCOM", "comsetting");
                if (str == "")
                {
                    str = "9600,Even,8,1";
                }
                this.comboBoxBaudRate.Text = str;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void SaveInfoToIni()
        {
            try
            {
                this.iniFile.IniWriteValue("ATUOCOM", "com", this.comboBoxSerialName.SelectedItem.ToString());
                this.iniFile.IniWriteValue("ATUOCOM", "comsetting", this.comboBoxBaudRate.SelectedItem.ToString());
                AutoReport.comport = this.comboBoxSerialName.SelectedItem.ToString();
                AutoReport.comsetting = this.comboBoxBaudRate.SelectedItem.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
