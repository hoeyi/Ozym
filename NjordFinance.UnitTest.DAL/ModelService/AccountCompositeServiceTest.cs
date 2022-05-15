using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    /// <inheritdoc/>
    [TestClass]
    public partial class AccountCompositeServiceTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            AccountComposite deleted = (await service.SelectWhereAysnc(
                predicate: a =>
                    a.AccountCompositeNavigation.AccountObjectCode ==
                        DeleteModelSuccessSample.AccountCompositeNavigation.AccountObjectCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result &&
                !context.AccountComposites.Any(
                    a => a.AccountCompositeId == deleted.AccountCompositeId));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            AccountComposite original = (await service.SelectWhereAysnc(
                predicate: x =>
                    x.AccountCompositeNavigation.AccountObjectCode ==
                        UpdateModelSuccessSample.AccountCompositeNavigation.AccountObjectCode,
                maxCount: 1))
                .First();

            original.AccountCompositeNavigation.ObjectDisplayName =
                $"{original.AccountCompositeNavigation.ObjectDisplayName} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.AccountComposites
                .Include(a => a.AccountCompositeNavigation)
                .FirstOrDefault(a => a.AccountCompositeId == original.AccountCompositeId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                updated, original));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                updated.AccountCompositeNavigation, original.AccountCompositeNavigation));
        }
    }

    /// <inheritdoc/>
    public partial class AccountCompositeServiceTest : ModelServiceBaseTest<AccountComposite>
    {
        private readonly Random _random = new();

        /// <inheritdoc/>
        protected override AccountComposite CreateModelSuccessSample => new()
        {
            AccountCompositeNavigation = new()
            {
                AccountObjectCode = "TESTCREATEC",
                ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                ObjectDisplayName = "TEST CREATE PASS (C)",
                ObjectDescription = "consectetur adipiscing elit"
            },
        };

        /// <inheritdoc/>
        protected override AccountComposite DeleteModelSuccessSample => new()
        {
            AccountCompositeNavigation = new()
            {
                AccountObjectCode = "TESTDELPASSC",
                ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                ObjectDisplayName = "TEST DELETE PASS (C)",
                ObjectDescription = "Lorem ipsum dolor sit amet"
            }
        };

        /// <inheritdoc/>
        protected override AccountComposite DeleteModelFailSample => new()
        {
            AccountCompositeNavigation = new()
            {
                AccountObjectId = -1000,
                AccountObjectCode = "TESTDELFAILC",
                ObjectType = AccountObjectType.Composite.ConvertToStringCode(),
                ObjectDisplayName = "TEST DELETE FAILURE (C)",
                ObjectDescription = "Lorem ipsum dolor sit amet"
            }
        };

        /// <inheritdoc/>
        protected override AccountComposite UpdateModelSuccessSample => new()
        {
            AccountCompositeNavigation = new()
            {
                AccountObjectCode = "TESTUPDATEC",
                ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                ObjectDisplayName = "TEST UPDATE PASS (C)",
                ObjectDescription = "sed do eiusmod ",
                StartDate = new DateTime(
                            _random.Next(1975, 2022), _random.Next(1, 12), _random.Next(1, 28))
            }
        };

        /// <inheritdoc/>
        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.AccountComposite WHERE AccountCompositeID > 0;" +
                "DELETE FROM FinanceApp.AccountObject WHERE AccountObjectID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        /// <inheritdoc/>
        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.AccountCompositeId,
                    DeleteModelSuccessSample.AccountCompositeNavigation.AccountObjectCode
                },
                new
                {
                    UpdateModelSuccessSample.AccountCompositeId,
                    UpdateModelSuccessSample.AccountCompositeNavigation.AccountObjectCode
                }
            });

            SeedModelsIfNotExists(
                including: a => a.AccountCompositeNavigation,
                (
                    DeleteModelSuccessSample,
                    x => x.AccountCompositeNavigation.AccountObjectCode ==
                        DeleteModelSuccessSample.AccountCompositeNavigation.AccountObjectCode
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.AccountCompositeNavigation.AccountObjectCode ==
                        UpdateModelSuccessSample.AccountCompositeNavigation.AccountObjectCode
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }

        protected override Expression<Func<AccountComposite, object>>[] IncludePaths =>
            new Expression<Func<AccountComposite, object>>[]
        {
            a => a.AccountCompositeNavigation
        };

        protected override int GetKey(AccountComposite model) => model.AccountCompositeId;

        protected override IModelService<AccountComposite> GetModelService() =>
            BuildModelService<AccountCompositeService>();
    }
}
