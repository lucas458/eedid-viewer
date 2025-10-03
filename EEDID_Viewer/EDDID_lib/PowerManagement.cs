using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class PowerManagement
    {
        public readonly bool StandbyMode;
        public readonly bool SuspendMode;
        public readonly bool ActiveOff;


        public PowerManagement(byte data)
        {
            StandbyMode = (data & 1 << 7) != 0;
            SuspendMode = (data & 1 << 6) != 0;
            ActiveOff   = (data & 1 << 5) != 0; 
        }

        public override string ToString()
        {
            string result = "<PowerManagement>";
            result += $"<StandbyMode>{StandbyMode}</StandbyMode>";
            result += $"<StandbyMode>{SuspendMode}</StandbyMode>";
            result += $"<StandbyMode>{ActiveOff}</StandbyMode>";
            result += "</PowerManagement>";
            return result;
        }

    }
}
