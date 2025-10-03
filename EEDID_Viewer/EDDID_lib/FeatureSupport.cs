using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class FeatureSupport
    {
        public readonly PowerManagement PowerManagement;
        public readonly FeatureSupportFlags FeatureSupportFlags;
        public readonly byte ColorTypeOrColorEncodingFormats;
        public readonly bool SupportGFTorCVT; 

        public readonly bool IsColorEncoding;

        public FeatureSupport( byte data, bool isColorEncoding )
        {
            ColorTypeOrColorEncodingFormats = (byte)((data >> 3) & 0x03);
            PowerManagement                 = new PowerManagement(data);
            FeatureSupportFlags             = new FeatureSupportFlags(data);
            SupportGFTorCVT                 = FeatureSupportFlags.ContinuousFrequency; // then the display will accept GTF or CVT
            IsColorEncoding                 = isColorEncoding;
        }


        public override string ToString()
        {
            string result = "<FeatureSupport>";
            result += PowerManagement.ToString();
            result += FeatureSupportFlags.ToString();
            result += $"<ColorTypeOrColorEncodingFormats>{ColorTypeOrColorEncodingFormats}</ColorTypeOrColorEncodingFormats>";
            result += $"<SupportGFTorCVT>{SupportGFTorCVT}</SupportGFTorCVT>";
            result += $"<IsColorEncoding>{IsColorEncoding}</IsColorEncoding>";
            result += "</FeatureSupport>";
            return result;
        }


    }
}
