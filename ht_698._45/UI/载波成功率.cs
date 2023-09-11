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
    public partial class 载波成功率 : Form
    {
        private TextBox[] txtArray_地址 = new TextBox[12];
        private TextBox[] txtArray_成功率 = new TextBox[12];
        private CheckBox[] chkArray = new CheckBox[12];
        private int[] Array_成功次数 = new int[12];
        public 载波成功率(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void btn_抄读_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                if (!PublicVariable.IsReading)
                {
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string str2 = "";
                    string str3 = "";
                    string parseData = "";
                    int num = Convert.ToInt32(this.txt_抄读次数.Text, 10);
                    PublicVariable.IsReading = true;
                    for (int i = 0; i < 12; i++)
                    {
                        if (this.chkArray[i].Checked)
                        {
                            list.Add(this.txtArray_地址[i].Text.PadLeft(12, '0'));
                        }
                        this.Array_成功次数[i] = 0;
                    }
                    for (int j = 0; j < num; j++)
                    {
                        if (!PublicVariable.IsReading)
                        {
                            break;
                        }
                        this.txt_抄读次数.Text = ((num - j) - 1).ToString();
                        for (int m = 0; m < list.Count; m++)
                        {
                            cData = "";
                            flag = Protocol.GetRequestNormal("00100200", "43", "05" + list[m], PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                            if (flag)
                            {
                                this.Array_成功次数[m]++;
                                flag = Protocol.GetResponseNormal(cData, ref str2, ref str3, ref parseData);
                            }
                            PublicVariable.Info = list[m] + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                            PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        }
                    }
                    for (int k = 0; k < list.Count; k++)
                    {
                        this.txtArray_成功率[k].Text = (((float)this.Array_成功次数[k]) / ((float)num)).ToString("#.##%");
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

        private void btn_停止_Click(object sender, EventArgs e)
        {
            PublicVariable.IsReading = false;
        }
        private void init()
        {
            this.txtArray_地址[0] = this.txt_地址_0;
            this.txtArray_地址[1] = this.txt_地址_1;
            this.txtArray_地址[2] = this.txt_地址_2;
            this.txtArray_地址[3] = this.txt_地址_3;
            this.txtArray_地址[4] = this.txt_地址_4;
            this.txtArray_地址[5] = this.txt_地址_5;
            this.txtArray_地址[6] = this.txt_地址_6;
            this.txtArray_地址[7] = this.txt_地址_7;
            this.txtArray_地址[8] = this.txt_地址_8;
            this.txtArray_地址[9] = this.txt_地址_9;
            this.txtArray_地址[10] = this.txt_地址_10;
            this.txtArray_地址[11] = this.txt_地址_11;
            this.txtArray_成功率[0] = this.txt_成功率_0;
            this.txtArray_成功率[1] = this.txt_成功率_1;
            this.txtArray_成功率[2] = this.txt_成功率_2;
            this.txtArray_成功率[3] = this.txt_成功率_3;
            this.txtArray_成功率[4] = this.txt_成功率_4;
            this.txtArray_成功率[5] = this.txt_成功率_5;
            this.txtArray_成功率[6] = this.txt_成功率_6;
            this.txtArray_成功率[7] = this.txt_成功率_7;
            this.txtArray_成功率[8] = this.txt_成功率_8;
            this.txtArray_成功率[9] = this.txt_成功率_9;
            this.txtArray_成功率[10] = this.txt_成功率_10;
            this.txtArray_成功率[11] = this.txt_成功率_11;
            this.chkArray[0] = this.chk_0;
            this.chkArray[1] = this.chk_1;
            this.chkArray[2] = this.chk_2;
            this.chkArray[3] = this.chk_3;
            this.chkArray[4] = this.chk_4;
            this.chkArray[5] = this.chk_5;
            this.chkArray[6] = this.chk_6;
            this.chkArray[7] = this.chk_7;
            this.chkArray[8] = this.chk_8;
            this.chkArray[9] = this.chk_9;
            this.chkArray[10] = this.chk_10;
            this.chkArray[11] = this.chk_11;
            for (int i = 0; i < 12; i++)
            {
                this.Array_成功次数[i] = 0;
            }
        }

        private void 载波成功率_Load(object sender, EventArgs e)
        {
            this.init();
        }
    }
}
