using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Test.ViewModel
{
    [TestClass]
    public class SecurityAttributeEntryViewModelTest
    {
        [TestMethod]
        public void ViewModel_AddEntry_KeyNotExists_AddsToCollection()
        {
            var viewModel = new SecurityAttributeViewModel(1, 1, DateTime.Now);

            viewModel.Add(1, 12.75M);

            Assert.IsTrue(viewModel.MemberEntries.First().Value == 12.75M);
        }

        [TestMethod]
        public void ViewModel_AddEntry_KeyExists_ThrowsException()
        {
            var viewModel = new SecurityAttributeViewModel(1, 1, DateTime.Now);

            viewModel.Add(1, 12.75M);

            Assert.ThrowsException<ArgumentException>(() => viewModel.Add(1, 12.75M));
        }

        [TestMethod]
        public void ViewModel_ValidCollection_YieldsValidatedState()
        {
            var viewModel = new SecurityAttributeViewModel(1, 1, DateTime.Now);

            viewModel.Add(1, 65.5M);
            viewModel.Add(2, 34.5M);

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Assert.IsTrue(Validator.TryValidateObject(viewModel, context, validationResults, true));
        }

        [TestMethod]
        public void ViewModel_InvalidCollection_YieldsInvalidState()
        {
            var viewModel = new SecurityAttributeViewModel(1, 1, DateTime.Now);

            viewModel.Add(1, 12.75M);

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(viewModel, context, validationResults, true));
        }

        [TestMethod]
        public void ViewModel_ValidCollection_ToEntityEntries_YieldsValidCollection()
        {
            var viewModel = new SecurityAttributeViewModel(1, 1, DateTime.Now);

            viewModel.Add(1, 65.5M);
            viewModel.Add(2, 34.5M);

            Assert.IsTrue(viewModel.ToEntities().All(a =>
            {
                var context = new ValidationContext(a, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                return Validator.TryValidateObject(a, context, validationResults, true);
            }));
        }
    }
}
