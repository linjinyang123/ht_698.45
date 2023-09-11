using System;
using System.Runtime.InteropServices;
using System.Text;
namespace ht_698._45
{

    internal class SocketApi
    {
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto)]
        public static extern int CloseDevice();
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto)]
        public static extern int ConnectDevice([MarshalAs(UnmanagedType.LPStr)] string PutIp, [MarshalAs(UnmanagedType.LPStr)] string PutPort, [MarshalAs(UnmanagedType.LPStr)] string PutCtime);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto)]
        public static extern int ConnectDevice([MarshalAs(UnmanagedType.LPStr)] StringBuilder PutIp, [MarshalAs(UnmanagedType.LPStr)] StringBuilder PutPort, [MarshalAs(UnmanagedType.LPStr)] StringBuilder PutCtime);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int CreateRand(int InRandLen, [MarshalAs(UnmanagedType.LPStr)] StringBuilder OutRand1);
        [DllImport("SocketApi.dll")]
        public static extern int Obj_Meter_Formal_GetESAMData(int iKeyState, int iOperateMode, string cMeterNo, string cOAD, StringBuilder cOutRandHost, StringBuilder cOutSID, StringBuilder cOutAttachData);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_GetMeterSetData(int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMID, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutAttachData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutMAC);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_GetPurseData(int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMID, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, int cTaskType, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutAttachData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutMAC);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_GetResponseData(int iKeyState, int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cMeterNo, [MarshalAs(UnmanagedType.LPStr)] string RandHost, [MarshalAs(UnmanagedType.LPStr)] string cReportData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder OutSID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder OutAttachData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder ucOutMac);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_GetSessionData(int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMID, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, int cTaskType, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutAttachData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutMAC);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_GetTrmKeyData(int iKeyState, [MarshalAs(UnmanagedType.LPStr)] string cESAMNO, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, [MarshalAs(UnmanagedType.LPStr)] string cMeterNo, [MarshalAs(UnmanagedType.LPStr)] string cKeyType, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutAttachData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutTrmKeyData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutMAC);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_InitSession(int iKeyState, [MarshalAs(UnmanagedType.LPStr)] string cDiv, [MarshalAs(UnmanagedType.LPStr)] string cASCTR, [MarshalAs(UnmanagedType.LPStr)] string cFLG, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutRandHost, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSessionInit, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSign);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_InitSession(int iKeyState, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cDiv, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cASCTR, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cFLG, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutRandHost, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSessionInit, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSign);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_SetESAMData(int InKeyState, int InOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMID, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, [MarshalAs(UnmanagedType.LPStr)] string cMeterNum, [MarshalAs(UnmanagedType.LPStr)] string cESAMRand, [MarshalAs(UnmanagedType.LPStr)] string cData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder OutSID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder OutAddData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder OutData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder OutMAC);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifyESAMData(int inKeyState, int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMNO, [MarshalAs(UnmanagedType.LPStr)] string cMeterNo, [MarshalAs(UnmanagedType.LPStr)] string cRandHost, [MarshalAs(UnmanagedType.LPStr)] string cOAD, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] string cMAC, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifyMeterData(int iKeyState, int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMID, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] string cMac, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifyReadData(int iKeyState, int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cMeterNo, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cRandHost, [MarshalAs(UnmanagedType.LPStr)] string cReadData, [MarshalAs(UnmanagedType.LPStr)] string cMac, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifyReportData(int iKeyState, int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cMeterNo, [MarshalAs(UnmanagedType.LPStr)] string cRandT, [MarshalAs(UnmanagedType.LPStr)] string cReportData, [MarshalAs(UnmanagedType.LPStr)] string cMac, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutRSPCTR);
        [DllImport("SocketApi.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifySession(int iKeyState, [MarshalAs(UnmanagedType.LPStr)] string cDiv, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cRandHost, [MarshalAs(UnmanagedType.LPStr)] string cSessionData, [MarshalAs(UnmanagedType.LPStr)] string cSign, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSessionKey);
    }
}

