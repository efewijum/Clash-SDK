using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashStatusResponse
    {
        [JsonProperty("hello")]
        public string Hello { get; set; }
    }
}
