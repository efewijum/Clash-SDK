using Clash.SDK.Models.Response;
using Clash.SDK.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK
{
    public sealed partial class ClashClient
    {
        public async Task<ClashProxiesResponse> GetClashProxies()
        {
            ClashProxiesResponse result = new ClashProxiesResponse
            {
                Proxies = new List<ClashProxyDetailResponse>()
            };
            string data = await GetAsync<string>(API_PROXIES);
            var obj = JObject.Parse(data);
            foreach (JProperty proxy in obj["proxies"])
            {
                result.Proxies.Add(proxy.Value.ToObject<ClashProxyDetailResponse>());
            }
            return result;
        }

        public async Task<ClashProxyDetailResponse> GetClashProxyDetail(string name)
        {
            string url = string.Format(API_PROXIES_NAME, Uri.EscapeDataString(name));
            var result = await GetAsync<ClashProxyDetailResponse>(url);
            return result;
        }

        public async Task<ClashDelayResponse> GetClashProxyDelay(string name, int timeout = 5000, string testUrl = "http://www.gstatic.com/generate_204")
        {
            string url = string.Format(API_PROXIES_DELAY, Uri.EscapeDataString(name));

            var dict = new Dictionary<string, dynamic>();
            dict.Add("timeout", Convert.ToString(timeout));
            dict.Add("url", testUrl);

            var result = await GetAsync<ClashDelayResponse>(url, dict);
            result.DelayLong = LongParser.Parse(result.Delay);
            return result;
        }

        public async Task<ClashNullableResponse> SwitchClashProxy(string selector, string proxy)
        {
            string url = string.Format(API_PROXIES_NAME, Uri.EscapeDataString(selector));

            var obj = new
            {
                name = proxy
            };

            var result = await PutAsync<ClashNullableResponse>(url, null, obj);
            return result;
        }

        public async Task<ClashNullableResponse> DisconnectConnection(string uuid)
        {
            string url = string.Format(API_CONNECTIONS_UUID, Uri.EscapeDataString(uuid));

            var result = await DeleteAsync<ClashNullableResponse>(url);
            return result;
        }

        public async Task<ClashNullableResponse> DisconnectAllConnections()
        {
            var result = await DeleteAsync<ClashNullableResponse>(API_CONNECTIONS);
            return result;
        }
    }
}
