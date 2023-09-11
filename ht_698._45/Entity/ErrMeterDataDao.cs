using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using ht_698._45.Model.Base;

namespace ht_698._45.Entity
{
    public class ErrMeterDataDao
    {
        public List<MeterData> GetMeterData(string mCarAdd, string mItemCount, out bool mMeterResult)
        {
            List<MeterData> lstMeterData = new List<MeterData>();
            MeterData mMeterData = new MeterData();
            try
            {
                mMeterResult = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                string SQLString = string.Format(@"SELECT * FROM TAB_METER_ERR_DATA WHERE CAR_ADD='{0}' and ITEM_COUNT='{1}'", mCarAdd, mItemCount);
                using (OleDbDataReader read = AccessHelper.ExecuteDataReader(SQLString, null))
                {
                    while (read.Read())
                    {
                        mMeterResult = true;
                        mMeterData.ITEM_ADD = Convert.ToString(read["ITEM_ADD"]);
                        mMeterData.ITEM_ZH_ELE = Convert.ToString(read["ITEM_ZH_ELE"]);
                        mMeterData.ITEM_ZH_ELE1 = Convert.ToString(read["ITEM_ZH_ELE1"]);
                        mMeterData.ITEM_ZH_ELE2 = Convert.ToString(read["ITEM_ZH_ELE2"]);
                        mMeterData.ITEM_ZH_ELE3 = Convert.ToString(read["ITEM_ZH_ELE3"]);
                        mMeterData.ITEM_ZH_ELE4 = Convert.ToString(read["ITEM_ZH_ELE4"]);
                        mMeterData.ITEM_ZX_ELE = Convert.ToString(read["ITEM_ZX_ELE"]);
                        mMeterData.ITEM_ZX_ELE1 = Convert.ToString(read["ITEM_ZX_ELE1"]);
                        mMeterData.ITEM_ZX_ELE2 = Convert.ToString(read["ITEM_ZX_ELE2"]);
                        mMeterData.ITEM_ZX_ELE3 = Convert.ToString(read["ITEM_ZX_ELE3"]);
                        mMeterData.ITEM_ZX_ELE4 = Convert.ToString(read["ITEM_ZX_ELE4"]);
                        mMeterData.ITEM_FX_ELE = Convert.ToString(read["ITEM_FX_ELE"]);
                        mMeterData.ITEM_FX_ELE1 = Convert.ToString(read["ITEM_FX_ELE1"]);
                        mMeterData.ITEM_FX_ELE2 = Convert.ToString(read["ITEM_FX_ELE2"]);
                        mMeterData.ITEM_FX_ELE3 = Convert.ToString(read["ITEM_FX_ELE3"]);
                        mMeterData.ITEM_FX_ELE4 = Convert.ToString(read["ITEM_FX_ELE4"]);
                        mMeterData.ITEM_COUNT = Convert.ToString(read["ITEM_COUNT"]);
                        lstMeterData.Add(mMeterData);
                    }
                }
            }
            catch
            {
                mMeterResult = false;
            }
            return lstMeterData;
        }

