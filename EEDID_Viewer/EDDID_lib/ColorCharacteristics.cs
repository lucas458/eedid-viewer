using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ColorCharacteristics
    {
        public readonly ColorChannelAxis Red;
        public readonly ColorChannelAxis Green;
        public readonly ColorChannelAxis Blue;
        public readonly ColorChannelAxis White;

        public ColorCharacteristics( byte[] data )
        {
            ushort rawRedX      = (ushort)( (data[2] << 2) | ((data[0] >> 6) & 0x03) );
            ushort rawRedY      = (ushort)( (data[3] << 2) | ((data[0] >> 4) & 0x03) );
            ushort rawGreenX    = (ushort)( (data[4] << 2) | ((data[0] >> 2) & 0x03) );
            ushort rawGreenY    = (ushort)( (data[5] << 2) | ((data[0] >> 0) & 0x03) );
            ushort rawBlueX     = (ushort)( (data[6] << 2) | ((data[1] >> 6) & 0x03) );
            ushort rawBlueY     = (ushort)( (data[7] << 2) | ((data[1] >> 4) & 0x03) );
            ushort rawWhiteX    = (ushort)( (data[8] << 2) | ((data[1] >> 2) & 0x03) );
            ushort rawWhiteY    = (ushort)( (data[9] << 2) | ((data[1] >> 0) & 0x03) );

            Red                 = new ColorChannelAxis(rawRedX/1024D, rawRedY/1024D);
            Green               = new ColorChannelAxis(rawGreenX/1024D, rawGreenY/1024D);
            Blue                = new ColorChannelAxis(rawBlueX/1024D, rawBlueY/1024D);
            White               = new ColorChannelAxis(rawWhiteX/1024D, rawWhiteY/1024D);
        }


        public override string ToString()
        {
            string result = "<ColorCharacteristics>";
            result += Red.ToString();
            result += Green.ToString();
            result += Blue.ToString();
            result += White.ToString();
            result += "</ColorCharacteristics>";
            return result;
        }

    }
}
