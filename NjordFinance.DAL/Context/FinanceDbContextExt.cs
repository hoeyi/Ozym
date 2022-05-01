﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;

namespace NjordFinance.Context
{
    public partial class FinanceDbContext : DbContext
    {
#pragma warning disable CA1822 // Mark members as static
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
#pragma warning restore CA1822 // Mark members as static
        {
            modelBuilder.Entity<AccountCustodian>().HasData(
                new AccountCustodian()
                {
                    AccountCustodianId = -100,
                    CustodianCode = "SOMEWHERE",
                    DisplayName = "SomeWhere Bank LLC"
                },
                new AccountCustodian()
                {
                    AccountCustodianId = -101,
                    CustodianCode = "SOMENAME",
                    DisplayName = "Some Name Securities Broker"
                },
                new AccountCustodian()
                {
                    AccountCustodianId = -102,
                    CustodianCode = "CRYPTO",
                    DisplayName = "Cryptopotamus Coin Exchange"
                });

            modelBuilder.Entity<AccountObject>().HasData(
                new AccountObject()
                {
                    AccountObjectId = -100,
                    AccountObjectCode = "TESTBROKER",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Broker Account",
                    ObjectDescription = "For testing functionality of broker acccount records."
                },
                new AccountObject()
                {
                    AccountObjectId = -101,
                    AccountObjectCode = "TESTBANK",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Test Bank Account",
                    ObjectDescription = "For testing functionality of bank account records."
                },
                new AccountObject()
                {
                    AccountObjectId = -102,
                    AccountObjectCode = "TESTCRYPTO",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "Testt Crypto Account",
                    ObjectDescription = "For testing functionality of crypto broker account records."
                });

            modelBuilder.Entity<Account>().HasData(
                new Account()
                {
                    AccountId = -101,
                    IsComplianceTradable = true,
                    HasBrokerTransaction = true,
                    AccountCustodianId = -102
                },
                new Account()
                {
                    AccountId = -100,
                    IsComplianceTradable = false,
                    HasBankTransaction = true,
                },
                new Account()
                {
                    AccountId = -102,
                    IsComplianceTradable = true,
                    HasBrokerTransaction = true,
                    HasWallet = true,
                    AccountCustodianId = -102
                });

            modelBuilder.Entity<Country>().HasData(
                new Country()
                {
                    CountryId = -100,
                    IsoCode3 = "USA",
                    DisplayName = "United States of America"
                },
                new Country()
                {
                    CountryId = -200,
                    IsoCode3 = "DEU",
                    DisplayName = "Germany"
                },
                new Country()
                {
                    CountryId = -300,
                    IsoCode3 = "CAN",
                    DisplayName = "Canada"
                },
                new Country()
                {
                    CountryId = -400,
                    IsoCode3 = "JPN",
                    DisplayName = "Japan"
                });

            modelBuilder.Entity<SecurityExchange>().HasData(
                new SecurityExchange()
                {
                    ExchangeId = -100,
                    ExchangeCode = "NYSE",
                    ExchangeDescription = "New York Stock Exchange"
                },
                new SecurityExchange()
                {
                    ExchangeId = -200,
                    ExchangeCode = "NASDAQ",
                    ExchangeDescription = "Nasdaq Stock Market"
                });

            modelBuilder.Entity<SecurityTypeGroup>().HasData(
                new SecurityTypeGroup()
                {
                    SecurityTypeGroupId = -100,
                    SecurityTypeGroupName = "Individual Stock",
                    DisplayOrder = 0
                },
                new SecurityTypeGroup()
                {
                    SecurityTypeGroupId = -200,
                    SecurityTypeGroupName = "Option Contracts",
                    DisplayOrder = 1
                },
                new SecurityTypeGroup()
                {
                    SecurityTypeGroupId = -300,
                    SecurityTypeGroupName = "Digital Assets",
                    DisplayOrder = 2
                });

            modelBuilder.Entity<SecurityType>().HasData(
                new SecurityType()
                {
                    SecurityTypeId = -100,
                    SecurityTypeGroupId = -100,
                    SecurityTypeName = "Common stock",
                    CanHaveDerivative = true,
                    CanHavePosition = true,
                    DisplayOrder = 0,
                    ValuationFactor = 1
                },
                new SecurityType()
                {
                    SecurityTypeId = -200,
                    SecurityTypeGroupId = -200,
                    SecurityTypeName = "Call option",
                    CanHaveDerivative = false,
                    CanHavePosition = true,
                    DisplayOrder = 1,
                    ValuationFactor = 1
                },
                new SecurityType()
                {
                    SecurityTypeId = -300,
                    SecurityTypeGroupId = -200,
                    SecurityTypeName = "Put option",
                    CanHaveDerivative = false,
                    CanHavePosition = true,
                    DisplayOrder = 2,
                    ValuationFactor = 1
                },
                new SecurityType()
                {
                    SecurityTypeId = -400,
                    SecurityTypeGroupId = -200,
                    SecurityTypeName = "Cash",
                    CanHaveDerivative = false,
                    CanHavePosition = false,
                    DisplayOrder = 3,
                    ValuationFactor = 1
                },
                new SecurityType()
                {
                    SecurityTypeId = -500,
                    SecurityTypeGroupId = -200,
                    SecurityTypeName = "Cryptocurrency",
                    CanHaveDerivative = false,
                    CanHavePosition = false,
                    DisplayOrder = 3,
                    ValuationFactor = 1
                });

            modelBuilder.Entity<Security>().HasData(
                new Security()
                {
                    SecurityId = -100,
                    SecurityTypeId = -100,
                    SecurityDescription = "Microsoft Inc.",
                    SecurityExchangeId = -200,
                },
                new Security()
                {
                    SecurityId = -101,
                    SecurityTypeId = -100,
                    SecurityDescription = "Apple Inc.",
                    SecurityExchangeId = -200,
                },
                new Security()
                {
                    SecurityId = -102,
                    SecurityTypeId = -100,
                    SecurityDescription = "JP Morgan Chase Co."
                },
                new Security()
                {
                    SecurityId = -103,
                    SecurityTypeId = -500,
                    SecurityDescription = "Bitcoin",
                    HasPerpetualMarket = true
                },
                new Security()
                {
                    SecurityId = -104,
                    SecurityTypeId = -500,
                    SecurityDescription = "Litecoin",
                    HasPerpetualMarket = true
                },
                new Security()
                {
                    SecurityId = -105,
                    SecurityTypeId = -500,
                    SecurityDescription = "Ether",
                    HasPerpetualMarket = true
                });

            modelBuilder.Entity<SecuritySymbolType>().HasData(
                new SecuritySymbolType()
                {
                    SymbolTypeId = -10,
                    SymbolTypeName = "CUSIP"
                },
                new SecuritySymbolType()
                {
                    SymbolTypeId = -20,
                    SymbolTypeName = "Custom Identifer"
                },
                new SecuritySymbolType()
                {
                    SymbolTypeId = -30,
                    SymbolTypeName = "Option Ticker"
                },
                new SecuritySymbolType()
                {
                    SymbolTypeId = -40,
                    SymbolTypeName = "Ticker"
                });

            modelBuilder.Entity<SecuritySymbol>().HasData(
                new SecuritySymbol()
                {
                    SymbolId = -100,
                    SecurityId = -100,
                    SymbolTypeId = -40,
                    Ticker = "MSFT",
                    EffectiveDate = GetRandomDateTime(20, 30)
                },
                new SecuritySymbol()
                {
                    SymbolId = -101,
                    SecurityId = -101,
                    SymbolTypeId = -40,
                    Ticker = "AAPL",
                    EffectiveDate = GetRandomDateTime(20, 30)
                },
                new SecuritySymbol()
                {
                    SymbolId = -102,
                    SecurityId = -102,
                    SymbolTypeId = -40,
                    Ticker = "JPM",
                    EffectiveDate = GetRandomDateTime(15, 25)
                },
                new SecuritySymbol()
                {
                    SymbolId = -103,
                    SecurityId = -103,
                    SymbolTypeId = -20,
                    CustomSymbol = "BTC",
                    EffectiveDate = GetRandomDateTime(7, 10)
                },
                new SecuritySymbol()
                {
                    SymbolId = -104,
                    SecurityId = -104,
                    SymbolTypeId = -20,
                    CustomSymbol = "LTC",
                    EffectiveDate = GetRandomDateTime(7, 10)
                },
                new SecuritySymbol()
                {
                    SymbolId = -105,
                    SecurityId = -105,
                    SymbolTypeId = -20,
                    CustomSymbol = "ETH",
                    EffectiveDate = GetRandomDateTime(1, 25)
                });
        }

        private static DateTime GetRandomDateTime(int minimumYearSeed, int maximumYearSeed)
        {
            Random random = new();

            return DateTime.Now
                .AddYears(
                    random.Next(
                        minValue: minimumYearSeed < 0 ? 0 : minimumYearSeed, 
                        maxValue: maximumYearSeed > 25 ? 25 : maximumYearSeed) * -1)
                .AddMonths(random.Next(0, 12))
                .AddDays(random.Next(0, 30));
        }
    }
}
