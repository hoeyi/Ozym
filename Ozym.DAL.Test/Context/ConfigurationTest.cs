using System;
using System.Collections.Generic;
using System.Linq;
using Ozym.EntityModel.Context.Configurations;
using Ozym.EntityModel.Context;
using Ozym.EntityModel;

namespace Ozym.Test.Context
{
    [TestCategory("Unit")]
    [TestClass]
    public class ConfigurationTest
    {
        private readonly Guid SourceGuid = Guid.Parse("{B5F55FE3-F415-4A9B-9A58-0304CCFC11F7}");

        [TestMethod]
        public void ConfigurationCollection_WithNoDuplicateKeys_IsValid_ReturnsTrue()
        {
            var configuration = new ConfigurationCollection();

            configuration.AddConfiguration(
                new EntityConfiguration<Account>(SourceGuid, new Account() { AccountId = 1 }));

            configuration.AddConfiguration(
                new EntityConfiguration<Account>(SourceGuid, new Account() { AccountId = 2 }));

            Assert.IsTrue(configuration.IsValid(out _));
        }

        [TestMethod]
        public void ConfigurationColleciton_WithDuplicateKeys_IsValid_ReturnsFalse()
        {
            var configuration = new ConfigurationCollection();

            configuration.AddConfiguration(
                new EntityConfiguration<Account>(SourceGuid, new Account() { AccountId = 1 }));

            configuration.AddConfiguration(
                new EntityConfiguration<Account>(SourceGuid, new Account() { AccountId = 1 }));

            bool isValid = configuration.IsValid(out IEnumerable<string> _);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ConfigurationColleciton_WithDuplicateKeys_WithDifferentSources_IsValid_ReturnsFalse()
        {
            var configuration = new ConfigurationCollection();

            configuration.AddConfiguration(
                new EntityConfiguration<Account>(SourceGuid, new Account() { AccountId = 1 }));

            configuration.AddConfiguration(
                new EntityConfiguration<Account>(Guid.NewGuid(), new Account() { AccountId = 1 }));

            bool isValid = configuration.IsValid(out IEnumerable<string> _);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Configuration_Collection_WithDuplicatKeysForDifferentEntities_IsValid_ReturnsTrue()
        {
            var configuration = new ConfigurationCollection();

            configuration.AddConfiguration(
                new EntityConfiguration<Account>(SourceGuid, new Account() { AccountId = 1 }));

            configuration.AddConfiguration(
                new EntityConfiguration<Country>(SourceGuid, new Country() { CountryId = 2 }));

            Assert.IsTrue(configuration.IsValid(out _));
        }

        [TestMethod]
        public void EntityConfiguration_UniqueIntegerPrimaryKeys_ReturnsExpectedReservedKeys()
        {
            var configuration = new EntityConfiguration<Account>(
                sourceGuid: SourceGuid,
                new Account[]
                {
                    new() { AccountId = 1 },
                    new() { AccountId = 2 }
                });

            Assert.AreEqual(
                configuration.ReservedKeys.Distinct().Count(),
                configuration.ReservedKeys.Count);
            Assert.AreEqual(2, configuration.ReservedKeys.Count);
            Assert.IsTrue(configuration.ReservedKeys.Any(x => x.GetHashCode() == 1));
            Assert.IsTrue(configuration.ReservedKeys.Any(x => x.GetHashCode() == 2));
        }

        [TestMethod]
        public void EntityConfiguration_NonUniqueIntegerPrimaryKeys_ReturnsExpectedReservedKeys()
        {
            var configuration = new EntityConfiguration<Account>(
                sourceGuid: SourceGuid,
                new Account[]
                {
                    new() { AccountId = 1 },
                    new() { AccountId = 1 }
                });

            Assert.AreEqual(1, configuration.ReservedKeys.Count);
        }

        [TestMethod]
        public void GetHashCode_ForCompositeKey_UsingObjectArray_SameReference()
        {
            var keyValue = new
            {
                Key1 = 1,
                Key2 = 2,
                Key3 = DateTime.UtcNow.Date
            };

            var testArray1 = new object[]
            {
                keyValue.Key1,
                keyValue.Key2,
                keyValue.Key3
            };

            var testArray2 = new object[]
            {
                keyValue.Key1,
                keyValue.Key2,
                keyValue.Key3
            };

            var databaseKey1 = new DatabaseKey(testArray1);
            var databaseKey2 = new DatabaseKey(testArray2);

            Assert.AreEqual(databaseKey1, databaseKey2);
        }

        // TODO: Need more tests covering other scenarios for theses types.
    }
}
