﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.ModelService;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    [TestClass]
    public partial class SecurityTypeGroupServiceTest
    {
        [TestMethod]
        public override async Task DeleteAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityTypeGroup deleted = (await service.SelectWhereAysnc(
                predicate: x => x.SecurityTypeGroupName == 
                    DeleteModelSuccessSample.SecurityTypeGroupName,
                maxCount: 1))
                .First();

            var result = await service.DeleteAsync(deleted);

            using var context = CreateDbContext();

            Assert.IsTrue(result && !context.SecurityTypeGroups
                .Any(x => x.SecurityTypeGroupId == deleted.SecurityTypeGroupId));
        }

        [TestMethod]
        public override async Task UpdateAsync_ValidModel_Returns_True()
        {
            var service = GetModelService();

            SecurityTypeGroup original = (await service.SelectWhereAysnc(
                predicate: x => x.SecurityTypeGroupName == 
                    UpdateModelSuccessSample.SecurityTypeGroupName,
                maxCount: 1))
                .First();

            original.SecurityTypeGroupName = $"{original.SecurityTypeGroupName} - u";

            var result = await service.UpdateAsync(original);

            using var context = CreateDbContext();

            var updated = context.SecurityTypeGroups
                .FirstOrDefault(a => a.SecurityTypeGroupId == original.SecurityTypeGroupId);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(updated, original));
        }
    }

    public partial class SecurityTypeGroupServiceTest
        : ModelServiceTest<SecurityTypeGroup>
    {
        protected override SecurityTypeGroup CreateModelSuccessSample => new()
        {
            SecurityTypeGroupNavigation = new()
            {
                AttributeId = -2,
                DisplayOrder = 0
            },
            SecurityTypeGroupName = "Test create pass"
        };

        protected override SecurityTypeGroup DeleteModelSuccessSample => new()
        {
            SecurityTypeGroupNavigation = new()
            {
                AttributeId = -2,
                DisplayName = "Test delete pass",
                DisplayOrder = 1
            },
            SecurityTypeGroupName = "Test delete pass"
        };

        protected override SecurityTypeGroup DeleteModelFailSample => new()
        {
            SecurityTypeGroupNavigation = new()
            {
                AttributeMemberId = -1000,
                AttributeId = -2,
                DisplayName = "Test delete fail",
                DisplayOrder = 2
            },
            SecurityTypeGroupId = -1000,
            SecurityTypeGroupName = "Test delete fail"
        };

        protected override SecurityTypeGroup UpdateModelSuccessSample => new()
        {
            SecurityTypeGroupNavigation = new()
            {
                AttributeId = -2,
                DisplayName = "Test update pass",
                DisplayOrder = 2
            },
            SecurityTypeGroupName = "Test update pass"
        };

        protected override Expression<Func<SecurityTypeGroup, object>>[] IncludePaths =>
            new Expression<Func<SecurityTypeGroup, object>>[]
            {
                a => a.SecurityTypeGroupNavigation
            };

        protected override IModelService<SecurityTypeGroup> GetModelService() =>
            BuildModelService<SecurityTypeGroupService>();
    }
}