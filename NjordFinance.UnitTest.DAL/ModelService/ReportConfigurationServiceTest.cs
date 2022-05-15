using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.UnitTest.ModelService
{
    [TestClass]
    public partial class ReportConfigurationServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ReportConfiguration deleted = (await service.SelectWhereAysnc(
                predicate: x => x.ConfigurationCode == DeleteModelSuccessSample.ConfigurationCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.ReportConfigurations
                .Any(x => x.ConfigurationId == deleted.ConfigurationId));
        }
        
        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ReportConfiguration original = (await service.SelectWhereAysnc(
                predicate: x => x.ConfigurationCode == UpdateModelSuccessSample.ConfigurationCode,
                maxCount: 1))
                .First();

            original.ConfigurationCode = $"{original.ConfigurationCode} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.ReportConfigurations
                .FirstOrDefault(a => a.ConfigurationId == original.ConfigurationId);

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class ReportConfigurationServiceTest
        : ModelServiceBaseTest<ReportConfiguration>
    {
        protected override ReportConfiguration CreateModelSuccessSample => new()
        {
            ConfigurationCode = "TestCreatePass",
            ConfigurationDescription = "Test create pass",
            XmlDefinition = Resources.DefaultConfiguration.Report_Parameters
        };

        protected override ReportConfiguration DeleteModelSuccessSample => new()
        {
            ConfigurationCode = "TestDeletePass",
            ConfigurationDescription = "Test delete pass",
            XmlDefinition = Resources.DefaultConfiguration.Report_Parameters
        };

        protected override ReportConfiguration DeleteModelFailSample => new()
        {
            ConfigurationId = -1000,
            ConfigurationCode = "TestDeleteFail",
            ConfigurationDescription = "Test delete fail",
            XmlDefinition = Resources.DefaultConfiguration.Report_Parameters
        };

        protected override ReportConfiguration UpdateModelSuccessSample => new()
        {
            ConfigurationCode = "TestUpdatePass",
            ConfigurationDescription = "Test update pass",
            XmlDefinition = Resources.DefaultConfiguration.Report_Parameters
        };

        [TestCleanup]
        public override void CleanUp()
        {
            Logger.LogInformation("Cleaning up {test}.", GetType().Name);

            using var context = CreateDbContext();

            int recordsDeleted = context.Database.ExecuteSqlRaw(
                "DELETE FROM FinanceApp.ReportConfiguration WHERE ConfigurationID > 0;");

            Logger.LogInformation("Deleted {count} records.", recordsDeleted);
        }

        [TestInitialize]
        public override void Initialize()
        {
            Logger.LogInformation("Seeding with test data {list}.", (object)new[]
            {
                new
                {
                    DeleteModelSuccessSample.ConfigurationCode,
                },
                new
                {
                    UpdateModelSuccessSample.ConfigurationCode
                }
            });

            SeedModelsIfNotExists(
                including: null,
                (
                    DeleteModelSuccessSample,
                    x => x.ConfigurationCode == DeleteModelSuccessSample.ConfigurationCode
                ),
                (
                    UpdateModelSuccessSample,
                    x => x.ConfigurationCode == UpdateModelSuccessSample.ConfigurationCode
                ));

            Logger.LogInformation("{Test} initialized.", GetType().Name);
        }


        protected override int GetKey(ReportConfiguration model) => model.ConfigurationId;

        protected override IModelService<ReportConfiguration> GetModelService() =>
            BuildModelService<ReportConfigurationService>();
    }
}
