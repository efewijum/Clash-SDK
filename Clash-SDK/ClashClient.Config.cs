using Clash.SDK.Models.Response;
using Clash.SDK.Models.Share;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK
{
    public sealed partial class ClashClient
    {
        public async Task<bool> GetClashStatus()
        {
            try
            {
                _ = await GetAsync<ClashStatusResponse>(API_STATUS);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ClashVersionResponse> GetClashVersion()
        {
            var result = await GetAsync<ClashVersionResponse>(API_VERSION);
            return result;
        }

        public async Task<ClashConfigsResponse> GetClashConfigs()
        {
            var result = await GetAsync<ClashConfigsResponse>(API_CONFIGS);
            return result;
        }

        public async Task<ClashNullableResponse> ChangeClashConfigs(Dictionary<string, dynamic> dict)
        {
            var result = await PatchAsync<ClashNullableResponse>(API_CONFIGS, dict);
            return result;
        }

        public async Task<ClashNullableResponse> ReloadClashConfig(bool force = false, string path = "")
        {
            var dict = new Dictionary<string, dynamic>();
            dict.Add("force", Convert.ToString(force));

            var obj = new
            {
                path = path,
            };

            var result = await PutAsync<ClashNullableResponse>(API_CONFIGS, dict, string.IsNullOrWhiteSpace(path) ? null : obj);
            return result;
        }

        public async Task<ClashRulesResponse> GetClashRules()
        {
            var result = await GetAsync<ClashRulesResponse>(API_RULES);
            return result;
        }

        public async Task<ClashRuleProvidersResponse> GetClashRuleProviders()
        {
            ClashRuleProvidersResponse result = new ClashRuleProvidersResponse
            {
                Providers = new List<ClashRuleProviderData>()
            };
            string data = await GetAsync<string>(API_RULE_PROVIDERS);
            var obj = JObject.Parse(data);
            foreach (JProperty provider in obj["providers"])
            {
                result.Providers.Add(provider.Value.ToObject<ClashRuleProviderData>());
            }
            return result;
        }

        public async Task<ClashNullableResponse> UpdateRuleProvider(string name)
        {
            string url = string.Format(API_RULE_PROVIDER_NAME, Uri.EscapeDataString(name));

            var result = await PutAsync<ClashNullableResponse>(url);
            return result;
        }
    }
}
