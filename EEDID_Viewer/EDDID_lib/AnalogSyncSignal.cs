using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class AnalogSyncSignal : SyncSignal
    {
        public readonly bool BipolarAnalogComposite;
        public readonly bool SyncOnRGB;

        public AnalogSyncSignal(byte data) : base(false, (data & 1 << 2) != 0)
        {
            BipolarAnalogComposite  = (data & 1 << 4) != 0;
            SyncOnRGB               = (data & 1 << 1) != 0;
        }

        public override string ToString()
        {
            string result = $"<SyncSignal serrations=\"{Serrations}\" isDigital=\"false\">";
            result += $"<BipolarAnalogComposite>{BipolarAnalogComposite}</BipolarAnalogComposite>";
            result += $"<SyncOnRGB>{SyncOnRGB}</SyncOnRGB>";
            result += "</SyncSignal>";
            return result;
        }

    }
}
