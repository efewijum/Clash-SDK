﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashProxiesResponse
    {
        /// <summary>
        /// 所有代理
        /// </summary>
        public List<ClashProxyDetailResponse> Proxies { get; set; }
    }
}
