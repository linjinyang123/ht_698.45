using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ht_698.Model.Base
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class IniFile
    {
        public string Path;

        public IniFile(string path)
        {
            this.Path = path;
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, byte[] retVal, int size, string filePath);
        public string IniReadValue(string section, string key)
        {
            StringBuilder retVal = new StringBuilder(0x5dc);
            GetPrivateProfileString(section, key, "", retVal, 0x5dc, this.Path);
            return retVal.ToString();
        }

        public byte[] IniReadValues(string section, string key)
        {
            byte[] retVal = new byte[0xff];
            GetPrivateProfileString(section, key, "", retVal, 0xff, this.Path);
            return retVal;
        }

        public void IniWriteValue(string section, string key, string iValue)
        {
            WritePrivateProfileString(section, key, iValue, this.Path);
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}
