using System;
using System.Linq;
using NjordinSight.EntityModel.Context.Configuration;
using NjordinSight.EntityModel;

namespace NjordinSight.EntityModel.Context.Configuration
{
    /// <summary>
    /// A collection of models to seed for integration testing.
    /// </summary>
    internal class TestModelServiceDataModel : ISeedData
    {
        private readonly Random _random = new();

        /// <inheritdoc/>
        public TestModelServiceDataModel()
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
                new(){ InvestmentStrategyId = -2, DisplayName = "Test update pass" },
                new(){ InvestmentStrategyId = -3, DisplayName = "Global Equity" },
                new()
                { 
                    InvestmentStrategyId = -4, 
                    DisplayName = "Retirement", 
                    Notes = "- Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." + 
                        "\n- Porttitor rhoncus dolor purus non enim praesent." +
                        "\n- Convallis a cras semper auctor neque vitae tempus."
                }
            };

            MarketHolidays = new MarketHoliday[]
            {
                new(){ MarketHolidayId = -1, MarketHolidayName = "Test delete pass" },
                new() { MarketHolidayId = -2, MarketHolidayName = "Test update pass"}
            };

            MarketIndices = new MarketIndex[]
            {
                new(){ IndexId = -1, IndexCode = "DELETEPASS", IndexDescription = "Test delete pass" },
                new(){ IndexId = -2, IndexCode = "UPDATEPASS", IndexDescription = "Test update pass" },
                new(){ IndexId = -3, IndexCode = "NYSE", IndexDescription = "New York Stock Exchange", },
                new(){ IndexId = -4, IndexCode = "DAX", IndexDescription = "Deutscher Aktienindex" }
            };

            MarketIndexPrices = new MarketIndexPrice[]
            {
                new()
                {
                    IndexPriceId = -1,
                    MarketIndexId = -3,
                    PriceCode = MarketIndexPriceCode.PriceReturn.ConvertToStringCode(),
                    PriceDate = GetRandomDateTime(),
                    Price = (decimal)(_random.NextDouble() / Math.PI * 1000)
                },
                new()
                {
                    IndexPriceId = -2,
                    MarketIndexId = -4,
                    PriceCode = MarketIndexPriceCode.PriceReturn.ConvertToStringCode(),
                    PriceDate = GetRandomDateTime(),
                    Price = (decimal)(_random.NextDouble() / Math.PI * 1000)
                },
                new()
                {
                    IndexPriceId = -3,
                    MarketIndexId = -4,
                    PriceCode = MarketIndexPriceCode.PriceReturn.ConvertToStringCode(),
                    PriceDate = GetRandomDateTime(),
                    Price = (decimal)(_random.NextDouble() / Math.PI * 1000)
                },
                new()
                {
                    IndexPriceId = -4,
                    MarketIndexId = -4,
                    PriceCode = MarketIndexPriceCode.PriceReturn.ConvertToStringCode(),
                    PriceDate = GetRandomDateTime(),
                    Price = (decimal)(_random.NextDouble() / Math.PI * 1000)
                },
                new()
                {
                    IndexPriceId = -5,
                    MarketIndexId = -4,
                    PriceCode = MarketIndexPriceCode.PriceReturn.ConvertToStringCode(),
                    PriceDate = GetRandomDateTime(),
                    Price = (decimal)(_random.NextDouble() / Math.PI * 1000)
                },
                new()
                {
                    IndexPriceId = -6,
                    MarketIndexId = -3,
                    PriceCode = MarketIndexPriceCode.TotalReturn.ConvertToStringCode(),
                    PriceDate = GetRandomDateTime(),
                    Price = (decimal)(_random.NextDouble() / Math.PI * 1000)
                },
                new()
                {
                    IndexPriceId = -7,
                    MarketIndexId = -4,
                    PriceCode = MarketIndexPriceCode.TotalReturn.ConvertToStringCode(),
                    PriceDate = GetRandomDateTime(),
                    Price = (decimal)(_random.NextDouble() / Math.PI * 1000)
                }
            };

