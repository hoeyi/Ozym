using Microsoft.EntityFrameworkCore;

namespace NjordinSight.EntityModel.Context
{
    public partial class FinanceDbContext : DbContext
    {
        public FinanceDbContext()
        {
        }

        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; }
        public virtual DbSet<AccountComposite> AccountComposites { get; set; }
        public virtual DbSet<AccountCompositeMember> AccountCompositeMembers { get; set; }
        public virtual DbSet<AccountCustodian> AccountCustodians { get; set; }
        public virtual DbSet<AccountObject> AccountObjects { get; set; }
        public virtual DbSet<AccountWallet> AccountWallets { get; set; }
        public virtual DbSet<AuditEvent> AuditEvents { get; set; }
        public virtual DbSet<BankTransaction> BankTransactions { get; set; }
        public virtual DbSet<BankTransactionCode> BankTransactionCodes { get; set; }
        public virtual DbSet<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; }
        public virtual DbSet<BrokerTransaction> BrokerTransactions { get; set; }
        public virtual DbSet<BrokerTransactionCode> BrokerTransactionCodes { get; set; }
        public virtual DbSet<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
        public virtual DbSet<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; }
        public virtual DbSet<InvestmentPerformanceEntry> InvestmentPerformanceEntries { get; set; }
        public virtual DbSet<InvestmentStrategy> InvestmentStrategies { get; set; }
        public virtual DbSet<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
        public virtual DbSet<MarketHoliday> MarketHolidays { get; set; }
        public virtual DbSet<MarketHolidayObservance> MarketHolidaySchedules { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).UseCollation("Latin1_General_BIN2");

                entity.HasOne(e => e.AccountCustodian)
                    .WithMany(c => c.Accounts)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Account_AccountCustodian");
            });

            modelBuilder.Entity<AccountAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => 
                    new { e.AttributeMemberId, e.AccountObjectId, e.EffectiveDate });

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
                entity.HasKey(e => 
                    new { e.AccountCompositeId, e.AccountId, e.EntryDate });

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

            modelBuilder.Entity<AccountCustodian>(entity =>
            {
                entity.HasIndex(e => e.CustodianCode, "UNI_AccountCustodian_CustodianCode")
                    .IsUnique()
                    .HasFilter("([CustodianCode] IS NOT NULL)");

                entity.HasIndex(e => e.DisplayName, "UNI_AccountCustodian_DisplayName")
                    .IsUnique()
                    .HasFilter("([DisplayName] IS NOT NULL)");
            });

            modelBuilder.Entity<AccountObject>(entity =>
            {
                entity.HasIndex(e => e.AccountObjectCode, "UNI_AccountObject_AccountObjectCode")
                    .IsUnique()
                    .HasFilter("([AccountObjectCode] IS NOT NULL)");

                entity.Property(e => e.ObjectType).IsFixedLength();

                if (ConfigureForSqlServer)
                    entity.Property(e => e.PrefixedObjectCode)
                        .HasComputedColumnSql(
                            "(case when [ObjectType]='c' then concat('+',[AccountObjectCode]) else [AccountObjectCode] end)", false);
                else
                    entity.Property(e => e.PrefixedObjectCode).IsRequired(false);

                entity.HasCheckConstraint(
                    name: "CK_AccountObject_ObjectType",
                    sql: "[ObjectType] IN ('c','a')");
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
                if (ConfigureForSqlServer)
                    entity.Property(e => e.TransactionVersion)
                        .IsRowVersion()
                        .IsConcurrencyToken();
                else
                    entity.Property(e => e.TransactionVersion).IsRequired(false);

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

                entity.HasIndex(e => e.DisplayName, "UNI_BankTransactionCode_DisplayName")
                    .IsUnique()
                    .HasFilter("([DisplayName] IS NOT NULL)");

                entity.HasIndex(e => e.TransactionCode, "UNI_BankTransactionCode_TransactionCode")
                    .IsUnique()
                    .HasFilter("([TransactionCode] IS NOT NULL)");
            });

            modelBuilder.Entity<BankTransactionCodeAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e => 
                    new { e.AttributeMemberId, e.TransactionCodeId, e.EffectiveDate });

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrokerTransaction_BrokerTransactionCode");
            });

            modelBuilder.Entity<BrokerTransactionCode>(entity =>
            {
                entity.HasIndex(e => e.DisplayName, "UNI_BrokerTransactionCode_DisplayName")
                    .IsUnique()
                    .HasFilter("([DisplayName] IS NOT NULL)");

                entity.HasIndex(e => e.TransactionCode, "UNI_BrokerTransactionCode_TransactionCode")
                    .IsUnique()
                    .HasFilter("([TransactionCode] IS NOT NULL)");

                entity.Property(e => e.TransactionCode).IsFixedLength();
            });

            modelBuilder.Entity<BrokerTransactionCodeAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e =>
                    new { e.AttributeMemberId, e.TransactionCodeId, e.EffectiveDate });

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
                entity.HasIndex(e => e.DisplayName, "UNI_Country_DisplayName")
                    .IsUnique()
                    .HasFilter("([DisplayName] IS NOT NULL)");

                entity.HasIndex(e => e.IsoCode3, "UNI_Country_IsoCode3")
                    .IsUnique()
                    .HasFilter("([IsoCode3] IS NOT NULL)");

                entity.Property(e => e.IsoCode3).IsFixedLength();

                entity.HasOne(d => d.AttributeMemberNavigation)
                    .WithOne(p => p.Country)
                    .HasForeignKey<Country>(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Country_ModelAttributeMember");
            });

            modelBuilder.Entity<CountryAttributeMemberEntry>(entity =>
            {
                entity.HasKey(e =>
                    new { e.AttributeMemberId, e.CountryId, e.EffectiveDate });

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
                entity.HasKey(e =>
                    new { e.AccountObjectId, e.AttributeMemberId, e.FromDate });

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
                entity.HasKey(e =>
                    new { e.AccountObjectId, e.FromDate });

                entity.HasOne(d => d.AccountObject)
                    .WithMany(p => p.InvestmentPerformanceEntries)
                    .HasForeignKey(d => d.AccountObjectId)
                    .HasConstraintName("FK_InvestmentPerformanceEntry_AccountObject");
            });

            modelBuilder.Entity<InvestmentStrategy>(entity =>
            {
                entity.HasIndex(e => e.DisplayName, "UNI_InvestmentStrategy_DisplayName")
                    .IsUnique()
                    .HasFilter("([DisplayName] IS NOT NULL)");
            });

            modelBuilder.Entity<InvestmentStrategyTarget>(entity =>
            {
                entity.HasKey(e =>
                    new { e.InvestmentStrategyId, e.AttributeMemberId, e.EffectiveDate });

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
                entity.HasIndex(e => e.MarketHolidayName, "UNI_MarketHoliday_MarketHolidayName")
                    .IsUnique()
                    .HasFilter("([MarketHolidayName] IS NOT NULL)");
            });

            modelBuilder.Entity<MarketHolidayObservance>(entity =>
            {
                entity.HasKey(e => new { e.MarketHolidayId, e.ObservanceDate });

                entity.HasOne(d => d.MarketHoliday)
                    .WithMany(p => p.MarketHolidaySchedules)
                    .HasForeignKey(d => d.MarketHolidayId)
                    .HasConstraintName("FK_MarketHolidayObservance_MarketHoliday");
            });

            modelBuilder.Entity<MarketIndex>(entity =>
            {
                entity.HasIndex(e => e.IndexCode, "UNI_MarketIndex_IndexCode")
                    .IsUnique()
                    .HasFilter("([IndexCode] IS NOT NULL)");
            });

            modelBuilder.Entity<MarketIndexPrice>(entity =>
            {
                entity.HasIndex(e => new { e.PriceDate, e.MarketIndexId, e.PriceCode }, "UNI_MarketIndexPrice_RowDef")
                    .IsUnique()
                    .HasFilter("([PriceCode] IS NOT NULL)");

                entity.Property(e => e.PriceCode).IsFixedLength();

                entity.HasOne(d => d.MarketIndex)
                    .WithMany(p => p.MarketIndexPrices)
                    .HasForeignKey(d => d.MarketIndexId)
                    .HasConstraintName("FK_MarketIndexPrice_MarketIndex");

                entity.HasCheckConstraint(
                    name: "CK_MarketIndexPrice_PriceCode",
                    sql: "[PriceCode] IN ('p','t')");
            });

            modelBuilder.Entity<ModelAttribute>(entity =>
            {
                entity.HasIndex(e => e.DisplayName, "UNI_ModelAttribute_DisplayName")
                    .IsUnique()
                    .HasFilter("([DisplayName] IS NOT NULL)");
            });

            modelBuilder.Entity<ModelAttributeMember>(entity =>
            {
                entity.HasIndex(e => new { e.DisplayName, e.AttributeId }, "UNI_ModelAttributeMember_RowDef")
                    .IsUnique()
                    .HasFilter("([DisplayName] IS NOT NULL)");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ModelAttributeMembers)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_ModelAttributeMember_ModelAttribute");
            });

            modelBuilder.Entity<ModelAttributeScope>(entity =>
            {
                entity.HasKey(e => new { e.AttributeId, e.ScopeCode });
                entity.HasCheckConstraint(
                    name: "CK_ModelAttributeScope_ScopeCode",
                    sql: "[ScopeCode] in ('acc', 'bnk', 'brk', 'cou', 'cus', 'exc', 'sec')");
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

                entity.HasIndex(e => e.ConfigurationCode, "UNI_ReportConfiguration_ConfigurationCode")
                    .IsUnique()
                    .HasFilter("([ConfigurationCode] IS NOT NULL)");
            });

            modelBuilder.Entity<ReportStyleSheet>(entity =>
            {
                entity.HasIndex(e => e.StyleSheetCode, "UNI_ReportStyleSheet_StyleSheetCode")
                    .IsUnique()
                    .HasFilter("([StyleSheetCode] IS NOT NULL)");
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
                entity.HasKey(e =>
                    new { e.AttributeMemberId, e.SecurityId, e.EffectiveDate });

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
                entity.HasIndex(e => e.ExchangeCode, "UNI_SecurityExchange_ExchangeCode")
                    .IsUnique()
                    .HasFilter("([ExchangeCode] IS NOT NULL)");
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

                if (ConfigureForSqlServer)
                    entity.Property(e => e.SymbolCode)
                        .HasComputedColumnSql(
                            "(case when [SymbolTypeID]=(-10) then [Cusip] when [SymbolTypeID]=(-20) then [CustomSymbol] when [SymbolTypeID]=(-30) then [OptionTicker] when [SymbolTypeID]=(-40) then [Ticker]  end)", 
                            true);
                else
                    entity.Property(e => e.SymbolCode).IsRequired(false);


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
                entity.HasIndex(e => e.SymbolTypeName, "UNI_SecuritySymbolType_TypeName")
                    .IsUnique()
                    .HasFilter("([SymbolTypeName] IS NOT NULL)");
            });

            modelBuilder.Entity<SecurityType>(entity =>
            {
                entity.HasIndex(e => e.SecurityTypeName, "UNI_SecurityType_SecurityTypeName")
                    .IsUnique()
                    .HasFilter("([SecurityTypeName] IS NOT NULL)");

                entity.Property(e => e.SecurityTypeId).ValueGeneratedNever();

                entity.HasOne(d => d.SecurityTypeGroup)
                    .WithMany(p => p.SecurityTypes)
                    .HasForeignKey(d => d.SecurityTypeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityType_SecurityTypeGroup");

                entity.HasOne(d => d.AttributeMemberNavigation)
                    .WithOne(p => p.SecurityType)
                    .HasForeignKey<SecurityType>(d => d.SecurityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityType_ModelAttributeMember");
            });

            modelBuilder.Entity<SecurityTypeGroup>(entity =>
            {
                entity.HasIndex(e => e.SecurityTypeGroupName, "UNI_SecurityTypeGroup_SecurityTypeGroupName")
                    .IsUnique()
                    .HasFilter("([SecurityTypeGroupName] IS NOT NULL)");

                entity.Property(e => e.SecurityTypeGroupId).ValueGeneratedNever();

                entity.HasOne(d => d.AttributeMemberNavigation)
                    .WithOne(p => p.SecurityTypeGroup)
                    .HasForeignKey<SecurityTypeGroup>(d => d.SecurityTypeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityTypeGroup_ModelAttributeMember");
            });

            modelBuilder.HasSequence("seqAuditEventID", "FinanceApp").HasMin(1);

            modelBuilder.HasSequence<int>("seqModelAttributeMember", "FinanceApp");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
