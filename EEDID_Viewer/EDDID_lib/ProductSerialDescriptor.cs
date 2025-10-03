using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class ProductSerialDescriptor : TaggedDescriptor
    {
        public readonly string Serial;

        public ProductSerialDescriptor(byte[] data) : base(0xFF)
        {
            Serial = Encoding.Default.GetString(data.Skip(5).Take(13).ToArray());
        }


        public override string ToString()
        {
            return $"<ProductSerialDescriptor><Serial>{Serial}</Serial></ProductSerialDescriptor>";
        }

    }
}
