using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Tools
{
    public static class LongParser
    {
        public static long Parse(string value)
        {
            long result;
            if (!long.TryParse(value, out result))
            {
                result = -1;
            }
            return result;
        }
    }
}
