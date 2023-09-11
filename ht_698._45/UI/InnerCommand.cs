using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ht_698._45.UI
{
    public partial class InnerCommand : Form
    {
        private short intCtrlCodeIndex;
        private byte[] RespondBytes;
        public InnerCommand(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        public static string CheckSum(string DataFrame)
        {
            byte num = 0;
            int num2 = 0;
            byte[] buffer = new byte[SerialPortUtil.HexToByte(DataFrame).Length];
            buffer = SerialPortUtil.HexToByte(DataFrame);
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 0x68)
                {
                    num2 = i;
                    break;
                }
            }
            for (int j = num2; j < buffer.Length; j++)
            {
                num = (byte)(buffer[j] + num);
            }
            return num.ToString("X16").Substring(14, 2);
        }

        private void btn_参数总清_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1A 04 BB 66 B6 B9 ";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "参数总清" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_初始化_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1F 04 46 47 87 B3";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if(PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "电表初始化" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_初始化flash_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 14 0D 44 33 33 41 35 33 33 33 34 33 33 33 33";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "初始化flash" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_固有化_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1A 04 BB 55 B6 B9 ";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "固有化参数" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_关闭明文拉合闸_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 14 0D 13 44 33 37 35 33 33 33 AB 89 67 45 33";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "关闭明文拉合闸" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_进厂_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1F 03 42 88 32";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "进入厂内" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_进厂盛帆_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1A 04 9A AB B6 B9 ";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "进入厂内" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_拉闸使能_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 14 0D 13 44 33 37 35 33 33 33 AB 89 67 45 DD ";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "使能明文拉合闸" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }
      
        private void btn_内部版本_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1E 04 38 21 21 71";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                string str3 = "";
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "内部版本" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                    if (flag2)
                    {   //固定33位   
                        str3 = PublicVariable.ASCIIHexstrTostr(PublicVariable.BackString(dataRegion).Substring(8));
                        this.txt_内部版本.Text = str3.Substring(0,33);
                    }
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info_Color = "Red";
                PublicVariable.Info = exception.Message;
            }
        }

        private void btn_退厂_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1F 03 42 DD 32";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "退出厂内" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_退出盛帆_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1A 04 88 99 B6 B9 ";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "退出厂内" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_校表总清_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 14 10 32 F3 F0 37 35 33 33 33 34 33 33 33 32 32 32 32 ";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "校表总清" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_中惠退厂_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 14 0D 37 35 33 41 37 33 33 33 34 33 33 33 33";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "退出厂内" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void btn_总清_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 1A 04 BA A5 B6 B9 ";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "厂内总清" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 04 0D 50 F4 35 33 33 33 32 32 32 32 32 32 32";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "XX_退出厂内" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                while (PublicVariable.ChangedFlag)
                {
                    Thread.Sleep(300);
                    Application.DoEvents();
                }
                PublicVariable.BeginRecState = false;
                string dataFrame = "68" + PublicVariable.BackString(PublicVariable.Address.Substring(2, 12)) + "68 04 26 4C F4 35 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33 33";
                dataFrame = dataFrame + CheckSum(dataFrame) + "16";
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(dataFrame));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(dataFrame));
                PublicVariable.BeginRecState = true;
                CommParam.comPort.comPort_DataReceived645();
                string dataRegion = "";
                bool bExtend = false;
                if (PublicVariable.RecDataString.Length > 0)
                {
                    dataRegion = "";
                    bool flag2 = CommParam.comPort.RecIsProtocol_内部(PublicVariable.RecDataString, ref dataRegion, ref bExtend);
                    PublicVariable.ChangedFlag = true;
                    PublicVariable.Info = "XX_进入厂内" + (flag2 ? "成功" : "失败--");
                    PublicVariable.Info_Color = flag2 ? "Blue" : "Red";
                }
                PublicVariable.ChangedFlag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
            }
        }
    }
}
