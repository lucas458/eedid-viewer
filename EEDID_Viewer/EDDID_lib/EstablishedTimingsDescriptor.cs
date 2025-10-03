using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class EstablishedTimingsDescriptor : TaggedDescriptor
    {
        public static readonly EstablishedTiming[] EstablishedTimingsTypes = new EstablishedTiming[]
        {
            // Byte 6
            new EstablishedTiming(640, 350, 85),
            new EstablishedTiming(640, 400, 85),
            new EstablishedTiming(720, 400, 85),
            new EstablishedTiming(640, 480, 85),
            new EstablishedTiming(848, 480, 60),
            new EstablishedTiming(800, 600, 85),
            new EstablishedTiming(1024, 768, 85),
            new EstablishedTiming(1152, 864, 85),
            // Byte 7
            new EstablishedTiming(1280, 768, 60), // RB     Note: (RB) means reduced blanking
            new EstablishedTiming(1280, 768, 60),
            new EstablishedTiming(1280, 768, 75),
            new EstablishedTiming(1280, 768, 85),
            new EstablishedTiming(1280, 960, 60),
            new EstablishedTiming(1280, 960, 85),
            new EstablishedTiming(1280, 1024, 60),
            new EstablishedTiming(1280, 1024, 85),
            // Byte 8
            new EstablishedTiming(1360, 768, 60),
            new EstablishedTiming(1440, 900, 60), // RB
            new EstablishedTiming(1440, 900, 60),
            new EstablishedTiming(1440, 900, 75),
            new EstablishedTiming(1440, 900, 85),
            new EstablishedTiming(1400, 1050, 60), // RB
            new EstablishedTiming(1400, 1050, 60),
            new EstablishedTiming(1400, 1050, 75),
            // Byte 9
            new EstablishedTiming(1400, 1050, 85),
            new EstablishedTiming(1680, 1050, 60), // RB
            new EstablishedTiming(1680, 1050, 60),
            new EstablishedTiming(1680, 1050, 75),
            new EstablishedTiming(1680, 1050, 85),
            new EstablishedTiming(1600, 1200, 60),
            new EstablishedTiming(1600, 1200, 65),
            new EstablishedTiming(1600, 1200, 70),
            // Byte 10
            new EstablishedTiming(1600, 1200, 75),
            new EstablishedTiming(1600, 1200, 85),
            new EstablishedTiming(1792, 1344, 60),
            new EstablishedTiming(1792, 1344, 75),
            new EstablishedTiming(1856, 1392, 60),
            new EstablishedTiming(1856, 1392, 75),
            new EstablishedTiming(1920, 1200, 60), // RB
            new EstablishedTiming(1920, 1200, 60),
            // Byte 11
            new EstablishedTiming(1920, 1200, 75),
            new EstablishedTiming(1920, 1200, 85),
            new EstablishedTiming(1920, 1440, 60),
            new EstablishedTiming(1920, 1440, 75),
        };


        public readonly List<EstablishedTiming> EstablishedTimings = new List<EstablishedTiming>();


        public EstablishedTimingsDescriptor(byte[] data) : base(0xF7)
        {


            // Established Timings III
            for (byte i = 0; i < EstablishedTimingsTypes.Length; i++)
            {
                byte currentBit = (byte)(7 - (i % 8));
                byte currentBlock = (byte)(i / 8);
                byte currentData = data[6 + currentBlock];

                if ((currentData & 1 << currentBit) != 0)
                {
                    EstablishedTimings.Add(EstablishedTimingsTypes[i]);
                }

            }

        }



        public override string ToString()
        {
            string result = "<EstablishedTimings>";
            EstablishedTimings.ForEach(e => result += e.ToString());
            result += "</EstablishedTimings>";
            return result;
        }


    }
}
