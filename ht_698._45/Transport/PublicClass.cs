using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45
{
    class PublicClass
    {
        public static bool blnSafety = false;
        private static string dataPortName = "485";
        private static string parityName = "Even";
        private static string portName = "com1";
        private static string baudRatName = "2400";
        private static string ZBparityName = "Even";
        private static string ZBportName = "com2";
        private static string ZBbaudRatName = "2400";
        private static string GHparityName = "Even";
        private static string GHportName = "com3";
        private static string GHbaudRatName = "2400";
        private static string HWparityName = "Even";
        private static string HWportName = "com4";
        private static string HWbaudRatName = "2400";
        private static string JJparityName = "Even";
        private static string JJportName = "com5";
        private static string JJbaudRatName = "2400";
        private static string password = "02000000";
        private static string code = "00000000";
        private static string bh = "AAAAAAAAAAAA";
        private static string date;
        private static string time;
        private static string data;
        private static int dataLen;
        private static int dataDecimal;
        private static string itemFlag;
        private static string dataFlag;
        private static string dataName;
        private static string userName;
        private static string dataUnit;
        private static string dataNo;
        private static int dataFromNo;
        private static string itemPlanName;
        private static string itemComName;
        private static string dataRW;
        private static string enWriteData;
        private static string putDiv;
        private static string putRand1;
        private static string putRand2;
        private static string putApdu = "04d6821E0A";
        private static string esamNo;
        private static string passwordData;
        private static string controlCode;
        private static string outMasterCertificate;//会话初始化或恢复,主站证书(大于1K，小于2K)；
        private static string outEncR1;//会话初始化或恢复,随机数1 密文，16 字节；
        private static string outMac;//会话初始化或恢复,Mac，4 字节；
        private static string outSign1;//会话初始化或恢复,签名64 字节；
        private static string outR1;//获取随机数,16 字节随机数,随机数1；
        private static string cOutRandHost;//获取主站会话协商数据,主站随机数（16Bytes）
        private static string cOutSessionInit;//获取主站会话协商数据,会话协商数据（32Bytes）
        private static string cOutSign;//获取主站会话协商数据,协商数据签名(64Bytes)
        private static string cMasterCert;//获取主站会话协商数据,主站证书；
        private static string cTerminalCert;//主站会话协商验证,终端证书;
        private static string cOutSessionKey;//主站会话协商验证,会话密钥;
        private static string manufacturerCode;//厂商编号(建立连接时电表返回) 
        private static string softwareVersionNumber;//软件版本号(建立连接时电表返回)
        private static string softwareVersionDate;//软件版本日期(建立连接时电表返回)
        private static string hardwareVersionNumber;//硬件版本号(建立连接时电表返回)
        private static string hardwareVersionDate;//硬件版本日期(建立连接时电表返回)
        private static string vendorExtension;//厂商扩展信息(建立连接时电表返回)
        private static string serverRan;//服务器随机数(建立连接时电表返回)
        private static string serverSignature;//服务器签名(建立连接时电表返回)
        private static string cESAMID;//ESMA序列号（读取ESMA信息返回）
        private static string cASCTR;//会话计数器（读取ESMA信息返回）

        private static string cOutSID;//安全标识
        private static string cOutAddData;//SID 的附加数据
        private static string cOutData;//数据
        private static string cOutMAC;//附加数据

        private static string cOutAttachData;//附加数据(获取电能表任务数据)

        public bool BlnSafety
        {
            get { return blnSafety; }
            set { blnSafety = value; }
        }

        /// <summary>
        ///附加数据(获取电能表任务数据)
        /// </summary>
        public string COutAttachData
        {
            get { return cOutAttachData; }
            set { cOutAttachData = value; }
        }

        /// <summary>
        ///数据校验码
        /// </summary>
        public string COutMAC
        {
            get { return cOutMAC; }
            set { cOutMAC = value; }
        }

        /// <summary>
        ///数据
        /// </summary>
        public string COutData
        {
            get { return cOutData; }
            set { cOutData = value; }
        }

        /// <summary>
        ///SID 的附加数据
        /// </summary>
        public string COutAddData
        {
            get { return cOutAddData; }
            set { cOutAddData = value; }
        }

        /// <summary>
        ///安全标识
        /// </summary>
        public string COutSID
        {
            get { return cOutSID; }
            set { cOutSID = value; }
        }

        /// <summary>
        ///服务器签名(建立连接时电表返回)
        /// </summary>
        public string ServerSignature
        {
            get { return serverSignature; }
            set { serverSignature = value; }
        }

        /// <summary>
        ///服务器随机数(建立连接时电表返回)
        /// </summary>
        public string ServerRan
        {
            get { return serverRan; }
            set { serverRan = value; }
        }

        /// <summary>
        ///会话计数器（读取ESMA信息返回）
        /// </summary>
        public string CASCTR
        {
            get { return cASCTR; }
            set { cASCTR = value; }
        }

        /// <summary>
        ///ESMA序列号（读取ESMA信息返回）
        /// </summary>
        public string CESAMID
        {
            get { return cESAMID; }
            set { cESAMID = value; }
        }

        /// <summary>
        ///厂商编号(建立连接时电表返回)
        /// </summary>
        public string ManufacturerCode
        {
            get { return manufacturerCode; }
            set { manufacturerCode = value; }
        }

        /// <summary>
        ///厂商扩展信息(建立连接时电表返回)
        /// </summary>
        public string VendorExtension
        {
            get { return vendorExtension; }
            set { vendorExtension = value; }
        }

        /// <summary>
        ///硬件版本日期(建立连接时电表返回)
        /// </summary>
        public string HardwareVersionDate
        {
            get { return hardwareVersionDate; }
            set { hardwareVersionDate = value; }
        }

        /// <summary>
        ///硬件版本号(建立连接时电表返回)
        /// </summary>
        public string HardwareVersionNumber
        {
            get { return hardwareVersionNumber; }
            set { hardwareVersionNumber = value; }
        }

        /// <summary>
        ///软件版本日期(建立连接时电表返回)
        /// </summary>
        public string SoftwareVersionDate
        {
            get { return softwareVersionDate; }
            set { softwareVersionDate = value; }
        }

        /// <summary>
        ///软件版本号(建立连接时电表返回)
        /// </summary>
        public string SoftwareVersionNumber
        {
            get { return softwareVersionNumber; }
            set { softwareVersionNumber = value; }
        }

        /// <summary>
        ///主站会话协商验证,终端证书;
        /// </summary>
        public string CTerminalCert
        {
            get { return cTerminalCert; }
            set { cTerminalCert = value; }
        }

        /// <summary>
        ///主站会话协商验证,会话密钥;
        /// </summary>
        public string COutSessionKey
        {
            get { return cOutSessionKey; }
            set { cOutSessionKey = value; }
        }

        /// <summary>
        ///获取主站会话协商数据,主站证书
        /// </summary>
        public string CMasterCert
        {
            get { return cMasterCert; }
            set { cMasterCert = value; }
        }

        /// <summary>
        ///获取主站会话协商数据,主站随机数（16Bytes）
        /// </summary>
        public string COutRandHost
        {
            get { return cOutRandHost; }
            set { cOutRandHost = value; }
        }

        /// <summary>
        ///获取主站会话协商数据,会话协商数据（32Bytes）
        /// </summary>
        public string COutSessionInit
        {
            get { return cOutSessionInit; }
            set { cOutSessionInit = value; }
        }

        /// <summary>
        ///获取主站会话协商数据,协商数据签名(64Bytes)
        /// </summary>
        public string COutSign
        {
            get { return cOutSign; }
            set { cOutSign = value; }
        }

        /// <summary>
        ///获取随机数,16 字节随机数,随机数1；
        /// </summary>
        public string OutR1
        {
            get { return outR1; }
            set { outR1 = value; }
        }

        /// <summary>
        ///会话初始化或恢复,签名64 字节；
        /// </summary>
        public string OutSign1
        {
            get { return outSign1; }
            set { outSign1 = value; }
        }

        /// <summary>
        ///会话初始化或恢复,Mac，4 字节
        /// </summary>
        public string OutMac
        {
            get { return outMac; }
            set { outMac = value; }
        }

        /// <summary>
        ///会话初始化或恢复,随机数1 密文，16 字节；
        /// </summary>
        public string OutEncR1
        {
            get { return outEncR1; }
            set { outEncR1 = value; }
        }

        /// <summary>
        ///会话初始化或恢复,随机数1 密文，16 字节；
        /// </summary>
        public string OutMasterCertificate
        {
            get { return outMasterCertificate; }
            set { outMasterCertificate = value; }
        }

        /// <summary>
        ///控制码
        /// </summary>
        public string ControlCode
        {
            get { return controlCode; }
            set { controlCode = value; }
        }

        /// <summary>
        ///安全认证密文
        /// </summary>
        public string PasswordData
        {
            get { return passwordData; }
            set { passwordData = value; }
        }

        /// <summary>
        ///安全认证ESAM序列还
        /// </summary>
        public string EsamNo
        {
            get { return esamNo; }
            set { esamNo = value; }
        }

        /// <summary>
        ///安全认证数据头
        /// </summary>
        public string PutApdu
        {
            get { return putApdu; }
            set { putApdu = value; }
        }

        /// <summary>
        ///安全认证随机数1
        /// </summary>
        public string PutRand1
        {
            get { return putRand1; }
            set { putRand1 = value; }
        }

        /// <summary>
        ///安全认证随机数2
        /// </summary>
        public string PutRand2
        {
            get { return putRand2; }
            set { putRand2 = value; }
        }

        /// <summary>
        ///安全认证分散因子
        /// </summary>
        public string PutDiv
        {
            get { return putDiv; }
            set { putDiv = value; }
        }

        /// <summary>
        ///写参数 解析后的值
        /// </summary>
        public string EnWriteData
        {
            get { return enWriteData; }
            set { enWriteData = value; }
        }

        /// <summary>
        /// 操作方式（0为读，1为写）
        /// </summary>
        public string DataRW
        {
            get { return dataRW; }
            set { dataRW = value; }
        }

        #region [载 波 端 口]
        /// <summary>
        ///载波端口校验方法
        /// </summary>
        public string ZBParityName
        {
            get { return ZBparityName; }
            set { ZBparityName = value; }
        }

        /// <summary>
        /// 载波端口名称
        /// </summary>
        public string ZBPortName
        {
            get { return ZBportName; }
            set { ZBportName = value; }
        }

        /// <summary>
        /// 载波端口波特率
        /// </summary>
        public string ZBBaudRatName
        {
            get { return ZBbaudRatName; }
            set { ZBbaudRatName = value; }
        }
        #endregion

        #region [485 端 口]
        /// <summary>
        ///485端口校验方法
        /// </summary>
        public string ParityName
        {
            get { return parityName; }
            set { parityName = value; }
        }

        /// <summary>
        /// 485端口名称
        /// </summary>
        public string PortName
        {
            get { return portName; }
            set { portName = value; }
        }

        /// <summary>
        /// 485端口波特率
        /// </summary>
        public string BaudRatName
        {
            get { return baudRatName; }
            set { baudRatName = value; }
        }
        #endregion

        #region [功 耗 表 端 口]
        /// <summary>
        ///功耗端口校验方法
        /// </summary>
        public string GHParityName
        {
            get { return GHparityName; }
            set { GHparityName = value; }
        }

        /// <summary>
        /// 功耗端口名称
        /// </summary>
        public string GHPortName
        {
            get { return GHportName; }
            set { GHportName = value; }
        }

        /// <summary>
        /// 功耗端口波特率
        /// </summary>
        public string GHBaudRatName
        {
            get { return GHbaudRatName; }
            set { GHbaudRatName = value; }
        }
        #endregion

        #region [红 外 端 口]
        /// <summary>
        ///红外端口校验方法
        /// </summary>
        public string HWParityName
        {
            get { return HWparityName; }
            set { HWparityName = value; }
        }

        /// <summary>
        /// 红外端口名称
        /// </summary>
        public string HWPortName
        {
            get { return HWportName; }
            set { HWportName = value; }
        }

        /// <summary>
        /// 红外端口波特率
        /// </summary>
        public string HWBaudRatName
        {
            get { return HWbaudRatName; }
            set { HWbaudRatName = value; }
        }
        #endregion

        #region [夹 具 端 口]
        /// <summary>
        ///夹具端口校验方法
        /// </summary>
        public string JJParityName
        {
            get { return JJparityName; }
            set { JJparityName = value; }
        }

        /// <summary>
        ///夹具端口名称
        /// </summary>
        public string JJPortName
        {
            get { return JJportName; }
            set { JJportName = value; }
        }

        /// <summary>
        /// 夹具端口波特率
        /// </summary>
        public string JJBaudRatName
        {
            get { return JJbaudRatName; }
            set { JJbaudRatName = value; }
        }
        #endregion

        /// <summary>
        /// 方案名称
        /// </summary>
        public string ItemPlanName
        {
            get { return itemPlanName; }
            set { itemPlanName = value; }
        }

        /// <summary>
        /// 通讯口名称
        /// </summary>
        public string ItemComName
        {
            get { return itemComName; }
            set { itemComName = value; }
        }

        /// <summary>
        /// 数据项通讯方式
        /// </summary>
        public string DataPortName
        {
            get { return dataPortName; }
            set { dataPortName = value; }
        }

        /// <summary>
        ///写数据对应的from框
        /// </summary>
        public int DataFromNo
        {
            get { return dataFromNo; }
            set { dataFromNo = value; }
        }

        /// <summary>
        ///数据单位
        /// </summary>
        public string DataUnit
        {
            get { return dataUnit; }
            set { dataUnit = value; }
        }

        /// <summary>
        ///数据主树状对应标示
        /// </summary>
        public string DataNo
        {
            get { return dataNo; }
            set { dataNo = value; }
        }

        /// <summary>
        ///用户名
        /// </summary>
        public string UserNmae
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        ///数据名称
        /// </summary>
        public string DataName
        {
            get { return dataName; }
            set { dataName = value; }
        }

        /// <summary>
        /// 电表通讯密码 
        /// </summary>
        public string PassWord
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// 电表通讯操作者代码 
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// 电表通讯地址
        /// </summary>
        public string Bh
        {
            get { return bh; }
            set { bh = value; }
        }

        /// <summary>
        ///数据标示
        /// </summary>
        public string DataFlag
        {
            get { return dataFlag; }
            set { dataFlag = value; }
        }

        /// <summary>
        /// 设置值（日期类型）
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// 设置值（时间类型）
        /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// 设置值（普通类型）
        /// </summary>
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        ///  设置值长度
        /// </summary>
        public int DataLen
        {
            get { return dataLen; }
            set { dataLen = value; }
        }

        /// <summary>
        ///  设置值小数位数
        /// </summary>
        public int DataDecimal
        {
            get { return dataDecimal; }
            set { dataDecimal = value; }
        }

        /// <summary>
        ///  设置值标示(1普通参数 2是 3是日期参数 4是时间参数)
        /// </summary>
        public string ItemFlag
        {
            get { return itemFlag; }
            set { itemFlag = value; }
        }
    }
}