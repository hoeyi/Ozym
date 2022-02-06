using EulerFinancial.Logging.Templates;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Logging
{
    #region Error delegates
    internal static partial class LoggerExtensions
    {
        private static readonly Action<ILogger, object, EntityState, EntityState, Exception> 
            _modelServiceAddReturnedInvalidState =
                LoggerMessage
                    .Define<object, EntityState, EntityState>(
                        logLevel: LogLevel.Information,
                        eventId: new EventId(400, name: nameof(ModelServiceAddReturnedInvalidState)),
                        formatString: ExceptionMessage.ModelService_AfterAdd_InvalidState);

        private static readonly Action<ILogger, object, EntityState, EntityState, Exception>
            _modelServiceDeleteReturnedInvalidState =
                LoggerMessage
                    .Define<object, EntityState, EntityState>(
                        logLevel: LogLevel.Error,
                        eventId: new EventId(401, nameof(ModelServiceDeleteReturnedInvalidState)),
                        formatString: ExceptionMessage.ModelService_AfterDelete_InvalidState);
        
        private static readonly Action<ILogger, object, Exception>
            _modelServiceReadSingleFailed =
                LoggerMessage
                    .Define<object>(
                        logLevel: LogLevel.Error,
                        eventId: new EventId(402, nameof(ModelServiceReadSingleFailed)),
                        formatString: ExceptionMessage.ModelService_ReadSingle_Failed);
        
        private static readonly Action<ILogger, Exception>
            _modelServiceSaveChangesFailed =
                LoggerMessage
                    .Define(
                        logLevel: LogLevel.Error,
                        eventId: new EventId(403, nameof(ModelServiceSaveChangesFailed)),
                        formatString: ExceptionMessage.ModelService_SaveChanges_Failed);

        private static readonly Action<ILogger, object, Exception> 
            _modelServiceNotInitialized =
                LoggerMessage
                    .Define<object>(
                        logLevel: LogLevel.Error,
                        eventId: new EventId(404, name: nameof(ModelServiceNotInitialized)),
                        formatString: ExceptionMessage.ModelService_NotInitialized);
                    
        /// <summary>
        /// Creates an error-level entry representing an addition that resulted in a model 
        /// <see cref="EntityState"/> not equal to the expectation.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the inserted model.</param>
        /// <param name="expected">The expected <see cref="EntityState"/>.</param>
        /// <param name="observed">The observed <see cref="EntityState"/>.</param>
        public static void ModelServiceAddReturnedInvalidState(
            this ILogger logger,
            object model,
            EntityState expected,
            EntityState observed)
            => _modelServiceAddReturnedInvalidState(logger, model, expected, observed, null);

        /// <summary>
        /// Creates an error-level entry representing a deletion that resulted in a model 
        /// <see cref="EntityState"/> not equal to the expectation.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the deleted model.</param>
        /// <param name="expected">The expected <see cref="EntityState"/>.</param>
        /// <param name="observed">The observed <see cref="EntityState"/>.</param>
        public static void ModelServiceDeleteReturnedInvalidState(
            this ILogger logger,
            object model,
            EntityState expected,
            EntityState observed)
        {

        }

        /// <summary>
        /// Creates an error-level entry representing a failure in a model services 'Save' method.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        public static void ModelServiceSaveChangesFailed(
            this ILogger logger,
            Exception exception)
            => _modelServiceSaveChangesFailed(logger, exception);

        /// <summary>
        /// Creates an error-level entry representing a failure to access a model record.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the queried model.</param>
        /// <param name="exception">The exception that caused the failure.</param>
        public static void ModelServiceReadSingleFailed(
            this ILogger logger,
            object model,
            Exception exception)
            => _modelServiceReadSingleFailed(logger, model, exception);

        /// <summary>
        /// Creates an error-level entry representing an encountered invalid model service state.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service">An object identifying the service that is the source of 
        /// the error.</param>
        public static void ModelServiceNotInitialized(
            this ILogger logger,
            object service,
            Exception exception)
            => _modelServiceNotInitialized(logger, service, exception);
    }

    #endregion
}
