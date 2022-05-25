using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Context
{
    /// <summary>
    /// Represents a collection models to 
    /// </summary>
    public interface ISeedData
    {
        /// <summary>
        /// Gets the <see cref="AccountCustodian"/> models to seed.
        /// </summary>
        AccountCustodian[] AccountCustodians { get; }

        /// <summary>
        /// Gets the <see cref="AccountCustodian"/> models to seed.
        /// </summary>
        AccountObject[] AccountObjects { get; }

        AccountComposite[] AccountComposites { get; }

        /// <summary>
        /// Gets the <see cref="AccountCustodian"/> models to seed.
        /// </summary>
        Account[] Accounts { get; }

        /// <summary>
        /// Gets the <see cref="BankTransactionCode"/> models to seed.
        /// </summary>
        BankTransactionCode[] BankTransactionCodes { get; }

        BrokerTransactionCode[] BrokerTransactionCodes { get; }

        /// <summary>
        /// Gets the <see cref="Country"/> models to seed.
        /// </summary>
        Country[] Countries { get; }

        InvestmentStrategy[] InvestmentStrategies { get; }

        MarketHoliday[] MarketHolidays { get; }

        MarketIndex[] MarketIndices { get; }

        ModelAttribute[] ModelAttributes { get; }

        ModelAttributeMember[] ModelAttributeMembers { get; }

        ReportConfiguration[] ReportConfigurations { get; }

        ReportStyleSheet[] ReportStyleSheets { get; }

        ResourceImage[] ResourceImages { get; }

        SecurityTypeGroup[] SecurityTypeGroups { get; }

        SecurityType[] SecurityTypes { get; }

        /// <summary>
        /// Gets the <see cref="Security"/> models to seed.
        /// </summary>
        Security[] Securities { get; }

        /// <summary>
        /// Gets the <see cref="SecurityExchange"/> models to seed.
        /// </summary>
        SecurityExchange[] SecurityExchanges { get; }

        /// <summary>
        /// Gets the <see cref="SecuritySymbol"/> models to seed.
        /// </summary>
        SecuritySymbol[] SecuritySymbols { get; }

        SecuritySymbolType[] SecuritySymbolTypes { get; }
    }
}
