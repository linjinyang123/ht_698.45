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
    public partial class feesCharge : Form
    {
        private FollowRepoartAndTimeTag followForm;
        public feesCharge(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }

        private void btn_Control_Click(object sender, EventArgs e)
        {
             bool flag = false;
            string cData = "";
            bool splitFlag = false;
            string data = "";
            List<string> frameData = new List<string>();
            string dataType = "";
            string dataLen = "";
            string timeText = "";
            string str6 = "";
            string str8 = "";
            string str9 = "";
            string parseData = "";
            List<string> list2 = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            data = "";
            cData = "";
            frameData.Clear();
            switch (this.cbx_Control.SelectedIndex)
            {
                case 0:
                    dataType = "010281171803";
                    dataLen = "010404010201";
                    str9 = "80008100";
                    data = "F20502" + Convert.ToByte(this.txt_继电器编号.Text).ToString("X2") + Convert.ToByte(this.txt_告警延时.Text).ToString("X2") + Convert.ToInt16(this.txt_限电延时.Text).ToString("X4") + ((this.cbx_合闸方式.SelectedIndex == 0) ? "01" : "00");
                    break;

                case 1:
                    dataType = "01028122";
                    dataLen = "01020401";
                    str9 = "80008200";
                    data = "F20502" + Convert.ToByte(this.txt_继电器编号.Text).ToString("X2") + ((this.cbx_合闸方式.SelectedIndex == 0) ? "01" : "00");
                    break;

                case 2:
                    dataType = "00";
                    dataLen = "00";
                    str9 = "80007F00";
                    data = "";
                    break;

                case 3:
                    dataType = "00";
                    dataLen = "00";
                    str9 = "80008000";
                    data = "";
                    break;

                case 4:
                    dataType = "00";
                    dataLen = "00";
                    str9 = "80017F00";
                    data = "";
                    break;

                case 5:
                    dataType = "00";
                    dataLen = "00";
                    str9 = "80018000";
                    data = "";
                    break;
            }
            cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
            str6 = this.dtp_ValidTime.Value.ToString("yyyyMMddHHmmss");
            timeText = string.Format("{0:X4}",Convert.ToInt32(str6.Substring(0, 4)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(4, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(6, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(8, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(10, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(12, 2))) + this.cmb_间隔单位.SelectedIndex.ToString("X2") + Convert.ToInt16(this.tbx_间隔.Text).ToString("X4");
            linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), str9 + cData, timeText);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str9, cData, timeText, ref splitFlag);
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str8, ref str9, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str8, ref str9, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = this.cbx_Control.Text + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
            }
        }

        private void btn_保电状态_Click(object sender, EventArgs e)
        {
            string str7;
            bool flag = false;
            bool splitFlag = false;
            string cData = "";
            string parseData = "";
            string str3 = "";
            string str4 = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_W.ToString("X2"), "80010200", PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormal("80010200", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormal(cData, ref str3, ref str4, ref parseData);
                    }
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
            PublicVariable.Info = "保电状态" + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag && ((str7 = parseData) != null))
            {
                if (str7 == "00")
                {
                    this.txt_保电状态.Text = "0 未保电";
                }
                else if (str7 == "01")
                {
                    this.txt_保电状态.Text = "1 保电";
                }
                else if (str7 == "02")
                {
                    this.txt_保电状态.Text = "2 自动保电";
                }
            }
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

        private void btn_读错误状态字_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool splitFlag = false;
            string cData = "";
            string parseData = "";
            string str3 = "";
            string str4 = "";
            string[] strArray = new string[] { "电表挂起", "保留", "密码错误/未授权", "安全认证超时", "保留", "跳闸失败(保电)", "跳闸自动恢复命令执行失败(保电)", "跳闸自动恢复时间无效", "跳闸自动恢复命令执行失败(跳闸)", "保留", "保留", "保留", "保留", "保留", "保留", "保留" };
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_W.ToString("X2"), "20410200", PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormal("20410200", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormal(cData, ref str3, ref str4, ref parseData);
                    }
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
            PublicVariable.Info = "读错误状态字" + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                int num = parseData.Length / 2;
                string str7 = "";
                string str8 = "";
                for (int i = 0; i < num; i++)
                {
                    str7 = str7 + Convert.ToString(Convert.ToByte(parseData.Substring(2 * i, 2), 0x10), 2).PadLeft(8, '0');
                }
                for (int j = 0; j < str7.Length; j++)
                {
                    str8 = str8 + ((str7[j] == '1') ? ("控制命令状态字： " + str7 + "\r\n状态内容： bit " + j.ToString() + "=1 " + strArray[j] + "\r\n------------------------\r\n") : "");
                }
                this.txt_状态字显示.Text = this.txt_状态字显示.Text + ((str8 == "") ? "没有状态字置位 ------------------------\r\n" : str8);
            }
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

        private void btn_读命令状态_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool splitFlag = false;
            string cData = "";
            string parseData = "";
            string str3 = "";
            string str4 = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_W.ToString("X2"), "80000500", PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormal("80000500", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormal(cData, ref str3, ref str4, ref parseData);
                    }
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
            PublicVariable.Info = "继电器命令状态" + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                if ((Convert.ToByte(parseData, 0x10) & 0x80) == 0x80)
                {
                    this.txt_继电器命令状态.Text = "1 跳闸命令";
                }
                else
                {
                    this.txt_继电器命令状态.Text = "0 合闸命令";
                }
            }
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

        private void btn_读执行状态字_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool splitFlag = false;
            string cData = "";
            string parseData = "";
            string str3 = "";
            string str4 = "";
            string[] strArray = new string[] { "直接合闸", "允许合闸", "直接跳闸", "延时跳闸(跳闸延时时间)", "跳闸自动恢复", "延时跳闸(大电流)", "保留", "保留", "保电", "保电解除", "报警", "报警解除", "保留", "保留", "保留", "保留" };
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_W.ToString("X2"), "20400200", PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormal("20400200", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormal(cData, ref str3, ref str4, ref parseData);
                    }
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
            PublicVariable.Info = "读执行状态字" + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                int num = parseData.Length / 2;
                string str7 = "";
                string str8 = "";
                for (int i = 0; i < num; i++)
                {
                    str7 = str7 + Convert.ToString(Convert.ToByte(parseData.Substring(2 * i, 2), 0x10), 2).PadLeft(8, '0');
                }
                for (int j = 0; j < str7.Length; j++)
                {
                    str8 = str8 + ((str7[j] == '1') ? ("控制命令状态字： " + str7 + "\r\n状态内容： bit " + j.ToString() + "=1 " + strArray[j] + "\r\n------------------------\r\n") : "");
                }
                this.txt_状态字显示.Text = this.txt_状态字显示.Text + ((str8 == "") ? "没有状态字置位 ------------------------\r\n" : str8);
            }
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

        private void btn_告警状态_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool splitFlag = false;
            string cData = "";
            string parseData = "";
            string str3 = "";
            string str4 = "";
            List<string> list = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            linkdata = Protocol.MakeLink_Data("05", "01", PublicVariable.PIID_W.ToString("X2"), "80000400", PublicVariable.TimeTag);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.GetRequestNormal("80000400", "43", PublicVariable.Address, PublicVariable.Client_Add, ref cData, PublicVariable.TimeTag, ref splitFlag);
                    if (flag)
                    {
                        flag = Protocol.GetResponseNormal(cData, ref str3, ref str4, ref parseData);
                    }
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
            PublicVariable.Info = "告警状态" + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
            PublicVariable.Info_Color = flag ? "Blue" : "Red";
            if (flag)
            {
                if ((Convert.ToByte(parseData, 0x10) & 0x80) == 0x80)
                {
                    this.txt_告警状态.Text = "1 告警状态";
                }
                else
                {
                    this.txt_告警状态.Text = "0 未告警";
                }
            }
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

        private void btn_明文合闸_Click(object sender, EventArgs e)
        {
            string cData = "";
            string dataType = "0102812210";
            string dataLen = "0103040104";
            string str4 = "80008300";
            string data = "F20502" + Convert.ToByte(this.txt_继电器编号.Text).ToString("X2") + ((this.cbx_合闸方式.SelectedIndex == 0) ? "01" : "00") + this.txt_密码.Text.PadLeft(8, '0');
            string str6 = "";
            string timeText = "";
            List<string> frameData = new List<string>();
            bool flag = false;
            bool splitFlag = false;
            string str9 = "";
            string parseData = "";
            List<string> list2 = new List<string>();
            string linkdata = "";
            string mAC = "";
            StringBuilder cOutData = new StringBuilder(200);
            cData = Protocol.From_Type_GetData(ref dataType, ref dataLen, ref data, ref frameData);
            str6 = this.dtp_ValidTime.Value.ToString("yyyyMMddHHmmss");
             timeText = string.Format("{0:X4}",Convert.ToInt32(str6.Substring(0, 4)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(4, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(6, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(8, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(10, 2)))+string.Format("{0:X2}",Convert.ToInt16(str6.Substring(12, 2))) + this.cmb_间隔单位.SelectedIndex.ToString("X2") + Convert.ToInt16(this.tbx_间隔.Text).ToString("X4");
            //timeText = ($"{Convert.ToInt32(str6.Substring(0, 4)):X4}" + $"{Convert.ToInt16(str6.Substring(4, 2)):X2}" + $"{Convert.ToInt16(str6.Substring(6, 2)):X2}" + $"{Convert.ToInt16(str6.Substring(8, 2)):X2}" + $"{Convert.ToInt16(str6.Substring(10, 2)):X2}" + $"{Convert.ToInt16(str6.Substring(12, 2)):X2}") + this.cmb_间隔单位.SelectedIndex.ToString("X2") + Convert.ToInt16(this.tbx_间隔.Text).ToString("X4");
            linkdata = Protocol.MakeLink_Data("07", "01", PublicVariable.PIID_W.ToString("X2"), str4 + cData, timeText);
            switch (PublicVariable.link_Math)
            {
                case Link_Math.纯明文操作:
                    flag = Protocol.ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, str4, cData, timeText, ref splitFlag);
                    break;

                case Link_Math.明文_RN:
                    flag = Protocol.Math_明文_RN("00", "01", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.明文_SID_MAC:
                    flag = Protocol.Math_明文_SIDMAC("00", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID:
                    flag = Protocol.Math_密文_SID("01", "03", ref linkdata, ref parseData, ref list2, ref mAC, ref str9, ref str4, ref splitFlag, ref cOutData);
                    break;

                case Link_Math.密文_SID_MAC:
                    flag = Protocol.Math_密文_SID_MAC("01", "00", ref linkdata, ref parseData, ref list2, ref mAC, ref str9, ref str4, ref splitFlag, ref cOutData);
                    break;
            }
            PublicVariable.Info = this.cbx_Control.Text + (flag ? "成功" : "失败") + PublicVariable.DARInfo + PublicVariable.MAC_Info;
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
            }
        }

        private void cbx_Control_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbx_Control.SelectedIndex == 1)
            {
                this.txt_继电器编号.Enabled = true;
                this.btn_明文合闸.Visible = true;
                this.cbx_合闸方式.Enabled = true;
                this.label_密码.Visible = true;
                this.gbx_明文合闸.Visible = true;
                this.txt_密码.Visible = true;
                this.txt_告警延时.Enabled = false;
                this.txt_限电延时.Enabled = false;
            }
            else if (this.cbx_Control.SelectedIndex == 0)
            {
                this.txt_继电器编号.Enabled = true;
                this.btn_明文合闸.Visible = false;
                this.label_密码.Visible = false;
                this.txt_密码.Visible = false;
                this.gbx_明文合闸.Visible = false;
                this.txt_告警延时.Enabled = true;
                this.txt_限电延时.Enabled = true;
                this.cbx_合闸方式.Enabled = true;
            }
            else
            {
                this.txt_继电器编号.Enabled = false;
                this.btn_明文合闸.Visible = false;
                this.label_密码.Visible = false;
                this.txt_密码.Visible = false;
                this.gbx_明文合闸.Visible = false;
                this.txt_告警延时.Enabled = false;
                this.txt_限电延时.Enabled = false;
                this.cbx_合闸方式.Enabled = false;
            }
        }

        private void feesCharge_Load(object sender, EventArgs e)
        {
            this.cbx_Control.SelectedIndex = 0;
            this.cbx_合闸方式.SelectedIndex = 0;
            this.cmb_间隔单位.SelectedIndex = 1;
        }

        private void txt_状态字显示_DoubleClick(object sender, EventArgs e)
        {
            this.txt_状态字显示.Text = "";
        }

        private void txt_状态字显示_TextChanged(object sender, EventArgs e)
        {
            this.txt_状态字显示.SelectionStart = this.txt_状态字显示.Text.Length;
            this.txt_状态字显示.ScrollToCaret();
        }
    }
}
