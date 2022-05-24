using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Context;
using NjordFinance.Context.Configuration;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;

namespace NjordFinance.Test.Configuration
{
    internal class ModelServiceTestDataModel : ISeedData
    {
        private static readonly Random _random = new();

        /// <inheritdoc/>
        public AccountCustodian[] AccountCustodians { get; } =
        {
            new AccountCustodian()
            {
                AccountCustodianId = -1,
                CustodianCode = "SOMEWHERE",
                DisplayName = "SomeWhere Bank LLC"
            },
            new AccountCustodian()
            {
                AccountCustodianId = -2,
                CustodianCode = "SOMENAME",
                DisplayName = "Some Name Securities Broker"
            },
            new AccountCustodian()
            {
                AccountCustodianId = -3,
                CustodianCode = "CRYPTO",
                DisplayName = "Cryptopotamus Coin Exchange"
            }
        };

        /// <inheritdoc/>
        public AccountObject[] AccountObjects { get; } =
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
            }
        };

        /// <inheritdoc/>
        public Account[] Accounts { get; } =
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

        /// <inheritdoc/>
        public BankTransactionCode[] BankTransactionCodes { get; } =
        {
            new() { TransactionCodeId = -1, TransactionCode = "401k", DisplayName = "401k Contribution" },
            new() { TransactionCodeId = -2, TransactionCode = "auto", DisplayName = "Automotive" },
            new() { TransactionCodeId = -3, TransactionCode = "balance", DisplayName = "Initial Balance" },
            new() { TransactionCodeId = -4, TransactionCode = "salary", DisplayName = "Salary/Wage" },
            new() { TransactionCodeId = -5, TransactionCode = "statetax", DisplayName = "State Tax Paid" },
            new() { TransactionCodeId = -6, TransactionCode = "timeoff", DisplayName = "Unused Paid Time-Off" },
            new() { TransactionCodeId = -7, TransactionCode = "travel", DisplayName = "Travel" },
        };

        /// <inheritdoc/>
        public Country[] Countries { get; } =
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

        /// <inheritdoc/>
        public SecurityExchange[] SecurityExchanges { get; } =
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
            }
        };

        /// <inheritdoc/>
        public Security[] Securities { get; } =
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
            }
        };

        /// <inheritdoc/>
        public SecuritySymbol[] SecuritySymbols { get; } =
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


        private static DateTime GetRandomDateTime()
        {
            Random random = new();

            return DateTime.Now.AddDays(random.Next(0, 7200) * -1);
        }
    }
}
