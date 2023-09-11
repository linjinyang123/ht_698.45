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
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class regist : Form
    {
        private string encryptComputer = string.Empty;
        private bool isRegist;
        public regist(string keyValue, ref bool flag)
        {
            this.InitializeComponent();
            flag = this.CheckRegistData(keyValue);
        }

        private void btn_退出_Click(object sender, EventArgs e)
        {
            if (this.isRegist)
            {
                base.Close();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btn_注册_Click(object sender, EventArgs e)
        {
            if (this.CheckRegist())
            {
                MessageBox.Show("注册成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                base.Close();
            }
            else
            {
                MessageBox.Show("请重新获取注册码~","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private bool CheckRegist()
        {
            EncryptionHelper helper = new EncryptionHelper();
            string key = helper.GetMD5String(this.encryptComputer).ToUpper();
            return this.CheckRegistData(key);
        }

        private bool CheckRegistData(string key)
        {
            if (!RegistFileHelper.ExistRegistInfofile())
            {
                this.isRegist = false;
                return false;
            }
            string str = RegistFileHelper.ReadRegistFile();
            EncryptionHelper helper = new EncryptionHelper(EncryptionKeyEnum.KeyB);
            string str2 = helper.DecryptString(str.PadLeft(80, '0')).ToUpper();
            if (key == str2)
            {
                this.isRegist = true;
                return true;
            }
            this.isRegist = false;
            return false;
        }

        private void regist_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isRegist)
            {
                Application.Exit();
            }
        }

        private void regist_Load(object sender, EventArgs e)
        {
            string computerInfo = ComputerInfo.GetComputerInfo();
            this.encryptComputer = new EncryptionHelper().EncryptString(computerInfo);
            EncryptionHelper helper = new EncryptionHelper(EncryptionKeyEnum.KeyB);
            string str2 = helper.GetMD5String(this.encryptComputer).ToUpper();
            this.txt_机器码.Text = str2;
        }

        private void txt_注册码_TextChanged(object sender, EventArgs e)
        {
            RegistFileHelper.WriteRegistFile(this.txt_注册码.Text);
        }

    }
}
