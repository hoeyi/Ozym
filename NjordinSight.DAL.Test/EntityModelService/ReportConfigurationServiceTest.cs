using NjordinSight.EntityModel;
using System.Linq;
using System.Threading.Tasks;

namespace NjordinSight.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public partial class ReportConfigurationServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ReportConfiguration deleted = (await service.SelectAsync(
                predicate: x => x.ConfigurationCode == DeleteModelSuccessSample.ConfigurationCode,
                pageSize: 1))
                .Item1.First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.ReportConfigurations
                .Any(x => x.ConfigurationId == deleted.ConfigurationId));
        }
        
        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ReportConfiguration original = (await service.SelectAsync(
                predicate: x => x.ConfigurationCode == UpdateModelSuccessSample.ConfigurationCode,
                pageSize: 1))
                .Item1.First();

            original.ConfigurationCode = $"{original.ConfigurationCode} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.ReportConfigurations
                .FirstOrDefault(a => a.ConfigurationId == original.ConfigurationId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class ReportConfigurationServiceTest
        : ModelServiceTest<ReportConfiguration>
    {
        protected override ReportConfiguration CreateModelSuccessSample => new()
        {
            ConfigurationCode = "TestCreatePass",
            ConfigurationDescription = "Test create pass",
            XmlDefinition = NjordinSight.Configuration.DefaultConfiguration.Report_Parameters
        };

        protected override ReportConfiguration DeleteModelSuccessSample => new()
        {
            ConfigurationCode = "TestDeletePass",
            ConfigurationDescription = "Test delete pass",
            XmlDefinition = NjordinSight.Configuration.DefaultConfiguration.Report_Parameters
        };

        protected override ReportConfiguration DeleteModelFailSample => new()
        {
            ConfigurationId = -1000,
            ConfigurationCode = "TestDeleteFail",
            ConfigurationDescription = "Test delete fail",
            XmlDefinition = NjordinSight.Configuration.DefaultConfiguration.Report_Parameters
        };

        protected override ReportConfiguration UpdateModelSuccessSample => new()
        {
            ConfigurationCode = "TestUpdatePass",
            ConfigurationDescription = "Test update pass",
            XmlDefinition = NjordinSight.Configuration.DefaultConfiguration.Report_Parameters
        };

        protected override IModelService<ReportConfiguration> GetModelService() =>
            BuildModelService<ReportConfigurationService>();
    }
}
