using Microsoft.EntityFrameworkCore;
using Ozym.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ozym.Test.EntityModelService
{
    /// <inheritdoc/>
    [TestClass]
    [TestCategory("Integration")]
    public partial class AccountCompositeServiceTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            AccountComposite deleted = (await service.SelectAsync(
                predicate: a =>
                    a.AccountCompositeNavigation.AccountObjectCode ==
                        DeleteModelSuccessSample.AccountCompositeNavigation.AccountObjectCode,
                pageSize: 1))
                .Item1.First();

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

            AccountComposite original = (await service.SelectAsync(
                predicate: x =>
                    x.AccountCompositeNavigation.AccountObjectCode ==
                        UpdateModelSuccessSample.AccountCompositeNavigation.AccountObjectCode,
                pageSize: 1))
                .Item1.First();

            original.AccountCompositeNavigation.ObjectDisplayName =
                $"{original.AccountCompositeNavigation.ObjectDisplayName} - updated";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.AccountComposites
                .Include(a => a.AccountCompositeNavigation)
                .FirstOrDefault(a => a.AccountCompositeId == original.AccountCompositeId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(
                updated, original));

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(
                updated.AccountCompositeNavigation, original.AccountCompositeNavigation));
        }
    }

    /// <inheritdoc/>
    public partial class AccountCompositeServiceTest : ModelServiceTest<AccountComposite>
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
                AccountObjectCode = "TESTDELPASSC"
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
                AccountObjectCode = "TESTUPDATEC"
            }
        };

        protected override Expression<Func<AccountComposite, object>>[] IncludePaths =>
            new Expression<Func<AccountComposite, object>>[]
        {
            a => a.AccountCompositeNavigation
        };

        protected override IModelService<AccountComposite> GetModelService() =>
            BuildModelService<AccountCompositeService>();
    }
}
