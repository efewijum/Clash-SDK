using Clash.SDK.Models.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashRulesResponse
    {
        /// <summary>
        /// Clash代理规则
        /// </summary>
        [JsonProperty("rules")]
        public List<ClashRuleData> Rules;
    }
}
