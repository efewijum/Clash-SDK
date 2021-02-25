using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashDelayResponse
    {
        /// <summary>
        /// 节点延迟
        /// </summary>
        [JsonProperty("delay")]
        public string Delay { get; set; }

        /// <summary>
        /// 节点延迟 (long)
        /// </summary>
        public long DelayLong { get; set; }
    }
}
