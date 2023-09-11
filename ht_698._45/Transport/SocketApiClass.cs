using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace ht_698._45
{
    class SocketApiClass
    {
        PublicClass Dt_Class = new PublicClass();
        int resultInt = 0;
        [DllImport("SocketApi.dll")]
        public static extern int ConnectDevice(string PutIP, string PutPort, string PutCtime);

        [DllImport("SocketApi.dll")]
        public static extern int Obj_Meter_Formal_InitSession(int iKeyState, string cESAMID, string cASCTR, string cFLG,
        byte[] cOutRandHost, byte[] cOutSessionInit, byte[] cOutSign);
        [DllImport("SocketApi.dll")]
        public static extern int Obj_Meter_Formal_VerifySession(int iKeyState, string cESAMID, string cRandHost, string cSessionData,
        string cSign, byte[] cOutSessionKey);

        [DllImport("SocketApi.dll")]
        public static extern int Obj_Meter_Formal_SetESAMData(int InKeyState, int InOperateMode, string cESAMID, string cSessionKey,
        string cMeterNum, string cOutRandHost, string cData, byte[] OutSID, byte[] OutAddData, byte[] OutData, byte[] OutMAC);

        [DllImport("SocketApi.dll")]
        public static extern int Obj_Meter_Formal_GetMeterSetData(int iOperateMode, string cESAMID, string cSessionKey, string cTaskData,
        byte[] cOutSID, byte[] cOutAttachData, byte[] cOutData, byte[] cOutMAC);

        [DllImport("SocketApi.dll")]
        public static extern int Obj_Meter_Formal_GetSessionData(int iOperateMode, string cESAMID, string cSessionKey, int cTaskType, string cTaskData,
        byte[] cOutSID, byte[] cOutAttachData, byte[] cOutData, byte[] cOutMAC);

        [DllImport("SocketApi.dll")]
        public static extern int Obj_Meter_Formal_VerifyMeterData(int iKeyState, int iOperateMode, string cESAMID, string cSessionKey,
        string cTaskData, string cMac, byte[] cOutData);

        /// <summary>
        /// 用于登录服务器，后续函数调用必须先调用此函数。
        /// 服务器连接如果在10 分钟内没有活动，会自动断开，建议每个连接增加一个心跳功能，通过调用电表身份认证函数保证连接处于活动状态。
        /// </summary>
        /// <param name="PutIP">服务器IP地址</param>
        /// <param name="PutPort">服务器端口号</param>
        /// <param name="PutCtime">等待时间单位秒</param>
        public bool doConnectDevice(string PutIP, string PutPort, string PutCtime)
        {
            resultInt = ConnectDevice(PutIP, PutPort, PutCtime);
            if (resultInt == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 用于主站与设备进行会话协商时产生密文和签名数据，该过程在建立应用连接时完成。
        /// </summary>
        /// <param name="iKeyState">对称密钥状态：0，出厂密钥；1，正式密钥</param>
        /// <param name="cESAMID">TESAM 序列号</param>
        /// <param name="cASCTR">应用会话计数器</param>
        /// <param name="cFLG">应用密钥产生标识，1Bytes，默认”01”;</param>
        /// <returns></returns>
        public bool doObj_Meter_Formal_InitSession(int iKeyState, string cESAMID, string cASCTR, string cFLG)
        {
            try
            {
                byte[] cOutRandHostSb = new byte[100];
                byte[] cOutSessionInitSb = new byte[100];
                byte[] cOutSignSb = new byte[100];

                resultInt = Obj_Meter_Formal_InitSession(iKeyState, cESAMID.ToUpper(), cASCTR.ToUpper(), cFLG.ToUpper(), cOutRandHostSb, cOutSessionInitSb, cOutSignSb);
                if (resultInt == 0)
                {
                    Dt_Class.COutRandHost = CRC16Util.CharArrayToHexString(cOutRandHostSb);
                    Dt_Class.COutSessionInit = CRC16Util.CharArrayToHexString(cOutSessionInitSb);
                    Dt_Class.COutSign = CRC16Util.CharArrayToHexString(cOutSignSb);
                    return true;
                }
                else
                    return false;

                //StringBuilder cOutRandHostSb = new StringBuilder();
                //StringBuilder cOutSessionInitSb = new StringBuilder();
                //StringBuilder cOutSignSb = new StringBuilder();
                //resultInt = Obj_Meter_Formal_InitSession(iKeyState, cESAMID, cASCTR, cFLG, cOutRandHostSb, cOutSessionInitSb, cOutSignSb);
                //if (resultInt == 0)
                //{
                //    Dt_Class.COutRandHost = cOutRandHostSb.ToString();
                //    Dt_Class.COutSessionInit = cOutSessionInitSb.ToString();
                //    Dt_Class.COutSign = cOutSignSb.ToString();
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}             
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 用于主站验证设备会话协商时返回的数据，验证成功主站产生会话密钥。
        /// </summary>
        /// <param name="iKeyState">对称密钥状态：0，出厂密钥；1，正式密钥</param>
        /// <param name="cESAMID">TESAM 序列号</param>
        /// <param name="cRandHost">主站随机数R1（16Bytes）</param>
        /// <param name="cSessionData">终端返回的应用会话协商数据(48Bytes)</param>
        /// <param name="cSign">终端返回的应用会话协商数据签名(64Bytes)</param>
        /// <returns></returns>
        public bool doObj_Meter_Formal_VerifySession(int iKeyState, string cESAMID, string cRandHost, string cSessionData, string cSign)
        {
            byte[] cOutSessionKeySb = new byte[500];

            resultInt = Obj_Meter_Formal_VerifySession(iKeyState, cESAMID.ToUpper(), cRandHost.ToUpper(), cSessionData.ToUpper(), cSign.ToUpper(), cOutSessionKeySb);
            if (resultInt == 0)
            {
                Dt_Class.COutSessionKey = CRC16Util.CharArrayToHexString(cOutSessionKeySb);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 用于设置表号、当前套电价文件、备用套电价文件、ESAM 存储标识。
        /// </summary>
        /// <param name="iKeyState">对称密钥状态：0，出厂密钥；1，正式密钥</param>
        /// <param name="InOperateMode">操作模式 iOperateMode =1：明文+MaciOperateMode= 2：密文iOperateMode= 3：密文+MAC</param>
        /// <param name="cESAMID">ESAM 序列号</param>
        /// <param name="cSessionKey">会话密钥 建立会话成功后系统存储的会话密钥</param>
        /// <param name="cMeterNum">表号(8Bytes)，不够8Bytes 前面填充0</param>
        /// <param name="cRandHost">主站随机数R1（16Bytes）</param>
        /// <param name="cData">4BytesOAD + 1Bytes 内容LEN + 内容</param>
        /// <returns></returns>
        public bool doObj_Meter_Formal_SetESAMDataint(int iKeyState, int InOperateMode, string cESAMID, string cSessionKey, string cMeterNum, string cRandHost, string cData)
        {
            byte[] cOutSID = new byte[100];
            byte[] cOutAddData = new byte[100];
            byte[] cOutData = new byte[100];
            byte[] cOutMAC = new byte[100];

            resultInt = Obj_Meter_Formal_SetESAMData(iKeyState, InOperateMode, cESAMID.ToUpper(), cSessionKey.ToUpper(), cMeterNum.ToUpper(), cRandHost.ToUpper(), cData.ToUpper(), cOutSID, cOutAddData, cOutData, cOutMAC);
            if (resultInt == 0)
            {
                Dt_Class.COutSID = CRC16Util.CharArrayToHexString(cOutSID);
                Dt_Class.COutAddData = CRC16Util.CharArrayToHexString(cOutAddData);
                Dt_Class.COutData = CRC16Util.CharArrayToHexString(cOutData);
                Dt_Class.COutMAC = CRC16Util.CharArrayToHexString(cOutMAC);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 对终端通用业务进行数据加密计算, 通用数据加密函数，写ESAM 操作和钱包操作数据下发通过此函数进行安全计算。
        /// </summary>
        /// <param name="InOperateMode">操作模式 iOperateMode =1：明文+MaciOperateMode= 2：密文iOperateMode= 3：密文+MAC</param>
        /// <param name="cESAMID">ESAM 序列号</param>
        /// <param name="cSessionKey">会话密钥 建立会话成功后系统存储的会话密钥</param>
        /// <param name="cTaskData">数据明文</param>
        /// <returns></returns>
        public bool doObj_Meter_Formal_GetMeterSetData(int iOperateMode, string cESAMID, string cSessionKey, string cTaskData)
        {
            byte[] cOutSID = new byte[100];
            byte[] cOutAttachData = new byte[100];
            byte[] cOutData = new byte[100];
            byte[] cOutMAC = new byte[100];

            resultInt = Obj_Meter_Formal_GetMeterSetData(iOperateMode, cESAMID.ToUpper(), cSessionKey.ToUpper(), cTaskData.ToUpper(), cOutSID, cOutAttachData, cOutData, cOutMAC);
            if (resultInt == 0)
            {
                Dt_Class.COutSID = CRC16Util.CharArrayToHexString(cOutSID);
                Dt_Class.COutAttachData = CRC16Util.CharArrayToHexString(cOutAttachData);
                Dt_Class.COutData = CRC16Util.CharArrayToHexString(cOutData);
                Dt_Class.COutMAC = CRC16Util.CharArrayToHexString(cOutMAC);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 对终端通用业务进行数据加密计算, 通用数据加密函数，写ESAM 操作和钱包操作数据下发通过此函数进行安全计算。
        /// </summary>
        /// <param name="InOperateMode">操作模式 iOperateMode =1：明文+MaciOperateMode= 2：密文iOperateMode= 3：密文+MAC</param>
        /// <param name="cESAMID">ESAM 序列号</param>
        /// <param name="cSessionKey">会话密钥 建立会话成功后系统存储的会话密钥</param>
        /// <param name="cTaskData">数据明文</param>
        /// <returns></returns>
        public bool doObj_Meter_Formal_VerifyMeterData(int iKeyState, int iOperateMode, string cESAMID, string cSessionKey, string cTaskData, string cMac)
        {
            byte[] cOutData = new byte[100];

            resultInt = Obj_Meter_Formal_VerifyMeterData(iKeyState, iOperateMode, cESAMID.ToUpper(), cSessionKey.ToUpper(), cTaskData.ToUpper(), cMac.ToUpper(), cOutData);
            if (resultInt == 0)
            {
                Dt_Class.COutData = CRC16Util.CharArrayToHexString(cOutData);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 用于对具体业务数据进行数据加密计算
        /// </summary>
        /// <param name="iKeyState">对称密钥状态：0，出厂密钥；1，正式密钥</param>
        /// <param name="InOperateMode">操作模式 iOperateMode =1：明文+MaciOperateMode= 2：密文iOperateMode= 3：密文+MAC</param>
        /// <param name="cESAMID">ESAM 序列号</param>
        /// <param name="cTaskType">参数类型：4，安全模式设置、设置会话时效门限；5，电价设、电价切换时间、费率时段、对时任务设置；6，除拉闸外的控制任务设置；8，拉闸任务设置；3，除上述操作外的操作，同Obj_Meter_Formal_GetMeterSetData；</param>
        /// <param name="cSessionKey">会话密钥 建立会话成功后系统存储的会话密钥</param>
        /// <param name="cTaskData">数据明文</param>
        /// <param name="cMac">数据验证码</param>
        /// <returns></returns>
        public bool doObj_Meter_Formal_GetSessionData(int iOperateMode, string cESAMID, string cSessionKey, int cTaskType, string cTaskData)
        {
            byte[] cOutSID = new byte[100];
            byte[] cOutAttachData = new byte[100];
            byte[] cOutData = new byte[100];
            byte[] cOutMAC = new byte[100];

            resultInt = Obj_Meter_Formal_GetSessionData(iOperateMode, cESAMID.ToUpper(), cSessionKey.ToUpper(), cTaskType, cTaskData.ToUpper(), cOutSID, cOutAttachData, cOutData, cOutMAC);
            if (resultInt == 0)
            {
                Dt_Class.COutSID = CRC16Util.CharArrayToHexString(cOutSID);
                Dt_Class.COutAttachData = CRC16Util.CharArrayToHexString(cOutAttachData);
                Dt_Class.COutData = CRC16Util.CharArrayToHexString(cOutData);
                Dt_Class.COutMAC = CRC16Util.CharArrayToHexString(cOutMAC);
                return true;
            }
            else
                return false;
        }
    }
}