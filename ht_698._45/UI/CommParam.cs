using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ht_698._45.UI
{
    public partial class CommParam : Form
    {
        public static SerialPortUtil comPort = new SerialPortUtil();
        private IniFile iniFile = new IniFile(Application.StartupPath + @"\Comm_Info.ini");
        private string[] set = new string[4];
        private string time = "";
        private string com = "";
        public CommParam(Form_Main parent)
        {
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        public void SaveInfoToIni()
        {
            try
            {
                this.iniFile.IniWriteValue("Comm", "com", this.comboBoxSerialName.SelectedItem == null ? "" : this.comboBoxSerialName.SelectedItem.ToString());
                this.iniFile.IniWriteValue("Comm", "set", PublicVariable.ComInfo);
                this.iniFile.IniWriteValue("Comm", "time", this.comboBoxDelayTime.SelectedItem == null ? "" : this.comboBoxDelayTime.SelectedItem.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveInfoToIni();
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                comPort.PortName = this.comboBoxSerialName.SelectedItem == null ? "" : this.comboBoxSerialName.SelectedItem.ToString();
                comPort.BautRate = (SerialPortBaudRates)Convert.ToInt32(this.comboBoxBaudRate.SelectedItem);
                comPort.Parity = (Parity)this.comboBoxParity.SelectedIndex;
                comPort.DataBits = (SerialPortDatabits)Convert.ToInt32(this.comboBoxDataBits.SelectedItem);
                comPort.StopBits = (StopBits)this.comboBoxStopBits.SelectedIndex;
                comPort.RecDelayTime = (DataRecDelayTime)Convert.ToInt32(this.comboBoxDelayTime.SelectedItem);
                PublicVariable.ComName = comPort.PortName;
                PublicVariable.ComInfo = ((int)comPort.BautRate).ToString() + "," + Convert.ToString(comPort.Parity) + "," + ((int)comPort.DataBits).ToString() + "," + ((int)comPort.StopBits).ToString();
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void ComClose()
        {
            if (comPort.IsOpen)
            {
                try
                {
                    comPort.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void CommParam_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.SaveInfoToIni();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void ComOpen()
        {
            if (!comPort.IsOpen)
            {
                try
                {
                    comPort.OpenPort();
                }
                catch (SystemException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                bool isOpen = comPort.IsOpen;
            }
        }
        /// <summary>
        /// 接收帧字节转十六进制
        /// </summary>
        /// <param name="ex"></param>
        public void comPort_DataReceived(DataReceivedEventArgs ex)
        {
            PublicVariable.RecDataString = SerialPortUtil.ByteToHex(ex.DataRecv);
            PublicVariable.ChangedFlag = true;
        }

        private void GetFromIni()
        {
            try
            {
                string str = "";
                str = this.iniFile.IniReadValue("Comm", "com");
                if (str == "")
                {
                    str = "COM1";
                }
                this.com = str;
                this.comboBoxSerialName.Text = this.com;
                str = this.iniFile.IniReadValue("Comm", "time");
                if (str == "")
                {
                    str = "1000";
                }
                this.time = str;
                this.comboBoxDelayTime.Text = this.time;
                str = this.iniFile.IniReadValue("Comm", "set");
                if (str == "")
                {
                    str = "2400,Even,8,1";
                }
                this.set = str.Split(new char[] { ',' });
                this.comboBoxBaudRate.Text = this.set[0];
                this.comboBoxDataBits.Text = this.set[2];
                this.comboBoxStopBits.Text = this.set[3];
                this.comboBoxParity.Text = this.set[1];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CommParam_Load(object sender, EventArgs e)
        {
            SerialPortUtil.SetPortNameValues(this.comboBoxSerialName);
            if (this.comboBoxSerialName.Items.Count == 0)
            {
                MessageBox.Show("没有发现串口，请检查！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            SerialPortUtil.SetBauRateValues(this.comboBoxBaudRate);
            SerialPortUtil.SetParityValues(this.comboBoxParity);
            SerialPortUtil.SetDataBitsValues(this.comboBoxDataBits);
            SerialPortUtil.SetStopBitValues(this.comboBoxStopBits);
            SerialPortUtil.SetDateRecDelayTime(this.comboBoxDelayTime);
            if (this.comboBoxSerialName.SelectedIndex!=-1)
            this.comboBoxSerialName.SelectedIndex = 0;
            this.comboBoxBaudRate.SelectedIndex = 2;
            this.comboBoxDataBits.SelectedIndex = 3;
            this.comboBoxParity.SelectedIndex = 2;
            this.comboBoxStopBits.SelectedIndex = 1;
            this.comboBoxDelayTime.SelectedIndex = 4;
            this.comboBoxSerialName.SelectedIndexChanged += delegate(object obj, EventArgs ex)
            {
                if (comPort.IsOpen)
                {
                    this.ComClose();
                    comPort.PortName = this.comboBoxSerialName.SelectedItem.ToString();
                    PublicVariable.ComName = comPort.PortName;
                    this.ComOpen();
                }
                else
                {
                    comPort.PortName = this.comboBoxSerialName.SelectedItem.ToString();
                    PublicVariable.ComName = comPort.PortName;
                }
            };
            this.comboBoxBaudRate.SelectedIndexChanged += delegate(object obj, EventArgs ex)
            {
                if (comPort.IsOpen)
                {
                    this.ComClose();
                    comPort.BautRate = (SerialPortBaudRates)Convert.ToInt32(this.comboBoxBaudRate.SelectedItem);
                    PublicVariable.ComInfo = ((int)comPort.BautRate).ToString() + "," + Convert.ToString(comPort.Parity) + "," + ((int)comPort.DataBits).ToString() + "," + ((int)comPort.StopBits).ToString();
                    this.ComOpen();
                }
                else
                {
                    comPort.BautRate = (SerialPortBaudRates)Convert.ToInt32(this.comboBoxBaudRate.SelectedItem);
                    PublicVariable.ComInfo = ((int)comPort.BautRate).ToString() + "," + Convert.ToString(comPort.Parity) + "," + ((int)comPort.DataBits).ToString() + "," + ((int)comPort.StopBits).ToString();
                }
            };
            this.comboBoxParity.SelectedIndexChanged += delegate(object obj, EventArgs ex)
            {
                if (comPort.IsOpen)
                {
                    this.ComClose();
                    comPort.Parity = (Parity)this.comboBoxParity.SelectedIndex;
                    PublicVariable.ComInfo = ((int)comPort.BautRate).ToString() + "," + Convert.ToString(comPort.Parity) + "," + ((int)comPort.DataBits).ToString() + "," + ((int)comPort.StopBits).ToString();
                    this.ComOpen();
                }
                else
                {
                    comPort.Parity = (Parity)this.comboBoxParity.SelectedIndex;
                    PublicVariable.ComInfo = ((int)comPort.BautRate).ToString() + "," + Convert.ToString(comPort.Parity) + "," + ((int)comPort.DataBits).ToString() + "," + ((int)comPort.StopBits).ToString();
                }
            };
            this.comboBoxDataBits.SelectedIndexChanged += delegate(object obj, EventArgs ex)
            {
                if (comPort.IsOpen)
                {
                    this.ComClose();
                    comPort.DataBits = (SerialPortDatabits)Convert.ToInt32(this.comboBoxDataBits.SelectedItem);
                    PublicVariable.ComInfo = ((int)comPort.BautRate).ToString() + "," + Convert.ToString(comPort.Parity) + "," + ((int)comPort.DataBits).ToString() + "," + ((int)comPort.StopBits).ToString();
                    this.ComOpen();
                }
                else
                {
                    comPort.DataBits = (SerialPortDatabits)Convert.ToInt32(this.comboBoxDataBits.SelectedItem);
                    PublicVariable.ComInfo = ((int)comPort.BautRate).ToString() + "," + Convert.ToString(comPort.Parity) + "," + ((int)comPort.DataBits).ToString() + "," + ((int)comPort.StopBits).ToString();
                }
            };
            this.comboBoxStopBits.SelectedIndexChanged += delegate(object obj, EventArgs ex)
            {
                if (comPort.IsOpen)
                {
                    this.ComClose();
                    comPort.StopBits = (StopBits)this.comboBoxStopBits.SelectedIndex;
                    this.ComOpen();
                }
                else
                {
                    comPort.StopBits = (StopBits)this.comboBoxStopBits.SelectedIndex;
                }
            };
            this.comboBoxDelayTime.SelectedIndexChanged += delegate(object obj, EventArgs ex)
            {
                if (comPort.IsOpen)
                {
                    this.ComClose();
                    comPort.RecDelayTime = (DataRecDelayTime)Convert.ToInt32(this.comboBoxDelayTime.SelectedItem);
                    PublicVariable.WaitDataRevTime = Convert.ToInt32(this.comboBoxDelayTime.SelectedItem);
                    this.ComOpen();
                }
                else
                {
                    comPort.RecDelayTime = (DataRecDelayTime)Convert.ToInt32(this.comboBoxDelayTime.SelectedItem);
                    PublicVariable.WaitDataRevTime = Convert.ToInt32(this.comboBoxDelayTime.SelectedItem);
                }
            };
            this.GetFromIni();
            comPort.DataReceived += new DataReceivedEventHandler(this.comPort_DataReceived);
            comPort.PortName = this.comboBoxSerialName.SelectedItem == null ? "" : this.comboBoxSerialName.SelectedItem.ToString();
            comPort.BautRate = (SerialPortBaudRates)Convert.ToInt32(this.comboBoxBaudRate.SelectedItem);
            comPort.Parity = (Parity)this.comboBoxParity.SelectedIndex;
            comPort.DataBits = (SerialPortDatabits)Convert.ToInt32(this.comboBoxDataBits.SelectedItem);
            comPort.StopBits = (StopBits)this.comboBoxStopBits.SelectedIndex;
            comPort.RecDelayTime = (DataRecDelayTime)Convert.ToInt32(this.comboBoxDelayTime.SelectedItem);
        }
      

    }
}
