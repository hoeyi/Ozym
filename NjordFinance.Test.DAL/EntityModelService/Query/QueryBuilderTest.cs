using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NjordFinance.EntityModel;
using NjordFinance.EntityModel.Context;
using NjordFinance.EntityModelService.Query;

namespace NjordFinance.Test.ModelService.Query
{
    [TestClass]
    public class QueryBuilderTest
    {
        [TestMethod]
        public async Task QueryBuilder_NoRelationship_ExecuteAsync_YieldsEnumerableInstance()
        {
            using var context = CreateContext();

            using var queryBuilder = new QueryBuilder<Country>(context);

            var result = await queryBuilder.SelectWhereAsync(predicate: x => true);

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Country>));
            Assert.IsTrue(condition: result.Any());
        }

        [TestMethod]
        public async Task QueryBuilder_DirectRelationship_ExecuteAsync_YieldsEnumerableInstance()
        {
            using var context = CreateContext();

            using IQueryBuilder<Account> queryBuilder = new QueryBuilder<Account>(context)
                .WithDirectRelationship(a => a.AccountNavigation);


            var result = await queryBuilder.Build().SelectWhereAsync(x => true);

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Account>));
            Assert.IsTrue(condition: result.Any());
        }

        [TestMethod]
        public async Task QueryBuilder_IndirectRelationship_ExecuteAsync_YieldsEnumerableInstance()
        {
            using var context = CreateContext();

            using IQueryBuilder<Security> queryBuilder = new QueryBuilder<Security>(context)
                .WithDirectRelationship(s => s.SecuritySymbols)
                .WithDirectRelationship(s => s.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(s => s.SecurityTypeGroup);

            var result = await queryBuilder.Build()
                .SelectWhereAsync(predicate: x => true);
                

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Security>));
            Assert.IsTrue(condition: result.Any());
        }

        private FinanceDbContext CreateContext() => TestUtility.DbContextFactory.CreateDbContext();
    }
}
