using Microsoft.Extensions.Logging;

namespace NjordFinance.Logging
{
    /// <summary>
    /// Extension class for implementing the <see cref="LoggerMessage"/>
    /// <see href="https://docs.microsoft.com/en-us/dotnet/core/extensions/high-performance-logging">
    /// pattern</see>.
    /// </summary>
    /// <remarks>
    /// <list type="table"> Event codes are selected based on the logging event.
    /// <item>Verbose: [0, 100)</item>
    /// <item>Debug: [100, 200)</item>
    /// <item>Information: [200, 300)</item>
    /// <item>Warning: [300, 400)</item>
    /// <item>Error: [400, 500)</item>
    /// <item>Fatal: [900, 1000)</item>
    /// </list>
    /// </remarks>
    internal static partial class LoggerExtensions
    {
        // No members should be defined in this file. Serves as class documentationo hub only.
    }
}
