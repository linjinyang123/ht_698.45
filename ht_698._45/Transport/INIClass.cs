using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ht_698._45
{
    class INIClass
    {
        public string iniFilePath; //INI文件名

        #region API函数声明
        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        #region 类的构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="AFileName">ini文件名</param>
        public INIClass(string AFileName)
        {
            iniFilePath = AFileName;
        }
        #endregion

        #region 读Ini文件
        /// <summary>
        /// 读Ini文件
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="NoText">没有参数回值</param>
        /// <param name="iniFilePath">文件名称</param>
        /// <returns></returns>
        public string ReadIniData(string Section, string Key, string NoText)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
        #endregion

        #region 写Ini文件
        /// <summary>
        /// 写Ini文件
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="NoText">值</param>
        /// <param name="iniFilePath">文件名称</param>
        /// <returns></returns>
        public bool WriteIniData(string Section, string Key, string Value)
        {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                    return false;
                else
                    return true;
        }
        #endregion

        /// <summary>
        ///保存至TXT
        /// </summary>
        /// <param name="BH">表号</param>
        public static void SaveLog(string str)
        {
            //string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\帧记录.txt";
            ////采用using关键字，会自动释放
            //using (FileStream fs = new FileStream(filePath, FileMode.Append))
            //{
            //    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
            //    {
            //        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            //        sw.WriteLine(str);
            //        sw.WriteLine("");
            //    }
            //}
        }
    }
}