using System;
using System.Linq;
using NjordFinance.ModelService.Abstractions;
using NjordFinance.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NjordFinance.Test.Unit
{
    [TestClass]
    [TestCategory("UnitTest")]
    public class ExpressionExtensionTest
    {
        [TestMethod]
        public void GetKeyExpression_SimpleKey_MatchesExpectedModel()
        {
            // setup
            var models = new Account[]
            {
                new(){ AccountId = 1 },
                new(){ AccountId = 2 }
            };

            var observedExpression = models[0].GetKeyExpression();

            // execute
            Assert.AreSame(
                expected: models[0],
                actual: models.AsQueryable().Where(observedExpression).First());
        }

        [TestMethod]
        public void GetKeyExpression_CompositeKey_MatchesExpectedModel()
        {
            // setup
            var date = DateTime.Now;

            var models = new InvestmentPerformanceAttributeMemberEntry[]
            {
                new()
                {
                    AccountObjectId = 1,
                    AttributeMemberId = 10,
                    FromDate = date
                },
                new()
                {
                    AccountObjectId = 1,
                    AttributeMemberId = 10,
                    FromDate = date
                }
            };

            var observedExpression = models[0].GetKeyExpression();

            // execute
            Assert.AreSame(
                expected: models[0],
                actual: models.AsQueryable().Where(observedExpression).First());
        }

    }
}
