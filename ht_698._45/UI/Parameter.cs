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
    public partial class Parameter : Form
    {
        private CheckBox[] chkArry = new CheckBox[14];
        private TextBox[] tbArray = new TextBox[12];
        private CheckBox[] jiesuanArray = new CheckBox[3];
        private MaskedTextBox[] tb_jiesuanArray = new MaskedTextBox[3];
        private CheckBox[] LCDArray = new CheckBox[7];
        private TextBox[] tb_LCDArray = new TextBox[7];
        private CheckBox[] ch_Arr_Buff = new CheckBox[0x16];
        private CheckBox[] cbArry2 = new CheckBox[8];
        private TextBox[] tbArry2 = new TextBox[0x16];
        private CheckBox[] cbArry3 = new CheckBox[9];
        private TextBox[] tbArry3 = new TextBox[20];
        private CheckBox[] cbArry4 = new CheckBox[11];
        private TextBox[] tbArry4 = new TextBox[0x17];
        public Parameter(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            this.ArrayCheck();
        }
        private void ArrayCheck()
        {
            this.chkArry[0] = this.chk_1;
            this.chkArry[1] = this.chk_2;
            this.chkArry[2] = this.chk_3;
            this.chkArry[3] = this.chk_4;
            this.chkArry[4] = this.chk_5;
            this.chkArry[5] = this.chk_6;
            this.chkArry[6] = this.chk_7;
            this.chkArry[7] = this.chk_8;
            this.chkArry[8] = this.chk_9;
            this.chkArry[9] = this.chk_10;
            this.chkArry[10] = this.chk_11;
            this.chkArry[11] = this.chk_12;
            this.chkArry[12] = this.chk_24;
            this.chkArry[13] = this.chk_16;
            this.jiesuanArray[0] = this.chk_13;
            this.jiesuanArray[1] = this.chk_14;
            this.jiesuanArray[2] = this.chk_15;
            this.tb_jiesuanArray[0] = this.txt_13;
            this.tb_jiesuanArray[1] = this.txt_14;
            this.tb_jiesuanArray[2] = this.txt_15;
            this.LCDArray[0] = this.chk_17;
            this.LCDArray[1] = this.chk_18;
            this.LCDArray[2] = this.chk_19;
            this.LCDArray[3] = this.chk_20;
            this.LCDArray[4] = this.chk_21;
            this.LCDArray[5] = this.chk_22;
            this.LCDArray[6] = this.chk_23;
            this.tb_LCDArray[0] = this.txt_16;
            this.tb_LCDArray[1] = this.txt_17;
            this.tb_LCDArray[2] = this.txt_18;
            this.tb_LCDArray[3] = this.txt_19;
            this.tb_LCDArray[4] = this.txt_20;
            this.tb_LCDArray[5] = this.txt_21;
            this.tb_LCDArray[6] = this.txt_22;
            this.tbArray[0] = this.txt_0;
            this.tbArray[1] = this.txt_2;
            this.tbArray[2] = this.txt_3;
            this.tbArray[3] = this.txt_4;
            this.tbArray[4] = this.txt_5;
            this.tbArray[5] = this.txt_6;
            this.tbArray[6] = this.txt_7;
            this.tbArray[7] = this.txt_8;
            this.tbArray[8] = this.txt_9;
            this.tbArray[9] = this.txt_10;
            this.tbArray[10] = this.txt_11;
            this.tbArray[11] = this.txt_12;
            this.ch_Arr_Buff[0] = this.chk_1;
            this.ch_Arr_Buff[1] = this.chk_2;
            this.ch_Arr_Buff[2] = this.chk_3;
            this.ch_Arr_Buff[3] = this.chk_4;
            this.ch_Arr_Buff[4] = this.chk_5;
            this.ch_Arr_Buff[5] = this.chk_6;
            this.ch_Arr_Buff[6] = this.chk_7;
            this.ch_Arr_Buff[7] = this.chk_8;
            this.ch_Arr_Buff[8] = this.chk_9;
            this.ch_Arr_Buff[9] = this.chk_10;
            this.ch_Arr_Buff[10] = this.chk_11;
            this.ch_Arr_Buff[11] = this.chk_12;
            this.ch_Arr_Buff[12] = this.chk_13;
            this.ch_Arr_Buff[13] = this.chk_14;
            this.ch_Arr_Buff[14] = this.chk_15;
            this.ch_Arr_Buff[15] = this.chk_17;
            this.ch_Arr_Buff[0x10] = this.chk_18;
            this.ch_Arr_Buff[0x11] = this.chk_19;
            this.ch_Arr_Buff[0x12] = this.chk_20;
            this.ch_Arr_Buff[0x13] = this.chk_21;
            this.ch_Arr_Buff[20] = this.chk_22;
            this.ch_Arr_Buff[0x15] = this.chk_23;
            this.cbArry2[0] = this.cb_22;
            this.cbArry2[1] = this.cb_23;
            this.cbArry2[2] = this.cb_24;
            this.cbArry2[3] = this.cb_25;
            this.cbArry2[4] = this.cb_26;
            this.cbArry2[5] = this.cb_27;
            this.cbArry2[6] = this.cb_28;
            this.cbArry2[7] = this.cb_29;
            this.tbArry2[0] = this.tb_0;
            this.tbArry2[1] = this.tb_1;
            this.tbArry2[2] = this.tb_2;
            this.tbArry2[3] = this.tb_3;
            this.tbArry2[4] = this.tb_4;
            this.tbArry2[5] = this.tb_5;
            this.tbArry2[6] = this.tb_6;
            this.tbArry2[7] = this.tb_7;
            this.tbArry2[8] = this.tb_8;
            this.tbArry2[9] = this.tb_9;
            this.tbArry2[10] = this.tb_10;
            this.tbArry2[11] = this.tb_11;
            this.tbArry2[12] = this.tb_12;
            this.tbArry2[13] = this.tb_13;
            this.tbArry2[14] = this.tb_14;
            this.tbArry2[15] = this.tb_15;
            this.tbArry2[0x10] = this.tb_16;
            this.tbArry2[0x11] = this.tb_17;
            this.tbArry2[0x12] = this.tb_18;
            this.tbArry2[0x13] = this.tb_19;
            this.tbArry2[20] = this.tb_20;
            this.tbArry2[0x15] = this.tb_21;
            this.cbArry3[0] = this.cb_30;
            this.cbArry3[1] = this.cb_31;
            this.cbArry3[2] = this.cb_32;
            this.cbArry3[3] = this.cb_33;
            this.cbArry3[4] = this.cb_34;
            this.cbArry3[5] = this.cb_35;
            this.cbArry3[6] = this.cb_36;
            this.cbArry3[7] = this.cb_37;
            this.cbArry3[8] = this.cb_38;
            this.tbArry3[0] = this.tx_0;
            this.tbArry3[1] = this.tx_1;
            this.tbArry3[2] = this.tx_2;
            this.tbArry3[3] = this.tx_3;
            this.tbArry3[4] = this.tx_4;
            this.tbArry3[5] = this.tx_5;
            this.tbArry3[6] = this.tx_6;
            this.tbArry3[7] = this.tx_7;
            this.tbArry3[8] = this.tx_8;
            this.tbArry3[9] = this.tx_9;
            this.tbArry3[10] = this.tx_10;
            this.tbArry3[11] = this.tx_11;
            this.tbArry3[12] = this.tx_12;
            this.tbArry3[13] = this.tx_13;
            this.tbArry3[14] = this.tx_14;
            this.tbArry3[15] = this.tx_15;
            this.tbArry3[0x10] = this.tx_16;
            this.tbArry3[0x11] = this.tx_17;
            this.tbArry3[0x12] = this.tx_18;
            this.tbArry3[0x13] = this.tx_19;
            this.cbArry4[0] = this.cbx_1;
            this.cbArry4[1] = this.cbx_2;
            this.cbArry4[2] = this.cbx_3;
            this.cbArry4[3] = this.cbx_4;
            this.cbArry4[4] = this.cbx_5;
            this.cbArry4[5] = this.cbx_6;
            this.cbArry4[6] = this.cbx_7;
            this.cbArry4[7] = this.cbx_8;
            this.cbArry4[8] = this.cbx_9;
            this.cbArry4[9] = this.cbx_10;
            this.cbArry4[10] = this.cbx_11;
            this.tbArry4[0] = this.tbx_0;
            this.tbArry4[1] = this.tbx_1;
            this.tbArry4[2] = this.tbx_2;
            this.tbArry4[3] = this.tbx_3;
            this.tbArry4[4] = this.tbx_4;
            this.tbArry4[5] = this.tbx_5;
            this.tbArry4[6] = this.tbx_6;
            this.tbArry4[7] = this.tbx_7;
            this.tbArry4[8] = this.tbx_8;
            this.tbArry4[9] = this.tbx_9;
            this.tbArry4[10] = this.tbx_10;
            this.tbArry4[11] = this.tbx_11;
            this.tbArry4[12] = this.tbx_12;
            this.tbArry4[13] = this.tbx_13;
            this.tbArry4[14] = this.tbx_14;
            this.tbArry4[15] = this.tbx_15;
            this.tbArry4[0x10] = this.tbx_16;
            this.tbArry4[0x11] = this.tbx_17;
            this.tbArry4[0x12] = this.tbx_18;
            this.tbArry4[0x13] = this.tbx_19;
            this.tbArry4[20] = this.tbx_20;
            this.tbArry4[0x15] = this.tbx_21;
            this.tbArry4[0x16] = this.tbx_22;
        }

        private void cb_22_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_22 != null) && this.cb_22.Visible) && this.cb_22.Checked)
            {
                this.cb_0.Checked = true;
                this.cb_0.CheckState = CheckState.Indeterminate;
                this.cb_1.Checked = true;
                this.cb_1.CheckState = CheckState.Indeterminate;
                this.cb_2.Checked = true;
                this.cb_2.CheckState = CheckState.Indeterminate;
                this.cb_3.Checked = true;
                this.cb_3.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_0.Checked = false;
                this.cb_1.Checked = false;
                this.cb_2.Checked = false;
                this.cb_3.Checked = false;
            }
        }

        private void cb_23_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_23 != null) && this.cb_23.Visible) && this.cb_23.Checked)
            {
                this.cb_4.Checked = true;
                this.cb_4.CheckState = CheckState.Indeterminate;
                this.cb_5.Checked = true;
                this.cb_5.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_4.Checked = false;
                this.cb_5.Checked = false;
            }
        }

        private void cb_24_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_24 != null) && this.cb_24.Visible) && this.cb_24.Checked)
            {
                this.cb_6.Checked = true;
                this.cb_6.CheckState = CheckState.Indeterminate;
                this.cb_7.Checked = true;
                this.cb_7.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_6.Checked = false;
                this.cb_7.Checked = false;
            }
        }

        private void cb_25_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_25 != null) && this.cb_25.Visible) && this.cb_25.Checked)
            {
                this.cb_8.Checked = true;
                this.cb_8.CheckState = CheckState.Indeterminate;
                this.cb_9.Checked = true;
                this.cb_9.CheckState = CheckState.Indeterminate;
                this.cb_10.Checked = true;
                this.cb_10.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_8.Checked = false;
                this.cb_9.Checked = false;
                this.cb_10.Checked = false;
            }
        }

        private void cb_26_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_26 != null) && this.cb_26.Visible) && this.cb_26.Checked)
            {
                this.cb_11.Checked = true;
                this.cb_11.CheckState = CheckState.Indeterminate;
                this.cb_12.Checked = true;
                this.cb_12.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_11.Checked = false;
                this.cb_12.Checked = false;
            }
        }

        private void cb_27_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_27 != null) && this.cb_27.Visible) && this.cb_27.Checked)
            {
                this.cb_13.Checked = true;
                this.cb_13.CheckState = CheckState.Indeterminate;
                this.cb_14.Checked = true;
                this.cb_14.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_13.Checked = false;
                this.cb_14.Checked = false;
            }
        }

        private void cb_28_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_28 != null) && this.cb_28.Visible) && this.cb_28.Checked)
            {
                this.cb_15.Checked = true;
                this.cb_15.CheckState = CheckState.Indeterminate;
                this.cb_16.Checked = true;
                this.cb_16.CheckState = CheckState.Indeterminate;
                this.cb_17.Checked = true;
                this.cb_17.CheckState = CheckState.Indeterminate;
                this.cb_18.Checked = true;
                this.cb_18.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_15.Checked = false;
                this.cb_16.Checked = false;
                this.cb_17.Checked = false;
                this.cb_18.Checked = false;
            }
        }

        private void cb_29_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_29 != null) && this.cb_29.Visible) && this.cb_29.Checked)
            {
                this.cb_19.Checked = true;
                this.cb_19.CheckState = CheckState.Indeterminate;
                this.cb_20.Checked = true;
                this.cb_20.CheckState = CheckState.Indeterminate;
                this.cb_21.Checked = true;
                this.cb_21.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cb_19.Checked = false;
                this.cb_20.Checked = false;
                this.cb_21.Checked = false;
            }
        }

        private void cb_30_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_30 != null) && this.cb_30.Visible) && this.cb_30.Checked)
            {
                this.chb_0.Checked = true;
                this.chb_0.CheckState = CheckState.Indeterminate;
                this.chb_1.Checked = true;
                this.chb_1.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_0.Checked = false;
                this.chb_1.Checked = false;
            }
        }

        private void cb_31_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_31 != null) && this.cb_31.Visible) && this.cb_31.Checked)
            {
                this.chb_2.Checked = true;
                this.chb_2.CheckState = CheckState.Indeterminate;
                this.chb_3.Checked = true;
                this.chb_3.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_2.Checked = false;
                this.chb_3.Checked = false;
            }
        }

        private void cb_32_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_32 != null) && this.cb_32.Visible) && this.cb_32.Checked)
            {
                this.chb_4.Checked = true;
                this.chb_4.CheckState = CheckState.Indeterminate;
                this.chb_5.Checked = true;
                this.chb_5.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_4.Checked = false;
                this.chb_5.Checked = false;
            }
        }

        private void cb_33_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_33 != null) && this.cb_33.Visible) && this.cb_33.Checked)
            {
                this.chb_6.Checked = true;
                this.chb_6.CheckState = CheckState.Indeterminate;
                this.chb_7.Checked = true;
                this.chb_7.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_6.Checked = false;
                this.chb_7.Checked = false;
            }
        }

        private void cb_34_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_34 != null) && this.cb_34.Visible) && this.cb_34.Checked)
            {
                this.chb_8.Checked = true;
                this.chb_8.CheckState = CheckState.Indeterminate;
                this.chb_9.Checked = true;
                this.chb_9.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_8.Checked = false;
                this.chb_9.Checked = false;
            }
        }

        private void cb_35_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_35 != null) && this.cb_35.Visible) && this.cb_35.Checked)
            {
                this.chb_10.Checked = true;
                this.chb_10.CheckState = CheckState.Indeterminate;
                this.chb_11.Checked = true;
                this.chb_11.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_10.Checked = false;
                this.chb_11.Checked = false;
            }
        }

        private void cb_36_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_36 != null) && this.cb_36.Visible) && this.cb_36.Checked)
            {
                this.chb_12.Checked = true;
                this.chb_12.CheckState = CheckState.Indeterminate;
                this.chb_13.Checked = true;
                this.chb_13.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_12.Checked = false;
                this.chb_13.Checked = false;
            }
        }

        private void cb_37_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_37 != null) && this.cb_37.Visible) && this.cb_37.Checked)
            {
                this.chb_14.Checked = true;
                this.chb_14.CheckState = CheckState.Indeterminate;
                this.chb_15.Checked = true;
                this.chb_15.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_14.Checked = false;
                this.chb_15.Checked = false;
            }
        }

        private void cb_38_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cb_38 != null) && this.cb_38.Visible) && this.cb_38.Checked)
            {
                this.chb_16.Checked = true;
                this.chb_16.CheckState = CheckState.Indeterminate;
                this.chb_17.Checked = true;
                this.chb_17.CheckState = CheckState.Indeterminate;
                this.chb_18.Checked = true;
                this.chb_18.CheckState = CheckState.Indeterminate;
                this.chb_19.Checked = true;
                this.chb_19.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.chb_16.Checked = false;
                this.chb_17.Checked = false;
                this.chb_18.Checked = false;
                this.chb_19.Checked = false;
            }
        }

        private void cbx_8_CheckedChanged(object sender, EventArgs e)
        {
            if (((this.cbx_8 != null) && this.cbx_8.Visible) && this.cbx_8.Checked)
            {
                this.cbx_81.Checked = true;
                this.cbx_81.CheckState = CheckState.Indeterminate;
                this.cbx_91.Checked = true;
                this.cbx_91.CheckState = CheckState.Indeterminate;
            }
            else
            {
                this.cbx_81.Checked = false;
                this.cbx_91.Checked = false;
            }
        }

        private void chb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chb_All.Checked)
            {
                for (int i = 0; i < this.chkArry.Length; i++)
                {
                    if ((this.chkArry[i] != null) && this.chkArry[i].Visible)
                    {
                        this.chkArry[i].Checked = true;
                    }
                }
                this.chk_24.Checked = true;
                this.chk_16.Checked = true;
            }
            else
            {
                for (int i = 0; i < this.chkArry.Length; i++)
                {
                    if ((this.chkArry[i] != null) && this.chkArry[i].Visible)
                    {
                        this.chkArry[i].Checked = false;
                    }
                }
                this.chk_24.Checked = false;
                this.chk_16.Checked = false;
            }
        }

        private void checkBoxShiZhongTongbu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxShiZhongTongbu.Checked)
            {
                this.timer1.Enabled = true;
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }

        private void chk_16_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_16.Checked)
            {
                for (int i = 0; i < this.LCDArray.Length; i++)
                {
                    if ((this.LCDArray[i] != null) && this.LCDArray[i].Visible)
                    {
                        this.LCDArray[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.LCDArray.Length; i++)
                {
                    if ((this.LCDArray[i] != null) && this.LCDArray[i].Visible)
                    {
                        this.LCDArray[i].Checked = false;
                    }
                }
            }
        }

        private void chk_23_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_24.Checked)
            {
                for (int i = 0; i < this.jiesuanArray.Length; i++)
                {
                    if ((this.jiesuanArray[i] != null) && this.jiesuanArray[i].Visible)
                    {
                        this.jiesuanArray[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.jiesuanArray.Length; i++)
                {
                    if ((this.jiesuanArray[i] != null) && this.jiesuanArray[i].Visible)
                    {
                        this.jiesuanArray[i].Checked = false;
                    }
                }
            }
        }

        private void chk_All_Page3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_All_Page3.Checked)
            {
                for (int i = 0; i < this.cbArry3.Length; i++)
                {
                    if ((this.cbArry3[i] != null) && this.cbArry3[i].Visible)
                    {
                        this.cbArry3[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.cbArry3.Length; i++)
                {
                    if ((this.cbArry3[i] != null) && this.cbArry3[i].Visible)
                    {
                        this.cbArry3[i].Checked = false;
                    }
                }
            }
        }

        private void chk_All_Page4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_All_Page4.Checked)
            {
                for (int i = 0; i < this.cbArry4.Length; i++)
                {
                    if ((this.cbArry4[i] != null) && this.cbArry4[i].Visible)
                    {
                        this.cbArry4[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.cbArry4.Length; i++)
                {
                    if ((this.cbArry4[i] != null) && this.cbArry4[i].Visible)
                    {
                        this.cbArry4[i].Checked = false;
                    }
                }
            }
        }

        private void ckb_All_Page2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckb_All_Page2.Checked)
            {
                for (int i = 0; i < this.cbArry2.Length; i++)
                {
                    if ((this.cbArry2[i] != null) && this.cbArry2[i].Visible)
                    {
                        this.cbArry2[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.cbArry2.Length; i++)
                {
                    if ((this.cbArry2[i] != null) && this.cbArry2[i].Visible)
                    {
                        this.cbArry2[i].Checked = false;
                    }
                }
            }
        }
        private void InintColor()
        {
            for (int i = 1; i <= 11; i++)
            {
                this.tbArray[i].BackColor = Color.White;
            }
            for (int j = 0; j < 3; j++)
            {
                this.tb_jiesuanArray[j].BackColor = Color.White;
            }
            for (int k = 0; k < 7; k++)
            {
                this.tb_LCDArray[k].BackColor = Color.White;
            }
            for (int m = 0; m < 0x16; m++)
            {
                this.tbArry2[m].BackColor = Color.White;
            }
            for (int n = 0; n < 20; n++)
            {
                this.tbArry3[n].BackColor = Color.White;
            }
            for (int num6 = 0; num6 < 0x12; num6++)
            {
                this.tbArry4[num6].BackColor = Color.White;
            }
        }

        private void tb_多属性设置_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    this.InintColor();
                    if (this.tabControl1.SelectedTab == this.tabPage1)
                    {
                        this.tb_多属性设置_Page1();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage2)
                    {
                        this.tb_多属性设置_Page2();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage3)
                    {
                        this.tb_多属性设置_Page3();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage4)
                    {
                        this.tb_多属性设置_Page4();
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
        private void tb_多属性设置_Page(CheckBox[] cbArry, TextBox[] tbArry, string[] OAD_Collection, byte[][] strDot, byte[][] strLen, string[] strType, string[] strlen, int[] Num)
        {
            byte sEQOfOAD = 0;
            string data = "";
            string str2 = "";
            bool splitFlag = false;
            List<string> frameData = new List<string>();
            bool flag2 = false;
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list2 = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < OAD_Collection.Length; i++)
            {
                if (((cbArry[i] != null) && cbArry[i].Visible) && cbArry[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    str2 = "";
                    frameData.Clear();
                    for (int j = Num[i]; j < Num[i + 1]; j++)
                    {
                        double num4 = Convert.ToDouble(tbArry[j].Text.Trim().PadLeft(strLen[i][j - Num[i]] * 2, '0')) * Math.Pow(10.0, (double)strDot[i][j - Num[i]]);
                        str2 = str2 + num4.ToString().PadLeft(strLen[i][j - Num[i]] * 2, '0');
                    }
                    data = data + OAD_Collection[i] + Protocol.From_Type_GetData(ref strType[i], ref strlen[i], ref str2, ref frameData);
                }
            }
            linkdata = Protocol.MakeLink_Data("06", "02", PublicVariable.PIID_W.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag2 = Protocol.SetRequestNormalList(sEQOfOAD, "43", PublicVariable.Address, PublicVariable.Client_Add, data, ref list2, PublicVariable.TimeTag, ref splitFlag);
                    break;

                case Link_Math.明文_RN:
                    flag2 = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag2 = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag2 = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag2 = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多属性设置" + (flag2 ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
        }

        private void tb_多属性设置_Page1()
        {
            bool splitFlag = false;
            string[] strArray = new string[] { 
                "40000200", "40020200", "41030200", "40010200", "40030200", "41090200", "410A0200", "41000200", "41010200", "F3010300", "F3000300", "41020200", "41160201", "41160202", "41160203", "40070201",
                "40070202", "40070203", "40070204", "40070205", "40070206", "40070207"
            };
            string[] strArray2 = new string[] { 
                "28", "09", "10", "09", "09", "06", "06", "17", "17", "18", "18", "17", "021717", "021717", "021717", "17",
                "18", "18", "18", "17", "17", "17"
            };
            string[] strArray3 = new string[] { 
                "07", "06", "16", "06", "06", "04", "04", "01", "01", "02", "02", "01", "020101", "020101", "020101", "01",
                "02", "02", "02", "01", "01", "01"
            };
            byte sEQOfOAD = 0;
            string data = "";
            string text = "";
            List<string> frameData = new List<string>();
            bool flag2 = false;
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list2 = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < this.ch_Arr_Buff.Length; i++)
            {
                if (((this.ch_Arr_Buff[i] != null) && this.ch_Arr_Buff[i].Visible) && this.ch_Arr_Buff[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    switch (i)
                    {
                        case 0:
                            text = this.txt_DateAndTime.Value.ToString("yyyyMMddHHmmss");
                            data = data + strArray[i] + Protocol.From_Type_GetData(Convert.ToByte(strArray2[i]), Convert.ToByte(strArray3[i]), ref text);
                            break;

                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            text = this.tbArray[i].Text;
                            data = data + strArray[i] + Protocol.From_Type_GetData(Convert.ToByte(strArray2[i]), Convert.ToByte(strArray3[i]), ref text);
                            break;

                        case 12:
                        case 13:
                        case 14:
                            frameData.Clear();
                            text = this.tb_jiesuanArray[i - 12].Text.Substring(0, this.tb_jiesuanArray[i - 12].Text.IndexOf("日")).PadLeft(2, '0') + this.tb_jiesuanArray[i - 12].Text.Substring(this.tb_jiesuanArray[i - 12].Text.IndexOf("日") + 1, 2).PadLeft(2, '0');
                            data = data + strArray[i] + Protocol.From_Type_GetData(ref strArray2[i], ref strArray3[i], ref text, ref frameData);
                            break;

                        case 15:
                        case 0x10:
                        case 0x11:
                        case 0x12:
                        case 0x13:
                        case 20:
                        case 0x15:
                            text = this.tb_LCDArray[i - 15].Text.PadLeft(Convert.ToByte(strArray3[i]) * 2, '0');
                            data = data + strArray[i] + Protocol.From_Type_GetData(Convert.ToByte(strArray2[i]), Convert.ToByte(strArray3[i]), ref text);
                            break;
                    }
                }
            }
            linkdata = Protocol.MakeLink_Data("06", "02", PublicVariable.PIID_W.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag2 = Protocol.SetRequestNormalList(sEQOfOAD, "43", PublicVariable.Address, PublicVariable.Client_Add, data, ref list2, PublicVariable.TimeTag, ref splitFlag);
                    break;

                case Link_Math.明文_RN:
                    flag2 = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag2 = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag2 = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag2 = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多属性设置" + (flag2 ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
        }
        private void tb_多属性设置_Page2()
        {
            string[] strArray = new string[] { "30000500", "30010500", "30020500", "30030500", "301D0600", "301E0600", "30040500", "30060500" };
            byte[][] bufferArray3 = new byte[8][];
            bufferArray3[0] = new byte[] { 1, 1, 4, 0 };
            byte[] buffer = new byte[2];
            buffer[0] = 1;
            bufferArray3[1] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 1;
            bufferArray3[2] = buffer2;
            byte[] buffer3 = new byte[3];
            buffer3[0] = 1;
            buffer3[1] = 4;
            bufferArray3[3] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 2;
            bufferArray3[4] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 2;
            bufferArray3[5] = buffer5;
            bufferArray3[6] = new byte[] { 1, 4, 4, 0 };
            byte[] buffer6 = new byte[3];
            buffer6[0] = 1;
            buffer6[1] = 4;
            bufferArray3[7] = buffer6;
            byte[][] strDot = bufferArray3;
            byte[][] strLen = new byte[][] { new byte[] { 2, 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 4, 1 }, new byte[] { 2, 4, 1 } };
            string[] strType = new string[] { "0218180517", "021817", "021817", "02180517", "021617", "021617", "0218050517", "02180517" };
            string[] strlen = new string[] { "0402020401", "020201", "020201", "03020101", "020201", "020201", "0402040401", "03020401" };
            int[] num = new int[] { 0, 4, 6, 8, 11, 13, 15, 0x13, 0x16 };
            this.tb_多属性设置_Page(this.cbArry2, this.tbArry2, strArray, strDot, strLen, strType, strlen, num);
        }

        private void tb_多属性设置_Page3()
        {
            string[] strArray = new string[] { "30050500", "302D0600", "30080500", "30070500", "30090600", "300A0600", "300B0500", "300C0600", "40300200" };
            byte[][] bufferArray3 = new byte[9][];
            byte[] buffer = new byte[2];
            buffer[0] = 4;
            bufferArray3[0] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 2;
            bufferArray3[1] = buffer2;
            byte[] buffer3 = new byte[2];
            buffer3[0] = 1;
            bufferArray3[2] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 1;
            bufferArray3[3] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 4;
            bufferArray3[4] = buffer5;
            byte[] buffer6 = new byte[2];
            buffer6[0] = 4;
            bufferArray3[5] = buffer6;
            byte[] buffer7 = new byte[2];
            buffer7[0] = 4;
            bufferArray3[6] = buffer7;
            byte[] buffer8 = new byte[2];
            buffer8[0] = 1;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[] { 1, 1, 1, 1 };
            byte[][] strDot = bufferArray3;
            byte[][] strLen = new byte[][] { new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 2, 2, 2 } };
            int[] num = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 0x10, 20 };
            string[] strType = new string[] { "020517", "021617", "020517", "020517", "020617", "020617", "020617", "021617", "0218181818" };
            string[] strlen = new string[] { "020401", "020201", "020401", "020401", "020401", "020401", "020401", "020201", "0402020202" };
            this.tb_多属性设置_Page(this.cbArry3, this.tbArry3, strArray, strDot, strLen, strType, strlen, num);
        }

        private void tb_多属性设置_Page4()
        {
            string[] strArray = new string[] { "300E0600", "300F0600", "30100600", "30110600", "302E0600", "302F0600", "30300600", "80000200", "40040200", "30400600", "40000500" };
            byte[][] bufferArray3 = new byte[11][];
            bufferArray3[0] = new byte[1];
            bufferArray3[1] = new byte[1];
            bufferArray3[2] = new byte[1];
            bufferArray3[3] = new byte[1];
            bufferArray3[4] = new byte[1];
            bufferArray3[5] = new byte[1];
            bufferArray3[6] = new byte[1];
            byte[] buffer8 = new byte[2];
            buffer8[0] = 4;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[9];
            byte[] buffer10 = new byte[3];
            buffer10[0] = 4;
            buffer10[1] = 2;
            bufferArray3[9] = buffer10;
            bufferArray3[10] = new byte[2];
            byte[][] strDot = bufferArray3;
            byte[][] strLen = new byte[][] { new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 4, 2 }, new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 4 }, new byte[] { 4, 2, 1 }, new byte[] { 2, 2 } };
            int[] num = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9, 0x12, 0x15, 0x17 };
            string[] strType = new string[] { "0217", "0217", "0217", "0217", "0217", "0217", "0217", "020618", "020222171717022217171706", "02051817", "021818" };
            string[] strlen = new string[] { "0101", "0101", "0101", "0101", "0101", "0101", "0101", "020402", "030401010101040101010104", "03040201", "020202" };
            this.tb_多属性设置_Page(this.cbArry4, this.tbArry4, strArray, strDot, strLen, strType, strlen, num);
        }

        private void tb_设置后读取_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    this.InintColor();
                    if (this.tabControl1.SelectedTab == this.tabPage1)
                    {
                        this.tb_设置后读取_Page1();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage2)
                    {
                        this.tb_设置后读取_Page2();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage3)
                    {
                        this.tb_设置后读取_Page3();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage4)
                    {
                        this.tb_设置后读取_Page4();
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
        private void tb_设置后读取_Page(CheckBox[] cbArry, TextBox[] tbArry, string[] strArray, byte[][] strDot, byte[][] strLen, string[] strType, string[] strlen, int[] Num)
        {
            bool splitFlag = false;
            byte sEQOfOAD = 0;
            string data = "";
            string str2 = "";
            List<string> frameData = new List<string>();
            List<byte> list2 = new List<byte>();
            List<string> list3 = new List<string>();
            List<string> list4 = new List<string>();
            string item = "";
            string str4 = "";
            string str5 = "";
            string parseData = "";
            new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (((cbArry[i] != null) && cbArry[i].Visible) && cbArry[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    list2.Add((byte)i);
                    str2 = "";
                    frameData.Clear();
                    for (int m = Num[i]; m < Num[i + 1]; m++)
                    {
                        double num8 = Convert.ToDouble(tbArry[m].Text.Trim().PadLeft(strLen[i][m - Num[i]] * 2, '0')) * Math.Pow(10.0, (double)strDot[i][m - Num[i]]);
                        str2 = str2 + num8.ToString().PadLeft(strLen[i][m - Num[i]] * 2, '0');
                    }
                    item = Protocol.From_Type_GetData(ref strType[i], ref strlen[i], ref str2, ref frameData);
                    data = (data + strArray[i] + item) + strArray[i] + "00";
                    list4.Add(item);
                }
            }
            string str = string.Join("", list4.ToArray());
            string str10 = "";
            string str11 = "";
            for (int j = 0; j < sEQOfOAD; j++)
            {
                Protocol.AnalyDataType(ref str, ref str10);
                list3.Add(str10);
            }
            List<string> list5 = new List<string>();
            bool[] flagArray = new bool[0x16];
            bool[] flagArray2 = new bool[0x16];
            int num5 = -1;
            linkdata = Protocol.MakeLink_Data("06", "03", PublicVariable.PIID_W.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    Protocol.SetThenGetRequestNormalList(sEQOfOAD, "43", PublicVariable.Address, PublicVariable.Client_Add, data, ref list5, PublicVariable.TimeTag, ref splitFlag, ref flagArray, ref flagArray2, ref str11);
                    break;

                case Link_Math.明文_RN:
                    Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list5, ref mAC, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list5, ref mAC, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list5, ref mAC, ref str4, ref str5, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list5, ref mAC, ref str4, ref str5, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;
            }
            for (int k = 0; k < sEQOfOAD; k++)
            {
                if (flagArray2[k])
                {
                    num5++;
                }
                for (int m = Num[list2[k]]; m < Num[list2[k] + 1]; m++)
                {
                    if ((flagArray[k] && flagArray2[k]) && (list3[k].Substring(0, 2 * strLen[list2[k]][m - Num[list2[k]]]) == list5[num5].Substring(0, 2 * strLen[list2[k]][m - Num[list2[k]]])))
                    {
                        tbArry[m].BackColor = Color.Aqua;
                        tbArry[m].Text = tbArry[m].Text + "--" + ((Convert.ToDouble(list5[num5].Substring(0, 2 * strLen[list2[k]][m - Num[list2[k]]])) / Math.Pow(10.0, (double)strDot[list2[k]][m - Num[list2[k]]]))).ToString();
                        list3[k] = list3[k].Substring(2 * strLen[list2[k]][m - Num[list2[k]]]);
                        list5[num5] = list5[num5].Substring(2 * strLen[list2[k]][m - Num[list2[k]]]);
                    }
                    else
                    {
                        tbArry[m].BackColor = Color.Red;
                        if (flagArray[k] || flagArray2[k])
                        {
                            tbArry[m].Text = (flagArray[k] ? "  " : "--") + tbArry[m].Text + (flagArray2[k] ? " " : "--");
                        }
                    }
                }
                PublicVariable.Info = cbArry[list2[k]].Text + "设置" + (flagArray[k] ? "成功" : "失败") + str11 + "-||-读取" + (flagArray2[k] ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = (flagArray[k] && flagArray2[k]) ? "Blue" : "Red";
            }
        }
        private void tb_设置后读取_Page1()
        {
            bool splitFlag = false;
            string[] strArray = new string[] { 
                "40000200", "40020200", "41030200", "40010200", "40030200", "41090200", "410A0200", "41000200", "41010200", "F3010300", "F3000300", "41020200", "41160201", "41160202", "41160203", "40070201",
                "40070202", "40070203", "40070204", "40070205", "40070206", "40070207"
            };
            string[] strArray2 = new string[] { 
                "28", "09", "10", "09", "09", "06", "06", "17", "17", "18", "18", "17", "021717", "021717", "021717", "17",
                "18", "18", "18", "17", "17", "17"
            };
            string[] strArray3 = new string[] { 
                "07", "06", "16", "06", "06", "04", "04", "01", "01", "02", "02", "01", "020101", "020101", "020101", "01",
                "02", "02", "02", "01", "01", "01"
            };
            byte sEQOfOAD = 0;
            string data = "";
            string text = "";
            List<string> frameData = new List<string>();
            List<byte> list2 = new List<byte>();
            List<string> list3 = new List<string>();
            List<string> list4 = new List<string>();
            string item = "";
            string str4 = "";
            string str5 = "";
            string parseData = "";
            new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < this.ch_Arr_Buff.Length; i++)
            {
                if (((this.ch_Arr_Buff[i] != null) && this.ch_Arr_Buff[i].Visible) && this.ch_Arr_Buff[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    list2.Add((byte)i);
                    switch (i)
                    {
                        case 0:
                            text = this.txt_DateAndTime.Value.ToString("yyyyMMddHHmmss");
                            item = Protocol.From_Type_GetData(Convert.ToByte(strArray2[i]), Convert.ToByte(strArray3[i]), ref text);
                            data = (data + strArray[i] + item) + strArray[i] + "00";
                            list4.Add(item);
                            break;

                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            text = this.tbArray[i].Text;
                            item = Protocol.From_Type_GetData(Convert.ToByte(strArray2[i]), Convert.ToByte(strArray3[i]), ref text);
                            data = (data + strArray[i] + item) + strArray[i] + "00";
                            list4.Add(item);
                            break;

                        case 12:
                        case 13:
                        case 14:
                            frameData.Clear();
                            text = this.tb_jiesuanArray[i - 12].Text.Substring(0, this.tb_jiesuanArray[i - 12].Text.IndexOf("日")).PadLeft(2, '0') + this.tb_jiesuanArray[i - 12].Text.Substring(this.tb_jiesuanArray[i - 12].Text.IndexOf("日") + 1, 2).PadLeft(2, '0');
                            item = Protocol.From_Type_GetData(ref strArray2[i], ref strArray3[i], ref text, ref frameData);
                            data = (data + strArray[i] + item) + strArray[i] + "00";
                            list4.Add(item);
                            break;

                        case 15:
                        case 0x10:
                        case 0x11:
                        case 0x12:
                        case 0x13:
                        case 20:
                        case 0x15:
                            text = this.tb_LCDArray[i - 15].Text.PadLeft(Convert.ToByte(strArray3[i]) * 2, '0');
                            item = Protocol.From_Type_GetData(Convert.ToByte(strArray2[i]), Convert.ToByte(strArray3[i]), ref text);
                            data = (data + strArray[i] + item) + strArray[i] + "00";
                            list4.Add(item);
                            break;
                    }
                }
            }
            string str = string.Join("", list4.ToArray());
            string str10 = "";
            string str11 = "";
            for (int j = 0; j < sEQOfOAD; j++)
            {
                Protocol.AnalyDataType(ref str, ref str10);
                list3.Add(str10);
            }
            List<string> list5 = new List<string>();
            bool[] flagArray = new bool[0x16];
            bool[] flagArray2 = new bool[0x16];
            int num4 = -1;
            linkdata = Protocol.MakeLink_Data("06", "03", PublicVariable.PIID_W.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    Protocol.SetThenGetRequestNormalList(sEQOfOAD, "43", PublicVariable.Address, PublicVariable.Client_Add, data, ref list5, PublicVariable.TimeTag, ref splitFlag, ref flagArray, ref flagArray2, ref str11);
                    break;

                case Link_Math.明文_RN:
                    Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list5, ref mAC, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list5, ref mAC, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list5, ref mAC, ref str4, ref str5, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list5, ref mAC, ref str4, ref str5, ref splitFlag, ref flagArray, ref flagArray2, ref str11, ref cOutData);
                    break;
            }
            for (int k = 0; k < sEQOfOAD; k++)
            {
                if (flagArray2[k])
                {
                    num4++;
                }
                if ((flagArray[k] && flagArray2[k]) && (list3[k] == list5[num4]))
                {
                    if ((list2[k] >= 1) && (list2[k] <= 11))
                    {
                        this.tbArray[list2[k]].BackColor = Color.Aqua;
                        this.tbArray[list2[k]].Text = this.tbArray[list2[k]].Text + "--" + list5[num4];
                    }
                    if ((list2[k] >= 12) && (list2[k] <= 14))
                    {
                        this.tb_jiesuanArray[list2[k] - 12].BackColor = Color.Aqua;
                        this.tb_jiesuanArray[list2[k] - 12].Text = list5[num4].Substring(0, 2) + "日" + list5[num4].Substring(2, 2) + "时";
                    }
                    if ((list2[k] >= 15) && (list2[k] <= 0x15))
                    {
                        this.tb_LCDArray[list2[k] - 15].BackColor = Color.Aqua;
                        this.tb_LCDArray[list2[k] - 15].Text = this.tb_LCDArray[list2[k] - 15].Text + "--" + list5[num4];
                    }
                }
                else
                {
                    if ((list2[k] >= 1) && (list2[k] <= 11))
                    {
                        this.tbArray[list2[k]].BackColor = Color.Red;
                        if (flagArray[k] || flagArray2[k])
                        {
                            this.tbArray[list2[k]].Text = (flagArray[k] ? "  " : "--") + this.tbArray[list2[k]].Text + (flagArray2[k] ? " " : "--");
                        }
                    }
                    if ((list2[k] >= 12) && (list2[k] <= 14))
                    {
                        this.tb_jiesuanArray[list2[k] - 12].BackColor = Color.Red;
                        if (flagArray[k] || flagArray2[k])
                        {
                            this.tb_jiesuanArray[list2[k] - 12].Text = list5[num4].Substring(0, 2) + "日" + list5[num4].Substring(2, 2) + "时";
                        }
                    }
                    if ((list2[k] >= 15) && (list2[k] <= 0x15))
                    {
                        this.tb_LCDArray[list2[k] - 15].BackColor = Color.Red;
                        if (flagArray[k] || flagArray2[k])
                        {
                            this.tb_LCDArray[list2[k] - 15].Text = (flagArray[k] ? "  " : "--") + this.tb_LCDArray[list2[k] - 15].Text + (flagArray2[k] ? "  " : "--");
                        }
                    }
                }
                PublicVariable.Info = this.ch_Arr_Buff[list2[k]].Text + "设置" + (flagArray[k] ? "成功" : "失败") + str11 + "-||-读取" + (flagArray2[k] ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = (flagArray[k] && flagArray2[k]) ? "Blue" : "Red";
            }
        }

        private void tb_设置后读取_Page2()
        {
            string[] strArray = new string[] { "30000500", "30010500", "30020500", "30030500", "301D0600", "301E0600", "30040500", "30060500" };
            byte[][] bufferArray3 = new byte[8][];
            bufferArray3[0] = new byte[] { 1, 1, 4, 0 };
            byte[] buffer = new byte[2];
            buffer[0] = 1;
            bufferArray3[1] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 1;
            bufferArray3[2] = buffer2;
            byte[] buffer3 = new byte[3];
            buffer3[0] = 1;
            buffer3[1] = 4;
            bufferArray3[3] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 2;
            bufferArray3[4] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 2;
            bufferArray3[5] = buffer5;
            bufferArray3[6] = new byte[] { 1, 4, 4, 0 };
            byte[] buffer6 = new byte[3];
            buffer6[0] = 1;
            buffer6[1] = 4;
            bufferArray3[7] = buffer6;
            byte[][] strDot = bufferArray3;
            byte[][] strLen = new byte[][] { new byte[] { 2, 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 4, 1 }, new byte[] { 2, 4, 1 } };
            string[] strType = new string[] { "0218180517", "021817", "021817", "02180517", "021617", "021617", "0218050517", "02180517" };
            string[] strlen = new string[] { "0402020401", "020201", "020201", "03020101", "020201", "020201", "0402040401", "03020401" };
            int[] num = new int[] { 0, 4, 6, 8, 11, 13, 15, 0x13, 0x16 };
            this.tb_设置后读取_Page(this.cbArry2, this.tbArry2, strArray, strDot, strLen, strType, strlen, num);
        }

        private void tb_设置后读取_Page3()
        {
            string[] strArray = new string[] { "30050500", "302D0600", "30080500", "30070500", "30090600", "300A0600", "300B0500", "300C0600", "40300200" };
            byte[][] bufferArray3 = new byte[9][];
            byte[] buffer = new byte[2];
            buffer[0] = 4;
            bufferArray3[0] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 2;
            bufferArray3[1] = buffer2;
            byte[] buffer3 = new byte[2];
            buffer3[0] = 1;
            bufferArray3[2] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 1;
            bufferArray3[3] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 4;
            bufferArray3[4] = buffer5;
            byte[] buffer6 = new byte[2];
            buffer6[0] = 4;
            bufferArray3[5] = buffer6;
            byte[] buffer7 = new byte[2];
            buffer7[0] = 4;
            bufferArray3[6] = buffer7;
            byte[] buffer8 = new byte[2];
            buffer8[0] = 1;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[] { 1, 1, 1, 1 };
            byte[][] strDot = bufferArray3;
            byte[][] strLen = new byte[][] { new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 2, 2, 2 } };
            int[] num = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 0x10, 20 };
            string[] strType = new string[] { "020517", "021617", "020517", "020517", "020617", "020617", "020617", "021617", "0218181818" };
            string[] strlen = new string[] { "020401", "020201", "020401", "020401", "020401", "020401", "020401", "020201", "0402020202" };
            this.tb_设置后读取_Page(this.cbArry3, this.tbArry3, strArray, strDot, strLen, strType, strlen, num);
        }

        private void tb_设置后读取_Page4()
        {
            string[] strArray = new string[] { "300E0600", "300F0600", "30100600", "30110600", "302E0600", "302F0600", "30300600", "80000200", "40040200", "30400600", "40000500" };
            byte[][] bufferArray3 = new byte[11][];
            bufferArray3[0] = new byte[1];
            bufferArray3[1] = new byte[1];
            bufferArray3[2] = new byte[1];
            bufferArray3[3] = new byte[1];
            bufferArray3[4] = new byte[1];
            bufferArray3[5] = new byte[1];
            bufferArray3[6] = new byte[1];
            byte[] buffer8 = new byte[2];
            buffer8[0] = 4;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[9];
            byte[] buffer10 = new byte[3];
            buffer10[0] = 4;
            buffer10[1] = 2;
            bufferArray3[9] = buffer10;
            bufferArray3[10] = new byte[2];
            byte[][] strDot = bufferArray3;
            byte[][] strLen = new byte[][] { new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 4, 2 }, new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 4 }, new byte[] { 4, 2, 1 }, new byte[] { 2, 2 } };
            int[] num = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9, 0x12, 0x15, 0x17 };
            string[] strType = new string[] { "0217", "0217", "0217", "0217", "0217", "0217", "0217", "020618", "020222171717022217171706", "02051817", "021818" };
            string[] strlen = new string[] { "0101", "0101", "0101", "0101", "0101", "0101", "0101", "020402", "030401010101040101010104", "03040201", "020202" };
            this.tb_设置后读取_Page(this.cbArry4, this.tbArry4, strArray, strDot, strLen, strType, strlen, num);
        }

        private void tbn_单项抄读_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    this.InintColor();
                    if (this.tabControl1.SelectedTab == this.tabPage1)
                    {
                        this.tn_单项抄读_Page1();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage2)
                    {
                        this.tn_单项抄读_Page2();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage3)
                    {
                        this.tn_单项抄读_Page3();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage4)
                    {
                        this.tn_单项抄读_Page4();
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

        private void tbn_单属性设置_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    this.InintColor();
                    if (this.tabControl1.SelectedTab == this.tabPage1)
                    {
                        this.tn_单相设置_Page1();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage2)
                    {
                        this.tn_单相设置_Page2();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage3)
                    {
                        this.tn_单相设置_Page3();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage4)
                    {
                        this.tn_单相设置_Page4();
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

        private void tbn_多项抄读_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    this.InintColor();
                    if (this.tabControl1.SelectedTab == this.tabPage1)
                    {
                        this.tn_多项抄读_Page1();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage2)
                    {
                        this.tn_多项抄读_Page2();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage3)
                    {
                        this.tn_多项抄读_Page3();
                    }
                    if (this.tabControl1.SelectedTab == this.tabPage4)
                    {
                        this.tn_多项抄读_Page4();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.txt_DateAndTime.Value = DateTime.Now;
        }
        public void tn_单相设置_Page1()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string data = "";
            string[] strArray = new string[] { "40000200", "40020200", "41030200", "40010200", "40030200", "41090200", "410A0200", "41000200", "41010200", "F3010300", "F3000300", "41020200" };
            byte[] buffer = new byte[] { 0x1c, 9, 10, 9, 9, 6, 6, 0x11, 0x11, 0x12, 0x12, 0x11 };
            byte[] buffer2 = new byte[] { 7, 6, 0x10, 6, 6, 4, 4, 1, 1, 2, 2, 1 };
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < 12; i++)
            {
                if (((this.chkArry[i] == null) || !this.chkArry[i].Visible) || !this.chkArry[i].Checked)
                {
                    continue;
                }
                cData = "";
                if (i == 0)
                {
                    data = this.txt_DateAndTime.Value.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    data = this.tbArray[i].Text;
                }
                cData = Protocol.From_Type_GetData(buffer[i], buffer2[i], ref data);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], cData, PublicVariable.TimeTag, ref splitFlag);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = this.chkArry[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (!flag)
                {
                    PublicVariable.IsReading = false;
                    return;
                }
            }
            string[] strArray2 = new string[] { "41160201", "41160202", "41160203" };
            string dataType = "01021717021717021717";
            string dataLen = "03020101020101020101";
            List<string> frameData = new List<string>();
            if ((((this.chk_24 == null) || !this.chk_24.Visible) || (!this.chk_24.Checked || !this.chk_13.Checked)) || (!this.chk_14.Checked || !this.chk_15.Checked))
            {
                for (int j = 0; j < strArray2.Length; j++)
                {
                    cData = "";
                    frameData.Clear();
                    string str10 = "021717";
                    string str11 = "020101";
                    if (((this.jiesuanArray[j] != null) && this.jiesuanArray[j].Visible) && this.jiesuanArray[j].Checked)
                    {
                        cData = this.tb_jiesuanArray[j].Text.Substring(0, this.tb_jiesuanArray[j].Text.IndexOf("日")).PadLeft(2, '0') + this.tb_jiesuanArray[j].Text.Substring(this.tb_jiesuanArray[j].Text.IndexOf("日") + 1, 2).PadLeft(2, '0');
                        cData = Protocol.From_Type_GetData(ref str10, ref str11, ref cData, ref frameData);
                        linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray2[j] + cData, PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray2[j], cData, PublicVariable.TimeTag, ref splitFlag);
                                break;

                            case Link_Math.明文_RN:
                                flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.明文_SID_MAC:
                                flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID:
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = this.jiesuanArray[j].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (!flag)
                        {
                            PublicVariable.IsReading = false;
                            return;
                        }
                    }
                }
            }
            else
            {
                cData = "";
                frameData.Clear();
                this.txt_13.Text = this.txt_13.Text.Trim();
                this.txt_14.Text = this.txt_14.Text.Trim();
                this.txt_15.Text = this.txt_15.Text.Trim();
                cData = ((this.txt_13.Text.Substring(0, this.txt_13.Text.IndexOf("日")).PadLeft(2, '0') + this.txt_13.Text.Substring(this.txt_13.Text.IndexOf("日") + 1, 2).PadLeft(2, '0')) + this.txt_14.Text.Substring(0, this.txt_14.Text.IndexOf("日")).PadLeft(2, '0') + this.txt_14.Text.Substring(this.txt_14.Text.IndexOf("日") + 1, 2).PadLeft(2, '0')) + this.txt_15.Text.Substring(0, this.txt_15.Text.IndexOf("日")).PadLeft(2, '0') + this.txt_15.Text.Substring(this.txt_15.Text.IndexOf("日") + 1, 2).PadLeft(2, '0');
                cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref cData, ref frameData);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), "41160200" + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, "41160200", cData, PublicVariable.TimeTag, ref splitFlag);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = this.chk_24.Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (!flag)
                {
                    PublicVariable.IsReading = false;
                    return;
                }
            }
            string[] strArray3 = new string[] { "40070201", "40070202", "40070203", "40070204", "40070205", "40070206", "40070207" };
            dataType = "0217181818171717";
            dataLen = "0701020202010101";
            if (((((this.chk_16 == null) || !this.chk_16.Visible) || (!this.chk_16.Checked || !this.chk_17.Checked)) || ((!this.chk_18.Checked || !this.chk_19.Checked) || (!this.chk_20.Checked || !this.chk_21.Checked))) || (!this.chk_22.Checked || !this.chk_23.Checked))
            {
                byte[] buffer4 = new byte[] { 0x11, 0x12, 0x12, 0x12, 0x11, 0x11, 0x11 };
                byte[] buffer5 = new byte[] { 1, 2, 2, 2, 1, 1, 1 };
                for (int j = 0; j < strArray3.Length; j++)
                {
                    cData = "";
                    frameData.Clear();
                    if (((this.LCDArray[j] != null) && this.LCDArray[j].Visible) && this.LCDArray[j].Checked)
                    {
                        cData = this.tb_LCDArray[j].Text.PadLeft(buffer5[j] * 2, '0');
                        cData = Protocol.From_Type_GetData(buffer4[j], buffer5[j], ref cData);
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
                                flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;

                            case Link_Math.密文_SID_MAC:
                                flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                                break;
                        }
                        PublicVariable.Info = this.LCDArray[j].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (!flag)
                        {
                            PublicVariable.IsReading = false;
                            return;
                        }
                    }
                }
            }
            else
            {
                cData = "";
                frameData.Clear();
                byte[] buffer3 = PublicVariable.HexToByte(dataLen);
                for (int j = 0; j < this.LCDArray.Length; j++)
                {
                    cData = cData + this.tb_LCDArray[j].Text.PadLeft(buffer3[j + 1] * 2, '0');
                }
                cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref cData, ref frameData);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), "40070200" + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, "40070200", cData, PublicVariable.TimeTag, ref splitFlag);
                        break;

                    case Link_Math.明文_RN:
                        flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.明文_SID_MAC:
                        flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list, ref mAC, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID:
                        flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;

                    case Link_Math.密文_SID_MAC:
                        flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list, ref mAC, ref str3, ref str4, ref splitFlag, ref cOutData);
                        break;
                }
                PublicVariable.Info = this.chk_16.Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (!flag)
                {
                    PublicVariable.IsReading = false;
                }
            }
        }

        private void tn_单相设置_Page2()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string data = "";
            List<string> frameData = new List<string>();
            string[] strArray = new string[] { "30000500", "30010500", "30020500", "30030500", "301D0600", "301E0600", "30040500", "30060500" };
            byte[][] bufferArray3 = new byte[8][];
            bufferArray3[0] = new byte[] { 1, 1, 4, 0 };
            byte[] buffer = new byte[2];
            buffer[0] = 1;
            bufferArray3[1] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 1;
            bufferArray3[2] = buffer2;
            byte[] buffer3 = new byte[3];
            buffer3[0] = 1;
            buffer3[1] = 4;
            bufferArray3[3] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 2;
            bufferArray3[4] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 2;
            bufferArray3[5] = buffer5;
            bufferArray3[6] = new byte[] { 1, 4, 4, 0 };
            byte[] buffer6 = new byte[3];
            buffer6[0] = 1;
            buffer6[1] = 4;
            bufferArray3[7] = buffer6;
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 2, 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 4, 1 }, new byte[] { 2, 4, 1 } };
            string[] strArray2 = new string[] { "0218180517", "021817", "021817", "02180517", "021617", "021617", "0218050517", "02180517" };
            string[] strArray3 = new string[] { "0402020401", "020201", "020201", "03020101", "020201", "020201", "0402040401", "03020401" };
            int[] numArray = new int[] { 0, 4, 6, 8, 11, 13, 15, 0x13, 0x16 };
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list2 = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (((this.cbArry2[i] == null) || !this.cbArry2[i].Visible) || !this.cbArry2[i].Checked)
                {
                    continue;
                }
                data = "";
                for (int j = numArray[i]; j < numArray[i + 1]; j++)
                {
                    double num3 = Convert.ToDouble(this.tbArry2[j].Text.Trim().PadLeft(bufferArray2[i][j - numArray[i]] * 2, '0')) * Math.Pow(10.0, (double)bufferArray[i][j - numArray[i]]);
                    data = data + num3.ToString().PadLeft(bufferArray2[i][j - numArray[i]] * 2, '0');
                }
                cData = "";
                frameData.Clear();
                cData = Protocol.From_Type_GetData(ref strArray2[i], ref strArray3[i], ref data, ref frameData);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], cData, PublicVariable.TimeTag, ref splitFlag);
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
                PublicVariable.Info = this.cbArry2[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (!flag)
                {
                    PublicVariable.IsReading = false;
                    return;
                }
            }
        }

        private void tn_单相设置_Page3()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string data = "";
            List<string> frameData = new List<string>();
            string[] strArray = new string[] { "30050500", "302D0600", "30080500", "30070500", "30090600", "300A0600", "300B0500", "300C0600", "40300200" };
            byte[][] bufferArray3 = new byte[9][];
            byte[] buffer = new byte[2];
            buffer[0] = 4;
            bufferArray3[0] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 2;
            bufferArray3[1] = buffer2;
            byte[] buffer3 = new byte[2];
            buffer3[0] = 1;
            bufferArray3[2] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 1;
            bufferArray3[3] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 4;
            bufferArray3[4] = buffer5;
            byte[] buffer6 = new byte[2];
            buffer6[0] = 4;
            bufferArray3[5] = buffer6;
            byte[] buffer7 = new byte[2];
            buffer7[0] = 4;
            bufferArray3[6] = buffer7;
            byte[] buffer8 = new byte[2];
            buffer8[0] = 1;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[] { 1, 1, 1, 1 };
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 2, 2, 2 } };
            int[] numArray = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 0x10, 20 };
            string[] strArray2 = new string[] { "020517", "021617", "020517", "020517", "020617", "020617", "020617", "021617", "0218181818" };
            string[] strArray3 = new string[] { "020401", "020201", "020401", "020401", "020401", "020401", "020401", "020201", "0402020202" };
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list2 = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (((this.cbArry3[i] == null) || !this.cbArry3[i].Visible) || !this.cbArry3[i].Checked)
                {
                    continue;
                }
                data = "";
                for (int j = numArray[i]; j < numArray[i + 1]; j++)
                {
                    double num3 = Convert.ToDouble(this.tbArry3[j].Text.Trim().PadLeft(bufferArray2[i][j - numArray[i]] * 2, '0')) * Math.Pow(10.0, (double)bufferArray[i][j - numArray[i]]);
                    data = data + num3.ToString().PadLeft(bufferArray2[i][j - numArray[i]] * 2, '0');
                }
                cData = "";
                frameData.Clear();
                cData = Protocol.From_Type_GetData(ref strArray2[i], ref strArray3[i], ref data, ref frameData);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], cData, PublicVariable.TimeTag, ref splitFlag);
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
                PublicVariable.Info = this.cbArry3[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (!flag)
                {
                    PublicVariable.IsReading = false;
                    return;
                }
            }
        }

        private void tn_单相设置_Page4()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string data = "";
            List<string> frameData = new List<string>();
            string[] strArray = new string[] { "300E0600", "300F0600", "30100600", "30110600", "302E0600", "302F0600", "30300600", "80000200", "40040200", "30400600", "40000500" };
            byte[][] bufferArray3 = new byte[11][];
            bufferArray3[0] = new byte[1];
            bufferArray3[1] = new byte[1];
            bufferArray3[2] = new byte[1];
            bufferArray3[3] = new byte[1];
            bufferArray3[4] = new byte[1];
            bufferArray3[5] = new byte[1];
            bufferArray3[6] = new byte[1];
            byte[] buffer8 = new byte[2];
            buffer8[0] = 4;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[9];
            byte[] buffer10 = new byte[3];
            buffer10[0] = 4;
            buffer10[1] = 2;
            bufferArray3[9] = buffer10;
            bufferArray3[10] = new byte[2];
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 4, 2 }, new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 4 }, new byte[] { 4, 2, 1 }, new byte[] { 2, 2 } };
            int[] numArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9, 0x12, 0x15, 0x17 };
            string[] strArray2 = new string[] { "0217", "0217", "0217", "0217", "0217", "0217", "0217", "020618", "020222171717022217171706", "02051817", "021818" };
            string[] strArray3 = new string[] { "0101", "0101", "0101", "0101", "0101", "0101", "0101", "020402", "030401010101040101010104", "03040201", "020202" };
            string str3 = "";
            string str4 = "";
            string parseData = "";
            List<string> list2 = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (((this.cbArry4[i] == null) || !this.cbArry4[i].Visible) || !this.cbArry4[i].Checked)
                {
                    continue;
                }
                data = "";
                for (int j = numArray[i]; j < numArray[i + 1]; j++)
                {
                    double num3 = Convert.ToDouble(this.tbArry4[j].Text.Trim().PadLeft(bufferArray2[i][j - numArray[i]] * 2, '0')) * Math.Pow(10.0, (double)bufferArray[i][j - numArray[i]]);
                    data = data + num3.ToString().PadLeft(bufferArray2[i][j - numArray[i]] * 2, '0');
                }
                cData = "";
                frameData.Clear();
                cData = Protocol.From_Type_GetData(ref strArray2[i], ref strArray3[i], ref data, ref frameData);
                linkdata = Protocol.MakeLink_Data("06", "01", PublicVariable.PIID_W.ToString("X2"), strArray[i] + cData, PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.SetRequestNormal("43", PublicVariable.Address, PublicVariable.Client_Add, strArray[i], cData, PublicVariable.TimeTag, ref splitFlag);
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
                PublicVariable.Info = this.cbArry4[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (!flag)
                {
                    PublicVariable.IsReading = false;
                    return;
                }
            }
        }

        private void tn_单项抄读_Page1()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string[] strArray = new string[] { "40000200", "40020200", "41030200", "40010200", "40030200", "41090200", "410A0200", "41000200", "41010200", "F3010300", "F3000300", "41020200" };
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            for (int i = 0; i < strArray.Length; i++)
            {
                cData = "";
                parseData = "";
                list.Clear();
                if (((this.chkArry[i] != null) && this.chkArry[i].Checked) && this.chkArry[i].Visible)
                {
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[i], PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.GetRequestNormal(strArray[i], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = this.chkArry[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        if (i == 0)
                        {
                            this.checkBoxShiZhongTongbu.Checked = false;
                            this.txt_DateAndTime.Text = parseData.Substring(0, 4) + "-" + parseData.Substring(4, 2) + "-" + parseData.Substring(6, 2) + " " + parseData.Substring(8, 2) + ":" + parseData.Substring(10, 2) + ":" + parseData.Substring(12, 2);
                        }
                        else
                        {
                            this.tbArray[i].Text = parseData;
                        }
                    }
                }
            }
            string[] strArray2 = new string[] { "41160201", "41160202", "41160203" };
            if ((((this.chk_24 == null) || !this.chk_24.Visible) || (!this.chk_24.Checked || !this.chk_13.Checked)) || (!this.chk_14.Checked || !this.chk_15.Checked))
            {
                for (int j = 0; j < strArray2.Length; j++)
                {
                    cData = "";
                    parseData = "";
                    list.Clear();
                    if (((this.jiesuanArray[j] != null) && this.jiesuanArray[j].Visible) && this.jiesuanArray[j].Checked)
                    {
                        linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray2[j], PublicVariable.TimeTag);
                        switch (PublicVariable.link_Math)
                        {
                            case Link_Math.纯明文操作:
                                flag = Protocol.GetRequestNormal(strArray2[j], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                        PublicVariable.Info = this.jiesuanArray[j].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            this.tb_jiesuanArray[j].Text = parseData.Substring(0, 2) + "日" + parseData.Substring(2, 2) + "时";
                        }
                    }
                }
            }
            else
            {
                cData = "";
                parseData = "";
                list.Clear();
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), "41160200", PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.GetRequestNormal("41160200", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                PublicVariable.Info = this.chk_24.Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (flag)
                {
                    this.txt_13.Text = parseData.Substring(0, 2) + "日" + parseData.Substring(2, 2) + "时";
                    this.txt_14.Text = parseData.Substring(4, 2) + "日" + parseData.Substring(6, 2) + "时";
                    this.txt_15.Text = parseData.Substring(8, 2) + "日" + parseData.Substring(10, 2) + "时";
                }
            }
            string[] strArray3 = new string[] { "40070201", "40070202", "40070203", "40070204", "40070205", "40070206", "40070207" };
            if (((((this.chk_16 == null) || !this.chk_16.Visible) || (!this.chk_16.Checked || !this.chk_17.Checked)) || ((!this.chk_18.Checked || !this.chk_19.Checked) || (!this.chk_20.Checked || !this.chk_21.Checked))) || (!this.chk_22.Checked || !this.chk_23.Checked))
            {
                for (int j = 0; j < strArray3.Length; j++)
                {
                    cData = "";
                    parseData = "";
                    list.Clear();
                    if (((this.LCDArray[j] != null) && this.LCDArray[j].Visible) && this.LCDArray[j].Checked)
                    {
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
                        PublicVariable.Info = this.LCDArray[j].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            this.tb_LCDArray[j].Text = parseData;
                        }
                    }
                }
            }
            else
            {
                cData = "";
                parseData = "";
                list.Clear();
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), "40070200", PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        PublicVariable.Info = "";
                        flag = Protocol.GetRequestNormal("40070200", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                PublicVariable.Info = this.chk_16.Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (flag)
                {
                    this.txt_16.Text = parseData.Substring(0, 2);
                    this.txt_17.Text = parseData.Substring(2, 4);
                    this.txt_18.Text = parseData.Substring(6, 4);
                    this.txt_19.Text = parseData.Substring(10, 4);
                    this.txt_20.Text = parseData.Substring(14, 2);
                    this.txt_21.Text = parseData.Substring(0x10, 2);
                    this.txt_22.Text = parseData.Substring(0x12, 2);
                }
            }
        }

        private void tn_单项抄读_Page2()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            string[] strArray = new string[] { "30000500", "30010500", "30020500", "30030500", "301D0600", "301E0600", "30040500", "30060500" };
            byte[][] bufferArray3 = new byte[8][];
            bufferArray3[0] = new byte[] { 1, 1, 4, 0 };
            byte[] buffer = new byte[2];
            buffer[0] = 1;
            bufferArray3[1] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 1;
            bufferArray3[2] = buffer2;
            byte[] buffer3 = new byte[3];
            buffer3[0] = 1;
            buffer3[1] = 4;
            bufferArray3[3] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 2;
            bufferArray3[4] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 2;
            bufferArray3[5] = buffer5;
            bufferArray3[6] = new byte[] { 1, 4, 4, 0 };
            byte[] buffer6 = new byte[3];
            buffer6[0] = 1;
            buffer6[1] = 4;
            bufferArray3[7] = buffer6;
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 2, 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 4, 1 }, new byte[] { 2, 4, 1 } };
            double num = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                int num3;
                int num4;
                int num5;
                int num6;
                int num7;
                int num8;
                int num9;
                int num10;
                cData = "";
                parseData = "";
                list.Clear();
                if (((this.cbArry2[i] == null) || !this.cbArry2[i].Checked) || !this.cbArry2[i].Visible)
                {
                    continue;
                }
                linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[i], PublicVariable.TimeTag);
                switch (PublicVariable.link_Math)
                {
                    case Link_Math.纯明文操作:
                        flag = Protocol.GetRequestNormal(strArray[i], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                PublicVariable.Info = this.cbArry2[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                PublicVariable.Info_Color = flag ? "Blue" : "Red";
                if (flag)
                {
                    switch (i)
                    {
                        case 0:
                            num3 = 0;
                            goto Label_044D;

                        case 1:
                            num4 = 4;
                            goto Label_04C4;

                        case 2:
                            num5 = 6;
                            goto Label_053B;

                        case 3:
                            num6 = 8;
                            goto Label_05B2;

                        case 4:
                            num7 = 11;
                            goto Label_062E;

                        case 5:
                            num8 = 13;
                            goto Label_06AA;

                        case 6:
                            num9 = 15;
                            goto Label_0726;

                        case 7:
                            num10 = 0x13;
                            goto Label_079F;
                    }
                }
                continue;
            Label_03EB:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num3] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num3]);
                this.tbArry2[num3].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num3] * 2);
                num3++;
            Label_044D:
                if (num3 < 4)
                {
                    goto Label_03EB;
                }
                continue;
            Label_045C:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num4 - 4] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num4 - 4]);
                this.tbArry2[num4].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num4 - 4] * 2);
                num4++;
            Label_04C4:
                if (num4 < 6)
                {
                    goto Label_045C;
                }
                continue;
            Label_04D3:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num5 - 6] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num5 - 6]);
                this.tbArry2[num5].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num5 - 6] * 2);
                num5++;
            Label_053B:
                if (num5 < 8)
                {
                    goto Label_04D3;
                }
                continue;
            Label_054A:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num6 - 8] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num6 - 8]);
                this.tbArry2[num6].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num6 - 8] * 2);
                num6++;
            Label_05B2:
                if (num6 < 11)
                {
                    goto Label_054A;
                }
                continue;
            Label_05C3:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num7 - 11] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num7 - 11]);
                this.tbArry2[num7].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num7 - 11] * 2);
                num7++;
            Label_062E:
                if (num7 < 13)
                {
                    goto Label_05C3;
                }
                continue;
            Label_063F:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num8 - 13] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num8 - 13]);
                this.tbArry2[num8].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num8 - 13] * 2);
                num8++;
            Label_06AA:
                if (num8 < 15)
                {
                    goto Label_063F;
                }
                continue;
            Label_06BB:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num9 - 15] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num9 - 15]);
                this.tbArry2[num9].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num9 - 15] * 2);
                num9++;
            Label_0726:
                if (num9 < 0x13)
                {
                    goto Label_06BB;
                }
                continue;
            Label_0734:
                num = ((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][num10 - 0x13] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][num10 - 0x13]);
                this.tbArry2[num10].Text = num.ToString();
                parseData = parseData.Substring(bufferArray2[i][num10 - 0x13] * 2);
                num10++;
            Label_079F:
                if (num10 < 0x16)
                {
                    goto Label_0734;
                }
            }
        }

        private void tn_单项抄读_Page3()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            string[] strArray = new string[] { "30050500", "302D0600", "30080500", "30070500", "30090600", "300A0600", "300B0500", "300C0600", "40300200" };
            byte[][] bufferArray3 = new byte[9][];
            byte[] buffer = new byte[2];
            buffer[0] = 4;
            bufferArray3[0] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 2;
            bufferArray3[1] = buffer2;
            byte[] buffer3 = new byte[2];
            buffer3[0] = 1;
            bufferArray3[2] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 1;
            bufferArray3[3] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 4;
            bufferArray3[4] = buffer5;
            byte[] buffer6 = new byte[2];
            buffer6[0] = 4;
            bufferArray3[5] = buffer6;
            byte[] buffer7 = new byte[2];
            buffer7[0] = 4;
            bufferArray3[6] = buffer7;
            byte[] buffer8 = new byte[2];
            buffer8[0] = 1;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[] { 1, 1, 1, 1 };
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 2, 2, 2 } };
            int[] numArray = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 0x10, 20 };
            int index = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                index++;
                cData = "";
                parseData = "";
                list.Clear();
                if (((this.cbArry3[i] != null) && this.cbArry3[i].Checked) && this.cbArry3[i].Visible)
                {
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[i], PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.GetRequestNormal(strArray[i], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = this.cbArry3[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        for (int j = numArray[index - 1]; j < numArray[index]; j++)
                        {
                            this.tbArry3[j].Text = (((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][j - numArray[index - 1]] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][j - numArray[index - 1]])).ToString();
                            parseData = parseData.Substring(bufferArray2[i][j - numArray[index - 1]] * 2);
                        }
                    }
                }
            }
        }

        private void tn_单项抄读_Page4()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string str3 = "";
            string parseData = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            string[] strArray = new string[] { "300E0600", "300F0600", "30100600", "30110600", "302E0600", "302F0600", "30300600", "80000200", "40040200", "30400600", "40000500" };
            byte[][] bufferArray3 = new byte[11][];
            bufferArray3[0] = new byte[1];
            bufferArray3[1] = new byte[1];
            bufferArray3[2] = new byte[1];
            bufferArray3[3] = new byte[1];
            bufferArray3[4] = new byte[1];
            bufferArray3[5] = new byte[1];
            bufferArray3[6] = new byte[1];
            byte[] buffer8 = new byte[2];
            buffer8[0] = 4;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[9];
            byte[] buffer10 = new byte[3];
            buffer10[0] = 4;
            buffer10[1] = 2;
            bufferArray3[9] = buffer10;
            bufferArray3[10] = new byte[2];
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 4, 2 }, new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 4 }, new byte[] { 4, 2, 1 }, new byte[] { 2, 2 } };
            int[] numArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9, 0x12, 0x15, 0x17 };
            for (int i = 0; i < strArray.Length; i++)
            {
                cData = "";
                parseData = "";
                list.Clear();
                if (((this.cbArry4[i] != null) && this.cbArry4[i].Checked) && this.cbArry4[i].Visible)
                {
                    linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_R.ToString("X2"), strArray[i], PublicVariable.TimeTag);
                    switch (PublicVariable.link_Math)
                    {
                        case Link_Math.纯明文操作:
                            flag = Protocol.GetRequestNormal(strArray[i], "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
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
                    PublicVariable.Info = this.cbArry4[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                    PublicVariable.Info_Color = flag ? "Blue" : "Red";
                    if (flag)
                    {
                        for (int j = numArray[i]; j < numArray[i + 1]; j++)
                        {
                            this.tbArry4[j].Text = (((double)Convert.ToInt32(parseData.Substring(0, bufferArray2[i][j - numArray[i]] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[i][j - numArray[i]])).ToString();
                            parseData = parseData.Substring(bufferArray2[i][j - numArray[i]] * 2);
                        }
                    }
                }
            }
        }

        private void tn_多项抄读_Page1()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            string parseData = "";
            string str4 = "";
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            byte sEQOfOAD = 0;
            string[] strArray = new string[] { 
                "40000200", "40020200", "41030200", "40010200", "40030200", "41090200", "410A0200", "41000200", "41010200", "F3010300", "F3000300", "41020200", "41160201", "41160202", "41160203", "40070201",
                "40070202", "40070203", "40070204", "40070205", "40070206", "40070207"
            };
            string data = "";
            for (int i = 0; i < this.ch_Arr_Buff.Length; i++)
            {
                if (((this.ch_Arr_Buff[i] != null) && this.ch_Arr_Buff[i].Visible) && this.ch_Arr_Buff[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    data = data + strArray[i];
                }
            }
            cData = "";
            parseData = "";
            list2.Clear();
            byte num3 = 0;
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            linkdata = Protocol.MakeLink_Data("05", "02", PublicVariable.PIID_R.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormalList(sEQOfOAD, data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormalList(cData, ref str2, ref list, ref list2);
                    }
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str2, ref str4, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str2, ref str4, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多项属性" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                for (int j = 0; j < this.ch_Arr_Buff.Length; j++)
                {
                    if (((this.ch_Arr_Buff[j] != null) && this.ch_Arr_Buff[j].Visible) && this.ch_Arr_Buff[j].Checked)
                    {
                        num3 = (byte)(num3 + 1);
                        switch (j)
                        {
                            case 0:
                                this.checkBoxShiZhongTongbu.Checked = false;
                                this.txt_DateAndTime.Text = list2[0].Substring(0, 4) + "-" + list2[0].Substring(4, 2) + "-" + list2[0].Substring(6, 2) + " " + list2[0].Substring(8, 2) + ":" + list2[0].Substring(10, 2) + ":" + list2[0].Substring(12, 2);
                                break;

                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                                this.tbArray[j].Text = list2[num3 - 1].ToString();
                                break;

                            case 12:
                            case 13:
                            case 14:
                                this.tb_jiesuanArray[j - 12].Text = list2[num3 - 1].ToString().Substring(0, 2) + "日" + list2[num3 - 1].ToString().Substring(2, 2) + "时";
                                break;

                            case 15:
                            case 0x10:
                            case 0x11:
                            case 0x12:
                            case 0x13:
                            case 20:
                            case 0x15:
                                this.tb_LCDArray[j - 15].Text = list2[num3 - 1].ToString();
                                break;
                        }
                    }
                }
            }
        }

        private void tn_多项抄读_Page2()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            List<string> list = new List<string>();
            List<string> parseData = new List<string>();
            byte sEQOfOAD = 0;
            string[] strArray = new string[] { "30000500", "30010500", "30020500", "30030500", "301D0600", "301E0600", "30040500", "30060500" };
            byte[][] bufferArray3 = new byte[8][];
            bufferArray3[0] = new byte[] { 1, 1, 4, 0 };
            byte[] buffer = new byte[2];
            buffer[0] = 1;
            bufferArray3[1] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 1;
            bufferArray3[2] = buffer2;
            byte[] buffer3 = new byte[3];
            buffer3[0] = 1;
            buffer3[1] = 4;
            bufferArray3[3] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 2;
            bufferArray3[4] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 2;
            bufferArray3[5] = buffer5;
            bufferArray3[6] = new byte[] { 1, 4, 4, 0 };
            byte[] buffer6 = new byte[3];
            buffer6[0] = 1;
            buffer6[1] = 4;
            bufferArray3[7] = buffer6;
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 2, 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 4, 4, 1 }, new byte[] { 2, 4, 1 } };
            int[] numArray = new int[] { 0, 4, 6, 8, 11, 13, 15, 0x13, 0x16 };
            string data = "";
            for (int i = 0; i < this.cbArry2.Length; i++)
            {
                if (((this.cbArry2[i] != null) && this.cbArry2[i].Visible) && this.cbArry2[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    data = data + strArray[i];
                }
            }
            cData = "";
            parseData.Clear();
            byte num4 = 0;
            string linkdata = "";
            string str5 = "";
            string str6 = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            linkdata = Protocol.MakeLink_Data("05", "02", PublicVariable.PIID_R.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormalList(sEQOfOAD, data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormalList(cData, ref str2, ref list, ref parseData);
                    }
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多项属性" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                for (int j = 0; j < this.cbArry2.Length; j++)
                {
                    if (((this.cbArry2[j] != null) && this.cbArry2[j].Visible) && this.cbArry2[j].Checked)
                    {
                        num4 = (byte)(num4 + 1);
                        if (parseData[num4 - 1].ToString() == "")
                        {
                            for (int k = numArray[j]; k < numArray[j + 1]; k++)
                            {
                                this.tbArry4[k].Text = parseData[num4 - 1].ToString();
                            }
                        }
                        else
                        {
                            for (int k = numArray[j]; k < numArray[j + 1]; k++)
                            {
                                this.tbArry2[k].Text = (((double)Convert.ToInt32(parseData[num4 - 1].Substring(0, bufferArray2[j][k - numArray[j]] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[j][k - numArray[j]])).ToString();
                                parseData[num4 - 1] = parseData[num4 - 1].Substring(bufferArray2[j][k - numArray[j]] * 2);
                            }
                        }
                    }
                }
            }
        }

        private void tn_多项抄读_Page3()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            List<string> list = new List<string>();
            List<string> parseData = new List<string>();
            byte sEQOfOAD = 0;
            string[] strArray = new string[] { "30050500", "302D0600", "30080500", "30070500", "30090600", "300A0600", "300B0500", "300C0600", "40300200" };
            byte[][] bufferArray3 = new byte[9][];
            byte[] buffer = new byte[2];
            buffer[0] = 4;
            bufferArray3[0] = buffer;
            byte[] buffer2 = new byte[2];
            buffer2[0] = 2;
            bufferArray3[1] = buffer2;
            byte[] buffer3 = new byte[2];
            buffer3[0] = 1;
            bufferArray3[2] = buffer3;
            byte[] buffer4 = new byte[2];
            buffer4[0] = 1;
            bufferArray3[3] = buffer4;
            byte[] buffer5 = new byte[2];
            buffer5[0] = 4;
            bufferArray3[4] = buffer5;
            byte[] buffer6 = new byte[2];
            buffer6[0] = 4;
            bufferArray3[5] = buffer6;
            byte[] buffer7 = new byte[2];
            buffer7[0] = 4;
            bufferArray3[6] = buffer7;
            byte[] buffer8 = new byte[2];
            buffer8[0] = 1;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[] { 1, 1, 1, 1 };
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 4, 1 }, new byte[] { 2, 1 }, new byte[] { 2, 2, 2, 2 } };
            int[] numArray = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 0x10, 20 };
            string data = "";
            for (int i = 0; i < this.cbArry3.Length; i++)
            {
                if (((this.cbArry3[i] != null) && this.cbArry3[i].Visible) && this.cbArry3[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    data = data + strArray[i];
                }
            }
            cData = "";
            parseData.Clear();
            byte num4 = 0;
            string linkdata = "";
            string str5 = "";
            string str6 = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x7d0);
            linkdata = Protocol.MakeLink_Data("05", "02", PublicVariable.PIID_R.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormalList(sEQOfOAD, data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormalList(cData, ref str2, ref list, ref parseData);
                    }
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多项属性" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                for (int j = 0; j < this.cbArry3.Length; j++)
                {
                    if (((this.cbArry3[j] != null) && this.cbArry3[j].Visible) && this.cbArry3[j].Checked)
                    {
                        num4 = (byte)(num4 + 1);
                        if (parseData[num4 - 1].ToString() == "")
                        {
                            for (int k = numArray[j]; k < numArray[j + 1]; k++)
                            {
                                this.tbArry4[k].Text = parseData[num4 - 1].ToString();
                            }
                        }
                        else
                        {
                            for (int k = numArray[j]; k < numArray[j + 1]; k++)
                            {
                                this.tbArry3[k].Text = (((double)Convert.ToInt32(parseData[num4 - 1].Substring(0, bufferArray2[j][k - numArray[j]] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[j][k - numArray[j]])).ToString();
                                parseData[num4 - 1] = parseData[num4 - 1].Substring(bufferArray2[j][k - numArray[j]] * 2);
                            }
                        }
                    }
                }
            }
        }
        private void tn_多项抄读_Page4()
        {
            bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string str2 = "";
            List<string> list = new List<string>();
            List<string> parseData = new List<string>();
            byte sEQOfOAD = 0;
            string[] strArray = new string[] { "300E0600", "300F0600", "30100600", "30110600", "302E0600", "302F0600", "30300600", "80000200", "40040200", "30400600", "40000500" };
            byte[][] bufferArray3 = new byte[11][];
            bufferArray3[0] = new byte[1];
            bufferArray3[1] = new byte[1];
            bufferArray3[2] = new byte[1];
            bufferArray3[3] = new byte[1];
            bufferArray3[4] = new byte[1];
            bufferArray3[5] = new byte[1];
            bufferArray3[6] = new byte[1];
            byte[] buffer8 = new byte[2];
            buffer8[0] = 4;
            bufferArray3[7] = buffer8;
            bufferArray3[8] = new byte[9];
            byte[] buffer10 = new byte[3];
            buffer10[0] = 4;
            buffer10[1] = 2;
            bufferArray3[9] = buffer10;
            bufferArray3[10] = new byte[2];
            byte[][] bufferArray = bufferArray3;
            byte[][] bufferArray2 = new byte[][] { new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 1 }, new byte[] { 4, 2 }, new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 4 }, new byte[] { 4, 2, 1 }, new byte[] { 2, 2 } };
            int[] numArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9, 0x12, 0x15, 0x17 };
            string data = "";
            for (int i = 0; i < this.cbArry4.Length; i++)
            {
                if (((this.cbArry4[i] != null) && this.cbArry4[i].Visible) && this.cbArry4[i].Checked)
                {
                    sEQOfOAD = (byte)(sEQOfOAD + 1);
                    data = data + strArray[i];
                }
            }
            cData = "";
            parseData.Clear();
            byte num4 = 0;
            string linkdata = "";
            string str5 = "";
            string str6 = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(0x5dc);
            linkdata = Protocol.MakeLink_Data("05", "02", PublicVariable.PIID_R.ToString("X2"), sEQOfOAD, data, PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormalList(sEQOfOAD, data, "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormalList(cData, ref str2, ref list, ref parseData);
                    }
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref str5, ref parseData, ref mAC, ref str2, ref str6, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = "多项属性" + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                for (int j = 0; j < this.cbArry4.Length; j++)
                {
                    if (((this.cbArry4[j] != null) && this.cbArry4[j].Visible) && this.cbArry4[j].Checked)
                    {
                        num4 = (byte)(num4 + 1);
                        if (parseData[num4 - 1].ToString() == "")
                        {
                            for (int k = numArray[j]; k < numArray[j + 1]; k++)
                            {
                                this.tbArry4[k].Text = parseData[num4 - 1].ToString();
                            }
                        }
                        else
                        {
                            for (int k = numArray[j]; k < numArray[j + 1]; k++)
                            {
                                this.tbArry4[k].Text = (((double)Convert.ToInt32(parseData[num4 - 1].Substring(0, bufferArray2[j][k - numArray[j]] * 2), 10)) / Math.Pow(10.0, (double)bufferArray[j][k - numArray[j]])).ToString();
                                parseData[num4 - 1] = parseData[num4 - 1].Substring(bufferArray2[j][k - numArray[j]] * 2);
                            }
                        }
                    }
                }
            }
        }

        private void chk_24_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_24.Checked)
            {
                for (int i = 0; i < this.jiesuanArray.Length; i++)
                {
                    if ((this.jiesuanArray[i] != null) && this.jiesuanArray[i].Visible)
                    {
                        this.jiesuanArray[i].Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.jiesuanArray.Length; i++)
                {
                    if ((this.jiesuanArray[i] != null) && this.jiesuanArray[i].Visible)
                    {
                        this.jiesuanArray[i].Checked = false;
                    }
                }
            }
        }

    }
}
