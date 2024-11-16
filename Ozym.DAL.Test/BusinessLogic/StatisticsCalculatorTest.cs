using Ozym.BusinessLogic.Functions;
using System;

namespace Ozym.Test.BusinessLogic
{
    [TestClass]
    [TestCategory("Unit")]
    public class StatisticsCalculatorTest
    {
        [TestMethod]
        public void NormalDistribution_StandardNormal_ReturnsDouble()
        {
            var calculator = new StatisticsCalculator();

            var observed = calculator.NormalDistributionSample(0, 1);

            Assert.IsInstanceOfType(observed, typeof(double));
        }

        [TestMethod]
        public void NormalDistributionSamples_StandardNormal_ReturnsArray()
        {
            var calculator = new StatisticsCalculator();

            var observed = calculator.NormalDistributionSamples(0, 1, 100);

            Assert.IsInstanceOfType(observed, typeof(double[]));
            Assert.IsTrue(observed.Length == 100);
            CollectionAssert.AllItemsAreNotNull(observed);
        }

        [TestMethod]
        public void StudentTDistributionSample_ValidParameters_ReturnsDouble()
        {
            var calculator = new StatisticsCalculator();

            var observed = calculator.StudentTDistributionSample(0, 1, 10);

            Assert.IsInstanceOfType(observed, typeof(double));
        }

        [TestMethod]
        public void StudentTDistributionSample_InvalidDegreesOfFreedom_ThrowsArgumentOutOfRangeException()
        {
            var calculator = new StatisticsCalculator();

            // Degrees of  equals zero
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                calculator.StudentTDistributionSample(mu: 0, scale: 1, degreesOfFreedom: 0);
            });

            // Count less than zero
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                calculator.StudentTDistributionSample(mu: 0, scale: 1, degreesOfFreedom: -1);
            });
        }

        [TestMethod]
        public void StudentTDistributionSamples_ValidParameters_ReturnsArray()
        {
            var calculator = new StatisticsCalculator();

            var observed = calculator.StudentTDistributionSamples(0, 1, 10, 100);

            Assert.IsInstanceOfType(observed, typeof(double[]));
            Assert.IsTrue(observed.Length == 100);
            CollectionAssert.AllItemsAreNotNull(observed);
        }

        [TestMethod]
        public void StudentTDistributionSamples_InvalidCount_ThrowsArgumentOutOfRangeException()
        {
            var calculator = new StatisticsCalculator();

            // Count equals zero
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                calculator.StudentTDistributionSamples(0, 1, 10, 0);
            });

            // Count less than zero
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                calculator.StudentTDistributionSamples(0, 1, 10, -1);
            });
        }
    }
}
