using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using EEDID_Viewer.EDDID_lib;

namespace EEDID_Viewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            try
            {

                string[] sampleFiles = new string[]{
                    "EDDID_lib/Samples/VESA_EDID_EXAMPLE_1.bin",
                    "EDDID_lib/Samples/VESA_EDID_EXAMPLE_2.bin",
                    "EDDID_lib/Samples/VESA_EDID_EXAMPLE_3.bin",
                    "EDDID_lib/Samples/EDID_TEST_1.bin"
                };

                byte[] buffer       = File.ReadAllBytes($"../../{sampleFiles[3]}");
                EEDID eEDID         = new EEDID(buffer);
                string dumpString   = Dump(buffer);

                Console.WriteLine("XML START");
                Console.WriteLine( eEDID.ToString() );
                Console.WriteLine("XML END");

                Console.WriteLine("DUMP START");
                Console.WriteLine(dumpString);
                Console.WriteLine("DUMP END");


                ManufacturerName.Text = "Manufacturer Name: " + eEDID.ManufactureName;
                ProductCode.Text = "Product Code: " + eEDID.ProductCode.ToString();
                WeekManufacture.Text = "Week Manufacture: " + eEDID.WeekManufacture.ToString();
                Year.Text = "Year: " + eEDID.Year.ToString();
                IsModelYear.Text = "IsModelYear: " + (eEDID.IsModelYear ? "yes" : "no");
                Version.Text = "Version: " + eEDID.GetVersionRevision();
                Gamma.Text = "Gamma: " + eEDID.Gamma.ToString();
                ExtensionBlockCount.Text = "Extension Block Count: " + eEDID.ExtensionBlockCount.ToString();
                Checksum.Text = "Checksum: " + eEDID.Checksum.ToString("x2") + "h";

                DumpData.Text = dumpString;


                eEDID.EstablishedTimings.ForEach(e => {
                    string[] data = {
                        e.Width.ToString(),
                        e.Height.ToString(),
                        e.Frequency.ToString()
                    };
                    EstablishedTimingTable.Rows.Add(data);
                }); 

            } catch (EEDIDException e)
            {

            } catch (IOException e)
            {

            }

        }




        public string Dump(byte[] buffer)
        {
            string output = "";

            string str = "Offset  : ";
            output = str;


            int bytesPerRow = 16;
            // Header
            for (int i = 0; i < bytesPerRow; i++)
            {
                str += i.ToString("x2") + ' ';
                output += i.ToString("x2") + ' ';
            } 
            //Console.WriteLine(str);
            str = "";
            output += "\n";


            for (int i = 0; i < buffer.Length; i++)
            {
                int offset = i / bytesPerRow * bytesPerRow;

                // Offset Adddress
                if (i % bytesPerRow == 0)
                {
                    str += offset.ToString("x8") + ": "; 
                }

                // Data
                str += buffer[i].ToString("x2") + " "; 

                // Ascii
                if ((i + 1) % bytesPerRow == 0 || i == buffer.Length - 1)
                {
                    str += string.Concat(Enumerable.Repeat("-- ", bytesPerRow - (i % bytesPerRow) - 1));
                    str += " |  ";


                    for (int j = 0; j < bytesPerRow; j++)
                    {
                        byte code = buffer[offset + j];
                        str += (j <= i % bytesPerRow && (code >= 32 && code <= 255)) ? Char.ToString(Convert.ToChar(code)) : ".";
                    }
                    output += str + "\n";
                    //Console.WriteLine(str);
                    str = "";
                }

            }


            return output;

        }
    }
}
