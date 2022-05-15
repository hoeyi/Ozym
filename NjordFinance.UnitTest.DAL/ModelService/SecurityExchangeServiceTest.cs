using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    [TestClass]
    public partial class SecurityExchangeServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityExchange deleted = (await service.SelectWhereAysnc(
                predicate: x => x.ExchangeCode == DeleteModelSuccessSample.ExchangeCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.SecurityExchanges
                .Any(x => x.ExchangeId == deleted.ExchangeId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityExchange original = (await service.SelectWhereAysnc(
                predicate: x => x.ExchangeCode == UpdateModelSuccessSample.ExchangeCode,
                maxCount: 1))
                .First();

            original.ExchangeCode = $"{original.ExchangeCode}-u";
            original.ExchangeDescription = $"{original.ExchangeDescription} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.SecurityExchanges
                .FirstOrDefault(a => a.ExchangeId == original.ExchangeId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class SecurityExchangeServiceTest
        : ModelServiceBaseTest<SecurityExchange>
    {
        protected override SecurityExchange CreateModelSuccessSample => new()
        {
            ExchangeCode = "TestCreatePass",
            ExchangeDescription = "Test create pass"
        };

        protected override SecurityExchange DeleteModelSuccessSample => new()
        {
            ExchangeCode = "TestDeletePass",
            ExchangeDescription = "Test delete pass"
        };

        protected override SecurityExchange DeleteModelFailSample => new()
        {
            ExchangeId = -1000,
            ExchangeCode = "TestDeleteFail",
            ExchangeDescription = "Test delete fail"
        };

        protected override SecurityExchange UpdateModelSuccessSample => new()
        {
            ExchangeCode = "TestUpdatePass",
            ExchangeDescription = "Test update pass"
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.SecurityExchange WHERE ExchangeID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.ExchangeCode,
                },
                new
                {
                    UpdateModelSuccessSample.ExchangeCode
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.ExchangeCode == DeleteModelSuccessSample.ExchangeCode
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.ExchangeCode == UpdateModelSuccessSample.ExchangeCode
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override int GetKey(SecurityExchange model) => model.ExchangeId;

        protected override IModelService<SecurityExchange> GetModelService() =>
            BuildModelService<SecurityExchangeService>();
    }
}
