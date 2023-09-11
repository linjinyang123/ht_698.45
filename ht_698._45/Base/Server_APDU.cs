using System;
namespace ht_698._45
{
    public enum Server_APDU
    {
        建立应用连接响应 = 130,
        断开应用连接响应 = 0x83,
        断开应用连接通知 = 0x84,
        读取请求 = 0x85,
        设置请求 = 0x86,
        操作请求 = 0x87,
        上报响应 = 0x88,
        代理响应 = 0x89,
        异常响应 = 0xee
    }
}

