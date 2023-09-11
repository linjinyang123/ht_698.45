using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698._45.Model.Options
{
    public class LeadAddress
    {
        INIClass mINIClass = new INIClass(AppDomain.CurrentDomain.BaseDirectory + "配置文件.ini");
        public string agreement { get; set; }
        public string address { get; set; }
        public string GetAddress()
        {
            string address = "";
            address = mINIClass.ReadIniData("领头表参数", "领头表通信地址", "");
            return address.PadLeft(12, '0');
        }
        public string Getagreement()
        {
            string agreement = "";
            agreement = mINIClass.ReadIniData("领头表参数", "领头表通信协议", "");
            return agreement;
        }
    }
}