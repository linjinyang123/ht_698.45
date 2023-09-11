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
    public partial class Sysconfig : Form
    {
        private static string strAdd = "";
        public Sysconfig(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void cb_fe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cb_fe.Checked)
                {
                    PublicVariable.FE_Number = Convert.ToByte(this.txt_fe.Text, 0x10);
                    PublicVariable.FE_Flag = true;
                }
                else
                {
                    PublicVariable.FE_Number = 0;
                    PublicVariable.FE_Flag = false;
                }
            }
            catch (Exception exception)
            {
                PublicVariable.FE_Flag = false;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cb_raoma33_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cb_raoma33.Checked)
                {
                    PublicVariable.RaomaFlag = true;
                }
                else
                {
                    PublicVariable.RaomaFlag = false;
                }
            }
            catch (Exception exception)
            {
                PublicVariable.RaomaFlag = false;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chb_系统时间_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chb_系统时间.Checked)
            {
                this.timer1.Enabled = true;
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }

        private void cmb_AddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((PublicVariable.Address != "C0AA") && (this.cmb_AddType.SelectedIndex == 3))
                {
                    strAdd = PublicVariable.Address;
                }
                if (strAdd != "")
                {
                    PublicVariable.Address = strAdd;
                }
                int length = PublicVariable.Address.PadLeft(12, '0').Length;
                switch (this.cmb_AddType.SelectedIndex)
                {
                    case 0:
                        PublicVariable.Address = "05" + PublicVariable.Address.PadLeft(12, '0').Substring(length - 12, 12);
                        return;

                    case 1:
                        PublicVariable.Address = "45" + PublicVariable.Address.PadLeft(12, '0').Substring(length - 12, 12);
                        return;

                    case 2:
                        PublicVariable.Address = "85" + PublicVariable.Address.PadLeft(12, '0').Substring(length - 12, 12);
                        return;

                    case 3:
                        PublicVariable.Address = "C0AA";
                        return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rd_无时标_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rd_无时标.Checked)
            {
                PublicVariable.TimeTag = false;
            }
            else if (this.rd_有时标.Checked)
            {
                PublicVariable.TimeTag = true;
            }
        }

        private void Sysconfig_Load(object sender, EventArgs e)
        {
            this.cmb_AddType.Items.Clear();
            foreach (add_Type type in Enum.GetValues(typeof(add_Type)))
            {
                this.cmb_AddType.Items.Add(type.ToString());
            }
            this.cmb_AddType.SelectedIndex = 0;
            this.cmb_间隔单位.SelectedIndex = 0;
            this.tbx_ClientAdd.Text = PublicVariable.Client_Add;
            this.rd_有时标.Checked = PublicVariable.TimeTag;
        }

        private void tb_时间_TextChanged(object sender, EventArgs e)
        {
            if (this.chb_系统时间.Checked)
            {
                this.tb_时间.Text = this.tb_时间.Text.PadRight(14, '0');
                PublicVariable.TimeText = Convert.ToInt32(this.tb_时间.Text.Substring(0, 4), 10).ToString("X4") + Convert.ToInt32(this.tb_时间.Text.Substring(4, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(6, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(8, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(10, 2), 10).ToString("X2") + Convert.ToInt32(this.tb_时间.Text.Substring(12, 2), 10).ToString("X2") + this.cmb_间隔单位.SelectedIndex.ToString("X2") + Convert.ToInt32(this.tbx_间隔.Text.PadLeft(4, '0'), 10).ToString("X4");
            }
        }

        private void tbx_ClientAdd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PublicVariable.Client_Add = this.tbx_ClientAdd.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tb_时间.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void txt_fe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PublicVariable.FE_Number = Convert.ToByte(this.txt_fe.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_帧字节_TextChanged(object sender, EventArgs e)
        {
            PublicVariable.sumOfbit = Convert.ToInt32(this.txt_帧字节.Text, 10);
        }
    }
}
