using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EulerFinancial.Model;

namespace EulerFinancial.Context
{
    public partial class EulerDbContext : DbContext
    {
        public EulerDbContext()
        {
        }

        public EulerDbContext(DbContextOptions<EulerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; } = null!;
        public virtual DbSet<AccountComposite> AccountComposites { get; set; } = null!;
        public virtual DbSet<AccountCompositeMember> AccountCompositeMembers { get; set; } = null!;
        public virtual DbSet<AccountCustodian> AccountCustodians { get; set; } = null!;
        public virtual DbSet<AccountObject> AccountObjects { get; set; } = null!;
        public virtual DbSet<AccountWallet> AccountWallets { get; set; } = null!;
        public virtual DbSet<AuditEvent> AuditEvents { get; set; } = null!;
        public virtual DbSet<BankTransaction> BankTransactions { get; set; } = null!;
        public virtual DbSet<BankTransactionCode> BankTransactionCodes { get; set; } = null!;
        public virtual DbSet<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; } = null!;
        public virtual DbSet<BrokerTransaction> BrokerTransactions { get; set; } = null!;
        public virtual DbSet<BrokerTransactionCode> BrokerTransactionCodes { get; set; } = null!;
        public virtual DbSet<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; } = null!;
        public virtual DbSet<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; } = null!;
        public virtual DbSet<InvestmentPerformanceEntry> InvestmentPerformanceEntries { get; set; } = null!;
        public virtual DbSet<InvestmentStrategy> InvestmentStrategies { get; set; } = null!;
        public virtual DbSet<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; } = null!;
        public virtual DbSet<MarketHoliday> MarketHolidays { get; set; } = null!;
        public virtual DbSet<MarketHolidaySchedule> MarketHolidaySchedules { get; set; } = null!;
        public virtual DbSet<MarketIndex> MarketIndices { get; set; } = null!;
        public virtual DbSet<MarketIndexPrice> MarketIndexPrices { get; set; } = null!;
        public virtual DbSet<ModelAttribute> ModelAttributes { get; set; } = null!;
        public virtual DbSet<ModelAttributeMember> ModelAttributeMembers { get; set; } = null!;
        public virtual DbSet<ModelAttributeScope> ModelAttributeScopes { get; set; } = null!;
        public virtual DbSet<ReportConfiguration> ReportConfigurations { get; set; } = null!;
        public virtual DbSet<ReportStyleSheet> ReportStyleSheets { get; set; } = null!;
        public virtual DbSet<ResourceImage> ResourceImages { get; set; } = null!;
        public virtual DbSet<Security> Securities { get; set; } = null!;
        public virtual DbSet<SecurityAttributeMemberEntry> SecurityAttributeMemberEntries { get; set; } = null!;
        public virtual DbSet<SecurityExchange> SecurityExchanges { get; set; } = null!;
        public virtual DbSet<SecurityPrice> SecurityPrices { get; set; } = null!;
        public virtual DbSet<SecuritySymbol> SecuritySymbols { get; set; } = null!;
        public virtual DbSet<SecuritySymbolMap> SecuritySymbolMaps { get; set; } = null!;
        public virtual DbSet<SecuritySymbolType> SecuritySymbolTypes { get; set; } = null!;
        public virtual DbSet<SecurityType> SecurityTypes { get; set; } = null!;
        public virtual DbSet<SecurityTypeGroup> SecurityTypeGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:EulerFinancial");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).UseCollation("Latin1_General_BIN2");

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
                entity.HasOne(d => d.AccountObject)
                    .WithMany(p => p.AccountAttributeMemberEntries)
                    .HasForeignKey(d => d.AccountObjectId)
                    .HasConstraintName("FK_AccountAttributeMemberEntry_AccountObjectID");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.AccountAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_AccountAttributeMemberEntry_ModelAttributeMember");
            });

            modelBuilder.Entity<AccountComposite>(entity =>
            {
                entity.Property(e => e.AccountCompositeId).ValueGeneratedNever();

                entity.HasOne(d => d.AccountCompositeNavigation)
                    .WithOne(p => p.AccountComposite)
                    .HasForeignKey<AccountComposite>(d => d.AccountCompositeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountComposite_AccountObject");
            });

            modelBuilder.Entity<AccountCompositeMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_AccountCommpositeMember");

                entity.HasOne(d => d.AccountComposite)
                    .WithMany(p => p.AccountCompositeMembers)
                    .HasForeignKey(d => d.AccountCompositeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountCommpositeMember_AccountComposite");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountCompositeMembers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountCommpositeMember_Account");
            });

            modelBuilder.Entity<AccountObject>(entity =>
            {
                entity.Property(e => e.ObjectType).IsFixedLength();

                entity.Property(e => e.PrefixedObjectCode).HasComputedColumnSql("(case when [ObjectType]='c' then concat('+',[AccountObjectCode]) else [AccountObjectCode] end)", false);
            });

            modelBuilder.Entity<AccountWallet>(entity =>
            {
                entity.Property(e => e.AddressCode).UseCollation("Latin1_General_BIN2");

                entity.Property(e => e.AddressTag).UseCollation("Latin1_General_BIN2");

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
                entity.Property(e => e.EventId).ValueGeneratedNever();
            });

            modelBuilder.Entity<BankTransaction>(entity =>
            {
                entity.Property(e => e.TransactionVersion)
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
            });

            modelBuilder.Entity<BankTransactionCodeAttributeMemberEntry>(entity =>
            {
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

                entity.HasOne(d => d.TaxLot)
                    .WithMany(p => p.InverseTaxLot)
                    .HasForeignKey(d => d.TaxLotId)
                    .HasConstraintName("FK_BrokerTransaction_BrokerTransaction");

                entity.HasOne(d => d.TransactionCode)
                    .WithMany(p => p.BrokerTransactions)
                    .HasForeignKey(d => d.TransactionCodeId)
                    .HasConstraintName("FK_BrokerTransaction_BrokerTransactionCode");
            });

            modelBuilder.Entity<BrokerTransactionCode>(entity =>
            {
                entity.Property(e => e.TransactionCode).IsFixedLength();
            });

            modelBuilder.Entity<BrokerTransactionCodeAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => e.EntryId)
                    .HasName("PK_BrokerTransactionAttributeMemberEntry");

                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.BrokerTransactionCodeAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_BrokerTransactionCodeAttributeMemberEntry_ModelAttributeMember");

                entity.HasOne(d => d.TransactionCode)
                    .WithMany(p => p.BrokerTransactionCodeAttributeMemberEntries)
                    .HasForeignKey(d => d.TransactionCodeId)
                    .HasConstraintName("FK_BrokerTransactionCodeAttributeMemberEntry_BrokerTransactionCode");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.IsoCode3).IsFixedLength();
            });

            modelBuilder.Entity<CountryAttributeMemberEntry>(entity =>
            {
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
                entity.HasOne(d => d.AccountObject)
                    .WithMany(p => p.InvestmentPerformanceEntries)
                    .HasForeignKey(d => d.AccountObjectId)
                    .HasConstraintName("FK_InvestmentPerformanceEntry_AccountObject");
            });

            modelBuilder.Entity<InvestmentStrategyTarget>(entity =>
            {
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

            modelBuilder.Entity<MarketHolidaySchedule>(entity =>
            {
                entity.HasKey(e => e.MarketHolidayEntryId)
                    .HasName("PK_MarketHolidayScheduleEntry");

                entity.HasOne(d => d.MarketHoliday)
                    .WithMany(p => p.MarketHolidaySchedules)
                    .HasForeignKey(d => d.MarketHolidayId)
                    .HasConstraintName("FK_MarketHolidayScheduleMarketHoliday");
            });

            modelBuilder.Entity<MarketIndexPrice>(entity =>
            {
                entity.Property(e => e.PriceCode).IsFixedLength();

                entity.HasOne(d => d.MarketIndex)
                    .WithMany(p => p.MarketIndexPrices)
                    .HasForeignKey(d => d.MarketIndexId)
                    .HasConstraintName("FK_MarketIndexPrice_MarketIndex");
            });

            modelBuilder.Entity<ModelAttribute>(entity =>
            {
                entity.Property(e => e.AttributeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ModelAttributeMember>(entity =>
            {
                entity.Property(e => e.AttributeMemberId).ValueGeneratedNever();

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ModelAttributeMembers)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_ModelAttributeMember_ModelAttribute");
            });

            modelBuilder.Entity<ModelAttributeScope>(entity =>
            {
                entity.Property(e => e.ScopeCode).IsFixedLength();

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ModelAttributeScopes)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_ModelAttributeScope_ModelAttribute");
            });

            modelBuilder.Entity<ReportConfiguration>(entity =>
            {
                entity.HasKey(e => e.ConfigurationId)
                    .HasName("PK_ReportSetting");
            });

            modelBuilder.Entity<Security>(entity =>
            {
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
                entity.HasOne(d => d.AttributeMember)
                    .WithMany(p => p.SecurityAttributeMemberEntries)
                    .HasForeignKey(d => d.AttributeMemberId)
                    .HasConstraintName("FK_SecurityAttributeMemberEntry_ModelAttributeMember");

                entity.HasOne(d => d.Security)
                    .WithMany(p => p.SecurityAttributeMemberEntries)
                    .HasForeignKey(d => d.SecurityId)
                    .HasConstraintName("FK_SecurityAttributeMemberEntry_Security");
            });

            modelBuilder.Entity<SecurityPrice>(entity =>
            {
                entity.HasOne(d => d.Security)
                    .WithMany(p => p.SecurityPrices)
                    .HasForeignKey(d => d.SecurityId)
                    .HasConstraintName("FK_SecurityPrice_Security");
            });

            modelBuilder.Entity<SecuritySymbol>(entity =>
            {
                entity.Property(e => e.Cusip).IsFixedLength();

                entity.Property(e => e.SymbolCode).HasComputedColumnSql("(case when [SecuritySymbol].[SymbolTypeID]=(-10) then [SecuritySymbol].[Cusip] when [SecuritySymbol].[SymbolTypeID]=(-20) then [SecuritySymbol].[CustomSymbol] when [SecuritySymbol].[SymbolTypeID]=(-30) then [SecuritySymbol].[OptionTicker] when [SecuritySymbol].[SymbolTypeID]=(-40) then [SecuritySymbol].[Ticker]  end)", false);

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
                entity.Property(e => e.SymbolMapId).ValueGeneratedNever();

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

            modelBuilder.Entity<SecurityType>(entity =>
            {
                entity.HasOne(d => d.SecurityTypeGroup)
                    .WithMany(p => p.SecurityTypes)
                    .HasForeignKey(d => d.SecurityTypeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityType_SecurityTypeGroup");
            });

            modelBuilder.HasSequence("seqAuditEventID", "EulerApp").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
