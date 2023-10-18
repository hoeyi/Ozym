using Ozym.BusinessLogic.Functions;

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
    }
}
