using System;

namespace ht_698._45
{
   
    public enum ConnectResult
    {
        允许建立应用连接 = 0,
        密码错误 = 1,
        对称解密错误 = 2,
        非对称解密错误 = 3,
        签名错误 = 4,
        协议版本不匹配 = 5,
        其他错误 = 0xff
    }
}

