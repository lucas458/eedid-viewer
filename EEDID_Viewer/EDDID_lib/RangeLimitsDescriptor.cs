using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class RangeLimitsDescriptor : TaggedDescriptor
    {
        public readonly ushort VerticalRateMin;
        public readonly ushort VerticalRateMax;
        public readonly ushort HorizontalRateMin;
        public readonly ushort HorizontalRateMax;
        public readonly ushort PixelClockMax;
        public readonly SecundaryGTF SecundaryGTF;
        public readonly CVTSupport CVTSupport;


        public RangeLimitsDescriptor(byte[] data, bool supportGTForCVT) : base(0xFD)
        {
            VerticalRateMin     = (ushort)(((data[4] & 0x03) == 0x03) ? data[5] + 255 : data[5]);
            VerticalRateMax     = (ushort)(((data[4] & 1 << 1) != 0) ? data[6] + 255 : data[6]);

            HorizontalRateMin   = (ushort)(((data[4] & 0x0C) == 0x0C)? data[7] + 255 : data[7]);
            HorizontalRateMax   = (ushort)(((data[4] & 1 << 3) != 0) ? data[8] + 255 : data[8]);

            PixelClockMax       = (ushort)(data[9] * 10);

            if (supportGTForCVT)
            {
                SecundaryGTF = new SecundaryGTF(data);
                CVTSupport = new CVTSupport(data);
            }

        }


        public override string ToString()
        {
            string result = "<RangeLimitsDescriptor>";
            result += $"<VerticalRateMin>{VerticalRateMin}</VerticalRateMin>";
            result += $"<VerticalRateMax>{VerticalRateMax}</VerticalRateMax>";
            result += $"<HorizontalRateMin>{HorizontalRateMin}</HorizontalRateMin>";
            result += $"<HorizontalRateMax>{HorizontalRateMax}</HorizontalRateMax>";
            result += $"<PixelClockMax>{PixelClockMax}</PixelClockMax>"; 
            result += (SecundaryGTF == null) ? "" : SecundaryGTF.ToString();
            result += (CVTSupport == null) ? "" : CVTSupport.ToString(); 
            result += "</RangeLimitsDescriptor>";
            return result;
        }


    }
}
