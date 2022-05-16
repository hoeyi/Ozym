using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    [TestClass]
    public partial class InvestmentStrategyServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            using var context = CreateDbContext();
            InvestmentStrategy deleted = (await service.SelectWhereAysnc(
                predicate: x => x.DisplayName == DeleteModelSuccessSample.DisplayName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);


            Assert.IsTrue(result && !context.InvestmentStrategies
                .Any(x => x.InvestmentStrategyId == deleted.InvestmentStrategyId));
        }

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

    public partial class InvestmentStrategyServiceTest
        : ModelServiceTest<InvestmentStrategy>
    {
        protected override InvestmentStrategy CreateModelSuccessSample => new()
        {
            DisplayName = "Test create pass"
        };

        protected override InvestmentStrategy DeleteModelSuccessSample => new()
        {
            DisplayName = "Test delete pass"
        };

        protected override InvestmentStrategy DeleteModelFailSample => new()
        {
            InvestmentStrategyId = -1000,
            DisplayName = "Test delete fail"
        };

        protected override InvestmentStrategy UpdateModelSuccessSample => new()
        {
            DisplayName = "Test update success"
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.InvestmentStrategy WHERE InvestmentStrategyID > 0;");

            Logger.LogInformation("Deleted {count} records", recordsDeleted);
        }

        [TestInitialize]
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

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.DisplayName == DeleteModelSuccessSample.DisplayName
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.DisplayName == UpdateModelSuccessSample.DisplayName
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override int GetKey(InvestmentStrategy model) => model.InvestmentStrategyId;

        protected override IModelService<InvestmentStrategy> GetModelService() =>
            BuildModelService<InvestmentStrategyService>();

    }
}
