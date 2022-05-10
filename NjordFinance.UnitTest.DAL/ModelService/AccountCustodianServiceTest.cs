using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public partial class AccountCustodianServiceTest : IModelServiceBaseTest<AccountCustodian>
    {
        /// <inheritdoc/>
        [TestMethod]
        public Task CreateAsync_ValidModel_Returns_Single_Model()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public Task DeleteAsync_InvalidModel_ThrowsModelUpdateException()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public Task DeleteAsync_ValidModel_Returns_True()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public Task GetDefaultAsync_Returns_Single_Model()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ModelExists_KeyIsPresent_Returns_True()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ModelExists_ModelIsPresent_Returns_True()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public Task ReadAsync_Returns_Single_Model()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public Task SelectAllAsync_Returns_Model_List()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public Task SelectWhereAsync_Returns_Model_List()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        [TestMethod]
        public Task UpdateAsync_ValidModel_Returns_True()
        {
            throw new NotImplementedException();
        }
    }

    /// <inheritdoc/>
    public partial class AccountCustodianServiceTest : ModelServiceBaseTest<AccountCustodian>
    {
        /// <inheritdoc/>
        protected override AccountCustodian CreateModelSuccessSample => new()
        {
            CustodianCode = "TESTCREATE",
            DisplayName = "Test custodian create."
        };

        /// <inheritdoc/>
        protected override AccountCustodian DeleteModelSuccessSample => new()
        {
            CustodianCode = "TESTDELPASS",
            DisplayName = "Test custodian delete."
        };

        /// <inheritdoc/>
        protected override AccountCustodian DeleteModelFailSample => new()
        {
            CustodianCode = "TESTDELFAIL",
            DisplayName = "Test custodian delete FAIL."
        };

        /// <inheritdoc/>
        protected override AccountCustodian UpdateModelSuccessSample => new()
        {
            CustodianCode = "TESTUPDATE",
            DisplayName = "Test custodian update."
        };

        /// <inheritdoc/>
        [TestCleanup]
        public override void CleanUp()
        {
            using var context = CreateDbContext();

            context.Database.ExecuteSqlRaw(
                "DELETE FROM NjorDbTest.FinanceApp.AccountCustodian WHERE AcountCustodianID > 0;");
        }

        /// <inheritdoc/>
        [TestInitialize]
        public override void Initialize()
        {
            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample, 
                    x => x.CustodianCode == DeleteModelSuccessSample.CustodianCode),
                (
                    UpdateModelSuccessSample, 
                    x => x.CustodianCode == UpdateModelSuccessSample.CustodianCode));
        }

        /// <inheritdoc/>
        protected override IModelService<AccountCustodian> GetModelService() =>
            BuildModelService<AccountCustodianService>();
    }
}
