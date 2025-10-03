using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class DigitalSyncSignal : SyncSignal
    {
        public readonly bool DigitalComposite;
        public readonly bool VerticalSyncPositive;
        public readonly bool HorizontalSyncPositive;

        public DigitalSyncSignal(byte data) : base(true, (data & 1 << 2) != 0)
        {
            DigitalComposite        = (data & 1 << 3) != 0;
            VerticalSyncPositive    = (data & 1 << 2) != 0;
            HorizontalSyncPositive  = (data & 1 << 1) != 0;
        }


        public override string ToString()
        {
            string result = $"<SyncSignal serrations=\"{Serrations}\" isDigital=\"true\">";
            result += $"<DigitalComposite>{DigitalComposite}</DigitalComposite>";
            result += $"<VerticalSyncPositive>{VerticalSyncPositive}</VerticalSyncPositive>";
            result += $"<HorizontalSyncPositive>{HorizontalSyncPositive}</HorizontalSyncPositive>";
            result += "</SyncSignal>";
            return result;
        }

    }
}
