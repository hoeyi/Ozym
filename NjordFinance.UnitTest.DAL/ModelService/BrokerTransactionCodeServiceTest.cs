using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Exceptions;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    [TestClass]
    public partial class BrokerTransactionCodeServiceTest
        : IModelServiceBaseTest<BrokerTransactionCode>
    {
        /// <inheritdoc/>
        [TestMethod]
        public override async Task CreateAsync_ValidModel_Returns_Single_Model()
        {
            var service = GetModelService();

            var code = await service.CreateAsync(CreateModelSuccessSample);

            using var context = CreateDbContext();

            var savedCode = context.BrokerTransactionCodes
                .FirstOrDefault(x => x.TransactionCodeId == code.TransactionCodeId);

            Assert.IsTrue(code.TransactionCodeId > 0);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(savedCode, code));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            var code = (await service.SelectWhereAysnc(
                predicate: x => x.TransactionCode == DeleteModelSuccessSample.TransactionCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(code);

            using var context = CreateDbContext();

            Assert.IsTrue(result &&
                !context.BrokerTransactionCodes.Any(
                    x => x.TransactionCodeId == code.TransactionCodeId));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task SelectWhereAsync_Returns_Model_List()
        {
            BrokerTransactionCode expected = GetLast();
            var service = GetModelService();

            var observed = (await service.SelectWhereAysnc(
                predicate: a => a.TransactionCodeId == expected.TransactionCodeId,
                maxCount: 1))
                .First();

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(expected, observed));
        }

        /// <inheritdoc/>
        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            BrokerTransactionCode code = (await service.SelectWhereAysnc(
                predicate: x => x.TransactionCode == UpdateModelSuccessSample.TransactionCode,
                maxCount: 1))
                .First();

            code.DisplayName = $"{code.DisplayName} - updated";

            var result = await service.UpdateAsync(code);

            using var context = CreateDbContext();

            var savedCode = context.BrokerTransactionCodes
                .FirstOrDefault(x => x.TransactionCodeId == code.TransactionCodeId);

            Assert.IsTrue(result && UnitTest.SimplePropertiesAreEqual(savedCode, code));
        }
    }
    public partial class BrokerTransactionCodeServiceTest
        : ModelServiceBaseTest<BrokerTransactionCode>
    {
        /// <inheritdoc/>
        protected override BrokerTransactionCode CreateModelSuccessSample => new()
        {
            TransactionCode = "TCP",
            DisplayName = "Test create pass",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
        };

        /// <inheritdoc/>
        protected override BrokerTransactionCode DeleteModelSuccessSample => new()
        {
            TransactionCode = "TDP",
            DisplayName = "Test delete pass",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
        };

        /// <inheritdoc/>
        protected override BrokerTransactionCode DeleteModelFailSample => new()
        {
            TransactionCodeId = -1000,
            TransactionCode = "TDF",
            DisplayName = "Test delete fail",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
        };

        /// <inheritdoc/>
        protected override BrokerTransactionCode UpdateModelSuccessSample => new()
        {
            TransactionCode = "TUP",
            DisplayName = "Test update pass",
            QuantityEffect = 1,
            ContributionWithdrawalEffect = 1,
            CashEffect = 1
        };

        /// <inheritdoc/>
        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}", nameof(BrokerTransactionCodeServiceTest));

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM NjordDbTest.FinanceApp.BrokerTransactionCode WHERE TransactionCodeId > 0;");

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
                    DeleteModelSuccessSample.TransactionCodeId,
                    DeleteModelSuccessSample.TransactionCode
                },
                new
                {
                    UpdateModelSuccessSample.TransactionCodeId,
                    UpdateModelSuccessSample.TransactionCode
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.TransactionCode == DeleteModelSuccessSample.TransactionCode
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.TransactionCode == UpdateModelSuccessSample.TransactionCode
                ));
        }

        /// <inheritdoc/>
        protected override int GetKey(BrokerTransactionCode model) => model.TransactionCodeId;

        /// <inheritdoc/>
        protected override IModelService<BrokerTransactionCode> GetModelService() =>
            BuildModelService<BrokerTransactionCodeService>();
    }
}
