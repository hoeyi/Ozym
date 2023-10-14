using Ozym.Logging.Templates;
using Microsoft.Extensions.Logging;
using System;

namespace Ozym.Logging
{
    public static partial class LoggerExtensions
    {
        private static readonly Action<ILogger, object, Exception> _modelServiceAddedPendingSave =
            LoggerMessage
                .Define<object>(
                    logLevel: LogLevel.Debug,
                    eventId: new EventId(100, name: nameof(ModelServiceAddedPendingSave)),
                    formatString: DebugMessage.ModelService_AddPendingSave_Success);

        private static readonly Action<ILogger, object, Exception> _modelServiceDeletedPendingSave =
            LoggerMessage
                .Define<object>(
                    logLevel: LogLevel.Debug,
                    eventId: new EventId(101, name: nameof(ModelServiceDeletedPendingSave)),
                    formatString: DebugMessage.ModelService_DeletePendingSave_Success);

        /// <summary>
        /// Creates an debug-level log entry for a model created as a pending change.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the created model.</param>
        public static void ModelServiceAddedPendingSave(this ILogger logger, object model) =>
            _modelServiceAddedPendingSave(logger, model, null);

        /// <summary>
        /// Creates an debug-level log entry for a model deleted as a pending change.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the deleted model.</param>
        public static void ModelServiceDeletedPendingSave(this ILogger logger, object model) =>
            _modelServiceDeletedPendingSave(logger, model, null);
    }
}
