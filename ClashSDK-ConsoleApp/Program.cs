using Clash.SDK;
using Clash.SDK.Models.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClashSDK.ConsoleApp
{
    class Program
    {
        static ClashClient clashClient = new ClashClient(26926);

        static void Main(string[] args)
        {
            Console.WriteLine("Clash-SDK Tester");
            TestClashSDK();
            Console.ReadKey();
        }

        public static async Task TestClashSDK()
        {
            /*
            // 打印版本
            Console.WriteLine("------------------Clash Version------------------");
            var version = await clashClient.GetClashVersion();
            Console.WriteLine(version.Version);
            // 打印规则
            Console.WriteLine("------------------Clash Rules------------------");
            var rules = await clashClient.GetClashRules();
            foreach (var rule in rules.Rules)
            {
                Console.WriteLine($"Type: {rule.Type} Payload: {rule.PayLoad} Proxy: {rule.Proxy}");
            }
            // 打印代理
            Console.WriteLine("------------------Clash Proxies------------------");
            var proxies = await clashClient.GetClashProxies();
            foreach (var proxy in proxies.Proxies)
            {
                Console.WriteLine($"Name: {proxy.Name} Type {proxy.Type.ToString()}");
            }
            // 测试WebSocket
            Console.WriteLine("------------------Clash WebSocket------------------");
            clashClient.GetClashConnection();
            clashClient.ConnectionUpdatedEvt += OnConnectionUpdated;
            //clashClient.ConnectionUpdatedEvt -= OnConnectionUpdated;
            // 测试延迟
            Console.WriteLine("------------------Clash Latency------------------");
            var result = await clashClient.GetClashProxyDelay("DIRECT");
            Console.WriteLine(result.Delay);
            */
            // 测试更改配置
            Console.WriteLine("------------------Clash Config------------------");
            var dict = new Dictionary<string, string>();
            dict.Add("mode", "direct");
            await clashClient.ChangeClashConfigs(dict);
            Console.WriteLine("Done");
        }

        public static void OnConnectionUpdated(object sender, ConnectionEvtArgs e)
        {

        }
    }
}
