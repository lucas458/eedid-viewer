using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class StandardTimingDescriptor : TaggedDescriptor
    {
        //public readonly StandardTiming[] StandardTiming = new StandardTiming[6];
        public readonly List<StandardTiming> StandardTimings = new List<StandardTiming>();

        public StandardTimingDescriptor(byte[] data) : base(0xFA)
        {

            for (byte i = 0; i < 6; i++)
            {
                ushort value = EEDID.ToUint16(data[5 + (i * 2)], data[5 + (i * 2 + 1)]);
                if (value != 0x0101)
                {
                    StandardTimings.Add(new StandardTiming(value));
                }
            }

        }


        public override string ToString()
        {
            string result = "<StandardTimingDescriptor>";
            StandardTimings.ForEach(e => result += e.ToString());
            result += "</StandardTimingDescriptor>";
            return result;
        }


    }
}
