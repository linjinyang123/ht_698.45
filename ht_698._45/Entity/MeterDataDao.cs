using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using ht_698._45.Model.Base;
namespace ht_698._45.Entity
{
    public class MeterDataDao
    {
        /// <summary>
        /// 获取实验表数据
        /// </summary>
        /// <param name="mCarAdd"></param>
        /// <param name="mItemCount"></param>
        /// <param name="mMeterResult"></param>
        /// <returns></returns>
        public List<MeterData> GetMeterData(string mCarAdd, string mItemCount, out bool mMeterResult)
        {
            List<MeterData> lstMeterData = new List<MeterData>();
            MeterData mMeterData = new MeterData();
            try
            {
                mMeterResult = false;
                List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
                string SQLString = string.Format(@"SELECT * FROM TAB_METER_DATA WHERE CAR_ADD='{0}' and ITEM_COUNT='{1}'", mCarAdd, mItemCount);
                using (OleDbDataReader read = AccessHelper.ExecuteDataReader(SQLString, null))
                {
                    while (read.Read())
                    {
                        mMeterData = new MeterData();
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
                        mMeterData.ITEM_TIME = Convert.ToString(read["ITEM_TIME"]);
                        mMeterData.ITEM_COUNT = Convert.ToString(read["ITEM_COUNT"]);
                        mMeterData.ITEM_TIME_ERR = Convert.ToString(read["ITEM_TIME_ERR"]);
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
        /// 写入实验表数据
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
                string SQLString = @"INSERT INTO TAB_METER_DATA(CAR_ADD,ITEM_COUNT,ITEM_ADD,
                                     ITEM_ZH_ELE,ITEM_ZH_ELE1,ITEM_ZH_ELE2,ITEM_ZH_ELE3,ITEM_ZH_ELE4,ITEM_ZH_ELE_ERR,
                                     ITEM_ZX_ELE,ITEM_ZX_ELE1,ITEM_ZX_ELE2,ITEM_ZX_ELE3,ITEM_ZX_ELE4,ITEM_ZX_ELE_ERR,
                                     ITEM_FX_ELE,ITEM_FX_ELE1,ITEM_FX_ELE2,ITEM_FX_ELE3,ITEM_FX_ELE4,ITEM_FX_ELE_ERR,
                                     ITEM_TIME,ITEM_CTIME,ITEM_TIME_ERR,ITEM_RESULT,ITEM_CHECK_TIME,ITEM_PRICE_PUR,
                                     ITEM_PRICE_REM,ITEM_PRICE_OVE,ITEM_PRICE_ELE_J,ITEM_PRICE_ELE_F,ITEM_PRICE_ELE_P,
                                     ITEM_PRICE_ELE_G,ITEM_PRICE_Cost,ITEM_PRICE_MONTH) 
                                     VALUES 
                                    (@CAR_ADD,@ITEM_COUNT,@ITEM_ADD,
                                     @ITEM_ZH_ELE,@ITEM_ZH_ELE1,@ITEM_ZH_ELE2,@ITEM_ZH_ELE3,@ITEM_ZH_ELE4,@ITEM_ZH_ELE_ERR,
                                     @ITEM_ZX_ELE,@ITEM_ZX_ELE1,@ITEM_ZX_ELE2,@ITEM_ZX_ELE3,@ITEM_ZX_ELE4,@ITEM_ZX_ELE_ERR,
                                     @ITEM_FX_ELE,@ITEM_FX_ELE1,@ITEM_FX_ELE2,@ITEM_FX_ELE3,@ITEM_FX_ELE4,@ITEM_FX_ELE_ERR,
                                     @ITEM_TIME,@ITEM_CTIME,@ITEM_TIME_ERR,@ITEM_RESULT,@ITEM_CHECK_TIME,@ITEM_PRICE_PUR,
                                     @ITEM_PRICE_REM,@ITEM_PRICE_OVE,@ITEM_PRICE_ELE_J ,@ITEM_PRICE_ELE_F,@ITEM_PRICE_ELE_P,
                                     @ITEM_PRICE_ELE_G,@ITEM_PRICE_Cost,@ITEM_PRICE_MONTH)";
                oleDbParameters.Add(AccessHelper.MakeParm("CAR_ADD", mCarAdd!=null?mCarAdd:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_COUNT", mMeterData.ITEM_COUNT!=null?mMeterData.ITEM_COUNT:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ADD", mMeterData.ITEM_ADD!=null?mMeterData.ITEM_ADD:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE",   mMeterData.ITEM_ZH_ELE!=null? mMeterData.ITEM_ZH_ELE:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE1", mMeterData.ITEM_ZH_ELE1!=null? mMeterData.ITEM_ZH_ELE1:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE2", mMeterData.ITEM_ZH_ELE2!=null? mMeterData.ITEM_ZH_ELE2:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE3", mMeterData.ITEM_ZH_ELE3!=null? mMeterData.ITEM_ZH_ELE3:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE4", mMeterData.ITEM_ZH_ELE4!=null? mMeterData.ITEM_ZH_ELE4:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZH_ELE_ERR", mMeterData.ITEM_ZH_ELE_ERR!=null?mMeterData.ITEM_ZH_ELE_ERR:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE", mMeterData.ITEM_ZX_ELE!=null?mMeterData.ITEM_ZX_ELE:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE1", mMeterData.ITEM_ZX_ELE1!=null?mMeterData.ITEM_ZX_ELE1:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE2", mMeterData.ITEM_ZX_ELE2!=null?mMeterData.ITEM_ZX_ELE2:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE3", mMeterData.ITEM_ZX_ELE3!=null?mMeterData.ITEM_ZX_ELE3:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE4", mMeterData.ITEM_ZX_ELE4!=null?mMeterData.ITEM_ZX_ELE4:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_ZX_ELE_ERR", mMeterData.ITEM_ZX_ELE_ERR!=null?mMeterData.ITEM_ZX_ELE_ERR:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE", mMeterData.ITEM_FX_ELE!=null?mMeterData.ITEM_FX_ELE:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE1", mMeterData.ITEM_FX_ELE1!=null?mMeterData.ITEM_FX_ELE1:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE2", mMeterData.ITEM_FX_ELE2!=null?mMeterData.ITEM_FX_ELE2:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE3", mMeterData.ITEM_FX_ELE3!=null?mMeterData.ITEM_FX_ELE3:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE4", mMeterData.ITEM_FX_ELE4!=null?mMeterData.ITEM_FX_ELE4:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_FX_ELE_ERR", mMeterData.ITEM_FX_ELE_ERR!=null?mMeterData.ITEM_FX_ELE_ERR:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_TIME", mMeterData.ITEM_TIME!=null?mMeterData.ITEM_TIME:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_CTIME", mMeterData.ITEM_CTIME!=null?mMeterData.ITEM_CTIME:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_TIME_ERR", mMeterData.ITEM_TIME_ERR!=null?mMeterData.ITEM_TIME_ERR:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_RESULT", mMeterData.ITEM_RESULT == "True" ? "合格" : "不合格"));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_CHECK_TIME", mMeterData.ITEM_CHECK_TIME != null ? mMeterData.ITEM_CHECK_TIME : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_PUR", mMeterData.ITEM_PRICE_PUR!=null? mMeterData.ITEM_PRICE_PUR:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_REM", mMeterData.ITEM_PRICE_REM!=null?mMeterData.ITEM_PRICE_REM:""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_OVE", mMeterData.ITEM_PRICE_OVE !=null?mMeterData.ITEM_PRICE_OVE  :""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_ELE", mMeterData.ITEM_PRICE_ELE_J != null ? mMeterData.ITEM_PRICE_ELE_J : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_ELE", mMeterData.ITEM_PRICE_ELE_F != null ? mMeterData.ITEM_PRICE_ELE_F : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_ELE", mMeterData.ITEM_PRICE_ELE_P != null ? mMeterData.ITEM_PRICE_ELE_P : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_ELE", mMeterData.ITEM_PRICE_ELE_G != null ? mMeterData.ITEM_PRICE_ELE_G : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_ELE", mMeterData.ITEM_PRICE_Cost != null ? mMeterData.ITEM_PRICE_Cost : ""));
                oleDbParameters.Add(AccessHelper.MakeParm("ITEM_PRICE_MONTH", mMeterData.ITEM_PRICE_Month != null ? mMeterData.ITEM_PRICE_Month : ""));
            
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
        /// 删除实验表数据
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
                string SQLString = @"delete FROM TAB_METER_DATA WHERE CAR_ADD=@CAR_ADD AND ITEM_COUNT=@ITEM_COUNT";
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