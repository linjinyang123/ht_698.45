using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace ht_698._45.Entity
{
    public class AddressDao
    {
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
                        { }
                    }
                }
            }
            catch
            {
                result = false;
            }
        }

        /// <summary>
        /// 取全部通讯地址
        /// </summary>
        /// <param name="listBh"></param>
        public void GetBH(out List<string> listBh)
        {
            listBh = new List<string>();
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"SELECT BH_NAME FROM TAB_BH";
            using (OleDbDataReader dr = AccessHelper.ExecuteDataReader(SQLString, null))
            {
                while (dr.Read())
                {
                    listBh.Add(Convert.ToString(dr["BH_NAME"]));
                }
            }
        }
    }
}