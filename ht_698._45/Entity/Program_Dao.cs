using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using ht_698._45;

namespace 掉电走字测试软件.Entity
{
    public class Program_Dao
    {
        #region *** 测试数据 ***
        /// <summary>
        /// 获取测试数据ID
        /// </summary>
        /// <param name="name">测试数据名称</param>
        /// <param name="id">测试数据ID</param>
        public void GetItems_ID(string name, out string id)
        {
            id = "";
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT * FROM TAB_ITEM where 名称='" + name+"'";
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, null))
            {
                while (dr.Read())
                {
                    id = dr["ID"].ToString();
                }
            }
        }

        /// <summary>
        /// 根据ID获取测试数据名称
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">获取的数据名称</param>
        public void GetItems_Name(string id, out string name)
        {
            name = "";
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT * FROM TAB_ITEM where ID=" + id;
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, null))
            {
                while (dr.Read())
                {
                    name = dr["名称"].ToString();
                }
            }
        }

        /// <summary>
        /// 取全部测试数据
        /// </summary>
        /// <param name="listItems">所有测试项</param>
        public void GetItems(out  List<ItemData> listItems)
        {
            listItems = new List<ItemData>();

            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT * FROM TAB_ITEM";
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, null))
            {
                while (dr.Read())
                {
                    ItemData mItemData = new ItemData();
                    mItemData.Item_Name = dr["名称"].ToString();
                    mItemData.Item_645_Value = dr["645_值"].ToString();
                    mItemData.Item_698_Value = dr["698_值"].ToString();
                    listItems.Add(mItemData);
                }
            }
        }

        /// <summary>
        /// 更新测试数据
        /// </summary>
        /// <param name="mItemData">输入数据</param>
        /// <param name="result"></param>
        public void UpdateItems(ItemData mItemData, out bool result)
        {
            try
            {
                result = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();

                oleDbParameters.Clear();
                string SQLString = @"UPDATE TAB_ITEM SET [645_值]=@645_值,[698_值]=@698_值 WHERE [名称] = @名称";
                oleDbParameters.Add(AccessHelper.MakeParm("645_值", mItemData.Item_645_Value));
                oleDbParameters.Add(AccessHelper.MakeParm("698_值", mItemData.Item_698_Value));
                oleDbParameters.Add(AccessHelper.MakeParm("名称", mItemData.Item_Name));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());

                if (count != 0)
                    result = true;
            }
            catch
            {
                result = false;
            }
        }

        /// <summary>
        /// 插入测试数据
        /// </summary>
        /// <param name="mItemData"></param>
        /// <param name="result"></param>
        public void InsertItems(ItemData mItemData, out bool result)
        {
            try
            {
                int ii = 0;
                result = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();

                oleDbParameters.Clear();
                string SQLString = @"INSERT INTO TAB_ITEM(名称,645_值,698_值) VALUES (@名称,@645_值,@698_值)";
                oleDbParameters.Add(AccessHelper.MakeParm("名称", mItemData.Item_Name));
                oleDbParameters.Add(AccessHelper.MakeParm(",645_值", mItemData.Item_645_Value));
                oleDbParameters.Add(AccessHelper.MakeParm(",698_值", mItemData.Item_698_Value));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());

                if (count != 0)
                    result = true;
            }
            catch
            {
                result = false;
            }
        }

        /// <summary>
        /// 删除单个测试数据
        /// </summary>
        /// <param name="str">测试数据名称</param>
        /// <param name="result">运行结果</param>
        public void DeleteItem(string str, out bool result)
        {
            try
            {
                result = false;

                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                string SQLString = @"DELETE FROM TAB_ITEM where [名称]=@名称";
                oleDbParameters.Add(AccessHelper.MakeParm("名称", str));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());

                if (count != 0)
                    result = true;
            }
            catch
            {
                result = false;
            }
        }
        #endregion

        #region *** 方案数据 ***
        /// <summary>
        /// 取全部方案
        /// </summary>
        /// <param name="listPrograms">所有方案名称</param>
        public void GetPrograms(out  List<ProgramData> listPrograms)
        {
            listPrograms = new List<ProgramData>();

            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT * FROM TAB_PROGRAM";
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, null))
            {
                while (dr.Read())
                {
                    ProgramData mProgramData = new ProgramData();
                    mProgramData.Program_Name = dr["方案名称"].ToString();
                    mProgramData.Program_Value = dr["值"].ToString();
                    listPrograms.Add(mProgramData);
                }
            }
        }

        /// <summary>
        /// 根据名称查询方案
        /// </summary>
        /// <param name="ProgramName">方案名称</param>
        /// <param name="value">方案值</param>
        public void GetProgramValue(string ProgramName, out string value)
        {
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT * FROM TAB_PROGRAM WHERE [方案名称]=@ProgramName";
            oleDbParameters.Add(AccessHelper.MakeParm("方案名称", ProgramName));
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, oleDbParameters.ToArray()))
            {
                if (dr.Read())
                    value = dr["值"].ToString();
                else
                    value = "";
            }
        }

        /// <summary>
        /// 更新方案
        /// </summary>
        /// <param name="listProName">方案名称</param>
        /// <param name="Provalue">方案值</param>
        /// <param name="result">更新结果</param>
        public void UpdateProd(ProgramData mProgramData, out bool result)
        {
            try
            {
                result = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();

                oleDbParameters.Clear();
                string SQLString = @"UPDATE TAB_PROGRAM SET [值]=@值 WHERE [方案名称] = @方案名称";
                oleDbParameters.Add(AccessHelper.MakeParm("值", mProgramData.Program_Value));
                oleDbParameters.Add(AccessHelper.MakeParm("方案名称", mProgramData.Program_Name));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());

                if (count != 0)
                    result = true;
            }
            catch
            {
                result = false;
            }
        }

        /// <summary>
        /// 插入方案
        /// </summary>
        /// <param name="listBh"></param>
        /// <param name="result"></param>
        public void InsertProd(ProgramData mProgramData, out bool result)
        {
            try
            {
                result = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();

                oleDbParameters.Clear();
                string SQLString = @"INSERT INTO TAB_PROGRAM(方案名称,值) VALUES (@I方案名称,@值)";
                oleDbParameters.Add(AccessHelper.MakeParm("方案名称", mProgramData.Program_Name));
                oleDbParameters.Add(AccessHelper.MakeParm("值", mProgramData.Program_Value));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());

                if (count != 0)
                    result = true;
            }
            catch
            {
                result = false;
            }
        }
        #endregion

        public void GetCountBH(string bh, out int maxOrder)
        {
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT count(BH_NAME) FROM TAB_BH  WHERE [BH_NAME]=@BH_NAME";
            oleDbParameters.Add(AccessHelper.MakeParm("BH_NAME", bh));
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, oleDbParameters.ToArray()))
            {
                if (dr.Read())
                    maxOrder = Convert.ToInt32(dr[0]);
                else
                    maxOrder = 0;
            }
        }

        /// <summary>
        /// 删除表号
        /// </summary>
        /// <param name="result"></param>
        public void DeleteBH(out bool result)
        {
            try
            {
                result = false;

                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                string SQLString = @"DELETE FROM TAB_BH";
                var count = AccessHelper.ExecuteNonQuery(SQLString, null);
                if (count == 0)
                    result = true;
                else
                    result = true;
            }
            catch
            {
                result = true;
            }
        }

        /// <summary>
        /// 写入表号
        /// </summary>
        /// <param name="listBh"></param>
        /// <param name="result"></param>
        public void InsterBH(List<string> listBh, out bool result)
        {
            try
            {
                int ii = 0;
                result = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                if (listBh.Count == 0)
                {
                    result = true;
                    return;
                }
                foreach (string bh in listBh)
                {
                    oleDbParameters.Clear();
                    string SQLString = @"INSERT INTO TAB_BH(BH_NAME) VALUES (@ITEM_NAME)";
                    oleDbParameters.Add(AccessHelper.MakeParm("ITEM_NAME", bh));
                    var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());

                    if (count == 0)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        result = true;
                        ii++;
                        if (ii == 58)
                        {  }
                    }
                }
            }
            catch
            {
                result = false;
            }
        }
    }


    /// <summary>
    /// 测试数据参数
    /// </summary>
    public class ItemData
    {
        public object Item_Name { get; set; }
        public object Item_645_Value { get; set; }
        public object Item_698_Value { get; set; }
    }

    /// <summary>
    /// 方案参数
    /// </summary>
    public class ProgramData 
    {
        public object Program_Name { get; set; }
        public object Program_Value { get; set; }
    }
}