using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ht_698._45.UI
{
    public partial class AutoReport : Form
    {
        private static string Address_手动 = "05111111111111";
        private SerialPort AutoCom;
        public static string comport = "COM2";
        public static string comsetting = "9600,E,8,1";
        public bool BeginRecState;
        private string outMAC;
        private string outRand;
        private string ReportDataRegion;
        private TreeListNode rootNode;
        private IniFile iniFile;
        public AutoReport(Form_Main parent)
        {
            this.AutoCom = new SerialPort();
            this.outMAC = "";
            this.outRand = "";
            this.ReportDataRegion = "";
            this.iniFile = new IniFile(Application.StartupPath + @"\Comm_Info.ini");
            this.InitializeComponent();
            base.MdiParent = parent;
        }
        public bool A_Result(ref string str, ref List<string> OAD_Buff, ref List<string> data, TreeList mytreeList, TreeListNode node)
        {
            try
            {
                if (str.Length >= 8)
                {
                    OAD_Buff.Add(str.Substring(0, 8));
                    string str2 = "";
                    if (str.Substring(0, 8) == "33200200")
                    {
                        str2 = "----新增上报列表";
                    }
                    else if (str.Substring(0, 8) == "20150200")
                    {
                        str2 = "----跟随上报状态字";
                    }
                    else
                    {
                        str2 = "其他";
                    }
                    TreeListNode rootnode = this.UpDateTreelistNode(mytreeList, node, str.Substring(0, 8) + str2);
                    if (str.Substring(8, 2) == "01")
                    {
                        str = str.Substring(10);
                        this.AnalyDataType(ref str, ref data, mytreeList, rootnode);
                        return true;
                    }
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, OAD_Buff, ((DAR)Convert.ToByte(str.Substring(10, 2), 0x10)).ToString(), "-" });
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
        private bool A_ResultRecord(string str, ref List<string> Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> ParseData)
        {
            try
            {
                Rercord_OAD.Add(str.Substring(2, 8));
                str = str.Substring(10);
                this.Get_RCSD(ref str, ref rel_Num, ref Rel_RCSD);
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
                    return true;
                }
                if (str.Substring(0, 2) == "00")
                {
                    str = str.Substring(2);
                    PublicVariable.DARInfo = string.Concat(new object[] { "-", PublicVariable.DARInfo, Rercord_OAD, ((DAR)Convert.ToByte(str.Substring(0, 2), 0x10)).ToString(), "-" });
                    str = str.Substring(2);
                    ParseData.Clear();
                    return false;
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }
        public static bool AnalyDataType(ref string str, ref List<string> data)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] buffer = PublicVariable.HexToByte(str);
            string str2 = "";
            switch (((DataType)buffer[0]))
            {
                case DataType.NULL:
                    data.Add("");
                    str = str.Substring(2);
                    goto Label_07B2;

                case DataType.Array:
                    str = str.Substring(4);
                    ParseArray(ref str, buffer[1], ref data);
                    goto Label_07B2;

                case DataType.Structure:
                    str = str.Substring(4);
                    ParseStruct(ref str, buffer[1], ref data);
                    goto Label_07B2;

                case DataType.Bool:
                    data.Add(str.Substring(2, 2));
                    str = str.Substring(4);
                    goto Label_07B2;

                case DataType.Bitstring:
                    {
                        byte num = buffer[1];
                        data.Add(str.Substring(4, 2 * (num / 8)));
                        str = str.Substring((2 + (num / 8)) * 2);
                        goto Label_07B2;
                    }
                case DataType.Doublelong:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    str = str.Substring(10);
                    goto Label_07B2;

                case DataType.Doublelongunsigned:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    str = str.Substring(10);
                    goto Label_07B2;

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
                        goto Label_07B2;
                    }
                case DataType.Visiblestring:
                    {
                        byte num4 = buffer[1];
                        str2 = PublicVariable.ASCIIHexstrTostr(str.Substring(4, 2 * num4));
                        data.Add(str2);
                        str = str.Substring((2 + num4) * 2);
                        goto Label_07B2;
                    }
                case DataType.Long:
                    str2 = str.Substring(2, 4);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    str = str.Substring(6);
                    goto Label_07B2;

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
                    goto Label_07B2;

                case DataType.long64:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    str = str.Substring(0x12);
                    goto Label_07B2;

                case DataType.long64unsigned:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    str = str.Substring(0x12);
                    goto Label_07B2;

                case DataType.Enum:
                    str2 = str.Substring(2, 2);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    str = str.Substring(4);
                    goto Label_07B2;

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
                    goto Label_07B2;

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
                        goto Label_07B2;
                    }
                case DataType.OI:
                    data.Add(str.Substring(2, 4));
                    str = str.Substring(6);
                    goto Label_07B2;

                case DataType.OAD:
                    data.Add(str.Substring(2, 8));
                    str = str.Substring(10);
                    goto Label_07B2;

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
                        goto Label_07B2;
                    }
                case DataType.OMD:
                    data.Add(str.Substring(2, 8));
                    str = str.Substring(10);
                    goto Label_07B2;

                case DataType.Scaler_Unit:
                    data.Add((0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2"));
                    data.Add(((UnitsEnum)Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString());
                    str = str.Substring(6);
                    goto Label_07B2;

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
                        goto Label_07B2;
                    }
                case DataType.COMDCB:
                    data.Add(str.Substring(2, 10));
                    str = str.Substring(12);
                    goto Label_07B2;

                default:
                    goto Label_07B2;
            }
            str = str.Substring(4);
        Label_07B2:
            return true;
        }

        public bool AnalyDataType(ref string str, ref List<string> data, TreeList mytreeList, TreeListNode rootnode)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] buffer = PublicVariable.HexToByte(str);
            string str2 = "";
            switch (((DataType)buffer[0]))
            {
                case DataType.NULL:
                    data.Add("");
                    mytreeList.AppendNode(new object[] { "" }, rootnode);
                    str = str.Substring(2);
                    goto Label_0BF5;

                case DataType.Array:
                    str = str.Substring(4);
                    this.ParseArray(ref str, buffer[1], ref data, mytreeList, rootnode);
                    goto Label_0BF5;

                case DataType.Structure:
                    str = str.Substring(4);
                    this.ParseStruct(ref str, buffer[1], ref data, mytreeList, rootnode);
                    goto Label_0BF5;

                case DataType.Bool:
                    mytreeList.AppendNode(new object[] { str.Substring(2, 2) }, rootnode);
                    data.Add(str.Substring(2, 2));
                    str = str.Substring(4);
                    goto Label_0BF5;

                case DataType.Bitstring:
                    {
                        byte num = buffer[1];
                        data.Add(str.Substring(4, 2 * (num / 8)));
                        mytreeList.AppendNode(new object[] { str.Substring(4, 2 * (num / 8)) }, rootnode);
                        str = str.Substring((2 + (num / 8)) * 2);
                        goto Label_0BF5;
                    }
                case DataType.Doublelong:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt32(str2, 0x10).ToString("D8") }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BF5;

                case DataType.Doublelongunsigned:
                    str2 = str.Substring(2, 8);
                    data.Add(Convert.ToInt32(str2, 0x10).ToString("D8"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt32(str2, 0x10).ToString("D8") }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BF5;

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
                        goto Label_0BF5;
                    }
                case DataType.Visiblestring:
                    {
                        byte num4 = buffer[1];
                        str2 = PublicVariable.ASCIIHexstrTostr(str.Substring(4, 2 * num4));
                        data.Add(str2);
                        mytreeList.AppendNode(new object[] { str2 }, rootnode);
                        str = str.Substring((2 + num4) * 2);
                        goto Label_0BF5;
                    }
                case DataType.Long:
                    str2 = str.Substring(2, 4);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D4"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt16(str2, 0x10).ToString("D4") }, rootnode);
                    str = str.Substring(6);
                    goto Label_0BF5;

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
                    goto Label_0BF5;

                case DataType.long64:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt64(str2, 0x10).ToString("D16") }, rootnode);
                    str = str.Substring(0x12);
                    goto Label_0BF5;

                case DataType.long64unsigned:
                    str2 = str.Substring(2, 0x10);
                    data.Add(Convert.ToInt64(str2, 0x10).ToString("D16"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt64(str2, 0x10).ToString("D16") }, rootnode);
                    str = str.Substring(0x12);
                    goto Label_0BF5;

                case DataType.Enum:
                    str2 = str.Substring(2, 2);
                    data.Add(Convert.ToInt16(str2, 0x10).ToString("D2"));
                    mytreeList.AppendNode(new object[] { Convert.ToInt16(str2, 0x10).ToString("D2") }, rootnode);
                    str = str.Substring(4);
                    goto Label_0BF5;

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
                    goto Label_0BF5;

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
                        goto Label_0BF5;
                    }
                case DataType.OI:
                    data.Add(str.Substring(2, 4));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 4) }, rootnode);
                    str = str.Substring(6);
                    goto Label_0BF5;

                case DataType.OAD:
                    data.Add(str.Substring(2, 8));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 8) }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BF5;

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
                        goto Label_0BF5;
                    }
                case DataType.OMD:
                    data.Add(str.Substring(2, 8));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 8) }, rootnode);
                    str = str.Substring(10);
                    goto Label_0BF5;

                case DataType.Scaler_Unit:
                    {
                        data.Add((0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2"));
                        object[] nodeData = new object[] { (0x100 - Convert.ToInt16(str.Substring(2, 2), 0x10)).ToString("D2") };
                        mytreeList.AppendNode(nodeData, rootnode);
                        data.Add(((UnitsEnum)Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString());
                        mytreeList.AppendNode(new object[] { ((UnitsEnum)Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString() }, rootnode);
                        str = str.Substring(6);
                        goto Label_0BF5;
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
                        goto Label_0BF5;
                    }
                case DataType.COMDCB:
                    data.Add(str.Substring(2, 10));
                    mytreeList.AppendNode(new object[] { str.Substring(2, 10) }, rootnode);
                    str = str.Substring(12);
                    goto Label_0BF5;

                default:
                    goto Label_0BF5;
            }
            str = str.Substring(4);
        Label_0BF5:
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
            switch (((DataType)buffer[0]))
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
                    item.Add(((UnitsEnum)Convert.ToInt16(str.Substring(4, 2), 0x10)).ToString());
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

        private void AutoReport_Load(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                str = this.iniFile.IniReadValue("ATUOCOM", "com");
                if (str == "")
                {
                    str = "COM1";
                }
                comport = str;
                str = this.iniFile.IniReadValue("ATUOCOM", "comsetting");
                if (str == "")
                {
                    str = "9600,Even,8,1";
                }
                comsetting = str;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.isButtonMathod(Address_手动);
        }
        public string ByteToHex(byte[] comByte)
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
        private bool ExplainDLT698(byte[] byteBuffer)
        {
            int index = 0;
            int length = 0;
            if (byteBuffer.Length < 15)
            {
                return false;
            }
            try
            {
                for (int i = 0; i <= 6; i++)
                {
                    if (byteBuffer[i] == 0xfe)
                    {
                        index++;
                    }
                }
                byte[] destinationArray = new byte[(byteBuffer.Length - index) - 4];
                if (byteBuffer[index] != 0x68)
                {
                    return false;
                }
                length = byteBuffer.Length;
                Array.Copy(byteBuffer, index + 1, destinationArray, 0, (length - index) - 4);
                if (byteBuffer[length - 1] != 0x16)
                {
                    return false;
                }
                if (!PublicVariable.GetCrc16(destinationArray).Equals(byteBuffer[length - 2].ToString("X2") + byteBuffer[length - 3].ToString("X2")))
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "ExplainDLT698");
                return false;
            }
        }

        public string Get_RCSD(ref string str, ref string rel_Num, ref List<string> Rel_RCSD)
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

        public bool GetResponseNormal(string LinkData, byte N, ref List<string> OAD_Buff, ref string PIID_Buff, ref List<string> ParseData, TreeList treelist)
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
                byte num = buffer[N];
                string str = LinkData.Substring(8);
                TreeListNode node = this.UpDateTreelistNode(treelist, null, "电能表主动上报内容");
                for (byte i = 0; i < num; i = (byte)(i + 1))
                {
                    flag = this.A_Result(ref str, ref OAD_Buff, ref ParseData, treelist, node);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool GetResponseNormal(string LinkData, byte N, ref List<string> OAD_Buff, ref string PIID_Buff, ref string ReportDataRegion, ref List<string> ParseData, ref string OutRand, ref string OutMAC, TreeList treelist)
        {
            try
            {
                if (LinkData.Length < 0x48)
                {
                    return false;
                }
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                byte[] buffer = PublicVariable.HexToByte(LinkData);
                ReportDataRegion = LinkData.Substring(6, buffer[2] * 2);
                PIID_Buff = LinkData.Substring(10, 2);
                byte num = buffer[N];
                string str = LinkData.Substring(8 + N);
                TreeListNode node = this.UpDateTreelistNode(treelist, null, "电能表主动上报内容");
                for (byte i = 0; i < num; i = (byte)(i + 1))
                {
                    flag = this.A_Result(ref str, ref OAD_Buff, ref ParseData, treelist, node);
                }
                OutRand = str.Substring(8, 0x18);
                OutMAC = str.Substring(0x22, 8);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool GetResponseRecord(string LinkData, ref string PIID_Buff, ref List<string> Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> ParseData)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                if (LinkData.Length < 0x18)
                {
                    return false;
                }
                string str = LinkData.Substring(6);
                PIID_Buff = str.Substring(4, 2);
                byte num = Convert.ToByte(str.Substring(0, 2), 0x10);
                for (byte i = 0; i < num; i = (byte)(i + 1))
                {
                    rel_Num = "";
                    Rel_RCSD.Clear();
                    Record_Num = "";
                    ParseData.Clear();
                    flag = this.A_ResultRecord(str, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref ParseData);
                    if (flag)
                    {
                        this.UpDateTree(this.Report_display, Rercord_OAD[i], rel_Num, Rel_RCSD, Record_Num, ParseData);
                    }
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool GetResponseRecord(string LinkData, ref List<string> Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> ParseData, ref string PIID_Buff, ref string ReportDataRegion, ref string outRand, ref string outMAC)
        {
            try
            {
                PublicVariable.DARInfo = "";
                PublicVariable.MAC_Info = "";
                bool flag = false;
                if (LinkData.Length < 0x18)
                {
                    return false;
                }
                byte num = Convert.ToByte(LinkData.Substring(4, 2), 0x10);
                ReportDataRegion = LinkData.Substring(6, 2 * num);
                PIID_Buff = LinkData.Substring(10, 2);
                string str = LinkData.Substring(12);
                byte num2 = Convert.ToByte(str.Substring(0, 2), 0x10);
                for (byte i = 0; i < num2; i = (byte)(i + 1))
                {
                    rel_Num = "";
                    Rel_RCSD.Clear();
                    Record_Num = "";
                    ParseData.Clear();
                    flag = this.A_ResultRecord(str, ref Rercord_OAD, ref rel_Num, ref Rel_RCSD, ref Record_Num, ref ParseData);
                    if (flag)
                    {
                        this.UpDateTree(this.Report_display, Rercord_OAD[i], rel_Num, Rel_RCSD, Record_Num, ParseData);
                    }
                }
                outRand = LinkData.Substring((num * 2) + 10, 0x18);
                outMAC = LinkData.Substring((((num * 2) + 10) + 0x18) + 2, 8);
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }
          private void isButtonMathod(string add)
        {
            if (this.rd_手动.Checked && !this.ck_费控.Checked)
            {
                if (this.ReportResponseList("03", add, "00"))
                {
                    this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
                }
            }
            else if ((this.rd_手动.Checked && this.ck_费控.Checked) && this.ReportResponseList_MAC_手动(add, "00", this.outRand, this.ReportDataRegion, this.outMAC))
            {
                this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
            }
        }

        public string MakeReportReposeData(List<string> Str_OAD, string Choice, string meterAdd, string Client_Add, string PIID_Buff, bool TimeTag)
        {
            try
            {
                string str = null;
                string str2 = "08";
                if (TimeTag)
                {
                    string str3 = "";
                    for (int i = 0; i < Str_OAD.Count; i++)
                    {
                        str3 = str3 + Str_OAD[i];
                    }
                    str = str2 + Choice + PIID_Buff + Str_OAD.Count.ToString("X2") + str3 + "01" + PublicVariable.TimeText;
                }
                else
                {
                    string str4 = "";
                    for (int i = 0; i < Str_OAD.Count; i++)
                    {
                        str4 = str4 + Str_OAD[i];
                    }
                    str = str2 + Choice + PIID_Buff + Str_OAD.Count.ToString("X2") + str4 + "00";
                }
                return str;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return "";
            }
        }

        public bool OrigDLT698Wrap(string DataLen, string Con_Code, string meterAdd, string Client_Add, string cData, bool TimeTag)
        {
            try
            {
                if (!this.AutoCom.IsOpen)
                {
                    this.AutoCom.Open();
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
                this.SendData(SerialPortUtil.HexToByte(str));
                PublicVariable.BeginRecState = true;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }
         public static void ParseArray(ref string str, byte Len, ref List<string> data)
        {
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref data);
            }
        }

        public void ParseArray(ref string str, byte Len, ref List<string> data, TreeList mytreeList, TreeListNode rootnode)
        {
            for (int i = 0; i < Len; i++)
            {
                this.AnalyDataType(ref str, ref data, mytreeList, rootnode);
            }
        }

        public static void ParseStruct(ref string str, byte Len, ref List<string> data)
        {
            for (int i = 0; i < Len; i++)
            {
                AnalyDataType(ref str, ref data);
            }
        }

        public void ParseStruct(ref string str, byte Len, ref List<string> data, TreeList mytreeList, TreeListNode rootnode)
        {
            for (int i = 0; i < Len; i++)
            {
                this.AnalyDataType(ref str, ref data, mytreeList, rootnode);
            }
        }

        public byte[] Read(int NumBytes)
        {
            byte[] buffer = new byte[NumBytes];
            byte[] destinationArray = new byte[0];
            if (this.AutoCom.IsOpen)
            {
                try
                {
                    if (this.AutoCom.BytesToRead > 0)
                    {
                        int length = this.AutoCom.Read(buffer, 0, NumBytes);
                        if (length > 0)
                        {
                            destinationArray = new byte[length];
                            Array.Copy(buffer, destinationArray, length);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + "Read");
                    return destinationArray;
                }
            }
            return destinationArray;
        }

        private byte[] Receive() 
        {
            return this.Read(520);
        }
        public bool ReceiveData(ref byte[] pbReceive)
        {
            try
            {
                long tickCount = Environment.TickCount;
                bool flag = false;
                byte[] destinationArray = new byte[0x1000];
                pbReceive = new byte[0];
                int destinationIndex = 0;
                while (!flag)
                {
                    if ((Environment.TickCount - tickCount) > 0xbb8L)
                    {
                        break;
                    }
                    byte[] sourceArray = this.Receive();
                    Thread.Sleep(1);
                    Application.DoEvents();
                    if (sourceArray.Length > 0)
                    {
                        Array.Copy(sourceArray, 0, destinationArray, destinationIndex, sourceArray.Length);
                        destinationIndex += sourceArray.Length;
                        if ((destinationArray[destinationIndex - 1] == 0x16) && (destinationIndex >= 12))
                        {
                            int sourceIndex = 0;
                            byte[] buffer3 = new byte[destinationIndex - sourceIndex];
                            Array.Copy(destinationArray, sourceIndex, buffer3, 0, buffer3.Length);
                            if (this.ExplainDLT698(buffer3))
                            {
                                pbReceive = buffer3;
                                flag = true;
                            }
                        }
                    }
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "ReceiveData");
                pbReceive = new byte[0];
                return false;
            }
        }

        public bool ReportResponseList(string Con_Code, string meterAdd, string Client_Add)
        {
            try
            {
                string dataLen = null;
                PublicVariable.PIID_R = (byte)(PublicVariable.PIID_R + 1);
                dataLen = ((short)((8 + (meterAdd.Length / 2)) + (this.txt_确认.Text.Length / 2))).ToString("X4");
                return this.OrigDLT698Wrap(dataLen, Con_Code, meterAdd, Client_Add, this.txt_确认.Text, false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool ReportResponseList(List<string> Str_OAD, string Choice, string Con_Code, string meterAdd, string Client_Add, string PIID_Buff, bool TimeTag)
        {
            try
            {
                string cData = null;
                string dataLen = null;
                string str3 = "08";
                bool flag = false;
                if (TimeTag)
                {
                    string str4 = "";
                    for (int i = 0; i < Str_OAD.Count; i++)
                    {
                        str4 = str4 + Str_OAD[i];
                    }
                    cData = str3 + Choice + PIID_Buff + Str_OAD.Count.ToString("X2") + str4 + "01" + PublicVariable.TimeText;
                    dataLen = ((short)((8 + (meterAdd.Length / 2)) + (cData.Length / 2))).ToString("X4");
                    flag = this.OrigDLT698Wrap(dataLen, Con_Code, meterAdd, Client_Add, cData, TimeTag);
                }
                else
                {
                    string str5 = "";
                    for (int i = 0; i < Str_OAD.Count; i++)
                    {
                        str5 = str5 + Str_OAD[i];
                    }
                    cData = str3 + Choice + PIID_Buff + Str_OAD.Count.ToString("X2") + str5 + "00";
                    dataLen = ((short)((8 + (meterAdd.Length / 2)) + (cData.Length / 2))).ToString("X4");
                    flag = this.OrigDLT698Wrap(dataLen, Con_Code, meterAdd, Client_Add, cData, TimeTag);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool ReportResponseList_MAC(List<string> Str_OAD, string Choice, string meterAdd, string PIID_Buff, string Choice_S_M, string iRand, string RepartData, string ReportMAC)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder cOutData = new StringBuilder(10);
            StringBuilder cOutRSPCTR = new StringBuilder(20);
            new StringBuilder(8);
            StringBuilder outSID = new StringBuilder(10);
            StringBuilder outAttachData = new StringBuilder(40);
            StringBuilder builder5 = new StringBuilder(600);
            StringBuilder ucOutMac = new StringBuilder(10);
            string str = "90";
            string cData = "";
            string cReportData = "";
            string dataLen = "";
            if (SocketApi.Obj_Meter_Formal_VerifyReportData(0, 0, PublicVariable.Meter_NO, iRand, RepartData, ReportMAC, cOutData, cOutRSPCTR) == 0)
            {
                cReportData = this.MakeReportReposeData(Str_OAD, Choice, meterAdd, "00", PIID_Buff, false);
                if (SocketApi.Obj_Meter_Formal_GetResponseData(0, 1, PublicVariable.Meter_NO, iRand, cReportData, outSID, outAttachData, builder5, ucOutMac) == 0)
                {
                    object[] objArray = new object[] { str, Choice_S_M, (cReportData.Length / 2).ToString("X2"), cReportData, "0100", (ucOutMac.Length / 2).ToString("X2"), ucOutMac };
                    cData = string.Concat(objArray);
                    dataLen = ((short)((8 + (meterAdd.Length / 2)) + (cData.Length / 2))).ToString("X4");
                    flag = this.OrigDLT698Wrap(dataLen, "03", meterAdd, "00", cData, false);
                }
            }
            return flag;
        }

        public bool ReportResponseList_MAC_手动(string meterAdd, string Choice_S_M, string iRand, string RepartData, string ReportMAC)
        {
            if (!PublicVariable.ConnetionFlag)
            {
                MessageBox.Show("此操作需要连接加密机");
                return false;
            }
            bool flag = false;
            StringBuilder cOutData = new StringBuilder(10);
            StringBuilder cOutRSPCTR = new StringBuilder(20);
            new StringBuilder(8);
            StringBuilder outSID = new StringBuilder(10);
            StringBuilder outAttachData = new StringBuilder(40);
            StringBuilder builder5 = new StringBuilder(600);
            StringBuilder ucOutMac = new StringBuilder(10);
            string str = "90";
            string cData = "";
            string cReportData = "";
            string dataLen = "";
            if (SocketApi.Obj_Meter_Formal_VerifyReportData(0, 0, PublicVariable.Meter_NO, iRand, RepartData, ReportMAC, cOutData, cOutRSPCTR) == 0)
            {
                cReportData = this.txt_确认.Text.Replace(" ", "") + "00";
                if (SocketApi.Obj_Meter_Formal_GetResponseData(0, 1, PublicVariable.Meter_NO, iRand, cReportData, outSID, outAttachData, builder5, ucOutMac) == 0)
                {
                    object[] objArray = new object[] { str, Choice_S_M, (cReportData.Length / 2).ToString("X2"), cReportData, "0100", (ucOutMac.Length / 2).ToString("X2"), ucOutMac };
                    cData = string.Concat(objArray);
                    dataLen = ((short)((8 + (meterAdd.Length / 2)) + (cData.Length / 2))).ToString("X4");
                    flag = this.OrigDLT698Wrap(dataLen, "03", meterAdd, "00", cData, false);
                }
            }
            return flag;
        }

        private void AutoReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            PublicVariable.BeginRecState = false;
            PublicVariable.isDisplay = false;
            this.tl_监控.Text = "打开监控";
            if (this.AutoCom.IsOpen)
            {
                this.AutoCom.Close();
            }
            Thread.Sleep(0x3e8);
        }
        private void Send(byte[] Val)
        {
            try
            {
                if (!this.AutoCom.IsOpen)
                {
                    this.AutoCom.Open();
                }
                this.Write(Val);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "Send");
            }
        }

        public void SendData(byte[] bSend)
        {
            this.Send(bSend);
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string linkData = "";
                bool bExtend = false;
                string getAddress = "";
                List<string> list = new List<string>();
                List<string> parseData = new List<string>();
                string str3 = "";
                List<string> list3 = new List<string>();
                string str4 = "";
                List<string> list4 = new List<string>();
                string str5 = "";
                List<List<List<string>>> list5 = new List<List<List<string>>>();
                byte[] pbReceive = new byte[0];
                string recString = "";
                if (PublicVariable.isDisplay)
                {
                    if (this.ReceiveData(ref pbReceive))
                    {
                        PublicVariable.isDisplay = false;
                        recString = this.ByteToHex(pbReceive);
                        if ((recString.Length > 0) && Protocol.RecIsProtocol(recString, ref getAddress, ref linkData, ref bExtend))
                        {
                            Address_手动 = getAddress;
                            this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 接收帧] \r\n" + recString);
                            if (linkData.Substring(0, 4) == "8801")
                            {
                                if ((this.GetResponseNormal(linkData, 3, ref list, ref str3, ref parseData, this.Report_display) && this.rd_自动.Checked) && this.ReportResponseList(list, "01", "03", getAddress, "00", str3, false))
                                {
                                    this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
                                }
                            }
                            else if (linkData.Substring(6, 4) == "8801")
                            {
                                if ((this.GetResponseNormal(linkData, 6, ref list, ref str3, ref this.ReportDataRegion, ref parseData, ref this.outRand, ref this.outMAC, this.Report_display) && this.rd_自动.Checked) && this.ReportResponseList_MAC(list, "01", getAddress, str3, "00", this.outRand, this.ReportDataRegion, this.outMAC))
                                {
                                    this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
                                }
                            }
                            else if (linkData.Substring(0, 4) == "8802")
                            {
                                if ((this.GetResponseRecord(linkData, ref str3, ref list3, ref str4, ref list4, ref str5, ref list5) && this.rd_自动.Checked) && this.ReportResponseList(list3, "02", "03", getAddress, "00", str3, false))
                                {
                                    this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
                                }
                            }
                            else if (((linkData.Substring(6, 4) == "8802") && this.GetResponseRecord(linkData, ref list3, ref str4, ref list4, ref str5, ref list5, ref str3, ref this.ReportDataRegion, ref this.outRand, ref this.outMAC)) && (this.rd_自动.Checked && this.ReportResponseList_MAC(list3, "02", getAddress, str3, "00", this.outRand, this.ReportDataRegion, this.outMAC)))
                            {
                                this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
                            }
                        }
                    }
                    PublicVariable.isDisplay = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            this.BeginRecState = true;
        }

        private void tl_监控_Click(object sender, EventArgs e)
        {
            if (this.tl_监控.Text == "打开监控")
            {
                PublicVariable.isDisplay = true;
                this.tl_监控.Text = "关闭监控";
                if (!this.AutoCom.IsOpen)
                {
                    this.AutoCom.PortName = comport;
                    this.AutoCom.BaudRate = Convert.ToInt32(comsetting.Split(new char[] { ',' })[0]);
                    this.AutoCom.DataBits = Convert.ToInt32(comsetting.Split(new char[] { ',' })[2]);
                    this.AutoCom.Parity = Parity.Even;
                    this.AutoCom.StopBits = (StopBits)Convert.ToInt32(comsetting.Split(new char[] { ',' })[3]);
                    this.AutoCom.DataReceived += new SerialDataReceivedEventHandler(this.Sp_DataReceived);
                    this.AutoCom.ReceivedBytesThreshold = 1;
                    try
                    {
                        this.AutoCom.Open();
                        this.toolStripButton1.Enabled = false;
                        this.tl_COM.Text = comport;
                        this.tl_baut.Text = comsetting;
                    }
                    catch
                    {
                        this.tl_监控.Text = "打开监控";
                        MessageBox.Show(comport + " 打开失败！");
                    }
                }
            }
            else if (this.tl_监控.Text == "关闭监控")
            {
                PublicVariable.isDisplay = false;
                this.tl_监控.Text = "打开监控";
                this.toolStripButton1.Enabled = true;
                this.AutoCom.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new AutoReportCom { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        }

        private void txt_报文_DoubleClick(object sender, EventArgs e)
        {
            this.txt_报文.Text = "";
        }
        private void UpDateControl(TextBox txt_Box, string text)
        {
            Thread.Sleep(0);
            if (txt_Box.InvokeRequired)
            {
                txt_Box.Invoke(new UpDateControlDelegate(this.UpDateControl), new object[] { txt_Box, text });
            }
            else
            {
                try
                {
                    txt_Box.Text = txt_Box.Text + "\r\n" + text;
                    Application.DoEvents();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + "UpDateControl");
                }
            }
        }
        private void UpDateTree(TreeList treelist, string Rercord_OAD, string rel_Num, List<string> Rel_RCSD, string Record_Num, List<List<List<string>>> list_ParseData_多级)
        {
            Thread.Sleep(0);
            if (treelist.InvokeRequired)
            {
                treelist.Invoke(new UpDateTreeDelegate(this.UpDateTree), new object[] { treelist, Rercord_OAD, rel_Num, Rel_RCSD, Record_Num, list_ParseData_多级 });
            }
            else
            {
                try
                {
                    DBConnect.DBOpen();
                    DataTable table = new DataTable();
                    table = DBConnect.Result("select ref_PropertyTag,RCSD_OAD,RCSD_Name,RCSD_Dot,RCSD_txt from record_display where ref_PropertyTag='2' or ref_PropertyTag='22'", "treeTable");
                    List<string> list = new List<string>();
                    List<string> list2 = new List<string>();
                    List<string> list3 = new List<string>();
                    treelist.BeginUnboundLoad();
                    TreeListNode parentNode = null;
                    TreeListNode node2 = treelist.AppendNode(new object[] { Rercord_OAD + ((Rercord_OAD == "30110201") ? " --- 上一次掉电记录" : "") }, parentNode);
                    TreeListNode node3 = treelist.AppendNode(new object[] { "共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "列 --- 关联属性列表共" + Convert.ToInt16(rel_Num, 0x10).ToString() + "列" }, node2);
                    for (int i = 0; i < Rel_RCSD.Count; i++)
                    {
                        for (int k = 0; k < table.Rows.Count; k++)
                        {
                            if (Rel_RCSD[i] == table.Rows[k][1].ToString())
                            {
                                list.Add(table.Rows[k][2].ToString());
                                list2.Add(table.Rows[k][3].ToString());
                                list3.Add(table.Rows[k][4].ToString());
                                break;
                            }
                        }
                        if (list.Count != (i + 1))
                        {
                            list.Add("请添加数据库相关说明！");
                            list2.Add("");
                            list3.Add("");
                        }
                        object[] nodeData = new object[1];
                        string[] strArray4 = new string[] { "第", (i + 1).ToString(), "列 --- ", Rel_RCSD[i], " --- ", list[i] };
                        nodeData[0] = string.Concat(strArray4);
                        treelist.AppendNode(nodeData, node3);
                    }
                    //TreeListNode node4 = new TreeListNode();
                    //TreeListNode node5 = new TreeListNode();
                    //new TreeListNode();
                    TreeListNode node4 ;
                    TreeListNode node5;
                    for(int j = 0; j < list_ParseData_多级.Count; j++)
                    {
                        object[] nodeData = new object[1];
                        string[] strArray5 = new string[] { "第", (j + 1).ToString(), "条记录 --- 记录（行）表共", Record_Num, "行" };
                        nodeData[0] = string.Concat(strArray5);
                        node4 = treelist.AppendNode(nodeData, node2);
                        for(int k = 0; k < list_ParseData_多级[j].Count; k++)
                        {
                            string[] strArray = list2[k].Split(new char[] { ',' });
                            string[] strArray2 = list3[k].Split(new char[] { ',' });
                            object[] objArray6 = new object[1];
                            string[] strArray6 = new string[] { "第", (k + 1).ToString(), "列 --- 共", list_ParseData_多级[j][k].Count.ToString(), "项---", list[k] };
                            objArray6[0] = string.Concat(strArray6);
                            node5 = treelist.AppendNode(objArray6, node4);
                            for (int m = 0; m < list_ParseData_多级[j][k].Count; m++)
                            {
                                if (strArray.Length > m)
                                {
                                    if ((strArray[m] != "") && (strArray2.Length > m))
                                    {
                                        treelist.AppendNode(new object[] { PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])) + ((strArray2[m] == "") ? "" : " --- ") + strArray2[m] }, node5);
                                    }
                                    else if ((strArray[m] != "") && (strArray2.Length <= m))
                                    {
                                        treelist.AppendNode(new object[] { PublicVariable.GetFloatstrFromBCDStr(list_ParseData_多级[j][k][m], Convert.ToInt16(strArray[m])) }, node5);
                                    }
                                    else if (strArray2.Length > m)
                                    {
                                        treelist.AppendNode(new object[] { PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) + ((strArray2[m] == "") ? "" : " --- ") + strArray2[m] }, node5);
                                    }
                                    else
                                    {
                                        treelist.AppendNode(new object[] { PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node5);
                                    }
                                }
                                else if (strArray2.Length > m)
                                {
                                    treelist.AppendNode(new object[] { PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) + ((strArray2[m] == "") ? "" : " --- ") + strArray2[m] }, node5);
                                }
                                else
                                {
                                    treelist.AppendNode(new object[] { PublicVariable.GetStringstrFromBCDStr(list_ParseData_多级[j][k][m]) }, node5);
                                }
                            }
                        }
                    }
                    treelist.ExpandToLevel(0);
                    treelist.EndUnboundLoad();
                    DBConnect.DBClose();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + "UpDateControl");
                }
            }
        }

        private void UpDateTreelist(TreeList treelist, string text)
        {
            Thread.Sleep(0);
            if (treelist.InvokeRequired)
            {
                treelist.Invoke(new UpDateTreelistDelegate(this.UpDateTreelist), new object[] { treelist, text });
            }
            else
            {
                try
                {
                    TreeListNode parentNode = null;
                    treelist.AppendNode(new object[] { text }, parentNode);
                    Application.DoEvents();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + "UpDateControl");
                }
            }
        }

        private TreeListNode UpDateTreelistNode(TreeList treelist, TreeListNode node, string text)
        {
            Thread.Sleep(0);
            if (treelist.InvokeRequired)
            {
                treelist.Invoke(new UpDateTreelistNodeDelegate(this.UpDateTreelistNode), new object[] { treelist, node, text });
            }
            else
            {
                try
                {
                    this.rootNode = treelist.AppendNode(new object[] { text }, node);
                    Application.DoEvents();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + "UpDateControl");
                }
            }
            return this.rootNode;
        }

        public void Write(byte[] WriteBytes)
        {
            if (this.AutoCom.IsOpen)
            {
                try
                {
                    this.AutoCom.Write(WriteBytes, 0, WriteBytes.Length);
                }
                catch
                {
                }
            }
        }

        private delegate void UpDateControlDelegate(TextBox txt_Box, string text);

        private delegate void UpDateTreeDelegate(TreeList treelist, string Rercord_OAD, string rel_Num, List<string> Rel_RCSD, string Record_Num, List<List<List<string>>> list_ParseData_多级);

        private delegate void UpDateTreelistDelegate(TreeList treelist, string text);

        private delegate TreeListNode UpDateTreelistNodeDelegate(TreeList treelist, TreeListNode node, string text);
    }
}
