using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class Screen
    {
        public readonly byte Size;
        public readonly AspectRatio AspectRatio;


        public Screen(byte size, AspectRatio ratio)
        {
            Size        = size;
            AspectRatio = ratio;
        }


        public override string ToString()
        {
            string result = "<Screen>";
            result += $"<Size>{Size}</Size>";
            result += AspectRatio.ToString();
            result += "</Screen>";
            return result;
        }

    }
}
