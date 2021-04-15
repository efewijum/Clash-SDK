using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Enums
{
    public enum VehicleType
    {
        [JsonProperty("Compatible")]
        Compatible,

        [JsonProperty("File")]
        File,

        [JsonProperty("HTTP")]
        Http
    }
}
