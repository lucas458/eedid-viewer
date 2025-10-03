using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class DetailedTimingAxis
    {
        public readonly ushort AddressableVideo;
        public readonly ushort Blanking;
        public readonly ushort FrontPorch;
        public readonly ushort SyncPulse;
        public readonly ushort ImageSize;
        public readonly byte BorderSize;

        public DetailedTimingAxis(ushort addressableVideo, ushort blanking,
                                  ushort frontPorch, ushort syncPulse, ushort imageSize, byte borderSize)
        {
            AddressableVideo    = addressableVideo;
            Blanking            = blanking;
            FrontPorch          = frontPorch;
            SyncPulse           = syncPulse;
            ImageSize           = imageSize;
            BorderSize          = borderSize;
        }

        public override string ToString()
        {
            string result = "<DetailedTimingAxis>"; 
            result += $"<AddressableVideo>{AddressableVideo}</AddressableVideo>";
            result += $"<Blanking>{Blanking}</Blanking>";
            result += $"<FrontPorch>{FrontPorch}</FrontPorch>";
            result += $"<SyncPulse>{SyncPulse}</SyncPulse>";
            result += $"<ImageSize>{ImageSize}</ImageSize>";
            result += $"<BorderSize>{BorderSize}</BorderSize>"; 
            result += "</DetailedTimingAxis>";
            return result;
        }

    }
}
