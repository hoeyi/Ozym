﻿using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModel.Context;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;

namespace NjordinSight.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="InvestmentPerformanceEntry"/> 
    /// data store.
    /// </summary>
    internal class InvestmentPerformanceService : ModelCollectionService<InvestmentPerformanceEntry>
    {
        /// <summary>
        /// Creates a new <see cref="InvestmentPerformanceService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public InvestmentPerformanceService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<InvestmentPerformanceEntry>(
                ContextFactory, ModelMetadata, Logger);
            GetDefaultModelDelegate = () => new InvestmentPerformanceEntry()
            {
                FromDate = DateTime.UtcNow.Date.AddDays(-1),
                ToDate = DateTime.UtcNow.Date
            };
        }
    }
}
