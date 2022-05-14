using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    /// <inheritdoc/>
    [TestClass]
    public partial class InvestmentStrategyServiceTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            InvestmentStrategy deleted = (await service.SelectWhereAysnc(
                predicate: x => x.DisplayName == DeleteModelSuccessSample.DisplayName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.InvestmentStrategies
                .Any(x => x.InvestmentStrategyId == deleted.InvestmentStrategyId));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            InvestmentStrategy original = (await service.SelectWhereAysnc(
                predicate: x => x.DisplayName == UpdateModelSuccessSample.DisplayName,
                maxCount: 1))
                .First();

            original.DisplayName = $"{original.DisplayName} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.InvestmentStrategies
                .FirstOrDefault(a => a.InvestmentStrategyId == original.InvestmentStrategyId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }
    }

    /// <inheritdoc/>
    public partial class InvestmentStrategyServiceTest
        : ModelServiceBaseTest<InvestmentStrategy>
    {
        /// <inheritdoc/>
        protected override InvestmentStrategy CreateModelSuccessSample => new()
        {
            DisplayName = "Test create pass"
        };

        /// <inheritdoc/>
        protected override InvestmentStrategy DeleteModelSuccessSample => new()
        {
            DisplayName = "Test delete pass"
        };

        /// <inheritdoc/>
        protected override InvestmentStrategy DeleteModelFailSample => new()
        {
            InvestmentStrategyId = -1000,
            DisplayName = "Test delete fail"
        };

        /// <inheritdoc/>
        protected override InvestmentStrategy UpdateModelSuccessSample => new()
        {
            DisplayName = "Test update success"
        };

        /// <inheritdoc/>
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", nameof(InvestmentStrategyServiceTest));

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM NjordDbTest.FinanceApp.InvestmentStrategy WHERE " +
                "IvestmentStrategyId > 0;");

            Logger.LogInformation("Deleted {count} records", recordsDeleted);
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.DisplayName
                },
                new
                {
                    UpdateModelSuccessSample.DisplayName
                }
            });
        }

        /// <inheritdoc/>
        protected override int GetKey(InvestmentStrategy model) => model.InvestmentStrategyId;

        /// <inheritdoc/>
        protected override IModelService<InvestmentStrategy> GetModelService() =>
            BuildModelService<InvestmentStrategyService>();

    }
}
