using NjordinSight.BusinessLogic.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.BusinessLogic.MarketFeed
{

    /// <summary>
    /// Service that generates data randomly to represent the behavior of a stock market watchlist.
    /// </summary>
    public class WatchList : IWatchlist
    {
        public WatchList(IStatisticsCalculator calculator)
        {
            Calculator = calculator;
        }

        private IStatisticsCalculator Calculator { get; init; }

        /// <inheritdoc/>
        public IEnumerable<Quote> GetQuotes() => new List<Quote>()
            {
                new ()
                {
                    Symbol = "SPY",
                    Description = "SPDR S&P 500 ETF",
                    LastPrice = 441,
                    Change = 0
                },
                new ()
                {
                    Symbol = "AAPL",
                    Description = "Apple Inc",
                    LastPrice = 185,
                    Change = 0
                },
                new ()
                {
                    Symbol = "AMZN",
                    Description = "Amazon.com Inc",
                    LastPrice = 126,
                    Change = 0
                },
                new ()
                {
                    Symbol = "NVDA",
                    Description = "Nvidia Corp",
                    LastPrice = 435.00,
                    Change = 0
                },
                new ()
                {
                    Symbol = "MSFT",
                    Description = "Microsoft Corp",
                    LastPrice = 300,
                    Change = 0
                },
            };

        /// <inheritdoc/>
        public IEnumerable<Quote> UpdateQuotes(IList<Quote> quotes)
        {
            var normalSamples = Calculator.NormalDistributionSamples(0.1, 1, quotes.Count);

            for (int i = 0; i < quotes.Count; i++)
            {
                var sample = normalSamples[i];
                var record = quotes[i];
                var priceDelta = sample / 100.0 * record.LastPrice;

                record.LastPrice -= priceDelta;
                record.Change = priceDelta;
            }

            return quotes;
        }
    }
}
