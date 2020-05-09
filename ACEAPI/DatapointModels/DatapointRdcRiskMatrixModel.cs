using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACEAPI.DatapointModels
{
    public class DatapointRdcRiskMatrixModel
    {
        //[EDW_PROD].[dbo].[customer].[Name_ID]
        public decimal NameId { get; set; }

        //[EDW_PROD].[dbo].[customer].[Name]
        public string Name { get; set; }

        //[EDW_PROD].[dbo].[customer].[Tax_ID_Number]
        public decimal TaxIdNumber { get; set; }

        //[EDW_PROD].[dbo].[customer].[Tax_ID_Number]
        public string TaxIdDescription { get; set; }

        //[EDW_PROD].[dbo].[customer].[Date_Opened]
        public DateTime DateOpened { get; set; }

        //[EDW_PROD].[dbo].[dda_account].[Resp_Code_Full_Description]
        public string CustomerOfficer { get; set; }

        //[EDW_PROD].[dbo].[customer].[NAICS_Code]
        public decimal NaicsCode { get; set; }

        //[EDW_PROD].[dbo].[customer].[NAICS_Description]
        public string NaicsDescription { get; set; }

        //[EDW_PROD].[dbo].[customer].[Date_of_Organization]
        public DateTime DateOfOrganization { get; set; }

        //MAX([EDW_PROD].[dbo].[dda_account].[Risk_Score2])
        public Int16 RiskRate { get; set; }

        //[EDW_PROD].[dbo].[dda_account].[DDA_Account]
        //public decimal DdaAccount { get; set; }

        //[EDW_PROD].[dbo].[dda_account_metrics].[90Day_Highest_Chargeback_Amount]
        //public decimal HighestChargebackAmount { get; set; }

        //[EDW_PROD].[dbo].[dda_account_metrics].[90Day_Total_Chargeback]
        //public decimal TotalChargeback { get; set; }

        //[EDW_PROD].[dbo].[dda_account_metrics].[90Day_Chargeback_Items]
        //Returned Items?
        public int ChargebackItems { get; set; }
        
        //[EDW_PROD].[dbo].[dda_account_metrics].[90Day_Highest_Settlement_Amount]
        //public decimal HighestSettlementAmount { get; set; }

        //[EDW_PROD].[dbo].[dda_account_metrics].[Rolling_3_Mo_NSF_Items]
        //NSF Items
        public int NsfItems { get; set; }

        //[EDW_PROD].[dbo].[dda_account_metrics].[RDC_Items]
        //Deposited Items?
        public int RdcItems { get; set; }

        //Tenure as Bank Customer (Days)
        public int DaysWithBank { get; set; }

        //Longevity in business (Years)
        public int DaysInBusiness { get; set; }

        //Total possible daily settlement
        public decimal RdcDailyLimit { get; set; }

        //Total possible daily settlement account
        public int RdcDailyLimitRiskContrib { get; set; }

        //Number of returned items?
        public int ChargebackRiskContrib { get; set; }

        //Number of deposited items (RDC item count)?
        public int DepositCountRiskContrib { get; set; }

        //Number of NSF Items
        public int NsfItemRiskContrib { get; set; }

        //Tenure as Bank Customer in Days
        public int BankTenureRiskContrib { get; set; }

        //Longevity of Business in Years
        public int YearsInBusinessRiskContrib { get; set; }

        //CIP Risk Rating (Prior to RDC)
        public int CipRiskRateRiskContrib { get; set; }

        public int RiskMatrixTotal { get; set; }

        public decimal WeightedRiskFactor { get; set; }

        public string RiskRating { get; set; }
    }
}
