using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace ht_698._45.UI
{
    public partial class selfReport : Form
    {
        private bool isTimeClose;
        private static string Address_手动 = "05111111111111";
        private Thread myThread;
        private TreeListNode rootNode;
        private bool isButton;
        public selfReport(Form_Main parent)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.isButton = true;
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

        public bool GetResponseNormal(string LinkData, ref List<string> OAD_Buff, ref List<string> ParseData, TreeList treelist)
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
                buffer[2].ToString("X2");
                byte num = buffer[3];
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

        public bool GetResponseRecord(string LinkData, ref List<string> Rercord_OAD, ref string rel_Num, ref List<string> Rel_RCSD, ref string Record_Num, ref List<List<List<string>>> ParseData)
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
        private void isButtonMathod(string add)
        {
            if (this.rd_手动.Checked && this.ReportResponseList("03", add, "00"))
            {
                this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
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

        public bool ReportResponseList(string Con_Code, string meterAdd, string Client_Add)
        {
            try
            {
                PublicVariable.PIID_R = (byte)(PublicVariable.PIID_R + 1);
                short num = (short)((8 + (meterAdd.Length / 2)) + (this.txt_确认.Text.Length / 2));
                return Protocol_2.OrigDLT698Wrap(num.ToString("X4"), Con_Code, meterAdd, Client_Add, this.txt_确认.Text, false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool ReportResponseList(List<string> Str_OAD, string Choice, string Con_Code, string meterAdd, string Client_Add, bool TimeTag)
        {
            try
            {
                string cData = null;
                string str3 = "08";
                bool flag = false;
                PublicVariable.PIID_R = (byte)(PublicVariable.PIID_R + 1);
                if (TimeTag)
                {
                    string str4 = "";
                    for (int i = 0; i < Str_OAD.Count; i++)
                    {
                        str4 = str4 + Str_OAD[i];
                    }
                    cData = str3 + Choice + PublicVariable.PIID_R.ToString("X2") + Str_OAD.Count.ToString("X2") + str4 + "01" + PublicVariable.TimeText;
                    flag = Protocol_2.OrigDLT698Wrap(((short)((8 + (meterAdd.Length / 2)) + (cData.Length / 2))).ToString("X4"), Con_Code, meterAdd, Client_Add, cData, TimeTag);
                }
                else
                {
                    string str5 = "";
                    for (int i = 0; i < Str_OAD.Count; i++)
                    {
                        str5 = str5 + Str_OAD[i];
                    }
                    cData = str3 + Choice + PublicVariable.PIID_R.ToString("X2") + Str_OAD.Count.ToString("X2") + str5 + "00";
                    flag = Protocol_2.OrigDLT698Wrap(((short)((8 + (meterAdd.Length / 2)) + (cData.Length / 2))).ToString("X4"), Con_Code, meterAdd, Client_Add, cData, TimeTag);
                }
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        private void selfReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            PublicVariable.BeginRecState = false;
            PublicVariable.isDisplay = false;
            this.isTimeClose = true;
            this.tl_监控.Text = "打开监控";
            Thread.Sleep(0x3e8);
            if (this.myThread != null)
            {
                this.myThread.Abort();
            }
        }
        private void ThreadMethod()
        {
            System.Timers.Timer timer = new System.Timers.Timer(100.0);
            timer.Elapsed += new ElapsedEventHandler(this.timer1_Tick);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string linkData = "";
            bool bExtend = false;
            string getAddress = "";
            List<string> list = new List<string>();
            List<string> parseData = new List<string>();
            List<string> list3 = new List<string>();
            string str3 = "";
            List<string> list4 = new List<string>();
            string str4 = "";
            List<List<List<string>>> list5 = new List<List<List<string>>>();
            if (this.isTimeClose)
            {
                ((System.Timers.Timer)sender).Stop();
            }
            else if (PublicVariable.isDisplay)
            {
                PublicVariable.isDisplay = false;
                if (!CommParam.comPort.IsOpen)
                {
                    CommParam.comPort.OpenPort();
                }
                PublicVariable.BeginRecState = true;
                PublicVariable.RecDataString = "";
                CommParam.comPort.comPort_DataReceived();
                if ((PublicVariable.RecDataString.Length > 0) && Protocol.RecIsProtocol(PublicVariable.RecDataString, ref getAddress, ref linkData, ref bExtend))
                {
                    Address_手动 = getAddress;
                    this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 接收帧] \r\n" + PublicVariable.RecDataString);
                    if ((linkData.Substring(0, 4) == "8801") || (linkData.Substring(6, 4) == "8801"))
                    {
                        if ((this.GetResponseNormal(linkData, ref list, ref parseData, this.Report_display) && this.rd_自动.Checked) && this.ReportResponseList(list, "01", "03", getAddress, "00", false))
                        {
                            this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
                        }
                    }
                    else if (((linkData.Substring(0, 4) == "8802") || (linkData.Substring(6, 4) == "8802")) && ((this.GetResponseRecord(linkData, ref list3, ref str3, ref list4, ref str4, ref list5) && this.rd_自动.Checked) && this.ReportResponseList(list3, "02", "03", getAddress, "00", false)))
                    {
                        this.UpDateControl(this.txt_报文, "[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 上报确认帧] \r\n" + PublicVariable.SendDataString + "\r\n===============================================\r\n");
                    }
                }
                if (this.isButton && this.rd_手动.Checked)
                {
                    this.isButton = false;
                    this.isButtonMathod(Address_手动);
                }
                PublicVariable.isDisplay = true;
            }
        }

        private void tl_监控_Click(object sender, EventArgs e)
        {
            if (this.tl_监控.Text == "打开监控")
            {
                PublicVariable.BeginRecState = true;
                PublicVariable.isDisplay = true;
                this.isTimeClose = false;
                this.tl_监控.Text = "关闭监控";
                this.myThread = new Thread(new ThreadStart(this.ThreadMethod));
                this.myThread.Start();
            }
            else if (this.tl_监控.Text == "关闭监控")
            {
                PublicVariable.BeginRecState = false;
                PublicVariable.isDisplay = false;
                this.isTimeClose = true;
                this.tl_监控.Text = "打开监控";
                Thread.Sleep(0x3e8);
                if (this.myThread != null)
                {
                    this.myThread.Abort();
                }
            }
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
                    TreeListNode node5 ;
                   // new TreeListNode();
                    for (int j = 0; j < list_ParseData_多级.Count; j++)
                    {
                        object[] nodeData = new object[1];
                        string[] strArray5 = new string[] { "第", (j + 1).ToString(), "条记录 --- 记录（行）表共", Record_Num, "行" };
                        nodeData[0] = string.Concat(strArray5);
                        node4 = treelist.AppendNode(nodeData, node2);
                        for (int k = 0; k < list_ParseData_多级[j].Count; k++)
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

        private delegate void UpDateControlDelegate(TextBox txt_Box, string text);

        private delegate void UpDateTreeDelegate(TreeList treelist, string Rercord_OAD, string rel_Num, List<string> Rel_RCSD, string Record_Num, List<List<List<string>>> list_ParseData_多级);

        private delegate void UpDateTreelistDelegate(TreeList treelist, string text);

        private delegate TreeListNode UpDateTreelistNodeDelegate(TreeList treelist, TreeListNode node, string text);
    }
}
