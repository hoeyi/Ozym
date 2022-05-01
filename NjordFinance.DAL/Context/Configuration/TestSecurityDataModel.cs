using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;

namespace NjordFinance.Context.Configuration
{
    /// <summary>
    /// Represents the seed data for test versions of security data in <see cref="FinanceDbContext"/>.
    /// <list type="bullet">Includes test models for the following:
    /// <item><see cref="SecurityExchange"/></item>
    /// <item><see cref="Security"/></item>
    /// <item><see cref="SecuritySymbol"/></item>
    /// </list>
    /// </summary>
    internal class TestSecurityDataModel
    {
        /// <summary>
        /// Creates a new instance of <see cref="TestSecurityDataModel"/>.
        /// </summary>
        public TestSecurityDataModel()
        {
        }

        /// <summary>
        /// Gets the <see cref="SecurityExchange"/> seed models.
        /// </summary>
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

        /// <summary>
        /// Gets the <see cref="Security"/> seed models.
        /// </summary>
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

        /// <summary>
        /// Gets the <see cref="SecuritySymbol"/> seed models.
        /// </summary>
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
