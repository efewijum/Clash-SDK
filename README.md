<p align="center">
    <img src="https://i.loli.net/2021/01/17/aK4wpbnsmudcJLo.png" align="center" height="80"/>
</p>

<div align="center">

# Clash .NET SDK

[![Nuget](https://img.shields.io/nuget/v/CoelWu.Clash.SDK)](https://www.nuget.org/packages/CoelWu.Clash.SDK/)

该SDK基于[Clash API](https://clash.gitbook.io/doc/restful-api)实现，在.NET Standard 2.0上构建

## 简单的开始

使用前，你需要先安装 **CoelWu.Clash.SDK** nuget包

```csharp
// 创建Client
ClashClient _client = new ClashClient();

// 获取Clash版本
var autoComNumResponse = await _client.GetClashVersion();

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
- [ClashX](https://github.com/yichengchen/clashX)