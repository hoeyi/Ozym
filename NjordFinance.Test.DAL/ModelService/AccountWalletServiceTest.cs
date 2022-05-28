using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public class AccountWalletServiceTest : ModelBatchServiceTest<AccountWallet>
    {
        [TestMethod]
        public override void ModelExists_KeyIsPresent_Returns_True()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void ModelExists_ModelIsPresent_Returns_True()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override Task ReadAsync_Returns_Single_Model()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void RemovePendingSave_IsDirty_Is_True()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override Task SelectAllAsync_Returns_Model_List()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override Task SelectWhereAsync_Returns_Model_ExpectedCollection()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void UpdatePendingSave_IsDirty_Is_True()
        {
            var service = GetModelService();

            var model = service.SelectAllAsync().Result.FirstOrDefault();

            model.AddressCode = $"{model.AddressCode}-u";

            Assert.IsTrue(service.IsDirty);
        }

        protected override IModelBatchService<AccountWallet> GetModelService()
        {
            var service = BuildModelService<AccountWalletService>();
            service.ForParent(parentId: -3);

            return service;
        }
    }
}
