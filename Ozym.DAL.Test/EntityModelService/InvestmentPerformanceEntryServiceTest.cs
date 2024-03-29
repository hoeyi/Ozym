﻿using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ozym.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class InvestmentPerformanceEntryServiceTest 
        : ModelCollectionServiceTest<InvestmentPerformanceEntry>
    {
        private const int _accountObjectId = -8;

        /// <inheritdoc/>
        protected override Expression<Func<InvestmentPerformanceEntry, bool>> ParentExpression =>
               x => x.AccountObjectId == _accountObjectId;

        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="ReadAsync_Returns_Single_Model"/> the 
        /// <see cref="InvestmentPerformanceEntry"/> entity does not have a single-integer key.</remarks>
        public override Task ReadAsync_Returns_Single_Model()
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task SelectWhereAsync_Returns_Model_ExpectedCollection()
        {
            var model = GetLast(ParentExpression);

            var service = GetModelService();

            Expression<Func<InvestmentPerformanceEntry, bool>> expression = x =>
                x.AccountObjectId == model.AccountObjectId && x.FromDate == model.FromDate;

            var models = (await service.SelectAsync(predicate: expression, pageSize: 1)).Item1;;

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(models.Last(), model));
        }

        /// <inheritdoc/>
        protected override IModelCollectionService<InvestmentPerformanceEntry> GetModelService() =>
            BuildModelService<InvestmentPerformanceService>();
    }
}
