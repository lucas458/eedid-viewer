using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
 
using System.Globalization;
  

namespace EEDID_Viewer.EDDID_lib
{
    class EEDID
    {
        public readonly string ManufactureName;
        public readonly ushort ProductCode;
        public readonly uint SerialNumber;
        public readonly byte WeekManufacture;
        public readonly ushort Year;
        public readonly bool IsModelYear;
        public readonly byte Version;
        public readonly byte Revision;
        public readonly VideoInput VideoInput;
        public readonly ScreenAxis ScreenAxis;
        public readonly double Gamma;
        public readonly FeatureSupport FeatureSupport;
        public readonly ColorCharacteristics ColorCharacteristics;
        public readonly List<EstablishedTiming> EstablishedTimings = new List<EstablishedTiming>();
        public readonly List<StandardTiming> StandardTimings = new List<StandardTiming>();
        public readonly DataBlock[] DataBlock = new DataBlock[4];
        public readonly byte ExtensionBlockCount;
        public readonly byte Checksum;

        public readonly ManufacuterPNP manufacuterPNP;


        private readonly byte[] _buffer;
        private readonly byte[] _validHeader = new byte[8] { 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00 };

        public static readonly EstablishedTiming[] EstablishedTimingsTypes = new EstablishedTiming[]
        {
            // Established Timing I
            new EstablishedTiming(720, 400, 70),
            new EstablishedTiming(720, 400, 88),
            new EstablishedTiming(640, 480, 60),
            new EstablishedTiming(640, 480, 67),
            new EstablishedTiming(640, 480, 72),
            new EstablishedTiming(640, 480, 75),
            new EstablishedTiming(800, 600, 56),
            new EstablishedTiming(800, 600, 60),
            // Established Timing II
            new EstablishedTiming(800, 600, 72),
            new EstablishedTiming(800, 600, 75),
            new EstablishedTiming(832, 624, 75),
            new EstablishedTiming(1024, 768, 87),
            new EstablishedTiming(1024, 768, 60),
            new EstablishedTiming(1024, 768, 70),
            new EstablishedTiming(1024, 768, 75),
            new EstablishedTiming(1280, 1024, 75),
            // Manufacturer's Timings
            new EstablishedTiming(1152, 870, 75),
        };


        public static ushort ToUint16(byte msb, byte lsb)
        {
            return (ushort)((msb << 8) | lsb);
        }


        private void SetDatablockByData( byte[] data, byte index )
        {

            if ( ToUint16(data[0], data[1]) == 0x0000 )
            {

                switch (data[3])
                {
                    case 0xFF: // Display Product Serial Number
                        DataBlock[index] = new ProductSerialDescriptor(data);
                        break;
                    case 0xFE: // Alphanumeric Data String (ASCII)
                        DataBlock[index] = new DataStringDescriptor(data);
                        break;
                    case 0xFD: // Display Range Limits: Includes optional timing information - default parameters, GTF Secondary Curve or CVT Descriptor
                        DataBlock[index] = new RangeLimitsDescriptor(data, FeatureSupport.SupportGFTorCVT);
                        break;
                    case 0xFC: // Display Product Name
                        DataBlock[index] = new DisplayNameDescriptor(data);
                        break;
                    case 0xFB: // Color Point Data
                        DataBlock[index] = new ColorPointDescriptor(data);
                        break;
                    case 0xFA: // Standard Timing Identifications
                        DataBlock[index] = new StandardTimingDescriptor(data);
                        break;
                    case 0xF9: // Display Color Management (DCM) Data
                        DataBlock[index] = new ColorManagementDescriptor(data);
                        break;
                    case 0xF8: // CVT 3 Byte Timing Codes
                        DataBlock[index] = new CVT3ByteCodeDescriptor(data);
                        break;
                    case 0xF7: // Established Timings III
                        DataBlock[index] = new EstablishedTimingsDescriptor(data);
                        break;
                    
                }

                return;
            }
            

            DataBlock[index] = new DetailedTimingDescriptor(data);
            
        }
        


        private string GetManufacturerName( ushort value )
        {
            char[] output = new char[3];
            output[0] = (char)( 64 + ((value >> 10) & 0x1F) );
            output[1] = (char)( 64 + ((value >>  5) & 0x1F) );
            output[2] = (char)( 64 + ((value >>  0) & 0x1F) );
            return new string(output);
        }
        

