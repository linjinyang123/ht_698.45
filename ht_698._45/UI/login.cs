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
    using Common;
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class login : Form
    {
        //private IContainer components;
        //private Label label3;
        //private Button btn_Cancel;
        //private Button btn_Login;
        //private GroupBox groupBox1;
        //private Label label2;
        private TextBox txt_pass;
        //private Label label1;
        private ComboBox cmbname;
        //private PictureBox pictureBox2;
        //private PictureBox pictureBox1;
        private IniFile iniFile = new IniFile(Application.StartupPath + @"\Comm_Info.ini");

        public login()
        {
            InitializeComponent();
        }

        private void textBox_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btn_Login.Focus();
                this.btn_Login_Click_1(sender, e);
            }
        }

        private void login_Load_1(object sender, EventArgs e)
        {
            this.cmbname.SelectedIndex = 0;
        }

        private void btn_Login_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((this.cmbname.SelectedItem.ToString() == "Admin") && (this.txt_pass.Text == "ht321"))
                {
                    base.Hide();
                    new Form_Main().Show();
                    string computerInfo = ComputerInfo.GetComputerInfo();
                    string str = new EncryptionHelper().EncryptString(computerInfo);
                    EncryptionHelper helper = new EncryptionHelper(EncryptionKeyEnum.KeyB);
                    string keyValue = helper.GetMD5String(str).ToUpper();
                    bool flag = false;
                    regist regist = new regist(keyValue, ref flag);
                    if (!flag)
                    {
                        regist.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btn_Login.Focus();
                this.btn_Login_Click_1(sender, e);
            }
        }
    }
}
