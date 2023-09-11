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
    public partial class SetIP : Form
    {
        private IniFile iniFile = new IniFile(Application.StartupPath + @"\config.ini");
        public SetIP(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            base.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.iniFile.IniReadValue("MAIN", "ip");
                string str2 = this.iniFile.IniReadValue("MAIN", "port");
                if (PublicVariable.IsLink && ((str != this.textBoxIP.Text) || (str2 != this.textBoxPort.Text)))
                {
                    PublicVariable.IsLink = false;
                    EncryptServerConnect.CloseEncryptServer698();
                }
                string text = this.textBoxIP.Text;
                string iValue = this.textBoxPort.Text;
                string str5 = this.textBoxTimeOut.Text;
                this.iniFile.IniWriteValue("MAIN", "ip", text);
                this.iniFile.IniWriteValue("MAIN", "port", iValue);
                this.iniFile.IniWriteValue("MAIN", "timeOut", str5);
                this.iniFile.IniWriteValue("MAIN", "LinkRoadFlag", this.rd_dir_net.Checked.ToString());
                PublicVariable.IP = this.textBoxIP.Text;
                PublicVariable.port = this.textBoxPort.Text;
                PublicVariable.timeOut = this.textBoxTimeOut.Text;
                PublicVariable.LinkRoadFlag = this.rd_dir_net.Checked;
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            } 
        }

        private void SetIP_Load(object sender, EventArgs e)
        {
            try
            {
                string str = this.iniFile.IniReadValue("MAIN", "ip");
                this.textBoxPort.Text = this.iniFile.IniReadValue("MAIN", "port");
                this.textBoxTimeOut.Text = this.iniFile.IniReadValue("MAIN", "timeout");
                this.textBoxIP.Text = str;
                this.rd_dir_net.Checked = Convert.ToBoolean(this.iniFile.IniReadValue("MAIN", "LinkRoadFlag"));
                this.rd_net.Checked = !this.rd_dir_net.Checked;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
