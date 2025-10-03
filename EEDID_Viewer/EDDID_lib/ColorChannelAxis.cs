using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ColorChannelAxis
    {
        public readonly double X;
        public readonly double Y;

        public ColorChannelAxis(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"<ColorChannelAxis x=\"{X}\" y=\"{Y}\"/>";
        }

    }
}
