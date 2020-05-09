using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACEAPI.Data;
using ACEAPI.DatapointModels;
using Microsoft.AspNetCore.Authorization;
using Deedle;

using Microsoft.Data.Analysis;
using System.Data;
//ing Deedle;

namespace ACEAPI.DatapointControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DatapointController : ControllerBase
    {
        private readonly EDW_PRODContext _context;

        public DatapointController(EDW_PRODContext context)
        {
            _context = context;
        }

        //// GET: api/CustomerDataModels
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CustomerDataModel>>> GetCustomerDataModel()
        //{
        //    return await _context.CustomerDataModel.ToListAsync();
        //}

        // GET: api/CustomerDataModels/5
        [HttpGet("CustomerInformation/{taxidnumber}")]
        public async Task<ActionResult<IEnumerable<DatapointCustomerInformationModel>>> GetDatapointCustomerInformationModel(decimal? taxidnumber)
        //public ActionResult<CustomerDataModel> GetCustomerDataModel(decimal? id)
        {
            string query = $@"
                SELECT 
                  DISTINCT customer.[Name_ID], 
                  TRIM(customer.[Name]) AS 'Name', 
                  customer.[Tax_ID_Number], 
                  TRIM(customer.[Tax_ID_Description]) AS 'Tax_ID_Description', 
                  customer.[Date_Opened], 
                  TRIM(
                    dda_account.[Resp_Code_Full_Description]
                  ) AS 'Customer_Officer', 
                  customer.[NAICS_Code], 
                  TRIM(customer.[NAICS_Description]) AS 'NAICS_Description', 
                  bsa_risk.[RiskRate], 
                  customer.[Date_of_Organization], 
                  customer.[Years_In_Business] 
                FROM 
                  [dbo].[customer] AS customer 
                  JOIN [dbo].[dda_account] AS dda_account ON customer.[Name_ID] = dda_account.[Name_ID] 
                  JOIN [dbo].[customer_taxid_map] TaxNameIdMap ON TaxNameIdMap.[Name_ID] = customer.[Name_ID] 
                  AND TaxNameIdMap.[Tax_ID_Number] = {taxidnumber} 
                  JOIN (
                    SELECT 
                      DISTINCT dda_account.[Name_ID], 
                      MAX(dda_account.[Risk_Score2]) AS 'RiskRate' 
                    FROM 
                      [dbo].[dda_account] AS dda_account 
                    GROUP BY 
                      dda_account.[Name_ID]
                  ) AS bsa_risk ON customer.[Name_ID] = bsa_risk.[Name_ID] 
                WHERE 
                  TaxNameIdMap.[Tax_ID_Number] = {taxidnumber}
            ";

            List<DatapointCustomerInformationModel> CustomerList = new List<DatapointCustomerInformationModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _context.Database.OpenConnection();
                using (var result = await command.ExecuteReaderAsync())
                {
                    while (result.Read())
                    {
                        DatapointCustomerInformationModel record = new DatapointCustomerInformationModel();

                        decimal tempNameId;
                        if (decimal.TryParse(result["Name_ID"].ToString(), out tempNameId))
                        {
                            record.NameId = tempNameId;
                        }

                        string tempName = result["Name"].ToString();
                        if (tempName != "")
                        {
                            record.Name = tempName;
                        }

                        decimal tempTaxIdNumber;
                        if (decimal.TryParse(result["Tax_ID_Number"].ToString(), out tempTaxIdNumber))
                        {
                            record.TaxIdNumber = tempTaxIdNumber;
                        }

                        string tempTaxIdDescription = result["Tax_ID_Description"].ToString();
                        if (tempTaxIdDescription != "")
                        {
                            record.TaxIdDescription = tempTaxIdDescription;
                        }

                        DateTime tempDateOpened;
                        if (DateTime.TryParse(result["Date_Opened"].ToString(), out tempDateOpened))
                        {
                            record.DateOpened = tempDateOpened;
                        }

                        string tempCustomerOfficer = result["Customer_Officer"].ToString();
                        if (tempCustomerOfficer != "")
                        {
                            record.CustomerOfficer = tempCustomerOfficer;
                        }

                        decimal tempNaicsCode;
                        if (decimal.TryParse(result["NAICS_Code"].ToString(), out tempNaicsCode))
                        {
                            record.NaicsCode = tempNaicsCode;
                        }

                        string tempNaicsDescription = result["NAICS_Description"].ToString();
                        if (tempNaicsDescription != "")
                        {
                            record.NaicsDescription = tempNaicsDescription;
                        }

                        DateTime tempDateOfOrganization;
                        if (DateTime.TryParse(result["Date_of_Organization"].ToString(), out tempDateOfOrganization))
                        {
                            record.DateOfOrganization = tempDateOfOrganization;
                        }

                        int tempBsaRiskScore2;
                        if (Int32.TryParse(result["RiskRate"].ToString(), out tempBsaRiskScore2))
                        {
                            record.BsaRiskScore2 = tempBsaRiskScore2;
                        }

                        int tempYearsInBusiness;
                        if (Int32.TryParse(result["Years_In_Business"].ToString(), out tempYearsInBusiness))
                        {
                            record.YearsInBusiness = tempYearsInBusiness;
                        }

                        CustomerList.Add(record);
                    }
                }
            }

            if (CustomerList == null)
            {
                return NotFound();
            }

            return CustomerList;
        }

        //[HttpPut("CustomerInformation")]
        //public async Task<ActionResult<IEnumerable<DatapointDdaRiskRateModel>>> GetDdaRiskRateModel(IEnumerable<Int16?> accounts)
        //{
        //    string accountsFilter = string.Join(",", accounts);

        //    string query = $@"
        //        SELECT 
        //          DISTINCT np.[Name_ID], 
        //          dda.[DDA_Account], 
        //          MAX(ddac.[Risk_Score2]) AS 'RiskRate' 
        //        FROM 
        //          [PRIME002].[dbo_DDA_Acct] AS dda 
        //          JOIN [PRIME002].[dbo_Name_To_All_Acct] np ON dda.[DDA_Account] = np.[Account_Number] 
        //          JOIN [PRIME002].[dbo_DDA_Codes] ddac ON dda.[DDA_Account] = ddac.[DDA_Account] 
        //        WHERE dda.[DDA_Account] in ({accountsFilter})
        //        GROUP BY 
        //          np.[Name_ID], 
        //          dda.[DDA_Account]
        //    ";

        //    List<DatapointDdaRiskRateModel> DdaRiskList = new List<DatapointDdaRiskRateModel>();

        //    using (var command = _context.Database.GetDbConnection().CreateCommand())
        //    {
        //        command.CommandText = query;
        //        _context.Database.OpenConnection();
        //        using (var result = await command.ExecuteReaderAsync())
        //        {
        //            while (result.Read())
        //            {
        //                DatapointDdaRiskRateModel record = new DatapointDdaRiskRateModel();

        //                decimal tempNameId;
        //                if (decimal.TryParse(result["Name_ID"].ToString(), out tempNameId))
        //                {
        //                    record.NameId = tempNameId;
        //                }

        //                decimal tempDdaAccount;
        //                if (decimal.TryParse(result["DDA_Account"].ToString(), out tempDdaAccount))
        //                {
        //                    record.DdaAccount = tempDdaAccount;
        //                }

        //                Int16 tempRiskRate;
        //                if (Int16.TryParse(result["RiskRate"].ToString(), out tempRiskRate))
        //                {
        //                    record.RiskRate = tempRiskRate;
        //                }

        //                DdaRiskList.Add(record);
        //            }
        //        }
        //    }

        //    if (DdaRiskList == null)
        //    {
        //        return NotFound();
        //    }

        //    return DdaRiskList;
        //}

        [HttpPut("RdcRiskMatrix")]
        public async Task<ActionResult<DatapointRdcRiskMatrixModel>> GetRdcRiskMatrix(DatapointRdcRiskMatrixInputModel input)
        {
            //DatapointRdcRiskMatrixReturnModel riskmatrix = new DatapointRdcRiskMatrixReturnModel();
            //List<DatapointRdcRiskMatrixModel> riskmatrix = new List<DatapointRdcRiskMatrixModel>();
            DatapointRdcRiskMatrixModel RiskMatrix = new DatapointRdcRiskMatrixModel();

            //string query1 = $@"
            //        SELECT 
            //          cif.[Name_ID], 
            //          cif.[Name], 
            //          cif.[Tax_ID_Number], 
            //          cif.[Tax_ID_Description], 
            //          cif.[Date_Opened], 
            //          officer.[External_Value] AS 'Customer_Officer', 
            //          cif.[NAICS_Code], 
            //          naics.[NAICS_Description], 
            //          flex.[Flex135] AS 'Date_of_Organization' 
            //        FROM 
            //          [PRIME002].[dbo_CIF_Name] AS cif 
            //          LEFT JOIN [PRIME002].[dbo_Cross_App_Data_Desc] AS officer ON cif.[Resp_Code] = officer.[From_Internal_Value] 
            //          AND officer.[Field_Code] = 1 
            //          AND officer.[Account_Type] = 1 
            //          LEFT JOIN [PRIME002].[dbo_NAICS_Description] AS naics ON cif.[NAICS_Code] = naics.[NAICS_Code] 
            //          LEFT JOIN [PRIME002].[dbo_Name_Flex_Data_101_To_200] AS flex ON cif.[Name_ID] = flex.[Account_Number]
            //        WHERE 
            //          cif.[Tax_ID_Number] = {input.TaxIdNumber}
            //";

            string DdaAccountsFilter = string.Join(",", input.Accounts);
            string TaxIdsFilter = string.Join(",", input.TaxIdNumber);
            RiskMatrix.RdcDailyLimit = input.RdcDailyLimit ??  0;

            //string query2 = $@"
            //    SELECT 
            //      DISTINCT np.[Name_ID], 
            //      dda.[DDA_Account], 
            //      MAX(ddac.[Risk_Score2]) AS 'RiskRate' 
            //    FROM 
            //      [PRIME002].[dbo_DDA_Acct] AS dda 
            //      JOIN [PRIME002].[dbo_Name_To_All_Acct] np ON dda.[DDA_Account] = np.[Account_Number] 
            //      JOIN [PRIME002].[dbo_DDA_Codes] ddac ON dda.[DDA_Account] = ddac.[DDA_Account] 
            //    WHERE dda.[DDA_Account] in ({accountsFilter})
            //    GROUP BY 
            //      np.[Name_ID], 
            //      dda.[DDA_Account]
            //";

            //string query3 = $@"
            //    SELECT 
            //      CustomerData.*, 
            //      RiskRateData.[DDA_Account], 
            //      RiskRateData.[RiskRate] 
            //    FROM 
            //      ({query1}) AS CustomerData 
            //      JOIN ({query2}) AS RiskRateData ON CustomerData.[Name_ID] = RiskRateData.[Name_ID]
            //";

            //string query = $@"
            //    SELECT 
            //      DISTINCT customer.[Name_ID], 
            //      TRIM(customer.[Name]) AS 'Name', 
            //      customer.[Tax_ID_Number], 
            //      TRIM(customer.[Tax_ID_Description]) AS 'Tax_ID_Description', 
            //      customer.[Date_Opened], 
            //      TRIM(
            //        dda_account.[Resp_Code_Full_Description]
            //      ) AS 'Customer_Officer', 
            //      customer.[NAICS_Code], 
            //      TRIM(customer.[NAICS_Description]) AS 'NAICS_Description', 
            //      bsa_risk.[RiskRate], 
            //      customer.[Date_of_Organization], 
            //      dda_account_metrics.[90Day_Highest_Chargeback_Amount], 
            //      dda_account_metrics.[90Day_Total_Chargeback], 
            //      dda_account_metrics.[90Day_Chargeback_Items], 
            //      dda_account_metrics.[90Day_Highest_Settlement_Amount], 
            //      dda_account_metrics.[Rolling_3_Mo_NSF_Items], 
            //      dda_account_metrics.[RDC_Items] 
            //    FROM 
            //      [dbo].[customer] AS customer 
            //      LEFT JOIN [dbo].[dda_account] AS dda_account ON customer.[Name_ID] = dda_account.[Name_ID] 
            //      LEFT JOIN [dbo].[dda_account_metrics] dda_account_metrics ON dda_account.[DDA_Account] = dda_account_metrics.[DDA_Account] 
            //      LEFT JOIN (
            //        SELECT 
            //          DISTINCT dda_account.[Name_ID], 
            //          dda_account.[DDA_Account], 
            //          MAX(dda_account.[Risk_Score2]) AS 'RiskRate' 
            //        FROM 
            //          [dbo].[dda_account] AS dda_account 
            //        WHERE 
            //          dda_account.[DDA_Account] in ({DdaAccountsFilter}) 
            //        GROUP BY 
            //          dda_account.[Name_ID], 
            //          dda_account.[DDA_Account]
            //      ) bsa_risk ON customer.[Name_ID] = bsa_risk.[Name_ID] 
            //    WHERE 
            //      customer.[Name_ID] IN (
            //        SELECT 
            //          TaxNameIdMap.[Name_ID] 
            //        FROM 
            //          [dbo].[customer_taxid_map] AS TaxNameIdMap 
            //        WHERE 
            //          TaxNameIdMap.[Tax_ID_Number] = {input.TaxIdNumber}
            //      )
            //";

            string dda_accounts_query = $@"
                SELECT 
                  MAX(bsa_risk.[Max BSA CIP Risk Score2]) as 'Max BSA CIP Risk Score2', 
                  SUM(
                    dda_metrics.[90Day_Chargeback_Items]
                  ) AS 'Sum Chargeback Items', 
                  SUM(
                    dda_metrics.[Rolling_3_Mo_NSF_Items]
                  ) AS 'Sum NSF Items', 
                  SUM(dda_metrics.[RDC_Items]) AS 'Sum RDC Items' 
                FROM 
                  (
                    SELECT 
                      dda.[DDA_Account], 
                      MAX(dda.[Risk_Score2]) AS 'Max BSA CIP Risk Score2' 
                    FROM 
                      [dbo].[dda_account] dda 
                    WHERE 
                      dda.[DDA_Account] IN ({DdaAccountsFilter}) 
                    GROUP BY 
                      dda.[DDA_Account]
                  ) AS bsa_risk 
                  JOIN [dbo].[dda_account_metrics] AS dda_metrics ON bsa_risk.[DDA_Account] = dda_metrics.[DDA_Account] 
            ";

            string taxids_query = $@"
                SELECT 
                  MIN(cust.[Date_of_Organization]) as 'Oldest Date of Organization', 
                  MAX(cust.[Years_In_Business]) as 'Max Years in Businesss', 
                  MIN(cust.[Date_Opened]) as 'Oldest Date Opened', 
                  MAX(cust.[Days_with_Bank]) as 'Max Days with Bank' 
                FROM 
                  [dbo].[customer_taxid_map] cust_map 
                  JOIN [dbo].[customer] cust ON cust.[Name_ID] = cust_map.[Name_ID] 
                WHERE 
                  cust_map.[Tax_ID_Number] IN ({TaxIdsFilter}) 
            ";

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = dda_accounts_query;
                _context.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (result.Read())
                    {
                        //BSA CIP Risk Score2

                        Int16 tempRiskRate;
                        if (Int16.TryParse(result["Max BSA CIP Risk Score2"].ToString(), out tempRiskRate))
                        {
                            RiskMatrix.RiskRate = tempRiskRate;
                        }

                        //dda account metrics

                        int tempChargebackItems;
                        if (int.TryParse(result["Sum Chargeback Items"].ToString(), out tempChargebackItems))
                        {
                            RiskMatrix.ChargebackItems = tempChargebackItems;
                        }

                        int tempNsfItems;
                        if (int.TryParse(result["Sum NSF Items"].ToString(), out tempNsfItems))
                        {
                            RiskMatrix.NsfItems = tempNsfItems;
                        }

                        int tempRdcItems;
                        if (int.TryParse(result["Sum RDC Items"].ToString(), out tempRdcItems))
                        {
                            RiskMatrix.RdcItems = tempRdcItems;
                        }
                    }
                }
            }

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = taxids_query;
                _context.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (result.Read())
                    {
                        DateTime today = DateTime.Now;

                        //Date of Organization
                        DateTime tempDateOfOrganization;
                        if (DateTime.TryParse(result["Oldest Date of Organization"].ToString(), out tempDateOfOrganization))
                        {
                            RiskMatrix.DateOpened = tempDateOfOrganization;
                        }

                        //Date Opened
                        DateTime tempDateOpened;
                        if (DateTime.TryParse(result["Oldest Date Opened"].ToString(), out tempDateOpened))
                        {
                            RiskMatrix.DateOpened = tempDateOpened;
                        }

                        //YearsInBusiness
                        int tempYearsInBusiness;
                        if (Int32.TryParse(result["Max Years in Businesss"].ToString(), out tempYearsInBusiness))
                        {
                            RiskMatrix.DaysInBusiness = tempYearsInBusiness * 365;
                        }


                        //Calculate Years In Business and Days With Bank
                        RiskMatrix.DaysWithBank = (int)(today - RiskMatrix.DateOpened).TotalDays;
                        //RiskMatrix.DaysInBusiness = (int)(today - RiskMatrix.DateOfOrganization).TotalDays;
                    }
                }
            }

            //using (var command = _context.Database.GetDbConnection().CreateCommand())
            //{
            //    command.CommandText = query;
            //    _context.Database.OpenConnection();
            //    using (var result = await command.ExecuteReaderAsync())
            //    {
            //        DateTime today = DateTime.Now;

            //        while (result.Read())
            //        {
            //            DatapointRdcRiskMatrixModel record = new DatapointRdcRiskMatrixModel();

            //            decimal tempNameId;
            //            if (decimal.TryParse(result["Name_ID"].ToString(), out tempNameId))
            //            {
            //                record.NameId = tempNameId;
            //            }

            //            string tempName = result["Name"].ToString();
            //            if (tempName != "")
            //            {
            //                record.Name = tempName;
            //            }

            //            decimal tempTaxIdNumber;
            //            if (decimal.TryParse(result["Tax_ID_Number"].ToString(), out tempTaxIdNumber))
            //            {
            //                record.TaxIdNumber = tempTaxIdNumber;
            //            }

            //            string tempTaxIdDescription = result["Tax_ID_Description"].ToString();
            //            if (tempTaxIdDescription != "")
            //            {
            //                record.TaxIdDescription = tempTaxIdDescription;
            //            }

            //            DateTime tempDateOpened;
            //            if (DateTime.TryParse(result["Date_Opened"].ToString(), out tempDateOpened))
            //            {
            //                record.DateOpened = tempDateOpened;
            //            }

            //            string tempCustomerOfficer = result["Customer_Officer"].ToString();
            //            if (tempCustomerOfficer != "")
            //            {
            //                record.CustomerOfficer = tempCustomerOfficer;
            //            }

            //            decimal tempNaicsCode;
            //            if (decimal.TryParse(result["NAICS_Code"].ToString(), out tempNaicsCode))
            //            {
            //                record.NaicsCode = tempNaicsCode;
            //            }

            //            string tempNaicsDescription = result["NAICS_Description"].ToString();
            //            if (tempNaicsDescription != "")
            //            {
            //                record.NaicsDescription = tempNaicsDescription;
            //            }

            //            DateTime tempDateOfOrganization;
            //            if (DateTime.TryParse(result["Date_of_Organization"].ToString(), out tempDateOfOrganization))
            //            {
            //                record.DateOpened = tempDateOfOrganization;
            //            }

            //            //decimal tempDdaAccount;
            //            //if (decimal.TryParse(result["DDA_Account"].ToString(), out tempDdaAccount))
            //            //{
            //            //    record.DdaAccount = tempDdaAccount;
            //            //}

            //            Int16 tempRiskRate;
            //            if (Int16.TryParse(result["RiskRate"].ToString(), out tempRiskRate))
            //            {
            //                record.RiskRate = tempRiskRate;
            //            }


            //            //account metrics

            //            int tempChargebackItems;
            //            if (int.TryParse(result["90Day_Chargeback_Items"].ToString(), out tempChargebackItems))
            //            {
            //                record.ChargebackItems = tempChargebackItems;
            //            }

            //            int tempNsfItems;
            //            if (int.TryParse(result["Rolling_3_Mo_NSF_Items"].ToString(), out tempNsfItems))
            //            {
            //                record.NsfItems = tempNsfItems;
            //            }

            //            int tempRdcItems;
            //            if (int.TryParse(result["RDC_Items"].ToString(), out tempRdcItems))
            //            {
            //                record.RdcItems = tempRdcItems;
            //            }


            //            //calculate days and years
            //            record.DaysWithBank = (int)(today - record.DateOpened).TotalDays;
            //            record.DaysInBusiness = (int)(today - record.DateOfOrganization).TotalDays;


            //            ////temporary placeholder values
            //            //record.HighestChargebackAmount = 5000.00m;
            //            //record.ChargebackItems = 50;
            //            //record.HighestSettlementAmount = 5000.00m;
            //            //record.TotalChargeback = 2500.00m;
            //            //record.NsfItems = 5;
            //            //record.RdcItems = 500;
            //            //record.DaysWithBank = 89;
            //            //record.DaysInBusiness = 15;

            //            record.RdcDailyLimit = input.RdcDailyLimit ?? 0;

            //            //riskmatrix.RiskMatrix.Add(record);
            //            riskmatrix.Add(record);
            //        }
            //    }
            //}

            //maxRiskMatrix.NameId = riskmatrix.RiskMatrix[0].NameId;
            //maxRiskMatrix.Name = riskmatrix.RiskMatrix[0].Name;
            //maxRiskMatrix.TaxIdNumber = riskmatrix.RiskMatrix[0].TaxIdNumber;
            //maxRiskMatrix.TaxIdDescription = riskmatrix.RiskMatrix[0].TaxIdDescription;
            //maxRiskMatrix.DateOpened = riskmatrix.RiskMatrix[0].DateOpened;
            //maxRiskMatrix.CustomerOfficer = riskmatrix.RiskMatrix[0].CustomerOfficer;
            //maxRiskMatrix.NaicsCode = riskmatrix.RiskMatrix[0].NaicsCode;
            //maxRiskMatrix.NaicsDescription = riskmatrix.RiskMatrix[0].NaicsDescription;
            //maxRiskMatrix.DateOfOrganization = riskmatrix.RiskMatrix[0].DateOfOrganization;
            ////maxRiskMatrix.DdaAccount = riskmatrix.RiskMatrix[0].DdaAccount;
            //maxRiskMatrix.RiskRate = riskmatrix.RiskMatrix[0].RiskRate;
            ////maxRiskMatrix.HighestChargebackAmount = riskmatrix.RiskMatrix[0].HighestChargebackAmount;
            //maxRiskMatrix.ChargebackItems = riskmatrix.RiskMatrix[0].ChargebackItems;
            ////maxRiskMatrix.HighestSettlementAmount = riskmatrix.RiskMatrix[0].HighestSettlementAmount;
            ////maxRiskMatrix.TotalChargeback = riskmatrix.RiskMatrix[0].TotalChargeback;
            //maxRiskMatrix.NsfItems = riskmatrix.RiskMatrix[0].NsfItems;
            //maxRiskMatrix.RdcItems = riskmatrix.RiskMatrix[0].RdcItems;
            //maxRiskMatrix.DaysWithBank = riskmatrix.RiskMatrix[0].DaysWithBank;
            //maxRiskMatrix.DaysInBusiness = riskmatrix.RiskMatrix[0].DaysInBusiness;
            //maxRiskMatrix.RdcDailyLimit = riskmatrix.RiskMatrix[0].RdcDailyLimit;

            //foreach (var row in riskmatrix)
            //{
            //    if (row.NameId > RiskMatrix.NameId)
            //    {
            //        RiskMatrix.NameId = row.NameId;
            //    }
            //    if (string.Compare(row.Name, RiskMatrix.Name) == 1)
            //    {
            //        RiskMatrix.Name = row.Name;
            //    }
            //    if (row.TaxIdNumber > RiskMatrix.TaxIdNumber)
            //    {
            //        RiskMatrix.TaxIdNumber = row.TaxIdNumber;
            //    }
            //    if (string.Compare(row.TaxIdDescription, RiskMatrix.TaxIdDescription) == 1)
            //    {
            //        RiskMatrix.TaxIdDescription = row.TaxIdDescription;
            //    }
            //    if (row.TaxIdNumber > RiskMatrix.TaxIdNumber)
            //    {
            //        RiskMatrix.TaxIdNumber = row.TaxIdNumber;
            //    }
            //    if (row.DateOpened > RiskMatrix.DateOpened)
            //    {
            //        RiskMatrix.DateOpened = row.DateOpened;
            //    }
            //    if (string.Compare(row.CustomerOfficer, RiskMatrix.CustomerOfficer) == 1)
            //    {
            //        RiskMatrix.CustomerOfficer = row.CustomerOfficer;
            //    }
            //    if (row.NaicsCode > RiskMatrix.NaicsCode)
            //    {
            //        RiskMatrix.NaicsCode = row.NaicsCode;
            //    }
            //    if (string.Compare(row.NaicsDescription, RiskMatrix.NaicsDescription) == 1)
            //    {
            //        RiskMatrix.NaicsDescription = row.NaicsDescription;
            //    }
            //    if (row.DateOfOrganization > RiskMatrix.DateOfOrganization)
            //    {
            //        RiskMatrix.DateOfOrganization = row.DateOfOrganization;
            //    }
            //    //if (row.DdaAccount > maxRiskMatrix.DdaAccount)
            //    //{
            //    //    maxRiskMatrix.DdaAccount = row.DdaAccount;
            //    //}
            //    if (row.RiskRate > RiskMatrix.RiskRate)
            //    {
            //        RiskMatrix.RiskRate = row.RiskRate;
            //    }
            //    //if (row.HighestChargebackAmount > maxRiskMatrix.HighestChargebackAmount)
            //    //{
            //    //    maxRiskMatrix.HighestChargebackAmount = row.HighestChargebackAmount;
            //    //}
            //    if (row.ChargebackItems > RiskMatrix.ChargebackItems)
            //    {
            //        RiskMatrix.ChargebackItems = row.ChargebackItems;
            //    }
            //    //if (row.HighestSettlementAmount > maxRiskMatrix.HighestSettlementAmount)
            //    //{
            //    //    maxRiskMatrix.HighestSettlementAmount = row.HighestSettlementAmount;
            //    //}
            //    //if (row.TotalChargeback > maxRiskMatrix.TotalChargeback)
            //    //{
            //    //    maxRiskMatrix.TotalChargeback = row.TotalChargeback;
            //    //}
            //    if (row.NsfItems > RiskMatrix.NsfItems)
            //    {
            //        RiskMatrix.NsfItems = row.NsfItems;
            //    }
            //    if (row.RdcItems > RiskMatrix.RdcItems)
            //    {
            //        RiskMatrix.RdcItems = row.RdcItems;
            //    }
            //    if (row.DaysWithBank > RiskMatrix.DaysWithBank)
            //    {
            //        RiskMatrix.DaysWithBank = row.DaysWithBank;
            //    }
            //    if (row.DaysInBusiness > RiskMatrix.DaysInBusiness)
            //    {
            //        RiskMatrix.DaysInBusiness = row.DaysInBusiness;
            //    }
            //    if (row.RdcDailyLimit > RiskMatrix.RdcDailyLimit)
            //    {
            //        RiskMatrix.RdcDailyLimit = row.RdcDailyLimit;
            //    }
            //}

            //riskMatrixMaxValues contains max values

            //foreach (var row in riskmatrix.RiskMatrix)
            //{
                //if (row.RdcDailyLimit <= 249999)
                //{
                //    row.RdcDailyLimitRiskContrib = 1;
                //}
                //else if (row.RdcDailyLimit >= 250000 && row.RdcDailyLimit <= 499999)
                //{
                //    row.RdcDailyLimitRiskContrib = 3;
                //}
                //else if (row.RdcDailyLimit >= 500000 && row.RdcDailyLimit <= 749999)
                //{
                //    row.RdcDailyLimitRiskContrib = 5;
                //}
                //else if (row.RdcDailyLimit >= 750000 && row.RdcDailyLimit <= 999999)
                //{
                //    row.RdcDailyLimitRiskContrib = 7;
                //}
                //else if (row.RdcDailyLimit >= 1000000)
                //{
                //    row.RdcDailyLimitRiskContrib = 10;
                //}

                //if (row.ChargebackItems <= 1)
                //{
                //    row.ChargebackRiskContrib = 1;
                //}
                //else if (row.ChargebackItems >= 2 && row.ChargebackItems <= 3)
                //{
                //    row.ChargebackRiskContrib = 3;
                //}
                //else if (row.ChargebackItems >= 4 && row.ChargebackItems <= 5)
                //{
                //    row.ChargebackRiskContrib = 5;
                //}
                //else if (row.ChargebackItems >= 6 && row.ChargebackItems <= 7)
                //{
                //    row.ChargebackRiskContrib = 7;
                //}
                //else if (row.ChargebackItems >= 8)
                //{
                //    row.ChargebackRiskContrib = 10;
                //}

                //if (row.RdcItems <= 200)
                //{
                //    row.DepositCountRiskContrib = 1;
                //}
                //else if (row.RdcItems >= 200 && row.RdcItems <= 400)
                //{
                //    row.DepositCountRiskContrib = 3;
                //}
                //else if (row.RdcItems >= 401 && row.RdcItems <= 600)
                //{
                //    row.DepositCountRiskContrib = 5;
                //}
                //else if (row.RdcItems >= 601 && row.RdcItems <= 800)
                //{
                //    row.DepositCountRiskContrib = 7;
                //}
                //else if (row.RdcItems >= 801)
                //{
                //    row.DepositCountRiskContrib = 10;
                //}

                //if (row.NsfItems <= 1)
                //{
                //    row.NsfItemRiskContrib = 1;
                //}
                //else if (row.NsfItems >= 2 && row.NsfItems <= 2)
                //{
                //    row.NsfItemRiskContrib = 3;
                //}
                //else if (row.NsfItems >= 3 && row.NsfItems <= 3)
                //{
                //    row.NsfItemRiskContrib = 5;
                //}
                //else if (row.NsfItems >= 4 && row.NsfItems <= 4)
                //{
                //    row.NsfItemRiskContrib = 7;
                //}
                //else if (row.NsfItems >= 5)
                //{
                //    row.NsfItemRiskContrib = 10;
                //}

                //if (row.DaysWithBank <= 89)
                //{
                //    row.BankTenureRiskContrib = 10;
                //}
                //else if (row.DaysWithBank >= 90 && row.DaysWithBank <= 364)
                //{
                //    row.BankTenureRiskContrib = 7;
                //}
                //else if (row.DaysWithBank >= 365 && row.DaysWithBank <= 729)
                //{
                //    row.BankTenureRiskContrib = 5;
                //}
                //else if (row.DaysWithBank >= 730 && row.DaysWithBank <= 1094)
                //{
                //    row.BankTenureRiskContrib = 3;
                //}
                //else if (row.DaysWithBank >= 1095)
                //{
                //    row.BankTenureRiskContrib = 1;
                //}

                //if (row.DaysInBusiness <= 1)
                //{
                //    row.YearsInBusinessRiskContrib = 10;
                //}
                //else if (row.DaysInBusiness >= 2 && row.DaysInBusiness <= 3)
                //{
                //    row.YearsInBusinessRiskContrib = 7;
                //}
                //else if (row.DaysInBusiness >= 4 && row.DaysInBusiness <= 5)
                //{
                //    row.YearsInBusinessRiskContrib = 5;
                //}
                //else if (row.DaysInBusiness >= 6 && row.DaysInBusiness <= 7)
                //{
                //    row.YearsInBusinessRiskContrib = 3;
                //}
                //else if (row.DaysInBusiness >= 8)
                //{
                //    row.YearsInBusinessRiskContrib = 1;
                //}

                //if (row.RiskRate == 1)
                //{
                //    row.CipRiskRateRiskContrib = 1;
                //}
                //else if (row.RiskRate == 2 || row.RiskRate == 3)
                //{
                //    row.CipRiskRateRiskContrib = 5;
                //}
                //else if (row.RiskRate == 4)
                //{
                //    row.CipRiskRateRiskContrib = 10;
                //}
                //else
                //{
                //    row.CipRiskRateRiskContrib = 1;
                //}
            //}

            //RDC Daily Limit Risk Factor (Total Possible Daily Settlement Account)
            if (RiskMatrix.RdcDailyLimit <= 249999.99m)
            {
                RiskMatrix.RdcDailyLimitRiskContrib = 1;
            }
            else if (RiskMatrix.RdcDailyLimit >= 250000.00m && RiskMatrix.RdcDailyLimit <= 499999.99m)
            {
                RiskMatrix.RdcDailyLimitRiskContrib = 3;
            }
            else if (RiskMatrix.RdcDailyLimit >= 500000.00m && RiskMatrix.RdcDailyLimit <= 699999.99m)
            {
                RiskMatrix.RdcDailyLimitRiskContrib = 5;
            }
            else if (RiskMatrix.RdcDailyLimit >= 750000.00m && RiskMatrix.RdcDailyLimit <= 999999.99m)
            {
                RiskMatrix.RdcDailyLimitRiskContrib = 7;
            }
            else if (RiskMatrix.RdcDailyLimit >= 1000000.00m)
            {
                RiskMatrix.RdcDailyLimitRiskContrib = 10;
            }

            //Chargeback Items Risk Factor (Number of Returned Items 3 Month)
            if (RiskMatrix.ChargebackItems <= 1)
            {
                RiskMatrix.ChargebackRiskContrib = 1;
            }
            else if (RiskMatrix.ChargebackItems >= 2 && RiskMatrix.ChargebackItems <= 3)
            {
                RiskMatrix.ChargebackRiskContrib = 3;
            }
            else if (RiskMatrix.ChargebackItems >= 4 && RiskMatrix.ChargebackItems <= 5)
            {
                RiskMatrix.ChargebackRiskContrib = 5;
            }
            else if (RiskMatrix.ChargebackItems >= 6 && RiskMatrix.ChargebackItems <= 7)
            {
                RiskMatrix.ChargebackRiskContrib = 7;
            }
            else if (RiskMatrix.ChargebackItems >= 8)
            {
                RiskMatrix.ChargebackRiskContrib = 10;
            }

            //RDC Item Count Risk Factor (Number of Deposited Items)
            if (RiskMatrix.RdcItems <= 200)
            {
                RiskMatrix.DepositCountRiskContrib = 1;
            }
            else if (RiskMatrix.RdcItems >= 201 && RiskMatrix.RdcItems <= 400)
            {
                RiskMatrix.DepositCountRiskContrib = 3;
            }
            else if (RiskMatrix.RdcItems >= 401 && RiskMatrix.RdcItems <= 600)
            {
                RiskMatrix.DepositCountRiskContrib = 5;
            }
            else if (RiskMatrix.RdcItems >= 601 && RiskMatrix.RdcItems <= 800)
            {
                RiskMatrix.DepositCountRiskContrib = 7;
            }
            else if (RiskMatrix.RdcItems >= 801)
            {
                RiskMatrix.DepositCountRiskContrib = 10;
            }

            //NSF Item Risk Factor (Number of NSF Items)
            if (RiskMatrix.NsfItems <= 1)
            {
                RiskMatrix.NsfItemRiskContrib = 1;
            }
            else if (RiskMatrix.NsfItems >= 2 && RiskMatrix.NsfItems <= 2)
            {
                RiskMatrix.NsfItemRiskContrib = 3;
            }
            else if (RiskMatrix.NsfItems >= 3 && RiskMatrix.NsfItems <= 3)
            {
                RiskMatrix.NsfItemRiskContrib = 5;
            }
            else if (RiskMatrix.NsfItems >= 4 && RiskMatrix.NsfItems <= 4)
            {
                RiskMatrix.NsfItemRiskContrib = 7;
            }
            else if (RiskMatrix.NsfItems >= 5)
            {
                RiskMatrix.NsfItemRiskContrib = 10;
            }

            //Days With Bank Risk Factor (Tenure as Customer of Bank)
            int year = 365;

            if (RiskMatrix.DaysWithBank <= 90)
            {
                RiskMatrix.BankTenureRiskContrib = 10;
            }
            else if (RiskMatrix.DaysWithBank >= 91 && RiskMatrix.DaysWithBank <= 1 * year)
            {
                RiskMatrix.BankTenureRiskContrib = 7;
            }
            else if (RiskMatrix.DaysWithBank >= 1 * year + 1 && RiskMatrix.DaysWithBank <= 2 * year)
            {
                RiskMatrix.BankTenureRiskContrib = 5;
            }
            else if (RiskMatrix.DaysWithBank >= 2 * year + 1 && RiskMatrix.DaysWithBank <= 3 * year)
            {
                RiskMatrix.BankTenureRiskContrib = 3;
            }
            else if (RiskMatrix.DaysWithBank >= 3 * year + 1)
            {
                RiskMatrix.BankTenureRiskContrib = 1;
            }

            //Years in Business Risk Factor (Longevity in Business)
            if (RiskMatrix.DaysInBusiness <= 1 * year)
            {
                RiskMatrix.YearsInBusinessRiskContrib = 10;
            }
            else if (RiskMatrix.DaysInBusiness >= 2 * year && RiskMatrix.DaysInBusiness <= 3 * year)
            {
                RiskMatrix.YearsInBusinessRiskContrib = 7;
            }
            else if (RiskMatrix.DaysInBusiness >= 4 * year && RiskMatrix.DaysInBusiness <= 5 * year)
            {
                RiskMatrix.YearsInBusinessRiskContrib = 5;
            }
            else if (RiskMatrix.DaysInBusiness >= 6 * year && RiskMatrix.DaysInBusiness <= 7 * year)
            {
                RiskMatrix.YearsInBusinessRiskContrib = 3;
            }
            else if (RiskMatrix.DaysInBusiness >= 8 * year)
            {
                RiskMatrix.YearsInBusinessRiskContrib = 1;
            }

            //Risk Rating Factor (CIP Risk Rating)
            if (RiskMatrix.RiskRate == 1)
            {
                RiskMatrix.CipRiskRateRiskContrib = 1;
            }
            else if (RiskMatrix.RiskRate == 2 || RiskMatrix.RiskRate == 3)
            {
                RiskMatrix.CipRiskRateRiskContrib = 5;
            }
            else if (RiskMatrix.RiskRate == 4)
            {
                RiskMatrix.CipRiskRateRiskContrib = 10;
            }
            else
            {
                RiskMatrix.CipRiskRateRiskContrib = 1;
            }

            //foreach (var row in riskmatrix.RiskMatrix)
            //{
            //    row.RiskMatrixTotal = row.RdcDailyLimitRiskContrib + row.ChargebackRiskContrib + row.DepositCountRiskContrib
            //        + row.NsfItemRiskContrib + row.BankTenureRiskContrib + row.YearsInBusinessRiskContrib + row.CipRiskRateRiskContrib;
            //}

            RiskMatrix.RiskMatrixTotal = RiskMatrix.RdcDailyLimitRiskContrib + RiskMatrix.ChargebackRiskContrib + RiskMatrix.DepositCountRiskContrib 
                + RiskMatrix.NsfItemRiskContrib + RiskMatrix.BankTenureRiskContrib + RiskMatrix.YearsInBusinessRiskContrib + RiskMatrix.CipRiskRateRiskContrib;


            //foreach (var row in riskmatrix.RiskMatrix)
            //{
            //    if (row.BankTenureRiskContrib == 10)
            //    {
            //        row.WeightedRiskFactor = 0.25m;
            //    }
            //    else if (row.RiskMatrixTotal <= 18)
            //    {
            //        row.WeightedRiskFactor = 0.05m;
            //    }
            //    else if (row.RiskMatrixTotal >= 19 && row.RiskMatrixTotal <= 27)
            //    {
            //        row.WeightedRiskFactor = 0.10m;
            //    }
            //    else if (row.RiskMatrixTotal >= 28 && row.RiskMatrixTotal <= 36)
            //    {
            //        row.WeightedRiskFactor = 0.15m;
            //    }
            //    else if (row.RiskMatrixTotal >= 37 && row.RiskMatrixTotal <= 41)
            //    {
            //        row.WeightedRiskFactor = 0.2m;
            //    }
            //    else if (row.RiskMatrixTotal >= 42)
            //    {
            //        row.WeightedRiskFactor = 0.25m;
            //    }
            //}

            if (RiskMatrix.BankTenureRiskContrib == 10)
            {
                RiskMatrix.WeightedRiskFactor = 0.25m;
            }
            else if (RiskMatrix.RiskMatrixTotal <= 18)
            {
                RiskMatrix.WeightedRiskFactor = 0.05m;
            }
            else if (RiskMatrix.RiskMatrixTotal >= 19 && RiskMatrix.RiskMatrixTotal <= 27)
            {
                RiskMatrix.WeightedRiskFactor = 0.10m;
            }
            else if (RiskMatrix.RiskMatrixTotal >= 28 && RiskMatrix.RiskMatrixTotal <= 36)
            {
                RiskMatrix.WeightedRiskFactor = 0.15m;
            }
            else if (RiskMatrix.RiskMatrixTotal >= 37 && RiskMatrix.RiskMatrixTotal <= 41)
            {
                RiskMatrix.WeightedRiskFactor = 0.20m;
            }
            else if (RiskMatrix.RiskMatrixTotal >= 42)
            {
                RiskMatrix.WeightedRiskFactor = 0.25m;
            }

            //foreach (var row in riskmatrix.RiskMatrix)
            //{
            //    if (row.BankTenureRiskContrib == 10)
            //    {
            //        row.RiskRating = "High";
            //    }
            //    else if (row.RiskMatrixTotal <= 18)
            //    {
            //        row.RiskRating = "Low";
            //    }
            //    else if (row.RiskMatrixTotal >= 19 && row.RiskMatrixTotal <= 27)
            //    {
            //        row.RiskRating = "Low-Medium";
            //    }
            //    else if (row.RiskMatrixTotal >= 28 && row.RiskMatrixTotal <= 36)
            //    {
            //        row.RiskRating = "Medium";
            //    }
            //    else if (row.RiskMatrixTotal >= 37 && row.RiskMatrixTotal <= 41)
            //    {
            //        row.RiskRating = "Medium-High";
            //    }
            //    else if (row.RiskMatrixTotal >= 42)
            //    {
            //        row.RiskRating = "High";
            //    }
            //}

            if (RiskMatrix.BankTenureRiskContrib == 10)
            {
                RiskMatrix.RiskRating = "High";
            }
            else if (RiskMatrix.RiskMatrixTotal <= 18)
            {
                RiskMatrix.RiskRating = "Low";
            }
            else if (RiskMatrix.RiskMatrixTotal >= 19 && RiskMatrix.RiskMatrixTotal <= 27)
            {
                RiskMatrix.RiskRating = "Low-Medium";
            }
            else if (RiskMatrix.RiskMatrixTotal >= 28 && RiskMatrix.RiskMatrixTotal <= 36)
            {
                RiskMatrix.RiskRating = "Medium";
            }
            else if (RiskMatrix.RiskMatrixTotal >= 37 && RiskMatrix.RiskMatrixTotal <= 41)
            {
                RiskMatrix.RiskRating = "Medium-High";
            }
            else if (RiskMatrix.RiskMatrixTotal >= 42)
            {
                RiskMatrix.RiskRating = "High";
            }

            return RiskMatrix;
        }

        //// PUT: api/CustomerDataModels/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomerDataModel(decimal? id, CustomerDataModel customerDataModel)
        //{
        //    if (id != customerDataModel.NameId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customerDataModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerDataModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/CustomerDataModels
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<CustomerDataModel>> PostCustomerDataModel(CustomerDataModel customerDataModel)
        //{
        //    _context.CustomerDataModel.Add(customerDataModel);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CustomerDataModelExists(customerDataModel.NameId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetCustomerDataModel", new { id = customerDataModel.NameId }, customerDataModel);
        //}

        //// DELETE: api/CustomerDataModels/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<CustomerDataModel>> DeleteCustomerDataModel(decimal? id)
        //{
        //    var customerDataModel = await _context.CustomerDataModel.FindAsync(id);
        //    if (customerDataModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CustomerDataModel.Remove(customerDataModel);
        //    await _context.SaveChangesAsync();

        //    return customerDataModel;
        //}

        //private bool CustomerDataModelExists(decimal? id)
        //{
        //    return _context.CustomerDataModel.Any(e => e.NameId == id);
        //}
    }
}
