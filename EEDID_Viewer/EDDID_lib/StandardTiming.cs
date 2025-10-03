using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class StandardTiming
    {
        public readonly ushort HorizontalSize;
        public readonly AspectRatio AspectRatio;
        public readonly byte RefreshRate;

        public static readonly AspectRatio[] AspectRatioTypes = new AspectRatio[]
        {
            new AspectRatio(16, 10),
            new AspectRatio(4, 3),
            new AspectRatio(5, 4),
            new AspectRatio(16, 9)
        };

        public StandardTiming( ushort data )
        {
            HorizontalSize  = (ushort)(((data >> 8) + 31) * 8);
            AspectRatio     = AspectRatioTypes[ (data & 0xFF) >> 6 ];
            RefreshRate     = (byte)((data & 0x3F) + 60);
        }


        public override string ToString()
        {
            string result = "<StandardTiming>";
            result += $"<HorizontalSize>{HorizontalSize}</HorizontalSize>";
            result += $"<RefreshRate>{RefreshRate}</RefreshRate>";
            result += AspectRatio.ToString();
            result += "</StandardTiming>";
            return result;
        }


    }
}
