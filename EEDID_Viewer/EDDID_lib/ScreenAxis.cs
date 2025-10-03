using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ScreenAxis
    {
        public readonly Screen Horizontal;
        public readonly Screen Vertical;

        public ScreenAxis(byte data1, byte data2) 
        {
            if ( EEDID.ToUint16(data1, data2) == 0x0000)
            {
                return;
            } 

            Horizontal  = new Screen( data1, new AspectRatio((data1+99)/100D, 1) );
            Vertical    = new Screen( data2, new AspectRatio(100D/(data2+99), 1) );
        }


        public override string ToString()
        {
            string result = "<ScreenAxis>";
            result += $"<Horizontal>{Horizontal.ToString()}</Horizontal>";
            result += $"<Vertical>{Vertical.ToString()}</Vertical>";
            result += "</ScreenAxis>";
            return result;
        }

    }
}
