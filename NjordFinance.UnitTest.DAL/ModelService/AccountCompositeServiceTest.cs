using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
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
    public partial class AccountCompositeServiceTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public override async Task CreateAsync_ValidModel_Returns_Single_Model()
        {
            var service = GetModelService();

            AccountComposite composite = await service.CreateAsync(CreateModelSuccessSample);

            using var context = CreateDbContext();

            var savedComposite = context.AccountComposites
                .Include(a => a.AccountCompositeNavigation)
                .FirstOrDefault(a => a.AccountCompositeId == composite.AccountCompositeId);

            Assert.IsTrue(composite.AccountCompositeId > 0);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedComposite, composite));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedComposite.AccountCompositeNavigation, composite.AccountCompositeNavigation));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            AccountComposite composite = (await service.SelectWhereAysnc(
                predicate: a =>
                    a.AccountCompositeNavigation.AccountObjectCode ==
                        DeleteModelSuccessSample.AccountCompositeNavigation.AccountObjectCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(composite);

            using var context = CreateDbContext();

            Assert.IsTrue(result &&
                !context.AccountComposites.Any(
                    a => a.AccountCompositeId == composite.AccountCompositeId));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task SelectWhereAsync_Returns_Model_List()
        {
            AccountComposite expected = GetLast(a => a.AccountCompositeNavigation);

            var service = GetModelService();

            var observed = (await service.SelectWhereAysnc(
                predicate: a => a.AccountCompositeNavigation.AccountObjectId
                    == expected.AccountCompositeId,
                maxCount: 1))
                .First();

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(expected, observed));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            AccountComposite composite = (await service.SelectWhereAysnc(
                predicate: x =>
                    x.AccountCompositeNavigation.AccountObjectCode ==
                        UpdateModelSuccessSample.AccountCompositeNavigation.AccountObjectCode,
                maxCount: 1))
                .First();

            composite.AccountCompositeNavigation.ObjectDisplayName =
                $"{composite.AccountCompositeNavigation.ObjectDisplayName} - updated";

            var result = await service.UpdateAsync(composite);

            using var context = CreateDbContext();

            var savedComposite = context.AccountComposites
                .Include(a => a.AccountCompositeNavigation)
                .FirstOrDefault(a => a.AccountCompositeId == composite.AccountCompositeId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedComposite, composite));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                savedComposite.AccountCompositeNavigation, composite.AccountCompositeNavigation));
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
            Logger.LogInformation(
                "Cleaning up {test}.", new { Name = nameof(AccountCompositeServiceTest) });

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM NjordDbTest.FinanceApp.AccountComposite WHERE AccountCompositeID > 0;" +
                "DELETE FROM NjordDbTest.FinanceApp.AccountObject WHERE AccountObjectID > 0;");

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
        }

        /// <inheritdoc/>
        protected override int GetKey(AccountComposite model) => model.AccountCompositeId;

        /// <inheritdoc/>
        protected override IModelService<AccountComposite> GetModelService() =>
            BuildModelService<AccountCompositeService>();
    }
}
