using EulerFinancial.Context;
using EulerFinancial.UnitTest.ModelService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerFinancial.UnitTest
{
    /// <summary>
    /// Container class for unit-test helper methods.
    /// </summary>
    internal class UnitTestConfig
    {
        /// <summary>
        /// Getst the configuration used by unit tests.
        /// </summary>
        internal static IConfiguration Configuration { get; } =
            new ConfigurationBuilder()
            .AddUserSecrets<UnitTestConfig>()
            .Build();

        /// <summary>
        /// Gets the <see cref="IDbContextFactory{TContext}"/> for creating test contexts.
        /// </summary>
        internal static TestDbContextFactory DbContextFactory = new();

        internal static readonly ILogger Logger = LoggerFactory
            .Create(builder => builder.AddConsole().AddDebug())
            .CreateLogger<UnitTestConfig>();
    }
}