        /// <summary>
        /// 写入误差值
        /// </summary>
        /// <param name="mMeterData"></param>
        /// <param name="mMeterResult"></param>
        /// <param name="mCarAdd"></param>
        public void InsterMetreData(MeterData mMeterData, out bool mMeterResult, string mCarAdd)
        {
            try
            {
                mMeterResult = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                string SQLString = @"INSERT INTO TAB_METER_ERR_DATA(CAR_ADD,ITEM_COUNT,ITEM_ADD,
                                     ITEM_ZH_ELE,ITEM_ZH_ELE1,ITEM_ZH_ELE2,ITEM_ZH_ELE3,ITEM_ZH_ELE4,
                                     ITEM_ZX_ELE,ITEM_ZX_ELE1,ITEM_ZX_ELE2,ITEM_ZX_ELE3,ITEM_ZX_ELE4,
                                     ITEM_FX_ELE,ITEM_FX_ELE1,ITEM_FX_ELE2,ITEM_FX_ELE3,ITEM_FX_ELE4,
                                     ITEM_RESULT,ITEM_CHECK_TIME ) 
                                     VALUES 
                                    (@CAR_ADD,@ITEM_COUNT,@ITEM_ADD,
                                     @ITEM_ZH_ELE,@ITEM_ZH_ELE1,@ITEM_ZH_ELE2,@ITEM_ZH_ELE3,@ITEM_ZH_ELE4,
                                     @ITEM_ZX_ELE,@ITEM_ZX_ELE1,@ITEM_ZX_ELE2,@ITEM_ZX_ELE3,@ITEM_ZX_ELE4,
                                     @ITEM_FX_ELE,@ITEM_FX_ELE1,@ITEM_FX_ELE2,@ITEM_FX_ELE3,@ITEM_FX_ELE4,
                                     @ITEM_RESULT,@ITEM_CHECK_TIME  )";
                oleDbParameters.Add(AccessHelper.MakeParm("CAR_ADD", mCarAdd!=null?mCarAdd:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_COUNT", mMeterData.ITEM_COUNT != null ? mMeterData.ITEM_COUNT : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ADD", mMeterData.ITEM_ADD != null ? mMeterData.ITEM_ADD : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE", mMeterData.ITEM_ZH_ELE != null ? mMeterData.ITEM_ZH_ELE : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE1", mMeterData.ITEM_ZH_ELE1 != null ? mMeterData.ITEM_ZH_ELE1 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE2", mMeterData.ITEM_ZH_ELE2 != null ? mMeterData.ITEM_ZH_ELE2 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE3", mMeterData.ITEM_ZH_ELE3 != null ? mMeterData.ITEM_ZH_ELE3 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE4", mMeterData.ITEM_ZH_ELE4 != null ? mMeterData.ITEM_ZH_ELE4 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE", mMeterData.ITEM_ZX_ELE != null ? mMeterData.ITEM_ZX_ELE : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE1", mMeterData.ITEM_ZX_ELE1 != null ? mMeterData.ITEM_ZX_ELE1 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE2", mMeterData.ITEM_ZX_ELE2 != null ? mMeterData.ITEM_ZX_ELE2 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE3", mMeterData.ITEM_ZX_ELE3 != null ? mMeterData.ITEM_ZX_ELE3 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE4", mMeterData.ITEM_ZX_ELE4 != null ? mMeterData.ITEM_ZX_ELE4 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE", mMeterData.ITEM_FX_ELE != null ? mMeterData.ITEM_FX_ELE : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE1", mMeterData.ITEM_FX_ELE1 != null ? mMeterData.ITEM_FX_ELE1 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE2", mMeterData.ITEM_FX_ELE2 != null ? mMeterData.ITEM_FX_ELE2 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE3", mMeterData.ITEM_FX_ELE3 != null ? mMeterData.ITEM_FX_ELE3 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE4", mMeterData.ITEM_FX_ELE4 != null ? mMeterData.ITEM_FX_ELE4 : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_RESULT", mMeterData.ITEM_RESULT != null ? mMeterData.ITEM_RESULT : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_CHECK_TIME", mMeterData.ITEM_CHECK_TIME != null ? mMeterData.ITEM_CHECK_TIME : ""));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());
                if (count == 0)
                    mMeterResult = false;
                else
                    mMeterResult = true;
            }
            catch
            {
                mMeterResult = true;
            }
        }

        /// <summary>
        /// 删除误差值
        /// </summary>
        /// <param name="mCarAdd"></param>
        /// <param name="mItemCount"></param>
        /// <param name="mMeterResult"></param>
        public void DeleteAll(string mCarAdd, string mItemCount, out bool mMeterResult)
        {
            try
            {
                mMeterResult = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                string SQLString = @"delete FROM TAB_METER_ERR_DATA WHERE CAR_ADD=@CAR_ADD AND ITEM_COUNT=@ITEM_COUNT";
                oleDbParameters.Add(AccessHelper.MakeParm("CAR_ADD", mCarAdd));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_COUNT", mItemCount));
                var count = AccessHelper.ExecuteNonQuery(SQLString, oleDbParameters.ToArray());
                if (count == 0)
                    mMeterResult = false;
                else
                    mMeterResult = true;
            }
            catch
            {
                mMeterResult = false;
            }
        }
    }
}