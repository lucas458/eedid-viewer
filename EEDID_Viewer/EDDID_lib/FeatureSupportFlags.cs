using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class FeatureSupportFlags
    {
        public readonly bool SRGB;
        public readonly bool IncludeNativePixelFormat;
        public readonly bool ContinuousFrequency;


        public FeatureSupportFlags(byte data)
        {
            SRGB                        = (data & 1 << 2) != 0;
            IncludeNativePixelFormat    = (data & 1 << 1) != 0;
            ContinuousFrequency         = (data & 1 << 0) != 0;
        }

        public override string ToString()
        {
            string result = "<FeatureSupportFlags>";
            result += $"<SRGB>{SRGB}</SRGB>";
            result += $"<IncludeNativePixelFormat>{IncludeNativePixelFormat}</IncludeNativePixelFormat>";
            result += $"<ContinuousFrequency>{ContinuousFrequency}</ContinuousFrequency>";
            result += "</FeatureSupportFlags>";
            return result;
        }

    }
}
