using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;

namespace NjordFinance.Test.ViewModel
{
    [TestClass]
    public class SecurityAttributeEntryViewModelTest
    {
        [TestMethod]
        public void ViewModel_AddEntry_KeyNotExists_AddsToCollection()
        {
            var viewModel = new SecurityAttributeViewModel(
                new() { SecurityId = 1 }, new() { AttributeId = 1 }, DateTime.Now);

            viewModel.MemberEntries.Add(new()
            {
                AttributeMemberId = 1,
                Weight = 0.1275M
            });

            Assert.IsTrue(viewModel.MemberEntries.First().Weight == 0.1275M);
        }

        [TestMethod]
        public void ViewModel_ValidCollection_YieldsValidatedState()
        {
            var viewModel = new SecurityAttributeViewModel(
                new() { SecurityId = 1 }, new() { AttributeId = 1 }, DateTime.Now);

            viewModel.MemberEntries.AddRange(new SecurityAttributeMemberEntry[]
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

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Assert.IsTrue(Validator.TryValidateObject(viewModel, context, validationResults, true));
        }

        [TestMethod]
        public void ViewModel_InvalidCollection_YieldsInvalidState()
        {
            var viewModel = new SecurityAttributeViewModel(
                new() { SecurityId = 1 }, new() { AttributeId = 1 }, DateTime.Now);

            viewModel.MemberEntries.Add(new()
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
            var viewModel = new SecurityAttributeViewModel(
                new() { SecurityId = 1}, new() { AttributeId = 1}, DateTime.Now);

            viewModel.MemberEntries.AddRange(new SecurityAttributeMemberEntry[]
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

            Assert.IsTrue(viewModel.ToEntities().All(a =>
            {
                var context = new ValidationContext(a, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                return Validator.TryValidateObject(a, context, validationResults, true);
            }));
        }
    }
}
