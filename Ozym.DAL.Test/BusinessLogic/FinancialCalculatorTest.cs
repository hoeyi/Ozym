using System;
using System.Collections.Generic;
using System.Linq;
using Ozym.BusinessLogic.Functions;
using System.Diagnostics;

namespace Ozym.Test.BusinessLogic
{
    [TestClass]
    [TestCategory("Unit")]
    public class FinancialCalculatorTest
    {
        private const double ResultPrecision = 0.0001;

        [TestMethod]
        public void AnnualizedTimeWeightedReturn_MaxCumulativeReturn_MaxYears_ReturnsZero()
        {
            var calculator = new FinancialCalculator();

            var observed = calculator.AnnualizedTimeWeightedReturn(
                cumulativeReturn: float.MaxValue, years: float.MaxValue);

            Assert.AreEqual(0.0, observed, ResultPrecision);
        }

        [TestMethod]
        public void AnnualizedTimeWeightedReturn_MinCumulativeReturn_MaxYears()
        {
            var calculator = new FinancialCalculator();

            var observed = calculator.AnnualizedTimeWeightedReturn(
                cumulativeReturn: float.MinValue, years: float.MaxValue);

            Assert.AreEqual(double.NaN, observed);
        }

        [TestMethod]
        public void AnnualizedTimeWeightedReturn_Years_IsLessThanZero_Returns_NaN()
        {
            var calculator = new FinancialCalculator();

            var observed = calculator.AnnualizedTimeWeightedReturn(0.1F, -0.1F);

            Assert.AreEqual(double.NaN, observed);
        }

        [TestMethod]
        public void AnnualizedTimeWeightedReturn_Years_IsZero_Returns_NaN()
        {
            var calculator = new FinancialCalculator();

            var observed = calculator.AnnualizedTimeWeightedReturn(0.1F, 0.0F);

            Assert.AreEqual(double.NaN, observed);
        }

