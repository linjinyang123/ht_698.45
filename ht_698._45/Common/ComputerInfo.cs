namespace Common
{
    using Microsoft.Win32;
    using System;
    using System.Management;
    using System.Net.NetworkInformation;

    public class ComputerInfo
    {
        private static string GetBaseBoardInfo() 
        {
            return GetHardWareInfo("Win32_BaseBoard", "SerialNumber");
        }

        private static string GetBIOSInfo()
        {
            return  GetHardWareInfo("Win32_BIOS", "SerialNumber");
        }

        public static string GetComputerInfo()
        {
            string cPUInfo = GetCPUInfo();
            string baseBoardInfo = GetBaseBoardInfo();
            string bIOSInfo = GetBIOSInfo();
            string mACInfo = GetMACInfo();
            return (cPUInfo + baseBoardInfo + bIOSInfo + mACInfo);
        }

        private static string GetCPUInfo() 
        {
            return  GetHardWareInfo("Win32_Processor", "ProcessorId");
        }
           

        private static string GetHardWareInfo(string typePath, string key)
        {
            try
            {
                ManagementClass class2 = new ManagementClass(typePath);
                ManagementObjectCollection instances = class2.GetInstances();
                PropertyDataCollection properties = class2.Properties;
                foreach (PropertyData data in properties)
                {
                    if (data.Name == key)
                    {
                        foreach (ManagementObject obj2 in instances)
                        {
                            return obj2.Properties[data.Name].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return string.Empty;
        }

        private static string GetMacAddressByNetworkInformation()
        {
            string str = @"SYSTEM\CurrentControlSet\Control\Network\{4D36E972-E325-11CE-BFC1-08002BE10318}\";
            string str2 = string.Empty;
            try
            {
                NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface interface2 in allNetworkInterfaces)
                {
                    if ((interface2.NetworkInterfaceType == NetworkInterfaceType.Ethernet) && (interface2.GetPhysicalAddress().ToString().Length != 0))
                    {
                        string name = str + interface2.Id + @"\Connection";
                        RegistryKey key = Registry.LocalMachine.OpenSubKey(name, false);
                        if (key != null)
                        {
                            string str4 = key.GetValue("PnpInstanceID", "").ToString();
                            int num = Convert.ToInt32(key.GetValue("MediaSubType", 0));
                            if ((str4.Length > 3) && (str4.Substring(0, 3) == "PCI"))
                            {
                                str2 = interface2.GetPhysicalAddress().ToString();
                                for (int i = 1; i < 6; i++)
                                {
                                    str2 = str2.Insert((3 * i) - 1, ":");
                                }
                                return str2;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return str2;
        }

        private static string GetMACInfo()
        {
            return GetHardWareInfo("Win32_BaseBoard", "SerialNumber");
        }
           
    }
}

