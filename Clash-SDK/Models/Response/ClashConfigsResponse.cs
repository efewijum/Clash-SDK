using Clash.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashConfigsResponse
    {
        /// <summary>
        /// Socks代理端口
        /// </summary>
        [JsonProperty("socks-port")]
        public int SocksPort { get; set; }
        
        /// <summary>
        /// Http代理端口
        /// </summary>
        [JsonProperty("port")]
        public int HttpPort { get; set; }

        /// <summary>
        /// Redir端口
        /// </summary>
        [JsonProperty("redir-port")]
        public int RedirPort { get; set; }

        /// <summary>
        /// TProxy端口
        /// </summary>
        [JsonProperty("tproxy-port")]
        public int TProxyPort { get; set; }

        /// <summary>
        /// 混合代理端口
        /// </summary>
        [JsonProperty("mixed-port")]
        public int MixedPort { get; set; }

        /// <summary>
        /// 允许局域网访问
        /// </summary>
        [JsonProperty("allow-lan")]
        public bool AllowLan { get; set; }

        /// <summary>
        /// Clash监听地址
        /// </summary>
        [JsonProperty("bind-address")]
        public string BindAddress { get; set; }

        /// <summary>
        /// Clash代理模式
        /// </summary>
        [JsonProperty("mode")]
        public ModeType Mode { get; set; }

        /// <summary>
        /// Clash日志等级
        /// </summary>
        [JsonProperty("log-level")]
        public LogLevelType LogLevel { get; set; }
        
        /// <summary>
        /// 是否启用IPV6
        /// </summary>
        [JsonProperty("ipv6")]
        public bool IPV6 { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        [JsonProperty("interface-name")]
        public string InterfaceName { get; set; }
    }
}
