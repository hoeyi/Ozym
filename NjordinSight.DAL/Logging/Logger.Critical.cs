using NjordinSight.Logging.Templates;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore;

namespace NjordinSight.Logging
{
    public static partial class LoggerExtensions
    {
        private static readonly Action<ILogger, DateTime, Exception>
            _unhandledExceptionEncountered =
                LoggerMessage
                    .Define<DateTime>(
                        logLevel: LogLevel.Critical,
                        eventId: new EventId(900, nameof(UnhandledExceptionEncountered)),
                        formatString: ExceptionMessage.UnhandledException);

        /// <summary>
        /// Creates a critical-level entry representing an unhandled/unrecoverable error.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        public static void UnhandledExceptionEncountered(
            this ILogger logger,
            Exception exception)
            // Should be UTCNow, but system tiem should suffice for now.
            // TODO: Update logging methods to address timezones.
            => _unhandledExceptionEncountered(logger, DateTime.Now, exception);
    }
}
