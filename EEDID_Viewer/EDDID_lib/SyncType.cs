using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class SyncType
    {
        public readonly bool SepareteSyncHorizontalVeritcal;
        public readonly bool CompositeSyncHorizontal;
        public readonly bool CompositeSyncOnGreen;


        public SyncType(byte data)
        {
            SepareteSyncHorizontalVeritcal  = (data & 1 << 3) != 0;
            CompositeSyncHorizontal         = (data & 1 << 2) != 0;
            CompositeSyncOnGreen            = (data & 1 << 1) != 0;
        }


        public override string ToString()
        {
            string result = "<SyncType>";
            result += $"<SepareteSyncHorizontalVeritcal>{SepareteSyncHorizontalVeritcal}</SepareteSyncHorizontalVeritcal>";
            result += $"<CompositeSyncHorizontal>{CompositeSyncHorizontal}</CompositeSyncHorizontal>";
            result += $"<CompositeSyncOnGreen>{CompositeSyncOnGreen}</CompositeSyncOnGreen>";
            result += "</SyncType>";
            return result;
        }

    }
}
