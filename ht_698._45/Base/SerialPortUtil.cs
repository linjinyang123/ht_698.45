using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
namespace ht_698._45
{
    public class SerialPortUtil
    {
        public bool ReceiveEventFlag;
        public byte EndByte;
        private string _portName;
        private SerialPortBaudRates _bautRate;
        private System.IO.Ports.Parity _parity;
        private System.IO.Ports.StopBits _stopBits;
        private SerialPortDatabits _dataBits;
        public DataRecDelayTime _recDelayTime;
        public SerialPort comPort;

        public event DataReceivedEventHandler DataReceived;

        public event SerialErrorReceivedEventHandler Error;

        public SerialPortUtil()
        {
            this.EndByte = 0x23;
            this._portName = "COM1";
            this._bautRate = SerialPortBaudRates.BaudRate_2400;
            this._parity = System.IO.Ports.Parity.Even;
            this._stopBits = System.IO.Ports.StopBits.One;
            this._dataBits = SerialPortDatabits.EightBits;
            this._recDelayTime = DataRecDelayTime.Delay_800;
            this.comPort = new SerialPort();
            this._portName = "COM1";
            this._bautRate = SerialPortBaudRates.BaudRate_2400;
            this._parity = System.IO.Ports.Parity.Even;
            this._dataBits = SerialPortDatabits.EightBits;
            this._stopBits = System.IO.Ports.StopBits.One;
            this.comPort.ErrorReceived += new SerialErrorReceivedEventHandler(this.comPort_ErrorReceived);
        }

        public SerialPortUtil(string name, SerialPortBaudRates baud, System.IO.Ports.Parity par, SerialPortDatabits dBits, System.IO.Ports.StopBits sBits)
        {
            this.EndByte = 0x23;
            this._portName = "COM1";
            this._bautRate = SerialPortBaudRates.BaudRate_2400;
            this._parity = System.IO.Ports.Parity.Even;
            this._stopBits = System.IO.Ports.StopBits.One;
            this._dataBits = SerialPortDatabits.EightBits;
            this._recDelayTime = DataRecDelayTime.Delay_800;
            this.comPort = new SerialPort();
            this._portName = name;
            this._parity = par;
            this._bautRate = baud;
            this._dataBits = dBits;
            this._stopBits = sBits;
            this.comPort.ErrorReceived += new SerialErrorReceivedEventHandler(this.comPort_ErrorReceived);
        }

        public SerialPortUtil(string name, string baud, string par, string dBits, string sBits)
        {
            this.EndByte = 0x23;
            this._portName = "COM1";
            this._bautRate = SerialPortBaudRates.BaudRate_2400;
            this._parity = System.IO.Ports.Parity.Even;
            this._stopBits = System.IO.Ports.StopBits.One;
            this._dataBits = SerialPortDatabits.EightBits;
            this._recDelayTime = DataRecDelayTime.Delay_800;
            this.comPort = new SerialPort();
            this._portName = name;
            this._bautRate = (SerialPortBaudRates) Enum.Parse(typeof(SerialPortBaudRates), baud);
            this._parity = (System.IO.Ports.Parity) Enum.Parse(typeof(System.IO.Ports.Parity), par);
            this._stopBits = (System.IO.Ports.StopBits) Enum.Parse(typeof(System.IO.Ports.StopBits), sBits);
            this._dataBits = (SerialPortDatabits) Enum.Parse(typeof(SerialPortDatabits), dBits);
            this.comPort.ErrorReceived += new SerialErrorReceivedEventHandler(this.comPort_ErrorReceived);
        }

