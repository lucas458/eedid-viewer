using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class AspectRatio
    {
        public readonly double Horizontal;
        public readonly double Vertical;

        public AspectRatio(double horizontal, double vertical)
        {
            Horizontal  = horizontal;
            Vertical    = vertical;
        }

        public override string ToString()
        {
            return $"<AspectRatio horizontal=\"{Horizontal}\" vertical=\"{Vertical}\"/>";
        }

    }
}
