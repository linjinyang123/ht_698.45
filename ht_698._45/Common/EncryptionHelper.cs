namespace Common
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;

    public class EncryptionHelper
    {
        private string encryptionKeyA;
        private string encryptionKeyB;
        private string md5Begin;
        private string md5End;
        private string encryptionKey;

        public EncryptionHelper()
        {
            this.encryptionKeyA = "pfe_Nova";
            this.encryptionKeyB = "WorkHard";
            this.md5Begin = "Hello";
            this.md5End = "World";
            this.encryptionKey = string.Empty;
            this.InitKey(EncryptionKeyEnum.KeyA);
        }

        public EncryptionHelper(EncryptionKeyEnum key)
        {
            this.encryptionKeyA = "pfe_Nova";
            this.encryptionKeyB = "WorkHard";
            this.md5Begin = "Hello";
            this.md5End = "World";
            this.encryptionKey = string.Empty;
            this.InitKey(key);
        }

        private string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = new byte[pToDecrypt.Length / 2];
            for (int i = 0; i < (pToDecrypt.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte) num2;
            }
            provider.Key = Encoding.ASCII.GetBytes(sKey);
            provider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream stream = new MemoryStream();
            new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write).Write(buffer, 0, buffer.Length);
            StringBuilder builder = new StringBuilder();
            return Encoding.Default.GetString(stream.ToArray());
        }

        public string DecryptString(string str) 
        {
            return  this.Decrypt(str, this.encryptionKey);
        }
       

        private string Encrypt(string str, string sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(str);
            provider.Key = Encoding.ASCII.GetBytes(sKey);
            provider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            builder.ToString();
            return builder.ToString();
        }

        public string EncryptString(string str) 
        {
            return this.Encrypt(str, this.encryptionKey);
        }

        public string GetMD5String(string str)
        {
            str = this.md5Begin + str + this.md5End;
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            byte[] buffer2 = md.ComputeHash(bytes);
            string str2 = string.Empty;
            foreach (byte num in buffer2)
            {
                str2 = str2 + num.ToString("x2");
            }
            return str2;
        }

        private void InitKey(EncryptionKeyEnum key = 0)
        {
            switch (key)
            {
                case EncryptionKeyEnum.KeyA:
                    this.encryptionKey = this.encryptionKeyA;
                    break;

                case EncryptionKeyEnum.KeyB:
                    this.encryptionKey = this.encryptionKeyB;
                    break;
            }
        }
    }
}

