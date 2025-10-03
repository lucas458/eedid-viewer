using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class TypeDisplayScalingSupported
    {
        public readonly bool HorizontalShrink;
        public readonly bool HorizontalStretch;
        public readonly bool VerticalShrink;
        public readonly bool VerticalStretch;

        public TypeDisplayScalingSupported(byte data)
        {
            HorizontalShrink    = (data & 1 << 7) != 0;
            HorizontalStretch   = (data & 1 << 6) != 0;
            VerticalShrink      = (data & 1 << 5) != 0;
            VerticalStretch     = (data & 1 << 4) != 0;
        }


        public override string ToString()
        {
            string result = "<TypeDisplayScalingSupported>"; 
            result += $"<HorizontalShrink>{HorizontalShrink}</HorizontalShrink>";
            result += $"<HorizontalStretch>{HorizontalStretch}</HorizontalStretch>";
            result += $"<VerticalShrink>{VerticalShrink}</VerticalShrink>";
            result += $"<VerticalStretch>{VerticalStretch}</VerticalStretch>"; 
            result += "</TypeDisplayScalingSupported>";
            return result;
        }

    }
}