        public void Auto_DataReceived(ref byte[] pbReceive)
        {
            try
            {
                if (PublicVariable.BeginRecState)
                {
                    List<byte> list = new List<byte>();
                    long ticks = DateTime.Now.Ticks;
                    long num2 = 0L;
                    bool flag = false;
                    byte[] buffer = new byte[this.comPort.ReadBufferSize + 1];
                    PublicVariable.nowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    while ((this.comPort.BytesToRead > 0) || !flag)
                    {
                        if (this.comPort.BytesToRead >= 1)
                        {
                            int num3 = this.comPort.Read(buffer, 0, this.comPort.BytesToRead);
                            for (int i = 0; i < num3; i++)
                            {
                                list.Add(buffer[i]);
                            }
                            if (this.ExplainDLT698(list))
                            {
                                PublicVariable.RecOverTicks = DateTime.Now.Ticks;
                                pbReceive = list.ToArray();
                                flag = true;
                                break;
                            }
                            ticks = DateTime.Now.Ticks;
                        }
                        num2 = DateTime.Now.Ticks - ticks;
                        if (num2 > ((long) ((long)this._recDelayTime * (long)(DataRecDelayTime.Delay_10000))))
                        {
                            PublicVariable.RecTimeOutFlag = true;
                            PublicVariable.BeginRecState = false;
                            this.comPort.DiscardInBuffer();
                            list.Clear();
                            return;
                        }
                    }
                    pbReceive = list.ToArray();
                    PublicVariable.BeginRecState = false;
                }
            }
            catch (Exception exception)
            {
                PublicVariable.BeginRecState = false;
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 字节转十六进制
        /// </summary>
        /// <param name="comByte"></param>
        /// <returns></returns>
        public static string ByteToHex(byte[] comByte)
        {
            string str = "";
            if (comByte != null)
            {
                for (int i = 0; i < comByte.Length; i++)
                {
                    str = str + comByte[i].ToString("X2") + " ";
                }
            }
            return str;
        }

        public void Close()
        {
            if (this.comPort.IsOpen)
            {
                this.comPort.Close();
            }
        }
        /// <summary>
        /// 数据接收
        /// </summary>
        public void comPort_DataReceived()
        {
            try
            {
                if (PublicVariable.BeginRecState)//发送状态
                {
                    List<byte> list = new List<byte>();
                    long ticks = DateTime.Now.Ticks;
                    long num2 = 0L;
                    bool flag = false;
                    byte[] buffer = new byte[this.comPort.ReadBufferSize + 1];
                    PublicVariable.nowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    while ((this.comPort.BytesToRead > 0) || !flag)
                    {
                        if (this.comPort.BytesToRead >= 1)
                        {
                            int num3 = this.comPort.Read(buffer, 0, this.comPort.BytesToRead);
                            for (int i = 0; i < num3; i++)
                            {
                                list.Add(buffer[i]);
                            }
                            if (this.ExplainDLT698(list))
                            {
                                PublicVariable.RecOverTicks = DateTime.Now.Ticks;
                                byte[] buffer2 = new byte[list.Count];
                                ByteToHex(list.ToArray());
                                flag = true;
                                break;
                            }
                            ticks = DateTime.Now.Ticks;
                        }
                        num2 = DateTime.Now.Ticks - ticks;
                        if (num2 > ((long)((long)this._recDelayTime * (long)DataRecDelayTime.Delay_10000)))
                        {
                            PublicVariable.RecTimeOutFlag = true;
                            PublicVariable.BeginRecState = false;
                            this.comPort.DiscardInBuffer();
                            list.Clear();
                            this.comPort.Close();
                            return;
                        }
                    }
                    byte[] buffer3 = list.ToArray();
                    if (buffer3 != null)
                    {
                        this.DataReceived(new DataReceivedEventArgs(buffer3));
                    }
                    this.comPort.Close();
                    PublicVariable.BeginRecState = false;
                }
            }
            catch (Exception exception)
            {
                this.comPort.Close();
                PublicVariable.BeginRecState = false;
                MessageBox.Show(exception.Message);
            }
        }

        public void comPort_DataReceived645()
        {
            try
            {
                if (PublicVariable.BeginRecState)
                {
                    List<byte> list = new List<byte>();
                    long ticks = DateTime.Now.Ticks;
                    long num2 = 0L;
                    bool flag = false;
                    byte[] buffer = new byte[this.comPort.ReadBufferSize + 1];
                    while ((this.comPort.BytesToRead > 0) || !flag)
                    {
                        if (this.comPort.BytesToRead >= 1)
                        {
                            int num3 = this.comPort.Read(buffer, 0, this.comPort.BytesToRead);
                            for(int i = 0; i < num3; i++)
                            {
                                list.Add(buffer[i]);
                            }
                            if (this.ExplainDLT645(list))
                            {
                                PublicVariable.RecOverTicks = DateTime.Now.Ticks;
                                byte[] buffer2 = new byte[list.Count];
                                ByteToHex(list.ToArray());
                                flag = true;
                                break;
                            }
                            ticks = DateTime.Now.Ticks;
                        }
                        num2 = DateTime.Now.Ticks - ticks;
                        if (num2 > ((long)((long)this._recDelayTime * (long)DataRecDelayTime.Delay_10000)))
                        {
                            PublicVariable.RecTimeOutFlag = true;
                            PublicVariable.BeginRecState = false;
                            this.comPort.DiscardInBuffer();
                            list.Clear();
                            this.comPort.Close();
                            return;
                        }
                    }
                    byte[] buffer3 = list.ToArray();
                    if (buffer3 != null)
                    {
                        this.DataReceived(new DataReceivedEventArgs(buffer3));
                    }
                    this.comPort.Close();
                    PublicVariable.BeginRecState = false;
                }
            }
            catch (Exception exception)
            {
                this.comPort.Close();
                PublicVariable.BeginRecState = false;
                MessageBox.Show(exception.Message);
            }
        }

        private void comPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (this.Error != null)
            {
                this.Error(sender, e);
            }
        }

        public void DiscardBuffer()
        {
            this.comPort.DiscardInBuffer();
            this.comPort.DiscardOutBuffer();
        }

        public static bool Exists(string port_name)
        {
            foreach (string str in SerialPort.GetPortNames())
            {
                if (str == port_name)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ExplainDLT645(List<byte> Buffer)
        {
            byte num = 0;
            int num2 = 0;
            int length = 0;
            byte[] buffer = new byte[Buffer.Count];
            buffer = Buffer.ToArray();
            if (buffer.Length <= 5)
            {
                return false;
            }
            try
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (buffer[i] == 0xfe)
                    {
                        num2++;
                    }
                }
                length = buffer.Length;
                if (buffer[length - 1] != 0x16)
                {
                    return false;
                }
                for (int j = num2; j < (length - 2); j++)
                {
                    num = (byte) (num + buffer[j]);
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }
        /// <summary>
        /// 698接收帧排除
        /// </summary>
        /// <param name="Buffer"></param>
        /// <returns></returns>
        private bool ExplainDLT698(List<byte> Buffer)
        {
            int index = 0;
            int length = 0;
            byte[] sourceArray = new byte[Buffer.Count];
            sourceArray = Buffer.ToArray();
            if (sourceArray.Length <= 9)
            {
                return false;
            }
            try
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (sourceArray[i] == 0xfe)
                    {
                        index++;
                    }
                }
                byte[] destinationArray = new byte[(Buffer.Count - index) - 4];
                if (sourceArray[index] != 0x68)
                {
                    return false;
                }
                length = sourceArray.Length;
                Array.Copy(sourceArray, index + 1, destinationArray, 0, (length - index) - 4);
                if (sourceArray[length - 1] != 0x16)
                {
                    return false;
                }
                if (!PublicVariable.GetCrc16(destinationArray).Equals(sourceArray[length - 2].ToString("X2") + sourceArray[length - 3].ToString("X2")))
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static string Format(SerialPort port)
        {
            return string.Format("{0} ({1},{2},{3},{4},{5})",port.PortName,port.BaudRate,port.DataBits,port.StopBits,port.Parity,port.Handshake);
        }
            //$"{port.PortName} ({port.BaudRate},{port.DataBits},{port.StopBits},{port.Parity},{port.Handshake})";

        public static string[] GetPortNames() 
        {
            return  SerialPort.GetPortNames();
        }
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");
            byte[] buffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(msg.Substring(i, 2), 0x10);
            }
            return buffer;
        }

        public void OpenPort()
        {
            if (this.comPort.IsOpen)
            {
                this.comPort.Close();
            }
            this.comPort.PortName = this._portName;
            this.comPort.DataBits = (int) this._dataBits;
            this.comPort.BaudRate = (int) this._bautRate;
            this.comPort.Parity = this._parity;
            this.comPort.StopBits = this._stopBits;
            this.comPort.Open();
        }

        public bool RecIsProtocol_内部(string RecString, ref string DataRegion, ref bool bExtend)
        {
            byte num = 0;
            byte[] buffer = HexToByte(RecString);
            if (buffer.Length < 12)
            {
                return false;
            }
            int index = 0;
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (buffer[i] == 0xfe)
                    {
                        index++;
                    }
                }
                if (buffer[index] != 0x68)
                {
                    return false;
                }
                int num4 = Convert.ToInt32(buffer[index + 9]);
                if ((buffer[index + 7] != 0x68) || (buffer[(num4 + index) + 11] != 0x16))
                {
                    return false;
                }
                for (int j = index; j < ((index + num4) + 10); j++)
                {
                    num = (byte) (num + buffer[j]);
                }
                if (((buffer[8 + index] & 0xd0) == 0xd0) || (buffer[8 + index] == 0xc3))
                {
                    for (int m = index + 10; m < (buffer.Length - 2); m++)
                    {
                        int num8 = buffer[m] - 0x33;
                        DataRegion = num8.ToString("X16").Substring(14, 2) + DataRegion;
                    }
                    return false;
                }
                if ((buffer[8 + index] == 0xb1) || (buffer[8 + index] == 0xb2))
                {
                    bExtend = true;
                }
                for (int k = index + 10; k < (buffer.Length - 2); k++)
                {
                    DataRegion = buffer[k].ToString("X16").Substring(14, 2) + DataRegion;
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public int SendCommand(byte[] SendData, ref byte[] ReceiveData, int Overtime)
        {
            if (!this.comPort.IsOpen)
            {
                this.comPort.Open();
            }
            this.ReceiveEventFlag = true;
            this.comPort.DiscardInBuffer();
            this.comPort.Write(SendData, 0, SendData.Length);
            int num = 0;
            int num2 = 0;
            while (num++ < Overtime)
            {
                if (this.comPort.BytesToRead >= ReceiveData.Length)
                {
                    break;
                }
                Thread.Sleep(1);
            }
            if (this.comPort.BytesToRead >= ReceiveData.Length)
            {
                num2 = this.comPort.Read(ReceiveData, 0, ReceiveData.Length);
            }
            this.ReceiveEventFlag = false;
            return num2;
        }

        public static void SetBauRateValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (SerialPortBaudRates rates in Enum.GetValues(typeof(SerialPortBaudRates)))
            {
                int num = (int) rates;
                obj.Items.Add(num.ToString());
            }
        }

        public static void SetDataBitsValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (SerialPortDatabits databits in Enum.GetValues(typeof(SerialPortDatabits)))
            {
                int num = (int) databits;
                obj.Items.Add(num.ToString());
            }
        }

