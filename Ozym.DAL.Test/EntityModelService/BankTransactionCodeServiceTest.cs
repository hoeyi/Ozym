﻿using Ozym.EntityModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ozym.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public partial class BankTransactionCodeServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            BankTransactionCode deleted = (await service.SelectAsync(x =>
                x.TransactionCode == DeleteModelSuccessSample.TransactionCode, 1))
                .Item1.First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.BankTransactionCodes
                .Any(x => x.TransactionCodeId == deleted.TransactionCodeId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            BankTransactionCode original = (await service.SelectAsync(
                predicate: a => a.TransactionCode == UpdateModelSuccessSample.TransactionCode,
                pageSize: 1))
                .Item1.First();

            original.DisplayName = "Test update pass EDIT";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.BankTransactionCodes
                .FirstOrDefault(a => a.TransactionCodeId == original.TransactionCodeId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }
    }

    public partial class BankTransactionCodeServiceTest 
        : ModelServiceTest<BankTransactionCode>
    {
        protected override BankTransactionCode CreateModelSuccessSample => new()
        {
            TransactionCode = "NEWPASS",
            DisplayName = "Test create pass."
        };

        protected override BankTransactionCode DeleteModelSuccessSample => new()
        {
            TransactionCode = "DELPASS"
        };

        protected override BankTransactionCode DeleteModelFailSample => new()
        {
            TransactionCodeId = -1000,
            TransactionCode = "DELFAIL",
            DisplayName = "Test delete fail."
        };

        protected override BankTransactionCode UpdateModelSuccessSample => new()
        {
            TransactionCode = "UPDPASS"
        };

        protected override IModelService<BankTransactionCode> GetModelService() =>
            BuildModelService<BankTransactionCodeService>();
    }
}
