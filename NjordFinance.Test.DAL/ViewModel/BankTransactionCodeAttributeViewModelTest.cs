using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;
using NjordFinance.Model.ViewModel;

namespace NjordFinance.Test.ViewModel
{
    [TestClass]
    public class BankTransactionCodeAttributeViewModelTest
    {
        //[TestMethod]
        //public void ViewModel_Constructor_CreatesInstance()
        //{
        //    var viewModel = new BankTransactionCodeAttributeViewModel(
        //        new() { TransactionCodeId = 1 }, DateTime.Now);

        //    Assert.IsInstanceOfType(viewModel, typeof(BankTransactionCodeAttributeViewModel));
        //}

        //[TestMethod]
        //public void ViewModel_ToEntity_YieldsEntityInstance()
        //{
        //    var viewModel = new BankTransactionCodeAttributeViewModel(
        //        new() { TransactionCodeId = 1 }, DateTime.Now);

        //    var entity = viewModel.ToEntryEntity();

        //    Assert.IsInstanceOfType(entity, typeof(BankTransactionCodeAttributeMemberEntry));

        //    Assert.IsTrue(
        //        viewModel.AttributeMemberId == entity.AttributeMemberId
        //        && viewModel.ParentObject.TransactionCodeId == entity.TransactionCodeId
        //        && viewModel.EffectiveDate == entity.EffectiveDate
        //        && entity.Weight == 100M);
        //}
    }
}
