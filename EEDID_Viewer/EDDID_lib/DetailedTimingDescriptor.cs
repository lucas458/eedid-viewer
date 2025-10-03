using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class DetailedTimingDescriptor : DataBlock
    {
        public readonly uint PixelClockHz;
        public readonly DetailedTimingAxis Horizontal;
        public readonly DetailedTimingAxis Vertical;
        public readonly bool Interlaced;
        public readonly byte StereoViewingSupport;
        public readonly SyncSignal SyncSignal;

        public DetailedTimingDescriptor( byte[] data ) : base(false)
        {

            PixelClockHz = (uint)(EEDID.ToUint16(data[1], data[0]) * 10000);

            Horizontal = new DetailedTimingAxis(EEDID.ToUint16((byte)(data[4]>>4), data[2]),
                                                EEDID.ToUint16((byte)(data[4]&0x0F), data[3]),
                                                EEDID.ToUint16((byte)(data[11]>>6), data[8]),
                                                EEDID.ToUint16((byte)((data[11]>>4)&0x03), data[9]),
                                                EEDID.ToUint16((byte)(data[14]>>4), data[12]),
                                                data[15]);

            Vertical = new DetailedTimingAxis(EEDID.ToUint16((byte)(data[7]>>4), data[5]),
                                              EEDID.ToUint16((byte)(data[7]&0x0F), data[6]),
                                              (ushort)( ((data[11]<<2)&0x30) | (data[10]>>4) ),
                                              (ushort)( ((data[11]&0x03)<<4) | (data[10]&0x0F) ),
                                              EEDID.ToUint16((byte)(data[14]&0x0F), data[13]),
                                              data[16]);


            Interlaced = (data[17] & 1 << 7) != 0;
            StereoViewingSupport = (byte)(data[17] & 0x61);

            
            if ( (data[17] & 1 << 4) == 0 )
            {
                SyncSignal = new AnalogSyncSignal(data[17]);
            }
            else
            {
                SyncSignal = new DigitalSyncSignal(data[17]);
            }


        }




        public override string ToString()
        {
            string result = "<DetailedTimingDescriptor>"; 
            result += $"<PixelClockHz>{PixelClockHz}</PixelClockHz>";
            result += $"<Horizontal>{Horizontal.ToString()}</Horizontal>";
            result += $"<Vertical>{Vertical.ToString()}</Vertical>";
            result += $"<Interlaced>{Interlaced}</Interlaced>";
            result += $"<StereoViewingSupport>{StereoViewingSupport}</StereoViewingSupport>";
            result += SyncSignal.ToString();
            result += "</DetailedTimingDescriptor>";
            return result;
        }


    }
}
