
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ht_698._45.UI;
using EncryptServerConnect;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace ht_698._45
{
    internal class Protocol_2
    {
        public static bool A_Result(ref string str, ref string OAD_Buff, ref List<List<string>> data)
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
                    List<string> item = new List<string> { "" };
                    data.Add(item);
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool A_Result(ref string str, ref string OAD_Buff, ref List<string> data)
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
                    data.Add("");
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool A_Result(ref string str, ref string OAD_Buff, ref List<string> data, TreeList mytreelist, TreeListNode rootnode)
        {
            try
            {
                if (str.Length >= 8)
                {
                    OAD_Buff = str.Substring(0, 8);
                    if (str.Substring(8, 2) == "01")
                    {
                        str = str.Substring(10);
                        AnalyDataType(ref str, ref data, mytreelist, rootnode);
                        return true;
                    }
                    PublicVariable.DARInfo = "-" + PublicVariable.DARInfo + OAD_Buff + ((DAR) Convert.ToByte(str.Substring(10, 2), 0x10)).ToString() + "-";
                    str = str.Substring(12);
                    data.Add("");
                    mytreelist.AppendNode(new object[] { "" }, rootnode);
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool AnalyDataType(ref string str, ref List<List<string>> data)
        {
            List<string> item = new List<string>();
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] buffer = PublicVariable.HexToByte(str);
            string str2 = "";
            switch (((DataType) buffer[0]))
            {
                case DataType.NULL:
                    item.Add("");
                    data.Add(item);
                    str = str.Substring(2);
                    goto Label_0736;

                case DataType.Array:
                    str = str.Substring(4);
                    ParseArray(ref str, buffer[1], ref data);
                    goto Label_0736;

                case DataType.Structure:
                    str = str.Substring(4);
                    ParseStruct(ref str, buffer[1], ref data);
                    goto Label_0736;

                case DataType.Bool:
                    item.Add(str.Substring(2, 2));
                    data.Add(item);
                    str = str.Substring(4);
                    goto Label_0736;

                case DataType.Bitstring:
                {
                    byte num = buffer[1];
                    item.Add(str.Substring(4, 2 * (num / 8)));
                    data.Add(item);
                    str = str.Substring((2 + (num / 8)) * 2);
                    goto Label_0736;
                }
                case DataType.Doublelong:
                    str2 = str.Substring(2, 8);
                    item.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0736;

                case DataType.Doublelongunsigned:
                    str2 = str.Substring(2, 8);
                    item.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0736;

                case DataType.Octetstring:
                {
                    int num2 = 0;
                    int num3 = 0;
                    if (buffer[1] <= 0x7f)
                    {
                        num2 = buffer[1];
                        item.Add(str.Substring(4, 2 * num2));
                        data.Add(item);
                        str = str.Substring((2 + num2) * 2);
                    }
                    else
                    {
                        num3 = buffer[1] & 15;
                        num2 = Convert.ToInt32(str.Substring(4, num3 * 2), 0x10);
                        item.Add(str.Substring(6, 2 * num2));
                        data.Add(item);
                        str = str.Substring((3 + num2) * 2);
                    }
                    goto Label_0736;
                }
                case DataType.Visiblestring:
                {
                    byte num4 = buffer[1];
                    str2 = PublicVariable.ASCIIHexstrTostr(str.Substring(4, 2 * num4));
                    if (str2 == "")
                    {
                        item.Add(str2.PadLeft(2 * num4, ' '));
                        data.Add(item);
                    }
                    str = str.Substring((2 + num4) * 2);
                    goto Label_0736;
                }
                case DataType.Long:
                    str2 = str.Substring(2, 4);
                    item.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    data.Add(item);
                    str = str.Substring(6);
                    goto Label_0736;

                case DataType.unsigned:
                    str2 = str.Substring(2, 2);
                    if (str2 == "FF")
                    {
                        item.Add(str2);
                        data.Add(item);
                        break;
                    }
                    item.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    data.Add(item);
                    break;

                case DataType.Longunsigned:
                    str2 = str.Substring(2, 4);
                    item.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    data.Add(item);
                    str = str.Substring(6);
                    goto Label_0736;

                case DataType.long64:
                    str2 = str.Substring(2, 0x10);
                    item.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    data.Add(item);
                    str = str.Substring(0x12);
                    goto Label_0736;

                case DataType.long64unsigned:
                    str2 = str.Substring(2, 0x10);
                    item.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    data.Add(item);
                    str = str.Substring(0x12);
                    goto Label_0736;

                case DataType.Enum:
                    str2 = str.Substring(2, 2);
                    item.Add(Convert.ToInt32(str2, 0x10).ToString("D2"));
                    data.Add(item);
                    str = str.Substring(4);
                    goto Label_0736;

                case DataType.date:
                    str2 = str.Substring(2, 10);
                    if (str2 == "FFFFFFFFFF")
                    {
                        item.Add(str2);
                        data.Add(item);
                    }
                    else
                    {
                        item.Add(Convert.ToInt32(str2.Substring(0, 4), 0x10).ToString("D4") + Convert.ToInt32(str2.Substring(4, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(6, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(8, 2), 0x10).ToString("D2"));
                        data.Add(item);
                    }
                    str = str.Substring(12);
                    goto Label_0736;

                case DataType.date_time_s:
                {
                    string str3 = "";
                    str3 = str.Substring(2, 14);
                    if (str3.Substring(0, 4) == "FFFF")
                    {
                        str2 = str3.Substring(0, 4);
                        str3 = str3.Substring(4);
                    }
                    else
                    {
                        str2 = Convert.ToInt32(str3.Substring(0, 4), 0x10).ToString("D4");
                        str3 = str3.Substring(4);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (str3.Substring(0, 2) != "FF")
                        {
                            str2 = str2 + Convert.ToInt32(str3.Substring(0, 2), 0x10).ToString("D2");
                            str3 = str3.Substring(2);
                        }
                        else
                        {
                            str2 = str2 + str3.Substring(0, 2);
                            str3 = str3.Substring(2);
                        }
                    }
                    item.Add(str2);
                    data.Add(item);
                    str = str.Substring(0x10);
                    goto Label_0736;
                }
                case DataType.OI:
                    item.Add(str.Substring(2, 4));
                    data.Add(item);
                    str = str.Substring(6);
                    goto Label_0736;

                case DataType.OAD:
                    item.Add(str.Substring(2, 8));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0736;

                case DataType.OMD:
                    item.Add(str.Substring(2, 8));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0736;

                case DataType.Scaler_Unit:
                    item.Add((0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2"));
                    item.Add(((UnitsEnum) Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString());
                    data.Add(item);
                    str.Substring(6);
                    goto Label_0736;

                case DataType.COMDCB:
                    item.Add(str.Substring(2, 10));
                    data.Add(item);
                    str = str.Substring(12);
                    goto Label_0736;

                default:
                    goto Label_0736;
            }
            str = str.Substring(4);
        Label_0736:
            return true;
        }

        public static bool AnalyDataType(ref string str, ref List<string> data)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] buffer = PublicVariable.HexToByte(str);
            string str2 = "";
            switch (((DataType) buffer[0]))
            {
                case DataType.NULL:
                    data.Add("");
                    str = str.Substring(2);
                    goto Label_082F;

                case DataType.Array:
                    str = str.Substring(4);
                    ParseArray(ref str, buffer[1], ref data);
                    goto Label_082F;

                case DataType.Structure:
                    str = str.Substring(4);
                    ParseStruct(ref str, buffer[1], ref data);
                    goto Label_082F;

                case DataType.Bool:
                    data.Add(str.Substring(2, 2));
                    str = str.Substring(4);
                    goto Label_082F;

                case DataType.Bitstring:
                {
                    byte num = buffer[1];
                    data.Add(str.Substring(4, 2 * (num / 8)));
                    str = str.Substring((2 + (num / 8)) * 2);
                    goto Label_082F;
                }
                case DataType.Doublelong:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    str = str.Substring(10);
                    goto Label_082F;

                case DataType.Doublelongunsigned:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    str = str.Substring(10);
                    goto Label_082F;

                case DataType.Octetstring:
                {
                    int num2 = 0;
                    int num3 = 0;
                    if (buffer[1] <= 0x7f)
                    {
                        num2 = buffer[1];
                        data.Add(str.Substring(4, 2 * num2));
                        str = str.Substring((2 + num2) * 2);
                    }
                    else
                    {
                        num3 = buffer[1] & 15;
                        num2 = Convert.ToInt32(str.Substring(4, num3 * 2), 0x10);
                        data.Add(str.Substring(6, 2 * num2));
                        str = str.Substring((3 + num2) * 2);
                    }
                    goto Label_082F;
                }
                case DataType.Visiblestring:
                {
                    byte num4 = buffer[1];
                    str2 = PublicVariable.ASCIIHexstrTostr(str.Substring(4, 2 * num4));
                    data.Add(str2);
                    str = str.Substring((2 + num4) * 2);
                    goto Label_082F;
                }
                case DataType.Long:
                    str2 = str.Substring(2, 4);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    str = str.Substring(6);
                    goto Label_082F;

                case DataType.unsigned:
                    str2 = str.Substring(2, 2);
                    if (str2 == "FF")
                    {
                        data.Add(str2);
                        break;
                    }
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    break;

                case DataType.Longunsigned:
                    str2 = str.Substring(2, 4);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D4"));
                    str = str.Substring(6);
                    goto Label_082F;

                case DataType.long64:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    str = str.Substring(0x12);
                    goto Label_082F;

                case DataType.long64unsigned:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    str = str.Substring(0x12);
                    goto Label_082F;

                case DataType.Enum:
                    str2 = str.Substring(2, 2);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    str = str.Substring(4);
                    goto Label_082F;

                case DataType.date:
                    str2 = str.Substring(2, 10);
                    if (str2 == "FFFFFFFFFF")
                    {
                        data.Add(str2);
                    }
                    else
                    {
                        data.Add(Convert.ToInt32(str2.Substring(0, 4), 0x10).ToString("D4") + Convert.ToInt32(str2.Substring(4, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(6, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(8, 2), 0x10).ToString("D2"));
                    }
                    str = str.Substring(12);
                    goto Label_082F;

                case DataType.date_time_s:
                {
                    string str3 = "";
                    str3 = str.Substring(2, 14);
                    if (str3.Substring(0, 4) == "FFFF")
                    {
                        str2 = str3.Substring(0, 4);
                        str3 = str3.Substring(4);
                    }
                    else
                    {
                        str2 = Convert.ToInt32(str3.Substring(0, 4), 0x10).ToString("D4");
                        str3 = str3.Substring(4);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (str3.Substring(0, 2) != "FF")
                        {
                            str2 = str2 + Convert.ToInt32(str3.Substring(0, 2), 0x10).ToString("D2");
                            str3 = str3.Substring(2);
                        }
                        else
                        {
                            str2 = str2 + str3.Substring(0, 2);
                            str3 = str3.Substring(2);
                        }
                    }
                    data.Add(str2);
                    str = str.Substring(0x10);
                    goto Label_082F;
                }
                case DataType.OI:
                    data.Add(str.Substring(2, 4));
                    str = str.Substring(6);
                    goto Label_082F;

                case DataType.OAD:
                    data.Add(str.Substring(2, 8));
                    str = str.Substring(10);
                    goto Label_082F;

                case DataType.ROAD:
                {
                    string item = str.Substring(4, 8);
                    str = str.Substring(12);
                    string str5 = str.Substring(0, 2);
                    str = str.Substring(2);
                    for (int i = 0; i < Convert.ToInt16(str5); i++)
                    {
                        item = item + "," + str.Substring(0, 8);
                        str = str.Substring(8);
                    }
                    data.Add(item);
                    goto Label_082F;
                }
                case DataType.OMD:
                    data.Add(str.Substring(2, 8));
                    str = str.Substring(10);
                    goto Label_082F;

                case DataType.RN:
                {
                    int num7 = 0;
                    int num8 = 0;
                    if (buffer[1] <= 0x7f)
                    {
                        num7 = buffer[1];
                        data.Add(str.Substring(4, 2 * num7));
                        str = str.Substring((2 + num7) * 2);
                    }
                    else
                    {
                        num8 = buffer[1] & 15;
                        num7 = Convert.ToInt32(str.Substring(4, num8 * 2), 0x10);
                        data.Add(str.Substring(6, 2 * num7));
                        str = str.Substring((3 + num7) * 2);
                    }
                    goto Label_082F;
                }
                case DataType.Scaler_Unit:
                    data.Add((0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2"));
                    data.Add(((UnitsEnum) Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString());
                    str = str.Substring(6);
                    goto Label_082F;

                case DataType.CSD:
                {
                    string str6 = str.Substring(2, 2);
                    string item = "";
                    string str8 = "";
                    str = str.Substring(4);
                    switch (str6)
                    {
                        case "00":
                            data.Add(str.Substring(0, 8));
                            str = str.Substring(8);
                            break;

                        case "01":
                            item = str.Substring(0, 8);
                            str = str.Substring(8);
                            str8 = str.Substring(0, 2);
                            str = str.Substring(2);
                            for (int i = 0; i < Convert.ToInt16(str8); i++)
                            {
                                item = item + "," + str.Substring(0, 8);
                                str = str.Substring(8);
                            }
                            data.Add(item);
                            break;
                    }
                    goto Label_082F;
                }
                case DataType.COMDCB:
                    data.Add(str.Substring(2, 10));
                    str = str.Substring(12);
                    goto Label_082F;

                default:
                    goto Label_082F;
            }
            str = str.Substring(4);
        Label_082F:
            return true;
        }

        public static bool AnalyDataType(ref string str, ref List<string> data, TreeList mytreeList, TreeListNode rootnode)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] buffer = PublicVariable.HexToByte(str);
            string str2 = "";
            switch (((DataType) buffer[0]))
            {
                case DataType.NULL:
                    data.Add("");
                    mytreeList.AppendNode(new object[] { "" }, rootnode);
                    str = str.Substring(2);
                    goto Label_0BD6;

                case DataType.Array:
                    str = str.Substring(4);
                    ParseArray(ref str, buffer[1], ref data, mytreeList, rootnode);
                    goto Label_0BD6;

                case DataType.Structure:
                    str = str.Substring(4);
                    ParseStruct(ref str, buffer[1], ref data, mytreeList, rootnode);
                    goto Label_0BD6;

                case DataType.Bool:
                    mytreeList.AppendNode(new object[] { str.Substring(2, 2) }, rootnode);
                    data.Add(str.Substring(2, 2));
                    str = str.Substring(4);
                    goto Label_0BD6;

                case DataType.Bitstring:
                {
                    byte num = buffer[1];
                    data.Add(str.Substring(4, 2 * (num / 8)));
                    mytreeList.AppendNode(new object[] { str.Substring(4, 2 * (num / 8)) }, rootnode);
                    str = str.Substring((2 + (num / 8)) * 2);
                    goto Label_0BD6;
                }
                case DataType.Doublelong:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt32(str2, 0x10).ToString("D8") }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BD6;

                case DataType.Doublelongunsigned:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt32(str2, 0x10).ToString("D8") }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BD6;

                case DataType.Octetstring:
                {
                    int num2 = 0;
                    int num3 = 0;
                    if (buffer[1] <= 0x7f)
                    {
                        num2 = buffer[1];
                        data.Add(str.Substring(4, 2 * num2));
                        mytreeList.AppendNode(new object[] { str.Substring(4, 2 * num2) }, rootnode);
                        str = str.Substring((2 + num2) * 2);
                    }
                    else
                    {
                        num3 = buffer[1] & 15;
                        num2 = Convert.ToInt32(str.Substring(4, num3 * 2), 0x10);
                        data.Add(str.Substring(6, 2 * num2));
                        mytreeList.AppendNode(new object[] { str.Substring(6, 2 * num2) }, rootnode);
                        str = str.Substring((3 + num2) * 2);
                    }
                    goto Label_0BD6;
                }
                case DataType.Visiblestring:
                {
                    byte num4 = buffer[1];
                    str2 = PublicVariable.ASCIIHexstrTostr(str.Substring(4, 2 * num4));
                    data.Add(str2);
                    mytreeList.AppendNode(new object[] { str2 }, rootnode);
                    str = str.Substring((2 + num4) * 2);
                    goto Label_0BD6;
                }
                case DataType.Long:
                    str2 = str.Substring(2, 4);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt16(str2, 0x10).ToString("D4") }, rootnode);
                    str = str.Substring(6);
                    goto Label_0BD6;

                case DataType.unsigned:
                    str2 = str.Substring(2, 2);
                    if (str2 == "FF")
                    {
                        data.Add(str2);
                        mytreeList.AppendNode(new object[] { str2 }, rootnode);
                        break;
                    }
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt16(str2, 0x10).ToString("D2") }, rootnode);
                    break;

                case DataType.Longunsigned:
                    str2 = str.Substring(2, 4);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D4"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt32(str2, 0x10).ToString("D4") }, rootnode);
                    str = str.Substring(6);
                    goto Label_0BD6;

                case DataType.long64:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt64(str2, 0x10).ToString("D16") }, rootnode);
                    str = str.Substring(0x12);
                    goto Label_0BD6;

                case DataType.long64unsigned:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt64(str2, 0x10).ToString("D16") }, rootnode);
                    str = str.Substring(0x12);
                    goto Label_0BD6;

                case DataType.Enum:
                    str2 = str.Substring(2, 2);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt16(str2, 0x10).ToString("D2") }, rootnode);
                    str = str.Substring(4);
                    goto Label_0BD6;

                case DataType.date:
                    str2 = str.Substring(2, 10);
                    if (str2 == "FFFFFFFFFF")
                    {
                        data.Add(str2);
                        mytreeList.AppendNode(new object[] { str2 }, rootnode);
                    }
                    else
                    {
                        data.Add(Convert.ToInt32(str2.Substring(0, 4), 0x10).ToString("D4") + Convert.ToInt32(str2.Substring(4, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(6, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(8, 2), 0x10).ToString("D2"));
                        mytreeList.AppendNode(new object[] { Convert.ToInt32(str2.Substring(0, 4), 0x10).ToString("D4") + Convert.ToInt32(str2.Substring(4, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(6, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(8, 2), 0x10).ToString("D2") }, rootnode);
                    }
                    str = str.Substring(12);
                    goto Label_0BD6;

                case DataType.date_time_s:
                {
                    string str3 = "";
                    str3 = str.Substring(2, 14);
                    if (str3.Substring(0, 4) == "FFFF")
                    {
                        str2 = str3.Substring(0, 4);
                        str3 = str3.Substring(4);
                    }
                    else
                    {
                        str2 = Convert.ToInt32(str3.Substring(0, 4), 0x10).ToString("D4");
                        str3 = str3.Substring(4);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (str3.Substring(0, 2) != "FF")
                        {
                            str2 = str2 + Convert.ToInt32(str3.Substring(0, 2), 0x10).ToString("D2");
                            str3 = str3.Substring(2);
                        }
                        else
                        {
                            str2 = str2 + str3.Substring(0, 2);
                            str3 = str3.Substring(2);
                        }
                    }
                    data.Add(str2);
                    mytreeList.AppendNode(new object[] { str2 }, rootnode);
                    str = str.Substring(0x10);
                    goto Label_0BD6;
                }
                case DataType.OI:
                    data.Add(str.Substring(2, 4));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 4) }, rootnode);
                    str = str.Substring(6);
                    goto Label_0BD6;

                case DataType.OAD:
                    data.Add(str.Substring(2, 8));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 8) }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BD6;

                case DataType.ROAD:
                {
                    string item = str.Substring(4, 8);
                    str = str.Substring(12);
                    string str5 = str.Substring(0, 2);
                    str = str.Substring(2);
                    for (int i = 0; i < Convert.ToInt16(str5); i++)
                    {
                        item = item + "," + str.Substring(0, 8);
                        str = str.Substring(8);
                    }
                    data.Add(item);
                    mytreeList.AppendNode(new object[] { item }, rootnode);
                    goto Label_0BD6;
                }
                case DataType.OMD:
                    data.Add(str.Substring(2, 8));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 8) }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BD6;

                case DataType.Scaler_Unit:
                {
                    data.Add((0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2"));
                    object[] nodeData = new object[] { (0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2") };
                    mytreeList.AppendNode(nodeData, rootnode);
                    data.Add(((UnitsEnum) Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString());
                    mytreeList.AppendNode(new object[] { ((UnitsEnum) Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString() }, rootnode);
                    str = str.Substring(6);
                    goto Label_0BD6;
                }
                case DataType.CSD:
                {
                    string str6 = str.Substring(2, 2);
                    string item = "";
                    string str8 = "";
                    str = str.Substring(4);
                    switch (str6)
                    {
                        case "00":
                            data.Add(str.Substring(0, 8));
                            mytreeList.AppendNode(new object[] { str.Substring(0, 8) }, rootnode);
                            str = str.Substring(8);
                            break;

                        case "01":
                            item = str.Substring(0, 8);
                            str = str.Substring(8);
                            str8 = str.Substring(0, 2);
                            str = str.Substring(2);
                            for (int i = 0; i < Convert.ToInt16(str8); i++)
                            {
                                item = item + "," + str.Substring(0, 8);
                                str = str.Substring(8);
                            }
                            data.Add(item);
                            mytreeList.AppendNode(new object[] { item }, rootnode);
                            break;
                    }
                    goto Label_0BD6;
                }
                case DataType.COMDCB:
                    data.Add(str.Substring(2, 10));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 10) }, rootnode);
                    str = str.Substring(12);
                    goto Label_0BD6;

                default:
                    goto Label_0BD6;
            }
            str = str.Substring(4);
        Label_0BD6:
            return true;
        }

        public static bool AnalyDataType_记录表(ref string str, ref List<List<string>> data)
        {
            List<string> item = new List<string>();
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] buffer = PublicVariable.HexToByte(str);
            string str2 = "";
            switch (((DataType) buffer[0]))
            {
                case DataType.NULL:
                    item.Add("");
                    data.Add(item);
                    str = str.Substring(2);
                    goto Label_0748;

                case DataType.Array:
                    str = str.Substring(4);
                    ParseArray(ref str, buffer[1], ref item);
                    data.Add(item);
                    goto Label_0748;

                case DataType.Structure:
                    str = str.Substring(4);
                    ParseStruct(ref str, buffer[1], ref item);
                    data.Add(item);
                    goto Label_0748;

                case DataType.Bool:
                    item.Add(str.Substring(2, 2));
                    data.Add(item);
                    str = str.Substring(4);
                    goto Label_0748;

                case DataType.Bitstring:
                {
                    byte num = buffer[1];
                    item.Add(str.Substring(4, 2 * (num / 8)));
                    data.Add(item);
                    str = str.Substring((2 + (num / 8)) * 2);
                    goto Label_0748;
                }
                case DataType.Doublelong:
                    str2 = str.Substring(2, 8);
                    item.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0748;

                case DataType.Doublelongunsigned:
                    str2 = str.Substring(2, 8);
                    item.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0748;

                case DataType.Octetstring:
                {
                    int num2 = 0;
                    int num3 = 0;
                    if (buffer[1] <= 0x7f)
                    {
                        num2 = buffer[1];
                        item.Add(str.Substring(4, 2 * num2));
                        data.Add(item);
                        str = str.Substring((2 + num2) * 2);
                    }
                    else
                    {
                        num3 = buffer[1] & 15;
                        num2 = Convert.ToInt32(str.Substring(4, num3 * 2), 0x10);
                        item.Add(str.Substring(6, 2 * num2));
                        data.Add(item);
                        str = str.Substring((3 + num2) * 2);
                    }
                    goto Label_0748;
                }
                case DataType.Visiblestring:
                {
                    byte num4 = buffer[1];
                    str2 = PublicVariable.ASCIIHexstrTostr(str.Substring(4, 2 * num4));
                    if (str2 == "")
                    {
                        item.Add(str2.PadLeft(2 * num4, ' '));
                        data.Add(item);
                    }
                    str = str.Substring((2 + num4) * 2);
                    goto Label_0748;
                }
                case DataType.Long:
                    str2 = str.Substring(2, 4);
                    item.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    data.Add(item);
                    str = str.Substring(6);
                    goto Label_0748;

                case DataType.unsigned:
                    str2 = str.Substring(2, 2);
                    if (str2 == "FF")
                    {
                        item.Add(str2);
                        data.Add(item);
                        break;
                    }
                    item.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    data.Add(item);
                    break;

                case DataType.Longunsigned:
                    str2 = str.Substring(2, 4);
                    item.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    data.Add(item);
                    str = str.Substring(6);
                    goto Label_0748;

                case DataType.long64:
                    str2 = str.Substring(2, 0x10);
                    item.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    data.Add(item);
                    str = str.Substring(0x12);
                    goto Label_0748;

                case DataType.long64unsigned:
                    str2 = str.Substring(2, 0x10);
                    item.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    data.Add(item);
                    str = str.Substring(0x12);
                    goto Label_0748;

                case DataType.Enum:
                    str2 = str.Substring(2, 2);
                    item.Add(Convert.ToInt32(str2, 0x10).ToString("D2"));
                    data.Add(item);
                    str = str.Substring(4);
                    goto Label_0748;

                case DataType.date:
                    str2 = str.Substring(2, 10);
                    if (str2 == "FFFFFFFFFF")
                    {
                        item.Add(str2);
                        data.Add(item);
                    }
                    else
                    {
                        item.Add(Convert.ToInt32(str2.Substring(0, 4), 0x10).ToString("D4") + Convert.ToInt32(str2.Substring(4, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(6, 2), 0x10).ToString("D2") + Convert.ToInt32(str2.Substring(8, 2), 0x10).ToString("D2"));
                        data.Add(item);
                    }
                    str = str.Substring(12);
                    goto Label_0748;

                case DataType.date_time_s:
                {
                    string str3 = "";
                    str3 = str.Substring(2, 14);
                    if (str3.Substring(0, 4) == "FFFF")
                    {
                        str2 = str3.Substring(0, 4);
                        str3 = str3.Substring(4);
                    }
                    else
                    {
                        str2 = Convert.ToInt32(str3.Substring(0, 4), 0x10).ToString("D4");
                        str3 = str3.Substring(4);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (str3.Substring(0, 2) != "FF")
                        {
                            str2 = str2 + Convert.ToInt32(str3.Substring(0, 2), 0x10).ToString("D2");
                            str3 = str3.Substring(2);
                        }
                        else
                        {
                            str2 = str2 + str3.Substring(0, 2);
                            str3 = str3.Substring(2);
                        }
                    }
                    item.Add(str2);
                    data.Add(item);
                    str = str.Substring(0x10);
                    goto Label_0748;
                }
                case DataType.OI:
                    item.Add(str.Substring(2, 4));
                    data.Add(item);
                    str = str.Substring(6);
                    goto Label_0748;

                case DataType.OAD:
                    item.Add(str.Substring(2, 8));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0748;

                case DataType.OMD:
                    item.Add(str.Substring(2, 8));
                    data.Add(item);
                    str = str.Substring(10);
                    goto Label_0748;

                case DataType.Scaler_Unit:
                    item.Add((0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2"));
                    item.Add(((UnitsEnum) Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString());
                    data.Add(item);
                    str.Substring(6);
                    goto Label_0748;

                case DataType.COMDCB:
                    item.Add(str.Substring(2, 10));
                    data.Add(item);
                    str = str.Substring(12);
                    goto Label_0748;

                default:
                    goto Label_0748;
            }
            str = str.Substring(4);
        Label_0748:
            return true;
        }

        public static string Get_RCSD(ref string str, ref string rel_Num, ref List<string> Rel_RCSD)
        {
            rel_Num = str.Substring(0, 2);
            str = str.Substring(2);
            for (int i = 0; i < Convert.ToInt16(rel_Num, 0x10); i++)
            {
                if (str.Substring(0, 2) == "00")
                {
                    str = str.Substring(2);
                    Rel_RCSD.Add(str.Substring(0, 8));
                    str = str.Substring(8);
                }
                else
                {
                    bool flag1 = str.Substring(0, 2) == "01";
                }
            }
            return "";
        }

        public static string Get_RCSD(byte SEQ_Of_CSD, byte Choice_CSD, List<string> list_OAD, string Ob_OAD1, byte SEQ_Of_OAD2, string str_OAD2)
        {
            string str2;
            try
            {
                byte num;
                string str = null;
                if (SEQ_Of_CSD == 0)
                {
                    return SEQ_Of_CSD.ToString("X2");
                }
                switch (Choice_CSD)
                {
                    case 0:
                        str = SEQ_Of_CSD.ToString("X2");
                        num = 0;
                        goto Label_005D;

                    case 1:
                        str = SEQ_Of_CSD.ToString("X2") + Choice_CSD.ToString("X2") + ROAD(Ob_OAD1, SEQ_Of_OAD2, str_OAD2);
                        goto Label_008B;

                    default:
                        goto Label_008B;
                }
            Label_003E:
                str = str + Choice_CSD.ToString("X2") + list_OAD[num];
                num = (byte) (num + 1);
            Label_005D:
                if (num < SEQ_Of_CSD)
                {
                    goto Label_003E;
                }
            Label_008B:
                str2 = str;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                str2 = null;
            }
            return str2;
        }

        public static string Get_RSD(byte Sele_RSD, string Sele_OAD, byte Start_Data_type, byte Start_Data_Len, ref string Start_Data, byte End_Data_type, byte End_Data_Len, ref string End_Data, byte data_TI_type, byte data_TI_Len, ref string data_TI, byte N)
        {
            try
            {
                string str = null;
                string str2 = "";
                string str3 = "";
                string str4 = "";
                str2 = Protocol.From_Type_GetData(Start_Data_type, Start_Data_Len, ref Start_Data);
                str3 = Protocol.From_Type_GetData(End_Data_type, End_Data_Len, ref End_Data);
                str4 = Protocol.From_Type_GetData(data_TI_type, data_TI_Len, ref data_TI);
                switch (Sele_RSD)
                {
                    case 1:
                        str = Sele_RSD.ToString("X2") + Sele_OAD.PadLeft(8, '0') + str2;
                        break;

                    case 2:
                        str = Sele_RSD.ToString("X2") + Sele_OAD.PadLeft(8, '0') + str2 + str3 + str4;
                        break;

                    case 9:
                        str = Sele_RSD.ToString("X2") + N.ToString("X2");
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

        public static bool GetRequestNormal(string Str_OAD, string Con_Code, string meterAdd, string Client_Add, ref string cData, ref string OAD_Buff, ref List<List<string>> ParseData, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                string str = null;
                string str3 = "05";
                string str4 = "01";
                bool flag = false;
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
                if (TimeTag)
                {
                    str = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + Str_OAD + "01" + PublicVariable.TimeText;
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
                    flag = GetResponseNormal(cData, ref OAD_Buff, ref ParseData);
                    PublicVariable.SplitFlag = SplitFlag;
                    PublicVariable.ChangedFlag = true;
                    return flag;
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

        public static bool GetRequestNormal(string Str_OAD, string Con_Code, string meterAdd, string Client_Add, ref string cData, ref string OAD_Buff, ref List<string> ParseData, bool TimeTag, ref bool SplitFlag)
        {
            try
            {
                string str = null;
                string str3 = "05";
                string str4 = "01";
                bool flag = false;
                string str5 = "";
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
                if (TimeTag)
                {
                    str = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + Str_OAD + "01" + PublicVariable.TimeText;
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
                    flag = GetResponseNormal(cData, ref str5, ref OAD_Buff, ref ParseData);
                    PublicVariable.SplitFlag = SplitFlag;
                    PublicVariable.ChangedFlag = true;
                    return flag;
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

        public static bool GetRequestRecord(string Con_Code, string meterAdd, string Client_Add, string Str_OAD, string Str_RSD, string Str_RCSD, ref string OutData, bool TimeTag, ref bool SplitFlag, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> list_ParseData_多级)
        {
            try
            {
                bool flag = false;
                string cData = null;
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
                string str3 = "05";
                string str4 = "03";
                if (TimeTag)
                {
                    cData = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + Str_OAD + Str_RSD + Str_RCSD + "01" + PublicVariable.TimeText;
                    short num = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (!OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, TimeTag))
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                   CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    cData = str3 + str4 + PublicVariable.PIID_R.ToString("X2") + Str_OAD + Str_RSD + Str_RCSD + "00";
                    short num2 = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (OrigDLT698Wrap(num2.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, TimeTag))
                    {
                       CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if ((PublicVariable.RecDataString.Length > 0) && RecIsProtocol(PublicVariable.RecDataString, ref OutData, ref SplitFlag))
                {
                    flag = GetResponseRecord(OutData, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref list_ParseData_多级);
                    PublicVariable.SplitFlag = SplitFlag;
                    PublicVariable.ChangedFlag = true;
                    return flag;
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

        public static bool GetRequestRecordList(string Con_Code, string meterAdd, string Client_Add, ref string getRecord_Num, getRecord[] SEQ_getRecord, ref string OutData, bool TimeTag, ref bool SplitFlag, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> list_ParseData_多级)
        {
            try
            {
                bool flag = false;
                string cData = null;
                string str2 = "";
                PublicVariable.PIID_R = (byte) (PublicVariable.PIID_R + 1);
                string str4 = "05";
                string str5 = "03";
                if (TimeTag)
                {
                    cData = str4 + str5 + PublicVariable.PIID_R.ToString("X2") + Convert.ToInt16(getRecord_Num, 10).ToString("X2");
                    for (int i = 0; i < Convert.ToInt16(getRecord_Num, 10); i++)
                    {
                        str2 = SEQ_getRecord[i].Str_OAD + SEQ_getRecord[i].Str_RSD + SEQ_getRecord[i].Str_RCSD;
                    }
                    cData = str2 + "01" + PublicVariable.TimeText;
                    short num4 = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (!OrigDLT698Wrap(num4.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, TimeTag))
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                    CommParam.comPort.comPort_DataReceived();
                }
                else
                {
                    cData = str4 + str5 + PublicVariable.PIID_R.ToString("X2") + Convert.ToInt16(getRecord_Num, 10).ToString("X2");
                    for (int i = 0; i < Convert.ToInt16(getRecord_Num, 10); i++)
                    {
                        str2 = SEQ_getRecord[i].Str_OAD + SEQ_getRecord[i].Str_RSD + SEQ_getRecord[i].Str_RCSD;
                    }
                    cData = str2 + "00";
                    short num6 = (short) ((8 + (meterAdd.Length / 2)) + (cData.Length / 2));
                    if (OrigDLT698Wrap(num6.ToString("X4"), Con_Code, meterAdd, Client_Add, cData, TimeTag))
                    {
                        CommParam.comPort.comPort_DataReceived();
                    }
                    else
                    {
                        PublicVariable.ChangedFlag = true;
                        return false;
                    }
                }
                if ((PublicVariable.RecDataString.Length > 0) && RecIsProtocol(PublicVariable.RecDataString, ref OutData, ref SplitFlag))
                {
                    flag = GetResponseRecordList(OutData, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref list_ParseData_多级);
                    PublicVariable.SplitFlag = SplitFlag;
                    PublicVariable.ChangedFlag = true;
                    return flag;
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

        public static bool GetResponseMD5(string LinkData, ref string str_OAD, ref string data_MD5)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                if (LinkData.Length >= 0x34)
                {
                    str_OAD = LinkData.Substring(6, 8);
                    LinkData = LinkData.Substring(14);
                    if (LinkData.Substring(0, 2) == "00")
                    {
                        LinkData = LinkData.Substring(2);
                        PublicVariable.DARInfo = "-" + PublicVariable.DARInfo + ((DAR) Convert.ToByte(LinkData.Substring(0, 2), 0x10)).ToString() + "-";
                        LinkData = LinkData.Substring(2);
                        data_MD5 = "";
                        return false;
                    }
                    if (LinkData.Substring(0, 2) == "01")
                    {
                        LinkData = LinkData.Substring(2);
                        data_MD5 = LinkData.Substring(0, 0x20);
                        LinkData = LinkData.Substring(0x20);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseNext(string LinkData, ref string data_分帧)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                if (LinkData.Length >= 20)
                {
                    LinkData.Substring(6, 2);
                    LinkData = LinkData.Substring(8);
                    LinkData.Substring(0, 4);
                    LinkData = LinkData.Substring(4);
                    if (LinkData.Substring(0, 2) == "00")
                    {
                        LinkData = LinkData.Substring(2);
                        PublicVariable.DARInfo = "-" + PublicVariable.DARInfo + ((DAR) Convert.ToByte(LinkData.Substring(0, 2), 0x10)).ToString() + "-";
                        LinkData = LinkData.Substring(2);
                        data_分帧 = "";
                        return false;
                    }
                    if (LinkData.Substring(0, 2) == "01")
                    {
                        LinkData = LinkData.Substring(2);
                        data_分帧 = LinkData;
                        return true;
                    }
                    if (LinkData.Substring(0, 2) == "02")
                    {
                        LinkData = LinkData.Substring(2);
                        data_分帧 = LinkData;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseNormal(string LinkData, ref string OAD_Buff, ref List<List<string>> ParseData)
        {
            try
            {
                if (LinkData.Length < 0x10)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                string str = LinkData.Substring(6);
                bool flag = A_Result(ref str, ref OAD_Buff, ref ParseData);
               Protocol.FollowReportAndTimeTag(str);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseNormal(string LinkData, ref string PIID_Buff, ref string OAD_Buff, ref List<string> ParseData)
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
                Protocol.FollowReportAndTimeTag(str);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseNormalList(string LinkData, ref string PIID_Buff, ref List<string> ListOAD_Buff, ref List<List<string>> ParseData_二级)
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
                string str = "";
                string str2 = LinkData.Substring(8);
                for (int i = 0; i < num; i++)
                {
                    List<string> data = new List<string>();
                    flag = A_Result(ref str2, ref str, ref data);
                    ListOAD_Buff.Add(str);
                    ParseData_二级.Add(data);
                }
                Protocol.FollowReportAndTimeTag(str2);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseNormalList(string LinkData, ref string PIID_Buff, ref List<string> ListOAD_Buff, ref List<List<string>> listData, TreeList myTreeList)
        {
            try
            {
                if (LinkData.Length < 0x10)
                {
                    return false;
                }
                TreeListNode parentNode = null;
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                byte[] buffer = PublicVariable.HexToByte(LinkData);
                PIID_Buff = buffer[2].ToString("X2");
                byte num = buffer[3];
                string str = "";
                string str2 = LinkData.Substring(8);
                myTreeList.ClearNodes();
                myTreeList.BeginUnboundLoad();
                for (int i = 0; i < num; i++)
                {
                    List<string> data = new List<string>();
                    TreeListNode rootnode = myTreeList.AppendNode(new object[] { "" }, parentNode);
                    flag = A_Result(ref str2, ref str, ref data, myTreeList, rootnode);
                    ListOAD_Buff.Add(str);
                    listData.Add(data);
                }
                myTreeList.EndUnboundLoad();
                Protocol.FollowReportAndTimeTag(str2);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseRecord(string LinkData, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> ParseData)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                if (LinkData.Length >= 0x18)
                {
                    string str = LinkData.Substring(6);
                    Rercord_OAD = str.Substring(0, 8);
                    str = str.Substring(8);
                    Get_RCSD(ref str, ref rel_Num, ref Rel_RCSD);
                    if (str.Substring(0, 2) == "01")
                    {
                        str = str.Substring(2);
                        Record_Num = str.Substring(0, 2);
                        str = str.Substring(2);
                        for (int i = 0; i < Convert.ToInt16(Record_Num, 0x10); i++)
                        {
                            List<List<string>> data = new List<List<string>>();
                            for (int j = 0; j < Convert.ToInt16(rel_Num, 0x10); j++)
                            {
                                AnalyDataType_记录表(ref str, ref data);
                            }
                            ParseData.Add(data);
                        }
                       Protocol.FollowReportAndTimeTag(str);
                        return true;
                    }
                    if (str.Substring(0, 2) == "00")
                    {
                        str = str.Substring(2);
                        PublicVariable.DARInfo = "-" + PublicVariable.DARInfo + Rercord_OAD + ((DAR) Convert.ToByte(str.Substring(0, 2), 0x10)).ToString() + "-";
                        str = str.Substring(2);
                        ParseData.Clear();
                        Protocol.FollowReportAndTimeTag(str);
                        return false;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool GetResponseRecordList(string LinkData, ref string getRecord_Num, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> ParseData)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                string str = "";
                string item = "";
                bool flag = false;
                if (LinkData.Length < 40)
                {
                    return false;
                }
                string str3 = LinkData.Substring(6);
                getRecord_Num = str3.Substring(0, 2);
                bool[] flagArray = new bool[Convert.ToInt16(getRecord_Num, 0x10)];
                str3 = str3.Substring(2);
                for (int i = 0; i < Convert.ToInt16(getRecord_Num, 0x10); i++)
                {
                    List<List<List<string>>> list;
                    List<List<string>> list2;
                    Rercord_OAD.Add(str3.Substring(0, 8));
                    str3 = str3.Substring(8);
                    List<string> list3 = new List<string>();
                    str = "";
                    Get_RCSD(ref str3, ref str, ref list3);
                    rel_Num.Add(str);
                    Rel_RCSD.Add(list3);
                    if (str3.Substring(0, 2) == "01")
                    {
                        str3 = str3.Substring(2);
                        item = str3.Substring(0, 2);
                        Record_Num.Add(item);
                        str3 = str3.Substring(2);
                        if (Convert.ToInt16(item, 0x10) != 0)
                        {
                            for (int k = 0; k < Convert.ToInt16(item, 0x10); k++)
                            {
                                list = new List<List<List<string>>>();
                                list2 = new List<List<string>>();
                                for (int m = 0; m < Convert.ToInt16(str, 0x10); m++)
                                {
                                    AnalyDataType_记录表(ref str3, ref list2);
                                }
                                list.Add(list2);
                                ParseData.Add(list);
                            }
                            flagArray[i] = true;
                        }
                        else
                        {
                            list = new List<List<List<string>>>();
                            list2 = new List<List<string>>();
                            list.Add(list2);
                            ParseData.Add(list);
                            flagArray[i] = true;
                        }
                    }
                    else if (str3.Substring(0, 2) == "00")
                    {
                        str3 = str3.Substring(2);
                        PublicVariable.DARInfo = "-" + PublicVariable.DARInfo + Rercord_OAD[i] + ((DAR) Convert.ToByte(str3.Substring(0, 2), 0x10)).ToString() + "-";
                        str3 = str3.Substring(2);
                        Record_Num.Add("00");
                        list = new List<List<List<string>>>();
                        list2 = new List<List<string>>();
                        list.Add(list2);
                        ParseData.Add(list);
                        flagArray[i] = false;
                    }
                }
                for (int j = 0; j < flagArray.Length; j++)
                {
                    if (!flagArray[j])
                    {
                        flag = false;
                        break;
                    }
                    flag = true;
                }
                Protocol.FollowReportAndTimeTag(str3);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref List<List<string>> List_ParseData_二级, ref string OAD_Buff, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(400);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "01")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref OAD_Buff, ref List_ParseData_二级);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str4;
                                if (((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null)) && (str4 != "85"))
                                {
                                    bool flag1 = str4 == "86";
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "01")
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref OAD_Buff, ref List_ParseData_二级);
                                }
                                else if ((str5 == "86") || (str5 == "87"))
                                {
                                }
                            }
                        }
                        else
                        {
                            string str6;
                            if (((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                            {
                                bool flag3 = str6 == "86";
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x3e8);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "01")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref List_ParseData);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str4;
                                if (((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null)) && (str4 != "85"))
                                {
                                    bool flag1 = str4 == "86";
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "01")
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref List_ParseData);
                                }
                                else if ((str5 == "86") || (str5 == "87"))
                                {
                                }
                            }
                        }
                        else
                        {
                            string str6;
                            if (((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                            {
                                bool flag3 = str6 == "86";
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x3e8);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "03")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseRecord(cOutData.ToString(), ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str4;
                                if (((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null)) && (str4 != "85"))
                                {
                                    bool flag1 = str4 == "86";
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "03")
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseRecord(cOutData.ToString(), ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                }
                                else if ((str5 == "86") || (str5 == "87"))
                                {
                                }
                            }
                        }
                        else
                        {
                            string str6;
                            if (((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                            {
                                bool flag3 = str6 == "86";
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool Math_密文_SID(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string getRecord_Num, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> List_ParseData, ref string OADBuff_MD5, ref string str_NextOrMD5, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(400);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool responseNext = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                    responseNext = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
                    if (!responseNext)
                    {
                        return responseNext;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        responseNext = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "04")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        responseNext = GetResponseRecordList(cOutData.ToString(), ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else if (cOutData.ToString().Substring(2, 2) == "05")
                            {
                                string str4 = cOutData.ToString().Substring(0, 2);
                                if (str4 != null)
                                {
                                    if (str4 == "85")
                                    {
                                        responseNext = GetResponseNext(cOutData.ToString(), ref str_NextOrMD5);
                                    }
                                    else if (str4 == "86")
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str5;
                                if ((cOutData.ToString().Substring(2, 2) == "06") && ((str5 = cOutData.ToString().Substring(0, 2)) != null))
                                {
                                    if (str5 == "85")
                                    {
                                        responseNext = GetResponseMD5(cOutData.ToString(), ref OADBuff_MD5, ref str_NextOrMD5);
                                    }
                                    else if (str5 == "86")
                                    {
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return responseNext;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                str2 = builder + ((builder2.Length / 2)).ToString("X2") + builder2;
                responseNext = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
                if (!responseNext)
                {
                    return responseNext;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 2, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    responseNext = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "04")
                        {
                            string str6 = cOutData.ToString().Substring(0, 2);
                            if (str6 != null)
                            {
                                if (str6 == "85")
                                {
                                    responseNext = GetResponseRecordList(cOutData.ToString(), ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                }
                                else if ((str6 == "86") || (str6 == "87"))
                                {
                                }
                            }
                        }
                        else if (cOutData.ToString().Substring(2, 2) == "05")
                        {
                            string str7 = cOutData.ToString().Substring(0, 2);
                            if (str7 != null)
                            {
                                if (str7 == "85")
                                {
                                    responseNext = GetResponseNext(cOutData.ToString(), ref str_NextOrMD5);
                                }
                                else if (str7 == "86")
                                {
                                }
                            }
                        }
                        else
                        {
                            string str8;
                            if ((cOutData.ToString().Substring(2, 2) == "06") && ((str8 = cOutData.ToString().Substring(0, 2)) != null))
                            {
                                if (str8 == "85")
                                {
                                    responseNext = GetResponseMD5(cOutData.ToString(), ref OADBuff_MD5, ref str_NextOrMD5);
                                }
                                else if (str8 == "86")
                                {
                                }
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return responseNext;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref List<List<string>> List_ParseData_二级, ref string OAD_Buff, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(400);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str2 = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "01")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref OAD_Buff, ref List_ParseData_二级);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str4;
                                if (((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null)) && (str4 != "85"))
                                {
                                    bool flag1 = str4 == "86";
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str2 = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "01")
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref OAD_Buff, ref List_ParseData_二级);
                                }
                                else if ((str5 == "86") || (str5 == "87"))
                                {
                                }
                            }
                        }
                        else
                        {
                            string str6;
                            if (((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                            {
                                bool flag3 = str6 == "86";
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref List<string> List_ParseData, ref string MAC, ref string PIID_Buff, ref string OAD_Buff, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x3e8);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str2 = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "01")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref List_ParseData);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str4;
                                if (((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null)) && (str4 != "85"))
                                {
                                    bool flag1 = str4 == "86";
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str2 = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "01")
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseNormal(cOutData.ToString(), ref PIID_Buff, ref OAD_Buff, ref List_ParseData);
                                }
                                else if ((str5 == "86") || (str5 == "87"))
                                {
                                }
                            }
                        }
                        else
                        {
                            string str6;
                            if (((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                            {
                                bool flag3 = str6 == "86";
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(0x3e8);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool flag = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str2 = string.Concat(objArray2);
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                        return flag;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        flag = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "03")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        flag = GetResponseRecord(cOutData.ToString(), ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str4;
                                if (((cOutData.ToString().Substring(2, 2) == "02") && ((str4 = cOutData.ToString().Substring(0, 2)) != null)) && (str4 != "85"))
                                {
                                    bool flag1 = str4 == "86";
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str2 = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (!flag)
                {
                    return flag;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    flag = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "03")
                        {
                            string str5 = cOutData.ToString().Substring(0, 2);
                            if (str5 != null)
                            {
                                if (str5 == "85")
                                {
                                    flag = GetResponseRecord(cOutData.ToString(), ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                }
                                else if ((str5 == "86") || (str5 == "87"))
                                {
                                }
                            }
                        }
                        else
                        {
                            string str6;
                            if (((cOutData.ToString().Substring(2, 2) == "02") && ((str6 = cOutData.ToString().Substring(0, 2)) != null)) && (str6 != "85"))
                            {
                                bool flag3 = str6 == "86";
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return flag;
        }

        public static bool Math_密文_SID_MAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string getRecord_Num, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> List_ParseData, ref string OADBuff_MD5, ref string str_NextOrMD5, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            StringBuilder builder = new StringBuilder(10);
            StringBuilder builder2 = new StringBuilder(8);
            StringBuilder builder3 = new StringBuilder(400);
            StringBuilder builder4 = new StringBuilder(8);
            string linkData = "";
            string str2 = "";
            bool responseNext = false;
            new List<string>();
            new List<string>();
            if (!PublicVariable.LinkRoadFlag)
            {
                if (PublicVariable.IsLink && EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.GetMeterSetData, ref builder, ref builder2, ref builder3, ref builder4, new object[] { 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata }))
                {
                    linkData = builder3.ToString();
                    object[] objArray2 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                    str2 = string.Concat(objArray2);
                    responseNext = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
                    if (!responseNext)
                    {
                        return responseNext;
                    }
                    bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC });
                    if (flag2)
                    {
                        responseNext = false;
                        if (cOutData.Length >= 20)
                        {
                            if (cOutData.ToString().Substring(2, 2) == "04")
                            {
                                string str3 = cOutData.ToString().Substring(0, 2);
                                if (str3 != null)
                                {
                                    if (str3 == "85")
                                    {
                                        responseNext = GetResponseRecordList(cOutData.ToString(), ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                    }
                                    else if ((str3 == "86") || (str3 == "87"))
                                    {
                                    }
                                }
                            }
                            else if (cOutData.ToString().Substring(2, 2) == "05")
                            {
                                string str4 = cOutData.ToString().Substring(0, 2);
                                if (str4 != null)
                                {
                                    if (str4 == "85")
                                    {
                                        responseNext = GetResponseNext(cOutData.ToString(), ref str_NextOrMD5);
                                    }
                                    else if (str4 == "86")
                                    {
                                    }
                                }
                            }
                            else
                            {
                                string str5;
                                if ((cOutData.ToString().Substring(2, 2) == "06") && ((str5 = cOutData.ToString().Substring(0, 2)) != null))
                                {
                                    if (str5 == "85")
                                    {
                                        responseNext = GetResponseMD5(cOutData.ToString(), ref OADBuff_MD5, ref str_NextOrMD5);
                                    }
                                    else if (str5 == "86")
                                    {
                                    }
                                }
                            }
                        }
                    }
                    PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                }
                return responseNext;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                linkData = builder3.ToString();
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str2 = string.Concat(objArray4);
                responseNext = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref linkData, Choice_Sec, str2, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
                if (!responseNext)
                {
                    return responseNext;
                }
                int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 3, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), linkData, MAC, cOutData);
                if (num == 0)
                {
                    responseNext = false;
                    if (cOutData.Length >= 20)
                    {
                        if (cOutData.ToString().Substring(2, 2) == "04")
                        {
                            string str6 = cOutData.ToString().Substring(0, 2);
                            if (str6 != null)
                            {
                                if (str6 == "85")
                                {
                                    responseNext = GetResponseRecordList(cOutData.ToString(), ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData);
                                }
                                else if ((str6 == "86") || (str6 == "87"))
                                {
                                }
                            }
                        }
                        else if (cOutData.ToString().Substring(2, 2) == "05")
                        {
                            string str7 = cOutData.ToString().Substring(0, 2);
                            if (str7 != null)
                            {
                                if (str7 == "85")
                                {
                                    responseNext = GetResponseNext(cOutData.ToString(), ref str_NextOrMD5);
                                }
                                else if (str7 == "86")
                                {
                                }
                            }
                        }
                        else
                        {
                            string str8;
                            if ((cOutData.ToString().Substring(2, 2) == "06") && ((str8 = cOutData.ToString().Substring(0, 2)) != null))
                            {
                                if (str8 == "85")
                                {
                                    responseNext = GetResponseMD5(cOutData.ToString(), ref OADBuff_MD5, ref str_NextOrMD5);
                                }
                                else if (str8 == "86")
                                {
                                }
                            }
                        }
                    }
                }
                PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
            }
            return responseNext;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string OAD_Buff, ref List<List<string>> List_ParseData_二级, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x10);
            StringBuilder builder2 = new StringBuilder(0x10);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if ((PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref oppOutRand)) && EncryptServerConnect.GetOutRand(8, ref builder2))
                {
                    oppOutRand.Append(builder2);
                    str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(8, ref oppOutRand) && EncryptServerConnect.GetOutRand(8, ref builder2))
            {
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
            }
            return flag;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string OAD_Buff, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x10);
            StringBuilder builder2 = new StringBuilder(0x10);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if ((PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref oppOutRand)) && EncryptServerConnect.GetOutRand(8, ref builder2))
                {
                    oppOutRand.Append(builder2);
                    str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(8, ref oppOutRand) && EncryptServerConnect.GetOutRand(8, ref oppOutRand))
            {
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
            }
            return flag;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x10);
            StringBuilder builder2 = new StringBuilder(0x10);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if ((PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref oppOutRand)) && EncryptServerConnect.GetOutRand(8, ref builder2))
                {
                    oppOutRand.Append(builder2);
                    str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(8, ref oppOutRand) && EncryptServerConnect.GetOutRand(8, ref builder2))
            {
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
            }
            return flag;
        }

        public static bool Math_明文_RN(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string getRecord_Num, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> List_ParseData, ref string OADBuff_MD5, ref string str_NextOrMD5, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
        {
            bool flag = false;
            StringBuilder oppOutRand = new StringBuilder(0x20);
            StringBuilder builder2 = new StringBuilder(0x20);
            string str = "";
            if (!PublicVariable.LinkRoadFlag)
            {
                if ((PublicVariable.IsLink && EncryptServerConnect.GetOutRand(8, ref oppOutRand)) && EncryptServerConnect.GetOutRand(8, ref builder2))
                {
                    oppOutRand.Append(builder2);
                    str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
                    if (!flag)
                    {
                    }
                }
                return flag;
            }
            if (EncryptServerConnect.GetOutRand(8, ref oppOutRand) && EncryptServerConnect.GetOutRand(8, ref builder2))
            {
                oppOutRand.Append(builder2);
                str = ((oppOutRand.Length / 2)).ToString("X2") + oppOutRand.ToString();
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string OAD_Buff, ref List<List<string>> List_ParseData_二级, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
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
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData_二级, ref MAC, ref SpliteFlag);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string OAD_Buff, ref List<string> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
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
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref OAD_Buff, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> List_ParseData, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
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
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC, ref SpliteFlag);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

        public static bool Math_明文_SIDMAC(string Choice_S_M, string Choice_Sec, ref string Linkdata, ref string getRecord_Num, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> List_ParseData, ref string OADBuff_MD5, ref string str_NextOrMD5, ref string MAC, ref bool SpliteFlag, ref StringBuilder cOutData)
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
                    flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
                    if (flag)
                    {
                        bool flag2 = EncryptServerConnect.MethodEncryptServer698(OOPEncryptor.NetEncryptor, OOPMethod.VerifyMeterData, ref cOutData, new object[] { PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC });
                        PublicVariable.MAC_Info = "(数据校验" + (flag2 ? "成功" : "失败") + ')';
                    }
                }
                return flag;
            }
            if (SocketApi.Obj_Meter_Formal_GetMeterSetData(1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, builder, builder2, builder3, builder4) == 0)
            {
                object[] objArray4 = new object[] { builder, (builder2.Length / 2).ToString("X2"), builder2, (builder4.Length / 2).ToString("X2"), builder4 };
                str = string.Concat(objArray4);
                flag = SECURITY_Request("43", PublicVariable.Address, PublicVariable.Client_Add, Choice_S_M, ref Linkdata, Choice_Sec, str, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextOrMD5, ref MAC, ref SpliteFlag);
                if (flag)
                {
                    int num = SocketApi.Obj_Meter_Formal_VerifyMeterData(PublicVariable.Key_State, 1, PublicVariable.ESAM_ID, PublicVariable.cOutSessionKey.ToString(), Linkdata, MAC, cOutData);
                    PublicVariable.MAC_Info = "(数据校验" + ((num == 0) ? "成功" : ("失败" + num.ToString())) + ')';
                }
            }
            return flag;
        }

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
                for (int j = 0; j <= ((meterAdd.Length / 2) - 2); j++)
                {
                    str = "0x" + meterAdd.Substring(2 * (((meterAdd.Length / 2) - 1) - j), 2);
                    buffer2[(j + index) + 5] = Convert.ToByte(str, 0x10);
                }
                buffer2[(index + (meterAdd.Length / 2)) + 4] = Convert.ToByte("0x" + Client_Add, 0x10);
                byte[] destinationArray = new byte[4 + (meterAdd.Length / 2)];
                Array.Copy(buffer2, index + 1, destinationArray, 0, 4 + (meterAdd.Length / 2));
                sData = PublicVariable.GetCrc16(destinationArray);
                Array.Clear(array, 0, 2);
                array = PublicVariable.HexToByte(PublicVariable.BackString(sData));
                array.CopyTo(buffer2, (int) ((index + (meterAdd.Length / 2)) + 5));
                byte[] buffer4 = new byte[cData.Length / 2];
                PublicVariable.HexToByte(cData).CopyTo(buffer2, (int) ((index + (meterAdd.Length / 2)) + 7));
                byte[] buffer5 = new byte[(6 + (meterAdd.Length / 2)) + (cData.Length / 2)];
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

        public static void ParseArray(ref string str, byte Len, ref List<List<string>> data)
        {
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref data);
            }
        }

        public static void ParseArray(ref string str, byte Len, ref List<string> data)
        {
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref data);
            }
        }

        public static void ParseArray(ref string str, byte Len, ref List<string> data, TreeList mytreeList, TreeListNode rootnode)
        {
            TreeListNode node = mytreeList.AppendNode(new object[] { "" }, rootnode);
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref data, mytreeList, node);
            }
        }

        public static void ParseStruct(ref string str, byte Len, ref List<List<string>> data)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref list);
            }
            data.Add(list);
        }

        public static void ParseStruct(ref string str, byte Len, ref List<string> data)
        {
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref data);
            }
        }

        public static void ParseStruct(ref string str, byte Len, ref List<string> data, TreeList mytreeList, TreeListNode rootnode)
        {
            TreeListNode node = mytreeList.AppendNode(new object[] { "" }, rootnode);
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref data, mytreeList, node);
            }
        }

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

        public static string ROAD(string Ob_OAD1, byte SEQ_Of_OAD2, string str_OAD2)
        {
            try
            {
                return (Ob_OAD1 + SEQ_Of_OAD2.ToString("X2") + str_OAD2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string OAD_Buff, ref List<List<string>> List_ParseData, ref string MAC, ref bool SplitFlag)
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
                    LinkData = "";
                    new List<string>();
                    if (RecIsProtocol(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                    {
                        flag = SECURITY_Response(ref LinkData, ref OAD_Buff, ref List_ParseData, ref MAC);
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

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string OAD_Buff, ref List<string> List_ParseData, ref string MAC, ref bool SplitFlag)
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
                    List<string> list = new List<string>();
                    if (RecIsProtocol(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                    {
                        flag = SECURITY_Response(ref LinkData, ref str5, ref OAD_Buff, ref list, ref List_ParseData, ref MAC);
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

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> List_ParseData, ref string MAC, ref bool SplitFlag)
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
                    LinkData = "";
                    new List<string>();
                    if (RecIsProtocol(PublicVariable.RecDataString, ref LinkData, ref SplitFlag))
                    {
                        flag = SECURITY_Response(ref LinkData, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref MAC);
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

        public static bool SECURITY_Request(string Con_Code, string meterAdd, string Client_Add, string Choice_S_M, ref string LinkData, string Choice_Sec, string Sec_Validtion, ref string getRecord_Num, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> List_ParseData, ref string OADBuff_MD5, ref string str_NextorMD5, ref string MAC, ref bool SplitFlag)
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
                        flag = SECURITY_Response(ref LinkData, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref List_ParseData, ref OADBuff_MD5, ref str_NextorMD5, ref MAC);
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

        public static bool SECURITY_Response(ref string LinkStr, ref string OAD_Buff, ref List<List<string>> List_ParseData_二级, ref string MAC)
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
                int num2 = 0;
                int num3 = 0;
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    List_ParseData_二级.Clear();
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
                        if (buffer[4 + num2] == 1)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    flag = GetResponseNormal(linkData, ref OAD_Buff, ref List_ParseData_二级);
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
                        else if (buffer[4 + num2] == 2)
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

        public static bool SECURITY_Response(ref string LinkStr, ref string PIID_Buff, ref string OAD_Buff, ref List<string> List_OAD_Buff, ref List<string> List_ParseData, ref string MAC)
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
                int num2 = 0;
                int num3 = 0;
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    List_ParseData.Add("");
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
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    flag = GetResponseNormal(linkData, ref PIID_Buff, ref OAD_Buff, ref List_ParseData);
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
                        else if (buffer[4 + num2] == 2)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    flag = Protocol.GetResponseNormalList(linkData, ref PIID_Buff, ref List_OAD_Buff, ref List_ParseData);
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

        public static bool SECURITY_Response(ref string LinkStr, ref string Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> list_ParseData_多级, ref string MAC)
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
                int num2 = 0;
                int num3 = 0;
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    list_ParseData_多级.Clear();
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
                        if (buffer[4 + num2] == 3)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    flag = GetResponseRecord(linkData, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref list_ParseData_多级);
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
                        else if (buffer[4 + num2] == 2)
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

        public static bool SECURITY_Response(ref string LinkStr, ref string getRecord_Num, ref List<string> Rercord_OAD, ref List<string> rel_Num, ref List<List<string>> Rel_RCSD, ref List<string> Record_Num, ref List<List<List<List<string>>>> list_ParseData_多级, ref string OADBuff_MD5, ref string str_NextOrMD5, ref string MAC)
        {
            try
            {
                if (LinkStr.Length < 8)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                bool responseNext = false;
                byte[] buffer = PublicVariable.HexToByte(LinkStr);
                byte num = buffer[1];
                string linkData = "";
                int num2 = 0;
                int num3 = 0;
                if (num == 2)
                {
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, ((DAR) buffer[2]).ToString(), '-' });
                    list_ParseData_多级.Clear();
                    responseNext = false;
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
                        if (buffer[4 + num2] == 4)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    responseNext = GetResponseRecordList(linkData, ref getRecord_Num, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref list_ParseData_多级);
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
                        else if (buffer[4 + num2] == 5)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    responseNext = GetResponseNext(linkData, ref str_NextOrMD5);
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
                        else if (buffer[4 + num2] == 6)
                        {
                            switch (buffer[3 + num2])
                            {
                                case 0x85:
                                    responseNext = GetResponseMD5(linkData, ref OADBuff_MD5, ref str_NextOrMD5);
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
                            responseNext = true;
                        }
                        else
                        {
                            responseNext = false;
                            MessageBox.Show("返回帧有误，请检查");
                        }
                    }
                    LinkStr = LinkStr.Substring(6 + (num2 * 2), num3 * 2);
                }
                return responseNext;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct getRecord
        {
            public string Str_OAD;
            public string Str_RSD;
            public string Str_RCSD;
        }
    }
}

