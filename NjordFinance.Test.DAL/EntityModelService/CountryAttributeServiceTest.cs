using NjordFinance.EntityModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Test.EntityModelService
{
    [TestClass]
    public class CountryAttributeServiceTest : ModelBatchServiceTest<CountryAttributeMemberEntry>
    {
        private const int _countryId = -682;
        protected override Expression<Func<CountryAttributeMemberEntry, bool>> ParentExpression =>
            x => x.CountryId == _countryId;

        /// <inheritdoc/>
        /// <remarks>Always passes because <see cref="v"/> the 
        /// <see cref="CountryAttributeMemberEntry"/> entity does not have a single-integer key.</remarks>
        [TestMethod]
        public override Task ReadAsync_Returns_Single_Model()
        {
            return Task.CompletedTask;
        }

        [TestMethod]
        public override async Task SelectWhereAsync_Returns_Model_ExpectedCollection()
        {
            var model = GetLast(ParentExpression);

            var service = GetModelService();

            Expression<Func<CountryAttributeMemberEntry, bool>> expression = x =>
                x.CountryId == model.CountryId && x.AttributeMemberId == model.AttributeMemberId
                && x.EffectiveDate == model.EffectiveDate;

            var models = await service.SelectWhereAysnc(predicate: expression, maxCount: 1);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(models.Last(), model));
        }

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.Weight *= 0.5M;

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<CountryAttributeMemberEntry> GetModelService() =>
            BuildModelService<CountryAttributeService>().WithParent(parentId: _countryId);
    }
}
