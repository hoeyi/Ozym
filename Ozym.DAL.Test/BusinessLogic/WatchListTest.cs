using Ozym.BusinessLogic.Functions;
using Ozym.BusinessLogic.MarketFeed;
using System.Collections.Generic;
using System.Linq;

namespace Ozym.Test.BusinessLogic
{
    [TestClass]
    [TestCategory("Unit")]
    public class WatchListTest
    {
        [TestMethod]
        public void GetQuotes_CalledOnce_ReturnsPriceDeltas_EqualToZero()
        {
            var facade = new Watchlist(new StatisticsCalculator());
            var quotes = facade.GetQuotes();

            Assert.IsTrue(quotes.All(x => x.Change == 0));
        }

        [TestMethod]
        public void GetQuotes_CalledTwice_ReturnsPriceDeltas_NotEqualToZero()
        {
            var facade = new Watchlist(new StatisticsCalculator());
            var quotes = facade.GetQuotes();
            quotes = facade.UpdateQuotes(quotes.ToList());

            Assert.AreEqual(
                expected: quotes.Count(), 
                actual: quotes.Select(x => x.Change).Distinct().Count());
        }
    }
}
