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
    public partial class Weekset : Form
    {
        private CheckBox[] chkArray;
        private string sCmd;
        public Weekset()
        {
            this.chkArray = new CheckBox[7];
            this.sCmd = "";
            this.sCmd = "";
            this.InitializeComponent();
            this.initArray();
            this.LoadForm(this.sCmd);
        }

        public Weekset(string sOldCmd)
        {
            this.chkArray = new CheckBox[7];
            this.sCmd = "";
            this.InitializeComponent();
            this.initArray();
            this.LoadForm(sOldCmd);
        }
        private void initArray()
        {
            this.chkArray[0] = this.checkBox1;
            this.chkArray[1] = this.checkBox2;
            this.chkArray[2] = this.checkBox3;
            this.chkArray[3] = this.checkBox4;
            this.chkArray[4] = this.checkBox5;
            this.chkArray[5] = this.checkBox6;
            this.chkArray[6] = this.checkBox7;
        }
        private void LoadForm(string mode)
        {
            int num = 0;
            if ((mode != "") && (mode.Length == 2))
            {
                num = Convert.ToInt32(mode, 0x10);
                for (int i = 7; i > 0; i--)
                {
                    if ((num & ((int)Math.Pow(2.0, (double)i))) == 0)
                    {
                        this.chkArray[7 - i].Checked = true;
                    }
                    else
                    {
                        this.chkArray[7 - i].Checked = false;
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < 7; i++)
            {
                if (this.chkArray[i].Checked)
                {
                    str = str + "0";
                }
                else
                {
                    str = str + "1";
                }
            }
            str = str + "0";
            base.Tag = string.Format("{0:X2}",Convert.ToInt32(str, 2)).PadLeft(2, '0');
            base.DialogResult = DialogResult.OK;
        }
    }
}
