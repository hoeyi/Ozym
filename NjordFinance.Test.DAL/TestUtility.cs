using NjordFinance.Test.ModelService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NjordFinance.Test
{
    /// <summary>
    /// Container class for test helper methods and assembly-level resource 
    /// initialization/cleanup.
    /// </summary>
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

        /// <summary>
        /// Checks public instance property values are equal two <typeparamref name="T"/> instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rhs"></param>
        /// <param name="lhs"></param>
        /// <remarks> The properties checked by this method are public instance properties deriving 
        /// from <see cref="ValueType"/>, <see cref="string"/>, <see cref="DateTime"/>, and those with  
        /// types: <see cref="string"/>, <see cref="DateTime"/>.
        /// </remarks>
        /// <returns>True if all matching property values are equal, else false.</returns>
        internal static bool SimplePropertiesAreEqual<T>(T rhs, T lhs)
        {
            if (rhs is null || lhs is null)
                return false;

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                    p.PropertyType.IsSubclassOf(typeof(ValueType)) ||
                    p.PropertyType.IsSubclassOf(typeof(string)) ||
                    p.PropertyType.IsSubclassOf(typeof(DateTime)) ||
                    p.PropertyType == typeof(string) ||
                    p.PropertyType == typeof(DateTime));

            var propertyValues = properties.Select(p => (p.Name, p.GetValue(rhs), p.GetValue(lhs)));

            var results = from p in propertyValues
                          select new
                          {
                              Property = p.Name,
                              LhsValue = p.Item2,
                              RhsValue = p.Item3,
                              AreEqual = p.Item2?.Equals(p.Item3) ?? (p.Item2 is null && p.Item3 is null)
                          };

            return results.All(r => r.AreEqual);
        }
    }
}
