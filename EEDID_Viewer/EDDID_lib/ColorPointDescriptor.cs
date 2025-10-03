using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ColorPointDescriptor : TaggedDescriptor
    {
        public readonly ColorPoint[] ColorPoint = new ColorPoint[2];
        

        public ColorPointDescriptor(byte[] data) : base(0xFB)
        {

            ColorChannelAxis axis0 = new ColorChannelAxis( ((data[7] << 2) | (data[6] >> 2)) / 1024D,
                                                           ((data[8] << 2) | (data[6] & 0x3)) / 1024D );

            ColorChannelAxis axis1 = new ColorChannelAxis( ((data[12] << 2) | (data[11] >> 2)) / 1024D,
                                                           ((data[13] << 2) | (data[11] & 0x3)) / 1024D );


            ColorPoint[0] = new ColorPoint(axis0, data[9],
                                           data[9] != 0xFF,
                                           data[5]);


            ColorPoint[1] = new ColorPoint(axis1, data[14],
                                           data[14] != 0xFF,
                                           data[10]);

        }


        public override string ToString()
        {
            string result = "<ColorPointDescriptor>";
            ColorPoint.ToList().ForEach(e => result += e.ToString());
            result += "</ColorPointDescriptor>";
            return result;
        }

    }
}
