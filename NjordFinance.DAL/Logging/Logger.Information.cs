using NjordFinance.Logging.Templates;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace NjordFinance.Logging
{
    public static partial class LoggerExtensions
    {
        private static readonly Action<ILogger, object, Exception> _modelServiceCreatedSingle = 
            LoggerMessage
                .Define<object>(
                    logLevel: LogLevel.Information,
                    eventId: new EventId(200, name: nameof(ModelServiceCreatedModel)),
                    formatString: InformationMessage.ModelService_CreatedSingle);

        private static readonly Action<ILogger, object, Exception> _modelServiceDeletedSingle =
            LoggerMessage
                .Define<object>(
                    logLevel: LogLevel.Information,
                    eventId: new EventId(201, name: nameof(ModelServiceDeletedModel)),
                    formatString: InformationMessage.ModelService_DeletedSingle);

        private static readonly Action<ILogger, object, Exception> _modelServiceReadSingle =
            LoggerMessage
                .Define<object>(
                    logLevel: LogLevel.Information,
                    eventId: new EventId(202, name: nameof(ModelServiceReadModel)),
                    formatString: InformationMessage.ModelService_ReadSingle);

        private static readonly Action<ILogger, object, Exception> _modelServiceUpdatedSingle =
            LoggerMessage
                .Define<object>(
                    logLevel: LogLevel.Information,
                    eventId: new EventId(203, name: nameof(ModelServiceUpdatedModel)),
                    formatString: InformationMessage.ModelService_UpdatedSingle);

        private static readonly Action<ILogger, int, Exception> _modelServiceSavedChanges =
            LoggerMessage
                .Define<int>(
                    logLevel: LogLevel.Information,
                    eventId: new EventId(204, name: nameof(ModelServicesSavedChanges)),
                    formatString: InformationMessage.ModelService_SavedChanges);

        private static readonly Action<ILogger, string, Expression, int, Guid, Exception> 
            _modelServiceSearchRequestAccepted =
                LoggerMessage
                    .Define<string, Expression, int, Guid>(
                        logLevel: LogLevel.Information,
                        eventId: new EventId(205, name: nameof(ModelServiceSearchRequestAccepted)),
                        formatString: InformationMessage.ModelService_SearchRequestAccepted);

        private static readonly Action<ILogger, string, int, Guid, Exception> _modelServiceSearchResultReturned =
            LoggerMessage
                .Define<string, int, Guid>(
                    logLevel: LogLevel.Information,
                    eventId: new EventId(206, name: nameof(ModelServiceSearchResultReturned)),
                    formatString: InformationMessage.ModelService_SearchResultReturned);

        /// <summary>
        /// Creates an information-level log entry for a read model.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the read model.</param>
        public static void ModelServiceReadModel(this ILogger logger, object model) => 
            _modelServiceReadSingle(logger, model, null);

        /// <summary>
        /// Creates an information-level log entry for a created model.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the created model.</param>
        public static void ModelServiceCreatedModel(this ILogger logger, object model) => 
            _modelServiceCreatedSingle(logger, model, null);

        /// <summary>
        /// Creates an information-level log entry for a modified model.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the modified model.</param>
        public static void ModelServiceUpdatedModel(this ILogger logger, object model) => 
            _modelServiceUpdatedSingle(logger, model, null);

        /// <summary>
        /// Creates an information-level log entry for a deleted model.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="model">An object identifying the deleted model.</param>
        public static void ModelServiceDeletedModel(this ILogger logger, object model) => 
            _modelServiceDeletedSingle(logger, model, null);

        /// <summary>
        /// Creates an information-level entry representing a successful service save action.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="modifiedCount">The count of records modified by the action.</param>
        public static void ModelServicesSavedChanges(
            this ILogger logger,
            int modifiedCount)
            => _modelServiceSavedChanges(logger, modifiedCount, null);

        /// <summary>
        /// Creates an information-level entry representing an accepted query.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="requestGuid">The identifier for the request.</param>
        /// <param name="type">The model type sought.</param>
        /// <param name="predicate">The predicate for the request.</param>
        /// <param name="recordLimit">The maximum number of records to return.</param>
        /// <remarks>Persist <paramref name="requestGuid"/> outside this method and re-use its 
        /// value in a call to <see cref="ModelServiceSearchResultReturned(ILogger, Guid, Type, int)"/>.</remarks>
        public static void ModelServiceSearchRequestAccepted(
            this ILogger logger,
            Guid requestGuid,
            Type type,
            Expression predicate,
            int recordLimit)
            => _modelServiceSearchRequestAccepted(logger, type.Name, predicate, recordLimit, requestGuid, null);

        /// <summary>
        /// Creates an information-level entry representing a returned query.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="requestGuid">The identifier for the request.</param>
        /// <param name="type">The model type sought.</param>
        /// <param name="resultCount">The count of records returned.</param>
        /// <remarks>To ensure log entries are linked, inlcude the same <paramref name="requestGuid"/> 
        /// passed to <see cref="ModelServiceSearchRequestAccepted(ILogger, Guid, Type, Expression, int)"/>.</remarks>
        public static void ModelServiceSearchResultReturned(
            this ILogger logger,
            Guid requestGuid,
            Type type,
            int resultCount)
            => _modelServiceSearchResultReturned(logger, type.Name, resultCount, requestGuid, null);
    }
}
