using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashNullableResponse
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 返回错误
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
