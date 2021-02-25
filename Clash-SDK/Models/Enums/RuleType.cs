using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clash.SDK.Models.Enums
{
    public enum RuleType
    {
        [EnumMember(Value = "Domain")]
        Domain,

        [EnumMember(Value = "DomainSuffix")]
        DomainSuffix,

        [EnumMember(Value = "DomainKeyword")]
        DomainKeyword,

        [EnumMember(Value = "SrcIPCIDR")]
        SrcIPCIDR,

        [EnumMember(Value = "IPCIDR")]
        IPCIDR,
        
        [EnumMember(Value = "GeoIP")]
        GeoIP,

        [EnumMember(Value = "DstPort")]
        DstPort,

        [EnumMember(Value = "SrcPort")]
        SrcPort,

        [EnumMember(Value = "Match")]
        Match
    }
}
