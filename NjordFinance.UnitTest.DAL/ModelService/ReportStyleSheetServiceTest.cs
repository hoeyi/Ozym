using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class ReportStyleSheetServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ReportStyleSheet deleted = (await service.SelectWhereAysnc(
                predicate: x => x.StyleSheetCode == DeleteModelSuccessSample.StyleSheetCode,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.ReportConfigurations
                .Any(x => x.ConfigurationId == deleted.StyleSheetId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            ReportStyleSheet original = (await service.SelectWhereAysnc(
                predicate: x => x.StyleSheetCode == UpdateModelSuccessSample.StyleSheetCode,
                maxCount: 1))
                .First();

            original.StyleSheetCode = $"{original.StyleSheetCode} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.ReportStyleSheets
                .FirstOrDefault(a => a.StyleSheetId == original.StyleSheetId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }

    }

    public partial class ReportStyleSheetServiceTest
        : ModelServiceTest<ReportStyleSheet>
    {
        protected override ReportStyleSheet CreateModelSuccessSample => new()
        {
            StyleSheetCode = "TestCreatePass",
            StyleSheetDescription = "Test create pass",
            XmlDefinition = Resources.DefaultConfiguration.Report_StyleSheet
        };

        protected override ReportStyleSheet DeleteModelSuccessSample => new()
        {
            StyleSheetCode = "TestDeletePass",
            StyleSheetDescription = "Test delete pass",
            XmlDefinition = Resources.DefaultConfiguration.Report_StyleSheet
        };

        protected override ReportStyleSheet DeleteModelFailSample => new()
        {
            StyleSheetId = -1000,
            StyleSheetCode = "TestDeleteFail",
            StyleSheetDescription = "Test delete fail",
            XmlDefinition = Resources.DefaultConfiguration.Report_StyleSheet
        };

        protected override ReportStyleSheet UpdateModelSuccessSample => new()
        {
            StyleSheetCode = "TestUpdatePass",
            StyleSheetDescription = "Test update pass",
            XmlDefinition = Resources.DefaultConfiguration.Report_StyleSheet
        };

        protected override int GetKey(ReportStyleSheet model) => model.StyleSheetId;

        protected override IModelService<ReportStyleSheet> GetModelService() =>
            BuildModelService<ReportStyleSheetService>();
    }
}
