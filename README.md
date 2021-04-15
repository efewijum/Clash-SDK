<p align="center">
    <img src="https://i.loli.net/2021/02/25/SdtJ295biqulCkf.png" align="center" height="80"/>
</p>

<div align="center">

# Clash .NET SDK

[![Nuget](https://img.shields.io/nuget/v/CoelWu.Clash.SDK?color=green&style=flat-square)](https://www.nuget.org/packages/CoelWu.Clash.SDK/)
![RunTime](https://img.shields.io/static/v1?label=runtime&message=.NET%205&color=cyan&style=flat-square)
![RunTime](https://img.shields.io/static/v1?label=runtime&message=.NET%20Core%203.1&color=blue&style=flat-square)
![RunTime](https://img.shields.io/static/v1?label=runtime&message=.NET%20Standard%202.0&color=yellow&style=flat-square)
![RunTime](https://img.shields.io/static/v1?label=runtime&message=.NET%20Standard%202.1&color=pink&style=flat-square)

该SDK基于[Clash API](https://clash.gitbook.io/doc/restful-api)实现

</div>

## 简单的开始

使用前，你需要先安装 **CoelWu.Clash.SDK** nuget包

```csharp
// 创建Client
ClashClient _client = new ClashClient();

// 获取Clash版本
var clashVersionResponse = await _client.GetClashVersion();

// 断开所有链接
await _client.DisconnectAllConnections();
```

## 更多例子

如需要更多使用案例，请参考 **ClashSDK-ConsoleApp**

## 释放

当你觉得客户端已经完成了使命，到了该释放的时候，那么你可以调用`Dispose`方法释放客户端对象。

```csharp
_client.Dispose();
```

## 鸣谢

- [Clash API](https://clash.gitbook.io/doc/restful-api)
- [Clash X](https://github.com/yichengchen/clashX)