using Microsoft.EntityFrameworkCore;
using EulerFinancial.Model;

#nullable disable

namespace EulerFinancial.Context
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
                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).IsUnicode(false);

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

            modelBuilder.Entity<AccountCustodian>(entity =>
            {
                entity.Property(e => e.CustodianCode).IsUnicode(false);

                entity.Property(e => e.DisplayName).IsUnicode(false);
            });

            modelBuilder.Entity<AccountGroup>(entity =>
            {
                entity.Property(e => e.AccountGroupId).ValueGeneratedNever();

                entity.HasOne(d => d.AccountGroupNavigation)
                    .WithOne(p => p.AccountGroup)
                    .HasForeignKey<AccountGroup>(d => d.AccountGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountGroup_AccountObject");
            });

            modelBuilder.Entity<AccountGroupMember>(entity =>
            {
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
                entity.Property(e => e.AccountObjectId).HasDefaultValueSql("(NEXT VALUE FOR [EulerApp].[seqAccountObjectID])");

                entity.Property(e => e.AccountObjectCode).IsUnicode(false);

                entity.Property(e => e.ObjectDescription).IsUnicode(false);

                entity.Property(e => e.ObjectDipslayName).IsUnicode(false);

                entity.Property(e => e.ObjectType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrefixedObjectCode)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(case when [AccountObject].[ObjectType]='g' then concat('+',[AccountObject].[AccountObjectCode]) else [AccountObject].[AccountObjectCode] end)", false);
            });

            modelBuilder.Entity<AccountWallet>(entity =>
            {
                entity.Property(e => e.AddressCode).IsUnicode(false);

                entity.Property(e => e.AddressTag).IsUnicode(false);

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
                entity.Property(e => e.Comment).IsUnicode(false);

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

                entity.Property(e => e.DisplayName).IsUnicode(false);

                entity.Property(e => e.TransactionCode).IsUnicode(false);
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

                entity.HasOne(d => d.TransactionCode)
                    .WithMany(p => p.BrokerTransactions)
                    .HasForeignKey(d => d.TransactionCodeId)
                    .HasConstraintName("FK_BrokerTransaction_BrokerTransactionCode");
            });

            modelBuilder.Entity<BrokerTransactionCode>(entity =>
            {
                entity.Property(e => e.DisplayName).IsUnicode(false);

                entity.Property(e => e.TransactionCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);
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

            modelBuilder.Entity<BrokerTransactionTaxLot>(entity =>
            {
                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.HasOne(d => d.Transaction)
                    .WithOne(p => p.BrokerTransactionTaxLot)
                    .HasForeignKey<BrokerTransactionTaxLot>(d => d.TransactionId)
                    .HasConstraintName("FK_BrokerTransactionTaxLot_BrokerTransaction");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.IsoCode3)
                    .IsUnicode(false)
                    .IsFixedLength(true);
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

            modelBuilder.Entity<InvestmentStrategy>(entity =>
            {
                entity.Property(e => e.DisplayName).IsUnicode(false);
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

            modelBuilder.Entity<MarketIndex>(entity =>
            {
                entity.Property(e => e.IndexCode).IsUnicode(false);

                entity.Property(e => e.IndexDescription).IsUnicode(false);
            });

            modelBuilder.Entity<MarketIndexPrice>(entity =>
            {
                entity.Property(e => e.PriceCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MarketIndex)
                    .WithMany(p => p.MarketIndexPrices)
                    .HasForeignKey(d => d.MarketIndexId)
                    .HasConstraintName("FK_MarketIndexPrice_MarketIndex");
            });

            modelBuilder.Entity<ModelAttribute>(entity =>
            {
                entity.Property(e => e.AttributeId).ValueGeneratedNever();

                entity.Property(e => e.DisplayName).IsUnicode(false);
            });

            modelBuilder.Entity<ModelAttributeMember>(entity =>
            {
                entity.Property(e => e.AttributeMemberId).ValueGeneratedNever();

                entity.Property(e => e.DisplayName).IsUnicode(false);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ModelAttributeMembers)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_ModelAttributeMember_ModelAttribute");
            });

            modelBuilder.Entity<ModelAttributeScope>(entity =>
            {
                entity.Property(e => e.ScopeCode)
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

                entity.Property(e => e.ConfigurationCode).IsUnicode(false);

                entity.Property(e => e.ConfigurationDescription).IsUnicode(false);
            });

            modelBuilder.Entity<ReportStyleSheet>(entity =>
            {
                entity.Property(e => e.StyleSheetCode).IsUnicode(false);

                entity.Property(e => e.StyleSheetDescription).IsUnicode(false);
            });

            modelBuilder.Entity<ResourceImage>(entity =>
            {
                entity.Property(e => e.FileExtension).IsUnicode(false);

                entity.Property(e => e.ImageDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.Property(e => e.SecurityDescription).IsUnicode(false);

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

            modelBuilder.Entity<SecurityExchange>(entity =>
            {
                entity.Property(e => e.ExchangeCode).IsUnicode(false);
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
                entity.Property(e => e.Cusip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomSymbol).IsUnicode(false);

                entity.Property(e => e.OptionTicker).IsUnicode(false);

                entity.Property(e => e.SymbolCode)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(case when [SecuritySymbol].[SymbolTypeID]=(1) then [SecuritySymbol].[Cusip] when [SecuritySymbol].[SymbolTypeID]=(2) then [SecuritySymbol].[CustomSymbol] when [SecuritySymbol].[SymbolTypeID]=(3) then [SecuritySymbol].[OptionTicker] when [SecuritySymbol].[SymbolTypeID]=(4) then [SecuritySymbol].[Ticker]  end)", false);

                entity.Property(e => e.Ticker).IsUnicode(false);

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

                entity.Property(e => e.CustodianSymbol).IsUnicode(false);

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
                entity.Property(e => e.SymbolTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<SecurityType>(entity =>
            {
                entity.Property(e => e.SecurityTypeName).IsUnicode(false);

                entity.HasOne(d => d.SecurityTypeGroup)
                    .WithMany(p => p.SecurityTypes)
                    .HasForeignKey(d => d.SecurityTypeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityType_SecurityTypeGroup");
            });

            modelBuilder.Entity<SecurityTypeGroup>(entity =>
            {
                entity.Property(e => e.SecurityTypeGroupName).IsUnicode(false);
            });

            modelBuilder.HasSequence("AccountObjectID", "EulerApp");

            modelBuilder.HasSequence<int>("seqAccountObjectID", "EulerApp");

            modelBuilder.HasSequence("seqAuditEventID", "EulerApp").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
