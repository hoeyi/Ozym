﻿using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NjordFinance.UnitTest
{
    [TestClass]
    public class SimplePropertiesAreEqualTest
    {
        [TestMethod]
        public void SimplePropertiesAreEqual_MatchedValues_Returns_True()
        {
            Account account1 = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TEST000_SEED",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST ACCOUNT #000",
                    ObjectDescription = "Account used for testing purposes."
                },
                AccountNumber = "0000-0000-00"
            };

            Account account2 = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TEST000_SEED",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST ACCOUNT #000",
                    ObjectDescription = "Account used for testing purposes."
                },
                AccountNumber = "0000-0000-00"
            };

            // Check complex objects for parity in non-complex properties.
            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                account1, account2));

            Assert.IsTrue(UnitTest.SimplePropertiesAreEqual(
                account1.AccountNavigation, account2.AccountNavigation));
        }

        [TestMethod]
        public void SimplePropertiesAreEqual_UnmatchedValues_Returns_False()
        {
            Account account1 = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TEST000_SEED",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST ACCOUNT #000",
                    ObjectDescription = "Account used for testing purposes."
                },
                AccountNumber = "0000-0000-00"
            };

            Account account2 = new()
            {
                AccountNavigation = new()
                {
                    AccountObjectCode = "TEST000",
                    ObjectType = AccountObjectType.Account.ConvertToStringCode(),
                    ObjectDisplayName = "TEST ACCOUNT #000",
                    ObjectDescription = "Account used for testing purposes."
                },
                AccountNumber = "0000-0000"
            };

            // Check complex objects for parity in non-complex properties.
            Assert.IsFalse(UnitTest.SimplePropertiesAreEqual(
                account1, account2));

            Assert.IsFalse(UnitTest.SimplePropertiesAreEqual(
                account1.AccountNavigation, account2.AccountNavigation));
        }
    }
}