using Clash.SDK.Models.Response;
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
    }
}
