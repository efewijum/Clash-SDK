using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Share
{
    public class ClashConnectionData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("download")]
        public long Download { get; set; }

        [JsonProperty("upload")]
        public long Upload { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("rule")]
        public string Rule { get; set; }

        [JsonProperty("rulePayload")]
        public string RulePayload { get; set; }

        [JsonProperty("chains")]
        public List<string> Chains { get; set; }

        [JsonProperty("metadata")]
        public ClashMetaData MetaData;
    }
}