        [TestMethod]
        public void AnnualizedTimeWeightedReturn_PreCalculatedResultSet_AllAccurateToOneBasisPoint()
        {
            var calculator = new FinancialCalculator();

            var mappedInputOutput = new AnnualizedReturnTestResult[]
            {
                new() { CumulativeRate = 0.5826F, Years = 19.9F, ExpectedValue =  0.0233 },
                new() { CumulativeRate = 0.0889F, Years = 21.5F, ExpectedValue =  0.004 },
                new() { CumulativeRate = 0.3024F, Years = 24.4F, ExpectedValue =  0.0109 },
                new() { CumulativeRate = -0.0883F, Years = 14.4F, ExpectedValue =  -0.0064 },
                new() { CumulativeRate = 0.3486F, Years = 3.3F, ExpectedValue =  0.0949 },
                new() { CumulativeRate = -0.0614F, Years = 24.3F, ExpectedValue =  -0.0026 },
                new() { CumulativeRate = -0.0651F, Years = 10.2F, ExpectedValue =  -0.0066 },
                new() { CumulativeRate = 0.1283F, Years = 8.1F, ExpectedValue =  0.015 },
                new() { CumulativeRate = 0.4779F, Years = 16.6F, ExpectedValue =  0.0238 },
                new() { CumulativeRate = 0.2469F, Years = 1, ExpectedValue =  0.2469 },
                new() { CumulativeRate = 0.183F, Years = 21.2F, ExpectedValue =  0.008 },
                new() { CumulativeRate = 0.1956F, Years = 23.1F, ExpectedValue =  0.0078 },
                new() { CumulativeRate = 0.2374F, Years = 7.2F, ExpectedValue =  0.03 },
                new() { CumulativeRate = 0.2723F, Years = 24.5F, ExpectedValue =  0.0099 },
                new() { CumulativeRate = 0.4269F, Years = 1, ExpectedValue =  0.4269 },
                new() { CumulativeRate = -0.04F, Years = 4.3F, ExpectedValue =  -0.0095 },
                new() { CumulativeRate = 0.262F, Years = 11.1F, ExpectedValue =  0.0212 },
                new() { CumulativeRate = 0.1668F, Years = 14.4F, ExpectedValue =  0.0108 },
                new() { CumulativeRate = 0.4435F, Years = 17.2F, ExpectedValue =  0.0216 },
                new() { CumulativeRate = 0.1761F, Years = 3, ExpectedValue =  0.0556 },
                new() { CumulativeRate = -0.2296F, Years = 11.2F, ExpectedValue =  -0.023 },
                new() { CumulativeRate = -0.0289F, Years = 23.2F, ExpectedValue =  -0.0013 },
                new() { CumulativeRate = 0.233F, Years = 7.5F, ExpectedValue =  0.0283 },
                new() { CumulativeRate = 0.0715F, Years = 5.3F, ExpectedValue =  0.0131 },
                new() { CumulativeRate = -0.0182F, Years = 12.3F, ExpectedValue =  -0.0015 },
                new() { CumulativeRate = 0.0784F, Years = 23.8F, ExpectedValue =  0.0032 },
                new() { CumulativeRate = 0.3084F, Years = 13.7F, ExpectedValue =  0.0198 },
                new() { CumulativeRate = 0.1322F, Years = 10.8F, ExpectedValue =  0.0116 },
                new() { CumulativeRate = -0.0477F, Years = 10.5F, ExpectedValue =  -0.0046 }
            };

            var observations = from io in mappedInputOutput
                          select new
                          {
                              Map = io,
                              ObservedResult = calculator.AnnualizedTimeWeightedReturn(
                                  io.CumulativeRate, io.Years)
                          };

            var fails = new List<AssertFailedException>();

            foreach(var obs in observations)
            {
                try
                {
                    Assert.AreEqual(
                        obs.Map.ExpectedValue, obs.ObservedResult, ResultPrecision);
                }
                catch(AssertFailedException e)
                {
                    Debug.WriteLine(e);
                    fails.Add(e);
                }
            }

            Assert.IsFalse(fails.Any());
        }

        [TestMethod]
        public void CumulativeTimeWeightedReturn_NullInput_ThrowsArgumentNullExcpetion()
        {
            var calculator = new FinancialCalculator();

            Assert.ThrowsException<ArgumentNullException>(() =>
                calculator.CumulativeTimeWeightedReturn(null));
        }

        [TestMethod]
        public void CumulativeTimeWeightedReturn_EmptyArrayInput_ThrowsInvalidOperationException()
        {
            var calculator = new FinancialCalculator();

            Assert.ThrowsException<InvalidOperationException>(() =>
                calculator.CumulativeTimeWeightedReturn(Array.Empty<InternalRateReturnResult>()));
        }

        [TestMethod]
        public void CumulativeTimeWeightedReturn_MappedExample_ReturnsExpectedValue()
        {
            var calculator = new FinancialCalculator();

            var expected = 0.21;
            var observed = calculator.CumulativeTimeWeightedReturn(
                new InternalRateReturnResult() { Irr = 0.1F },
                new InternalRateReturnResult() { Irr = 0.1F });

            Assert.AreEqual(expected, observed, ResultPrecision);
        }

        [TestMethod]
        public void FutureValue_SinglePeriod_AnnualPeriodType_ReturnsExpectedValue()
        {
            var calculator = new FinancialCalculator();

            var testDate = new DateTime(2022, 12, 31);

            var resultList = calculator.FutureValue(testDate, 1, 100, 0.05F, 0, PeriodType.Annual);

            var firstObserved = resultList.FirstOrDefault();
            var lastObserved = resultList.LastOrDefault();

            // Expects exactly two results.
            Assert.IsTrue(resultList.Count() == 2);

            Assert.IsTrue(
                firstObserved.Period == 0 &&
                firstObserved.PeriodDate == testDate &&
                firstObserved.Principal == 100 &&
                firstObserved.Interest == 0);

            Assert.IsTrue(
                lastObserved.Period == 1 &&
                lastObserved.PeriodDate == testDate.AddYears(1) &&
                lastObserved.Principal == 100 &&
                lastObserved.Interest == 5);
        }

