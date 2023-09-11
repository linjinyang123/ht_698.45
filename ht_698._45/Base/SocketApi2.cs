using System;
using System.Runtime.InteropServices;
using System.Text;
namespace ht_698._45
{
    internal class SocketApi2
    {
        [DllImport("SocketApi2.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto)]
        public static extern int ConnectDevice([MarshalAs(UnmanagedType.LPStr)] string PutIp, [MarshalAs(UnmanagedType.LPStr)] string PutPort, [MarshalAs(UnmanagedType.LPStr)] string PutCtime);
        [DllImport("SocketApi2.dll")]
        public static extern int Obj_Meter_Formal_GetESAMData(int iKeyState, int iOperateMode, string cMeterNo, string cOAD, StringBuilder cOutRandHost, StringBuilder cOutSID, StringBuilder cOutAttachData);
        [DllImport("SocketApi2.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_GetMeterSetData(int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMID, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSID, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutAttachData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutMAC);
        [DllImport("SocketApi2.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_InitSession(int iKeyState, [MarshalAs(UnmanagedType.LPStr)] string cDiv, [MarshalAs(UnmanagedType.LPStr)] string cASCTR, [MarshalAs(UnmanagedType.LPStr)] string cFLG, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutRandHost, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSessionInit, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSign);
        [DllImport("SocketApi2.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifyESAMData(int inKeyState, int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMNO, [MarshalAs(UnmanagedType.LPStr)] string cMeterNo, [MarshalAs(UnmanagedType.LPStr)] string cRandHost, [MarshalAs(UnmanagedType.LPStr)] string cOAD, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] string cMAC, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData);
        [DllImport("SocketApi2.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifyMeterData(int iKeyState, int iOperateMode, [MarshalAs(UnmanagedType.LPStr)] string cESAMID, [MarshalAs(UnmanagedType.LPStr)] string cSessionKey, [MarshalAs(UnmanagedType.LPStr)] string cTaskData, [MarshalAs(UnmanagedType.LPStr)] string cMac, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutData);
        [DllImport("SocketApi2.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int Obj_Meter_Formal_VerifySession(int iKeyState, [MarshalAs(UnmanagedType.LPStr)] string cDiv, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cRandHost, [MarshalAs(UnmanagedType.LPStr)] string cSessionData, [MarshalAs(UnmanagedType.LPStr)] string cSign, [MarshalAs(UnmanagedType.LPStr)] StringBuilder cOutSessionKey);
    }
}

