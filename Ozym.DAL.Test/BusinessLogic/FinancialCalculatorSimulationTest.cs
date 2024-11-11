using MathNet.Numerics.Distributions;
using Ozym.BusinessLogic.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.Test.BusinessLogic
{
    public partial class FinancialCalculatorTest
    {
        [TestMethod]
        public void FutureValueSimulation_PeriodsMinValue_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(
                    startDate: DateTime.MinValue,
                    periods: int.MinValue,
                    presentValue: 0,
                    growthRate: (0, 0),
                    regularDeposit: (0, 0),
                    periodType: PeriodType.Annual));
        }

        [TestMethod]
        public void FutureValueSimulation_PeriodsMaxValue_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(
                    startDate: DateTime.MinValue,
                    periods: int.MaxValue,
                    presentValue: 0,
                    growthRate: (0, 0),
                    regularDeposit: (0, 0),
                    periodType: PeriodType.Annual));
        }

        [TestMethod]
        public void FutureValueSimulation_SimulationsBelowMinimum_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(
                    startDate: DateTime.MinValue,
                    periods: 0,
                    presentValue: 0,
                    growthRate: (0, 0),
                    regularDeposit: (0, 0),
                    periodType: PeriodType.Annual,
                    simulations: 0));
        }

        [TestMethod]
        public void FutureValueSimulation_SimulationsAboveMaximum_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(
                    startDate: DateTime.MinValue,
                    periods: 0,
                    presentValue: 0,
                    growthRate: (0, 0),
                    regularDeposit: (0, 0),
                    periodType: PeriodType.Annual,
                    simulations: int.MaxValue));
        }

        [TestMethod]
        public void FutureValueSimulation_SingleSimulation_ValidParameters_ReturnsExpectedResult()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var testDate = DateTime.UtcNow.Date;

            // Act
            var resultset = calculator.FutureValueSimulation(testDate, 5, 100, (0.1F, 0.16F), (0, 0), PeriodType.Annual);

            // Assert
            Assert.AreEqual(expected: 1, actual: resultset.Count);
            Assert.AreEqual(expected: 6, actual: resultset[0].Count());
            Assert.AreEqual(expected: 5, actual: resultset[0].Max(x => x.Period));
        }

        [TestMethod]
        public void FutureValueSimulation_MaxSimulation_ValidParameters_ReturnsExpectedResult()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var testDate = DateTime.UtcNow.Date;

            // Act
            var resultset = calculator.FutureValueSimulation(testDate, 20, 100, (0.1F, 0.16F), (10, 5), PeriodType.Annual, simulations: 1000);

            // Assert
            Assert.AreEqual(expected: 1000, actual: resultset.Count);
            Assert.IsTrue(resultset.Values.All(x => x.Count() == 21));
            Assert.IsTrue(resultset.Values.All(x => x.Max(y => y.Period) == 20));
        }


        [TestMethod]
        public void FutureValueSimulation_GrowthDistributionIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var startDate = DateTime.UtcNow.Date;
            var periods = 10;
            var presentValue = 100;
            IContinuousDistribution growthDistribution = null;
            IContinuousDistribution contributionDistribution = new Normal();
            var periodType = PeriodType.Annual;
            var simulations = 1;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                calculator.FutureValueSimulation(startDate, periods, presentValue, growthDistribution, contributionDistribution, periodType, simulations));
        }

        [TestMethod]
        public void FutureValueSimulation_ContributionDistributionIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var startDate = DateTime.UtcNow.Date;
            var periods = 10;
            var presentValue = 100;
            IContinuousDistribution growthDistribution = new Normal();
            IContinuousDistribution contributionDistribution = null;
            var periodType = PeriodType.Annual;
            var simulations = 1;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                calculator.FutureValueSimulation(startDate, periods, presentValue, growthDistribution, contributionDistribution, periodType, simulations));
        }

        [TestMethod]
        public void FutureValueSimulation_PeriodsLessThanOne_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var startDate = DateTime.UtcNow.Date;
            var periods = 0;
            var presentValue = 100;
            IContinuousDistribution growthDistribution = new Normal();
            IContinuousDistribution contributionDistribution = new Normal();
            var periodType = PeriodType.Annual;
            var simulations = 1;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(startDate, periods, presentValue, growthDistribution, contributionDistribution, periodType, simulations));
        }

        [TestMethod]
        public void FutureValueSimulation_PeriodsGreaterThanOneHundred_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var startDate = DateTime.UtcNow.Date;
            var periods = 101;
            var presentValue = 100;
            IContinuousDistribution growthDistribution = new Normal();
            IContinuousDistribution contributionDistribution = new Normal();
            var periodType = PeriodType.Annual;
            var simulations = 1;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(startDate, periods, presentValue, growthDistribution, contributionDistribution, periodType, simulations));
        }

        [TestMethod]
        public void FutureValueSimulation_SimulationsLessThanOne_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var startDate = DateTime.UtcNow.Date;
            var periods = 10;
            var presentValue = 100;
            IContinuousDistribution growthDistribution = new Normal();
            IContinuousDistribution contributionDistribution = new Normal();
            var periodType = PeriodType.Annual;
            var simulations = 0;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(startDate, periods, presentValue, growthDistribution, contributionDistribution, periodType, simulations));
        }

        [TestMethod]
        public void FutureValueSimulation_SimulationsGreaterThanOneThousand_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new FinancialCalculator();
            var startDate = DateTime.UtcNow.Date;
            var periods = 10;
            var presentValue = 100;
            IContinuousDistribution growthDistribution = new Normal();
            IContinuousDistribution contributionDistribution = new Normal();
            var periodType = PeriodType.Annual;
            var simulations = 1001;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                calculator.FutureValueSimulation(startDate, periods, presentValue, growthDistribution, contributionDistribution, periodType, simulations));
        }
    }
}
