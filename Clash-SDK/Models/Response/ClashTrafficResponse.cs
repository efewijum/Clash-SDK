using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashTrafficResponse
    {
        /// <summary>
        /// 上行流量
        /// </summary>
        [JsonProperty("up")]
        public long Up { get; set; }

        /// <summary>
        /// 下行流量
        /// </summary>
        [JsonProperty("down")]
        public long Down { get; set; }
    }
}
