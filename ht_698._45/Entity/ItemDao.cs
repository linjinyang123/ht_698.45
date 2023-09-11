using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace ht_698._45.Entity
{
    public class ItemDao
    {
        public void GetMaxOrder(out int maxOrder)
        {
            maxOrder = 0;

            string SQLString = @"SELECT max(ITEM_ORDER) FROM TAB_METER ";
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, null))
            {
                if (dr.Read())
                    maxOrder = Convert.ToInt32(dr[0]);
                else
                    maxOrder = 0;
            }
        }

        public void GetItemByOrder(out  List<Item> list, int itemOrder)
        {
            list = new List<Item>();
            Item item = new Item();
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT * FROM TAB_METER WHERE [ITEM_ORDER]=@ITEM_ORDER";
            oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ORDER", itemOrder));
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, oleDbParameters.ToArray()))
            {
                while (dr.Read())
                {
                    item = new Item();
                    item.itemName = dr["ITEM_NAME"].ToString();
                    int modeNo = Convert.ToInt32(dr["ITEM_MODE"]);
                    switch (modeNo)
                    {
                        case 5:
                            item.itemMode = "读";
                            break;
                        case 6:
                            item.itemMode = "写";
                            break;
                        case 7:
                            item.itemMode = "方法";
                            break;
                    }
                    item.itemAgreement = dr["ITEM_AGREEMENT"].ToString();
                    if (item.itemAgreement == "698协议")
                    {
                        string strOAD = dr["ITEM_OAD"].ToString();

                        item.mOAD = new OAD()
                        {
                            mOAD = _Convert._ToBytes(strOAD, false)
                        };
                        string strItemValue = dr["ITEM_VALUE"].ToString();
                        item.itemValue = strItemValue;
                        string comName = Convert.ToString(dr["ITEM_COM"]);
                        item.mComName = comName;
                        int iEncryptNo = Convert.ToByte(dr["ENCRYPT_TYPE"]);
                        item.encryptTypeNo = iEncryptNo;
                    }
                    else
                    {
                        string comName = Convert.ToString(dr["ITEM_COM"]);
                        item.mComName = comName;
                        string strItemValue = dr["ITEM_VALUE"].ToString();
                        string strOAD = dr["ITEM_OAD"].ToString();
                        item.strOAD = strOAD;
                        item.itemValue = strItemValue;
                    }
                    list.Add(item);
                }
            }
        }

        public void GetItemAgreement(out List<Item> list, string itemName)
        {
            list = new List<Item>();
            Item item = new Item();

            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();

            string SQLString = @"SELECT [*] FROM TAB_METER WHERE [ITEM_NAME]=@ITEM_NAME";
            oleDbParameters.Add(AccessHelper.MakeParm("ITEM_NAME", itemName));
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, oleDbParameters.ToArray()))
            {
                if (dr.Read())
                {
                    item = new Item();
                    item.itemAgreement = dr["ITEM_AGREEMENT"].ToString();
                    list.Add(item);
                }
                else
                    list = null;
            }
        }

        public void GetItemAll_698(out List<Item> list, int itemOrder)
        {
            list = new List<Item>();
            Item item = new Item();

            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();

            string SQLString = @"SELECT [*] FROM TAB_METER WHERE [ITEM_ORDER]=@ITEM_ORDER";
            oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ORDER", itemOrder));
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, oleDbParameters.ToArray()))
            {
                if (dr.Read())
                {
                    item = new Item();
                    item.itemName = dr["ITEM_NAME"].ToString();
                    string strOAD = dr["ITEM_OAD"].ToString();
                    item.mOAD = new OAD()
                    {
                        mOAD = _Convert._ToBytes(strOAD, false)
                    };
                    string strItemValue = dr["ITEM_VALUE"].ToString();
                    item.itemValue = strItemValue;
                    string comName = Convert.ToString(dr["ITEM_COM"]);
                    item.mComName = comName;
                    int iEncryptNo = Convert.ToByte(dr["ENCRYPT_TYPE"]);
                    item.encryptTypeNo = iEncryptNo;
                    list.Add(item);
                }
                else
                    list = null;
            }
        }
    }
}