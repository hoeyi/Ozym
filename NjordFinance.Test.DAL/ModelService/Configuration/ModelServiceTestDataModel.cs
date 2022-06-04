using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Context.Configuration;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;

namespace NjordFinance.Test.ModelService.Configuration
{
    /// <summary>
    /// A collection of models to seed for integration testing.
    /// </summary>
    internal class ModelServiceTestDataModel : ISeedData
    {
        private readonly Random _random = new();

        /// <inheritdoc/>
        public ModelServiceTestDataModel()
        {
            AccountCustodians = new AccountCustodian[]
            {
                new()
                {
                    AccountCustodianId = -1,
                    CustodianCode = "SOMEWHERE",
                    DisplayName = "SomeWhere Bank LLC"
                },
                new()
                {
                    AccountCustodianId = -2,
                    CustodianCode = "SOMENAME",
                    DisplayName = "Some Name Securities Broker"
                },
                new()
                {
                    AccountCustodianId = -3,
                    CustodianCode = "CRYPTO",
                    DisplayName = "Cryptopotamus Coin Exchange"
                },
                new()
                {
                    AccountCustodianId = -4,
                    CustodianCode = "TESTDELPASS",
                    DisplayName = "Test delete pass"
                },
                new()
                {
                    AccountCustodianId = -5,
                    CustodianCode = "TESTUPDATE",
                    DisplayName = "Test update pass"
                }
            };

            AccountObjects = new AccountObject[]
            {
                new()
                {
                    AccountObjectId = -5,
                    AccountObjectCode = "TESTBROKER",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Broker Account",
                    ObjectDescription = "For testing functionality of broker acccount records."
                },
                new()
                {
                    AccountObjectId = -6,
                    AccountObjectCode = "TESTBANK",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Bank Account",
                    ObjectDescription = "For testing functionality of bank account records."
                },
                new()
                {
                    AccountObjectId = -7,
                    AccountObjectCode = "TESTCRYPTO",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Crypto Account",
                    ObjectDescription = "For testing functionality of crypto broker account records."
                },
                new()
                {
                    AccountObjectId = -1,
                    AccountObjectCode = "TESTDELPASS",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST DELETE PASS",
                    ObjectDescription = "Lorem ipsum dolor sit amet"
                },
                new()
                {
                    AccountObjectId = -2,
                    AccountObjectCode = "TESTUPDPASS",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST UPDATE PASS",
                    ObjectDescription = "sed do eiusmod ",
                    StartDate = new DateTime(
                                _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1, 28))
                },
                new()
                {
                    AccountObjectId = -3,
                    AccountObjectCode = "TESTDELPASSC",
                    ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                    ObjectDisplayName = "TEST DELETE PASS",
                    ObjectDescription = "sed aasdfa dsfapgotpokn",
                    StartDate = new DateTime(
                                    _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1,28))
                },
                new()
                {
                    AccountObjectId = -4,
                    AccountObjectCode = "TESTUPDATEC",
                    ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                    ObjectDisplayName = "TEST UPDATE PASS",
                    ObjectDescription = "sed fafdjuq dsfaplkokn",
                    StartDate = new DateTime(
                                    _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1,28))
                },
                new()
                {
                    AccountObjectId = -8,
                    AccountObjectCode = "TESTMEMBERS",
                    ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                    ObjectDisplayName = "TEST HAS MEMBERS",
                    ObjectDescription = "sed aadfg asfijgc",
                    StartDate = new DateTime(
                        _random.Next(1975, 2022), _random.Next(1,12), _random.Next(1,28))
                }
            };

            Accounts = new Account[]
            {
                new Account()
                {
                    AccountId = -5,
                    IsComplianceTradable = true,
                    HasBrokerTransaction = true,
                    AccountCustodianId = -2
                },
                new Account()
                {
                    AccountId = -6,
                    IsComplianceTradable = false,
                    HasBankTransaction = true
                },
                new Account()
                {
                    AccountId = -7,
                    IsComplianceTradable = true,
                    HasBrokerTransaction = true,
                    HasWallet = true,
                    AccountCustodianId = -3
                },
                new Account()
                {
                    AccountId = -1,
                    AccountNumber = "0000-0000-00"
                },
                new Account()
                {
                    AccountId = -2,
                    AccountNumber = "0000-0000-00"
                }
            };

            AccountWallets = new AccountWallet[]
            {
                new(){
                    AccountWalletId = -1, AccountId = -7, DenominationSecurityId = -5,
                    AddressCode = "5F32C68C-415C-4612-AA29-14D6FE0940C6", AddressTag = "ABC"},
                new(){ AccountWalletId = -2, AccountId = -7, DenominationSecurityId = -6,
                    AddressCode= "2E34D0C0-6DC7-4DC6-86C4-F0B3A4A1BEBE"}
            };

            AccountComposites = new AccountComposite[]
            {
                new(){ AccountCompositeId = -3 },
                new(){ AccountCompositeId = -4 },
                new() { AccountCompositeId = -8 }
            };

            AccountCompositeMembers = new AccountCompositeMember[]
            {
                new()
                {
                    AccountId = -5,
                    AccountCompositeId = -8,
                    EntryDate = GetRandomDateTime(),
                    Comment = "Test #1"
                },
                new()
                {
                    AccountId = -6,
                    AccountCompositeId = -8,
                    EntryDate = GetRandomDateTime(),
                    Comment = "Test #2"
                }
            };

            BankTransactionCodes = new BankTransactionCode[]
            {
                new() { TransactionCodeId = -2, TransactionCode = "UPDPASS", DisplayName = "Test update pass" },
                new() { TransactionCodeId = -1, TransactionCode = "DELPASS", DisplayName = "Test delete pass"},
                new() { TransactionCodeId = -3, TransactionCode = "balance", DisplayName = "Initial Balance" },
                new() { TransactionCodeId = -4, TransactionCode = "salary", DisplayName = "Salary/Wage" },
                new() { TransactionCodeId = -5, TransactionCode = "statetax", DisplayName = "State Tax Paid" },
                new() { TransactionCodeId = -6, TransactionCode = "timeoff", DisplayName = "Unused Paid Time-Off" },
                new() { TransactionCodeId = -7, TransactionCode = "travel", DisplayName = "Travel" },
                new() { TransactionCodeId = -8, TransactionCode = "401k", DisplayName = "401k Contribution" },
                new() { TransactionCodeId = -9, TransactionCode = "auto", DisplayName = "Automotive" }
            };

            BankTransactions = new BankTransaction[]
            {
                new(){ TransactionId = -2, AccountId = -6, TransactionDate = new DateTime(2002, 9, 21), TransactionCodeId = -7, Amount = 100M, Comment = "Test add"},
                new(){ TransactionId = -1, AccountId = -6, TransactionDate = new DateTime(2003, 1, 15), TransactionCodeId = -8, Amount = 100M, Comment = "Test remove"},
                new(){ TransactionId = -3, AccountId = -6, TransactionDate = new DateTime(2007, 3, 6), TransactionCodeId = -6, Amount = 64.97M, Comment = "Example: Unused Paid Time-Off"},
                new(){ TransactionId = -4, AccountId = -6, TransactionDate = new DateTime(2004, 4, 10), TransactionCodeId = -6, Amount = 67.24M, Comment = "Example: Unused Paid Time-Off"},
                new(){ TransactionId = -5, AccountId = -6, TransactionDate = new DateTime(2020, 8, 13), TransactionCodeId = -4, Amount = 12.29M, Comment = "Example: Salary/Wage"},
                new(){ TransactionId = -6, AccountId = -6, TransactionDate = new DateTime(2022, 10, 14), TransactionCodeId = -6, Amount = 20.59M, Comment = "Example: Unused Paid Time-Off"},
                new(){ TransactionId = -7, AccountId = -6, TransactionDate = new DateTime(2002, 12, 8), TransactionCodeId = -5, Amount = 95.76M, Comment = "Example: State Tax Paid"},
                new(){ TransactionId = -8, AccountId = -6, TransactionDate = new DateTime(2017, 9, 9), TransactionCodeId = -6, Amount = 25.59M, Comment = "Example: Unused Paid Time-Off"},
                new(){ TransactionId = -9, AccountId = -6, TransactionDate = new DateTime(2000, 8, 13), TransactionCodeId = -4, Amount = 64.28M, Comment = "Example: Salary/Wage"},
                new(){ TransactionId = -10, AccountId = -6, TransactionDate = new DateTime(2010, 2, 8), TransactionCodeId = -8, Amount = 97.73M, Comment = "Example: 401k Contribution"},
                new(){ TransactionId = -11, AccountId = -6, TransactionDate = new DateTime(2008, 8, 3), TransactionCodeId = -5, Amount = 95.95M, Comment = "Example: State Tax Paid"},
                new(){ TransactionId = -12, AccountId = -6, TransactionDate = new DateTime(2015, 10, 9), TransactionCodeId = -4, Amount = 69.21M, Comment = "Example: Salary/Wage"},
                new(){ TransactionId = -13, AccountId = -6, TransactionDate = new DateTime(2017, 9, 26), TransactionCodeId = -8, Amount = 53.99M, Comment = "Example: 401k Contribution"},
                new(){ TransactionId = -14, AccountId = -6, TransactionDate = new DateTime(2003, 3, 17), TransactionCodeId = -4, Amount = 79.99M, Comment = "Example: Salary/Wage"},
                new(){ TransactionId = -15, AccountId = -6, TransactionDate = new DateTime(2003, 11, 27), TransactionCodeId = -7, Amount = 12.86M, Comment = "Example: Travel"},
                new(){ TransactionId = -16, AccountId = -6, TransactionDate = new DateTime(2006, 10, 4), TransactionCodeId = -5, Amount = 27.25M, Comment = "Example: State Tax Paid"},
                new(){ TransactionId = -17, AccountId = -6, TransactionDate = new DateTime(2002, 3, 1), TransactionCodeId = -7, Amount = 56.77M, Comment = "Example: Travel"},
                new(){ TransactionId = -18, AccountId = -6, TransactionDate = new DateTime(2016, 9, 28), TransactionCodeId = -7, Amount = 4.39M, Comment = "Example: Travel"},
                new(){ TransactionId = -19, AccountId = -6, TransactionDate = new DateTime(2010, 11, 16), TransactionCodeId = -7, Amount = 42.37M, Comment = "Example: Travel"},
                new(){ TransactionId = -20, AccountId = -6, TransactionDate = new DateTime(2011, 8, 20), TransactionCodeId = -7, Amount = 59.36M, Comment = "Example: Travel"},
                new(){ TransactionId = -21, AccountId = -6, TransactionDate = new DateTime(2015, 6, 21), TransactionCodeId = -6, Amount = 74.64M, Comment = "Example: Unused Paid Time-Off"},
                new(){ TransactionId = -22, AccountId = -6, TransactionDate = new DateTime(2015, 6, 12), TransactionCodeId = -8, Amount = 22.38M, Comment = "Example: 401k Contribution"},
                new(){ TransactionId = -23, AccountId = -6, TransactionDate = new DateTime(2000, 7, 21), TransactionCodeId = -4, Amount = 1.77M, Comment = "Example: Salary/Wage"},
                new(){ TransactionId = -24, AccountId = -6, TransactionDate = new DateTime(2001, 7, 10), TransactionCodeId = -9, Amount = -5.22M, Comment = "Example: Automotive"},
                new(){ TransactionId = -25, AccountId = -6, TransactionDate = new DateTime(2021, 2, 15), TransactionCodeId = -6, Amount = -7.7M, Comment = "Example: Unused Paid Time-Off"},
                new(){ TransactionId = -26, AccountId = -6, TransactionDate = new DateTime(2003, 1, 3), TransactionCodeId = -9, Amount = -7.71M, Comment = "Example: Automotive"},
            };

            BrokerTransactionCodes = new BrokerTransactionCode[]
            {
                new()
                {
                    TransactionCodeId = -1,
                    TransactionCode = "TDP",
                    DisplayName = "Test delete pass",
                    QuantityEffect = 1,
                    ContributionWithdrawalEffect = 1,
                    CashEffect = 1
                },
                new()
                {
                    TransactionCodeId = -2,
                    TransactionCode = "TUP",
                    DisplayName = "Test update pass",
                    QuantityEffect = 1,
                    ContributionWithdrawalEffect = 1,
                    CashEffect = 1
                }
            };

            InvestmentStrategies = new InvestmentStrategy[]
            {
                new(){ InvestmentStrategyId = -1, DisplayName = "Test delete pass" },
                new(){ InvestmentStrategyId = -2, DisplayName = "Test update pass" }
            };

            MarketHolidays = new MarketHoliday[]
            {
                new(){ MarketHolidayId = -1, MarketHolidayName = "Test delete pass" },
                new() { MarketHolidayId = -2, MarketHolidayName = "Test update pass"}
            };

            MarketIndices = new MarketIndex[]
            {
                new(){ IndexId = -1, IndexCode = "DELETEPASS", IndexDescription = "Test delete pass" },
                new(){ IndexId = -2, IndexCode = "UPDATEPASS", IndexDescription = "Test update pass" }
            };

            ModelAttributes = new ModelAttribute[]
            {
                new(){ AttributeId = -1, DisplayName = "Test delete pass" },
                new(){ AttributeId = -2, DisplayName = "Test update pass" },
                new(){ AttributeId = -3, DisplayName = "Account Type" }
            };

            ReportConfigurations = new ReportConfiguration[]
            {
                new()
                {
                    ConfigurationId = -1,
                    ConfigurationCode = "TestDeletePass",
                    ConfigurationDescription = "Test delete pass",
                    XmlDefinition = Resources.DefaultConfiguration.Report_Parameters
                },
                new()
                {
                    ConfigurationId = -2,
                    ConfigurationCode = "TestUpdatePass",
                    ConfigurationDescription = "Test update pass",
                    XmlDefinition = Resources.DefaultConfiguration.Report_Parameters
                }
            };

            ReportStyleSheets = new ReportStyleSheet[]
            {
                new()
                {
                    StyleSheetId = -1,
                    StyleSheetCode = "TestDeletePass",
                    StyleSheetDescription = "Test delete pass",
                    XmlDefinition = Resources.DefaultConfiguration.Report_StyleSheet
                },
                new()
                {
                    StyleSheetId = -2,
                    StyleSheetCode = "TestUpdatePass",
                    StyleSheetDescription = "Test update pass",
                    XmlDefinition = Resources.DefaultConfiguration.Report_StyleSheet
                }
            };

            ResourceImages = new ResourceImage[]
            {
                new()
                {
                    ImageId = -1,
                    ImageDescription = "Test delete pass",
                    ImageBinary = Resources.Images.fractal_circle_icon_dark,
                    FileExtension = "PNG"
                },
                new()
                {
                    ImageId = -2,
                    ImageDescription = "Test update pass",
                    ImageBinary = Resources.Images.fractal_circle_icon_dark,
                    FileExtension = "JPG"
                }
            };

            Securities = new Security[]
            {
                new()
                {
                    SecurityId = -1,
                    SecurityTypeId = -300,
                    SecurityDescription = "Microsoft Inc.",
                    SecurityExchangeId = -2,
                },
                new()
                {
                    SecurityId = -2,
                    SecurityTypeId = -300,
                    SecurityDescription = "Apple Inc.",
                    SecurityExchangeId = -2,
                },
                new()
                {
                    SecurityId = -3,
                    SecurityTypeId = -300,
                    SecurityDescription = "JP Morgan Chase Co.",
                    SecurityExchangeId = -1
                },
                new()
                {
                    SecurityId = -4,
                    SecurityTypeId = -312,
                    SecurityDescription = "Bitcoin",
                    HasPerpetualMarket = true
                },
                new()
                {
                    SecurityId = -5,
                    SecurityTypeId = -312,
                    SecurityDescription = "Litecoin",
                    HasPerpetualMarket = true
                },
                new()
                {
                    SecurityId = -6,
                    SecurityTypeId = -312,
                    SecurityDescription = "Ether",
                    HasPerpetualMarket = true
                },
                new()
                {
                    SecurityId = -7,
                    SecurityTypeId = -301,
                    SecurityDescription = "Volkswagen ADR",
                    SecurityExchangeId = -1
                },
                new()
                {
                    SecurityId = -8,
                    SecurityTypeId = -310,
                    SecurityDescription = "MSFT 3/15/2023 Call 375.00"
                },
                new()
                {
                    SecurityId = -9,
                    SecurityTypeId = -304,
                    SecurityDescription = "Apple Inc 3.5% 6/30/2025"
                },
                new()
                {
                    SecurityId = -10,
                    SecurityDescription = "Test delete pass",
                    SecurityExchangeId = -2,
                    HasPerpetualMarket = true,
                    HasPerpetualPrice = false,
                    SecurityTypeId = -302
                },
                new()
                {
                    SecurityId = -11,
                    SecurityDescription = "Test update pass",
                    SecurityExchangeId = -1,
                    HasPerpetualMarket = true,
                    HasPerpetualPrice = false,
                    SecurityTypeId = -310
                }
            };

            SecuritySymbolTypes = new SecuritySymbolType[]
            {
                new(){ SymbolTypeId = -1, SymbolTypeName = "TestDeletePass" },
                new(){ SymbolTypeId = -2, SymbolTypeName = "TestUpdatePass" }
            };

            SecuritySymbols = new SecuritySymbol[]
            {
                new()
                {
                    SymbolId = -1,
                    SecurityId = -1,
                    SymbolTypeId = -40,
                    Ticker = "MSFT",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -2,
                    SecurityId = -2,
                    SymbolTypeId = -40,
                    Ticker = "AAPL",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -3,
                    SecurityId = -3,
                    SymbolTypeId = -40,
                    Ticker = "JPM",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -4,
                    SecurityId = -4,
                    SymbolTypeId = -20,
                    CustomSymbol = "BTC",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -5,
                    SecurityId = -5,
                    SymbolTypeId = -20,
                    CustomSymbol = "LTC",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -6,
                    SecurityId = -6,
                    SymbolTypeId = -20,
                    CustomSymbol = "ETH",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -7,
                    SecurityId = -7,
                    SymbolTypeId = -40,
                    Ticker = "VWAGY",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -8,
                    SecurityId = -8,
                    SymbolTypeId = -30,
                    OptionTicker = "MSFT230315C0030000",
                    EffectiveDate = GetRandomDateTime()
                },
                new()
                {
                    SymbolId = -9,
                    SecurityId = -9,
                    SymbolTypeId = -10,
                    Cusip = "ABC123XYZ"
                }
            };

            SecurityExchanges = new SecurityExchange[]
            {
                new SecurityExchange()
                {
                    ExchangeId = -1,
                    ExchangeCode = "NYSE",
                    ExchangeDescription = "New York Stock Exchange"
                },
                new SecurityExchange()
                {
                    ExchangeId = -2,
                    ExchangeCode = "NASDAQ",
                    ExchangeDescription = "Nasdaq Stock Market"
                },
                new()
                {
                    ExchangeId = -3,
                    ExchangeCode = "TestDeletePass",
                    ExchangeDescription = "Test delete pass"
                },
                new()
                {
                    ExchangeId = -4,
                    ExchangeCode = "TestUpdatePass",
                    ExchangeDescription = "Test update pass"
                }
            };

            SecurityTypeGroups = new SecurityTypeGroup[]
            {
                new()
                {
                    SecurityTypeGroupId = -1,
                    SecurityTypeGroupName = "Test delete pass",
                },
                new()
                {
                    SecurityTypeGroupId = -2,
                    SecurityTypeGroupName = "Test update pass"
                }
            };

            SecurityTypes = new SecurityType[]
            {
                new()
                {
                    SecurityTypeId = -3,
                    SecurityTypeGroupId = -202,
                    SecurityTypeName = "Test delete pass"
                },
                new()
                {
                    SecurityTypeId = -4,
                    SecurityTypeGroupId = -203,
                    SecurityTypeName = "Test update pass"
                }
            };

            ModelAttributeMembers = SecurityTypeGroups
                .Select(s => new ModelAttributeMember
                {
                    AttributeId = -20,
                    AttributeMemberId = s.SecurityTypeGroupId,
                    DisplayName = s.SecurityTypeGroupName,
                    DisplayOrder = (short)Array.IndexOf(SecurityTypeGroups, s)
                })
                .Concat(SecurityTypes.Select(s => new ModelAttributeMember()
                {
                    AttributeId = -30,
                    AttributeMemberId = s.SecurityTypeId,
                    DisplayName = s.SecurityTypeName,
                    DisplayOrder = (short)Array.IndexOf(SecurityTypes, s)
                }))
                .Concat(new ModelAttributeMember[]
                {
                    new(){ AttributeMemberId = -10, AttributeId = -3, DisplayName = "IRA" },
                    new(){ AttributeMemberId = -11, AttributeId = -3, DisplayName = "ROTH" },
                    new(){ AttributeMemberId = -12, AttributeId = -3, DisplayName = "401K" }
                })
                .ToArray();

            AccountAttributes = new AccountAttributeMemberEntry[]
            {
                new()
                {
                    AccountObjectId = -3,
                    AttributeMemberId = -10,
                    EffectiveDate = GetRandomDateTime(),
                    Weight = 1M
                },
                new()
                {
                    AccountObjectId = -4,
                    AttributeMemberId = -11,
                    EffectiveDate = GetRandomDateTime(),
                    Weight = 1M
                }
            };
        }

        /// <inheritdoc/>
        public AccountAttributeMemberEntry[] AccountAttributes { get; }

        /// <inheritdoc/>
        public AccountCompositeMember[] AccountCompositeMembers { get; }

        /// <inheritdoc/>
        public AccountComposite[] AccountComposites { get; }

        /// <inheritdoc/>
        public AccountCustodian[] AccountCustodians { get; }

        /// <inheritdoc/>
        public AccountObject[] AccountObjects { get; }

        /// <inheritdoc/>
        public Account[] Accounts { get; }

        /// <inheritdoc/>
        public AccountWallet[] AccountWallets { get; }

        /// <inheritdoc/>
        public BankTransactionCodeAttributeMemberEntry[] BankTransactionCodeAttributes { get; }

        /// <inheritdoc/>
        public BankTransactionCode[] BankTransactionCodes { get; }

        /// <inheritdoc/>
        public BankTransaction[] BankTransactions { get; }

        /// <inheritdoc/>
        public BrokerTransactionCodeAttributeMemberEntry[] BrokerTransactionCodeAttributes { get; }

        /// <inheritdoc/>
        public BrokerTransactionCode[] BrokerTransactionCodes { get; }

        /// <inheritdoc/>
        public BrokerTransaction[] BrokerTransactions { get; }

        /// <inheritdoc/>
        public Country[] Countries { get; }

        /// <inheritdoc/>
        public CountryAttributeMemberEntry[] CountryAttributes { get; }

        /// <inheritdoc/>
        public InvestmentPerformanceAttributeMemberEntry[] InvestmentPerformanceAttributeEntries { get; }

        /// <inheritdoc/>
        public InvestmentPerformanceEntry[] InvestmentPerformanceEntries { get; }

        /// <inheritdoc/>
        public InvestmentStrategy[] InvestmentStrategies { get; }

        /// <inheritdoc/>
        public InvestmentStrategyTarget[] InvestmentStrategyTargets { get; }

        /// <inheritdoc/>
        public MarketHoliday[] MarketHolidays { get; }

        /// <inheritdoc/>
        public MarketHolidayObservance[] MarketHolidayObservances { get; }

        /// <inheritdoc/>
        public MarketIndexPrice[] MarketIndexPrices { get; }

        /// <inheritdoc/>
        public MarketIndex[] MarketIndices { get; }

        /// <inheritdoc/>
        public ModelAttributeMember[] ModelAttributeMembers { get; }

        /// <inheritdoc/>
        public ModelAttribute[] ModelAttributes { get; }

        /// <inheritdoc/>
        public ReportConfiguration[] ReportConfigurations { get; }

        /// <inheritdoc/>
        public ReportStyleSheet[] ReportStyleSheets { get; }

        /// <inheritdoc/>
        public ResourceImage[] ResourceImages { get; }

        /// <inheritdoc/>
        public Security[] Securities { get; }

        /// <inheritdoc/>
        public SecurityAttributeMemberEntry[] SecurityAttributes { get; }

        /// <inheritdoc/>
        public SecurityExchange[] SecurityExchanges { get; }

        /// <inheritdoc/>
        public SecurityPrice[] SecurityPrices { get; }

        /// <inheritdoc/>
        public SecuritySymbol[] SecuritySymbols { get; }

        /// <inheritdoc/>
        public SecuritySymbolType[] SecuritySymbolTypes { get; }

        /// <inheritdoc/>
        public SecurityTypeGroup[] SecurityTypeGroups { get; }

        /// <inheritdoc/>
        public SecurityType[] SecurityTypes { get; }

        private DateTime GetRandomDateTime()
            => DateTime.Now.AddDays(_random.Next(0, 7200) * -1);
    }
}
