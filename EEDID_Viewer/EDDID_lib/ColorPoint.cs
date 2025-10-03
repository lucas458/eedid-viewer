using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ColorPoint
    {
        public readonly ColorChannelAxis Axis;
        public readonly double Gamma;
        public readonly bool HasGamma;
        public readonly byte WhitePointIndex;

        public ColorPoint(ColorChannelAxis axis, double gamma, bool hasGamma, byte whitePointIndex)
        {
            Axis            = axis;
            Gamma           = (hasGamma) ? gamma : 0;
            HasGamma        = hasGamma;
            WhitePointIndex = whitePointIndex;
        }


        public override string ToString()
        {
            string result = "<ColorPoint>";
            result += Axis.ToString();
            result += $"<Gamma>{Gamma}</Gamma>";
            result += $"<HasGamma>{HasGamma}</HasGamma>";
            result += $"<WhitePointIndex>{WhitePointIndex}</WhitePointIndex>";
            result += "</ColorPoint>";
            return result;
        }

    }
}
