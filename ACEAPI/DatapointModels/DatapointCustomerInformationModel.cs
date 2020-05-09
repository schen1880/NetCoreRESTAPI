using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACEAPI.DatapointModels
{
    public class DatapointCustomerInformationModel
    {
        public decimal? NameId { get; set; }
        //public string NameId { get; set; }

        public string Name { get; set; }

        public decimal? TaxIdNumber { get; set; }
        //public string TaxIdNumber { get; set; }

        public string TaxIdDescription { get; set; }

        public DateTime? DateOpened { get; set; }
        //public string DateOpened { get; set; }

        public string? CustomerOfficer { get; set; }

        public decimal? NaicsCode { get; set; }
        //public string NaicsCode { get; set; }

        public string? NaicsDescription { get; set; }

        public DateTime? DateOfOrganization { get; set; }
        //public string DateOfOrganization { get; set; }

        public decimal YearsInBusiness { get; set; }

        public int BsaRiskScore2 { get; set;}
    }
}
