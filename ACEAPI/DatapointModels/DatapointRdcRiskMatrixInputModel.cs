using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACEAPI.DatapointModels
{
    public class DatapointRdcRiskMatrixInputModel
    {
        public IEnumerable<decimal?> TaxIdNumber { get; set; }

        public decimal? RdcDailyLimit { get; set; }

        public IEnumerable<decimal?> Accounts { get; set; }

        public DatapointRdcRiskMatrixInputModel()
        {
            this.TaxIdNumber = Enumerable.Empty<decimal?>();
            this.Accounts = Enumerable.Empty<decimal?>();
        }
    }
}
