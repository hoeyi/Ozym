using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NjordFinance.Model;
using NjordFinance.ModelService.Query;
using NjordFinance.Context;

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

            using IQueryBuilder<Account> queryBuilder = new QueryBuilder<Account>(context);

            var result = await queryBuilder
                .WithDirectRelationship(a => a.AccountNavigation)
                .SelectWhereAsync(predicate: x => true);

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Account>));
            Assert.IsTrue(condition: result.Any());
        }

        [TestMethod]
        public async Task QueryBuilder_IndirectRelationship_ExecuteAsync_YieldsEnumerableInstance()
        {
            using var context = CreateContext();

            using IQueryBuilder<Security> queryBuilder = new QueryBuilder<Security>(context);

            var result = await queryBuilder
                .WithDirectRelationship(s => s.SecuritySymbols)
                .WithDirectRelationship(s => s.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(s => s.SecurityTypeGroup)
                .SelectWhereAsync(predicate: x => true);
                

            Assert.IsInstanceOfType(result, typeof(IEnumerable<Security>));
            Assert.IsTrue(condition: result.Any());
        }

        private FinanceDbContext CreateContext() => TestUtility.DbContextFactory.CreateDbContext();
    }
}
