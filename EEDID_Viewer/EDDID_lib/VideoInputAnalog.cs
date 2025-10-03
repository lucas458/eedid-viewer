using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class VideoInputAnalog : VideoInput
    {
        public readonly byte SignalLevel;
        public readonly bool VideoSetupBlankToBlack;
        public readonly SyncType SyncType;
        public readonly bool Serrations;

        public VideoInputAnalog( byte data ) : base(false)
        {

            SignalLevel             = (byte)((data >> 5) & 0x03);
            VideoSetupBlankToBlack  = (data & 1 << 4) != 0;
            SyncType                = new SyncType(data);
            Serrations              = (data & 1 << 0) != 0;
        }


        public override string ToString()
        {
            string result = "<VideoInput isDigital=\"false\">";
            result += $"<SignalLevel>{SignalLevel}</SignalLevel>";
            result += $"<VideoSetupBlankToBlack>{SignalLevel}</VideoSetupBlankToBlack>";
            result += SyncType.ToString();
            result += $"<Serrations>{Serrations}</Serrations>";
            result += "</VideoInput>";
            return result;
        }

    }
}
