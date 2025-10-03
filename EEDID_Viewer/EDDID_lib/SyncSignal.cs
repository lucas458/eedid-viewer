using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class SyncSignal
    {
        public readonly bool IsDigital;
        public readonly bool Serrations;

        public SyncSignal(bool digital, bool serrations)
        {
            IsDigital = digital;
            Serrations = serrations;
        }

    }
}
