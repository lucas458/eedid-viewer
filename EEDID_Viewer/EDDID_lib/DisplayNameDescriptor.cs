using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class DisplayNameDescriptor : TaggedDescriptor
    {
        public readonly string Name;


        public DisplayNameDescriptor(byte[] data) : base(0xFC)
        {
            Name = Encoding.Default.GetString(data.Skip(5).Take(13).ToArray());
        }

        public override string ToString()
        {
            return $"<DisplayNameDescriptor><Serial>{Name}</Serial></DisplayNameDescriptor>";
        }

    }
}
