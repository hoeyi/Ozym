using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Context.Configuration;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;

namespace NjordFinance.Test.Configuration
{
    internal class ModelServiceTestDataModel : ISeedData
    {
        private static readonly Random _random = new();

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
                    AccountObjectId = -1,
                    AccountObjectCode = "TESTBROKER",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Broker Account",
                    ObjectDescription = "For testing functionality of broker acccount records."
                },
                new()
                {
                    AccountObjectId = -2,
                    AccountObjectCode = "TESTBANK",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Bank Account",
                    ObjectDescription = "For testing functionality of bank account records."
                },
                new()
                {
                    AccountObjectId = -3,
                    AccountObjectCode = "TESTCRYPTO",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Crypto Account",
                    ObjectDescription = "For testing functionality of crypto broker account records."
                },
                new()
                {
                    AccountObjectId = -4,
                    AccountObjectCode = "TESTDELPASS",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST DELETE PASS",
                    ObjectDescription = "Lorem ipsum dolor sit amet"
                },
                new()
                {
                    AccountObjectId = -5,
                    AccountObjectCode = "TESTUPDPASS",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST UPDATE PASS",
                    ObjectDescription = "sed do eiusmod ",
                    StartDate = new DateTime(
                                _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1, 28))
                },
                new()
                {
                    AccountObjectId = -6,
                    AccountObjectCode = "TESTDELPASSC",
                    ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                    ObjectDisplayName = "TEST DELETE PASS",
                    ObjectDescription = "sed aasdfa dsfapgotpokn",
                    StartDate = new DateTime(
                                    _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1,28))
                },
                new()
                {
                    AccountObjectId = -7,
                    AccountObjectCode = "TESTUPDATEC",
                    ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                    ObjectDisplayName = "TEST UPDATE PASS",
                    ObjectDescription = "sed fafdjuq dsfaplkokn",
                    StartDate = new DateTime(
                                    _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1,28))
                }
            };

            Accounts = new Account[]
            {
                new Account()
                {
                    AccountId = -1,
                    IsComplianceTradable = true,
                    HasBrokerTransaction = true,
                    AccountCustodianId = -2
                },
                new Account()
                {
                    AccountId = -2,
                    IsComplianceTradable = false,
                    HasBankTransaction = true
                },
                new Account()
                {
                    AccountId = -3,
                    IsComplianceTradable = true,
                    HasBrokerTransaction = true,
                    HasWallet = true,
                    AccountCustodianId = -3
                },
                new Account()
                {
                    AccountId = -4,
                    AccountNumber = "0000-0000-00"
                },
                new Account()
                {
                    AccountId = -5,
                    AccountNumber = "0000-0000-00"
                }
            };

            AccountWallets = new AccountWallet[]
            {
                new(){ 
                    AccountWalletId = -1, AccountId = -3, DenominationSecurityId = -5,
                    AddressCode = "5F32C68C-415C-4612-AA29-14D6FE0940C6", AddressTag = "ABC"},
                new(){ AccountWalletId = -2, AccountId = -3, DenominationSecurityId = -6,
                    AddressCode= "2E34D0C0-6DC7-4DC6-86C4-F0B3A4A1BEBE"}
            };

            AccountComposites = new AccountComposite[]
            {
                new(){ AccountCompositeId = -6 },
                new(){ AccountCompositeId = -7 }
            };

            BankTransactionCodes = new BankTransactionCode[]
            {
                new() { TransactionCodeId = -1, TransactionCode = "401k", DisplayName = "401k Contribution" },
                new() { TransactionCodeId = -2, TransactionCode = "auto", DisplayName = "Automotive" },
                new() { TransactionCodeId = -3, TransactionCode = "balance", DisplayName = "Initial Balance" },
                new() { TransactionCodeId = -4, TransactionCode = "salary", DisplayName = "Salary/Wage" },
                new() { TransactionCodeId = -5, TransactionCode = "statetax", DisplayName = "State Tax Paid" },
                new() { TransactionCodeId = -6, TransactionCode = "timeoff", DisplayName = "Unused Paid Time-Off" },
                new() { TransactionCodeId = -7, TransactionCode = "travel", DisplayName = "Travel" },
                new() { TransactionCodeId = -8, TransactionCode = "UPDPASS", DisplayName = "Test update pass" },
                new() { TransactionCodeId = -9, TransactionCode = "DELPASS", DisplayName = "Test delete pass"}
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

            Countries = new Country[]
            {
                new Country()
                {
                    CountryId = -1,
                    IsoCode3 = "USA",
                    DisplayName = "United States of America"
                },
                new Country()
                {
                    CountryId = -2,
                    IsoCode3 = "DEU",
                    DisplayName = "Germany"
                },
                new Country()
                {
                    CountryId = -3,
                    IsoCode3 = "CAN",
                    DisplayName = "Canada"
                },
                new Country()
                {
                    CountryId = -4,
                    IsoCode3 = "JPN",
                    DisplayName = "Japan"
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
                new(){ AttributeId = -2, DisplayName = "Test update pass" }
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
                .ToArray();
        }
        /// <inheritdoc/>
        public AccountCustodian[] AccountCustodians { get; }

        /// <inheritdoc/>
        public AccountObject[] AccountObjects { get; }

        /// <inheritdoc/>
        public AccountComposite[] AccountComposites { get; } 

        /// <inheritdoc/>
        public Account[] Accounts { get; }

        /// <inheritdoc/>
        public AccountWallet[] AccountWallets { get; }

        /// <inheritdoc/>
        public BankTransactionCode[] BankTransactionCodes { get; }

        public BrokerTransactionCode[] BrokerTransactionCodes { get; }
        
        /// <inheritdoc/>
        public Country[] Countries { get; }

        /// <inheritdoc/>
        public InvestmentStrategy[] InvestmentStrategies { get; }

        /// <inheritdoc/>
        public MarketHoliday[] MarketHolidays { get; }

        /// <inheritdoc/>
        public MarketIndex[] MarketIndices { get; }

        /// <inheritdoc/>
        public ModelAttribute[] ModelAttributes { get; }

        public ModelAttributeMember[] ModelAttributeMembers { get; }

        /// <inheritdoc/>
        public ReportConfiguration[] ReportConfigurations { get; }

        /// <inheritdoc/>
        public ReportStyleSheet[] ReportStyleSheets { get; }

        /// <inheritdoc/>
        public ResourceImage[] ResourceImages { get; }

        /// <inheritdoc/>
        public Security[] Securities { get; }

        /// <inheritdoc/>
        public SecurityExchange[] SecurityExchanges { get; }

        /// <inheritdoc/>
        public SecuritySymbol[] SecuritySymbols { get; }

        /// <inheritdoc/>
        public SecuritySymbolType[] SecuritySymbolTypes { get; }

        /// <inheritdoc/>
        public SecurityTypeGroup[] SecurityTypeGroups { get; }

        /// <inheritdoc/>
        public SecurityType[] SecurityTypes { get; }

        private static DateTime GetRandomDateTime()
        {
            Random random = new();

            return DateTime.Now.AddDays(random.Next(0, 7200) * -1);
        }
    }
}
