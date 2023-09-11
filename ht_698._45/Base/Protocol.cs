using EncryptServerConnect;
using ht_698._45;
using ht_698._45.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace ht_698._45
{
    internal class Protocol
    {
        public static bool A_Result(ref string str, ref string OAD_Buff, ref string data)
        {
            try
            {
                if (str.Length >= 8)
                {
                    OAD_Buff = str.Substring(0, 8);
                    if (str.Substring(8, 2) == "01")
                    {
                        str = str.Substring(10);
                        AnalyDataType(ref str, ref data);
                        return true;
                    }
                    PublicVariable.DARInfo = "-" + PublicVariable.DARInfo + OAD_Buff + ((DAR) Convert.ToByte(str.Substring(10, 2), 0x10)).ToString() + "-";
                    str = str.Substring(12);
                    data = "";
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionRequest(string Read, string Con_Code, string meterAdd, string Client_Add, string OAD_Buff, string cData, string Timetext, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "01";
                string str2 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str2 = (Read + str + PublicVariable.PIID_W.ToString("X2") + OAD_Buff + cData) + "01" + Timetext;
                short num = (short) (15 + (str2.Length / 2));
                if (OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str2, false))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.ChangedFlag = true;
                    return false;
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str4 = "";
                    string parseData = "";
                    cData = "";
                    OAD_Buff = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = ActionResponseNormal(cData, ref str4, ref OAD_Buff, ref parseData);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionRequest(string Read, string Con_Code, string meterAdd, string Client_Add, string OAD_Buff, string cData, ref List<string> ParseData, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "01";
                string str2 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str2 = Read + str + PublicVariable.PIID_W.ToString("X2") + OAD_Buff + cData;
                if (TimeTag)
                {
                    str2 = str2 + "01" + PublicVariable.TimeText;
                }
                else
                {
                    str2 = str2 + "00";
                }
                short num = (short) ((8 + (meterAdd.Length / 2)) + (str2.Length / 2));
                if (OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str2, false))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.ChangedFlag = true;
                    return false;
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str4 = "";
                    cData = "";
                    OAD_Buff = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = ActionResponseNormal(cData, ref str4, ref OAD_Buff, ref ParseData);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionRequest(string Read, string Con_Code, string meterAdd, string Client_Add, string OAD_Buff, string cData, ref string ParseData, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "01";
                string str2 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str2 = Read + str + PublicVariable.PIID_W.ToString("X2") + OAD_Buff + cData;
                if (TimeTag)
                {
                    str2 = str2 + "01" + PublicVariable.TimeText;
                }
                else
                {
                    str2 = str2 + "00";
                }
                short num = (short) ((8 + (meterAdd.Length / 2)) + (str2.Length / 2));
                if (OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str2, false))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.ChangedFlag = true;
                    return false;
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str4 = "";
                    cData = "";
                    OAD_Buff = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = ActionResponseNormal(cData, ref str4, ref OAD_Buff, ref ParseData);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionRequest(string Read, string Con_Code, string meterAdd, string Client_Add, string OAD_Buff, string cData, ref string ParseData, string Timetext, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "01";
                string str2 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str2 = Read + str + PublicVariable.PIID_W.ToString("X2") + OAD_Buff + cData;
                if (Timetext != "")
                {
                    str2 = str2 + "01" + Timetext;
                }
                else
                {
                    str2 = str2 + "00";
                }
                short num = (short) ((8 + (meterAdd.Length / 2)) + (str2.Length / 2));
                if (OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str2, false))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.ChangedFlag = true;
                    return false;
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str4 = "";
                    cData = "";
                    OAD_Buff = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = ActionResponseNormal(cData, ref str4, ref OAD_Buff, ref ParseData);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionRequestList(string Read, string Con_Code, string meterAdd, string Client_Add, string SEQ_of_OMD, string cData, ref List<string> list_OMD_Buff, ref List<string> Re_DAR, ref List<string> Re_ParseData, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "01";
                string str2 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str2 = Read + str + PublicVariable.PIID_W.ToString("X2") + SEQ_of_OMD.PadLeft(2, '0') + cData;
                if (TimeTag)
                {
                    str2 = str2 + "01" + PublicVariable.TimeText;
                }
                else
                {
                    str2 = str2 + "00";
                }
                short num = (short) ((8 + (meterAdd.Length / 2)) + (str2.Length / 2));
                if (OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str2, false))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.ChangedFlag = true;
                    return false;
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    cData = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = ActionResponseNormalList(cData, ref SEQ_of_OMD, ref list_OMD_Buff, ref Re_DAR, ref Re_ParseData);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionResponseNormal(string RecStr, ref string PIID_Buff, ref string OMD_Buff, ref List<string> ParseData)
        {
            try
            {
                PublicVariable.DARInfo = "";
                if (RecStr.Length >= 20)
                {
                    byte[] buffer = PublicVariable.HexToByte(RecStr);
                    string str = "";
                    PIID_Buff = buffer[2].ToString("X2");
                    OMD_Buff = RecStr.Substring(6, 8);
                    str = RecStr.Substring(0x12);
                    PublicVariable.DARInfo = "---" + OMD_Buff + ((DAR) buffer[7]).ToString();
                    if (buffer[7] == 0)
                    {
                        if (buffer[8] == 1)
                        {
                            Protocol_2.AnalyDataType(ref str, ref ParseData);
                        }
                        FollowReportAndTimeTag(str);
                        return true;
                    }
                    if (buffer[8] == 1)
                    {
                        Protocol_2.AnalyDataType(ref str, ref ParseData);
                    }
                    FollowReportAndTimeTag(str);
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionResponseNormal(string RecStr, ref string PIID_Buff, ref string OMD_Buff, ref string ParseData)
        {
            try
            {
                PublicVariable.DARInfo = "";
                if (RecStr.Length >= 20)
                {
                    byte[] buffer = PublicVariable.HexToByte(RecStr);
                    string str = "";
                    PIID_Buff = buffer[2].ToString("X2");
                    OMD_Buff = RecStr.Substring(6, 8);
                    str = RecStr.Substring(0x12);
                    PublicVariable.DARInfo = "---" + OMD_Buff + ((DAR) buffer[7]).ToString();
                    if (buffer[7] == 0)
                    {
                        if (buffer[8] == 1)
                        {
                            AnalyDataType(ref str, ref ParseData);
                        }
                        FollowReportAndTimeTag(str);
                        return true;
                    }
                    if (buffer[8] == 1)
                    {
                        AnalyDataType(ref str, ref ParseData);
                    }
                    FollowReportAndTimeTag(str);
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionResponseNormalList(string RecStr, ref string SEQ_of_OMD, ref List<string> list_OMD_Buff, ref List<string> Re_DAR, ref List<string> Re_ParseData)
        {
            try
            {
                PublicVariable.DARInfo = "";
                if (RecStr.Length < 20)
                {
                    return false;
                }
                string item = "";
                string data = "";
                RecStr.Substring(4, 2);
                SEQ_of_OMD = RecStr.Substring(6, 2);
                int num = Convert.ToInt16(RecStr.Substring(6, 2), 0x10);
                bool[] flagArray = new bool[num];
                RecStr = RecStr.Substring(8);
                for (int i = 0; i < num; i++)
                {
                    item = RecStr.Substring(0, 8);
                    list_OMD_Buff.Add(item);
                    RecStr = RecStr.Substring(8);
                    Re_DAR.Add(RecStr.Substring(0, 2));
                    if (RecStr.Substring(0, 2) == "00")
                    {
                        RecStr = RecStr.Substring(2);
                        if (RecStr.Substring(0, 2) == "01")
                        {
                            RecStr = RecStr.Substring(2);
                            AnalyDataType(ref RecStr, ref data);
                            Re_ParseData.Add(data);
                        }
                        else
                        {
                            Re_ParseData.Add("");
                            RecStr = RecStr.Substring(2);
                        }
                        flagArray[i] = true;
                    }
                    else
                    {
                        PublicVariable.DARInfo = "--" + PublicVariable.DARInfo + item + ((DAR) Convert.ToInt16(RecStr.Substring(0, 2), 0x10)).ToString() + "--";
                        RecStr = RecStr.Substring(2);
                        if (RecStr.Substring(0, 2) == "01")
                        {
                            RecStr = RecStr.Substring(2);
                            AnalyDataType(ref RecStr, ref data);
                            Re_ParseData.Add(data);
                        }
                        else
                        {
                            Re_ParseData.Add("");
                            RecStr = RecStr.Substring(2);
                        }
                        flagArray[i] = false;
                    }
                }
                FollowReportAndTimeTag(RecStr);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionThenGetRequestNormalList(string Read, string Con_Code, string meterAdd, string Client_Add, string SEQ_of_Pro, string cData, ref List<string> list_OMD_Action, ref List<string> Re_DAR, ref List<string> Re_ParseData_Action, ref List<string> list_OAD_Read, ref List<List<string>> list_Re_ParseData_Read, ref List<bool> flag1, ref List<bool> flag2, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "01";
                string str2 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str2 = Read + str + PublicVariable.PIID_W.ToString("X2") + SEQ_of_Pro.PadLeft(2, '0') + cData;
                if (TimeTag)
                {
                    str2 = str2 + "01" + PublicVariable.TimeText;
                }
                else
                {
                    str2 = str2 + "00";
                }
                short num = (short) ((8 + (meterAdd.Length / 2)) + (str2.Length / 2));
                if (OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str2, false))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.ChangedFlag = true;
                    return false;
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    cData = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = ActionThenGetResponseNormalList(cData, ref SEQ_of_Pro, ref list_OMD_Action, ref Re_DAR, ref Re_ParseData_Action, ref list_OAD_Read, ref list_Re_ParseData_Read, ref flag1, ref flag2);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool ActionThenGetResponseNormalList(string RecStr, ref string SEQ_of_Pro, ref List<string> list_OMD_Action, ref List<string> Re_DAR, ref List<string> Re_ParseData_Action, ref List<string> list_OAD_Read, ref List<List<string>> list_Re_ParseData_Read, ref List<bool> flag1, ref List<bool> flag2)
        {
            try
            {
                PublicVariable.DARInfo = "";
                if (RecStr.Length < 0x24)
                {
                    return false;
                }
                string item = "";
                string data = "";
                RecStr.Substring(4, 2);
                SEQ_of_Pro = RecStr.Substring(6, 2);
                int num = Convert.ToInt16(RecStr.Substring(6, 2), 0x10);
                RecStr = RecStr.Substring(8);
                for (int i = 0; i < num; i++)
                {
                    item = RecStr.Substring(0, 8);
                    list_OMD_Action.Add(item);
                    RecStr = RecStr.Substring(8);
                    Re_DAR.Add(RecStr.Substring(0, 2));
                    if (RecStr.Substring(0, 2) == "00")
                    {
                        RecStr = RecStr.Substring(2);
                        if (RecStr.Substring(0, 2) == "01")
                        {
                            RecStr = RecStr.Substring(2);
                            AnalyDataType(ref RecStr, ref data);
                            Re_ParseData_Action.Add(data);
                        }
                        else
                        {
                            Re_ParseData_Action.Add("");
                            RecStr = RecStr.Substring(2);
                        }
                        flag1.Add(true);
                    }
                    else
                    {
                        PublicVariable.DARInfo = "--" + PublicVariable.DARInfo + item + ((DAR) Convert.ToInt16(RecStr.Substring(0, 2), 0x10)).ToString() + "--";
                        RecStr = RecStr.Substring(2);
                        if (RecStr.Substring(0, 2) == "01")
                        {
                            RecStr = RecStr.Substring(2);
                            AnalyDataType(ref RecStr, ref data);
                            Re_ParseData_Action.Add(data);
                        }
                        else
                        {
                            Re_ParseData_Action.Add("");
                            RecStr = RecStr.Substring(2);
                        }
                        flag1.Add(false);
                    }
                    string str3 = "";
                    List<string> list = new List<string>();
                    if (Protocol_2.A_Result(ref RecStr, ref str3, ref list))
                    {
                        flag2.Add(true);
                        list_OAD_Read.Add(str3);
                        list_Re_ParseData_Read.Add(list);
                    }
                    else
                    {
                        flag2.Add(false);
                        list_OAD_Read.Add(str3);
                        list_Re_ParseData_Read.Add(list);
                    }
                }
                FollowReportAndTimeTag(RecStr);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool AnalyDataType(ref string str, ref string data)
        {
            string str2;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] buffer = PublicVariable.HexToByte(str);
            switch (((DataType) buffer[0]))
            {
                case DataType.NULL:
                    data = "";
                    str = str.Substring(2);
                    goto Label_058A;

                case DataType.Array:
                    str = str.Substring(4);
                    ParseArray(ref str, buffer[1], ref data);
                    goto Label_058A;

                case DataType.Structure:
                    str = str.Substring(4);
                    ParseStruct(ref str, buffer[1], ref data);
                    goto Label_058A;

                case DataType.Bool:
                    data = str.Substring(2, 2);
                    str = str.Substring(4);
                    goto Label_058A;

                case DataType.Bitstring:
                {
                    byte num = buffer[1];
                    data = str.Substring(4, 2 * (num / 8));
                    str = str.Substring((2 + (num / 8)) * 2);
                    goto Label_058A;
                }
                case DataType.Doublelong:
                    data = str.Substring(2, 8);
                    data = Convert.ToInt32(data, 0x10).ToString("D8");
                    str = str.Substring(10);
                    goto Label_058A;

                case DataType.Doublelongunsigned:
                    data = str.Substring(2, 8);
                    data = Convert.ToInt32(data, 0x10).ToString("D8");
                    str = str.Substring(10);
                    goto Label_058A;

                case DataType.Octetstring:
                {
                    int num2 = 0;
                    int num3 = 0;
                    if (buffer[1] <= 0x7f)
                    {
                        num2 = buffer[1];
                        data = str.Substring(4, 2 * num2);
                        str = str.Substring((2 + num2) * 2);
                    }
                    else
                    {
                        num3 = buffer[1] & 15;
                        num2 = Convert.ToInt32(str.Substring(4, num3 * 2), 0x10);
                        data = str.Substring(6, 2 * num2);
                        str = str.Substring((3 + num2) * 2);
                    }
                    goto Label_058A;
                }
                case DataType.Visiblestring:
                {
                    byte num4 = buffer[1];
                    data = PublicVariable.ASCIIHexstrTostr(str.Substring(4, 2 * num4));
                    str = str.Substring((2 + num4) * 2);
                    goto Label_058A;
                }
                case DataType.Long:
                    data = str.Substring(2, 4);
                    data = Convert.ToInt16(data, 0x10).ToString("D4");
                    str = str.Substring(6);
                    goto Label_058A;

                case DataType.unsigned:
                    data = str.Substring(2, 2);
                    if (data != "FF")
                    {
                        data = Convert.ToInt16(data, 0x10).ToString("D2");
                    }
                    str = str.Substring(4);
                    goto Label_058A;

                case DataType.Longunsigned:
                    data = str.Substring(2, 4);
                    data = Convert.ToInt16(data, 0x10).ToString("D4");
                    str = str.Substring(6);
                    goto Label_058A;

                case DataType.long64:
                    data = str.Substring(2, 0x10);
                    data = Convert.ToInt64(data, 0x10).ToString("D16");
                    str = str.Substring(0x12);
                    goto Label_058A;

                case DataType.long64unsigned:
                    data = str.Substring(2, 0x10);
                    data = Convert.ToUInt64(data, 0x10).ToString("D16");
                    str = str.Substring(0x12);
                    goto Label_058A;

                case DataType.Enum:
                    data = str.Substring(2, 2);
                    data = Convert.ToInt32(data, 0x10).ToString("D2");
                    str = str.Substring(4);
                    goto Label_058A;

                case DataType.date:
                    data = str.Substring(2, 10);
                    if (data != "FFFFFFFFFF")
                    {
                        data = Convert.ToInt32(data.Substring(0, 4), 0x10).ToString("D4") + Convert.ToInt32(data.Substring(4, 2), 0x10).ToString("D2") + Convert.ToInt32(data.Substring(6, 2), 0x10).ToString("D2") + Convert.ToInt32(data.Substring(8, 2), 0x10).ToString("D2");
                    }
                    str = str.Substring(12);
                    goto Label_058A;

                case DataType.date_time_s:
                    str2 = "";
                    str2 = str.Substring(2, 14);
                    if (str2.Substring(0, 4) == "FFFF")
                    {
                        data = str2.Substring(0, 4);
                        str2 = str2.Substring(4);
                        break;
                    }
                    data = Convert.ToInt32(str2.Substring(0, 4), 0x10).ToString("D4");
                    str2 = str2.Substring(4);
                    break;

                case DataType.OI:
                    data = str.Substring(2, 4);
                    str = str.Substring(6);
                    goto Label_058A;

                case DataType.OAD:
                    data = str.Substring(2, 8);
                    str = str.Substring(10);
                    goto Label_058A;

                case DataType.COMDCB:
                    data = str.Substring(2, 10);
                    str = str.Substring(12);
                    goto Label_058A;

                default:
                    goto Label_058A;
            }
            for (int i = 0; i < 5; i++)
            {
                if (str2.Substring(0, 2) != "FF")
                {
                    data = data + Convert.ToInt32(str2.Substring(0, 2), 0x10).ToString("D2");
                    str2 = str2.Substring(2);
                }
                else
                {
                    data = data + str2.Substring(0, 2);
                    str2 = str2.Substring(2);
                }
            }
            str = str.Substring(0x10);
        Label_058A:
            return true;
        }

        private string Dispose_RCSD(byte SEQ_Of_CSD, byte Choice_CSD, string List_OAD)
        {
            try
            {
                string str = null;
                if (SEQ_Of_CSD == 0)
                {
                    return SEQ_Of_CSD.ToString("X2");
                }
                switch (Choice_CSD)
                {
                    case 0:
                        str = SEQ_Of_CSD.ToString("X2") + List_OAD;
                        break;

                    case 1:
                        str = "";
                        break;
                }
                return str;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        private string Dispose_ROAD(string Ob_OAD1, byte SEQ_Of_OAD2, string List_OAD2)
        {
            try
            {
                return (Ob_OAD1 + SEQ_Of_OAD2.ToString("X2") + List_OAD2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        private string Dispose_RSD(byte Sele_RSD, string Sele_OAD, string Start_Data, string End_Data, string data_TI, byte N)
        {
            try
            {
                string str = null;
                switch (Sele_RSD)
                {
                    case 1:
                        str = Sele_OAD + Start_Data;
                        break;

                    case 2:
                        str = Sele_OAD + Start_Data + End_Data + data_TI;
                        break;

                    case 9:
                        str = N.ToString("X2");
                        break;
                }
                return str;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public static bool ESAM_Math_纯明文_Read(string OAD_回抄, string OAD_target, ref string ParseData, ref List<string> List_ParseData, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(100);
            StringBuilder builder2 = new StringBuilder(100);
            StringBuilder builder3 = new StringBuilder(200);
            string cData = "";
            int num = -1;
            bool flag2 = false;
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetESAMData, ref builder, ref builder2, ref builder3, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target }))
                    {
                        return flag;
                    }
                    flag2 = false;
                    cData = "5D" + builder2.ToString() + ((builder3.Length / 2)).ToString("X2") + builder3.ToString();
                    flag = ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, OAD_回抄, cData, ref ParseData, PublicVariable.TimeTag, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = false;
                    if ((OAD_target == "40180200") || (OAD_target == "40190200"))
                    {
                        PublicVariable.MAC_Info = "(数据效验：无法效验，动态库会崩溃!)";
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyESAMData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, builder.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8) });
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi2.Obj_Meter_Formal_GetESAMData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target, builder, builder2, builder3) == 0)
            {
                cData = "5D" + builder2.ToString() + ((builder3.Length / 2)).ToString("X2") + builder3.ToString();
                flag = ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, OAD_回抄, cData, ref ParseData, PublicVariable.TimeTag, ref SpliteFlag);
                if (flag)
                {
                    num = SocketApi2.Obj_Meter_Formal_VerifyESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, builder.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8), cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool ESAM_Math_纯明文_Write(string OAD_ESAM更新, string cData, ref string ParseData, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(100);
            StringBuilder builder2 = new StringBuilder(200);
            StringBuilder builder3 = new StringBuilder(200);
            StringBuilder oppOutRand = new StringBuilder(0x20);
            StringBuilder builder5 = new StringBuilder(0x20);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    bool outRand = EncryptServerConnect.GetOutRand(0x10, ref oppOutRand);
                    if (!outRand)
                    {
                        return flag;
                    }
                    if (outRand)
                    {
                        outRand = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.SetESAMData, ref builder, ref builder2, ref cOutData, ref builder3, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, oppOutRand.ToString(), cData });
                        if (outRand)
                        {
                            string[] strArray = new string[] { "020209", PublicVariable.calc_Octlen(cData), cData.ToString(), "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder3.Length / 2).ToString("X2"), builder3.ToString() };
                            str = string.Concat(strArray);
                            flag = ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, OAD_ESAM更新, str, ref ParseData, PublicVariable.TimeTag, ref SpliteFlag);
                        }
                    }
                    PublicVariable.MAC_Info = "(" + (outRand ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi.CreateRand(8, oppOutRand) == 0)
            {
                int num = -1;
                num = SocketApi.CreateRand(8, builder5);
                if (num == 0)
                {
                    oppOutRand.Append(builder5);
                    num = SocketApi.Obj_Meter_Formal_SetESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, oppOutRand.ToString(), cData, builder, builder2, cOutData, builder3);
                    if (num == 0)
                    {
                        string[] strArray2 = new string[] { "020209", PublicVariable.calc_Octlen(cData), cData.ToString(), "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder3.Length / 2).ToString("X2"), builder3.ToString() };
                        str = string.Concat(strArray2);
                        flag = ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, OAD_ESAM更新, str, ref ParseData, PublicVariable.TimeTag, ref SpliteFlag);
                    }
                }
                PublicVariable.MAC_Info = "(" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool ESAM_Math_密文_SID_MAC_Read(string Choice_S_M, string Choice_Sec, string OAD_回抄, string OAD_target, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(100);
            StringBuilder builder3 = new StringBuilder(0x5dc);
            StringBuilder cOutMAC = new StringBuilder(8);
            StringBuilder cOutRandHost = new StringBuilder(100);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi2.Obj_Meter_Formal_GetESAMData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target, cOutRandHost, cOutSID, cOutAttachData) != 0)
                {
                    return flag;
                }
                num = -1;
                str2 = "5D" + cOutSID.ToString() + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData.ToString();
                Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + str2, PublicVariable.TimeTag);
                if (SocketApi2.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                object[] objArray6 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                str2 = string.Concat(objArray6);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi2.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num != 0)
                {
                    goto Label_064B;
                }
                flag = false;
                if ((cOutData.Length < 20) || (cOutData.ToString().Substring(2, 2) != "01"))
                {
                    goto Label_064B;
                }
                string str4 = cOutData.ToString().Substring(0, 2);
                if (str4 != null)
                {
                    if (str4 == "85")
                    {
                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                    }
                    else if (str4 == "86")
                    {
                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                    }
                    else if (str4 == "87")
                    {
                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetESAMData, ref cOutRandHost, ref cOutSID, ref cOutAttachData, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target }))
                {
                    bool flag2 = false;
                    str2 = "5D" + cOutSID.ToString() + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData.ToString();
                    Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + str2, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    object[] objArray3 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                    str2 = string.Concat(objArray3);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if ((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01"))
                        {
                            string str3 = cOutData.ToString().Substring(0, 2);
                            if (str3 != null)
                            {
                                if (str3 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str3 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str3 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                            if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                            {
                                flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyESAMData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, cOutRandHost.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8) });
                                if (!flag2)
                                {
                                    cOutData.Clear();
                                }
                            }
                        }
                    }
                    if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                    {
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                        return flag;
                    }
                    PublicVariable.MAC_Info = "(数据效验：无法效验，动态库会崩溃!)";
                }
                return flag;
            }
            num = SocketApi2.Obj_Meter_Formal_VerifyESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, cOutRandHost.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8), cOutData);
            if (num != 0)
            {
                cOutData.Clear();
            }
        Label_064B:
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool ESAM_Math_密文_SID_MAC_Write(string Choice_S_M, string Choice_Sec, string OAD_ESAM更新, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(0x10);
            StringBuilder builder2 = new StringBuilder(0x10);
            StringBuilder outSID = new StringBuilder(60);
            StringBuilder outAddData = new StringBuilder(100);
            StringBuilder builder5 = new StringBuilder(0x5dc);
            StringBuilder outMAC = new StringBuilder(0x10);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.CreateRand(8, builder) != 0)
                {
                    return flag;
                }
                num = -1;
                if (SocketApi.CreateRand(8, builder2) != 0)
                {
                    return flag;
                }
                builder.Append(builder2);
                if (SocketApi.Obj_Meter_Formal_SetESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, builder.ToString(), Linkdata, outSID, outAddData, cOutData, outMAC) != 0)
                {
                    return flag;
                }
                num = -1;
                string[] strArray2 = new string[] { "020209", PublicVariable.calc_Octlen(Linkdata), Linkdata.ToString(), "5E", outSID.ToString(), (outAddData.Length / 2).ToString("X2"), outAddData.ToString(), (outMAC.Length / 2).ToString("X2"), outMAC.ToString() };
                Linkdata = string.Concat(strArray2);
                Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + Linkdata, PublicVariable.TimeTag);
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, outSID, outAddData, builder5, outMAC) != 0)
                {
                    return flag;
                }
                linkData = builder5.ToString();
                object[] objArray5 = new object[5];
                objArray5[0] = outSID;
                objArray5[1] = (outAddData.Length / 2).ToString("X2");
                objArray5[2] = outAddData;
                objArray5[3] = (outMAC.Length / 2).ToString("X2");
                objArray5[4] = outMAC;
                str2 = string.Concat(objArray5);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    string str4;
                    flag = false;
                    if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str4 = cOutData.ToString().Substring(0, 2)) != null))
                    {
                        if (str4 == "85")
                        {
                            flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str4 == "86")
                        {
                            flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str4 == "87")
                        {
                            flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref builder))
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.GetOutRand(8, ref builder2))
                    {
                        return flag;
                    }
                    builder.Append(builder2);
                    flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.SetESAMData, ref outSID, ref outAddData, ref cOutData, ref outMAC, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, builder.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    flag2 = false;
                    string[] strArray = new string[] { "020209", PublicVariable.calc_Octlen(Linkdata), Linkdata.ToString(), "5E", outSID.ToString(), (outAddData.Length / 2).ToString("X2"), outAddData.ToString(), (outMAC.Length / 2).ToString("X2"), outMAC.ToString() };
                    Linkdata = string.Concat(strArray);
                    Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + Linkdata, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref outSID, ref outAddData, ref builder5, ref outMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder5.ToString();
                    object[] objArray3 = new object[5];
                    objArray3[0] = outSID;
                    objArray3[1] = (outAddData.Length / 2).ToString("X2");
                    objArray3[2] = outAddData;
                    objArray3[3] = (outMAC.Length / 2).ToString("X2");
                    objArray3[4] = outMAC;
                    str2 = string.Concat(objArray3);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        string str3;
                        flag = false;
                        if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str3 = cOutData.ToString().Substring(0, 2)) != null))
                        {
                            if (str3 == "85")
                            {
                                flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str3 == "86")
                            {
                                flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str3 == "87")
                            {
                                flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool ESAM_Math_密文_SID_Read(string Choice_S_M, string Choice_Sec, string OAD_回抄, string OAD_target, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(100);
            StringBuilder builder3 = new StringBuilder(0x5dc);
            StringBuilder cOutMAC = new StringBuilder(8);
            StringBuilder cOutRandHost = new StringBuilder(100);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi2.Obj_Meter_Formal_GetESAMData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target, cOutRandHost, cOutSID, cOutAttachData) != 0)
                {
                    return flag;
                }
                num = -1;
                str2 = "5D" + cOutSID.ToString() + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData.ToString();
                Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + str2, PublicVariable.TimeTag);
                if (SocketApi2.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi2.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num != 0)
                {
                    goto Label_05F2;
                }
                num = -1;
                flag = false;
                if ((cOutData.Length < 20) || (cOutData.ToString().Substring(2, 2) != "01"))
                {
                    goto Label_05F2;
                }
                string str4 = cOutData.ToString().Substring(0, 2);
                if (str4 != null)
                {
                    if (str4 == "85")
                    {
                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                    }
                    else if (str4 == "86")
                    {
                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                    }
                    else if (str4 == "87")
                    {
                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetESAMData, ref cOutRandHost, ref cOutSID, ref cOutAttachData, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target }))
                    {
                        return flag;
                    }
                    str2 = "5D" + cOutSID.ToString() + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData.ToString();
                    Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + str2, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag2 = false;
                        flag = false;
                        if ((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01"))
                        {
                            string str3 = cOutData.ToString().Substring(0, 2);
                            if (str3 != null)
                            {
                                if (str3 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str3 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str3 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                            if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                            {
                                flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyESAMData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, cOutRandHost.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8) });
                                if (!flag2)
                                {
                                    cOutData.Clear();
                                }
                            }
                        }
                    }
                    if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                    {
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                        return flag;
                    }
                    PublicVariable.MAC_Info = "(数据效验：无法效验，动态库会崩溃!)";
                }
                return flag;
            }
            if (ParseData.Length >= 8)
            {
                num = SocketApi2.Obj_Meter_Formal_VerifyESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, cOutRandHost.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8), cOutData);
            }
            if (num != 0)
            {
                cOutData.Clear();
            }
        Label_05F2:
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool ESAM_Math_密文_SID_Write(string Choice_S_M, string Choice_Sec, string OAD_ESAM更新, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(0x10);
            StringBuilder builder2 = new StringBuilder(0x10);
            StringBuilder outSID = new StringBuilder(60);
            StringBuilder outAddData = new StringBuilder(100);
            StringBuilder builder5 = new StringBuilder(0x5dc);
            StringBuilder outMAC = new StringBuilder(0x10);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.CreateRand(8, builder) != 0)
                {
                    return flag;
                }
                num = -1;
                num = SocketApi.CreateRand(8, builder2);
                if (num != 0)
                {
                    return flag;
                }
                builder.Append(builder2);
                if (num != 0)
                {
                    return flag;
                }
                num = -1;
                if (SocketApi.Obj_Meter_Formal_SetESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, builder.ToString(), Linkdata, outSID, outAddData, cOutData, outMAC) != 0)
                {
                    return flag;
                }
                num = -1;
                string[] strArray2 = new string[] { "020209", PublicVariable.calc_Octlen(Linkdata), Linkdata.ToString(), "5E", outSID.ToString(), (outAddData.Length / 2).ToString("X2"), outAddData.ToString(), (outMAC.Length / 2).ToString("X2"), outMAC.ToString() };
                Linkdata = string.Concat(strArray2);
                Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + Linkdata, PublicVariable.TimeTag);
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, outSID, outAddData, builder5, outMAC) != 0)
                {
                    return flag;
                }
                linkData = builder5.ToString();
                str2 = outSID + ((outAddData.Length / 2)).ToString("X2") + outAddData;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    string str4;
                    flag = false;
                    if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str4 = cOutData.ToString().Substring(0, 2)) != null))
                    {
                        if (str4 == "85")
                        {
                            flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str4 == "86")
                        {
                            flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str4 == "87")
                        {
                            flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref builder))
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.GetOutRand(8, ref builder2))
                    {
                        return flag;
                    }
                    builder.Append(builder2);
                    flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.SetESAMData, ref outSID, ref outAddData, ref cOutData, ref outMAC, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, builder.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    flag2 = false;
                    string[] strArray = new string[] { "020209", PublicVariable.calc_Octlen(Linkdata), Linkdata.ToString(), "5E", outSID.ToString(), (outAddData.Length / 2).ToString("X2"), outAddData.ToString(), (outMAC.Length / 2).ToString("X2"), outMAC.ToString() };
                    Linkdata = string.Concat(strArray);
                    Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + Linkdata, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref outSID, ref outAddData, ref builder5, ref outMAC, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    flag2 = false;
                    linkData = builder5.ToString();
                    str2 = outSID + ((outAddData.Length / 2)).ToString("X2") + outAddData;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        string str3;
                        flag = false;
                        if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str3 = cOutData.ToString().Substring(0, 2)) != null))
                        {
                            if (str3 == "85")
                            {
                                flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str3 == "86")
                            {
                                flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str3 == "87")
                            {
                                flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool ESAM_Math_密钥更新_SID_MAC(string Choice_S_M, string Choice_Sec, string OAD_密钥更新, int key_Target, ref string ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            bool flag = false;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(40);
            StringBuilder cOutAttachData = new StringBuilder(100);
            StringBuilder cOutTrmKeyData = new StringBuilder(0x1000);
            StringBuilder cOutMAC = new StringBuilder(10);
            StringBuilder builder5 = new StringBuilder(0x1000);
            string cSessionKey = PublicVariable.cOutSessionKey.ToString();
            string cTaskData = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string linkData = "";
            List<string> list = new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetTrmKeyData(key_Target, PublicVariable.ESAM_ID, cSessionKey, PublicVariable.Meter_NO, "00", cOutSID, cOutAttachData, cOutTrmKeyData, cOutMAC) != 0)
                {
                    return flag;
                }
                num = -1;
                str3 = PublicVariable.calc_Octlen(cOutTrmKeyData.ToString());
                string[] strArray2 = new string[] { "020209", str3, cOutTrmKeyData.ToString(), "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                cTaskData = string.Concat(strArray2);
                cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_密钥更新 + cTaskData, PublicVariable.TimeTag);
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData, cOutSID, cOutAttachData, builder5, cOutMAC) != 0)
                {
                    return flag;
                }
                object[] objArray5 = new object[5];
                objArray5[0] = cOutSID;
                objArray5[1] = (cOutAttachData.Length / 2).ToString("X2");
                objArray5[2] = cOutAttachData;
                objArray5[3] = (cOutMAC.Length / 2).ToString("X2");
                objArray5[4] = cOutMAC;
                str4 = string.Concat(objArray5);
                linkData = builder5.ToString();
                flag = SECURITY_Request_分帧("63", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str4, ref ParseData, ref list, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    string str9;
                    flag = false;
                    if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str9 = cOutData.ToString().Substring(0, 2)) != null))
                    {
                        if (str9 == "85")
                        {
                            flag = GetResponseNormal(cOutData.ToString(), ref str5, ref str6, ref ParseData);
                        }
                        else if (str9 == "86")
                        {
                            flag = SetResponseNormal(cOutData.ToString(), ref str5, ref str6, ref ParseData);
                        }
                        else if (str9 == "87")
                        {
                            flag = ActionResponseNormal(cOutData.ToString(), ref str5, ref str6, ref ParseData);
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetTrmKeyData, ref cOutSID, ref cOutAttachData, ref cOutTrmKeyData, ref cOutMAC, new object[] { key_Target, PublicVariable.ESAM_ID, cSessionKey, PublicVariable.Meter_NO, "00" }))
                {
                    bool flag2 = false;
                    str3 = PublicVariable.calc_Octlen(cOutTrmKeyData.ToString());
                    string[] strArray = new string[] { "020209", str3, cOutTrmKeyData.ToString(), "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                    cTaskData = string.Concat(strArray);
                    cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_密钥更新 + cTaskData, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder5, ref cOutMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData }))
                    {
                        return flag;
                    }
                    object[] objArray3 = new object[5];
                    objArray3[0] = cOutSID;
                    objArray3[1] = (cOutAttachData.Length / 2).ToString("X2");
                    objArray3[2] = cOutAttachData;
                    objArray3[3] = (cOutMAC.Length / 2).ToString("X2");
                    objArray3[4] = cOutMAC;
                    str4 = string.Concat(objArray3);
                    linkData = builder5.ToString();
                    flag = SECURITY_Request_分帧("63", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str4, ref ParseData, ref list, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        string str8;
                        flag = false;
                        if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str8 = cOutData.ToString().Substring(0, 2)) != null))
                        {
                            if (str8 == "85")
                            {
                                flag = GetResponseNormal(cOutData.ToString(), ref str5, ref str6, ref ParseData);
                            }
                            else if (str8 == "86")
                            {
                                flag = SetResponseNormal(cOutData.ToString(), ref str5, ref str6, ref ParseData);
                            }
                            else if (str8 == "87")
                            {
                                flag = ActionResponseNormal(cOutData.ToString(), ref str5, ref str6, ref ParseData);
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool ESAM_Math_明文_RN_Read(string Choice_S_M, string Choice_Sec, string OAD_回抄, string OAD_target, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x20);
            StringBuilder builder2 = new StringBuilder(0x20);
            StringBuilder builder3 = new StringBuilder(100);
            StringBuilder builder4 = new StringBuilder(100);
            StringBuilder builder5 = new StringBuilder(200);
            string str = "";
            string str2 = "";
            int num = -1;
            bool flag2 = false;
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetESAMData, ref builder3, ref builder4, ref builder5, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target }))
                    {
                        return flag;
                    }
                    flag2 = false;
                    if (!EncryptServerConnect.GetOutRand(8, ref oppOutRand))
                    {
                        return flag;
                    }
                    flag2 = false;
                    str2 = "5D" + builder4.ToString() + ((builder5.Length / 2)).ToString("X2") + builder5.ToString();
                    if (!EncryptServerConnect.GetOutRand(8, ref builder2))
                    {
                        return flag;
                    }
                    oppOutRand.Append(builder2);
                    str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                    Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + str2, PublicVariable.TimeTag);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = false;
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyReadData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, oppOutRand, Linkdata, MAC });
                    if (flag2)
                    {
                        flag2 = false;
                        if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                        {
                            flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyESAMData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, builder3.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8) });
                        }
                    }
                    if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                    {
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                        return flag;
                    }
                    PublicVariable.MAC_Info = "(数据效验：无法效验，动态库会崩溃!)";
                }
                return flag;
            }
            if (SocketApi2.Obj_Meter_Formal_GetESAMData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target, builder3, builder4, builder5) == 0)
            {
                num = -1;
                if (SocketApi.CreateRand(8, oppOutRand) != 0)
                {
                    return flag;
                }
                str2 = "5D" + builder4.ToString() + ((builder5.Length / 2)).ToString("X2") + builder5.ToString();
                if (SocketApi.CreateRand(8, builder2) != 0)
                {
                    return flag;
                }
                num = -1;
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + str2, PublicVariable.TimeTag);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = -1;
                num = SocketApi.Obj_Meter_Formal_VerifyReadData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, oppOutRand, Linkdata, MAC, cOutData);
                if (num == 0)
                {
                    num = -1;
                    num = SocketApi2.Obj_Meter_Formal_VerifyESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, builder3.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8), cOutData);
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool ESAM_Math_明文_RN_Write(string Choice_S_M, string Choice_Sec, string OAD_ESAM更新, ref string cData, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x20);
            StringBuilder builder2 = new StringBuilder(0x20);
            StringBuilder builder3 = new StringBuilder(0x20);
            new StringBuilder(100);
            StringBuilder builder4 = new StringBuilder(100);
            StringBuilder builder5 = new StringBuilder(200);
            StringBuilder builder6 = new StringBuilder(200);
            string str = "";
            string linkData = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    bool outRand = EncryptServerConnect.GetOutRand(0x10, ref oppOutRand);
                    if (!outRand || !outRand)
                    {
                        return flag;
                    }
                    outRand = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.SetESAMData, ref builder4, ref builder5, ref cOutData, ref builder6, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, oppOutRand.ToString(), cData }))
                    {
                        return flag;
                    }
                    string[] strArray = new string[] { "020209", PublicVariable.calc_Octlen(cData), cData.ToString(), "5E", builder4.ToString(), (builder5.Length / 2).ToString("X2"), builder5.ToString(), (builder6.Length / 2).ToString("X2"), builder6.ToString() };
                    linkData = string.Concat(strArray);
                    if (!EncryptServerConnect.GetOutRand(8, ref builder3))
                    {
                        return flag;
                    }
                    builder2.Clear();
                    if (!EncryptServerConnect.GetOutRand(8, ref builder2))
                    {
                        return flag;
                    }
                    builder3.Append(builder2);
                    str = ((builder3.Length / 2)).ToString("X2") + builder3.ToString();
                    linkData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + linkData, PublicVariable.TimeTag);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        outRand = false;
                        outRand = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyReadData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, builder3, linkData, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (outRand ? "成功" : "失败") + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.CreateRand(8, oppOutRand) == 0)
            {
                int num = -1;
                num = SocketApi.CreateRand(8, builder2);
                if (num == 0)
                {
                    oppOutRand.Append(builder2);
                    if (num == 0)
                    {
                        num = -1;
                        if (SocketApi.Obj_Meter_Formal_SetESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, oppOutRand.ToString(), cData, builder4, builder5, cOutData, builder6) == 0)
                        {
                            string[] strArray2 = new string[] { "020209", PublicVariable.calc_Octlen(cData), cData.ToString(), "5E", builder4.ToString(), (builder5.Length / 2).ToString("X2"), builder5.ToString(), (builder6.Length / 2).ToString("X2"), builder6.ToString() };
                            linkData = string.Concat(strArray2);
                            if (SocketApi.CreateRand(8, builder3) == 0)
                            {
                                builder2.Clear();
                                if (SocketApi.CreateRand(8, builder2) == 0)
                                {
                                    builder3.Append(builder2);
                                    str = ((builder3.Length / 2)).ToString("X2") + builder3.ToString();
                                    linkData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + linkData, PublicVariable.TimeTag);
                                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                                    if (flag)
                                    {
                                        num = -1;
                                        num = SocketApi.Obj_Meter_Formal_VerifyReadData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, builder3, linkData, MAC, cOutData);
                                        PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return flag;
        }

        public static bool ESAM_Math_明文_SIDMAC_Read(string Choice_S_M, string Choice_Sec, string OAD_回抄, string OAD_target, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(100);
            StringBuilder builder3 = new StringBuilder(0x5dc);
            StringBuilder builder4 = new StringBuilder(8);
            StringBuilder builder5 = new StringBuilder(100);
            string str = "";
            string str2 = "";
            string linkData = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetESAMData, ref builder5, ref builder, ref builder2, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target }))
                {
                    bool flag2 = false;
                    str2 = "5D" + builder.ToString() + ((builder2.Length / 2)).ToString("X2") + builder2.ToString();
                    Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + str2, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    flag2 = false;
                    object[] objArray3 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str = string.Concat(objArray3);
                    linkData = builder3.ToString();
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag2 = false;
                        if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                        {
                            flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyESAMData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, builder5.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8) });
                            if (!flag2)
                            {
                                cOutData.Clear();
                            }
                        }
                    }
                    if ((OAD_target != "40180200") && (OAD_target != "40190200"))
                    {
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                        return flag;
                    }
                    PublicVariable.MAC_Info = "(数据效验：无法效验，动态库会崩溃!)";
                }
                return flag;
            }
            if (SocketApi2.Obj_Meter_Formal_GetESAMData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, OAD_target, builder5, builder, builder2) == 0)
            {
                int num = -1;
                Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_回抄 + ("5D" + builder.ToString() + ((builder2.Length / 2)).ToString("X2") + builder2.ToString()), PublicVariable.TimeTag);
                if (SocketApi2.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) != 0)
                {
                    return flag;
                }
                object[] objArray6 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray6);
                linkData = builder3.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi2.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    num = -1;
                    num = SocketApi2.Obj_Meter_Formal_VerifyESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.Meter_NO, builder5.ToString(), OAD_target, ParseData.Substring(0, ParseData.Length - 8), ParseData.Substring(ParseData.Length - 8), cOutData);
                    if (num != 0)
                    {
                        cOutData.Clear();
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool ESAM_Math_明文_SIDMAC_Write(string Choice_S_M, string Choice_Sec, string OAD_ESAM更新, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x10);
            StringBuilder builder2 = new StringBuilder(0x10);
            StringBuilder builder3 = new StringBuilder(10);
            StringBuilder builder4 = new StringBuilder(100);
            StringBuilder builder5 = new StringBuilder(0x5dc);
            StringBuilder builder6 = new StringBuilder(8);
            string str = "";
            string linkData = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref oppOutRand))
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.GetOutRand(8, ref builder2))
                    {
                        return flag;
                    }
                    oppOutRand.Append(builder2);
                    flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.SetESAMData, ref builder3, ref builder4, ref cOutData, ref builder6, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, oppOutRand.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    string[] strArray = new string[] { "020209", PublicVariable.calc_Octlen(Linkdata), Linkdata.ToString(), "5E", builder3.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString(), (builder6.Length / 2).ToString("X2"), builder6.ToString() };
                    Linkdata = string.Concat(strArray);
                    Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + Linkdata, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder3, ref builder4, ref builder5, ref builder6, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    object[] objArray3 = new object[5];
                    objArray3[0] = builder3;
                    objArray3[1] = (builder4.Length / 2).ToString("X2");
                    objArray3[2] = builder4;
                    objArray3[3] = (builder6.Length / 2).ToString("X2");
                    objArray3[4] = builder6;
                    str = string.Concat(objArray3);
                    linkData = builder5.ToString();
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.CreateRand(8, oppOutRand) == 0)
            {
                int num = -1;
                num = SocketApi.CreateRand(8, builder2);
                if (num == 0)
                {
                    oppOutRand.Append(builder2);
                    if (num == 0)
                    {
                        num = -1;
                        if (SocketApi.Obj_Meter_Formal_SetESAMData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), PublicVariable.Meter_NO, oppOutRand.ToString(), Linkdata, builder3, builder4, cOutData, builder6) == 0)
                        {
                            string[] strArray2 = new string[] { "020209", PublicVariable.calc_Octlen(Linkdata), Linkdata.ToString(), "5E", builder3.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString(), (builder6.Length / 2).ToString("X2"), builder6.ToString() };
                            Linkdata = string.Concat(strArray2);
                            Linkdata = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_ESAM更新 + Linkdata, PublicVariable.TimeTag);
                            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder3, builder4, builder5, builder6) == 0)
                            {
                                object[] objArray5 = new object[] { builder3, (builder4.Length / 2).ToString("X2"), builder4, (builder6.Length / 2).ToString("X2"), builder6 };
                                str = string.Concat(objArray5);
                                linkData = builder5.ToString();
                                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                                if (flag)
                                {
                                    num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                                }
                            }
                        }
                    }
                }
            }
            return flag;
        }

        public static void FollowReportAndTimeTag(string followInfo)
        {
            try
            {
                PublicVariable.follow_DataNormal.Clear();
                PublicVariable.follow_OADNormal.Clear();
                PublicVariable.follow_TimeTag.Clear();
                PublicVariable.follow_DataRercord.Clear();
                PublicVariable.follow_OADRercord = "";
                PublicVariable.follow_RecordNumRercord = "";
                PublicVariable.follow_rel_NumRercord = "";
                PublicVariable.follow_Rel_RCSDRercord.Clear();
                string str = "";
                byte num = 0;
                if (followInfo.Substring(0, 2) == "01")
                {
                    followInfo = followInfo.Substring(2);
                    if (followInfo.Substring(0, 2) == "01")
                    {
                        followInfo = followInfo.Substring(2);
                        num = Convert.ToByte(followInfo.Substring(0, 2), 0x10);
                        followInfo = followInfo.Substring(2);
                        for (int i = 0; i < num; i++)
                        {
                            Protocol_2.A_Result(ref followInfo, ref str, ref PublicVariable.follow_DataNormal);
                            PublicVariable.follow_OADNormal.Add(str);
                        }
                    }
                    else if (followInfo.Substring(0, 2) == "02")
                    {
                        followInfo = followInfo.Substring(2);
                        num = Convert.ToByte(followInfo.Substring(0, 2), 0x10);
                        followInfo = followInfo.Substring(2);
                        PublicVariable.follow_OADRercord = followInfo.Substring(0, 8);
                        followInfo = followInfo.Substring(8);
                        Protocol_2.Get_RCSD(ref followInfo, ref PublicVariable.follow_rel_NumRercord, ref PublicVariable.follow_Rel_RCSDRercord);
                        if (followInfo.Substring(0, 2) == "01")
                        {
                            followInfo = followInfo.Substring(2);
                            PublicVariable.follow_RecordNumRercord = followInfo.Substring(0, 2);
                            followInfo = followInfo.Substring(2);
                            for (int i = 0; i < Convert.ToInt16(PublicVariable.follow_RecordNumRercord, 0x10); i++)
                            {
                                List<List<string>> data = new List<List<string>>();
                                for (int j = 0; j < Convert.ToInt16(PublicVariable.follow_rel_NumRercord, 0x10); j++)
                                {
                                    Protocol_2.AnalyDataType_记录表(ref followInfo, ref data);
                                }
                                PublicVariable.follow_DataRercord.Add(data);
                            }
                        }
                        else if (followInfo.Substring(0, 2) == "00")
                        {
                            followInfo = followInfo.Substring(2);
                            PublicVariable.DARInfo = "-" + PublicVariable.DARInfo + PublicVariable.follow_OADRercord + ((DAR) Convert.ToByte(followInfo.Substring(0, 2), 0x10)).ToString() + "-";
                            followInfo = followInfo.Substring(2);
                            PublicVariable.follow_DataRercord.Clear();
                        }
                    }
                }
                else
                {
                    bool flag1 = followInfo.Substring(0, 2) == "00";
                }
                if (followInfo.Substring(0, 2) == "01")
                {
                    string str2 = "";
                    followInfo = followInfo.Substring(2);
                    str2 = followInfo.Substring(0, 14);
                    PublicVariable.follow_TimeTag.Add(Convert.ToInt32(str2.Substring(0, 4), 0x10).ToString("D4") + Convert.ToInt16(str2.Substring(4, 2), 0x10).ToString("D2") + Convert.ToInt16(str2.Substring(6, 2), 0x10).ToString("D2") + Convert.ToInt16(str2.Substring(8, 2), 0x10).ToString("D2") + Convert.ToInt16(str2.Substring(10, 2), 0x10).ToString("D2") + Convert.ToInt16(str2.Substring(12, 2), 0x10).ToString("D2"));
                    followInfo = followInfo.Substring(14);
                    PublicVariable.follow_TimeTag.Add(followInfo.Substring(0, 2));
                    followInfo = followInfo.Substring(2);
                    PublicVariable.follow_TimeTag.Add(Convert.ToInt32(followInfo.Substring(0, 4), 0x10).ToString("D4"));
                    followInfo = followInfo.Substring(4);
                }
                else
                {
                    bool flag2 = followInfo.Substring(0, 2) == "00";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                PublicVariable.Info = exception.Message;
                PublicVariable.Info_Color = "Red";
                PublicVariable.IsReading = false;
            }
        }

        public static string From_Type_GetData(byte dataType, byte dataLen, ref string data)
        {
            string str = "";
            switch (((DataType) dataType))
            {
                case DataType.NULL:
                    dataLen = 0;
                    return dataType.ToString("X2");

                case DataType.Array:
                case DataType.Structure:
                case (DataType.Doublelongunsigned | DataType.Array):
                case ((DataType) 8):
                case (DataType.Visiblestring | DataType.Array):
                case DataType.UTF8string:
                case (DataType.UTF8string | DataType.Array):
                case (DataType.UTF8string | DataType.Structure):
                case (DataType.Longunsigned | DataType.Array):
                case DataType.Float32:
                case DataType.float64:
                case DataType.date_time:
                case DataType.time:
                    return str;

                case DataType.Bool:
                    dataLen = 1;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt16(data.Substring(0, dataLen * 2), 10).ToString("X2");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.Bitstring:
                {
                    int num = dataLen / 8;
                    data = data.PadLeft(num * 2, '0');
                    str = dataType.ToString("X2") + ((num * 8)).ToString("X2") + data.Substring(0, num * 2);
                    data = data.Substring(num * 2);
                    return str;
                }
                case DataType.Doublelong:
                    dataLen = 4;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt32(data.Substring(0, dataLen * 2), 10).ToString("X8");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.Doublelongunsigned:
                    dataLen = 4;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt32(data.Substring(0, dataLen * 2), 10).ToString("X8");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.Octetstring:
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + dataLen.ToString("X2") + data.PadLeft(dataLen * 2, '0').Substring(0, dataLen * 2);
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.Visiblestring:
                {
                    string s = "";
                    data = data.PadRight(dataLen * 2);
                    s = data.Substring(0, dataLen * 2);
                    byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(s);
                    data = data.Substring(dataLen * 2);
                    string str3 = "";
                    foreach (byte num2 in bytes)
                    {
                        str3 = str3 + num2.ToString("X2").Replace("20", "00");
                    }
                    int num12 = dataLen * 2;
                    return (dataType.ToString("X2") + num12.ToString("X2") + str3);
                }
                case DataType.Integer:
                    dataLen = 1;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt16(data.Substring(0, dataLen * 2), 10).ToString("X2");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.Long:
                    dataLen = 2;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt16(data.Substring(0, dataLen * 2), 10).ToString("X4");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.unsigned:
                    dataLen = 1;
                    data = data.PadLeft(dataLen * 2, '0');
                    if (data.Substring(0, 2) == "FF")
                    {
                        str = dataType.ToString("X2") + data.Substring(0, dataLen * 2);
                        break;
                    }
                    str = dataType.ToString("X2") + Convert.ToInt16(data.Substring(0, dataLen * 2), 10).ToString("X2");
                    break;

                case DataType.Longunsigned:
                    dataLen = 2;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt16(data.Substring(0, dataLen * 2), 10).ToString("X4");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.long64:
                    dataLen = 8;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt64(data.Substring(0, dataLen * 2), 10).ToString("X16");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.long64unsigned:
                    dataLen = 8;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToUInt64(data.Substring(0, dataLen * 2), 10).ToString("X16");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.Enum:
                    dataLen = 1;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + Convert.ToInt16(data.Substring(0, dataLen * 2), 10).ToString("X2");
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.date:
                    dataLen = 5;
                    data = data.PadLeft(dataLen * 2, '0');
                    if (data.Substring(0, 4) == "FFFF")
                    {
                        str = dataType.ToString("X2") + data.Substring(0, 4);
                        data = data.Substring(4);
                    }
                    else
                    {
                        str = dataType.ToString("X2") + string.Format("{0:X4}",Convert.ToInt32(data.Substring(0, 4)));
                        data = data.Substring(4);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (data.Substring(0, 2) != "FF")
                        {
                            str = str + string.Format("{0:X2}",Convert.ToInt16(data.Substring(0, 2)));
                            data = data.Substring(2);
                        }
                        else
                        {
                            str = str + data.Substring(0, 2);
                            data = data.Substring(2);
                        }
                    }
                    return str;

                case DataType.date_time_s:
                    dataLen = 7;
                    data = data.PadLeft(dataLen * 2, '0');
                    if (data.Substring(0, 4) == "FFFF")
                    {
                        str = dataType.ToString("X2") + data.Substring(0, 4);
                        data = data.Substring(4);
                    }
                    else
                    {
                        str = dataType.ToString("X2") + string.Format("{0:X4}",Convert.ToInt32(data.Substring(0, 4)));
                        data = data.Substring(4);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (data.Substring(0, 2) != "FF")
                        {
                            str = str + string.Format("{0:X2}",Convert.ToInt16(data.Substring(0, 2)));
                            data = data.Substring(2);
                        }
                        else
                        {
                            str = str + data.Substring(0, 2);
                            data = data.Substring(2);
                        }
                    }
                    return str;

                case DataType.OI:
                    dataLen = 2;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + data.Substring(0, dataLen * 2);
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.OAD:
                    dataLen = 4;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + data.Substring(0, dataLen * 2);
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.ROAD:
                case DataType.OMD:
                case DataType.TSA:
                case DataType.MAC:
                case DataType.RN:
                case DataType.Region:
                case DataType.Scaler_Unit:
                case DataType.RSD:
                case DataType.MS:
                case DataType.SID:
                case DataType.SID_MAC:
                case DataType.RCSD:
                    return str;

                case DataType.TI:
                    dataLen = 3;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + data.Substring(0, dataLen * 2);
                    data = data.Substring(dataLen * 2);
                    return str;

                case DataType.CSD:
                {
                    string str4 = data.Substring(0, 2);
                    int num5 = 0;
                    data = data.Substring(2);
                    switch (str4)
                    {
                        case "00":
                            str = dataType.ToString("X2") + str4 + data.Substring(0, 8);
                            data = data.Substring(8);
                            return str;

                        case "01":
                            str = dataType.ToString("X2") + str4 + data.Substring(0, 8);
                            data = data.Substring(8);
                            num5 = Convert.ToInt16(data.Substring(0, 2));
                            data = data.Substring(2);
                            for (int i = 0; i < num5; i++)
                            {
                                str = str + num5.ToString("X2") + data.Substring(0, 8);
                                data = data.Substring(8);
                            }
                            break;
                    }
                    return str;
                }
                case DataType.COMDCB:
                    dataLen = 5;
                    data = data.PadLeft(dataLen * 2, '0');
                    str = dataType.ToString("X2") + data.Substring(0, dataLen * 2);
                    data = data.Substring(dataLen * 2);
                    return str;

                default:
                    return str;
            }
            data = data.Substring(dataLen * 2);
            return str;
        }

        public static string From_Type_GetData(ref string dataType, ref string dataLen, ref string data, ref List<string> FrameData)
        {
            string item = "";
            switch (Convert.ToByte(dataType.Substring(0, 2)))
            {
                case 1:
                {
                    byte num = Convert.ToByte(dataLen.Substring(0, 2), 10);
                    item = dataType.Substring(0, 2) + Convert.ToInt16(dataLen.Substring(0, 2), 10).ToString("X2");
                    FrameData.Add(item);
                    for (int i = 0; i < num; i++)
                    {
                        dataType = dataType.Substring(2);
                        dataLen = dataLen.Substring(2);
                        if ((dataType.Substring(0, 2) == "01") || (dataType.Substring(0, 2) == "02"))
                        {
                            From_Type_GetData(ref dataType, ref dataLen, ref data, ref FrameData);
                        }
                        else
                        {
                            byte num3 = Convert.ToByte(dataType.Substring(0, 2));
                            byte num4 = Convert.ToByte(dataLen.Substring(0, 2));
                            item = From_Type_GetData(num3, num4, ref data);
                            FrameData.Add(item);
                        }
                    }
                    break;
                }
                case 2:
                {
                    byte num5 = Convert.ToByte(dataLen.Substring(0, 2), 10);
                    item = dataType.Substring(0, 2) + Convert.ToInt16(dataLen.Substring(0, 2), 10).ToString("X2");
                    FrameData.Add(item);
                    for (int i = 0; i < num5; i++)
                    {
                        dataType = dataType.Substring(2);
                        dataLen = dataLen.Substring(2);
                        if ((dataType.Substring(0, 2) == "01") || (dataType.Substring(0, 2) == "02"))
                        {
                            From_Type_GetData(ref dataType, ref dataLen, ref data, ref FrameData);
                        }
                        else
                        {
                            byte num7 = Convert.ToByte(dataType.Substring(0, 2));
                            byte num8 = Convert.ToByte(dataLen.Substring(0, 2));
                            item = From_Type_GetData(num7, num8, ref data);
                            FrameData.Add(item);
                        }
                    }
                    break;
                }
                default:
                {
                    byte num9 = Convert.ToByte(dataType.Substring(0, 2), 10);
                    byte num10 = Convert.ToByte(dataLen.Substring(0, 2), 10);
                    FrameData.Add(From_Type_GetData(num9, num10, ref data));
                    dataType = dataType.Substring(2);
                    dataLen = dataLen.Substring(2);
                    break;
                }
            }
            return string.Join("", FrameData.ToArray());
        }

        public static bool Get_Math_密文_SID_会话时效设置(string Linkdata, ref string outData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder builder4 = new StringBuilder(8);
            string str = "";
            string str2 = "";
            bool flag = false;
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetSessionData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), 2, Linkdata }))
                {
                    str = builder3.ToString();
                    str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                    string[] strArray = new string[] { "020209", (str.Length / 2).ToString("X2"), str, "5D", str2 };
                    outData = string.Concat(strArray);
                    flag = true;
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetSessionData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), 2, Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                str = builder3.ToString();
                str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                string[] strArray2 = new string[] { "020209", (str.Length / 2).ToString("X2"), str, "5D", str2 };
                outData = string.Concat(strArray2);
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 发起读取请求
        /// </summary>
        /// <param name="Str_OAD"></param>
        /// <param name="Con_Code"></param>
        /// <param name="meterAdd"></param>
        /// <param name="Client_Add"></param>
        /// <param name="cData"></param>
        /// <param name="TimeTag"></param>
        /// <param name="SplitFlag"></param>
        /// <returns></returns>
        public static bool GetRequestNormal(string Str_OAD, string Con_Code, string meterAdd, string Client_Add, ref string cData, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                string str = null;
                string str3 = "05";//请求读取
                string str4 = "01";//读取一个对象请求
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);//服务优先级（一般：0）和序号
                if (TimeTag)//判断是否有时间标签
                {
                    str = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + Str_OAD + "01" + PublicVariable.TimeText;
                    short num = (short) ((8 + (meterAdd.Length / 2)) + (str.Length / 2));//从帧头到时间标签的长度
                    if (!OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str, TimeTag))
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    str = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + Str_OAD + "00";
                    short num2 = (short) ((8 + (meterAdd.Length / 2)) + (str.Length / 2));
                    if (OrigDLT698Wrap(num2.ToString("X4"), Con_Code, meterAdd, Client_Add, str, TimeTag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if ((PublicVariable.RecDataString.Length > 0) && RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                {
                    PublicVariable.SplitFlag = SplitFlag;
                    PublicVariable.ChangedFlag = true;
                    return true;
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetRequestNormalList(byte SEQ_Of_OAD, string Colletion_OAD, string Con_Code, string meterAdd, string Client_Add, ref string cData, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                string str = null;
                string str3 = "05";
                string str4 = "02";
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
                if (TimeTag)
                {
                    str = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + SEQ_Of_OAD.ToString("X2") + Colletion_OAD + "01" + PublicVariable.TimeText;
                    short num = (short) ((8 + (meterAdd.Length / 2)) + (str.Length / 2));
                    if (!OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, str, TimeTag))
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    str = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + SEQ_Of_OAD.ToString("X2") + Colletion_OAD + "00";
                    short num2 = (short) ((8 + (meterAdd.Length / 2)) + (str.Length / 2));
                    if (OrigDLT698Wrap(num2.ToString("X4"), Con_Code, meterAdd, Client_Add, str, TimeTag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if ((PublicVariable.RecDataString.Length > 0) && RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                {
                    PublicVariable.SplitFlag = SplitFlag;
                    PublicVariable.ChangedFlag = true;
                    return true;
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        private string GetRequestRecord(byte PIID, byte Sele_RSD, byte SEQ_Of_RCSD, string CSD)
        {
            try
            {
                PIID = (byte) (PIID + 1);
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public static bool GetResponseNormal(string LinkData, ref string PIID_Buff, ref string OAD_Buff, ref string ParseData)
        {
            try
            {
                if (LinkData.Length < 0x10)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                byte[] buffer = PublicVariable.HexToByte(LinkData);
                PIID_Buff = buffer[2].ToString("X2");
                string str = LinkData.Substring(6);
                bool flag = A_Result(ref str, ref OAD_Buff, ref ParseData);
                FollowReportAndTimeTag(str);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseNormalList(string LinkData, ref string PIID_Buff, ref List<string> ListOAD_Buff, ref List<string> ParseData)
        {
            try
            {
                if (LinkData.Length < 0x10)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                byte[] buffer = PublicVariable.HexToByte(LinkData);
                PIID_Buff = buffer[2].ToString("X2");
                byte num = buffer[3];
                string data = "";
                string str2 = "";
                string str3 = LinkData.Substring(8);
                for (int i = 0; i < num; i++)
                {
                    flag = A_Result(ref str3, ref str2, ref data);
                    ListOAD_Buff.Add(str2);
                    ParseData.Add(data);
                }
                FollowReportAndTimeTag(str3);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static string MakeLink_Data(string Action, string Choice, string PIID_Str, string data, bool TimeFlag)
        {
            string str = "";
            if (TimeFlag)
            {
                str = Action + Choice + PIID_Str + data + "01" + PublicVariable.TimeText;
            }
            else
            {
                str = Action + Choice + PIID_Str + data + "00";
            }
            if ((Action == "06") || (Action == "07"))
            {
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
            }
            if (Action == "05")
            {
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
            }
            return str;
        }

        public static string MakeLink_Data(string Action, string Choice, string PIID_Str, string data, string TimeText)
        {
            string str = "";
            str = Action + Choice + PIID_Str + data + "01" + TimeText;
            if ((Action == "06") || (Action == "07"))
            {
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
            }
            if (Action == "05")
            {
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
            }
            return str;
        }

        public static string MakeLink_Data(string Action, string Choice, string PIID_Str, byte SEQOfOAD, string data, bool TimeFlag)
        {
            string str = "";
            if (TimeFlag)
            {
                str = Action + Choice + PIID_Str + SEQOfOAD.ToString("X2") + data + "01" + PublicVariable.TimeText;
            }
            else
            {
                str = Action + Choice + PIID_Str + SEQOfOAD.ToString("X2") + data + "00";
            }
            if ((Action == "06") || (Action == "07"))
            {
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
            }
            if (Action == "05")
            {
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
            }
            return str;
        }

        public static string MakeLink_Data(string Action, string Choice, string PIID_Str, string data, bool TimeFlag, string timeText)
        {
            string str = "";
            if (TimeFlag)
            {
                str = Action + Choice + PIID_Str + data + "01" + timeText;
            }
            else
            {
                str = Action + Choice + PIID_Str + data + "00";
            }
            if ((Action == "06") || (Action == "07"))
            {
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
            }
            if (Action == "05")
            {
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
            }
            return str;
        }

        public static bool Math_纯明文_钱包初始化(string OAD_钱包初始化, int TaskType, string cData, ref string ParseData, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            bool flag = false;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(100);
            StringBuilder builder2 = new StringBuilder(60);
            StringBuilder builder3 = new StringBuilder(20);
            string str = "";
            string str2 = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetPurseData, ref builder, ref builder2, ref cOutData, ref builder3, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData });
                    if (flag2)
                    {
                        string[] strArray = new string[] { "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder3.Length / 2).ToString("X2"), builder3.ToString() };
                        str2 = string.Concat(strArray);
                        if (TaskType == 9)
                        {
                            string[] strArray2 = new string[] { "020206", cData.ToString(), "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder3.Length / 2).ToString("X2"), builder3.ToString() };
                            str = string.Concat(strArray2);
                        }
                        else
                        {
                            str = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str2 + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                        }
                        ParseData = "";
                        flag = ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, OAD_钱包初始化, str, ref ParseData, PublicVariable.TimeTag, ref SpliteFlag);
                    }
                    PublicVariable.MAC_Info = "(" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            int num = SocketApi.Obj_Meter_Formal_GetPurseData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData, builder, builder2, cOutData, builder3);
            if (num == 0)
            {
                string[] strArray4 = new string[] { "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder3.Length / 2).ToString("X2"), builder3.ToString() };
                str2 = string.Concat(strArray4);
                if (TaskType == 9)
                {
                    string[] strArray5 = new string[] { "020206", cData.ToString(), "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder3.Length / 2).ToString("X2"), builder3.ToString() };
                    str = string.Concat(strArray5);
                }
                else
                {
                    str = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str2 + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                }
                ParseData = "";
                flag = ActionRequest("07", "43", PublicVariable.Address, PublicVariable.Client_Add, OAD_钱包初始化, str, ref ParseData, PublicVariable.TimeTag, ref SpliteFlag);
            }
            PublicVariable.MAC_Info = "(" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num2;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            byte num = 0;
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num2 = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num2 == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) != "01")
                        {
                            string str6;
                            if ((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null))
                            {
                                if (str6 == "85")
                                {
                                    flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                }
                                else if (str6 == "86")
                                {
                                    flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                }
                            }
                        }
                        else
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) != "01")
                            {
                                string str4;
                                if ((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null))
                                {
                                    if (str4 == "85")
                                    {
                                        flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                    }
                                    else if (str4 == "86")
                                    {
                                        flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                    }
                                }
                            }
                            else
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "86")
                                    {
                                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "87")
                                    {
                                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num2 == 0) ? "成功" : ("失败" + num2.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref List<string> list_OAD, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num2;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            byte num = 0;
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num2 = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num2 == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) != "01")
                        {
                            string str6;
                            if ((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null))
                            {
                                if (str6 == "85")
                                {
                                    flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list_OAD, ref List_ParseData);
                                }
                                else if (str6 == "86")
                                {
                                    flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list_OAD, ref List_ParseData, ref ParseData);
                                }
                            }
                        }
                        else
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) != "01")
                            {
                                string str4;
                                if ((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null))
                                {
                                    if (str4 == "85")
                                    {
                                        flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list_OAD, ref List_ParseData);
                                    }
                                    else if (str4 == "86")
                                    {
                                        flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list_OAD, ref List_ParseData, ref ParseData);
                                    }
                                }
                            }
                            else
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "86")
                                    {
                                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "87")
                                    {
                                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num2 == 0) ? "成功" : ("失败" + num2.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf, ref StringBuilder cOutData)
        {
            int num2;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x3e8);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            byte num = 0;
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            List<string> list4 = new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num2 = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num2 == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) != "01")
                        {
                            if (cOutData.ToString().Substring(2, 2) != "02")
                            {
                                string str8;
                                if (((cOutData.ToString().Substring(2, 2) == "03") && ((str8 = cOutData.ToString().Substring(0, 2)) != null)) && ((str8 != "85") && (str8 == "86")))
                                {
                                    flag = SetThenGetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list3, ref list4, ref List_ParseData, ref ParseData, ref flag1, ref flag2, ref DARInfo_Buf);
                                }
                            }
                            else
                            {
                                string str7 = cOutData.ToString().Substring(0, 2);
                                if (str7 != null)
                                {
                                    if (str7 == "85")
                                    {
                                        flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                    }
                                    else if (str7 == "86")
                                    {
                                        flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                    }
                                }
                            }
                        }
                        else
                        {
                            string str6 = cOutData.ToString().Substring(0, 2);
                            if (str6 != null)
                            {
                                if (str6 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str6 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str6 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag3 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag3)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) != "01")
                            {
                                if (cOutData.ToString().Substring(2, 2) != "02")
                                {
                                    string str5;
                                    if (((cOutData.ToString().Substring(2, 2) == "03") && ((str5 = cOutData.ToString().Substring(0, 2)) != null)) && ((str5 != "85") && (str5 == "86")))
                                    {
                                        flag = SetThenGetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list3, ref list4, ref List_ParseData, ref ParseData, ref flag1, ref flag2, ref DARInfo_Buf);
                                    }
                                }
                                else
                                {
                                    string str4 = cOutData.ToString().Substring(0, 2);
                                    if (str4 != null)
                                    {
                                        if (str4 == "85")
                                        {
                                            flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                        }
                                        else if (str4 == "86")
                                        {
                                            flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "86")
                                    {
                                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "87")
                                    {
                                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag3 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num2 == 0) ? "成功" : ("失败" + num2.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string SEQ_of_Pro, ref List<string> List_OAD_Buff_W, ref List<string> list_DAR_W, ref List<string> Re_ParseData_Action, ref List<string> List_OAD_Buff_R, ref List<List<string>> List_Data_Buff_R, ref List<bool> flag1, ref List<bool> flag2, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            string str3 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                str3 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str3, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "01")
                        {
                            string str7;
                            if ((((str7 = cOutData.ToString().Substring(0, 2)) == null) || (str7 == "85")) || ((str7 == "86") || (str7 == "87")))
                            {
                            }
                        }
                        else if (cOutData.ToString().Substring(2, 2) == "02")
                        {
                            string str8;
                            if ((((str8 = cOutData.ToString().Substring(0, 2)) != null) && (str8 != "85")) && ((str8 != "86") && (str8 == "87")))
                            {
                                flag = ActionResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action);
                            }
                        }
                        else
                        {
                            string str9;
                            if (((cOutData.ToString().Substring(2, 2) == "03") && ((str9 = cOutData.ToString().Substring(0, 2)) != null)) && (str9 != "85"))
                            {
                                if (str9 == "86")
                                {
                                    flag = SetThenGetResponseNormalList(cOutData.ToString(), ref str2, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                }
                                else if (str9 == "87")
                                {
                                    flag = ActionThenGetResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag3 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    str3 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str3, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag3)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "01")
                            {
                                string str4;
                                if ((((str4 = cOutData.ToString().Substring(0, 2)) == null) || (str4 == "85")) || ((str4 == "86") || (str4 == "87")))
                                {
                                }
                            }
                            else if (cOutData.ToString().Substring(2, 2) == "02")
                            {
                                string str5;
                                if ((((str5 = cOutData.ToString().Substring(0, 2)) != null) && (str5 != "85")) && ((str5 != "86") && (str5 == "87")))
                                {
                                    flag = ActionResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action);
                                }
                            }
                            else
                            {
                                string str6;
                                if (((cOutData.ToString().Substring(2, 2) == "03") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                                {
                                    if (str6 == "86")
                                    {
                                        flag = SetThenGetResponseNormalList(cOutData.ToString(), ref str2, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                    }
                                    else if (str6 == "87")
                                    {
                                        flag = ActionThenGetResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag3 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num2;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            byte num = 0;
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                str2 = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num2 = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num2 == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) != "01")
                        {
                            string str6;
                            if ((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null))
                            {
                                if (str6 == "85")
                                {
                                    flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                }
                                else if (str6 == "86")
                                {
                                    flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                }
                            }
                        }
                        else
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                    str2 = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) != "01")
                            {
                                string str4;
                                if ((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null))
                                {
                                    if (str4 == "85")
                                    {
                                        flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                    }
                                    else if (str4 == "86")
                                    {
                                        flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                    }
                                }
                            }
                            else
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "86")
                                    {
                                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "87")
                                    {
                                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num2 == 0) ? "成功" : ("失败" + num2.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref List<string> list_OAD, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num2;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            byte num = 0;
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                str2 = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num2 = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num2 == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) != "01")
                        {
                            string str6;
                            if ((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null))
                            {
                                if (str6 == "85")
                                {
                                    flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list_OAD, ref List_ParseData);
                                }
                                else if (str6 == "86")
                                {
                                    flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list_OAD, ref List_ParseData, ref ParseData);
                                }
                            }
                        }
                        else
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str5 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                    str2 = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) != "01")
                            {
                                string str4;
                                if ((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null))
                                {
                                    if (str4 == "85")
                                    {
                                        flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list_OAD, ref List_ParseData);
                                    }
                                    else if (str4 == "86")
                                    {
                                        flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list_OAD, ref List_ParseData, ref ParseData);
                                    }
                                }
                            }
                            else
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "86")
                                    {
                                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "87")
                                    {
                                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num2 == 0) ? "成功" : ("失败" + num2.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf, ref StringBuilder cOutData)
        {
            int num2;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x3e8);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            byte num = 0;
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            List<string> list4 = new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                str2 = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num2 = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num2 == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) != "01")
                        {
                            if (cOutData.ToString().Substring(2, 2) != "02")
                            {
                                string str8;
                                if (((cOutData.ToString().Substring(2, 2) == "03") && ((str8 = cOutData.ToString().Substring(0, 2)) != null)) && ((str8 != "85") && (str8 == "86")))
                                {
                                    flag = SetThenGetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list3, ref list4, ref List_ParseData, ref ParseData, ref flag1, ref flag2, ref DARInfo_Buf);
                                }
                            }
                            else
                            {
                                string str7 = cOutData.ToString().Substring(0, 2);
                                if (str7 != null)
                                {
                                    if (str7 == "85")
                                    {
                                        flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                    }
                                    else if (str7 == "86")
                                    {
                                        flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                    }
                                }
                            }
                        }
                        else
                        {
                            string str6 = cOutData.ToString().Substring(0, 2);
                            if (str6 != null)
                            {
                                if (str6 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str6 == "86")
                                {
                                    flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                                else if (str6 == "87")
                                {
                                    flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag3 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                    str2 = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag3)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) != "01")
                            {
                                if (cOutData.ToString().Substring(2, 2) != "02")
                                {
                                    string str5;
                                    if (((cOutData.ToString().Substring(2, 2) == "03") && ((str5 = cOutData.ToString().Substring(0, 2)) != null)) && ((str5 != "85") && (str5 == "86")))
                                    {
                                        flag = SetThenGetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list3, ref list4, ref List_ParseData, ref ParseData, ref flag1, ref flag2, ref DARInfo_Buf);
                                    }
                                }
                                else
                                {
                                    string str4 = cOutData.ToString().Substring(0, 2);
                                    if (str4 != null)
                                    {
                                        if (str4 == "85")
                                        {
                                            flag = GetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref list, ref List_ParseData);
                                        }
                                        else if (str4 == "86")
                                        {
                                            flag = SetResponseNormalList(cOutData.ToString(), ref PIID_Buff, ref num, ref list2, ref List_ParseData, ref ParseData);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "86")
                                    {
                                        flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                    else if (str3 == "87")
                                    {
                                        flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag3 ? "成功" : ("失败" + flag3.ToString())) + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num2 == 0) ? "成功" : ("失败" + num2.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string SEQ_of_Pro, ref List<string> List_OAD_Buff_W, ref List<string> list_DAR_W, ref List<string> Re_ParseData_Action, ref List<string> List_OAD_Buff_R, ref List<List<string>> List_Data_Buff_R, ref List<bool> flag1, ref List<bool> flag2, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(10);
            StringBuilder cOutAttachData = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder cOutMAC = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            string str3 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                str3 = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str3, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "01")
                        {
                            string str7;
                            if ((((str7 = cOutData.ToString().Substring(0, 2)) == null) || (str7 == "85")) || ((str7 == "86") || (str7 == "87")))
                            {
                            }
                        }
                        else if (cOutData.ToString().Substring(2, 2) == "02")
                        {
                            string str8;
                            if ((((str8 = cOutData.ToString().Substring(0, 2)) != null) && (str8 != "85")) && ((str8 != "86") && (str8 == "87")))
                            {
                                flag = ActionResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action);
                            }
                        }
                        else
                        {
                            string str9;
                            if (((cOutData.ToString().Substring(2, 2) == "03") && ((str9 = cOutData.ToString().Substring(0, 2)) != null)) && (str9 != "85"))
                            {
                                if (str9 == "86")
                                {
                                    flag = SetThenGetResponseNormalList(cOutData.ToString(), ref str2, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                }
                                else if (str9 == "87")
                                {
                                    flag = ActionThenGetResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink)
                {
                    bool flag3 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { cOutSID, (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData, (cOutMAC.Length / 2).ToString("X2"), cOutMAC };
                    str3 = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str3, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag3)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "01")
                            {
                                string str4;
                                if ((((str4 = cOutData.ToString().Substring(0, 2)) == null) || (str4 == "85")) || ((str4 == "86") || (str4 == "87")))
                                {
                                }
                            }
                            else if (cOutData.ToString().Substring(2, 2) == "02")
                            {
                                string str5;
                                if ((((str5 = cOutData.ToString().Substring(0, 2)) != null) && (str5 != "85")) && ((str5 != "86") && (str5 == "87")))
                                {
                                    flag = ActionResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action);
                                }
                            }
                            else
                            {
                                string str6;
                                if (((cOutData.ToString().Substring(2, 2) == "03") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                                {
                                    if (str6 == "86")
                                    {
                                        flag = SetThenGetResponseNormalList(cOutData.ToString(), ref str2, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                    }
                                    else if (str6 == "87")
                                    {
                                        flag = ActionThenGetResponseNormalList(cOutData.ToString(), ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag3 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID_MAC_钱包初始化(string Choice_S_M, string Choice_Sec, string OAD_钱包初始化, int TaskType, ref string cData, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(60);
            StringBuilder cOutAttachData = new StringBuilder(100);
            StringBuilder builder3 = new StringBuilder(0x5dc);
            StringBuilder cOutMAC = new StringBuilder(0x10);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            string cTaskData = "";
            string str4 = "";
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetPurseData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData, cOutSID, cOutAttachData, cOutData, cOutMAC) != 0)
                {
                    return flag;
                }
                num = -1;
                string[] strArray4 = new string[] { "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                str4 = string.Concat(strArray4);
                if (TaskType == 9)
                {
                    string[] strArray5 = new string[] { "020206", cData, "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                    cTaskData = string.Concat(strArray5);
                }
                else
                {
                    cTaskData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str4 + "0906" + PublicVariable.Meter_NO.Substring(4, 12);
                }
                ParseData = "";
                cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + cTaskData, PublicVariable.TimeTag);
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                object[] objArray5 = new object[5];
                objArray5[0] = cOutSID;
                objArray5[1] = (cOutAttachData.Length / 2).ToString("X2");
                objArray5[2] = cOutAttachData;
                objArray5[3] = (cOutMAC.Length / 2).ToString("X2");
                objArray5[4] = cOutMAC;
                str2 = string.Concat(objArray5);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    string str6;
                    flag = false;
                    if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str6 = cOutData.ToString().Substring(0, 2)) != null))
                    {
                        if (str6 == "85")
                        {
                            flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str6 == "86")
                        {
                            flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str6 == "87")
                        {
                            flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetPurseData, ref cOutSID, ref cOutAttachData, ref cOutData, ref cOutMAC, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData }))
                {
                    bool flag2 = false;
                    string[] strArray = new string[] { "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                    str4 = string.Concat(strArray);
                    if (TaskType == 9)
                    {
                        string[] strArray2 = new string[] { "020206", cData, "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                        cTaskData = string.Concat(strArray2);
                    }
                    else
                    {
                        cTaskData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str4 + "0906" + PublicVariable.Meter_NO.Substring(4, 12);
                    }
                    ParseData = "";
                    cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + cTaskData, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData }))
                    {
                        return flag;
                    }
                    flag2 = false;
                    linkData = builder3.ToString();
                    object[] objArray3 = new object[5];
                    objArray3[0] = cOutSID;
                    objArray3[1] = (cOutAttachData.Length / 2).ToString("X2");
                    objArray3[2] = cOutAttachData;
                    objArray3[3] = (cOutMAC.Length / 2).ToString("X2");
                    objArray3[4] = cOutMAC;
                    str2 = string.Concat(objArray3);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        string str5;
                        flag = false;
                        if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str5 = cOutData.ToString().Substring(0, 2)) != null))
                        {
                            if (str5 == "85")
                            {
                                flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str5 == "86")
                            {
                                flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str5 == "87")
                            {
                                flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool Math_密文_SID_钱包初始化(string Choice_S_M, string Choice_Sec, string OAD_钱包初始化, int TaskType, ref string cData, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            int num;
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder cOutSID = new StringBuilder(60);
            StringBuilder cOutAttachData = new StringBuilder(100);
            StringBuilder builder3 = new StringBuilder(0x5dc);
            StringBuilder cOutMAC = new StringBuilder(0x10);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            string cTaskData = "";
            string str4 = "";
            new List<string>();
            new List<string>();
            if (PublicVariable.LinkRoadFlag)
            {
                if (SocketApi.Obj_Meter_Formal_GetPurseData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData, cOutSID, cOutAttachData, cOutData, cOutMAC) != 0)
                {
                    return flag;
                }
                num = -1;
                string[] strArray4 = new string[] { "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                str4 = string.Concat(strArray4);
                if (TaskType == 9)
                {
                    string[] strArray5 = new string[] { "020206", cData, "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                    cTaskData = string.Concat(strArray5);
                }
                else
                {
                    cTaskData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str4 + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                }
                ParseData = "";
                cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + cTaskData, PublicVariable.TimeTag);
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData, cOutSID, cOutAttachData, builder3, cOutMAC) != 0)
                {
                    return flag;
                }
                linkData = builder3.ToString();
                str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    string str6;
                    flag = false;
                    if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str6 = cOutData.ToString().Substring(0, 2)) != null))
                    {
                        if (str6 == "85")
                        {
                            flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str6 == "86")
                        {
                            flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                        else if (str6 == "87")
                        {
                            flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                        }
                    }
                }
            }
            else
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetPurseData, ref cOutSID, ref cOutAttachData, ref cOutData, ref cOutMAC, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData }))
                {
                    bool flag2 = false;
                    string[] strArray = new string[] { "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                    str4 = string.Concat(strArray);
                    if (TaskType == 9)
                    {
                        string[] strArray2 = new string[] { "020206", cData, "5E", cOutSID.ToString(), (cOutAttachData.Length / 2).ToString("X2"), cOutAttachData.ToString(), (cOutMAC.Length / 2).ToString("X2"), cOutMAC.ToString() };
                        cTaskData = string.Concat(strArray2);
                    }
                    else
                    {
                        cTaskData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str4 + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                    }
                    ParseData = "";
                    cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + cTaskData, PublicVariable.TimeTag);
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref cOutSID, ref cOutAttachData, ref builder3, ref cOutMAC, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData }))
                    {
                        return flag;
                    }
                    linkData = builder3.ToString();
                    str2 = cOutSID + ((cOutAttachData.Length / 2)).ToString("X2") + cOutAttachData;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        string str5;
                        flag = false;
                        if (((cOutData.Length >= 20) && (cOutData.ToString().Substring(2, 2) == "01")) && ((str5 = cOutData.ToString().Substring(0, 2)) != null))
                        {
                            if (str5 == "85")
                            {
                                flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str5 == "86")
                            {
                                flag = SetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                            else if (str5 == "87")
                            {
                                flag = ActionResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref ParseData);
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            return flag;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x20);
            new StringBuilder(0x20);
            string str = "";
            bool outRand = false;
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    outRand = EncryptServerConnect.GetOutRand(0x10, ref oppOutRand);
                    if (outRand && outRand)
                    {
                        str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                        flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                        if (!flag)
                        {
                        }
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(0x10, ref oppOutRand))
            {
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
            }
            return flag;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string OAD_Buff, ref List<string> list_OAD_Buff, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x20);
            StringBuilder builder2 = new StringBuilder(0x20);
            string str = "";
            bool outRand = false;
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    outRand = EncryptServerConnect.GetOutRand(0x10, ref oppOutRand);
                    if (outRand && outRand)
                    {
                        str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                        flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref list_OAD_Buff, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                        if (!flag)
                        {
                        }
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(8, ref oppOutRand) && EncryptServerConnect.GetOutRand(8, ref builder2))
            {
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref list_OAD_Buff, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
            }
            return flag;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x20);
            StringBuilder builder2 = new StringBuilder(0x20);
            string str = "";
            bool outRand = false;
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    outRand = EncryptServerConnect.GetOutRand(0x10, ref oppOutRand);
                    if (outRand && outRand)
                    {
                        str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                        flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag, ref flag1, ref flag2, ref DARInfo_Buf);
                        if (!flag)
                        {
                        }
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(8, ref oppOutRand) && EncryptServerConnect.GetOutRand(8, ref builder2))
            {
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag, ref flag1, ref flag2, ref DARInfo_Buf);
            }
            return flag;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string SEQ_of_Pro, ref List<string> List_OAD_Buff_W, ref List<string> list_DAR_W, ref List<string> Re_ParseData_Action, ref List<string> List_OAD_Buff_R, ref List<List<string>> List_Data_Buff_R, ref List<bool> flag1, ref List<bool> flag2, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x20);
            StringBuilder builder2 = new StringBuilder(0x20);
            string str = "";
            bool outRand = false;
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink)
                {
                    outRand = EncryptServerConnect.GetOutRand(0x10, ref oppOutRand);
                    if (outRand && outRand)
                    {
                        str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                        flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
                        if (!flag)
                        {
                        }
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(8, ref oppOutRand) && EncryptServerConnect.GetOutRand(8, ref builder2))
            {
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
            }
            return flag;
        }

        public static bool Math_明文_RN_钱包初始化(string Choice_S_M, string Choice_Sec, string OAD_钱包初始化, int TaskType, ref string cData, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x10);
            StringBuilder builder2 = new StringBuilder(0x10);
            StringBuilder builder3 = new StringBuilder(100);
            StringBuilder builder4 = new StringBuilder(200);
            StringBuilder builder5 = new StringBuilder(200);
            string str = "";
            string linkData = "";
            string str3 = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref oppOutRand))
                {
                    bool flag2 = false;
                    if (!EncryptServerConnect.GetOutRand(8, ref builder2))
                    {
                        return flag;
                    }
                    oppOutRand.Append(builder2);
                    flag2 = false;
                    if (!EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetPurseData, ref builder3, ref builder4, ref cOutData, ref builder5, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData }))
                    {
                        return flag;
                    }
                    string[] strArray = new string[] { "5E", builder3.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString(), (builder5.Length / 2).ToString("X2"), builder5.ToString() };
                    str3 = string.Concat(strArray);
                    if (TaskType == 9)
                    {
                        string[] strArray2 = new string[] { "020206", cData, "5E", builder3.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString(), (builder5.Length / 2).ToString("X2"), builder5.ToString() };
                        linkData = string.Concat(strArray2);
                    }
                    else
                    {
                        linkData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str3 + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                    }
                    ParseData = "";
                    str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                    linkData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + linkData, PublicVariable.TimeTag);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        flag2 = false;
                        flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyReadData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.Meter_NO, oppOutRand, linkData, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.CreateRand(8, oppOutRand) == 0)
            {
                int num = -1;
                num = SocketApi.CreateRand(8, builder2);
                if (num != 0)
                {
                    return flag;
                }
                oppOutRand.Append(builder2);
                if (num != 0)
                {
                    return flag;
                }
                num = -1;
                num = SocketApi.Obj_Meter_Formal_GetPurseData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData, builder3, builder4, cOutData, builder5);
                if (num != 0)
                {
                    return flag;
                }
                string[] strArray4 = new string[] { "5E", builder3.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString(), (builder5.Length / 2).ToString("X2"), builder5.ToString() };
                str3 = string.Concat(strArray4);
                if (TaskType == 9)
                {
                    string[] strArray5 = new string[] { "020206", cData, "5E", builder3.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString(), (builder5.Length / 2).ToString("X2"), builder5.ToString() };
                    linkData = string.Concat(strArray5);
                }
                else
                {
                    linkData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str3 + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                }
                ParseData = "";
                if (num == 0)
                {
                    str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                    linkData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + linkData, PublicVariable.TimeTag);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        num = -1;
                        num = SocketApi.Obj_Meter_Formal_VerifyReadData(PublicVariable.Key_State, 1, PublicVariable.Meter_NO, oppOutRand, linkData, MAC, cOutData);
                        PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                    }
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder builder4 = new StringBuilder(8);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : ("失败" + flag2.ToString())) + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string OAD_Buff, ref List<string> list_OAD_Buff, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder builder4 = new StringBuilder(8);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref list_OAD_Buff, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : ("失败" + flag2.ToString())) + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref list_OAD_Buff, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x5dc);
            StringBuilder builder4 = new StringBuilder(8);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag, ref flag1, ref flag2, ref DARInfo_Buf);
                    if (flag)
                    {
                        bool flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag3 ? "成功" : ("失败" + flag3.ToString())) + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag, ref flag1, ref flag2, ref DARInfo_Buf);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string SEQ_of_Pro, ref List<string> List_OAD_Buff_W, ref List<string> list_DAR_W, ref List<string> Re_ParseData_Action, ref List<string> List_OAD_Buff_R, ref List<List<string>> List_Data_Buff_R, ref List<bool> flag1, ref List<bool> flag2, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x7d0);
            StringBuilder builder4 = new StringBuilder(8);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        bool flag3 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag3 ? "成功" : ("失败" + flag3.ToString())) + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC, ref SpliteFlag);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC_钱包初始化(string Choice_S_M, string Choice_Sec, string OAD_钱包初始化, int TaskType, ref string cData, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            PublicVariable.MAC_Info = "";
            PublicVariable.DARInfo = "";
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(100);
            StringBuilder builder3 = new StringBuilder(0x5dc);
            StringBuilder builder4 = new StringBuilder(8);
            string str = "";
            string linkData = "";
            string cTaskData = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetPurseData, ref builder, ref builder2, ref cOutData, ref builder4, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData }))
                {
                    string[] strArray = new string[] { "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString() };
                    str = string.Concat(strArray);
                    if (TaskType == 9)
                    {
                        string[] strArray2 = new string[] { "020206", cData, "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString() };
                        cTaskData = string.Concat(strArray2);
                    }
                    else
                    {
                        cTaskData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                    }
                    ParseData = "";
                    str = "";
                    cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + cTaskData, PublicVariable.TimeTag);
                    if (EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData }))
                    {
                        object[] objArray3 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                        str = string.Concat(objArray3);
                        linkData = builder3.ToString();
                        flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                        if (flag)
                        {
                            bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                            PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                        }
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetPurseData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), TaskType, cData, builder, builder2, cOutData, builder4) == 0)
            {
                string[] strArray4 = new string[] { "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString() };
                str = string.Concat(strArray4);
                if (TaskType == 9)
                {
                    string[] strArray5 = new string[] { "020206", cData, "5E", builder.ToString(), (builder2.Length / 2).ToString("X2"), builder2.ToString(), (builder4.Length / 2).ToString("X2"), builder4.ToString() };
                    cTaskData = string.Concat(strArray5);
                }
                else
                {
                    cTaskData = "02060F" + ParseData + "06" + cData.Substring(0, 8) + "06" + cData.Substring(8, 8) + "0906" + cData.Substring(0x10, 12) + str + "0906" + PublicVariable.Meter_NO.Substring(2, 12);
                }
                ParseData = "";
                str = "";
                cTaskData = MakeLink_Data("07", "01", PublicVariable.PIID_R.ToString("X2"), OAD_钱包初始化 + cTaskData, PublicVariable.TimeTag);
                if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), cTaskData, builder, builder2, builder3, builder4) == 0)
                {
                    object[] objArray5 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str = string.Concat(objArray5);
                    linkData = builder3.ToString();
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str, ref ParseData, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                        PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 组帧和写请求
        /// </summary>
        /// <param name="DataLen"></param>
        /// <param name="Con_Code"></param>
        /// <param name="meterAdd"></param>
        /// <param name="Client_Add"></param>
        /// <param name="cData"></param>
        /// <param name="TimeTag"></param>
        /// <returns></returns>
        public static bool OrigDLT698Wrap(string DataLen, string Con_Code, string meterAdd, string Client_Add, string cData, bool TimeTag)
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
                string str = "";
                string sData = null;
                string str3 = null;
                short num2 = Convert.ToInt16("0x" + DataLen, 0x10);//除前导字符、校验帧FCS和帧尾外的长度整数
                byte[] array = new byte[num2];
                byte[] buffer2 = new byte[(2 + num2) + PublicVariable.FE_Number];//除帧尾的长度
                int index = 0;
                for(int i = 0; i < PublicVariable.FE_Number; i++)
                {
                    buffer2[index++] = 0xfe;//加前导字符
                }
                array = PublicVariable.HexToByte(PublicVariable.BackString(DataLen));
                buffer2[index] = 0x68;  //帧头
                array.CopyTo(buffer2, (int) (index + 1));
                buffer2[index + 3] = Convert.ToByte("0x" + Con_Code, 0x10);//控制域
                buffer2[index + 4] = Convert.ToByte(meterAdd.Substring(0, 2), 0x10);//服务器地址
                for (int j = 0; j <= ((meterAdd.Length / 2) - 2); j++)
                {
                    str = "0x" + meterAdd.Substring(2 * (((meterAdd.Length / 2) - 1) - j), 2);
                    buffer2[(j + index) + 5] = Convert.ToByte(str, 0x10);
                }
                buffer2[(index + (meterAdd.Length / 2)) + 4] = Convert.ToByte("0x" + Client_Add, 0x10);//客户机地址
                byte[] destinationArray = new byte[4 + (meterAdd.Length / 2)];
                Array.Copy(buffer2, index + 1, destinationArray, 0, 4 + (meterAdd.Length / 2));
                sData = PublicVariable.GetCrc16(destinationArray);//帧头校验HCS
                Array.Clear(array, 0, 2);
                array = PublicVariable.HexToByte(PublicVariable.BackString(sData));
                array.CopyTo(buffer2, (int) ((index + (meterAdd.Length / 2)) + 5));
                byte[] buffer4 = new byte[cData.Length / 2];
                PublicVariable.HexToByte(cData).CopyTo(buffer2, (int) ((index + (meterAdd.Length / 2)) + 7));
                byte[] buffer5 = new byte[(6 + (meterAdd.Length / 2)) + (cData.Length / 2)];
                Array.Copy(buffer2, index + 1, buffer5, 0, num2 - 2);//APDU
                str3 = PublicVariable.GetCrc16(buffer5);//帧校验FCS
                Array.Clear(array, 0, 2);
                PublicVariable.HexToByte(PublicVariable.BackString(str3)).CopyTo(buffer2, (int) ((index + num2) - 1));
                buffer2[(index + num2) + 1] = 0x16;//帧尾
                str = "";//存发送帧
                foreach (byte num5 in buffer2)
                {
                    str = str + string.Format("{0:X2}",num5); 
                }
                PublicVariable.RecDataString = "";//返回帧
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(str));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(str));//485串口写请求
                PublicVariable.BeginRecState = true;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        private static bool OrigExtend(string DataLen, string Con_Code, string meterAdd, string Client_Add, string Extend)
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
                string str = "";
                string sData = null;
                string str3 = null;
                short num2 = Convert.ToInt16("0x" + DataLen, 0x10);
                byte[] array = new byte[num2];
                byte[] buffer2 = new byte[(2 + num2) + PublicVariable.FE_Number];
                int index = 0;
                for (int i = 0; i < PublicVariable.FE_Number; i++)
                {
                    buffer2[index++] = 0xfe;
                }
                array = PublicVariable.HexToByte(PublicVariable.BackString(DataLen));
                buffer2[index] = 0x68;
                array.CopyTo(buffer2, (int) (index + 1));
                buffer2[index + 3] = Convert.ToByte("0x" + Con_Code, 0x10);
                buffer2[index + 4] = Convert.ToByte(meterAdd.Substring(0, 2), 0x10);
                for (int j = 0; j <= 5; j++)
                {
                    str = "0x" + meterAdd.Substring(2 * (6 - j), 2);
                    buffer2[(j + index) + 5] = Convert.ToByte(str, 0x10);
                }
                buffer2[index + 11] = Convert.ToByte("0x" + Client_Add, 0x10);
                byte[] destinationArray = new byte[4 + (meterAdd.Length / 2)];
                Array.Copy(buffer2, index + 1, destinationArray, 0, 4 + (meterAdd.Length / 2));
                sData = PublicVariable.GetCrc16(destinationArray);
                Array.Clear(array, 0, 2);
                array = PublicVariable.HexToByte(PublicVariable.BackString(sData));
                array.CopyTo(buffer2, (int) (index + 12));
                byte[] buffer4 = new byte[Extend.Length / 2];
                PublicVariable.HexToByte(Extend).CopyTo(buffer2, (int) (index + 14));
                byte[] buffer5 = new byte[13 + (Extend.Length / 2)];
                Array.Copy(buffer2, index + 1, buffer5, 0, num2 - 2);
                str3 = PublicVariable.GetCrc16(buffer5);
                Array.Clear(array, 0, 2);
                PublicVariable.HexToByte(PublicVariable.BackString(str3)).CopyTo(buffer2, (int) ((index + num2) - 1));
                buffer2[(index + num2) + 1] = 0x16;
                str = "";
                foreach (byte num5 in buffer2)
                {
                    str = str + string.Format("{0:X2}",num5);
                }
                PublicVariable.RecDataString = "";
                PublicVariable.SendDataString = SerialPortUtil.ByteToHex(SerialPortUtil.HexToByte(str));
                CommParam.comPort.WriteData(SerialPortUtil.HexToByte(str));
                PublicVariable.BeginRecState = true;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static void ParseArray(ref string str, byte Len, ref string data)
        {
            string str2 = "";
            List<string> list = new List<string>();
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref str2);
                list.Add(str2);
            }
            data = string.Join("", list.ToArray());
        }

        public static void ParseStruct(ref string str, byte Len, ref string data)
        {
            string str2 = "";
            List<string> list = new List<string>();
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref str2);
                list.Add(str2);
            }
            data = string.Join("", list.ToArray());
        }
        /// <summary>
        /// 接收帧判断
        /// </summary>
        /// <param name="RecString"></param>
        /// <param name="LinkData"></param>
        /// <param name="bExtend"></param>
        /// <returns></returns>
        public static bool RecIsProtocol(string RecString, ref string LinkData, ref bool bExtend)
        {
            string extend = "";
            List<string> list = new List<string>();
            byte[] sourceArray = SerialPortUtil.HexToByte(RecString);
            if (sourceArray.Length < 12)
            {
                return false;
            }
            int index = 0;
            try
            {
                for (int i = 0; i <= 4; i++)
                {
                    if (sourceArray[i] == 0xfe)
                    {
                        index++;
                    }
                }
                if (sourceArray[index] != 0x68)
                {
                    return false;
                }
                int length = sourceArray.Length;
                if (sourceArray[length - 1] != 0x16)
                {
                    return false;
                }
                byte[] destinationArray = new byte[(sourceArray.Length - index) - 4];
                Array.Copy(sourceArray, index + 1, destinationArray, 0, (sourceArray.Length - index) - 4);
                if (!PublicVariable.GetCrc16(destinationArray).Equals(sourceArray[sourceArray.Length - 2].ToString("X2") + sourceArray[sourceArray.Length - 3].ToString("X2")))
                {
                    return false;
                }
                if ((sourceArray[3 + index] & 0x20) == 0x20)
                {
                    bExtend = true;
                }
                else
                {
                    bExtend = false;
                }
                byte num1 = sourceArray[index + 4];
                for (int j = ((index + 8) + (sourceArray[index + 4] & 15)) + 1; j < (sourceArray.Length - 3); j++)
                {
                    LinkData = LinkData + sourceArray[j].ToString("X2");
                }
                if (bExtend)
                {
                    extend = LinkData.Substring(0, 4);
                    LinkData = LinkData.Substring(4);
                    list.Add(LinkData);
                    while (Convert.ToByte(extend.Substring(2, 2), 0x10) != 0x40)
                    {
                        extend = extend.Substring(0, 2) + "80";
                        if (OrigExtend("0011", "63", PublicVariable.Address, PublicVariable.Client_Add, extend))
                        {
                            CommParam.comPort.comPort_DataReceived();
                        }
                        LinkData = "";
                        if (RecIsProtocol_分帧(PublicVariable.RecDataString, ref LinkData, ref bExtend))
                        {
                            extend = LinkData.Substring(0, 4);
                            LinkData = LinkData.Substring(4);
                            list.Add(LinkData);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    LinkData = string.Join("", list.ToArray());
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool RecIsProtocol(string RecString, ref string getAddress, ref string LinkData, ref bool bExtend)
        {
            string extend = "";
            List<string> list = new List<string>();
            byte[] sourceArray = SerialPortUtil.HexToByte(RecString);
            if (sourceArray.Length < 12)
            {
                return false;
            }
            int index = 0;
            try
            {
                for (int i = 0; i <= 4; i++)
                {
                    if (sourceArray[i] == 0xfe)
                    {
                        index++;
                    }
                }
                if (sourceArray[index] != 0x68)
                {
                    return false;
                }
                int length = sourceArray.Length;
                if (sourceArray[length - 1] != 0x16)
                {
                    return false;
                }
                byte[] destinationArray = new byte[(sourceArray.Length - index) - 4];
                Array.Copy(sourceArray, index + 1, destinationArray, 0, (sourceArray.Length - index) - 4);
                if (!PublicVariable.GetCrc16(destinationArray).Equals(sourceArray[sourceArray.Length - 2].ToString("X2") + sourceArray[sourceArray.Length - 3].ToString("X2")))
                {
                    return false;
                }
                for (int j = 0; j < 6; j++)
                {
                    getAddress = sourceArray[(index + j) + 5].ToString("X2") + getAddress;
                }
                getAddress = "05" + getAddress;
                if ((sourceArray[3 + index] & 0x20) == 0x20)
                {
                    bExtend = true;
                }
                else
                {
                    bExtend = false;
                }
                byte num1 = sourceArray[index + 4];
                for (int k = ((index + 8) + (sourceArray[index + 4] & 15)) + 1; k < (sourceArray.Length - 3); k++)
                {
                    LinkData = LinkData + sourceArray[k].ToString("X2");
                }
                if (bExtend)
                {
                    extend = LinkData.Substring(0, 4);
                    LinkData = LinkData.Substring(4);
                    list.Add(LinkData);
                    while (Convert.ToByte(extend.Substring(2, 2), 0x10) != 0x40)
                    {
                        extend = extend.Substring(0, 2) + "80";
                        if (OrigExtend("0011", "63", PublicVariable.Address, PublicVariable.Client_Add, extend))
                        {
                            CommParam.comPort.comPort_DataReceived();
                        }
                        LinkData = "";
                        if (RecIsProtocol_分帧(PublicVariable.RecDataString, ref LinkData, ref bExtend))
                        {
                            extend = LinkData.Substring(0, 4);
                            LinkData = LinkData.Substring(4);
                            list.Add(LinkData);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    LinkData = string.Join("", list.ToArray());
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool RecIsProtocol_分帧(string RecString, ref string LinkData, ref bool bExtend)
        {
            byte[] sourceArray = SerialPortUtil.HexToByte(RecString);
            if (sourceArray.Length < 12)
            {
                return false;
            }
            int index = 0;
            try
            {
                for (int i = 0; i <= 4; i++)
                {
                    if (sourceArray[i] == 0xfe)
                    {
                        index++;
                    }
                }
                if (sourceArray[index] != 0x68)
                {
                    return false;
                }
                int length = sourceArray.Length;
                if (sourceArray[length - 1] != 0x16)
                {
                    return false;
                }
                byte[] destinationArray = new byte[(sourceArray.Length - index) - 4];
                Array.Copy(sourceArray, index + 1, destinationArray, 0, (sourceArray.Length - index) - 4);
                if (!PublicVariable.GetCrc16(destinationArray).Equals(sourceArray[sourceArray.Length - 2].ToString("X2") + sourceArray[sourceArray.Length - 3].ToString("X2")))
                {
                    return false;
                }
                if ((sourceArray[3 + index] & 0x20) == 0x20)
                {
                    bExtend = true;
                }
                else
                {
                    bExtend = false;
                }
                byte num1 = sourceArray[index + 4];
                for (int j = ((index + 8) + (sourceArray[index + 4] & 15)) + 1; j < (sourceArray.Length - 3); j++)
                {
                    LinkData = LinkData + sourceArray[j].ToString("X2");
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                bool timeTag = false;
                string str = "10";
                string cData = "";
                string str4 = "";
                string str5 = "";
                int num = -1;
                string str6 = "";
                str4 = PublicVariable.calc_Octlen(LinkData.Length);
                cData = str + Choice_S_M + str4 + LinkData + Choice_Sec + Sec_Validtion;
                int num2 = cData.Length / (2 * (PublicVariable.sumOfbit - 0x13));
                if (num2 >= 1)
                {
                    Con_Code = "63";
                    for (int i = 0; i <= num2; i++)
                    {
                        if (cData.Length > ((PublicVariable.sumOfbit - 0x13) * 2))
                        {
                            num++;
                            if (i == 0)
                            {
                                str6 = "00";
                            }
                            else
                            {
                                str6 = "C0";
                            }
                            str5 = num.ToString("X2") + str6 + cData.Substring(0, (PublicVariable.sumOfbit - 0x13) * 2);
                            cData = cData.Substring((PublicVariable.sumOfbit - 0x13) * 2);
                        }
                        else
                        {
                            num++;
                            str6 = "40";
                            str5 = num.ToString("X2") + str6 + cData.Substring(0);
                        }
                        short num4 = (short) ((8 + (meterAdd.Length / 2)) + (str5.Length / 2));
                        if (OrigDLT698Wrap(num4.ToString("X4"), Con_Code, meterAdd, Client_Add, str5, timeTag))
                        {
                            CommParam.comPort.comPort_DataReceived();
                        }
                        else
                        {
                            PublicVariable.ChangedFlag = true;
                            return false;
                        }
                    }
                }
                else
                {
                    Con_Code = "43";
                    short num5 = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (OrigDLT698Wrap(num5.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, timeTag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str7 = "";
                    LinkData = "";
                    string str8 = "";
                    List<string> list = new List<string>();
                    if (RecIsProtocol(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                    {
                        flag = SECURITY_Response(ref LinkData, ref str7, ref str8, ref list, ref ParseData, ref List_ParseData, ref MAC);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string OAD_Str, ref List<string> List_OAD_Str, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                bool timeTag = false;
                string str = "10";
                string cData = "";
                string str4 = "";
                string str5 = "";
                int num = -1;
                string str6 = "";
                str4 = PublicVariable.calc_Octlen(LinkData.Length);
                cData = str + Choice_S_M + str4 + LinkData + Choice_Sec + Sec_Validtion;
                int num2 = cData.Length / (2 * (PublicVariable.sumOfbit - 0x13));
                if (num2 >= 1)
                {
                    Con_Code = "63";
                    for (int i = 0; i <= num2; i++)
                    {
                        if (cData.Length > ((PublicVariable.sumOfbit - 0x13) * 2))
                        {
                            num++;
                            if (i == 0)
                            {
                                str6 = "00";
                            }
                            else
                            {
                                str6 = "C0";
                            }
                            str5 = num.ToString("X2") + str6 + cData.Substring(0, (PublicVariable.sumOfbit - 0x13) * 2);
                            cData = cData.Substring((PublicVariable.sumOfbit - 0x13) * 2);
                        }
                        else
                        {
                            num++;
                            str6 = "40";
                            str5 = num.ToString("X2") + str6 + cData.Substring(0);
                        }
                        short num4 = (short) ((8 + (meterAdd.Length / 2)) + (str5.Length / 2));
                        if (OrigDLT698Wrap(num4.ToString("X4"), Con_Code, meterAdd, Client_Add, str5, timeTag))
                        {
                            CommParam.comPort.comPort_DataReceived();
                        }
                        else
                        {
                            PublicVariable.ChangedFlag = true;
                            return false;
                        }
                    }
                }
                else
                {
                    Con_Code = "43";
                    short num5 = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (OrigDLT698Wrap(num5.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, timeTag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str7 = "";
                    LinkData = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                    {
                        flag = SECURITY_Response(ref LinkData, ref str7, ref OAD_Str, ref List_OAD_Str, ref ParseData, ref List_ParseData, ref MAC);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SplitFlag, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                bool timeTag = false;
                string str = "10";
                string cData = "";
                string str4 = "";
                str4 = PublicVariable.calc_Octlen(LinkData.Length);
                cData = str + Choice_S_M + str4 + LinkData + Choice_Sec + Sec_Validtion;
                short num = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                if (OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, timeTag))
                {
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    PublicVariable.ChangedFlag = true;
                    return false;
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str5 = "";
                    LinkData = "";
                    string str6 = "";
                    List<string> list = new List<string>();
                    if (RecIsProtocol(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                    {
                        flag = SECURITY_Response(ref LinkData, ref str5, ref str6, ref list, ref ParseData, ref List_ParseData, ref MAC, ref flag1, ref flag2, ref DARInfo_Buf);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string SEQ_of_Pro, ref List<string> List_OAD_Buff_W, ref List<string> list_DAR_W, ref List<string> Re_ParseData_Action, ref List<string> List_OAD_Buff_R, ref List<List<string>> List_Data_Buff_R, ref List<bool> flag1, ref List<bool> flag2, ref string MAC, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                bool timeTag = false;
                string str = "10";
                string cData = "";
                string str4 = "";
                string str5 = "";
                int num = -1;
                string str6 = "";
                str4 = PublicVariable.calc_Octlen(LinkData.Length);
                cData = str + Choice_S_M + str4 + LinkData + Choice_Sec + Sec_Validtion;
                int num2 = cData.Length / (2 * (PublicVariable.sumOfbit - 0x13));
                if (num2 >= 1)
                {
                    Con_Code = "63";
                    for (int i = 0; i <= num2; i++)
                    {
                        if (cData.Length > ((PublicVariable.sumOfbit - 0x13) * 2))
                        {
                            num++;
                            if (i == 0)
                            {
                                str6 = "00";
                            }
                            else
                            {
                                str6 = "C0";
                            }
                            str5 = num.ToString("X2") + str6 + cData.Substring(0, (PublicVariable.sumOfbit - 0x13) * 2);
                            cData = cData.Substring((PublicVariable.sumOfbit - 0x13) * 2);
                        }
                        else
                        {
                            num++;
                            str6 = "40";
                            str5 = num.ToString("X2") + str6 + cData.Substring(0);
                        }
                        short num4 = (short) ((8 + (meterAdd.Length / 2)) + (str5.Length / 2));
                        if (OrigDLT698Wrap(num4.ToString("X4"), Con_Code, meterAdd, Client_Add, str5, timeTag))
                        {
                            CommParam.comPort.comPort_DataReceived();
                        }
                        else
                        {
                            PublicVariable.ChangedFlag = true;
                            return false;
                        }
                    }
                }
                else
                {
                    Con_Code = "43";
                    short num5 = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (OrigDLT698Wrap(num5.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, timeTag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    LinkData = "";
                    new List<string>();
                    if (RecIsProtocol(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                    {
                        flag = SECURITY_Response(ref LinkData, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2, ref MAC);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Request_分帧(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                bool timeTag = false;
                string str = "10";
                string str2 = "";
                string cData = "";
                string str5 = "";
                int num = -1;
                string str6 = "";
                str5 = PublicVariable.calc_Octlen(LinkData.Length);
                str2 = str + Choice_S_M + str5 + LinkData + Choice_Sec + Sec_Validtion;
                int num2 = str2.Length / (2 * (PublicVariable.sumOfbit - 0x13));
                for (int i = 0; i <= num2; i++)
                {
                    if (str2.Length > ((PublicVariable.sumOfbit - 0x13) * 2))
                    {
                        num++;
                        if (i == 0)
                        {
                            str6 = "00";
                        }
                        else
                        {
                            str6 = "C0";
                        }
                        cData = num.ToString("X2") + str6 + str2.Substring(0, (PublicVariable.sumOfbit - 0x13) * 2);
                        str2 = str2.Substring((PublicVariable.sumOfbit - 0x13) * 2);
                    }
                    else
                    {
                        num++;
                        str6 = "40";
                        cData = num.ToString("X2") + str6 + str2.Substring(0);
                    }
                    short num4 = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (OrigDLT698Wrap(num4.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, timeTag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                    if (PublicVariable.RecDataString.Length > 0)
                    {
                        string str7 = "";
                        LinkData = "";
                        string str8 = "";
                        List<string> list = new List<string>();
                        if (RecIsProtocol_分帧(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                        {
                            flag = SECURITY_Response_分帧(ref LinkData, ref str7, ref str8, ref list, ref ParseData, ref List_ParseData, ref MAC);
                            PublicVariable.SplitFlag = SplitFlag;
                            PublicVariable.ChangedFlag = true;
                            if (!flag)
                            {
                                return flag;
                            }
                        }
                    }
                    PublicVariable.ChangedFlag = true;
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Response(ref string LinkStr, ref string PIID_Buff, ref string OAD_Buff, ref List<string> List_OAD_Buff, ref string ParseData, ref List<string> List_ParseData, ref string MAC)
        {
            try
            {
                if (LinkStr.Length < 8)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                bool flag = false;
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                byte num = buffer[1];
                string linkData = "";
                byte num2 = 0;
                int num3 = 0;
                int num4 = 0;
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    ParseData = "";
                    flag = false;
                }
                else
                {
                    if (buffer[2] > 0x7f)
                    {
                        num3 = buffer[2] & 15;
                        num4 = Convert.ToInt32(LinkStr.Substring(6, num3 * 2), 0x10);
                    }
                    else
                    {
                        num4 = buffer[2];
                    }
                    linkData = LinkStr.Substring(6 + (num3 * 2), num4 * 2);
                    if (num == 0)
                    {
                        PIID_Buff = buffer[5].ToString("X2");
                        if (buffer[4 + num3] == 1)
                        {
                            ParseData = "";
                            switch (buffer[3 + num3])
                            {
                                case 0x85:
                                    flag = GetResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;

                                case 0x86:
                                    flag = SetResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;

                                case 0x87:
                                    flag = ActionResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;
                            }
                            List_OAD_Buff.Add(OAD_Buff);
                            if (buffer.Length >= ((num4 + num3) + 4))
                            {
                                if (buffer[((num4 + num3) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num4 + num3) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num4 + num3) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                        else if (buffer[4 + num3] == 2)
                        {
                            switch (buffer[3 + num3])
                            {
                                case 0x85:
                                    flag = GetResponseNormalList(linkData, ref PIID_Buff, ref List_OAD_Buff, ref List_ParseData);
                                    break;

                                case 0x86:
                                    flag = SetResponseNormalList(linkData, ref PIID_Buff, ref num2, ref List_OAD_Buff, ref List_ParseData, ref ParseData);
                                    break;
                            }
                            if (buffer.Length >= ((num4 + num3) + 4))
                            {
                                if (buffer[((num4 + num3) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num4 + num3) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num4 + num3) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                    }
                    else if (num == 1)
                    {
                        ParseData = "";
                        if (buffer.Length >= ((num4 + num3) + 4))
                        {
                            if (buffer[((num4 + num3) + 2) + 1] == 1)
                            {
                                MAC = LinkStr.Substring((((num4 + num3) + 2) + 4) * 2, 8);
                            }
                            else if (buffer[((num4 + num3) + 2) + 1] == 0)
                            {
                                MAC = "";
                            }
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            MessageBox.Show("返回帧有误，请检查");
                        }
                    }
                    LinkStr = LinkStr.Substring(6 + (num3 * 2), num4 * 2);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Response(ref string LinkStr, ref string SEQ_of_Pro, ref List<string> List_OAD_Buff_W, ref List<string> list_DAR_W, ref List<string> Re_ParseData_Action, ref List<string> List_OAD_Buff_R, ref List<List<string>> List_Data_Buff_R, ref List<bool> flag1, ref List<bool> flag2, ref string MAC)
        {
            try
            {
                if (LinkStr.Length < 8)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "";
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                byte num = buffer[1];
                string recStr = "";
                int num2 = 0;
                int num3 = 0;
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    flag = false;
                }
                else
                {
                    if (buffer[2] > 0x7f)
                    {
                        num2 = buffer[2] & 15;
                        num3 = Convert.ToInt32(LinkStr.Substring(6, num2 * 2), 0x10);
                    }
                    else
                    {
                        num3 = buffer[2];
                    }
                    recStr = LinkStr.Substring(6 + (num2 * 2), num3 * 2);
                    if (num == 0)
                    {
                        str = buffer[5].ToString("X2");
                        if (buffer[4 + num2] == 1)
                        {
                            switch (buffer[3 + num2])
                            {
                            }
                            if (buffer.Length >= ((num3 + num2) + 4))
                            {
                                if (buffer[((num3 + num2) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num3 + num2) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num3 + num2) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                        else if (buffer[4 + num2] == 2)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x87:
                                    flag = ActionResponseNormalList(recStr, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action);
                                    break;
                            }
                            if (buffer.Length >= ((num3 + num2) + 4))
                            {
                                if (buffer[((num3 + num2) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num3 + num2) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num3 + num2) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                        else if (buffer[4 + num2] == 3)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x86:
                                    flag = SetThenGetResponseNormalList(recStr, ref str, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                    break;

                                case 0x87:
                                    flag = ActionThenGetResponseNormalList(recStr, ref SEQ_of_Pro, ref List_OAD_Buff_W, ref list_DAR_W, ref Re_ParseData_Action, ref List_OAD_Buff_R, ref List_Data_Buff_R, ref flag1, ref flag2);
                                    break;
                            }
                            if (buffer.Length >= ((num3 + num2) + 4))
                            {
                                if (buffer[((num3 + num2) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num3 + num2) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num3 + num2) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                    }
                    else if (num == 1)
                    {
                        if (buffer.Length >= ((num3 + num2) + 4))
                        {
                            if (buffer[((num3 + num2) + 2) + 1] == 1)
                            {
                                MAC = LinkStr.Substring((((num3 + num2) + 2) + 4) * 2, 8);
                            }
                            else if (buffer[((num3 + num2) + 2) + 1] == 0)
                            {
                                MAC = "";
                            }
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            MessageBox.Show("返回帧有误，请检查");
                        }
                    }
                    LinkStr = LinkStr.Substring(6 + (num2 * 2), num3 * 2);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Response(ref string LinkStr, ref string PIID_Buff, ref string OAD_Buff, ref List<string> List_OAD_Buff, ref string ParseData, ref List<string> List_ParseData, ref string MAC, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf)
        {
            try
            {
                if (LinkStr.Length < 8)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                bool flag = false;
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                byte num = buffer[1];
                string linkData = "";
                byte num2 = 0;
                int num3 = 0;
                int num4 = 0;
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    ParseData = "";
                    flag = false;
                }
                else
                {
                    if (buffer[2] > 0x7f)
                    {
                        num3 = buffer[2] & 15;
                        num4 = Convert.ToInt32(LinkStr.Substring(6, num3 * 2), 0x10);
                    }
                    else
                    {
                        num4 = buffer[2];
                    }
                    linkData = LinkStr.Substring(6 + (num3 * 2), num4 * 2);
                    if (num == 0)
                    {
                        PIID_Buff = buffer[5].ToString("X2");
                        if (buffer[4 + num3] == 1)
                        {
                            ParseData = "";
                            switch (buffer[3 + num3])
                            {
                                case 0x85:
                                    flag = GetResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;

                                case 0x86:
                                    flag = SetResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;

                                case 0x87:
                                    flag = ActionResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;
                            }
                            List_OAD_Buff.Add(OAD_Buff);
                            if (buffer.Length >= ((num4 + num3) + 4))
                            {
                                if (buffer[((num4 + num3) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num4 + num3) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num4 + num3) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                        else if (buffer[4 + num3] == 2)
                        {
                            switch (buffer[3 + num3])
                            {
                                case 0x85:
                                    flag = GetResponseNormalList(linkData, ref PIID_Buff, ref List_OAD_Buff, ref List_ParseData);
                                    break;

                                case 0x86:
                                    flag = SetResponseNormalList(linkData, ref PIID_Buff, ref num2, ref List_OAD_Buff, ref List_ParseData, ref ParseData);
                                    break;
                            }
                            if (buffer.Length >= ((num4 + num3) + 4))
                            {
                                if (buffer[((num4 + num3) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num4 + num3) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num4 + num3) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                        else if (buffer[4 + num3] == 3)
                        {
                            switch (buffer[3 + num3])
                            {
                                case 0x86:
                                    flag = SetThenGetResponseNormalList(linkData, ref PIID_Buff, ref num2, ref list, ref list2, ref List_ParseData, ref ParseData, ref flag1, ref flag2, ref DARInfo_Buf);
                                    break;
                            }
                            if (buffer.Length >= ((num4 + num3) + 4))
                            {
                                if (buffer[((num4 + num3) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num4 + num3) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num4 + num3) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                    }
                    else if (num == 1)
                    {
                        ParseData = "";
                        if (buffer.Length >= ((num4 + num3) + 4))
                        {
                            if (buffer[((num4 + num3) + 2) + 1] == 1)
                            {
                                MAC = LinkStr.Substring((((num4 + num3) + 2) + 4) * 2, 8);
                            }
                            else if (buffer[((num4 + num3) + 2) + 1] == 0)
                            {
                                MAC = "";
                            }
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            MessageBox.Show("返回帧有误，请检查");
                        }
                    }
                    LinkStr = LinkStr.Substring(6 + (num3 * 2), num4 * 2);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SECURITY_Response_分帧(ref string LinkStr, ref string PIID_Buff, ref string OAD_Buff, ref List<string> List_OAD_Buff, ref string ParseData, ref List<string> List_ParseData, ref string MAC)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                if (LinkStr.Length < 8)
                {
                    return (LinkStr.Substring(2, 2) == "80");
                }
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                byte num = buffer[1];
                string linkData = "";
                int num2 = 0;
                int num3 = 0;
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    ParseData = "";
                    flag = false;
                }
                else
                {
                    if (buffer[2] > 0x7f)
                    {
                        num2 = buffer[2] & 15;
                        num3 = Convert.ToInt32(LinkStr.Substring(6, num2 * 2), 0x10);
                    }
                    else
                    {
                        num3 = buffer[2];
                    }
                    linkData = LinkStr.Substring(6 + (num2 * 2), num3 * 2);
                    if (num == 0)
                    {
                        PIID_Buff = buffer[5].ToString("X2");
                        if (buffer[4 + num2] == 1)
                        {
                            ParseData = "";
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    flag = GetResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;

                                case 0x86:
                                    flag = SetResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;

                                case 0x87:
                                    flag = ActionResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref ParseData);
                                    break;
                            }
                            List_OAD_Buff.Add(OAD_Buff);
                            if (buffer.Length >= ((num3 + num2) + 4))
                            {
                                if (buffer[((num3 + num2) + 2) + 1] == 1)
                                {
                                    MAC = LinkStr.Substring((((num3 + num2) + 2) + 4) * 2, 8);
                                }
                                else if (buffer[((num3 + num2) + 2) + 1] == 0)
                                {
                                    MAC = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("返回帧有误，请检查");
                            }
                        }
                    }
                    else if (num == 1)
                    {
                        ParseData = "";
                        if (buffer.Length >= ((num3 + num2) + 4))
                        {
                            if (buffer[((num3 + num2) + 2) + 1] == 1)
                            {
                                MAC = LinkStr.Substring((((num3 + num2) + 2) + 4) * 2, 8);
                            }
                            else if (buffer[((num3 + num2) + 2) + 1] == 0)
                            {
                                MAC = "";
                            }
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            MessageBox.Show("返回帧有误，请检查");
                        }
                    }
                    LinkStr = LinkStr.Substring(6 + (num2 * 2), num3 * 2);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetRequestNormal(string Con_Code, string meterAdd, string Client_Add, string OAD_Buff, string cData, bool TimeFlag, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "06";
                string str2 = "01";
                string str3 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                string str5 = "";
                int num = -1;
                string str6 = "";
                str3 = str + str2 + PublicVariable.PIID_W.ToString("X2") + OAD_Buff + cData;
                if (TimeFlag)
                {
                    str3 = str3 + "01" + PublicVariable.TimeText;
                }
                else
                {
                    str3 = str3 + "00";
                }
                int num2 = str3.Length / (2 * (PublicVariable.sumOfbit - 0x13));
                if (num2 >= 1)
                {
                    Con_Code = "63";
                    for (int i = 0; i <= num2; i++)
                    {
                        if (str3.Length > ((PublicVariable.sumOfbit - 0x13) * 2))
                        {
                            num++;
                            if (i == 0)
                            {
                                str6 = "00";
                            }
                            else
                            {
                                str6 = "C0";
                            }
                            str5 = num.ToString("X2") + str6 + str3.Substring(0, (PublicVariable.sumOfbit - 0x13) * 2);
                            str3 = str3.Substring((PublicVariable.sumOfbit - 0x13) * 2);
                        }
                        else
                        {
                            num++;
                            str6 = "40";
                            str5 = num.ToString("X2") + str6 + str3.Substring(0);
                        }
                        short num4 = (short) ((8 + (meterAdd.Length / 2)) + (str5.Length / 2));
                        if (OrigDLT698Wrap(num4.ToString("X4"), Con_Code, meterAdd, Client_Add, str5, TimeFlag))
                        {
                            CommParam.comPort.comPort_DataReceived();
                            PublicVariable.ChangedFlag = true;
                        }
                        else
                        {
                            PublicVariable.ChangedFlag = true;
                            return false;
                        }
                    }
                }
                else
                {
                    Con_Code = "43";
                    short num5 = (short) ((8 + (meterAdd.Length / 2)) + (str3.Length / 2));
                    if (OrigDLT698Wrap(num5.ToString("X4"), Con_Code, meterAdd, Client_Add, str3, TimeFlag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    string str7 = "";
                    string parseData = "";
                    cData = "";
                    OAD_Buff = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = SetResponseNormal(cData, ref str7, ref OAD_Buff, ref parseData);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetRequestNormalList(byte SEQ_of_OAD, string Con_Code, string meterAdd, string Client_Add, string cData, ref List<string> List_ParseData, bool TimeFlag, ref bool SplitFlag)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "06";
                string str2 = "02";
                string str3 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str3 = str + str2 + PublicVariable.PIID_W.ToString("X2") + SEQ_of_OAD.ToString("X2") + cData;
                if (TimeFlag)
                {
                    str3 = str3 + "01" + PublicVariable.TimeText;
                    short num2 = (short) ((8 + (meterAdd.Length / 2)) + (str3.Length / 2));
                    if (!OrigDLT698Wrap(num2.ToString("X4"), Con_Code, meterAdd, Client_Add, str3, TimeFlag))
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    str3 = str3 + "00";
                    short num3 = (short) ((8 + (meterAdd.Length / 2)) + (str3.Length / 2));
                    if (OrigDLT698Wrap(num3.ToString("X4"), Con_Code, meterAdd, Client_Add, str3, TimeFlag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    byte num = 0;
                    string str5 = "";
                    string followReportAndTime = "";
                    List<string> list = new List<string>();
                    cData = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = SetResponseNormalList(cData, ref str5, ref num, ref list, ref List_ParseData, ref followReportAndTime);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetResponseNormal(string RecStr, ref string PIID_Buff, ref string OAD_Buff, ref string ParseData)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                if (RecStr.Length >= 20)
                {
                    byte[] buffer = PublicVariable.HexToByte(RecStr);
                    PIID_Buff = buffer[2].ToString("X2");
                    OAD_Buff = RecStr.Substring(6, 8);
                    ParseData = RecStr.Substring(0x10);
                    PublicVariable.DARInfo = "---" + OAD_Buff + ((DAR) buffer[7]).ToString();
                    if (buffer[7] == 0)
                    {
                        FollowReportAndTimeTag(ParseData);
                        return true;
                    }
                    FollowReportAndTimeTag(ParseData);
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetResponseNormalList(string LinkStr, ref string PIID_Buff, ref byte SEQ_Of_OAD, ref List<string> List_OAD_Buff, ref List<string> List_ParseData, ref string FollowReportAndTime)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                if (LinkStr.Length < 20)
                {
                    return false;
                }
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                bool flag = true;
                PIID_Buff = buffer[2].ToString("X2");
                SEQ_Of_OAD = buffer[3];
                LinkStr = LinkStr.Substring(8);
                for (int i = 0; i < SEQ_Of_OAD; i++)
                {
                    List_OAD_Buff.Add(LinkStr.Substring(0, 8));
                    List_ParseData.Add(LinkStr.Substring(8, 2));
                    if (Convert.ToByte(LinkStr.Substring(8, 2), 0x10) != 0)
                    {
                        PublicVariable.DARInfo = PublicVariable.DARInfo + "-" + List_OAD_Buff[i].ToString() + ((DAR) Convert.ToByte(LinkStr.Substring(8, 2), 0x10)).ToString() + "-";
                        flag = false;
                    }
                    LinkStr = LinkStr.Substring(10);
                }
                FollowReportAndTime = LinkStr.Substring(0);
                FollowReportAndTimeTag(FollowReportAndTime);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetResponseNormalList_wrop(string LinkStr, ref string PIID_Buff, ref byte SEQ_Of_OAD, ref List<string> List_OAD_Buff, ref List<string> List_ParseData, ref string FollowReportAndTime)
        {
            try
            {
                PublicVariable.DARInfo = "";
                if (LinkStr.Length < 20)
                {
                    return false;
                }
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                PIID_Buff = buffer[2].ToString("X2");
                SEQ_Of_OAD = buffer[3];
                LinkStr = LinkStr.Substring(8);
                for (int i = 0; i < SEQ_Of_OAD; i++)
                {
                    List_OAD_Buff.Add(LinkStr.Substring(0, 8));
                    List_ParseData.Add(LinkStr.Substring(8, 2));
                    if (Convert.ToByte(LinkStr.Substring(8, 2), 0x10) != 0)
                    {
                        PublicVariable.DARInfo = PublicVariable.DARInfo + "-" + List_OAD_Buff[i].ToString() + ((DAR) Convert.ToByte(LinkStr.Substring(8, 2), 0x10)).ToString() + "-";
                    }
                    LinkStr = LinkStr.Substring(10);
                }
                FollowReportAndTime = LinkStr.Substring(0);
                FollowReportAndTimeTag(FollowReportAndTime);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetThenGetRequestNormalList(byte SEQ_of_OAD, string Con_Code, string meterAdd, string Client_Add, string cData, ref List<string> list_Data_R, bool TimeFlag, ref bool SplitFlag, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf)
        {
            try
            {
                PublicVariable.DARInfo = "";
                bool flag = false;
                string str = "06";
                string str2 = "03";
                string str3 = "";
                PublicVariable.PIID_W = (byte) (PublicVariable.PIID_W + 1);
                str3 = str + str2 + PublicVariable.PIID_W.ToString("X2") + SEQ_of_OAD.ToString("X2") + cData;
                if (TimeFlag)
                {
                    str3 = str3 + "01" + PublicVariable.TimeText;
                    short num2 = (short) ((8 + (meterAdd.Length / 2)) + (str3.Length / 2));
                    if (!OrigDLT698Wrap(num2.ToString("X4"), Con_Code, meterAdd, Client_Add, str3, TimeFlag))
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    str3 = str3 + "00";
                    short num3 = (short) ((8 + (meterAdd.Length / 2)) + (str3.Length / 2));
                    if (OrigDLT698Wrap(num3.ToString("X4"), Con_Code, meterAdd, Client_Add, str3, TimeFlag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if (PublicVariable.RecDataString.Length > 0)
                {
                    byte num = 0;
                    string str5 = "";
                    string followReportAndTime = "";
                    List<string> list = new List<string>();
                    List<string> list2 = new List<string>();
                    cData = "";
                    if (RecIsProtocol(PublicVariable.RecDataString, ref cData, ref SplitFlag))
                    {
                        flag = SetThenGetResponseNormalList(cData, ref str5, ref num, ref list, ref list2, ref list_Data_R, ref followReportAndTime, ref flag1, ref flag2, ref DARInfo_Buf);
                        PublicVariable.SplitFlag = SplitFlag;
                        PublicVariable.ChangedFlag = true;
                        return flag;
                    }
                }
                PublicVariable.ChangedFlag = true;
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetThenGetResponseNormalList(string LinkStr, ref string PIID_Buff, ref string SEQ_Of_OAD, ref List<string> List_OAD_Buff_W, ref List<string> list_DAR_W, ref List<string> List_OAD_Buff_R, ref List<List<string>> List_Data_Buff_R, ref List<bool> flag1, ref List<bool> flag2)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                if (LinkStr.Length < 0x20)
                {
                    return false;
                }
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                PIID_Buff = buffer[2].ToString("X2");
                SEQ_Of_OAD = buffer[3].ToString();
                string str = "";
                LinkStr = LinkStr.Substring(8);
                for (int i = 0; i < buffer[3]; i++)
                {
                    List_OAD_Buff_W.Add(LinkStr.Substring(0, 8));
                    list_DAR_W.Add(LinkStr.Substring(8, 2));
                    if (Convert.ToByte(LinkStr.Substring(8, 2)) != 0)
                    {
                        PublicVariable.DARInfo = PublicVariable.DARInfo + "--" + List_OAD_Buff_W[i].ToString() + ((DAR) Convert.ToByte(LinkStr.Substring(8, 2), 0x10)).ToString() + "-";
                        flag1.Add(false);
                    }
                    else
                    {
                        flag1.Add(true);
                    }
                    LinkStr = LinkStr.Substring(10);
                    str = "";
                    List<string> data = new List<string>();
                    if (Protocol_2.A_Result(ref LinkStr, ref str, ref data))
                    {
                        flag2.Add(true);
                        List_OAD_Buff_R.Add(str);
                        List_Data_Buff_R.Add(data);
                    }
                    else
                    {
                        flag2.Add(false);
                        List_OAD_Buff_R.Add(str);
                        List_Data_Buff_R.Add(data);
                    }
                }
                LinkStr = LinkStr.Substring(0);
                FollowReportAndTimeTag(LinkStr);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool SetThenGetResponseNormalList(string LinkStr, ref string PIID_Buff, ref byte SEQ_Of_OAD, ref List<string> List_OAD_Buff_W, ref List<string> List_OAD_Buff_R, ref List<string> List_Data_Buff_R, ref string FollowReportAndTime, ref bool[] flag1, ref bool[] flag2, ref string DARInfo_Buf)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                DARInfo_Buf = "";
                if (LinkStr.Length < 20)
                {
                    return false;
                }
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                PIID_Buff = buffer[2].ToString("X2");
                SEQ_Of_OAD = buffer[3];
                string str = "";
                string data = "";
                LinkStr = LinkStr.Substring(8);
                for (int i = 0; i < SEQ_Of_OAD; i++)
                {
                    List_OAD_Buff_W.Add(LinkStr.Substring(0, 8));
                    if (Convert.ToByte(LinkStr.Substring(8, 2)) != 0)
                    {
                        DARInfo_Buf = DARInfo_Buf + "--" + List_OAD_Buff_W[i].ToString() + ((DAR) Convert.ToByte(LinkStr.Substring(8, 2), 0x10)).ToString() + "-";
                        flag1[i] = false;
                    }
                    else
                    {
                        flag1[i] = true;
                    }
                    LinkStr = LinkStr.Substring(10);
                    str = "";
                    data = "";
                    if (A_Result(ref LinkStr, ref str, ref data))
                    {
                        flag2[i] = true;
                        List_Data_Buff_R.Add(data);
                    }
                    else
                    {
                        flag2[i] = false;
                    }
                }
                FollowReportAndTime = LinkStr.Substring(0);
                FollowReportAndTimeTag(FollowReportAndTime);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }
    }
}

