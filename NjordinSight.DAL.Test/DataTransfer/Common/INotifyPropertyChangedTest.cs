using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.Test.DataTransfer.Common
{
    /// <summary>
    /// Contains unit tests verifying behavior of <see cref="INotifyPropertyChanged"/> 
    /// implementation.
    /// </summary>
    [TestClass]
    [TestCategory("Unit")]
    public partial class INotifyPropertyChangedTest
    {
        #region PropertyChanged not invoked
        // Covers branches where setter value equality check returns FALSE.

        [TestMethod]
        public void AccountBaseAttributeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountBaseAttributeDto>();

        [TestMethod]
        public void AccountBaseDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountBaseDto>();

        [TestMethod]
        public void AccountCompositeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountCompositeDto>();

        [TestMethod]
        public void AccountCompositeMemberDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountCompositeMemberDto>();

        [TestMethod]
        public void AccountCustodianDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountCustodianDto>();

        [TestMethod]
        public void AccountDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountDto>();

        [TestMethod]
        public void AccountSimpleDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountSimpleDto>();

        [TestMethod] 
        public void AccountWalletDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<AccountWalletDto>();

        [TestMethod] 
        public void BankTransactionCodeAttributeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<BankTransactionCodeAttributeDto>();

        [TestMethod] 
        public void BankTransactionCodeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<BankTransactionCodeDto>();

        [TestMethod] 
        public void BankTransactionDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<BankTransactionDto>();

        [TestMethod] 
        public void BrokerTransactionCodeAttributeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<BrokerTransactionCodeAttributeDto>();

        [TestMethod] 
        public void BrokerTransactionCodeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<BrokerTransactionCodeDto>();

        [TestMethod] 
        public void BrokerTransactionDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<BrokerTransactionDto>();

        [TestMethod] 
        public void CountryAttributeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<CountryAttributeDto>();

        [TestMethod] 
        public void CountryDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<CountryDto>();

        [TestMethod] 
        public void InvestmentModelDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<InvestmentModelDto>();

        [TestMethod] 
        public void InvestmentModelTargetDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<InvestmentModelTargetDto>();

        [TestMethod] 
        public void InvestmentPerformanceAttributeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<InvestmentPerformanceAttributeDto>();

        [TestMethod] 
        public void InvestmentPerformanceDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<InvestmentPerformanceDto>();

        [TestMethod] 
        public void MarketHolidayDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<MarketHolidayDto>();

        [TestMethod] 
        public void MarketHolidayObservanceDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<MarketHolidayObservanceDto>();

        [TestMethod] 
        public void MarketIndexDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<MarketIndexDto>();

        [TestMethod] 
        public void MarketIndexPriceDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<MarketIndexPriceDto>();

        [TestMethod] 
        public void ModelAttributeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<ModelAttributeDto>();

        [TestMethod] 
        public void ModelAttributeMemberDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<ModelAttributeMemberDto>();

        [TestMethod] 
        public void ModelAttributeScopeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<ModelAttributeScopeDto>();

        [TestMethod] 
        public void ReportConfigurationDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<ReportConfigurationDto>();

        [TestMethod] 
        public void ReportStyleSheetDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<ReportStyleSheetDto>();

        [TestMethod] 
        public void SecurityAttributeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecurityAttributeDto>();

        [TestMethod]
        public void SecurityDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecurityDto>(
                exclusions: new string[] { nameof(SecurityDto.CurrentSymbol) });

        [TestMethod] 
        public void SecurityExchangeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecurityExchangeDto>();

        [TestMethod] 
        public void SecurityPriceDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecurityPriceDto>();

        [TestMethod] 
        public void SecuritySymbolDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecuritySymbolDto>();

        [TestMethod] 
        public void SecuritySymbolMapDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecuritySymbolMapDto>();

        [TestMethod] 
        public void SecuritySymbolTypeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecuritySymbolTypeDto>();

        [TestMethod] 
        public void SecurityTypeDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecurityTypeDto>();

        [TestMethod] 
        public void SecurityTypeGroupDto_PropertyChanged_Event_Raised() =>
            When_Property_Set_PropertyChanged_Event_Raised<SecurityTypeGroupDto>();
        #endregion

        #region PropertyChanged not invoked
        // Covers branches where setter value equality check returns TRUE.

        [TestMethod]
        public void AccountBaseAttributeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountBaseAttributeDto>();

        [TestMethod]
        public void AccountBaseDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountBaseDto>();

        [TestMethod]
        public void AccountCompositeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountCompositeDto>();

        [TestMethod]
        public void AccountCompositeMemberDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountCompositeMemberDto>();

        [TestMethod]
        public void AccountCustodianDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountCustodianDto>();

        [TestMethod]
        public void AccountDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountDto>();

        [TestMethod]
        public void AccountSimpleDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountSimpleDto>();

        [TestMethod]
        public void AccountWalletDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<AccountWalletDto>();

        [TestMethod]
        public void BankTransactionCodeAttributeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<BankTransactionCodeAttributeDto>();

        [TestMethod]
        public void BankTransactionCodeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<BankTransactionCodeDto>();

        [TestMethod]
        public void BankTransactionDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<BankTransactionDto>();

        [TestMethod]
        public void BrokerTransactionCodeAttributeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<BrokerTransactionCodeAttributeDto>();

        [TestMethod]
        public void BrokerTransactionCodeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<BrokerTransactionCodeDto>();

        [TestMethod]
        public void BrokerTransactionDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<BrokerTransactionDto>();

        [TestMethod]
        public void CountryAttributeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<CountryAttributeDto>();

        [TestMethod]
        public void CountryDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<CountryDto>();

        [TestMethod]
        public void InvestmentModelDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<InvestmentModelDto>();

        [TestMethod]
        public void InvestmentModelTargetDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<InvestmentModelTargetDto>();

        [TestMethod]
        public void InvestmentPerformanceAttributeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<InvestmentPerformanceAttributeDto>();

        [TestMethod]
        public void InvestmentPerformanceDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<InvestmentPerformanceDto>();

        [TestMethod]
        public void MarketHolidayDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<MarketHolidayDto>();

        [TestMethod]
        public void MarketHolidayObservanceDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<MarketHolidayObservanceDto>();

        [TestMethod]
        public void MarketIndexDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<MarketIndexDto>();

        [TestMethod]
        public void MarketIndexPriceDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<MarketIndexPriceDto>();

        [TestMethod]
        public void ModelAttributeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<ModelAttributeDto>();

        [TestMethod]
        public void ModelAttributeMemberDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<ModelAttributeMemberDto>();

        [TestMethod]
        public void ModelAttributeScopeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<ModelAttributeScopeDto>();

        [TestMethod]
        public void ReportConfigurationDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<ReportConfigurationDto>();

        [TestMethod]
        public void ReportStyleSheetDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<ReportStyleSheetDto>();

        [TestMethod]
        public void SecurityAttributeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecurityAttributeDto>();

        [TestMethod]
        public void SecurityDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecurityDto>();

        [TestMethod]
        public void SecurityExchangeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecurityExchangeDto>(
                exclusions: new string[] { nameof(SecurityDto.CurrentSymbol) });

        [TestMethod]
        public void SecurityPriceDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecurityPriceDto>();

        [TestMethod]
        public void SecuritySymbolDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecuritySymbolDto>();

        [TestMethod]
        public void SecuritySymbolMapDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecuritySymbolMapDto>();

        [TestMethod]
        public void SecuritySymbolTypeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecuritySymbolTypeDto>();

        [TestMethod]
        public void SecurityTypeDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecurityTypeDto>();

        [TestMethod]
        public void SecurityTypeGroupDto_PropertyChanged_Event_Not_Raised() =>
            When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<SecurityTypeGroupDto>();
        #endregion
    }

    #region Helper methods
    public partial class INotifyPropertyChangedTest
    {
        /// <summary>
        /// Generic method implementing the unit test for setting the value of a change-tracking 
        /// property where the test value is not equal to the original value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exclusions">Collection of property names to exclude from testing.</param>
        private static void When_Property_Set_PropertyChanged_Event_Raised<T>(
            IEnumerable<string> exclusions = null)
            where T : INotifyPropertyChanged
        {
            // Arrange
            var typeValueMap = new Dictionary<Type, object>()
            {
                { typeof(bool) , true },
                { typeof(bool?) , true },
                { typeof(short) , (short)1 },
                { typeof(short?) , (short?)1 },
                { typeof(int) , 1 },
                { typeof(int?) , 1 },
                { typeof(double) , 1D },
                { typeof(double?) , 1D },
                { typeof(DateTime) , DateTime.UtcNow.Date },
                { typeof(DateTime?) , (DateTime?)DateTime.UtcNow.Date },
                { typeof(decimal) , 1M },
                { typeof(decimal?) , (decimal?)1M },
                { typeof(string), "Test string" }
            };
            var properties = GetTestableProperites<T>(
                                typeValueMap, exclusions ?? Array.Empty<string>());

            bool expected = true;

            // Act
            bool observed = properties.All(x =>
            {
                try
                {
                    AssertPropertyChangedEventInvoked<T>(x);
                    return true;
                }
                catch (AssertFailedException)
                {
                    return false;
                }
            });

            // Assert
            Assert.AreEqual(expected, observed);
        }

        /// <summary>
        /// Generic method implementing the unit test for setting the value of a change-tracking 
        /// property where the test value is equal to the original value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exclusions">Collection of property names to exclude from testing.</param>
        private static void When_Property_Set_No_Value_Change_PropertyChanged_Event_Not_Raised<T>(
            IEnumerable<string> exclusions = null)
            where T : INotifyPropertyChanged
        {
            // Arrange
            var typeValueMap = new Dictionary<Type, object>()
            {
                { typeof(bool) , default(bool) },
                { typeof(bool?) , default(bool?) },
                { typeof(short) , default(short) },
                { typeof(short?) , default(short?) },
                { typeof(int) , default(int) },
                { typeof(int?) , default(int?) },
                { typeof(double) , default(double) },
                { typeof(double?) , default(double?) },
                { typeof(DateTime) , default(DateTime) },
                { typeof(DateTime?) , default(DateTime?) },
                { typeof(decimal) , default(decimal) },
                { typeof(decimal?) , default(decimal?) },
                { typeof(string), default(string) }
            };
            var properties = GetTestableProperites<T>(
                                typeValueMap, exclusions ?? Array.Empty<string>());

            bool expected = true;

            // Act
            bool observed = properties.All(x =>
            {
                try
                {
                    AssertPropertyChangedEventNotInvoked<T>(x);
                    return true;
                }
                catch (AssertFailedException)
                {
                    return false;
                }
            });

            // Assert
            Assert.AreEqual(expected, observed);
        }

        /// <summary>
        /// Initializes a default instance of <typeparamref name="T"/> and asserts setting the 
        /// property value raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <typeparam name="T">The type implementing <see cref="INotifyPropertyChanged"/>.</typeparam>
        /// <param name="testedProperty">The <see cref="TestedProperty"/> describing the test inputs.</param>
        private static void AssertPropertyChangedEventInvoked<T>(TestedProperty testedProperty)
            where T : INotifyPropertyChanged
        {
            Console.WriteLine(
                $"Test:\t{nameof(AssertPropertyChangedEventInvoked)}\n" +
                $"Property:\t" +
                $"{testedProperty.Property.DeclaringType.Name}.{testedProperty.Property.Name}");

            // Arrange
            T instance = (T)Activator.CreateInstance(typeof(T));

            string observedPropertyNameChanged = null;
            object expectedValue = testedProperty.TestValue;

            instance.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
            {
                observedPropertyNameChanged = args.PropertyName;
            };

            // Act
            var beforeSetValue = testedProperty.Property.GetValue(instance);
            testedProperty.Property.SetValue(instance, expectedValue);
            var afterSetValue = testedProperty.Property.GetValue(instance);

            bool valueChanged = (beforeSetValue is null ^ afterSetValue is null) || 
                !beforeSetValue.Equals(afterSetValue);
            bool eventRaised = testedProperty.Property.Name.Equals(observedPropertyNameChanged);

            // Assert
            Console.WriteLine($"Result:\t{(valueChanged && eventRaised ? "PASS" : "FAIL")}\n" +
                $"\tExpected<{testedProperty.Property.Name}>, Observed<{observedPropertyNameChanged}>\n" +
                $"\tExpected<{expectedValue}>, Observed<{afterSetValue}>\n");

            // Value is changed.
            Assert.AreEqual(testedProperty.TestValue, afterSetValue);

            // PropertyChanged event for expected property was raised.
            Assert.AreEqual(testedProperty.Property.Name, observedPropertyNameChanged);
        }

        /// <summary>
        /// Initializes a default instance of <typeparamref name="T"/> and asserts setting the 
        /// property value to the current value does not raise the 
        /// <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <typeparam name="T">The type implementing <see cref="INotifyPropertyChanged"/>.</typeparam>
        /// <param name="testedProperty">The <see cref="TestedProperty"/> describing the test inputs.</param>
        private static void AssertPropertyChangedEventNotInvoked<T>(TestedProperty testedProperty)
            where T : INotifyPropertyChanged
        {
            Console.WriteLine(
                $"Test:\t{nameof(AssertPropertyChangedEventNotInvoked)}\n" +
                $"Property:\t" +
                $"{testedProperty.Property.DeclaringType.Name}.{testedProperty.Property.Name}");

            // Arrange
            T instance = (T)Activator.CreateInstance(typeof(T));

            string observedPropertyNameChanged = null;
            bool eventRaised = false;

            object expectedValue = testedProperty.TestValue;

            instance.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
            {
                observedPropertyNameChanged = args.PropertyName;
                eventRaised = true;
            };

            // Act
            var beforeSetValue = testedProperty.Property.GetValue(instance);
            testedProperty.Property.SetValue(instance, expectedValue);
            var afterSetValue = testedProperty.Property.GetValue(instance);

            bool valueChanged = (beforeSetValue is null ^ afterSetValue is null) ||
                 !(beforeSetValue?.Equals(afterSetValue) ?? true);
            bool propertyNameIsNull = string.IsNullOrEmpty(observedPropertyNameChanged);

            // Assert
            Console.WriteLine($"Result:\t{(!valueChanged && !eventRaised ? "PASS" : "FAIL")}\n" +
                $"\tExpected<>, Observed<{observedPropertyNameChanged}>\n" +
                $"\tExpected<{beforeSetValue}>, Observed<{afterSetValue}>\n");

            // The event was not raised.
            Assert.IsFalse(eventRaised);
            
            // The observed property change is still undefined.
            Assert.IsTrue(propertyNameIsNull);

            // Value is unchanged.
            Assert.IsFalse(valueChanged);
        }

        /// <summary>
        /// Creates a list of <see cref="TestedProperty"/> records based on the given type-value 
        /// map to use for the test(s).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeValueMap"><see cref="IDictionary{TKey, TValue}"/> mapping types to 
        /// their corresponding test values.</param>
        /// <param name="propertyExclusions">Collection of property names to exclude from testing.</param>
        /// <returns></returns>
        private static List<TestedProperty> GetTestableProperites<T>(
            IDictionary<Type, object> typeValueMap, IEnumerable<string> propertyExclusions)
        {
            if (propertyExclusions is null)
                throw new ArgumentNullException(paramName: nameof(propertyExclusions));

            var type = typeof(T);
            var properties = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => typeValueMap.ContainsKey(x.PropertyType) && 
                    !propertyExclusions.Contains(x.Name))
                .Select(x => new TestedProperty
                {
                    Property = x,
                    Getter = x.GetGetMethod(),
                    Setter = x.GetSetMethod(),
                    TestValue = typeValueMap[x.PropertyType]
                })
                .Where(x => x.Getter is not null && x.Setter is not null)
                .ToList();

            return properties;
        }

        /// <summary>
        /// Represents an instance property that has a public getter and setter.
        /// </summary>
        private record TestedProperty
        {
            /// <summary>
            /// Gets or sets the <see cref="PropertyInfo"/> for the property tested.
            /// </summary>
            public PropertyInfo Property { get; init; }

            /// <summary>
            /// Gets or sets the <see cref="MethodInfo"/> describing the public getter of this property.
            /// </summary>
            public MethodInfo Getter { get; init; }

            /// <summary>
            /// Gets or sets the <see cref="MethodInfo"/> describing the public setter of this property.
            /// </summary>
            public MethodInfo Setter { get; init; }

            /// <summary>
            /// Gets or sets the value to use when testing the setter.
            /// </summary>
            public object TestValue { get; init; }
        }
    }
    #endregion
}
