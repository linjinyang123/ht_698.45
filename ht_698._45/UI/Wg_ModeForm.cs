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
    public partial class Wg_ModeForm : Form
    {
        private CheckBox[] chkArray;
        private RadioButton[] radArray;
        private int index;
        private string sCmd;
        public Wg_ModeForm()
        {
            this.chkArray = new CheckBox[4];
            this.radArray = new RadioButton[8];
            this.sCmd = "";
            this.InitializeComponent();
            this.initArray();
            this.Wg_ModeForm_Load(this.sCmd);
        }

        public Wg_ModeForm(int iIndex, string dis)
        {
            this.chkArray = new CheckBox[4];
            this.radArray = new RadioButton[8];
            this.sCmd = "";
            this.index = iIndex;
            this.sCmd = dis;
            this.InitializeComponent();
            this.initArray();
            this.Wg_ModeForm_Load(this.sCmd);
        }
        private void initArray()
        {
            string[] strArray = new string[] { "无功组合方式1", "无功组合方式2" };
            this.chkArray[0] = this.chk_0;
            this.chkArray[1] = this.chk_1;
            this.chkArray[2] = this.chk_2;
            this.chkArray[3] = this.chk_3;
            this.radArray[0] = this.rad_0;
            this.radArray[1] = this.rad_1;
            this.radArray[2] = this.rad_2;
            this.radArray[3] = this.rad_3;
            this.radArray[4] = this.rad_4;
            this.radArray[5] = this.rad_5;
            this.radArray[6] = this.rad_6;
            this.radArray[7] = this.rad_7;
            this.label1.Text = strArray[this.index];
            for (int i = 0; i < 4; i++)
            {
                this.chkArray[i].CheckedChanged += new EventHandler(this.Calculate);
            }
            for (int j = 0; j < 8; j++)
            {
                this.radArray[j].CheckedChanged += new EventHandler(this.Calculate);
            }
        }

        private void Wg_ModeForm_Load(string str)
        {
            int num;
            int num2 = Convert.ToInt32(str, 0x10);
            for (num = 0; num < 4; num++)
            {
                if ((Math.Pow(2.0, (double)(7 - (num * 2))) == (((int)Math.Pow(2.0, (double)(7 - (num * 2)))) & num2)) || (Math.Pow(2.0, (double)((7 - (num * 2)) + 1)) == (((int)Math.Pow(2.0, (double)((7 - (num * 2)) + 1))) & num2)))
                {
                    this.chkArray[num].Checked = true;
                }
                else
                {
                    this.chkArray[num].Checked = false;
                }
            }
            for (num = 0; num < 8; num++)
            {
                if (Math.Pow(2.0, (double)(7 - num)) == (((int)Math.Pow(2.0, (double)(7 - num))) & num2))
                {
                    this.radArray[num].Checked = true;
                }
            }
        }
        private void Calculate(object sender, EventArgs e)
        {
            string str = "";
            int num = 0;
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.chkArray[i].Checked)
                    {
                        if (this.radArray[i * 2].Checked)
                        {
                            num += (int)Math.Pow(2.0, (double)((6 - (i * 2)) + 1));
                            str = str + this.radArray[i * 2].Text + this.chkArray[i].Text;
                        }
                        else if (this.radArray[(i * 2) + 1].Checked)
                        {
                            num += (int)Math.Pow(2.0, (double)(6 - (i * 2)));
                            str = str + this.radArray[(i * 2) + 1].Text + this.chkArray[i].Text;
                        }
                    }
                }
                if (str.Substring(0, 1) == "+")
                {
                    str = str.Substring(1);
                }
                this.txt_Wg1.Text = str;
                this.sCmd = num.ToString("X2");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bn_Cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void bn_Ok_Click(object sender, EventArgs e)
        {
            base.Tag = this.sCmd;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }
    }
}
