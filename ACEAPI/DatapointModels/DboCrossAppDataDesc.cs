using System;
using System.Collections.Generic;

namespace ACEAPI.DatapointModels
{
    public partial class DboCrossAppDataDesc
    {
        public short? InstitutionNumber { get; set; }
        public decimal? BranchNumber { get; set; }
        public short? FieldCode { get; set; }
        public string FromInternalValue { get; set; }
        public string ThruInternalValue { get; set; }
        public short? SystemCode { get; set; }
        public short? ExcludeFlag { get; set; }
        public string ShortName { get; set; }
        public string ExternalValue { get; set; }
        public DateTime? DateLastChanged { get; set; }
        public decimal? FromInternalValueNumeric { get; set; }
        public short? AccountType { get; set; }
    }
}
