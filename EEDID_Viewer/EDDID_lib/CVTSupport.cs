using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDID_Viewer.EDDID_lib
{
    class CVTSupport
    {
        public readonly byte Version;
        public readonly byte AdditionalPixelClockPrecision;
        public readonly double MaximumPixelClock;
        public readonly ushort MaximumActivePixels;
        public readonly List<AspectRatio> SupportedAspectRatios = new List<AspectRatio>();
        public readonly AspectRatio PreferredAspectRatio;
        public readonly bool StandardBlankingCVT;
        public readonly bool ReducedBlankingCVT;
        public readonly TypeDisplayScalingSupported DisplayScaling;
        public readonly byte PreferredVerticalRefreshRate;

        public static readonly AspectRatio[] SupportedAspectRatioTypes = new AspectRatio[]{
            new AspectRatio(4, 3),
            new AspectRatio(16, 9),
            new AspectRatio(16, 10),
            new AspectRatio(5, 4),
            new AspectRatio(15, 9),
        };


        public CVTSupport(byte[] data)
        {
            Version                         = data[11];
            AdditionalPixelClockPrecision   = (byte)(data[12] >> 2);
            MaximumPixelClock               = (data[9] * 10) - (AdditionalPixelClockPrecision * 0.25D);
            MaximumActivePixels             = (ushort)(8 * (data[13] + (256 * (data[12] & 0x03) ) ));

            for (byte i = 0; i < SupportedAspectRatioTypes.Length; i++)
            {
                if ( (data[14] & 1 << 7 - i) != 0)
                {
                    SupportedAspectRatios.Add(SupportedAspectRatioTypes[i]);
                }
            }

            PreferredAspectRatio = SupportedAspectRatioTypes[ data[15] >> 5 ];
            StandardBlankingCVT = (data[15] & 1 << 3) != 0;
            ReducedBlankingCVT = (data[15] & 1 << 4) != 0;
            DisplayScaling = new TypeDisplayScalingSupported(data[16]);
            PreferredVerticalRefreshRate = data[17];
        }



        public override string ToString()
        {
            string result = "<CVTSupport>";

            result += $"<Version>{Version}</Version>";
            result += $"<AdditionalPixelClockPrecision>{AdditionalPixelClockPrecision}</AdditionalPixelClockPrecision>";
            result += $"<MaximumPixelClock>{MaximumPixelClock}</MaximumPixelClock>";
            result += $"<MaximumActivePixels>{MaximumActivePixels}</MaximumActivePixels>";

            result += "<SupportedAspectRatios>";
            SupportedAspectRatios.ForEach(e => result += e.ToString());
            result += "</SupportedAspectRatios>";

            result += $"<PreferredAspectRatio>{PreferredAspectRatio.ToString()}</PreferredAspectRatio>";
            result += $"<StandardBlankingCVT>{StandardBlankingCVT}</StandardBlankingCVT>";
            result += $"<ReducedBlankingCVT>{ReducedBlankingCVT}</ReducedBlankingCVT>";
            result += DisplayScaling.ToString();
            result += $"<PreferredVerticalRefreshRate>{PreferredVerticalRefreshRate}</PreferredVerticalRefreshRate>";

            result += "</CVTSupport>";
            return result;
        }


    }
}
