using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ht_698._45.Model.Base;
using System.ComponentModel;
using System.IO.Ports;
using 掉电走字测试软件;

namespace ht_698._45.Model.Options
{
    public class PortOptions : Threshold
    {
        INIClass mINIClass = new INIClass(AppDomain.CurrentDomain.BaseDirectory + "配置文件.ini");
        public PortOptions()
        {
            Load();
        }

        public void Load()
        {
            端口号 = mINIClass.ReadIniData("端口", "端口号", "");
            PortInfo.PortName = 端口号;
            //通讯速率 = (mINIClass.ReadIniData("领头表参数", "领头表通信协议", "4800") == "645") ? "4800" : "9600";
            通讯速率 = mINIClass.ReadIniData("端口", "通讯速率", "");

            PortInfo.ParityName = "Even";
            领头表通讯速率 = mINIClass.ReadIniData("端口", "领头表通讯速率", "");
        }

        public void Save()
        {
            mINIClass.WriteIniData("端口", "端口号", 端口号);
            PortInfo.PortName = 端口号;
            mINIClass.WriteIniData("端口", "通讯速率", 通讯速率);

            mINIClass.WriteIniData("端口", "领头表通讯速率", 领头表通讯速率);
        }

        [Category("端口参数"), Description("测试端口号"), TypeConverter(typeof(PortItem))]
        public string 端口号 { get; set; }

        [Category("端口参数"), Description("实验表通讯速率"), TypeConverter(typeof(BaudRatItem))]
        public string 通讯速率 { get; set; }

        [Category("领头表端口参数"), Description("领头表通讯速率"), TypeConverter(typeof(BaudRatItem))]
        public string 领头表通讯速率 { get; set; }
    }

    #region [*** PropertyGrid控件创建下拉列表类 ***]

    #region [*** 方式1 ***]
    /// <summary>
    /// 端口号列
    /// </summary>
    class PortItem : StringConverter
    {
        //true enable,false disable
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(SerialPort.GetPortNames());//编辑下拉框中的内容
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    /// <summary>
    /// 波特率列
    /// </summary>
    class BaudRatItem : StringConverter
    {
        //true enable,false disable
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "1200", "2400", "4800", "9600", "14400" });//编辑下拉框中的内容
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    #endregion

    #region [*** 方式2 ***]
    /*
     * 调用示例
     * [Category("端口参数"), Description("实验表通讯速率"), TypeConverter(typeof(MyConverter)), ListAttribute(new string[] { "1200", "2400", "4800", "9600", "14400", })]
     * public string 通讯速率 { get; set; }
     */

    class ListAttribute : Attribute
    {
        public string[] _lst;

        public ListAttribute(string[] lst)
        {
            //初始化列表值  
            _lst = lst;
        }
    }

    /// <summary>
    /// PropertyGrid控件创建下拉列表
    /// </summary>
    public class MyConverter : ExpandableObjectConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ListAttribute listAttribute = (ListAttribute)context.PropertyDescriptor.Attributes[typeof(ListAttribute)];
            StandardValuesCollection vals = new TypeConverter.StandardValuesCollection(listAttribute._lst);

            return vals;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
    }
    #endregion

    #endregion
}