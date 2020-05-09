using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ACEAPI.DatapointModels;


namespace ACEAPI.Data
{
    public partial class EDW_PRODContext : DbContext
    {
        public EDW_PRODContext()
        {
        }

        public EDW_PRODContext(DbContextOptions<EDW_PRODContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<DboCifName> DboCifName { get; set; }
        //public virtual DbSet<DboCrossAppDataDesc> DboCrossAppDataDesc { get; set; }
        //public virtual DbSet<DboNaicsDescription> DboNaicsDescription { get; set; }
        //public virtual DbSet<DboNameFlexData101To200> DboNameFlexData101To200 { get; set; }

        //public virtual DbSet<DatapointCustomerInformationModel> CustomerDataModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DboCifName>(entity =>
            //{
            //    entity.HasKey(e => e.NameId);

            //    entity.ToTable("dbo_CIF_Name", "PRIME002");

            //    entity.Property(e => e.AccountingGroup).HasColumnName("Accounting_Group");

            //    entity.Property(e => e.ActivityFlag).HasColumnName("Activity_Flag");

            //    entity.Property(e => e.BeneOwnerOptOutFlag).HasColumnName("Bene_Owner_Opt_Out_Flag");

            //    entity.Property(e => e.BeneOwnerOptOutFlagDesc)
            //        .HasColumnName("Bene_Owner_Opt_Out_Flag_Desc")
            //        .HasMaxLength(15)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Birthday).HasColumnType("datetime");

            //    entity.Property(e => e.BranchNumber).HasColumnName("Branch_Number");

            //    entity.Property(e => e.CreditScore).HasColumnName("Credit_Score");

            //    entity.Property(e => e.CustomerOpenMethod).HasColumnName("Customer_Open_Method");

            //    entity.Property(e => e.CustomerType).HasColumnName("Customer_Type");

            //    entity.Property(e => e.CustomerTypeDesc)
            //        .HasColumnName("Customer_Type_Desc")
            //        .HasMaxLength(40)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DateDeceased)
            //        .HasColumnName("Date_Deceased")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.DateLastFmActivity)
            //        .HasColumnName("Date_Last_FM_Activity")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.DateOpened)
            //        .HasColumnName("Date_Opened")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.EbbPassword)
            //        .HasColumnName("EBB_Password")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.EmployeeOfficerDirector).HasColumnName("Employee_Officer_Director");

            //    entity.Property(e => e.GenderCode)
            //        .HasColumnName("Gender_Code")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.GenerationCode)
            //        .HasColumnName("Generation_Code")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.InstitutionNumber).HasColumnName("Institution_Number");

            //    entity.Property(e => e.LanguagePreference)
            //        .HasColumnName("Language_Preference")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.LastAlternateId).HasColumnName("Last_Alternate_ID");

            //    entity.Property(e => e.MiddleInitial)
            //        .HasColumnName("Middle_Initial")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.NaicsCode)
            //        .HasColumnName("NAICS_Code")
            //        .HasColumnType("decimal(8, 0)");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.NameId)
            //        .HasColumnName("Name_ID")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.PrimaryContactIndex).HasColumnName("Primary_Contact_Index");

            //    entity.Property(e => e.PrimaryPhoneIndex).HasColumnName("Primary_Phone_Index");

            //    entity.Property(e => e.RaceCode).HasColumnName("Race_Code");

            //    entity.Property(e => e.ReferralRespCode).HasColumnName("Referral_Resp_Code");

            //    entity.Property(e => e.RelationshipCode)
            //        .HasColumnName("Relationship_Code")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.RespCode).HasColumnName("Resp_Code");

            //    entity.Property(e => e.RetentionCode)
            //        .HasColumnName("Retention_Code")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.RiskRanking).HasColumnName("Risk_Ranking");

            //    entity.Property(e => e.RiskScore1).HasColumnName("Risk_Score1");

            //    entity.Property(e => e.RiskScore2).HasColumnName("Risk_Score2");

            //    entity.Property(e => e.ShortFirstName)
            //        .HasColumnName("Short_First_Name")
            //        .HasMaxLength(15)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.ShortLastName)
            //        .HasColumnName("Short_Last_Name")
            //        .HasMaxLength(25)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SignatureLink)
            //        .HasColumnName("Signature_Link")
            //        .HasColumnType("decimal(10, 0)");

            //    entity.Property(e => e.Soundex)
            //        .HasMaxLength(11)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.TaxIdCode)
            //        .HasColumnName("Tax_ID_Code")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.TaxIdDescription)
            //        .HasColumnName("Tax_ID_Description")
            //        .HasMaxLength(20)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.TaxIdNumber)
            //        .HasColumnName("Tax_ID_Number")
            //        .HasColumnType("decimal(10, 0)");

            //    entity.Property(e => e.TaxIdType).HasColumnName("Tax_ID_Type");

            //    entity.Property(e => e.TinMatchingCode)
            //        .HasColumnName("TIN_Matching_Code")
            //        .HasMaxLength(2)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.TinVerificationAttempts).HasColumnName("TIN_Verification_Attempts");

            //    entity.Property(e => e.TinVerificationDate)
            //        .HasColumnName("TIN_Verification_Date")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.WithholdingCode)
            //        .HasColumnName("Withholding_Code")
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<DboCrossAppDataDesc>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("dbo_Cross_App_Data_Desc", "PRIME002");

            //    entity.Property(e => e.AccountType).HasColumnName("Account_Type");

            //    entity.Property(e => e.BranchNumber)
            //        .HasColumnName("Branch_Number")
            //        .HasColumnType("decimal(6, 0)");

            //    entity.Property(e => e.DateLastChanged)
            //        .HasColumnName("Date_Last_Changed")
            //        .HasColumnType("datetime");

            //    entity.Property(e => e.ExcludeFlag).HasColumnName("Exclude_Flag");

            //    entity.Property(e => e.ExternalValue)
            //        .HasColumnName("External_Value")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.FieldCode).HasColumnName("Field_Code");

            //    entity.Property(e => e.FromInternalValue)
            //        .HasColumnName("From_Internal_Value")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.FromInternalValueNumeric)
            //        .HasColumnName("From_Internal_Value_Numeric")
            //        .HasColumnType("decimal(12, 0)");

            //    entity.Property(e => e.InstitutionNumber).HasColumnName("Institution_Number");

            //    entity.Property(e => e.ShortName)
            //        .HasColumnName("Short_Name")
            //        .HasMaxLength(3)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.SystemCode).HasColumnName("System_Code");

            //    entity.Property(e => e.ThruInternalValue)
            //        .HasColumnName("Thru_Internal_Value")
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<DboNaicsDescription>(entity =>
            //{
            //    entity.HasKey(e => e.NaicsCode);

            //    entity.ToTable("dbo_NAICS_Description", "PRIME002");

            //    entity.Property(e => e.NaicsCode)
            //        .HasColumnName("NAICS_Code")
            //        .HasColumnType("decimal(8, 0)");

            //    entity.Property(e => e.NaicsDescription)
            //        .HasColumnName("NAICS_Description")
            //        .HasMaxLength(150)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<DboNameFlexData101To200>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("dbo_Name_Flex_Data_101_To_200", "PRIME002");

            //    entity.Property(e => e.AccountNumber)
            //        .HasColumnName("Account_Number")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.Property(e => e.Flex101)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex101Description)
            //        .HasColumnName("Flex101_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex102)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex102Description)
            //        .HasColumnName("Flex102_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex103)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex103Description)
            //        .HasColumnName("Flex103_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex104)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex104Description)
            //        .HasColumnName("Flex104_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex105)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex105Description)
            //        .HasColumnName("Flex105_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex106)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex106Description)
            //        .HasColumnName("Flex106_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex107)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex107Description)
            //        .HasColumnName("Flex107_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex108)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex108Description)
            //        .HasColumnName("Flex108_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex109)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex109Description)
            //        .HasColumnName("Flex109_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex110)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex110Description)
            //        .HasColumnName("Flex110_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex111)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex111Description)
            //        .HasColumnName("Flex111_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex112)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex112Description)
            //        .HasColumnName("Flex112_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex113)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex113Description)
            //        .HasColumnName("Flex113_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex114)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex114Description)
            //        .HasColumnName("Flex114_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex115)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex115Description)
            //        .HasColumnName("Flex115_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex116)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex116Description)
            //        .HasColumnName("Flex116_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex117)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex117Description)
            //        .HasColumnName("Flex117_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex118)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex118Description)
            //        .HasColumnName("Flex118_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex119)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex119Description)
            //        .HasColumnName("Flex119_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex120)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex120Description)
            //        .HasColumnName("Flex120_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex121)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex121Description)
            //        .HasColumnName("Flex121_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex122)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex122Description)
            //        .HasColumnName("Flex122_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex123)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex123Description)
            //        .HasColumnName("Flex123_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex124)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex124Description)
            //        .HasColumnName("Flex124_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex125)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex125Description)
            //        .HasColumnName("Flex125_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex126)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex126Description)
            //        .HasColumnName("Flex126_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex127)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex127Description)
            //        .HasColumnName("Flex127_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex128)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex128Description)
            //        .HasColumnName("Flex128_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex129)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex129Description)
            //        .HasColumnName("Flex129_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex130)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex130Description)
            //        .HasColumnName("Flex130_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex131)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex131Description)
            //        .HasColumnName("Flex131_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex132)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex132Description)
            //        .HasColumnName("Flex132_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex133)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex133Description)
            //        .HasColumnName("Flex133_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex134)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex134Description)
            //        .HasColumnName("Flex134_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex135)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex135Description)
            //        .HasColumnName("Flex135_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex136)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex136Description)
            //        .HasColumnName("Flex136_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex137)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex137Description)
            //        .HasColumnName("Flex137_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex138)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex138Description)
            //        .HasColumnName("Flex138_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex139)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex139Description)
            //        .HasColumnName("Flex139_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex140)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex140Description)
            //        .HasColumnName("Flex140_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex141)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex141Description)
            //        .HasColumnName("Flex141_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex142)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex142Description)
            //        .HasColumnName("Flex142_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex143)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex143Description)
            //        .HasColumnName("Flex143_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex144)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex144Description)
            //        .HasColumnName("Flex144_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex145)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex145Description)
            //        .HasColumnName("Flex145_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex146)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex146Description)
            //        .HasColumnName("Flex146_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex147)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex147Description)
            //        .HasColumnName("Flex147_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex148)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex148Description)
            //        .HasColumnName("Flex148_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex149)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex149Description)
            //        .HasColumnName("Flex149_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex150)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex150Description)
            //        .HasColumnName("Flex150_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex151)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex151Description)
            //        .HasColumnName("Flex151_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex152)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex152Description)
            //        .HasColumnName("Flex152_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex153)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex153Description)
            //        .HasColumnName("Flex153_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex154)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex154Description)
            //        .HasColumnName("Flex154_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex155)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex155Description)
            //        .HasColumnName("Flex155_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex156)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex156Description)
            //        .HasColumnName("Flex156_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex157)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex157Description)
            //        .HasColumnName("Flex157_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex158)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex158Description)
            //        .HasColumnName("Flex158_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex159)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex159Description)
            //        .HasColumnName("Flex159_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex160)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex160Description)
            //        .HasColumnName("Flex160_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex161)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex161Description)
            //        .HasColumnName("Flex161_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex162)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex162Description)
            //        .HasColumnName("Flex162_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex163)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex163Description)
            //        .HasColumnName("Flex163_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex164)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex164Description)
            //        .HasColumnName("Flex164_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex165)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex165Description)
            //        .HasColumnName("Flex165_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex166)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex166Description)
            //        .HasColumnName("Flex166_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex167)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex167Description)
            //        .HasColumnName("Flex167_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex168)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex168Description)
            //        .HasColumnName("Flex168_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex169)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex169Description)
            //        .HasColumnName("Flex169_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex170)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex170Description)
            //        .HasColumnName("Flex170_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex171)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex171Description)
            //        .HasColumnName("Flex171_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex172)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex172Description)
            //        .HasColumnName("Flex172_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex173)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex173Description)
            //        .HasColumnName("Flex173_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex174)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex174Description)
            //        .HasColumnName("Flex174_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex175)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex175Description)
            //        .HasColumnName("Flex175_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex176)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex176Description)
            //        .HasColumnName("Flex176_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex177)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex177Description)
            //        .HasColumnName("Flex177_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex178)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex178Description)
            //        .HasColumnName("Flex178_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex179)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex179Description)
            //        .HasColumnName("Flex179_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex180)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex180Description)
            //        .HasColumnName("Flex180_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex181)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex181Description)
            //        .HasColumnName("Flex181_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex182)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex182Description)
            //        .HasColumnName("Flex182_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex183)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex183Description)
            //        .HasColumnName("Flex183_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex184)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex184Description)
            //        .HasColumnName("Flex184_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex185)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex185Description)
            //        .HasColumnName("Flex185_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex186)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex186Description)
            //        .HasColumnName("Flex186_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex187)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex187Description)
            //        .HasColumnName("Flex187_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex188)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex188Description)
            //        .HasColumnName("Flex188_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex189)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex189Description)
            //        .HasColumnName("Flex189_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex190)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex190Description)
            //        .HasColumnName("Flex190_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex191)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex191Description)
            //        .HasColumnName("Flex191_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex192)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex192Description)
            //        .HasColumnName("Flex192_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex193)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex193Description)
            //        .HasColumnName("Flex193_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex194)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex194Description)
            //        .HasColumnName("Flex194_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex195)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex195Description)
            //        .HasColumnName("Flex195_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex196)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex196Description)
            //        .HasColumnName("Flex196_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex197)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex197Description)
            //        .HasColumnName("Flex197_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex198)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex198Description)
            //        .HasColumnName("Flex198_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex199)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex199Description)
            //        .HasColumnName("Flex199_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex200)
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.Flex200Description)
            //        .HasColumnName("Flex200_Description")
            //        .HasMaxLength(40)
            //        .IsUnicode(false)
            //        .IsFixedLength();

            //    entity.Property(e => e.InstitutionNumber).HasColumnName("Institution_Number");

            //    entity.Property(e => e.RecordNumber).HasColumnName("Record_Number");
            //});

            //modelBuilder.Entity<DatapointCustomerInformationModel>(entity =>
            //{
            //    entity.HasKey(e => e.NameId);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
