using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class DataBlock
    {
        public readonly bool IsDescriptor;

        public DataBlock(bool isDescriptor)
        {
            IsDescriptor = isDescriptor;
        }

    }
}
