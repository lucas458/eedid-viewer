using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class DataStringDescriptor : TaggedDescriptor
    {
        public readonly string Data;


        public DataStringDescriptor(byte[] data) : base(0xFE)
        {
            Data = Encoding.Default.GetString(data.Skip(5).Take(13).ToArray());
        }

        public override string ToString()
        {
            return $"<DataStringDescriptor><Data>{Data}</Data></DataStringDescriptor>";
        }

    }
}
