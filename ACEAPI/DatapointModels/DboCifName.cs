using System;
using System.Collections.Generic;

namespace ACEAPI.DatapointModels
{
    public partial class DboCifName
    {
        public short? InstitutionNumber { get; set; }
        public decimal? NameId { get; set; }
        public short? CustomerType { get; set; }
        public string CustomerTypeDesc { get; set; }
        public string RelationshipCode { get; set; }
        public string Name { get; set; }
        public string ShortLastName { get; set; }
        public string ShortFirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Soundex { get; set; }
        public string TaxIdCode { get; set; }
        public decimal? TaxIdNumber { get; set; }
        public short? TaxIdType { get; set; }
        public string TaxIdDescription { get; set; }
        public short? TinVerificationAttempts { get; set; }
        public DateTime? TinVerificationDate { get; set; }
        public string WithholdingCode { get; set; }
        public short? CustomerOpenMethod { get; set; }
        public string LanguagePreference { get; set; }
        public string RetentionCode { get; set; }
        public decimal? SignatureLink { get; set; }
        public int? CreditScore { get; set; }
        public short? RiskScore1 { get; set; }
        public short? RiskScore2 { get; set; }
        public short? RiskRanking { get; set; }
        public decimal? NaicsCode { get; set; }
        public DateTime? DateOpened { get; set; }
        public DateTime? DateLastFmActivity { get; set; }
        public DateTime? Birthday { get; set; }
        public string GenderCode { get; set; }
        public short? RaceCode { get; set; }
        public short? EmployeeOfficerDirector { get; set; }
        public string EbbPassword { get; set; }
        public short? PrimaryPhoneIndex { get; set; }
        public short? PrimaryContactIndex { get; set; }
        public short? ActivityFlag { get; set; }
        public short? LastAlternateId { get; set; }
        public short? BranchNumber { get; set; }
        public int? AccountingGroup { get; set; }
        public int? RespCode { get; set; }
        public int? ReferralRespCode { get; set; }
        public string TinMatchingCode { get; set; }
        public DateTime? DateDeceased { get; set; }
        public short? BeneOwnerOptOutFlag { get; set; }
        public string BeneOwnerOptOutFlagDesc { get; set; }
        public string GenerationCode { get; set; }
    }
}
