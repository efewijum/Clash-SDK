using Clash.SDK.Models.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashConnectionResponse
    {
        [JsonProperty("downloadTotal")]
        public long DownloadTotal { get; set; }

        [JsonProperty("uploadTotal")]
        public long UploadTotal { get; set; }

        [JsonProperty("connections")]
        public List<ClashConnectionData> Connections { get; set; }
    }
}
