using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ht_698._45.Model.Options;
using ht_698._45.Model.Base;
namespace ht_698._45.Transport
{
    public interface IMethod
    {
        /// <summary>
        /// 读取电量数据（总，尖，峰，平，谷）
        /// </summary>
        /// <param name="results"></param>
        void 读取电量数据(out string[] datas, string address, out bool result);

        /// <summary>
        /// 读取电量数据（总，尖，峰，平，谷）
        /// </summary>
        /// <param name="results"></param>
        void 读取领头表数据1(out string[] datas, string address, out bool result);

        /// <summary>
        /// 读取分钟冻结数据（电压、电流、功率、功率因数）
        /// </summary>
        /// <param name="results"></param>
        void 读取多数据(out string[] datas, string address, out bool result, List<string> lstStrOAD);
        void 读取多数据(string address, out bool result, List<string> lstStrOAD);
        void 读取实验1数据(out string[] datas, string address, out bool result);

        /// <summary>
        /// 实验1表数据是否合格
        /// </summary>
        void 实验表数据1(TestThreshold mTestThreshold, MeterData mMeterData, out bool result);
        void 领头表数据1(LeadThreshold mLeadThreshold, MeterData mMeterData, out bool result);

        /// <summary>
        /// 领头表与误差表比较数据
        /// </summary>
        /// <param name="mTestThreshold"></param>
        /// <param name="mMeterData"></param>
        /// <param name="result"></param>
        void 误差数据(ErrThreshold mErrThreshold, MeterData mLeanMeterData, MeterData mMeterData, out bool result, int addressNo);
        void 清零_645(string address, out bool result);
        void 清零_698(string address, out bool result);
        void 读取实验2数据(string address, out bool result, out string[] datas);
        void 读取领头表数据2(string address, out bool result, out string[] datas);
        void 校时_645(string address, out bool result);
    }
}