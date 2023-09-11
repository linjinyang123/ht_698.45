using EncryptServerConnect;
using ht_698._45;
using System;
using System.Text;
namespace ht_698._45
{
    internal class EncryptServerConnect
    {
        public static void CloseEncryptServer698()
        {
            PublicVariable.encrypt.CloseEncryptServer698();
        }

        public static bool ConnectEncryptServer698(string serverIP, ushort serverPort) 
        {
            return PublicVariable.encrypt.ConnectEncryptServer698(serverIP, serverPort);
        }
           
        public static string[] GetArray(params object[] str)
        {
            int length = str.Length;
            string[] strArray = new string[length];
            for (int i = 0; i < length; i++)
            {
                strArray[i] = str[i].ToString();
            }
            return strArray;
        }

        public static bool GetOutRand(int length, ref StringBuilder oppOutRand)
        {
            oppOutRand.Clear();
            string str = "";
            for (int i = 0; i < (1 + (length / 0x10)); i++)
            {
                str = str + Guid.NewGuid().ToString("N").ToUpper();
            }
            if (str.Length >= (length * 2))
            {
                oppOutRand.Append(str.Substring(0, length * 2));
                return true;
            }
            oppOutRand.Append("");
            return false;
        }
        /// <summary>
        /// 服务器加密方法
        /// </summary>
        /// <param name="oopEncryptor"></param>
        /// <param name="oopMethod"></param>
        /// <param name="cOutData"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool MethodEncryptServer698(OOPEncryptor oopEncryptor, OOPMethod oopMethod, ref StringBuilder[] cOutData, params object[] str)
        {

            int length = str.Length;
            string[] oopData = new string[length];
            bool flag = false;
            string[] oopOutData = new string[5];
            for (int i = 0; i < length; i++)
            {
                oopData[i] = str[i].ToString();
            }
            for (int j = 0; j < oopOutData.Length; j++)
            {
                cOutData[j].Clear();
            }
            flag = PublicVariable.encrypt.MethodEncryptServer698(oopEncryptor, oopMethod, oopData, out oopOutData);
            if (flag && (oopOutData.Length != 0))
            {
                for (int k = 0; k < oopOutData.Length; k++)
                {
                    cOutData[k].Append(oopOutData);
                }
                return flag;
            }
            return false;
        }

        public static bool MethodEncryptServer698(OOPEncryptor oopEncryptor, OOPMethod oopMethod, ref StringBuilder cOutData, params object[] str)
        {
            int length = str.Length;
            string[] oopData = new string[length];
            bool flag = false;
            string[] oopOutData = new string[1];
            cOutData.Clear();
            for (int i = 0; i < length; i++)
            {
                oopData[i] = str[i].ToString();
            }
            flag = PublicVariable.encrypt.MethodEncryptServer698(oopEncryptor, oopMethod, oopData, out oopOutData);
            if (flag && (oopOutData.Length == 1))
            {
                cOutData.Append(oopOutData[0]);
                return flag;
            }
            return false;
        }

        public static bool MethodEncryptServer698(OOPEncryptor oopEncryptor, OOPMethod oopMethod, ref StringBuilder cOutData1, ref StringBuilder cOutData2, ref StringBuilder cOutData3, params object[] str)
        {
            int length = str.Length;
            string[] oopData = new string[length];
            bool flag = false;
            string[] oopOutData = new string[1];
            cOutData1.Clear();
            cOutData2.Clear();
            cOutData3.Clear();
            for (int i = 0; i < length; i++)
            {
                oopData[i] = str[i].ToString();
            }
            flag = PublicVariable.encrypt.MethodEncryptServer698(oopEncryptor, oopMethod, oopData, out oopOutData);
            if (flag && (oopOutData.Length == 3))
            {
                cOutData1.Append(oopOutData[0]);
                cOutData2.Append(oopOutData[1]);
                cOutData3.Append(oopOutData[2]);
                return flag;
            }
            return false;
        }

        public static bool MethodEncryptServer698(OOPEncryptor oopEncryptor, OOPMethod oopMethod, ref StringBuilder cOutData1, ref StringBuilder cOutData2, ref StringBuilder cOutData3, ref StringBuilder cOutData4, params object[] str)
        {
            int length = str.Length;
            string[] oopData = new string[length];
            bool flag = false;
            string[] oopOutData = new string[1];
            cOutData1.Clear();
            cOutData2.Clear();
            cOutData3.Clear();
            cOutData4.Clear();
            for (int i = 0; i < length; i++)
            {
                oopData[i] = str[i].ToString();
            }
            flag = PublicVariable.encrypt.MethodEncryptServer698(oopEncryptor, oopMethod, oopData, out oopOutData);
            if (flag && (oopOutData.Length == 4))
            {
                cOutData1.Append(oopOutData[0]);
                cOutData2.Append(oopOutData[1]);
                cOutData3.Append(oopOutData[2]);
                cOutData4.Append(oopOutData[3]);
                return flag;
            }
            return false;
        }
    }
}

