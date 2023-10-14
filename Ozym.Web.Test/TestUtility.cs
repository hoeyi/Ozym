using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ozym.Web.Test.Identity;

namespace Ozym.Web.Test
{
    [TestClass]
    public class TestUtility
    {
        /// <summary>
        /// Resets the test 
        /// </summary>
        [AssemblyCleanup]
        public static void ResetDatabaseToInitialState() =>
            TestDbContextFactory.ResetTestDatabase();

        /// <summary>
        /// Getst the configuration used by unit tests.
        /// </summary>
        internal static IConfiguration Configuration { get; } =
            new ConfigurationBuilder()
            .AddUserSecrets<TestUtility>()
            .Build();

        /// <summary>
        /// Gets the <see cref="IDbContextFactory{TContext}"/> for creating test contexts.
        /// </summary>
        internal static TestDbContextFactory DbContextFactory { get; private set; } = new();

        /// <summary>
        /// The <see cref="ILogger"/> instance for this project.
        /// </summary>
        internal static readonly ILogger Logger = LoggerFactory
            .Create(builder => builder.AddConsole().AddDebug())
            .CreateLogger<TestUtility>();
    }
}