            ModelAttributes = new ModelAttribute[]
            {
                new(){ AttributeId = -1, DisplayName = "Test delete pass" },
                new(){ AttributeId = -2, DisplayName = "Test update pass" },
                new(){ AttributeId = -3, DisplayName = "Account Type" },
                new(){ AttributeId = -4, DisplayName = "Economic Development" },
                new(){ AttributeId = -5, DisplayName = "Class" },
                new(){ AttributeId = -6, DisplayName = "Category" }
            };

            ModelAttributeScopes = new ModelAttributeScope[]
            {
                new(){ AttributeId = -1, ScopeCode = ModelAttributeScopeCode.Account.ConvertToStringCode() },
                new(){ AttributeId = -2, ScopeCode = ModelAttributeScopeCode.Exchange.ConvertToStringCode() },
                new(){ AttributeId = -3, ScopeCode = ModelAttributeScopeCode.Account.ConvertToStringCode() },
                new(){ AttributeId = -4, ScopeCode = ModelAttributeScopeCode.Country.ConvertToStringCode() },
                new(){ AttributeId = -5, ScopeCode = ModelAttributeScopeCode.BankTransactionCode.ConvertToStringCode() },
                new(){ AttributeId = -6, ScopeCode = ModelAttributeScopeCode.BrokerTransactionCode.ConvertToStringCode() },
            };

            ReportConfigurations = new ReportConfiguration[]
            {
                new()
                {
                    ConfigurationId = -1,
                    ConfigurationCode = "TestDeletePass",
                    ConfigurationDescription = "Test delete pass",
                    XmlDefinition = DefaultConfiguration.Report_Parameters
                },
                new()
                {
                    ConfigurationId = -2,
                    ConfigurationCode = "TestUpdatePass",
                    ConfigurationDescription = "Test update pass",
                    XmlDefinition = DefaultConfiguration.Report_Parameters
                }
            };

            ReportStyleSheets = new ReportStyleSheet[]
            {
                new()
                {
                    StyleSheetId = -1,
                    StyleSheetCode = "TestDeletePass",
                    StyleSheetDescription = "Test delete pass",
                    XmlDefinition = DefaultConfiguration.Report_StyleSheet
                },
                new()
                {
                    StyleSheetId = -2,
                    StyleSheetCode = "TestUpdatePass",
                    StyleSheetDescription = "Test update pass",
                    XmlDefinition = DefaultConfiguration.Report_StyleSheet
                }
            };

