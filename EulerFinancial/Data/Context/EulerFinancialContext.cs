using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EulerFinancial.Data.Model;

#nullable disable

namespace EulerFinancial.Data.Context
{
    public partial class EulerFinancialContext : DbContext
    {
        public EulerFinancialContext()
        {
        }

        public EulerFinancialContext(DbContextOptions<EulerFinancialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; }
        public virtual DbSet<AccountCustodian> AccountCustodians { get; set; }
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<AccountGroupMember> AccountGroupMembers { get; set; }
        public virtual DbSet<AccountObject> AccountObjects { get; set; }
        public virtual DbSet<AccountWallet> AccountWallets { get; set; }
        public virtual DbSet<AuditEvent> AuditEvents { get; set; }
        public virtual DbSet<BankTransaction> BankTransactions { get; set; }
        public virtual DbSet<BankTransactionCode> BankTransactionCodes { get; set; }
        public virtual DbSet<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; }
        public virtual DbSet<BrokerTransaction> BrokerTransactions { get; set; }
        public virtual DbSet<BrokerTransactionCode> BrokerTransactionCodes { get; set; }
        public virtual DbSet<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; }
        public virtual DbSet<BrokerTransactionTaxLot> BrokerTransactionTaxLots { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
        public virtual DbSet<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; }
        public virtual DbSet<InvestmentPerformanceEntry> InvestmentPerformanceEntries { get; set; }
        public virtual DbSet<InvestmentStrategy> InvestmentStrategies { get; set; }
        public virtual DbSet<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
        public virtual DbSet<MarketHoliday> MarketHolidays { get; set; }
        public virtual DbSet<MarketHolidaySchedule> MarketHolidaySchedules { get; set; }
        public virtual DbSet<MarketIndex> MarketIndices { get; set; }
        public virtual DbSet<MarketIndexPrice> MarketIndexPrices { get; set; }
        public virtual DbSet<ModelAttribute> ModelAttributes { get; set; }
        public virtual DbSet<ModelAttributeMember> ModelAttributeMembers { get; set; }
        public virtual DbSet<ModelAttributeScope> ModelAttributeScopes { get; set; }
        public virtual DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        public virtual DbSet<ReportStyleSheet> ReportStyleSheets { get; set; }
        public virtual DbSet<ResourceImage> ResourceImages { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<SecurityAttributeMemberEntry> SecurityAttributeMemberEntries { get; set; }
        public virtual DbSet<SecurityExchange> SecurityExchanges { get; set; }
        public virtual DbSet<SecurityPrice> SecurityPrices { get; set; }
        public virtual DbSet<SecuritySymbol> SecuritySymbols { get; set; }
        public virtual DbSet<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
        public virtual DbSet<SecuritySymbolType> SecuritySymbolTypes { get; set; }
        public virtual DbSet<SecurityType> SecurityTypes { get; set; }
        public virtual DbSet<SecurityTypeGroup> SecurityTypeGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:EulerFinancial");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "EulerApp");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountCustodianId).HasColumnName("AccountCustodianID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.BooksClosedDate).HasColumnType("date");

                entity.HasOne(d => d.AccountCustodian)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountCustodianId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Account_AccountCustodian");

                entity.HasOne(d => d.AccountNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_AccountObject");
            });

            modelBuilder.Entity<AccountAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("AccountAttributeMemberEntry", "EulerApp");

                entity.HasIndex(e => new { e.EffectiveDate, e.AccountObjectId, e.AttributeMemberId }, "UNI_AccountAttributeMemberEntry_RowDef")
                    .IsUnique();

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.AccountObjectId).HasColumnName("AccountObjectID");

                entity.Property(e => e.AttributeMemberId).HasColumnName("AttributeMemberID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 4)");

                entity.HasOne(d => d.AccountObject)
                    .WithMany(p => p.AccountAttributeMemberEntries)
                    .HasForeignKey(d => d.AccountObjectId)
                    .HasConstraintName("FK_AccountAttributeMemberEntry_AccountObjectID");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.AccountAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_AccountAttributeMemberEntry_ModelAttributeMember");
            });

            modelBuilder.Entity<AccountCustodian>(entity =>
            {
                entity.ToTable("AccountCustodian", "EulerApp");

                entity.HasIndex(e => e.CustodianCode, "UNI_AccountCustodian_CustodianCode")
                    .IsUnique();

                entity.HasIndex(e => e.DisplayName, "UNI_AccountCustodian_DisplayName")
                    .IsUnique();

                entity.Property(e => e.AccountCustodianId).HasColumnName("AccountCustodianID");

                entity.Property(e => e.CustodianCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(72)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountGroup>(entity =>
            {
                entity.ToTable("AccountGroup", "EulerApp");

                entity.Property(e => e.AccountGroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountGroupID");

                entity.HasOne(d => d.AccountGroupNavigation)
                    .WithOne(p => p.AccountGroup)
                    .HasForeignKey<AccountGroup>(d => d.AccountGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountGroup_AccountObject");
            });

            modelBuilder.Entity<AccountGroupMember>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("AccountGroupMember", "EulerApp");

                entity.HasIndex(e => new { e.EntryDate, e.AccountId, e.AccountGroupId }, "UNI_AccountGroupMember_RowDef");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.AccountGroupId).HasColumnName("AccountGroupID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.ExitDate).HasColumnType("date");

                entity.HasOne(d => d.AccountGroup)
                    .WithMany(p => p.AccountGroupMembers)
                    .HasForeignKey(d => d.AccountGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountGroupMember_AccountGroup");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountGroupMembers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountGroupMember_Account");
            });

            modelBuilder.Entity<AccountObject>(entity =>
            {
                entity.ToTable("AccountObject", "EulerApp");

                entity.HasIndex(e => e.AccountObjectCode, "UNI_AccountObject_AccountObjectCode")
                    .IsUnique();

                entity.Property(e => e.AccountObjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountObjectID");

                entity.Property(e => e.AccountObjectCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CloseDate).HasColumnType("date");

                entity.Property(e => e.ObjectDescription)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectDipslayName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrefixedObjectCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(case when [AccountObject].[ObjectType]='g' then concat('+',[AccountObject].[AccountObjectCode]) else [AccountObject].[AccountObjectCode] end)", false);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<AccountWallet>(entity =>
            {
                entity.ToTable("AccountWallet", "EulerApp");

                entity.HasIndex(e => e.AddressCode, "UNI_AccountWallet_AddressCode")
                    .IsUnique();

                entity.HasIndex(e => e.AddressTag, "UNI_AccountWallet_AddressTag")
                    .IsUnique();

                entity.HasIndex(e => new { e.DenominationSecurityId, e.AccountId }, "UNI_AccountWallet_RowDef")
                    .IsUnique();

                entity.Property(e => e.AccountWalletId).HasColumnName("AccountWalletID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AddressCode)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.AddressTag)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DenominationSecurityId).HasColumnName("DenominationSecurityID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountWallets)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountWallet_Account");

                entity.HasOne(d => d.DenominationSecurity)
                    .WithMany(p => p.AccountWallets)
                    .HasForeignKey(d => d.DenominationSecurityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountWallet_Security");
            });

            modelBuilder.Entity<AuditEvent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("AuditEvent", "EulerApp");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventID");

                entity.Property(e => e.AuditUserId).HasColumnName("AuditUserID");

                entity.Property(e => e.EventTimeUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("EventTimeUTC");
            });

            modelBuilder.Entity<BankTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("BankTransaction", "EulerApp");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Comment)
                    .HasMaxLength(72)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BankTransactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankTransaction_Account");

                entity.HasOne(d => d.TransactionCode)
                    .WithMany(p => p.BankTransactions)
                    .HasForeignKey(d => d.TransactionCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankTransaction_BankTransactionCode");
            });

            modelBuilder.Entity<BankTransactionCode>(entity =>
            {
                entity.HasKey(e => e.TransactionCodeId)
                    .HasName("PK_BankTransactionSymbol");

                entity.ToTable("BankTransactionCode", "EulerApp");

                entity.HasIndex(e => e.DisplayName, "UNI_BankTransactionCode_DisplayName")
                    .IsUnique();

                entity.HasIndex(e => e.TransactionCode, "UNI_BankTransactionCode_TransactionCode")
                    .IsUnique();

                entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BankTransactionCodeAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("BankTransactionCodeAttributeMemberEntry", "EulerApp");

                entity.HasIndex(e => new { e.EffectiveDate, e.TransactionCodeId, e.AttributeMemberId }, "UNI_BankTransactionCodeAttributeMemberEntry_RowDef")
                    .IsUnique();

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.AttributeMemberId).HasColumnName("AttributeMemberID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 4)");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.BankTransactionCodeAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_BankTransactionCodeAttributeMemberEntry_ModelAttributeMember");

                entity.HasOne(d => d.TransactionCode)
                    .WithMany(p => p.BankTransactionCodeAttributeMemberEntries)
                    .HasForeignKey(d => d.TransactionCodeId)
                    .HasConstraintName("FK_BankTransactionCodeAttributeMemberEntry_BankTransactionCode");
            });

            modelBuilder.Entity<BrokerTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("BrokerTransaction", "EulerApp");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.DepSecurityId).HasColumnName("DepSecurityID");

                entity.Property(e => e.Fee).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(19, 6)");

                entity.Property(e => e.SecurityId).HasColumnName("SecurityID");

                entity.Property(e => e.SettleDate).HasColumnType("date");

                entity.Property(e => e.TaxLotId).HasColumnName("TaxLotID");

                entity.Property(e => e.TradeDate).HasColumnType("date");

                entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");

                entity.Property(e => e.Withholding).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BrokerTransactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrokerTransaction_Account");

                entity.HasOne(d => d.DepSecurity)
                    .WithMany(p => p.BrokerTransactionDepSecurities)
                    .HasForeignKey(d => d.DepSecurityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrokerTransaction_DepSecurityID");

                entity.HasOne(d => d.Security)
                    .WithMany(p => p.BrokerTransactionSecurities)
                    .HasForeignKey(d => d.SecurityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrokerTransaction_SecurityID");

                entity.HasOne(d => d.TransactionCode)
                    .WithMany(p => p.BrokerTransactions)
                    .HasForeignKey(d => d.TransactionCodeId)
                    .HasConstraintName("FK_BrokerTransaction_BrokerTransactionCode");
            });

            modelBuilder.Entity<BrokerTransactionCode>(entity =>
            {
                entity.HasKey(e => e.TransactionCodeId);

                entity.ToTable("BrokerTransactionCode", "EulerApp");

                entity.HasIndex(e => e.DisplayName, "UNI_BrokerTransactionCode_DisplayName")
                    .IsUnique();

                entity.HasIndex(e => e.TransactionCode, "UNI_BrokerTransactionCode_TransactionCode")
                    .IsUnique();

                entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<BrokerTransactionCodeAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId)
                    .HasName("PK_BrokerTransactionAttributeMemberEntry");

                entity.ToTable("BrokerTransactionCodeAttributeMemberEntry", "EulerApp");

                entity.HasIndex(e => new { e.EffectiveDate, e.TransactionCodeId, e.AttributeMemberId }, "UNI_BrokerTransactionCodeAttributeMemberEntry_RowDef")
                    .IsUnique();

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.AttributeMemberId).HasColumnName("AttributeMemberID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 4)");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.BrokerTransactionCodeAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_BrokerTransactionCodeAttributeMemberEntry_ModelAttributeMember");

                entity.HasOne(d => d.TransactionCode)
                    .WithMany(p => p.BrokerTransactionCodeAttributeMemberEntries)
                    .HasForeignKey(d => d.TransactionCodeId)
                    .HasConstraintName("FK_BrokerTransactionCodeAttributeMemberEntry_BrokerTransactionCode");
            });

            modelBuilder.Entity<BrokerTransactionTaxLot>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("BrokerTransactionTaxLot", "EulerApp");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("TransactionID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(19, 6)");

                entity.Property(e => e.TransactionIdcloseVersus).HasColumnName("TransactionIDCloseVersus");

                entity.HasOne(d => d.Transaction)
                    .WithOne(p => p.BrokerTransactionTaxLot)
                    .HasForeignKey<BrokerTransactionTaxLot>(d => d.TransactionId)
                    .HasConstraintName("FK_BrokerTransactionTaxLot_BrokerTransaction");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "EulerApp");

                entity.HasIndex(e => e.DisplayName, "UNI_Country_DisplayName")
                    .IsUnique();

                entity.HasIndex(e => e.IsoCode3, "UNI_Country_IsoCode3")
                    .IsUnique();

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.IsoCode3)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CountryAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("CountryAttributeMemberEntry", "EulerApp");

                entity.HasIndex(e => new { e.AttributeMemberId, e.CountryId, e.EffectiveDate }, "UNI_CountryAttributeMemberEntry_RowDef")
                    .IsUnique();

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.AttributeMemberId).HasColumnName("AttributeMemberID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 4)");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.CountryAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_CountryAttributeMemberEntry_ModelAttributeMember");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryAttributeMemberEntries)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_CountryAttributeMemberEntry_Country");
            });

            modelBuilder.Entity<InvestmentPerformanceAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("InvestmentPerformanceAttributeMemberEntry", "EulerApp");

                entity.HasIndex(e => new { e.FromDate, e.AccountObjectId, e.AttributeMemberId }, "UNI_InvestmentPerformanceAttributeMemberEntry_RowDef")
                    .IsUnique();

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.AccountObjectId).HasColumnName("AccountObjectID");

                entity.Property(e => e.AttributeMemberId).HasColumnName("AttributeMemberID");

                entity.Property(e => e.AverageCapital).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Gain).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Irr)
                    .HasColumnType("decimal(9, 4)")
                    .HasColumnName("IRR");

                entity.Property(e => e.MarketValue).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.NetContribution).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.AccountObject)
                    .WithMany(p => p.InvestmentPerformanceAttributeMemberEntries)
                    .HasForeignKey(d => d.AccountObjectId)
                    .HasConstraintName("FK_InvestmentPerformanceAttributeMemberEntry_AccountObject");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.InvestmentPerformanceAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvestmentPerformanceAttributeMemberEntry_ModelAttributeMember");
            });

            modelBuilder.Entity<InvestmentPerformanceEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("InvestmentPerformanceEntry", "EulerApp");

                entity.HasIndex(e => new { e.FromDate, e.AccountObjectId }, "UNI_InvestmentPerformanceEntry_RowDef")
                    .IsUnique();

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.AccountObjectId).HasColumnName("AccountObjectID");

                entity.Property(e => e.AverageCapital).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Gain).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Irr)
                    .HasColumnType("decimal(9, 4)")
                    .HasColumnName("IRR");

                entity.Property(e => e.MarketValue).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.NetContribution).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.AccountObject)
                    .WithMany(p => p.InvestmentPerformanceEntries)
                    .HasForeignKey(d => d.AccountObjectId)
                    .HasConstraintName("FK_InvestmentPerformanceEntry_AccountObject");
            });

            modelBuilder.Entity<InvestmentStrategy>(entity =>
            {
                entity.ToTable("InvestmentStrategy", "EulerApp");

                entity.HasIndex(e => e.DisplayName, "UNI_InvestmentStrategy_DisplayName")
                    .IsUnique();

                entity.Property(e => e.InvestmentStrategyId).HasColumnName("InvestmentStrategyID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InvestmentStrategyTarget>(entity =>
            {
                entity.ToTable("InvestmentStrategyTarget", "EulerApp");

                entity.HasIndex(e => new { e.EffectiveDate, e.AttributeMemberId, e.InvestmentStrategyId }, "UNI_InvestmentStrategyTarget_RowDef")
                    .IsUnique();

                entity.Property(e => e.InvestmentStrategyTargetId).HasColumnName("InvestmentStrategyTargetID");

                entity.Property(e => e.AttributeMemberId).HasColumnName("AttributeMemberID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.InvestmentStrategyId).HasColumnName("InvestmentStrategyID");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.InvestmentStrategyTargets)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvestmentStrategyTarget_ModelAttributeMember");

                entity.HasOne(d => d.InvestmentStrategy)
                    .WithMany(p => p.InvestmentStrategyTargets)
                    .HasForeignKey(d => d.InvestmentStrategyId)
                    .HasConstraintName("FK_InvestmentStrategyTarget_InvestmentStrategy");
            });

            modelBuilder.Entity<MarketHoliday>(entity =>
            {
                entity.ToTable("MarketHoliday", "EulerApp");

                entity.HasIndex(e => e.MarketHolidayName, "UNI_MarketHoliday_MarketHolidayName")
                    .IsUnique();

                entity.Property(e => e.MarketHolidayId).HasColumnName("MarketHolidayID");

                entity.Property(e => e.MarketHolidayName)
                    .IsRequired()
                    .HasMaxLength(72);
            });

            modelBuilder.Entity<MarketHolidaySchedule>(entity =>
            {
                entity.HasKey(e => e.MarketHolidayEntryId)
                    .HasName("PK_MarketHolidayScheduleEntry");

                entity.ToTable("MarketHolidaySchedule", "EulerApp");

                entity.HasIndex(e => new { e.ObservanceDate, e.MarketHolidayId }, "UNI_MarketHolidaySchedule_RowDef")
                    .IsUnique();

                entity.Property(e => e.MarketHolidayEntryId).HasColumnName("MarketHolidayEntryID");

                entity.Property(e => e.MarketHolidayId).HasColumnName("MarketHolidayID");

                entity.Property(e => e.ObservanceDate).HasColumnType("date");

                entity.HasOne(d => d.MarketHoliday)
                    .WithMany(p => p.MarketHolidaySchedules)
                    .HasForeignKey(d => d.MarketHolidayId)
                    .HasConstraintName("FK_MarketHolidayScheduleMarketHoliday");
            });

            modelBuilder.Entity<MarketIndex>(entity =>
            {
                entity.HasKey(e => e.IndexId);

                entity.ToTable("MarketIndex", "EulerApp");

                entity.HasIndex(e => e.IndexCode, "UNI_MarketIndex_IndexCode")
                    .IsUnique();

                entity.Property(e => e.IndexId).HasColumnName("IndexID");

                entity.Property(e => e.IndexCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IndexDescription)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarketIndexPrice>(entity =>
            {
                entity.HasKey(e => e.IndexPriceId);

                entity.ToTable("MarketIndexPrice", "EulerApp");

                entity.HasIndex(e => new { e.PriceDate, e.MarketIndexId, e.PriceCode }, "UNI_MarketIndexPrice_RowDef")
                    .IsUnique();

                entity.Property(e => e.IndexPriceId).HasColumnName("IndexPriceID");

                entity.Property(e => e.MarketIndexId).HasColumnName("MarketIndexID");

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PriceCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PriceDate).HasColumnType("date");

                entity.HasOne(d => d.MarketIndex)
                    .WithMany(p => p.MarketIndexPrices)
                    .HasForeignKey(d => d.MarketIndexId)
                    .HasConstraintName("FK_MarketIndexPrice_MarketIndex");
            });

            modelBuilder.Entity<ModelAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId);

                entity.ToTable("ModelAttribute", "EulerApp");

                entity.HasIndex(e => e.DisplayName, "UNI_ModelAttribute_DisplayName")
                    .IsUnique();

                entity.Property(e => e.AttributeId)
                    .ValueGeneratedNever()
                    .HasColumnName("AttributeID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModelAttributeMember>(entity =>
            {
                entity.HasKey(e => e.AttributeMemberId);

                entity.ToTable("ModelAttributeMember", "EulerApp");

                entity.HasIndex(e => new { e.DisplayName, e.AttributeId }, "UNI_ModelAttributeMember_RowDef")
                    .IsUnique();

                entity.Property(e => e.AttributeMemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("AttributeMemberID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ModelAttributeMembers)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_ModelAttributeMember_ModelAttribute");
            });

            modelBuilder.Entity<ModelAttributeScope>(entity =>
            {
                entity.HasKey(e => e.AttributeScopeId);

                entity.ToTable("ModelAttributeScope", "EulerApp");

                entity.HasIndex(e => new { e.AttributeId, e.ScopeCode }, "UNI_ModelAttributeScope_AttributeID_ScopeCode")
                    .IsUnique();

                entity.Property(e => e.AttributeScopeId).HasColumnName("AttributeScopeID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.ScopeCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ModelAttributeScopes)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_ModelAttributeScope_ModelAttribute");
            });

            modelBuilder.Entity<ReportConfiguration>(entity =>
            {
                entity.HasKey(e => e.ConfigurationId)
                    .HasName("PK_ReportSetting");

                entity.ToTable("ReportConfiguration", "EulerApp");

                entity.HasIndex(e => e.ConfigurationCode, "UNI_ReportConfiguration_ConfigurationCode")
                    .IsUnique();

                entity.Property(e => e.ConfigurationId).HasColumnName("ConfigurationID");

                entity.Property(e => e.ConfigurationCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigurationDescription)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.XmlDefinition)
                    .IsRequired()
                    .HasColumnType("xml");
            });

            modelBuilder.Entity<ReportStyleSheet>(entity =>
            {
                entity.HasKey(e => e.StyleSheetId);

                entity.ToTable("ReportStyleSheet", "EulerApp");

                entity.HasIndex(e => e.StyleSheetCode, "UNI_ReportStyleSheet_StyleSheetCode")
                    .IsUnique();

                entity.Property(e => e.StyleSheetId).HasColumnName("StyleSheetID");

                entity.Property(e => e.StyleSheetCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.StyleSheetDescription)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.XmlDefinition)
                    .IsRequired()
                    .HasColumnType("xml");
            });

            modelBuilder.Entity<ResourceImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("ResourceImage", "EulerApp");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ImageBinary).IsRequired();

                entity.Property(e => e.ImageDescription)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.ToTable("Security", "EulerApp");

                entity.Property(e => e.SecurityId).HasColumnName("SecurityID");

                entity.Property(e => e.CurrentSymbol)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Issuer)
                    .IsRequired()
                    .HasMaxLength(96);

                entity.Property(e => e.SecurityDescription)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityExchangeId).HasColumnName("SecurityExchangeID");

                entity.Property(e => e.SecurityTypeId).HasColumnName("SecurityTypeID");

                entity.HasOne(d => d.SecurityExchange)
                    .WithMany(p => p.Securities)
                    .HasForeignKey(d => d.SecurityExchangeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Security_SecurityExchange");

                entity.HasOne(d => d.SecurityType)
                    .WithMany(p => p.Securities)
                    .HasForeignKey(d => d.SecurityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_SecurityType");
            });

            modelBuilder.Entity<SecurityAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("SecurityAttributeMemberEntry", "EulerApp");

                entity.HasIndex(e => new { e.EffectiveDate, e.SecurityId, e.AttributeMemberId }, "UNI_SecurityAttributeMemberEntry_RowDef")
                    .IsUnique();

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.AttributeMemberId).HasColumnName("AttributeMemberID");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.SecurityId).HasColumnName("SecurityID");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 4)");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.SecurityAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_SecurityAttributeMemberEntry_ModelAttributeMember");

                entity.HasOne(d => d.Security)
                    .WithMany(p => p.SecurityAttributeMemberEntries)
                    .HasForeignKey(d => d.SecurityId)
                    .HasConstraintName("FK_SecurityAttributeMemberEntry_Security");
            });

            modelBuilder.Entity<SecurityExchange>(entity =>
            {
                entity.HasKey(e => e.ExchangeId);

                entity.ToTable("SecurityExchange", "EulerApp");

                entity.HasIndex(e => e.ExchangeCode, "UNI_SecurityExchange_ExchangeCode")
                    .IsUnique();

                entity.Property(e => e.ExchangeId).HasColumnName("ExchangeID");

                entity.Property(e => e.ExchangeCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeDescription).HasMaxLength(128);
            });

            modelBuilder.Entity<SecurityPrice>(entity =>
            {
                entity.HasKey(e => e.PriceId);

                entity.ToTable("SecurityPrice", "EulerApp");

                entity.HasIndex(e => new { e.PriceDate, e.SecurityId }, "UNI_SecurityPrice_RowDef")
                    .IsUnique();

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.PriceClose).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PriceDate).HasColumnType("date");

                entity.Property(e => e.PriceHigh).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PriceLow).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PriceOpen).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.SecurityId).HasColumnName("SecurityID");

                entity.HasOne(d => d.Security)
                    .WithMany(p => p.SecurityPrices)
                    .HasForeignKey(d => d.SecurityId)
                    .HasConstraintName("FK_SecurityPrice_Security");
            });

            modelBuilder.Entity<SecuritySymbol>(entity =>
            {
                entity.HasKey(e => e.SymbolId);

                entity.ToTable("SecuritySymbol", "EulerApp");

                entity.HasIndex(e => new { e.SecurityId, e.EffectiveDate }, "UNI_SecuritySymbol_Column")
                    .IsUnique();

                entity.Property(e => e.SymbolId).HasColumnName("SymbolID");

                entity.Property(e => e.Cusip)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomSymbol)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.OptionTicker)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityId).HasColumnName("SecurityID");

                entity.Property(e => e.SymbolCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(case when [SecuritySymbol].[SymbolTypeID]=(1) then [SecuritySymbol].[Cusip] when [SecuritySymbol].[SymbolTypeID]=(2) then [SecuritySymbol].[CustomSymbol] when [SecuritySymbol].[SymbolTypeID]=(3) then [SecuritySymbol].[OptionTicker] when [SecuritySymbol].[SymbolTypeID]=(4) then [SecuritySymbol].[Ticker]  end)", false);

                entity.Property(e => e.SymbolTypeId).HasColumnName("SymbolTypeID");

                entity.Property(e => e.Ticker)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Security)
                    .WithMany(p => p.SecuritySymbols)
                    .HasForeignKey(d => d.SecurityId)
                    .HasConstraintName("FK_SecuritySymbol_Security");

                entity.HasOne(d => d.SymbolType)
                    .WithMany(p => p.SecuritySymbols)
                    .HasForeignKey(d => d.SymbolTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecuritySymbol_SecuritySymbolType");
            });

            modelBuilder.Entity<SecuritySymbolMap>(entity =>
            {
                entity.HasKey(e => e.SymbolMapId);

                entity.ToTable("SecuritySymbolMap", "EulerApp");

                entity.HasIndex(e => new { e.SecuritySymbolId, e.AccountCustodianId }, "UNI_SecuritySymbolMap_RowDef")
                    .IsUnique();

                entity.Property(e => e.SymbolMapId)
                    .ValueGeneratedNever()
                    .HasColumnName("SymbolMapID");

                entity.Property(e => e.AccountCustodianId).HasColumnName("AccountCustodianID");

                entity.Property(e => e.CustodianSymbol)
                    .IsRequired()
                    .HasMaxLength(72)
                    .IsUnicode(false);

                entity.Property(e => e.SecuritySymbolId).HasColumnName("SecuritySymbolID");

                entity.HasOne(d => d.AccountCustodian)
                    .WithMany(p => p.SecuritySymbolMaps)
                    .HasForeignKey(d => d.AccountCustodianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecuritySymbolMap_AccountCustodian");

                entity.HasOne(d => d.SecuritySymbol)
                    .WithMany(p => p.SecuritySymbolMaps)
                    .HasForeignKey(d => d.SecuritySymbolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecuritySymbolMap_SecuritySymbol");
            });

            modelBuilder.Entity<SecuritySymbolType>(entity =>
            {
                entity.HasKey(e => e.SymbolTypeId);

                entity.ToTable("SecuritySymbolType", "EulerApp");

                entity.HasIndex(e => e.SymbolTypeName, "UNI_SecuritySymbolType_TypeName")
                    .IsUnique();

                entity.Property(e => e.SymbolTypeId).HasColumnName("SymbolTypeID");

                entity.Property(e => e.SymbolTypeName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SecurityType>(entity =>
            {
                entity.ToTable("SecurityType", "EulerApp");

                entity.HasIndex(e => e.SecurityTypeName, "UNI_SecurityType_SecurityTypeName")
                    .IsUnique();

                entity.Property(e => e.SecurityTypeId).HasColumnName("SecurityTypeID");

                entity.Property(e => e.SecurityTypeGroupId).HasColumnName("SecurityTypeGroupID");

                entity.Property(e => e.SecurityTypeName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ValuationFactor).HasColumnType("decimal(7, 4)");

                entity.HasOne(d => d.SecurityTypeGroup)
                    .WithMany(p => p.SecurityTypes)
                    .HasForeignKey(d => d.SecurityTypeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityType_SecurityTypeGroup");
            });

            modelBuilder.Entity<SecurityTypeGroup>(entity =>
            {
                entity.ToTable("SecurityTypeGroup", "EulerApp");

                entity.HasIndex(e => e.SecurityTypeGroupName, "UNI_SecurityTypeGroup_SecurityTypeGroupName")
                    .IsUnique();

                entity.Property(e => e.SecurityTypeGroupId).HasColumnName("SecurityTypeGroupID");

                entity.Property(e => e.SecurityTypeGroupName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("AccountObjectID", "EulerApp");

            modelBuilder.HasSequence("seqAuditEventID", "EulerApp").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
