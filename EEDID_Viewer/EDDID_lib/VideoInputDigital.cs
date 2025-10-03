using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class VideoInputDigital : VideoInput
    {
        public readonly byte BitDepth;
        public readonly byte SupportedDigitalVideoInterface;


        public VideoInputDigital(byte data) : base(true)
        {
            BitDepth                        = (byte)( (data >> 4) & 0x07 );
            SupportedDigitalVideoInterface  = (byte)(data & 0x0F);
        }

        public override string ToString()
        {
            string result = "<VideoInput isDigital=\"true\">";
            result += $"<BitDepth>{BitDepth}</BitDepth>";
            result += $"<SupportedDigitalVideoInterface>{SupportedDigitalVideoInterface}</SupportedDigitalVideoInterface>";
            result += "</VideoInput>";
            return result;
        }

    }
}
