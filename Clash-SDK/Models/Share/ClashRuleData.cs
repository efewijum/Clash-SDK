using Clash.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Share
{
    public class ClashRuleData
    {
        [JsonProperty("type")]
        public RuleType Type { get; set; }

        [JsonProperty("payload")]
        public string PayLoad { get; set; }

        [JsonProperty("proxy")]
        public string Proxy { get; set; }
    }
}
