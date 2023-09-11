using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ht_698._45.Model.Base;
using System.ComponentModel;
namespace ht_698._45.Model.Options
{
    public class ErrThreshold : Threshold
    {
        INIClass mINIClass = new INIClass(AppDomain.CurrentDomain.BaseDirectory + "配置文件.ini");
        public ErrThreshold()
        {
            Load();
        }
        public void Load()
        {
            组合总电量 = mINIClass.ReadIniData("比较误差阀值", "组合总电量", "");
            组合尖电量 = mINIClass.ReadIniData("比较误差阀值", "组合尖电量", "");
            组合峰电量 = mINIClass.ReadIniData("比较误差阀值", "组合峰电量", "");
            组合平电量 = mINIClass.ReadIniData("比较误差阀值", "组合平电量", "");
            组合谷电量 = mINIClass.ReadIniData("比较误差阀值", "组合谷电量", "");
        
            正向总电量 = mINIClass.ReadIniData("比较误差阀值", "正向总电量", "");
            正向尖电量 = mINIClass.ReadIniData("比较误差阀值", "正向尖电量", "");
            正向峰电量 = mINIClass.ReadIniData("比较误差阀值", "正向峰电量", "");
            正向平电量 = mINIClass.ReadIniData("比较误差阀值", "正向平电量", "");
            正向谷电量 = mINIClass.ReadIniData("比较误差阀值", "正向谷电量", "");
        
            反向总电量 = mINIClass.ReadIniData("比较误差阀值", "反向总电量", "");
            反向尖电量 = mINIClass.ReadIniData("比较误差阀值", "反向尖电量", "");
            反向峰电量 = mINIClass.ReadIniData("比较误差阀值", "反向峰电量", "");
            反向平电量 = mINIClass.ReadIniData("比较误差阀值", "反向平电量", "");
            反向谷电量 = mINIClass.ReadIniData("比较误差阀值", "反向谷电量", "");
            电量误差补偿值 = mINIClass.ReadIniData("比较误差阀值", "电量误差补偿值", "");
        }
        public void Save()
        {
            mINIClass.WriteIniData("比较误差阀值", "组合总电量", 组合总电量);
            mINIClass.WriteIniData("比较误差阀值", "组合尖电量", 组合尖电量);
            mINIClass.WriteIniData("比较误差阀值", "组合峰电量", 组合峰电量);
            mINIClass.WriteIniData("比较误差阀值", "组合平电量", 组合平电量);
            mINIClass.WriteIniData("比较误差阀值", "组合谷电量", 组合谷电量);
        
            mINIClass.WriteIniData("比较误差阀值", "正向总电量", 正向总电量);
            mINIClass.WriteIniData("比较误差阀值", "正向尖电量", 正向尖电量);
            mINIClass.WriteIniData("比较误差阀值", "正向峰电量", 正向峰电量);
            mINIClass.WriteIniData("比较误差阀值", "正向平电量", 正向平电量);
            mINIClass.WriteIniData("比较误差阀值", "正向谷电量", 正向谷电量);
        
            mINIClass.WriteIniData("比较误差阀值", "反向总电量", 反向总电量);
            mINIClass.WriteIniData("比较误差阀值", "反向尖电量", 反向尖电量);
            mINIClass.WriteIniData("比较误差阀值", "反向峰电量", 反向峰电量);
            mINIClass.WriteIniData("比较误差阀值", "反向平电量", 反向平电量);
            mINIClass.WriteIniData("比较误差阀值", "反向谷电量", 反向谷电量);
            mINIClass.WriteIniData("比较误差阀值", "电量误差补偿值", 电量误差补偿值);
        }
        
        [Category("电量误差补偿值"), Description("电量误差补偿值(补偿值=（最后表位实验表-第1表位实验表)/表数,格式：00.00")]
        public string 电量误差补偿值 { get; set; }

        #region [*** 组合电量阀值 ***]
        [Category("组合电量阀值"), Description("组合总电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 组合总电量 { get; set; }
        
        [Category("组合电量阀值"), Description("组合尖电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 组合尖电量 { get; set; }
        
        [Category("组合电量阀值"), Description("组合峰电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 组合峰电量 { get; set; }
        
        [Category("组合电量阀值"), Description("组合平电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 组合平电量 { get; set; }
        
        [Category("组合电量阀值"), Description("组合谷电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 组合谷电量 { get; set; }
        #endregion

        #region [*** 正向电量阀值 ***]
        [Category("正向电量阀值"), Description("正向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 正向总电量 { get; set; }
        
        [Category("正向电量阀值"), Description("正向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 正向尖电量 { get; set; }
        
        [Category("正向电量阀值"), Description("正向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 正向峰电量 { get; set; }
        
        [Category("正向电量阀值"), Description("正向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 正向平电量 { get; set; }
        
        [Category("正向电量阀值"), Description("正向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 正向谷电量 { get; set; }
        #endregion

        #region [*** 反向电量阀值 ***]
        [Category("反向电量阀值"), Description("反向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 反向总电量 { get; set; }
        
        [Category("反向电量阀值"), Description("反向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 反向尖电量 { get; set; }
        
        [Category("反向电量阀值"), Description("反向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 反向峰电量 { get; set; }
        
        [Category("反向电量阀值"), Description("反向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 反向平电量 { get; set; }
        
        [Category("反向电量阀值"), Description("反向电量阀值(领头表电量-实验表电量),格式：00.00")]
        public string 反向谷电量 { get; set; }
        #endregion
    }
}