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
    public partial class LadderAndPrice : Form
    {
        private FollowRepoartAndTimeTag followForm;
        private CheckBox[] chkArray = new CheckBox[10];
        private TextBox[] txtArray = new TextBox[0x10];
        public LadderAndPrice(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
            this.InitArray();
        }
        private void InitArray()
        {
            this.chkArray[0] = this.cbx_0;
            this.chkArray[1] = this.cbx_1;
            this.chkArray[2] = this.cbx_2;
            this.chkArray[3] = this.cbx_3;
            this.chkArray[4] = this.cbx_4;
            this.chkArray[5] = this.cbx_5;
            this.chkArray[6] = this.cbx_6;
            this.chkArray[7] = this.cbx_7;
            this.chkArray[8] = this.cbx_8;
            this.chkArray[9] = this.cbx_9;
            this.txtArray[0] = this.txt_0;
            this.txtArray[1] = this.txt_1;
            this.txtArray[2] = this.txt_2;
            this.txtArray[3] = this.txt_3;
            this.txtArray[4] = this.txt_4;
            this.txtArray[5] = this.txt_5;
            this.txtArray[6] = this.txt_6;
            this.txtArray[7] = this.txt_7;
            this.txtArray[8] = this.txt_8;
            this.txtArray[9] = this.txt_9;
            this.txtArray[10] = this.txt_10;
            this.txtArray[11] = this.txt_11;
            this.txtArray[12] = this.txt_12;
            this.txtArray[13] = this.txt_13;
            this.txtArray[14] = this.txt_14;
            this.txtArray[15] = this.txt_15;
        }

        private void tsb_单项抄读_Click(object sender, EventArgs e)
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
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    string[] strArray = new string[] { "400D0200", "401F0200", "40200200", "40210200", "201A0200", "201B0200", "201C0200", "202C0200", "202D0200", "202E0200" };
                    byte[][] bufferArray3 = new byte[10][];
                    bufferArray3[0] = new byte[1];
                    bufferArray3[1] = new byte[] { 2, 2, 2 };
                    bufferArray3[2] = new byte[] { 2, 2 };
                    bufferArray3[3] = new byte[] { 2, 2, 2 };
                    bufferArray3[4] = new byte[] { 4 };
                    bufferArray3[5] = new byte[] { 4 };
                    bufferArray3[6] = new byte[] { 4 };
                    byte[] buffer6 = new byte[2];
                    buffer6[0] = 2;
                    bufferArray3[7] = buffer6;
                    bufferArray3[8] = new byte[] { 2 };
                    bufferArray3[9] = new byte[] { 2 };
                    byte[][] bufferArray = bufferArray3;
                    byte[][] bufferArray2 = new byte[][] { new byte[] { 1 }, new byte[] { 4, 4, 4 }, new byte[] { 4, 4 }, new byte[] { 4, 4, 4 }, new byte[] { 4 }, new byte[] { 4 }, new byte[] { 4 }, new byte[] { 4, 4 }, new byte[] { 4 }, new byte[] { 4 } };
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        int num2;
                        int num3;
                        int num4;
                        int num5;
                        cData = "";
                        parseData = "";
                        list.Clear();
                        if (((this.chkArray[i] == null) || !this.chkArray[i].Checked) || !this.chkArray[i].Visible)
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
                        PublicVariable.Info = this.chkArray[i].Text + (flag ? "读取成功" : "读取失败--") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
                        PublicVariable.Info_Color = flag ? "Blue" : "Red";
                        if (flag)
                        {
                            switch (i)
                            {
                                case 0:
                                    this.txtArray[0].Text = parseData.Substring(0, 2);
                                    break;

                                case 1:
                                    num2 = 1;
                                    goto Label_04AD;

                                case 2:
                                    num3 = 4;
                                    goto Label_0508;

                                case 3:
                                    num4 = 6;
                                    goto Label_0563;

                                case 4:
                                    this.txtArray[9].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][0] * 2), bufferArray[i][0]);
                                    parseData = parseData.Substring(bufferArray2[i][0]);
                                    break;

                                case 5:
                                    this.txtArray[10].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][0] * 2), bufferArray[i][0]);
                                    parseData = parseData.Substring(bufferArray2[i][0] * 2);
                                    break;

                                case 6:
                                    this.txtArray[11].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][0] * 2), bufferArray[i][0]);
                                    parseData = parseData.Substring(bufferArray2[i][0] * 2);
                                    break;

                                case 7:
                                    num5 = 12;
                                    goto Label_0687;

                                case 8:
                                    this.txtArray[14].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][0] * 2), bufferArray[i][0]);
                                    parseData = parseData.Substring(bufferArray2[i][0] * 2);
                                    break;

                                case 9:
                                    this.txtArray[15].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][0] * 2), bufferArray[i][0]);
                                    parseData = parseData.Substring(bufferArray2[i][0] * 2);
                                    break;
                            }
                        }
                        goto Label_070B;
                    Label_0461:
                        this.txtArray[num2].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][num2 - 1] * 2), bufferArray[i][num2 - 1]);
                        parseData = parseData.Substring(bufferArray2[i][num2 - 1] * 2);
                        num2++;
                    Label_04AD:
                        if (num2 < 4)
                        {
                            goto Label_0461;
                        }
                        goto Label_070B;
                    Label_04BC:
                        this.txtArray[num3].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][num3 - 4] * 2), bufferArray[i][num3 - 4]);
                        parseData = parseData.Substring(bufferArray2[i][num3 - 4] * 2);
                        num3++;
                    Label_0508:
                        if (num3 < 6)
                        {
                            goto Label_04BC;
                        }
                        goto Label_070B;
                    Label_0517:
                        this.txtArray[num4].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][num4 - 6] * 2), bufferArray[i][num4 - 6]);
                        parseData = parseData.Substring(bufferArray2[i][num4 - 6] * 2);
                        num4++;
                    Label_0563:
                        if (num4 < 9)
                        {
                            goto Label_0517;
                        }
                        goto Label_070B;
                    Label_0638:
                        this.txtArray[num5].Text = PublicVariable.GetFloatstrFromBCDStr(parseData.Substring(0, bufferArray2[i][num5 - 12] * 2), bufferArray[i][num5 - 12]);
                        parseData = parseData.Substring(bufferArray2[i][num5 - 12] * 2);
                        num5++;
                    Label_0687:
                        if (num5 < 14)
                        {
                            goto Label_0638;
                        }
                    Label_070B:
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

        private void tsb_单项设置_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PublicVariable.IsReading)
                {
                    PublicVariable.IsReading = true;
                    bool flag = false;
                    string cData = "";
                    bool splitFlag = false;
                    string data = "";
                    List<string> frameData = new List<string>();
                    string[] strArray = new string[] { "400D0200", "401F0200", "40200200", "40210200" };
                    byte[][] bufferArray3 = new byte[4][];
                    bufferArray3[0] = new byte[1];
                    bufferArray3[1] = new byte[] { 2, 2, 2 };
                    bufferArray3[2] = new byte[] { 2, 2 };
                    bufferArray3[3] = new byte[] { 2, 2, 2 };
                    byte[][] bufferArray = bufferArray3;
                    byte[][] bufferArray2 = new byte[][] { new byte[] { 1 }, new byte[] { 4, 4, 4 }, new byte[] { 4, 4 }, new byte[] { 4, 4, 4 } };
                    string[] strArray2 = new string[] { "17", "02060606", "020606", "02060606" };
                    string[] strArray3 = new string[] { "01", "03040404", "020404", "03040404" };
                    int[] numArray = new int[] { 0, 1, 4, 6, 9 };
                    string str3 = "";
                    string str4 = "";
                    string parseData = "";
                    List<string> list2 = new List<string>();
                    string linkdata = "";
                    string mAC = "";
                    StringBuilder cOutData = new StringBuilder(200);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (((this.chkArray[i] == null) || !this.chkArray[i].Visible) || !this.chkArray[i].Checked)
                        {
                            continue;
                        }
                        data = "";
                        for (int j = numArray[i]; j < numArray[i + 1]; j++)
                        {
                            double num3 = Convert.ToDouble(this.txtArray[j].Text.Trim().PadLeft(bufferArray2[i][j - numArray[i]] * 2, '0')) * Math.Pow(10.0, (double)bufferArray[i][j - numArray[i]]);
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
                        PublicVariable.Info = this.chkArray[i].Text + (flag ? "设置成功" : "设置失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
    }
}
