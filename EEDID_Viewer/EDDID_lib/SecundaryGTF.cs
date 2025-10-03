using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class SecundaryGTF
    {
        public readonly byte StartBreakFrenquency;
        public readonly byte C;
        public readonly ushort M;
        public readonly byte K;
        public readonly byte J;

        public SecundaryGTF(byte[] data)
        {
            StartBreakFrenquency = data[12];
            C = (byte)(data[13] * 2);
            M = EEDID.ToUint16(data[15], data[14]);
            K = data[16];
            J = (byte)(data[17] * 2);
        }

        public override string ToString()
        {
            string result = "<SecundaryGTF>";
            result += $"<C>{C}</C>";
            result += $"<M>{M}</M>";
            result += $"<K>{K}</K>";
            result += $"<J>{J}</J>";
            result += "</SecundaryGTF>";
            return result;
        }

    }
}
