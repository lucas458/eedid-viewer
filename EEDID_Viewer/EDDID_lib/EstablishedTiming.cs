using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class EstablishedTiming
    {
        public readonly ushort Width;
        public readonly ushort Height;
        public readonly ushort Frequency;

        public EstablishedTiming(ushort width, ushort height, ushort freq)
        {
            Width       = width;
            Height      = height;
            Frequency   = freq;
        }

        public override string ToString()
        {
            string result = "<EstablishedTiming>";
            result += $"<Width>{Width}</Width>";
            result += $"<Height>{Height}</Height>";
            result += $"<Frequency>{Frequency}</Frequency>";
            result += "</EstablishedTiming>";
            return result;
        }

    }
}
