using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration.Attributes;
using CsvHelper;

namespace EEDID_Viewer.EDDID_lib
{
    class ManufacuterPNP
    {
        [Name("Company")]
        public string Company { get; set; }

        [Name("PNP ID")]
        public string PNPID { get; set; }

        [Name("Approved On Date")]
        public DateTime ApprovedOnDate { get; set; }


        public override string ToString()
        {
            string result = "<ManufacuterPNP>";
            result += $"<Company>{Company}</Company>";
            result += $"<PNPID>{PNPID}</PNPID>"; 
            result += $"<ApprovedOnDate>{ApprovedOnDate.ToShortDateString()}</ApprovedOnDate>";  
            result += "</ManufacuterPNP>";
            return result;
        }

    }
}
