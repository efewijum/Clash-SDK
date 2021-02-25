using Clash.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashLogResponse
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        [JsonProperty("type")]
        public LogType Type { get; set; }

        /// <summary>
        /// 日志信息
        /// </summary>
        [JsonProperty("payload")]
        public string PayLoad { get; set; }
    }
}
