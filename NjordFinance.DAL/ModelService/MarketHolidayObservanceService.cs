﻿using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="MarketHolidayObservance"/> 
    /// data store.
    /// </summary>
    internal class MarketHolidayObservanceService : ModelBatchService<MarketHolidayObservance>
    {
        /// <summary>
        /// Creates a new <see cref="MarketHolidayObservanceService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public MarketHolidayObservanceService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<MarketHolidayObservance>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = null
            };

            Writer = new ModelWriterBatchService<MarketHolidayObservance>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = null,
                GetDefaultModelDelegate = () => new()
            };
        }

        public override bool ForParent(int parentId, out NotSupportedException e)
        {
            e = new(message: Exceptions.ExceptionString.ModelService_ParentNotSupported);
            return false;
        }
    }
}