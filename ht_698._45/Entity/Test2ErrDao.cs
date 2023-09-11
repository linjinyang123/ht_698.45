using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace ht_698._45.Entity
{
    public class Test2ErrDao
    {
        public void InsterBH(string add, out bool result)
        {
            try
            {
                result = false;
                string checkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                string SQLString = @"INSERT INTO TAB_TEST2_ERR(ITEM_ADD,ITEM_CHECK_TIEM) VALUES (@ITEM_ADD,@ITEM_CHECK_TIEM)";
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ADD", add));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_CHECK_TIEM", checkTime));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());
                if (count == 0)
                    result = false;
                else
                    result = true;
            }
            catch
            {
                result = true;
            }
        }
    }
}