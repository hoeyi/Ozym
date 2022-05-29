using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Context.Configuration
{
    /// <summary>
    /// Represents a collection models to add to a data store on initialization.
    /// </summary>
    public interface ISeedData
    {
        /// <summary>
        /// Gets the <see cref="AccountAttributeMemberEntry"/> to seed.
        /// </summary>
        AccountAttributeMemberEntry[] AccountAttributes { get; }

        /// <summary>
        /// Gets the <see cref="AccountCompositeMember"/> to seed.
        /// </summary>
        AccountCompositeMember AccountCompositeMemnbers { get; }

        /// <summary>
        /// Gets the <see cref="AccountComposite"/> models to seed.
        /// </summary>
        AccountComposite[] AccountComposites { get; }

        /// <summary>
        /// Gets the <see cref="AccountCustodian"/> models to seed.
        /// </summary>
        AccountCustodian[] AccountCustodians { get; }

        /// <summary>
        /// Gets the <see cref="AccountCustodian"/> models to seed.
        /// </summary>
        AccountObject[] AccountObjects { get; }

        /// <summary>
        /// Gets the <see cref="AccountCustodian"/> models to seed.
        /// </summary>
        Account[] Accounts { get; }

        /// <summary>
        /// Gets the <see cref="AccountWallet"/> models to seed.
        /// </summary>
        AccountWallet[] AccountWallets { get; }

        /// <summary>
        /// Gets the <see cref="BankTransactionCodeAttributeMemberEntry"/> to seed.
        /// </summary>
        BankTransactionCodeAttributeMemberEntry[] BankTransactionCodeAttributes { get; }

        /// <summary>
        /// Gets the <see cref="BankTransactionCode"/> models to seed.
        /// </summary>
        BankTransactionCode[] BankTransactionCodes { get; }

        /// <summary>
        /// Gets the <see cref="BankTransaction"/> to seed.
        /// </summary>
        BankTransaction[] BankTransactions { get; }

        /// <summary>
        /// Gets the <see cref="BrokerTransactionCodeAttributeMemberEntry"/> to seed.
        /// </summary>
        BrokerTransactionCodeAttributeMemberEntry[] BrokerTransactionCodeAttributes { get; }

        /// <summary>
        /// Gets the <see cref="BrokerTransactionCode"/> models to seed.
        /// </summary>
        BrokerTransactionCode[] BrokerTransactionCodes { get; }

        /// <summary>
        /// Gets the <see cref="BrokerTransaction"/> to seed.
        /// </summary>
        BrokerTransaction[] BrokerTransactions { get; }

        /// <summary>
        /// Gets the <see cref="Country"/> models to seed.
        /// </summary>
        Country[] Countries { get; }

        /// <summary>
        /// Gets the <see cref="CountryAttributeMemberEntry"/> to seed.
        /// </summary>
        CountryAttributeMemberEntry[] CountryAttributes { get; }

        /// <summary>
        /// Gets the <see cref="InvestmentPerformanceAttributeMemberEntry"/> to seed.
        /// </summary>
        InvestmentPerformanceAttributeMemberEntry[] InvestmentPerformanceAttributeEntries { get; }

        /// <summary>
        /// Gets the <see cref="InvestmentPerformanceEntry"/> to seed.
        /// </summary>
        InvestmentPerformanceEntry[] InvestmentPerformanceEntries { get; }

        /// <summary>
        /// Gets the <see cref="InvestmentStrategy"/> models to seed.
        /// </summary>
        InvestmentStrategy[] InvestmentStrategies { get; }

        /// <summary>
        /// Gets the <see cref="InvestmentStrategyTarget"/> to seed.
        /// </summary>
        InvestmentStrategyTarget[] InvestmentStrategyTargets { get; }

        /// <summary>
        /// Gets the <see cref="MarketHoliday"/> models to seed.
        /// </summary>
        MarketHoliday[] MarketHolidays { get; }

        /// <summary>
        /// Gets the <see cref="MarketHolidaySchedule"/> to seed.
        /// </summary>
        MarketHolidaySchedule[] MarketHolidaySchedules { get; }

        /// <summary>
        /// Gets the <see cref="MarketIndexPrice"/> to seed.
        /// </summary>
        MarketIndexPrice[] MarketIndexPrices { get; }

        /// <summary>
        /// Gets the <see cref="MarketIndex"/> models to seed.
        /// </summary>
        MarketIndex[] MarketIndices { get; }

        /// <summary>
        /// Gets the <see cref="ModelAttributeMember"/> models to seed.
        /// </summary>
        ModelAttributeMember[] ModelAttributeMembers { get; }

        /// <summary>
        /// Gets the <see cref="ModelAttribute"/> models to seed.
        /// </summary>
        ModelAttribute[] ModelAttributes { get; }

        /// <summary>
        /// Gets the <see cref="ReportConfiguration"/> models to seed.
        /// </summary>
        ReportConfiguration[] ReportConfigurations { get; }

        /// <summary>
        /// Gets the <see cref="ReportStyleSheet"/> models to seed.
        /// </summary>
        ReportStyleSheet[] ReportStyleSheets { get; }

        /// <summary>
        /// Gets the <see cref="ResourceImage"/> models to seed.
        /// </summary>
        ResourceImage[] ResourceImages { get; }

        /// <summary>
        /// Gets the <see cref="Security"/> models to seed.
        /// </summary>
        Security[] Securities { get; }

        /// <summary>
        /// Gets the <see cref="SecurityAttributeMemberEntry"/> to seed.
        /// </summary>
        SecurityAttributeMemberEntry[] SecurityAttributes { get; }

        /// <summary>
        /// Gets the <see cref="SecurityExchange"/> models to seed.
        /// </summary>
        SecurityExchange[] SecurityExchanges { get; }

        /// <summary>
        /// Gets the <see cref="SecurityPrice"/> to seed.
        /// </summary>
        SecurityPrice[] SecurityPrices { get; }

        /// <summary>
        /// Gets the <see cref="SecuritySymbol"/> models to seed.
        /// </summary>
        SecuritySymbol[] SecuritySymbols { get; }

        /// <summary>
        /// Gets the <see cref="SecuritySymbolType"/> models to seed.
        /// </summary>
        SecuritySymbolType[] SecuritySymbolTypes { get; }

        /// <summary>
        /// Gets the <see cref="SecurityTypeGroup"/> models to seed.
        /// </summary>
        SecurityTypeGroup[] SecurityTypeGroups { get; }

        /// <summary>
        /// Gets the <see cref="SecurityType"/> models to seed.
        /// </summary>
        SecurityType[] SecurityTypes { get; }
    }
}
