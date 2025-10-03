using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class TaggedDescriptor : DataBlock
    {
        public readonly byte Tag;

        public TaggedDescriptor(byte tag) : base(true)
        {
            Tag = tag;
        }
    }
}
