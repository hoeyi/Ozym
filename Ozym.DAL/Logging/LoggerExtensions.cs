using Microsoft.Extensions.Logging;

namespace Ozym.Logging
{
    /// <summary>
    /// Extension class for implementing the <see cref="LoggerMessage"/>
    /// <see href="https://docs.microsoft.com/en-us/dotnet/core/extensions/high-performance-logging">
    /// pattern</see>.
    /// </summary>
    /// <remarks>
    /// <list type="table"> Event codes are selected based on the logging event.
    /// <item><see cref="LogLevel.Trace"/>: [0, 99]</item>
    /// <item><see cref="LogLevel.Debug"/>: [100, 199]</item>
    /// <item><see cref="LogLevel.Information"/>: [200, 299]</item>
    /// <item><see cref="LogLevel.Warning"/>: [300, 399]</item>
    /// <item><see cref="LogLevel.Error"/>: [400, 499]</item>
    /// <item><see cref="LogLevel.Critical"/>: [900, 999]</item>
    /// </list>
    /// </remarks>
    public static partial class LoggerExtensions
    {
        // No members should be defined in this file. Serves as class documentation hub only.
    }
}