            ResourceImages = new ResourceImage[]
            {
                new()
                {
                    ImageId = -1,
                    ImageDescription = "Test delete pass",
                    ImageBinary = Images.fractal_circle_icon_dark,
                    FileExtension = "PNG"
                },
                new()
                {
                    ImageId = -2,
                    ImageDescription = "Test update pass",
                    ImageBinary = Images.fractal_circle_icon_dark,
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

            SecurityPrices = new SecurityPrice[]
            {
                new()
                {
                    PriceId = -1,
                    SecurityId = -9,
                    PriceDate = GetRandomDateTime(),
                    PriceClose = (decimal)(_random.NextDouble() * 100),
                    PriceOpen = (decimal)(_random.NextDouble() * 100),
                    PriceHigh = (decimal)(_random.NextDouble() * 100),
                    PriceLow = (decimal)(_random.NextDouble() * 100)
                },
                new()
                {
                    PriceId = -2,
                    SecurityId = -7,
                    PriceDate = GetRandomDateTime(),
                    PriceClose = (decimal)(_random.NextDouble() * 100),
                    PriceOpen = (decimal)(_random.NextDouble() * 100),
                    PriceHigh = (decimal)(_random.NextDouble() * 100),
                    PriceLow = (decimal)(_random.NextDouble() * 100)
                },
                new()
                {
                    PriceId = -3,
                    SecurityId = -5,
                    PriceDate = GetRandomDateTime(),
                    PriceClose = (decimal)(_random.NextDouble() * 1000),
                },
                new()
                {
                    PriceId = -4,
                    SecurityId = -4,
                    PriceDate = GetRandomDateTime(),
                    PriceClose = (decimal)(_random.NextDouble() * 100),
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
                    new()
                    { 
                        AttributeMemberId = -10, AttributeId = -3, DisplayName = "IRA",
                        DisplayOrder = 0
                    },
                    new()
                    { 
                        AttributeMemberId = -11, AttributeId = -3, DisplayName = "ROTH",
                        DisplayOrder = 1
                    },
                    new()
                    { 
                        AttributeMemberId = -12, AttributeId = -3, DisplayName = "401K",
                        DisplayOrder = 2
                    },
                    new()
                    { 
                        AttributeMemberId = -13, AttributeId = -4, DisplayName = "Developed", 
                        DisplayOrder = 0 
                    },
                    new()
                    { 
                        AttributeMemberId = -14, AttributeId = -4, DisplayName = "Emerging",
                        DisplayOrder = 1
                    },
                    new()
                    { 
                        AttributeMemberId = -15, AttributeId = -5, DisplayName = "Necessary",
                        DisplayOrder = 0
                    },
                    new()
                    { 
                        AttributeMemberId = -16, AttributeId = -5, DisplayName = "Discretionary",
                        DisplayOrder = 1
                    },
                    new()
                    { 
                        AttributeMemberId = -17, AttributeId = -6, DisplayName = "Trading",
                        DisplayOrder = 0
                    },
                    new()
                    { 
                        AttributeMemberId = -18, AttributeId = -6, DisplayName = "Contributions",
                        DisplayOrder = 1
                    },
                    new()
                    { 
                        AttributeMemberId = -19, AttributeId = -6, DisplayName = "Expenses",
                        DisplayOrder = 2
                    },
                    new()
                    {
                        AttributeMemberId = -21, AttributeId = -2, DisplayName = "Test delete",
                        DisplayOrder = 0
                    },
                    new()
                    {
                        AttributeMemberId = -22, AttributeId = -2, DisplayName = "Test update",
                        DisplayOrder = 1
                    }
                })
                .ToArray();

            #region Attribute member entry
            AccountAttributes = new AccountAttributeMemberEntry[]
            {
                new()
                {
                    AccountObjectId = -3,
                    AttributeMemberId = -10,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                },
                new()
                {
                    AccountObjectId = -4,
                    AttributeMemberId = -11,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                }
            };

            BankTransactionCodeAttributes = new BankTransactionCodeAttributeMemberEntry[]
            {
                new()
                {
                    TransactionCodeId = -9,
                    AttributeMemberId = -15,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                },
                new()
                {
                    TransactionCodeId = -9,
                    AttributeMemberId = -16,
                    EffectiveDate = GetRandomDateTime(),
                    Weight = 1M
                },
                new()
                {
                    TransactionCodeId = -8,
                    AttributeMemberId = -16,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                }
            };

            BrokerTransactionCodeAttributes = new BrokerTransactionCodeAttributeMemberEntry[]
            {
                new()
                {
                    TransactionCodeId = -20,
                    AttributeMemberId = -17,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                },
                new()
                {
                    TransactionCodeId = -20,
                    AttributeMemberId = -17,
                    EffectiveDate = GetRandomDateTime(),
                    Weight = 1M
                },
                new()
                {
                    TransactionCodeId = -24,
                    AttributeMemberId = -18,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                },
                new()
                {
                    TransactionCodeId = -14,
                    AttributeMemberId = -19,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                }
            };

            CountryAttributes = new CountryAttributeMemberEntry[]
            {
                new()
                {
                    CountryId = -682,
                    AttributeMemberId = -13,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                },
                new()
                {
                    CountryId = -682,
                    AttributeMemberId = -13,
                    EffectiveDate = GetRandomDateTime(),
                    Weight = 1M
                },
                new()
                {
                    CountryId = -750,
                    AttributeMemberId = -14,
                    EffectiveDate = GetRandomDateTime(),
                    Weight = 1M
                }
            };

            SecurityAttributes = new SecurityAttributeMemberEntry[]
            {
                new()
                {
                    SecurityId = -1,
                    AttributeMemberId = -662,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                },
                new()
                {
                    SecurityId = -1,
                    AttributeMemberId = -662,
                    EffectiveDate = GetRandomDateTime(),
                    Weight = 1M
                },
                new()
                {
                    SecurityId = -7,
                    AttributeMemberId = -682,
                    EffectiveDate = DateTime.MinValue,
                    Weight = 1M
                }
            };

            #endregion

            BrokerTransactions = new BrokerTransaction[]
            {
                new()
                { 
                    TransactionId = -1, AccountId = -5, TransactionCodeId = -12, 
                    TradeDate = new DateTime(2021, 2, 27), SettleDate = new DateTime(2021, 2, 27), 
                    SecurityId = -101, Amount = 10000M, DepSecurityId = -100  
                },
                new()
                { 
                    TransactionId = -2, AccountId = -5, TransactionCodeId = -11, 
                    TradeDate = new DateTime(2017, 11, 6), SettleDate = new DateTime(2017, 11, 8), 
                    SecurityId = -1, Quantity = 100M, Amount = 5000M, Fee = 4.95M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -3, AccountId = -5, TransactionCodeId = -13, 
                    TradeDate = new DateTime(2020, 12, 12), SettleDate = new DateTime(2020, 12, 12), 
                    SecurityId = -1, Amount = 500M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -4, AccountId = -5, TransactionCodeId = -16, 
                    TradeDate = new DateTime(2018, 10, 8), SettleDate = new DateTime(2018, 10, 8), 
                    SecurityId = -101, Amount = 4.78M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -5, AccountId = -5, TransactionCodeId = -14, 
                    TradeDate = new DateTime(2017, 3, 3), SettleDate = new DateTime(2017, 3, 3), 
                    SecurityId = -102, Amount = 5M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -6, AccountId = -5, TransactionCodeId = -11, 
                    TradeDate = new DateTime(2017, 8, 2), SettleDate = new DateTime(2017, 8, 4), 
                    SecurityId = -3, Quantity = 5M, Amount = 764M, Fee = 4.95M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -7, AccountId = -5, TransactionCodeId = -11, 
                    TradeDate = new DateTime(2020, 3, 18), SettleDate = new DateTime(2020, 3, 20), 
                    SecurityId = -2, Quantity = 2M, Amount = 854M, Fee = 4.95M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -8, AccountId = -5, TransactionCodeId = -20, 
                    TradeDate = new DateTime(2017, 5, 3), SettleDate = new DateTime(2022, 5, 5), 
                    SecurityId = -1, Quantity = 30M, Amount = 6579M, Fee = 4.95M, DepSecurityId = -101, TaxLotId = -2 
                },
                new()
                { 
                    TransactionId = -9, AccountId = -5, TransactionCodeId = -21, 
                    TradeDate = new DateTime(2022, 3, 4), SettleDate = new DateTime(2015, 3, 5), 
                    SecurityId = -7, Quantity = 50M, Amount = 4316M, Fee = 4.95M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -10, AccountId = -5, TransactionCodeId = -22, 
                    TradeDate = new DateTime(2022, 3, 8), SettleDate = new DateTime(2022, 3, 8), 
                    SecurityId = -101, Amount = 1000M, DepSecurityId = -100 
                },
                new()
                { 
                    TransactionId = -11, AccountId = -5, TransactionCodeId = -14, 
                    TradeDate = new DateTime(2022, 8, 2), SettleDate = new DateTime(2022, 8, 2), 
                    SecurityId = -102, Amount = 1.01M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -12, AccountId = -5, TransactionCodeId = -13, 
                    TradeDate = new DateTime(2020, 2, 2), SettleDate = new DateTime(2020, 2, 2), 
                    SecurityId = -3, Amount = 44M, DepSecurityId = -101 
                },
                new()
                { 
                    TransactionId = -13, AccountId = -5, TransactionCodeId = -10, 
                    TradeDate = new DateTime(2020, 3, 12), SettleDate = new DateTime(2020, 3, 14), 
                    SecurityId = -7, Quantity = 40M, Amount = 3580M, Fee = 4.95M,DepSecurityId = -101, TaxLotId = -9 
                },
                new()
                { 
                    TransactionId = -14, AccountId = -5, TransactionCodeId = -17, 
                    TradeDate = new DateTime(2017, 11, 3), SettleDate = new DateTime(2017, 11, 3), 
                    SecurityId = -1, Quantity = 50M, Amount = 3500M, DepSecurityId = -100 
                },
                new()
                { 
                    TransactionId = -15, AccountId = -5, TransactionCodeId = -17, 
                    TradeDate = new DateTime(2019, 8, 1), SettleDate = new DateTime(2019, 8, 1), 
                    SecurityId = -6, Quantity = 4.56798M, Amount = 1200M, DepSecurityId = -100 
                },
                new(){ 
                    TransactionId = -16, AccountId = -5, TransactionCodeId = -18, 
                    TradeDate = new DateTime(2020, 6, 1), SettleDate = new DateTime(2020, 6, 1), 
                    SecurityId = -6, Quantity = 3M, Amount = 965M, DepSecurityId = -100, TaxLotId = -15 
                },
            };

            var targetEffDate = GetRandomDateTime();
            var tagetEffDate2 = GetRandomDateTime();

            InvestmentStrategyTargets = new InvestmentStrategyTarget[]
            {
                new()
                {
                    InvestmentStrategyId = -3,
                    AttributeMemberId = -13,
                    EffectiveDate = targetEffDate,
                    Weight = 0.70M
                },
                new()
                {
                    InvestmentStrategyId = -3,
                    AttributeMemberId = -14,
                    EffectiveDate = targetEffDate,
                    Weight = 0.30M
                },
                new()
                {
                    InvestmentStrategyId = -3,
                    AttributeMemberId = -100,
                    EffectiveDate = tagetEffDate2,
                    Weight = 0.75M,
                },
                new()
                {
                    InvestmentStrategyId = -3,
                    AttributeMemberId = -101,
                    EffectiveDate = tagetEffDate2,
                    Weight = 0.15M,
                },
                new()
                {
                    InvestmentStrategyId = -3,
                    AttributeMemberId = -104,
                    EffectiveDate = tagetEffDate2,
                    Weight = 0.1M,
                },
                new()
                {
                    InvestmentStrategyId = -4,
                    AttributeMemberId = -13,
                    EffectiveDate = targetEffDate,
                    Weight = 0.50M
                },
                new()
                {
                    InvestmentStrategyId = -4,
                    AttributeMemberId = -14,
                    EffectiveDate = targetEffDate,
                    Weight = 0.50M
                },
            };

            InvestmentPerformanceEntries = new InvestmentPerformanceEntry[]
            {
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 9), 
                    ToDate = new DateTime(2020, 1, 10), MarketValue = 558.9502M, NetContribution = 0M, 
                    AverageCapital = 529.3496M, Gain = 29.6006M, Irr = -0.0177M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 8), 
                    ToDate = new DateTime(2020, 1, 9), MarketValue = 529.3496M, NetContribution = 0M, 
                    AverageCapital = 538.8917M, Gain = -9.542M, Irr = -0.0132M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 7), 
                    ToDate = new DateTime(2020, 1, 8), MarketValue = 538.8917M, NetContribution = 0M, 
                    AverageCapital = 546.1246M, Gain = -7.2329M, Irr = 0.0328M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 6), 
                    ToDate = new DateTime(2020, 1, 7), MarketValue = 546.1246M, NetContribution = 0M, 
                    AverageCapital = 528.7705M, Gain = 17.3541M, Irr = 0.0684M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 5), 
                    ToDate = new DateTime(2020, 1, 6), MarketValue = 528.7705M, NetContribution = 0M, 
                    AverageCapital = 494.9266M, Gain = 33.8439M, Irr = 0M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 4), 
                    ToDate = new DateTime(2020, 1, 5), MarketValue = 494.9266M, NetContribution = 0M, 
                    AverageCapital = 494.9266M, Gain = 0M, Irr = 0M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 3), 
                    ToDate = new DateTime(2020, 1, 4), MarketValue = 494.9266M, NetContribution = 0M, 
                    AverageCapital = 494.9266M, Gain = 0M, Irr = 0.0579M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 2), 
                    ToDate = new DateTime(2020, 1, 3), MarketValue = 494.9266M, NetContribution = 0M, 
                    AverageCapital = 467.8515M, Gain = 27.0751M, Irr = -0.0326M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2020, 1, 1), 
                    ToDate = new DateTime(2020, 1, 2), MarketValue = 467.8515M, NetContribution = 0M, 
                    AverageCapital = 483.6172M, Gain = -15.7657M, Irr = 0M 
                },
                new()
                { 
                    AccountObjectId = -8, FromDate = new DateTime(2019, 12, 31), 
                    ToDate = new DateTime(2020, 1, 1), MarketValue = 483.6172M, NetContribution = 0M, 
                    AverageCapital = 483.6172M, Gain = 0M, Irr = -0.0004M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 9), 
                    ToDate = new DateTime(2020, 1, 10), MarketValue = 18487.2835M, NetContribution = 0M, 
                    AverageCapital = 18495.5054M, Gain = -8.2219M, Irr = 0.0024M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 8), 
                    ToDate = new DateTime(2020, 1, 9), MarketValue = 18495.5054M, NetContribution = 0M, 
                    AverageCapital = 18450.3985M, Gain = 45.1069M, Irr = 0.0014M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 7), 
                    ToDate = new DateTime(2020, 1, 8), MarketValue = 18450.3985M, NetContribution = 0M, 
                    AverageCapital = 18424.0153M, Gain = 26.3832M, Irr = -0.0012M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 6), 
                    ToDate = new DateTime(2020, 1, 7), MarketValue = 18424.0153M, NetContribution = 0M, 
                    AverageCapital = 18445.5433M, Gain = -21.528M, Irr = -0.0006M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 5), 
                    ToDate = new DateTime(2020, 1, 6), MarketValue = 18445.5433M, NetContribution = 0M, 
                    AverageCapital = 18457.4199M, Gain = -11.8766M, Irr = 0M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 4), 
                    ToDate = new DateTime(2020, 1, 5), MarketValue = 18457.4199M, NetContribution = 0M, 
                    AverageCapital = 18457.4199M, Gain = 0M, Irr = 0M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 3), 
                    ToDate = new DateTime(2020, 1, 4), MarketValue = 18457.4199M, NetContribution = 0M, 
                    AverageCapital = 18457.4199M, Gain = 0M, Irr = -0.0018M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 2), 
                    ToDate = new DateTime(2020, 1, 3), MarketValue = 18457.4199M, NetContribution = 0M, 
                    AverageCapital = 18491.0371M, Gain = -33.6172M, Irr = 0.0028M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2020, 1, 1), 
                    ToDate = new DateTime(2020, 1, 2), MarketValue = 18491.0371M, NetContribution = 0M, 
                    AverageCapital = 18439.8514M, Gain = 51.1856M, Irr = 0M 
                },
                new()
                { 
                    AccountObjectId = -5, FromDate = new DateTime(2019, 12, 31), 
                    ToDate = new DateTime(2020, 1, 1), MarketValue = 18439.8514M, NetContribution = 0M, 
                    AverageCapital = 18439.8514M, Gain = 0M, Irr = 0M 
                }
            };

            InvestmentPerformanceAttributeEntries = new InvestmentPerformanceAttributeMemberEntry[]
            {
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 9), 
                    ToDate = new DateTime(2020, 1, 10), MarketValue = 558.9502M, NetContribution = 0M, 
                    AverageCapital = 529.3496M, Gain = 29.6006M, Irr = -0.0177M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 8), 
                    ToDate = new DateTime(2020, 1, 9), MarketValue = 529.3496M, NetContribution = 0M, 
                    AverageCapital = 538.8917M, Gain = -9.542M, Irr = -0.0132M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 7), 
                    ToDate = new DateTime(2020, 1, 8), MarketValue = 538.8917M, NetContribution = 0M, 
                    AverageCapital = 546.1246M, Gain = -7.2329M, Irr = 0.0328M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 6), 
                    ToDate = new DateTime(2020, 1, 7), MarketValue = 546.1246M, NetContribution = 0M, 
                    AverageCapital = 528.7705M, Gain = 17.3541M, Irr = 0.0684M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 5), 
                    ToDate = new DateTime(2020, 1, 6), MarketValue = 528.7705M, NetContribution = 0M, 
                    AverageCapital = 494.9266M, Gain = 33.8439M, Irr = 0M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 4), 
                    ToDate = new DateTime(2020, 1, 5), MarketValue = 494.9266M, NetContribution = 0M, 
                    AverageCapital = 494.9266M, Gain = 0M, Irr = 0M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 3), 
                    ToDate = new DateTime(2020, 1, 4), MarketValue = 494.9266M, NetContribution = 0M, 
                    AverageCapital = 494.9266M, Gain = 0M, Irr = 0.0579M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 2), 
                    ToDate = new DateTime(2020, 1, 3), MarketValue = 494.9266M, NetContribution = 0M, 
                    AverageCapital = 467.8515M, Gain = 27.0751M, Irr = -0.0326M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 1), 
                    ToDate = new DateTime(2020, 1, 2), MarketValue = 467.8515M, NetContribution = 0M, 
                    AverageCapital = 483.6172M, Gain = -15.7657M, Irr = 0M 
                },
                new()
                { 
                    AttributeMemberId = -100, AccountObjectId = -5, FromDate = new DateTime(2019, 12, 31), 
                    ToDate = new DateTime(2020, 1, 1), MarketValue = 483.6172M, NetContribution = 0M, 
                    AverageCapital = 483.6172M, Gain = 0M, Irr = -0.0004M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 9), 
                    ToDate = new DateTime(2020, 1, 10), MarketValue = 18487.2835M, NetContribution = 0M,
                    AverageCapital = 18495.5054M, Gain = -8.2219M, Irr = 0.0024M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 8), 
                    ToDate = new DateTime(2020, 1, 9), MarketValue = 18495.5054M, NetContribution = 0M, 
                    AverageCapital = 18450.3985M, Gain = 45.1069M, Irr = 0.0014M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 7), 
                    ToDate = new DateTime(2020, 1, 8), MarketValue = 18450.3985M, NetContribution = 0M, 
                    AverageCapital = 18424.0153M, Gain = 26.3832M, Irr = -0.0012M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 6), 
                    ToDate = new DateTime(2020, 1, 7), MarketValue = 18424.0153M, NetContribution = 0M, 
                    AverageCapital = 18445.5433M, Gain = -21.528M, Irr = -0.0006M }
                ,
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 5), 
                    ToDate = new DateTime(2020, 1, 6), MarketValue = 18445.5433M, NetContribution = 0M, 
                    AverageCapital = 18457.4199M, Gain = -11.8766M, Irr = 0M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 4), 
                    ToDate = new DateTime(2020, 1, 5), MarketValue = 18457.4199M, NetContribution = 0M, 
                    AverageCapital = 18457.4199M, Gain = 0M, Irr = 0M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 3), 
                    ToDate = new DateTime(2020, 1, 4), MarketValue = 18457.4199M, NetContribution = 0M, 
                    AverageCapital = 18457.4199M, Gain = 0M, Irr = -0.0018M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 2), 
                    ToDate = new DateTime(2020, 1, 3), MarketValue = 18457.4199M, NetContribution = 0M, 
                    AverageCapital = 18491.0371M, Gain = -33.6172M, Irr = 0.0028M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2020, 1, 1), 
                    ToDate = new DateTime(2020, 1, 2), MarketValue = 18491.0371M, NetContribution = 0M, 
                    AverageCapital = 18439.8514M, Gain = 51.1856M, Irr = 0M 
                },
                new()
                { 
                    AttributeMemberId = -101, AccountObjectId = -5, FromDate = new DateTime(2019, 12, 31), 
                    ToDate = new DateTime(2020, 1, 1), MarketValue = 18439.8514M, NetContribution = 0M, 
                    AverageCapital = 18439.8514M, Gain = 0M,  
                },
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
        public ModelAttributeScope[] ModelAttributeScopes { get; }

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
