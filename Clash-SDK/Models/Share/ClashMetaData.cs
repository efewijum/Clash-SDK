using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Share
{
    public class ClashMetaData
    {
        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sourceIP")]
        public string SourceIP { get; set; }

        [JsonProperty("sourcePort")]
        public int SourcePort { get; set; }

        [JsonProperty("destinationIP")]
        public string DestinationIP { get; set; }

        [JsonProperty("destinationPort")]
        public int DestinationPort { get; set; }
    }
}
