﻿using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.EntityModel.Context;
using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;

namespace Ozym.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="ReportStyleSheet"/> 
    /// data store.
    /// </summary>
    internal class ReportStyleSheetService : ModelService<ReportStyleSheet>
    {
        /// <summary>
        /// Creates a new <see cref="ReportStyleSheetService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public ReportStyleSheetService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<ReportStyleSheet>(
                contextFactory, modelMetadata, logger);
            Writer = new ModelWriterService<ReportStyleSheet>(
                contextFactory, modelMetadata, logger);
        }
    }
}