        [TestMethod]
        public void FutureValue_ZeroPeriods_ReturnsOnlyInitialResultRecord()
        {
            var calculator = new FinancialCalculator();

            var testDate = DateTime.UtcNow.Date;
            var expected = new FutureValueResult()
            {
                Period = 0,
                PeriodDate = testDate,
                Principal = 100,
                Interest = 0
            };

            var resultset = calculator.FutureValue(testDate, 0, 100, 0.05F, 0, PeriodType.Annual);

            // Expects exactly one result.
            Assert.IsTrue(resultset.Count() == 1);

            var observed = resultset.FirstOrDefault();

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void FutureValue_PeriodType_Day_SampleParameters_ReturnsExpectedCollection()
        {
            var calculator = new FinancialCalculator();

            var testDate = new DateTime(2022, 12, 31);

            var expected = new List<FutureValueResult>()
            {
                new() { Period = 0, PeriodDate = testDate, Principal = 1000, Interest = 0F },
                new() { Period = 1, PeriodDate = new DateTime(2023, 1, 1), Principal = 1100, Interest = 0.3F },
                new() { Period = 2, PeriodDate = new DateTime(2023, 1, 2), Principal = 1200, Interest = 0.63F },
                new() { Period = 3, PeriodDate = new DateTime(2023, 1, 3), Principal = 1300, Interest = 0.99F },
                new() { Period = 4, PeriodDate = new DateTime(2023, 1, 4), Principal = 1400, Interest = 1.38F },
                new() { Period = 5, PeriodDate = new DateTime(2023, 1, 5), Principal = 1500, Interest = 1.8F },
                new() { Period = 6, PeriodDate = new DateTime(2023, 1, 6), Principal = 1600, Interest = 2.25F },
                new() { Period = 7, PeriodDate = new DateTime(2023, 1, 7), Principal = 1700, Interest = 2.73F },
                new() { Period = 8, PeriodDate = new DateTime(2023, 1, 8), Principal = 1800, Interest = 3.24F },
                new() { Period = 9, PeriodDate = new DateTime(2023, 1, 9), Principal = 1900, Interest = 3.78F },
                new() { Period = 10, PeriodDate = new DateTime(2023, 1, 10), Principal = 2000, Interest = 4.36F }
            };

            var observed = calculator
                .FutureValue(testDate, 10, 1000, 0.0003F, 100, PeriodType.Day)
                .ToList();

            CollectionAssert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void FutureValue_PeriodType_Week_SampleParameters_ReturnsExpectedCollection()
        {
            var calculator = new FinancialCalculator();

            var testDate = new DateTime(2022, 12, 31);
            var expected = new List<FutureValueResult>()
            {
                new() { Period = 0, PeriodDate = testDate, Principal = 1000, Interest = 0F },
                new() { Period = 1, PeriodDate = new DateTime(2023, 1, 7), Principal = 1100, Interest = 1.9F },
                new() { Period = 2, PeriodDate = new DateTime(2023, 1, 14), Principal = 1200, Interest = 3.99F },
                new() { Period = 3, PeriodDate = new DateTime(2023, 1, 21), Principal = 1300, Interest = 6.28F },
                new() { Period = 4, PeriodDate = new DateTime(2023, 1, 28), Principal = 1400, Interest = 8.76F },
                new() { Period = 5, PeriodDate = new DateTime(2023, 2, 4), Principal = 1500, Interest = 11.44F },
                new() { Period = 6, PeriodDate = new DateTime(2023, 2, 11), Principal = 1600, Interest = 14.31F },
                new() { Period = 7, PeriodDate = new DateTime(2023, 2, 18), Principal = 1700, Interest = 17.38F },
                new() { Period = 8, PeriodDate = new DateTime(2023, 2, 25), Principal = 1800, Interest = 20.64F },
                new() { Period = 9, PeriodDate = new DateTime(2023, 3, 4), Principal = 1900, Interest = 24.1F },
                new() { Period = 10, PeriodDate = new DateTime(2023, 3, 11), Principal = 2000, Interest = 27.76F }
            };

            var observed = calculator
                .FutureValue(testDate, 10, 1000, 0.0019F, 100, PeriodType.Week)
                .ToList();

            CollectionAssert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void FutureValue_PeriodType_Month_SampleParameters_ReturnsExpectedCollection()
        {
            var calculator = new FinancialCalculator();

            var testDate = new DateTime(2022, 12, 31);
            var expected = new List<FutureValueResult>()
            {
                new() { Period = 0, PeriodDate = testDate, Principal = 1000, Interest = 0F },
                new() { Period = 1, PeriodDate = new DateTime(2023, 1, 31), Principal = 1100, Interest = 8.3F },
                new() { Period = 2, PeriodDate = new DateTime(2023, 2, 28), Principal = 1200, Interest = 17.5F },
                new() { Period = 3, PeriodDate = new DateTime(2023, 3, 31), Principal = 1300, Interest = 27.6F },
                new() { Period = 4, PeriodDate = new DateTime(2023, 4, 30), Principal = 1400, Interest = 38.62F },
                new() { Period = 5, PeriodDate = new DateTime(2023, 5, 31), Principal = 1500, Interest = 50.56F },
                new() { Period = 6, PeriodDate = new DateTime(2023, 6, 30), Principal = 1600, Interest = 63.43F },
                new() { Period = 7, PeriodDate = new DateTime(2023, 7, 31), Principal = 1700, Interest = 77.24F },
                new() { Period = 8, PeriodDate = new DateTime(2023, 8, 31), Principal = 1800, Interest = 91.99F },
                new() { Period = 9, PeriodDate = new DateTime(2023, 9, 30), Principal = 1900, Interest = 107.69F },
                new() { Period = 10, PeriodDate = new DateTime(2023, 10, 31), Principal = 2000, Interest = 124.36F }
            };

            var observed = calculator
                .FutureValue(testDate, 10, 1000, 0.0083F, 100, PeriodType.Month)
                .ToList();

            CollectionAssert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void FutureValue_PeriodType_Quarter_SampleParameters_ReturnsExpectedCollection()
        {
            var calculator = new FinancialCalculator();

            var testDate = new DateTime(2022, 12, 31);
            var expected = new List<FutureValueResult>()
            {
                new() { Period = 0, PeriodDate = testDate, Principal = 1000, Interest = 0F },
                new() { Period = 1, PeriodDate = new DateTime(2023, 3, 31), Principal = 1100, Interest = 25F },
                new() { Period = 2, PeriodDate = new DateTime(2023, 6, 30), Principal = 1200, Interest = 53.12F },
                new() { Period = 3, PeriodDate = new DateTime(2023, 9, 30), Principal = 1300, Interest = 84.45F },
                new() { Period = 4, PeriodDate = new DateTime(2023, 12, 31), Principal = 1400, Interest = 119.06F },
                new() { Period = 5, PeriodDate = new DateTime(2024, 3, 31), Principal = 1500, Interest = 157.04F },
                new() { Period = 6, PeriodDate = new DateTime(2024, 6, 30), Principal = 1600, Interest = 198.47F },
                new() { Period = 7, PeriodDate = new DateTime(2024, 9, 30), Principal = 1700, Interest = 243.43F },
                new() { Period = 8, PeriodDate = new DateTime(2024, 12, 31), Principal = 1800, Interest = 292.01F },
                new() { Period = 9, PeriodDate = new DateTime(2025, 3, 31), Principal = 1900, Interest = 344.31F },
                new() { Period = 10, PeriodDate = new DateTime(2025, 6, 30), Principal = 2000, Interest = 400.42F }
            };

            var observed = calculator
                .FutureValue(testDate, 10, 1000, 0.025F, 100, PeriodType.Quarter)
                .ToList();

            CollectionAssert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void FutureValue_PeriodType_Annual_SampleParameters_ReturnsExpectedCollection()
        {
            var calculator = new FinancialCalculator();

            var testDate = new DateTime(2022, 12, 31);
            var expected = new List<FutureValueResult>()
            {
                new() { Period = 0, PeriodDate = new DateTime(2022, 12, 31), Principal = 1000, Interest = 0F },
                new() { Period = 1, PeriodDate = new DateTime(2023, 12, 31), Principal = 1100, Interest = 100F },
                new() { Period = 2, PeriodDate = new DateTime(2024, 12, 31), Principal = 1200, Interest = 220F },
                new() { Period = 3, PeriodDate = new DateTime(2025, 12, 31), Principal = 1300, Interest = 362F },
                new() { Period = 4, PeriodDate = new DateTime(2026, 12, 31), Principal = 1400, Interest = 528.2F },
                new() { Period = 5, PeriodDate = new DateTime(2027, 12, 31), Principal = 1500, Interest = 721.02F },
                new() { Period = 6, PeriodDate = new DateTime(2028, 12, 31), Principal = 1600, Interest = 943.12F },
                new() { Period = 7, PeriodDate = new DateTime(2029, 12, 31), Principal = 1700, Interest = 1197.43F },
                new() { Period = 8, PeriodDate = new DateTime(2030, 12, 31), Principal = 1800, Interest = 1487.18F },
                new() { Period = 9, PeriodDate = new DateTime(2031, 12, 31), Principal = 1900, Interest = 1815.9F },
                new() { Period = 10, PeriodDate = new DateTime(2032, 12, 31), Principal = 2000, Interest = 2187.48F }
            };

            var observed = calculator
                .FutureValue(testDate, 10, 1000, 0.1F, 100, PeriodType.Annual)
                .ToList();

            CollectionAssert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void FutureValue_PeriodsMinValue_Throws_ArgumentOutOfRangeException()
        {
            var calculator = new FinancialCalculator();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValue(
                    startDate: DateTime.MinValue,
                    periods: int.MinValue,
                    presentValue: 0,
                    growthRate: 0,
                    regularDeposit: 0,
                    periodType: PeriodType.Annual));
        }


        [TestMethod]
        public void FutureValue_PeriodsMaxValue_Throws_ArgumentOutOfRangeException()
        {
            var calculator = new FinancialCalculator();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValue(
                    startDate: DateTime.MinValue,
                    periods: int.MaxValue,
                    presentValue: 0,
                    growthRate: 0,
                    regularDeposit: 0,
                    periodType: PeriodType.Annual));
        }

        [TestMethod]
        public void EffectiveAnnualInterestRate_PreCalculatedResultSet_MatchesExpectedCollection()
        {
            var calculator = new FinancialCalculator();

            var mappedInputOutput = new List<EffectiveAnnualReturnTestResult>()
            {
                // Annual - positive
                new() { NominalRate = 0.1F, CompoundSchedule = CompoundSchedule.Annually, ExpectedValue = 0.1F },
                new() { NominalRate = 0.1759F, CompoundSchedule = CompoundSchedule.Annually, ExpectedValue = 0.1759F },
                
                // Annual - negative
                new() { NominalRate = -0.1F, CompoundSchedule = CompoundSchedule.Annually, ExpectedValue = -0.1F },
                new() { NominalRate = -0.1759F, CompoundSchedule = CompoundSchedule.Annually, ExpectedValue = -0.1759F },

                // SemiAnnual - positive
                new() { NominalRate = 0.1F, CompoundSchedule = CompoundSchedule.SemiAnnually, ExpectedValue = 0.1025F },
                new() { NominalRate = 0.1759F, CompoundSchedule = CompoundSchedule.SemiAnnually, ExpectedValue = 0.1836F },

                // SemiAnnual - negative
                new() { NominalRate = -0.1F, CompoundSchedule = CompoundSchedule.SemiAnnually, ExpectedValue = -0.0975F },
                new() { NominalRate = -0.1759F, CompoundSchedule = CompoundSchedule.SemiAnnually, ExpectedValue = -0.1682F },

                // Monthly - positive
                new() { NominalRate = 0.1F, CompoundSchedule = CompoundSchedule.Monthly, ExpectedValue = 0.1047F },
                new() { NominalRate = 0.1759F, CompoundSchedule = CompoundSchedule.Monthly, ExpectedValue = 0.1908F },
                
                // Monthly - negative
                new() { NominalRate = -0.1F, CompoundSchedule = CompoundSchedule.Monthly, ExpectedValue = -0.0955F },
                new() { NominalRate = -0.1759F, CompoundSchedule = CompoundSchedule.Monthly, ExpectedValue = -0.1624F },

                // Daily - positive
                // TODO: NominalRate = 0.1F gives output off by 0.0001. Figure out why.
                new() { NominalRate = 0.1F, CompoundSchedule = CompoundSchedule.Daily, ExpectedValue = 0.1051F },
                new() { NominalRate = 0.1759F, CompoundSchedule = CompoundSchedule.Daily, ExpectedValue = 0.1923F },

                // Daily - negative
                new() { NominalRate = -0.1F, CompoundSchedule = CompoundSchedule.Daily, ExpectedValue = -0.0952F },
                new() { NominalRate = -0.1759F, CompoundSchedule = CompoundSchedule.Daily, ExpectedValue = -0.1613F },

                // Continuous - positive
                new() { NominalRate = 0.1F, CompoundSchedule = CompoundSchedule.Continuous, ExpectedValue = 0.1052F },
                new() { NominalRate = 0.1759F, CompoundSchedule = CompoundSchedule.Continuous, ExpectedValue = 0.1923F },

                // Continuous - negative
                new() { NominalRate = -0.1F, CompoundSchedule = CompoundSchedule.Continuous, ExpectedValue = -0.0952F },
                new() { NominalRate = -0.1759F, CompoundSchedule = CompoundSchedule.Continuous, ExpectedValue = -0.1613F }
            };

            var observations = from io in mappedInputOutput
                               select new
                               {
                                   Map = io,
                                   ObservedValue = calculator.EffectiveAnnualInterestRate(
                                       nominalRate: io.NominalRate,
                                       compounding: io.CompoundSchedule)
                               };

            var fails = new List<AssertFailedException>();

            foreach (var obs in observations)
            {
                try
                {
                    Assert.AreEqual(
                        obs.Map.ExpectedValue, obs.ObservedValue, ResultPrecision);
                }
                catch (AssertFailedException e)
                {
                    Debug.WriteLine(e);
                    fails.Add(e);
                }
            }

            Assert.IsFalse(fails.Any());
        }

        /// <summary>
        /// Represents an input-output map for the 
        /// <see cref="IFinancialCalculator.EffectiveAnnualInterestRate"/> function.
        /// </summary>
        readonly record struct EffectiveAnnualReturnTestResult
        {
            public float NominalRate { get; init; }

            public CompoundSchedule CompoundSchedule { get; init; }

            public float ExpectedValue { get; init; }
        }

        /// <summary>
        /// Represents an input-output map for the 
        /// <see cref="IFinancialCalculator.AnnualizedTimeWeightedReturn"/> function.
        /// </summary>
        readonly record struct AnnualizedReturnTestResult
        {
            public float CumulativeRate { get; init; }

            public float Years { get; init; }

            public double ExpectedValue { get; init; }
        }
    }
}
