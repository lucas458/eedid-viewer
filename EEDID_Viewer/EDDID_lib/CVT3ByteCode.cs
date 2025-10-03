using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class CVT3ByteCode
    {
        public readonly ushort AddressableLines;
        public readonly AspectRatio AspectRatio;
        public readonly byte PreferredVerticalRate;
        public readonly byte SupportedVerticalRate;

        public static readonly AspectRatio[] AspectRatioTypes = new AspectRatio[]
        {
            new AspectRatio(4, 3),
            new AspectRatio(16, 9),
            new AspectRatio(16, 10),
            new AspectRatio(15, 9),
        };

        public CVT3ByteCode( uint data )
        {
            byte a = (byte)((data >> 16) & 0xFF);
            byte b = (byte)((data >> 8) & 0xFF);
            byte c = (byte)(data & 0xFF);


            AddressableLines        = (ushort)( ((b & 0xF0) << 4) | a ); 
            AspectRatio             = AspectRatioTypes[ (b >> 2) & 0x03 ];
            PreferredVerticalRate   = (byte)( (c >> 5) & 0x03 );
            SupportedVerticalRate   = (byte)( c & 0x1F );
        }


        public override string ToString()
        {
            string result = "<CVT3ByteCode>"; 
            result += $"<AddressableLines>{AddressableLines}</AddressableLines>";
            result += AspectRatio.ToString();
            result += $"<PreferredVerticalRate>{PreferredVerticalRate}</PreferredVerticalRate>";
            result += $"<SupportedVerticalRate>{SupportedVerticalRate}</SupportedVerticalRate>"; 
            result += "</CVT3ByteCode>";
            return result;
        }


    }

}
