using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.BusinessLogic.Functions;
using NjordinSight.BusinessLogic.MarketFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Test.BusinessLogic
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
