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

        public async Task<ClashDelayResponse> GetClashProxyDelay(string name, int timeout = 3000, string testUrl = "http://www.gstatic.com/generate_204")
        {
            string url = string.Format(API_PROXIES_DELAY, Uri.EscapeDataString(name));

            var dict = new Dictionary<string, dynamic>();
            dict.Add("timeout", Convert.ToString(timeout));
            dict.Add("url", testUrl);

            var result = await GetAsync<ClashDelayResponse>(url, dict);
            result.DelayLong = LongParser.Parse(result.Delay);
            return result;
        }

        public async Task SwitchClashProxy(string selector, string proxy)
        {
            string url = string.Format(API_PROXIES_NAME, Uri.EscapeDataString(selector));

            var obj = new
            {
                name = proxy
            };

            await PutAsync<ClashNullResponse>(url, null, obj);
        }

        public async Task DisconnectConnection(string uuid)
        {
            string url = string.Format(API_CONNECTIONS_UUID, Uri.EscapeDataString(uuid));

            _ = await DeleteAsync<ClashNullResponse>(url);
        }

        public async Task DisconnectAllConnections()
        {
            _ = await DeleteAsync<ClashNullResponse>(API_CONNECTIONS);
        }
    }
}
