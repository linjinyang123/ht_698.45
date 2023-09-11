using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace ht_698._45.Entity
{
    public class METER_JUDGE_DAO
    {
        public void InsterMetreJudge(METER_JUDGE mMetreJudge, out bool mMeterResult)
        {
            mMeterResult = false;
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"INSERT INTO TAB_METER_JUDGE(FACTORY_NUM,ADDRESS_NUM ) VALUES (@FACTORY_NUM,@ADDRESS_NUM)";
            oleDbParameters.Add(AccessHelper.MakeParm("FACTORY_NUM", mMetreJudge.FACTORY_NUM != null ? mMetreJudge.FACTORY_NUM : ""));
            oleDbParameters.Add(AccessHelper.MakeParm("ADDRESS_NUM", mMetreJudge.ADDRESS_NUM != null ? mMetreJudge.ADDRESS_NUM : ""));
            var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());
            if (count == 0)
                mMeterResult = false;
            else
                mMeterResult = true;
        }

        public void DeleteMetreJudge(string mTXM, out bool mMeterResult)
        {
            mMeterResult = false;
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            string SQLString = @"DELETE FROM TAB_METER_JUDGE  WHERE [ADDRESS_NUM]=@ADDRESS_NUM";
            oleDbParameters.Add(AccessHelper.MakeParm("ADDRESS_NUM", mTXM));
            var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());
            if (count == 0)
                mMeterResult = false;
            else
                mMeterResult = true;
        }
    }
}