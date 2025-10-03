using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ManufacturerDataDescriptor : TaggedDescriptor
    {
        public readonly byte[] Data = new byte[13];

        public ManufacturerDataDescriptor(byte[] data) : base(data[3])
        {
            Data = data;
        }


        public override string ToString()
        {
            return $"<ManufacturerDataDescriptor><Data>{Data}</Data></ManufacturerDataDescriptor>";
        }

    }

}
