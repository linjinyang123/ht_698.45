namespace Common
{
    using System;
    using System.IO;

    public class RegistFileHelper
    {
        public static string ComputerInfofile = "ComputerInfo.key";
        public static string RegistInfofile = "RegistInfo.key";

        public static bool ExistComputerInfofile() 
        {
            return  File.Exists(ComputerInfofile);
        }
           

        public static bool ExistRegistInfofile() 
        {
            return  File.Exists(RegistInfofile);
        }
           

        public static string ReadComputerInfoFile() 
        {
            return   ReadFile(ComputerInfofile);
        }
          

        private static string ReadFile(string fileName)
        {
            string str = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    str = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
            }
            return str;
        }

        public static string ReadRegistFile() 
        {
            return ReadFile(RegistInfofile);
        }
          

        public static void WriteComputerInfoFile(string info)
        {
            WriteFile(info, ComputerInfofile);
        }

        private static void WriteFile(string info, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    writer.Write(info);
                    writer.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void WriteRegistFile(string info)
        {
            WriteFile(info, RegistInfofile);
        }
    }
}

