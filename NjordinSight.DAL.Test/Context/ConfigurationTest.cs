using System;
using System.Collections.Generic;
using System.Linq;
using NjordinSight.EntityModel.Context.Configurations;
using NjordinSight.EntityModel.Context;
using NjordinSight.EntityModel;

namespace NjordinSight.Test.Context
{
    [TestClass]
    public class ConfigurationTest
    {
        private readonly Guid Guid = Guid.Parse("{B5F55FE3-F415-4A9B-9A58-0304CCFC11F7}");
        [TestMethod]
        public void ConfigurationBase_UniqueIntegerPrimaryKeys_ReturnsExpectedReservedKeys()
        {
            var configuration = new EntityConfiguration<Account>(
                sourceGuid: Guid,
                new Account[]
                {
                    new Account() { AccountId = 1 },
                    new Account() { AccountId = 2 }
                });

            Assert.AreEqual(
                configuration.ReservedKeys.Distinct().Count(),
                configuration.ReservedKeys.Count);
            Assert.AreEqual(2, configuration.ReservedKeys.Count);
            Assert.IsTrue(configuration.ReservedKeys.Any(x => x.GetHashCode() == 1));
            Assert.IsTrue(configuration.ReservedKeys.Any(x => x.GetHashCode() == 2));
        }

        [TestMethod]
        public void ConfigurationBase_NonUniqueIntegerPrimaryKeys_ReturnsExpectedReservedKeys()
        {
            var configuration = new EntityConfiguration<Account>(
                sourceGuid: Guid,
                new Account[]
                {
                    new Account() { AccountId = 1 },
                    new Account() { AccountId = 1 }
                });

            Assert.AreNotEqual(
                configuration.ReservedKeys.Distinct().Count(),
                configuration.ReservedKeys.Count);
            Assert.AreNotEqual(2, configuration.ReservedKeys.Count);
            Assert.IsTrue(configuration.ReservedKeys.Any(x => x.GetHashCode() == 1));
            Assert.IsFalse(configuration.ReservedKeys.Any(x => x.GetHashCode() == 2));
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
