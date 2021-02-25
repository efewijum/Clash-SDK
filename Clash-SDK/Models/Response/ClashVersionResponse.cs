using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashVersionResponse
    {
        /// <summary>
        /// Clash版本
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