        public static void SetDateRecDelayTime(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (DataRecDelayTime time in Enum.GetValues(typeof(DataRecDelayTime)))
            {
                int num = (int) time;
                obj.Items.Add(num.ToString());
            }
        }

        public static void SetParityValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in Enum.GetNames(typeof(System.IO.Ports.Parity)))
            {
                obj.Items.Add(str);
            }
        }

        public static void SetPortNameValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in SerialPort.GetPortNames())
            {
                obj.Items.Add(str);
            }
        }

        public static void SetStopBitValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in Enum.GetNames(typeof(System.IO.Ports.StopBits)))
            {
                obj.Items.Add(str);
            }
        }

        public void WriteData(string msg)
        {
            if (!this.comPort.IsOpen)
            {
                this.comPort.Open();
            }
            this.comPort.DiscardInBuffer();
            this.comPort.Write(msg);
        }
        /// <summary>
        /// 写DT/L698命令帧，即发送帧
        /// </summary>
        /// <param name="msg"></param>
        public void WriteData(byte[] msg)
        {
            if (!this.comPort.IsOpen)
            {
                this.comPort.Open();
            }
            Thread.Sleep(100);
            this.comPort.DiscardInBuffer();
            this.comPort.DiscardOutBuffer();
            PublicVariable.nowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.comPort.Write(msg, 0, msg.Length);
            PublicVariable.SendTimeTicks = DateTime.Now.Ticks;
        }

        public void WriteData(byte[] msg, int offset, int count)
        {
            if (!this.comPort.IsOpen)
            {
                this.comPort.Open();
            }
            this.comPort.DiscardInBuffer();
            this.comPort.Write(msg, offset, count);
        }

        public string PortName
        {
            get 
            {
                return this._portName;
            }
            set 
            {
               this._portName = value;
            }
                
        }

        public SerialPortBaudRates BautRate
        {
            get 
            {
                return this._bautRate;
            }
            set 
            {
                this._bautRate = value;
            }

        }

        public System.IO.Ports.Parity Parity
        {
            get
            {
                return this._parity;
            }
                
            set 
            {
                this._parity = value;
            }
                
        }

        public System.IO.Ports.StopBits StopBits
        {
            get 
            {
                return this._stopBits;
            }  
            set 
            {
                this._stopBits = value;
            }
                
        }

        public SerialPortDatabits DataBits
        {
            get 
            {
                return this._dataBits;
            }
                
            set 
            {
                this._dataBits = value;
            }
               
        }

        public DataRecDelayTime RecDelayTime
        {
            get 
            {
                return this._recDelayTime;
            }
                
            set 
            {
               this._recDelayTime = value;
            }
                
        }

        public bool IsOpen 
        {
            get
            {
                return this.comPort.IsOpen;
            }
           
        }
            
    }
}

