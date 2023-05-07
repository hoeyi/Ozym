using NjordFinance.EntityModelService.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class ReferenceDataServiceTest
    {
        private static readonly IQueryService _dataService = 
            new QueryService(TestUtility.DbContextFactory);

        [TestMethod]
        public async Task GetAccountCustodianDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetAccountCustodianDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetAccountDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetAccountDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetBankTransactionCodeDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetBankTransactionCodeDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetBrokerTransactionCodeDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetBrokerTransactionCodeDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetCashOrExternalSecurityDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetCashOrExternalSecurityDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetCryptocurrencyDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetCryptocurrencyDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetMarketIndexDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetMarketIndexDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetSecurityTypeDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetSecurityTypeDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetSecurityTypeGroupDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetSecurityTypeGroupDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }

        [TestMethod]
        public async Task GetTransactableSecurityDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetTransactableSecurityDTOsAsync();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }


        [TestMethod]
        public async Task GetModelAttributeMemberDTOsAsync_ReturnsCollection()
        {
            var result = await _dataService.GetModelAttributeMemberDTOsAsync(attributeId: -1);

            Assert.IsInstanceOfType(result, typeof(IEnumerable<LookupModel<int, string>>));
        }
    }
}