        public EEDID( byte[] buffer )
        {
            _buffer = buffer;

            if ( _buffer.Length < 128 )
            {
                throw new EEDIDException("Buffer Is Less Than 128");
            }

            /*if (  _buffer.Sum(e => e) % 256 != 0)
            {
                throw new EEDIDException("Invalid Checksum");
            }*/

            for (byte i = 0; i < _validHeader.Length; i++)
            {
                if ( _buffer[i] != _validHeader[i] )
                {
                    throw new EEDIDException("Invalid Header");
                }
            }

            ManufactureName         = GetManufacturerName( ToUint16(_buffer[0x08], _buffer[0x09]) );
            ProductCode             = ToUint16(_buffer[0x0B], _buffer[0x0A]);
            SerialNumber            = (uint)( ToUint16(_buffer[0x0F], _buffer[0x0E]) << 16 | ToUint16(_buffer[0x0D], _buffer[0x0C])  );
            WeekManufacture         = _buffer[0x10];
            Year                    = (ushort)(_buffer[0x11] + 1990);
            IsModelYear             = _buffer[0x10] == 0xFF;
            Version                 = _buffer[0x12];
            Revision                = _buffer[0x13];

            
            // Video Input
            if ( (_buffer[0x14] & 1 << 7) == 0 )
            {
                VideoInput = new VideoInputAnalog(_buffer[0x14]);
            }
            else
            {
                VideoInput = new VideoInputDigital(_buffer[0x14]);
            }



            ScreenAxis              = new ScreenAxis(_buffer[0x15], _buffer[0x16]); // need?




            Gamma                   =  (_buffer[0x17] + 100) / 100D;
            FeatureSupport          = new FeatureSupport(_buffer[0x18], (_buffer[0x14] & 1 << 7) != 0);
            ColorCharacteristics    = new ColorCharacteristics( _buffer.Skip(0x19).Take(10).ToArray() );




            
            // Established Timings I & II   AND   Manufacturer's Timings
            for (byte i = 0; i < EstablishedTimingsTypes.Length; i++)
            {
                byte currentBit = (byte)(7 - (i % 8));
                byte currentBlock = (byte)(i / 8);
                byte currentData = _buffer[0x23 + currentBlock];

                if ( (currentData & 1 << currentBit) != 0 )
                {
                    EstablishedTimings.Add( EstablishedTimingsTypes[i] );
                }

            }


            // Standard Timings: 1 to 8
            for (byte i = 0; i < 8; i++)
            {
                ushort value = ToUint16(_buffer[0x26 + (i * 2)], _buffer[0x26 + (i * 2 + 1)]);
                if ( value != 0x0101)
                {
                    StandardTimings.Add(new StandardTiming(value));
                }
            }


            // 18 Byte Descriptors: 4 items [DataBlock]
            for (byte i = 0; i < DataBlock.Length; i++)
            {
                // offset: (i * 18) + 0x36
                byte[] dataBlockBuffer = _buffer.Skip(i*18 + 0x36).Take(18).ToArray();
                SetDatablockByData(dataBlockBuffer, i);
            }

            ExtensionBlockCount = _buffer[0x7E];
            Checksum = _buffer[0x7F];



            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(@"../../EDDID_lib/PNPRegistry.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var item = csv.GetRecords<ManufacuterPNP>(); 
                manufacuterPNP = item.First(e => e.PNPID.Equals(ManufactureName));
            }



        }





        public string GetVersionRevision()
        {
            return $"{Version}.{Revision}";
        }




        public override string ToString()
        {
            string result = "<EEDID>";
            result += $"<ManufactureName>{ManufactureName}</ManufactureName>";
            result += $"<ProductCode>{ProductCode}</ProductCode>";
            result += $"<SerialNumber>{SerialNumber}</SerialNumber>";
            result += $"<WeekManufacture>{WeekManufacture}</WeekManufacture>";
            result += $"<Year>{Year}</Year>";
            result += $"<IsModelYear>{IsModelYear}</IsModelYear>";
            result += $"<Version>{Version}</Version>";
            result += $"<Revision>{Revision}</Revision>";


            if (VideoInput.IsDigital)
            {
                result += ((VideoInputDigital)VideoInput).ToString();
            }
            else
            {
                result += ((VideoInputAnalog)VideoInput).ToString();
            }


            result += ScreenAxis.ToString();
            result += $"<Gamma>{Gamma}</Gamma>";
            result += FeatureSupport.ToString();
            result += ColorCharacteristics.ToString();

            // Established Timings
            result += "<EstablishedTimings>";
            EstablishedTimings.ForEach(e => result += e.ToString());
            result += "</EstablishedTimings>";
            // Standard Timings
            result += "<StandardTimings>";
            StandardTimings.ForEach(e => result += e.ToString());
            result += "</StandardTimings>";



            // Data Block 
            for (byte i = 0; i < DataBlock.Length; i++)
            {

                DataBlock block = DataBlock[i];

                // descriptor
                if ( block.IsDescriptor )
                {
                    byte tag = ((TaggedDescriptor)block).Tag;
                    result += $"<DataBlock isDescriptor=\"true\" tag=\"{tag}\">";
                    result += block.ToString();
                    result += "</DataBlock>";
                    continue;
                }

                // detailed timings 
                result += $"<DataBlock isDescriptor=\"false\">";
                result += ((DetailedTimingDescriptor)block).ToString();
                result += "</DataBlock>";
            }



            result += $"<ExtensionBlockCount>{ExtensionBlockCount}</ExtensionBlockCount>";
            result += $"<Checksum>{Checksum}</Checksum>";

            result += "</EEDID>";
            return result;
        }



    }
}
