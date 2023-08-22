using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Deprecated;

namespace NjordinSight.Test.DataTransfer
{
    [TestClass]
    [TestCategory("Unit")]
    public class SecurityAttributeEntryDtoTest
    {
        [TestMethod]
        public void ViewModel_AddEntry_KeyNotExists_AddsToCollection()
        {
            var currentDate = DateTime.UtcNow.Date;

            var viewModel = new SecurityAttributeGrouping(
                new() { SecurityId = 1 }, new() { AttributeId = 1 }, currentDate);

            viewModel.AddEntry(new()
            {
                SecurityId = 1,
                AttributeMemberId = 1,
                EffectiveDate = currentDate,
                Weight = 0.1275M
            });

            Assert.IsTrue(viewModel.Entries.First().Weight == 0.1275M);
        }

        [TestMethod]
        public void ViewModel_ValidCollection_YieldsValidatedState()
        {
            var currentDate = DateTime.UtcNow.Date;

            var viewModel = new SecurityAttributeGrouping(
                new() { SecurityId = 1 }, new() { AttributeId = 1 }, currentDate);

            viewModel.AddRange(new SecurityAttributeMemberEntry[]
                {
                    new()
                    {
                        AttributeMemberId = 1,
                        SecurityId = 1,
                        EffectiveDate = currentDate,
                        Weight = 0.655M
                    },
                    new()
                    {
                        AttributeMemberId = 2,
                        SecurityId = 1,
                        EffectiveDate = currentDate,
                        Weight = 0.345M
                    }
                });

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(viewModel, context, validationResults, true);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ViewModel_InvalidCollection_YieldsInvalidState()
        {
            var viewModel = new SecurityAttributeGrouping(
                new() { SecurityId = 1 }, new() { AttributeId = 1 }, DateTime.Now);

            viewModel.AddEntry(new()
            {
                AttributeMemberId = 1,
                Weight = 0.1275M
            });

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(viewModel, context, validationResults, true));
        }

        [TestMethod]
        public void ViewModel_ValidCollection_ToEntityEntries_YieldsValidCollection()
        {
            var viewModel = new SecurityAttributeGrouping(
                new() { SecurityId = 1}, new() { AttributeId = 1}, DateTime.Now);

            viewModel.AddRange(new SecurityAttributeMemberEntry[]
                {
                    new()
                    {
                        AttributeMemberId = 1,
                        Weight = 0.655M
                    },
                    new()
                    {
                        AttributeMemberId = 2,
                        Weight = 0.345M
                    }
                });

            Assert.IsTrue(viewModel.Entries.All(a =>
            {
                var context = new ValidationContext(a, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                return Validator.TryValidateObject(a, context, validationResults, true);
            }));
        }
    }
}
