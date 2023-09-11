using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45.Model.Base
{
    /// <summary>
    /// 电量参数
    /// </summary>
    public class ElectricParameter
    {
        /// <summary>
        /// 组合总电量
        /// </summary>
        public double ZH_Ele { get; set; }

        /// <summary>
        /// 组合尖电量
        /// </summary>
        public double ZH_Ele1 { get; set; }

        /// <summary>
        /// 组合峰电量
        /// </summary>
        public double ZH_Ele2 { get; set; }

        /// <summary>
        /// 组合平电量
        /// </summary>
        public double ZH_Ele3 { get; set; }

        /// <summary>
        /// 组合谷电量
        /// </summary>
        public double ZH_Ele4 { get; set; }

        /// <summary>
        /// 组合电量差（总-尖-峰-平-谷）
        /// </summary>
        public double ZH_Ele_Err { get; set; }

        /// <summary>
        /// 正向总电量
        /// </summary>
        public double ZX_Ele { get; set; }

        /// <summary>
        /// 正向尖电量
        /// </summary>
        public double ZX_Ele1 { get; set; }

        /// <summary>
        /// 正向峰电量
        /// </summary>
        public double ZX_Ele2 { get; set; }

        /// <summary>
        /// 正向平电量
        /// </summary>
        public double ZX_Ele3 { get; set; }

        /// <summary>
        /// 正向谷电量
        /// </summary>
        public double ZX_Ele4 { get; set; }

        /// <summary>
        /// 正向电量差（总-尖-峰-平-谷）
        /// </summary>
        public double ZX_Ele_Err { get; set; }

        /// <summary>
        /// 反向总电量
        /// </summary>
        public double FX_Ele { get; set; }

        /// <summary>
        /// 反向尖电量
        /// </summary>
        public double FX_Ele1 { get; set; }

        /// <summary>
        /// 反向峰电量
        /// </summary>
        public double FX_Ele2 { get; set; }

        /// <summary>
        /// 反向平电量
        /// </summary>
        public double FX_Ele3 { get; set; }

        /// <summary>
        /// 反向谷电量
        /// </summary>
        public double FX_Ele4 { get; set; }

        /// <summary>
        /// 反向电量差（总-尖-峰-平-谷）
        /// </summary>
        public double FX_Ele_Err { get; set; }

        /// <summary>
        /// 购电金额
        /// </summary>
        public double PRICE_Purchase { get; set; }

        /// <summary>
        /// 剩余金额
        /// </summary>
        public double PRICE_Remaining { get; set; }

        /// <summary>
        /// 透支金额
        /// </summary>
        public double PRICE_Overdraft { get; set; }

        /// <summary>
        /// 尖电价
        /// </summary>
        public double PRICE_Ele_J { get; set; }

        /// <summary>
        /// 峰电价
        /// </summary>
        public double PRICE_Ele_F { get; set; }

        /// <summary>
        /// 平电价
        /// </summary>
        public double PRICE_Ele_P { get; set; }

        /// <summary>
        /// 谷电价
        /// </summary>
        public double PRICE_Ele_G { get; set; }

        /// <summary>
        /// 电费
        /// </summary>
        public double PRICE_Cost { get; set; }

        /// <summary>
        /// 月度电量
        /// </summary>
        public double PowerMonth { get; set; }

        /// <summary>
        /// 上一月度电量
        /// </summary>
        public double PowerLastMonth { get; set; }

        /// <summary>
        /// 电压
        /// </summary>
        public double Voltage { get; set; }

        /// <summary>
        /// 电流
        /// </summary>
        public double Current { get; set; }

        /// <summary>
        /// 功率
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        /// 功率因数
        /// </summary>
        public double PowerFactor { get; set; }

        /// <summary>
        /// 时间{0000/0/0 00:00:00}
        /// </summary>
        public DateTime _Time { get; set; }
    }
}