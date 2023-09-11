using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ht_698._45.Model.Base;

namespace ht_698._45.Model.Options
{
    public class LeadThreshold : Threshold
    {
        INIClass mINIClass = new INIClass(AppDomain.CurrentDomain.BaseDirectory + "配置文件.ini");
        public LeadThreshold()
        {
            Load();
        }
        public void Load()
        {
            组合电量 = mINIClass.ReadIniData("领头表阀值", "组合电量", "");
            正向电量 = mINIClass.ReadIniData("领头表阀值", "正向电量", "");
            反向电量 = mINIClass.ReadIniData("领头表阀值", "反向电量", "");
            时间误差 = mINIClass.ReadIniData("领头表阀值", "时间误差", "");
        }
        public void Save()
        {
            mINIClass.WriteIniData("领头表阀值", "组合电量", 组合电量);
            mINIClass.WriteIniData("领头表阀值", "正向电量", 正向电量);
            mINIClass.WriteIniData("领头表阀值", "反向电量", 反向电量);
            mINIClass.WriteIniData("领头表阀值", "时间误差", 时间误差);
        }

        [Category("电量阀值"), Description("组合电量阀值(总电量-尖电量-峰电量-平电量-谷电量),格式：00.00")]
        public string 组合电量 { get; set; }
        [Category("电量阀值"), Description("正向电量阀值(总电量-尖电量-峰电量-平电量-谷电量),格式：00.00")]
        public string 正向电量 { get; set; }
        [Category("电量阀值"), Description("反向电量阀值(总电量-尖电量-峰电量-平电量-谷电量),格式：00.00")]
        public string 反向电量 { get; set; }
        [Category("参数阀值"), Description("时间误差阀值(表内时间与当前时间比较),格式：00.00")]
        public string 时间误差 { get; set; }
    }
}