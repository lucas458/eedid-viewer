using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ColorManagementDescriptor : TaggedDescriptor
    {
        public readonly byte Version;
        public readonly double Red;
        public readonly double Green;
        public readonly double Blue;


        public ColorManagementDescriptor(byte[] data) : base(0xF9)
        {

        }

    }
}
