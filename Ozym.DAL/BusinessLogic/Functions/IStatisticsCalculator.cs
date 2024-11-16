namespace Ozym.BusinessLogic.Functions
{
    /// <summary>
    /// Represents a stateless class providing statistics-related mathematical functions.
    /// </summary>
    public interface IStatisticsCalculator
    {
        /// <summary>
        /// Generates a normally-distrubted random number using the Box-Muller transform.
        /// </summary>
        /// <param name="mean">The mean of the distribution sampled.</param>
        /// <param name="stddev">The standard deviation of the distribution sampled.</param>
        /// <returns>A <see cref="double"/> given the generated sample.</returns>
        double NormalDistributionSample(double mean, double stddev);

        /// <summary>
        /// Generates a series of normally-distributed random numbers using the Box-Muller transform.
        /// </summary>
        /// <param name="mean">The mean of the distribution sampled.<</param>
        /// <param name="stddev">The standard deviation of the distribution sampled.</param>
        /// <param name="count">The number of samples to return.</param>
        /// <returns>The generated series as an array of <see cref="double"/>.</returns>
        double[] NormalDistributionSamples(double mean, double stddev, int count);

        /// <summary>
        /// Generates a random number from a Student's t-distribution.
        /// </summary>
        /// <param name="mu">The location parameter for the sampled distribution.</param> 
        /// <param name="scale">The scale parameter for the sampled distribution.</param>
        /// <param name="degreesOfFreedom">The degrees of freedom for the sampled distribution.</param>
        /// <returns>The generated sample as a <see cref="double"/>.</returns>
        double StudentTDistributionSample(double mu, double scale, double degreesOfFreedom);

        /// <summary>
        /// Generates a random number series from a Student's t-distribution.
        /// </summary>
        /// <param name="mu">The location parameter for the sampled distribution.</param> 
        /// <param name="scale">The scale parameter for the sampled distribution.</param>
        /// <param name="degreesOfFreedom">The degrees of freedom for the sampled distribution.</param>
        /// <returns>The generated series as an array of <see cref="double"/>.</returns>
        double[] StudentTDistributionSamples(double mu, double scale, double degreesOfFreedom, int count);
    }
}
