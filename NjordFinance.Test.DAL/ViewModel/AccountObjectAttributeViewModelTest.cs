﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordFinance.Model;
using NjordFinance.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Test.ViewModel
{
    [TestClass]
    public class AccountObjectAttributeViewModelTest
    {
        [TestMethod]
        public void ViewModel_Constructor_CreatesInstance()
        {
            var viewModel = new AccountObjectAttributeViewModel(
                new() { AccountObjectId = 1 }, DateTime.Now);

            Assert.IsInstanceOfType(viewModel, typeof(AccountObjectAttributeViewModel));
        }

        [TestMethod]
        public void ViewModel_ToEntity_YieldsEntityInstance()
        {
            var viewModel = new AccountObjectAttributeViewModel(
                new() { AccountObjectId = 1 }, DateTime.Now);

            var entity = viewModel.ToEntryEntity();

            Assert.IsInstanceOfType(entity, typeof(AccountAttributeMemberEntry));

            Assert.IsTrue(
                viewModel.AttributeMemberId == entity.AttributeMemberId
                && viewModel.ParentObject.AccountObjectId == entity.AccountObjectId
                && viewModel.EffectiveDate == entity.EffectiveDate
                && entity.Weight == 100M);
        }
    }
}