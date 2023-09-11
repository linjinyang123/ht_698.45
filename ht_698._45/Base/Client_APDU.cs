using System;
namespace ht_698._45
{
  

    public enum Client_APDU
    {
        建立应用连接请求 = 2,
        断开应用连接请求 = 3,
        读取请求 = 5,
        设置请求 = 6,
        操作请求 = 7,
        上报应答 = 8,
        代理请求 = 9,
        异常响应 = 110
    }
}

