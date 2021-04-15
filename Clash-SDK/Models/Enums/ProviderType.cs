using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Enums
{
    public enum ProviderType
    {
        [JsonProperty("Proxy")]
        Proxy,

        [JsonProperty("Rule")]
        Rule
    }
}
