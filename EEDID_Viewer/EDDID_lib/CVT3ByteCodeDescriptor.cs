using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class CVT3ByteCodeDescriptor : TaggedDescriptor
    {
        public readonly byte Version; 
        public readonly CVT3ByteCode[] CVT3ByteCodes = new CVT3ByteCode[4];

        public CVT3ByteCodeDescriptor(byte[] data) : base(0xF8)
        {

        }


        public override string ToString()
        {
            string result = "<CVT3ByteCodeDescriptor>";
            result += $"<Version>{Version}</Version>";

            result += $"<CVT3ByteCodes>";
            CVT3ByteCodes.ToList().ForEach(e => result += e.ToString());
            result += $"</CVT3ByteCodes>";

            result += "</CVT3ByteCodeDescriptor>";
            return result;
        }

    }
}
