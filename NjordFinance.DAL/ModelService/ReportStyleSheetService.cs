using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
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
