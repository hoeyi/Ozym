using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
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
        protected override AccountCustodian CreateModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        protected override AccountCustodian DeleteModelSuccessSample => throw new NotImplementedException();

        /// <inheritdoc/>
        protected override AccountCustodian DeleteModelFailSample => throw new NotImplementedException();
        
        /// <inheritdoc/>
        protected override AccountCustodian UpdateModelSuccessSample => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override IModelService<AccountCustodian> GetModelService() =>
            new AccountCustodianService(
                contextFactory: UnitTest.DbContextFactory,
                modelMetadata: new ModelMetadataService(),
                logger: UnitTest.Logger);
    }
}
