using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="InvestmentPerformanceEntry"/> 
    /// data store.
    /// </summary>
    internal class InvestmentPerformanceService : ModelBatchService<InvestmentPerformanceEntry>
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
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            Reader = new ModelReaderService<InvestmentPerformanceEntry>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountObjectId == parentId
            };

            Writer = new ModelWriterBatchService<InvestmentPerformanceEntry>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountObjectId == parentId,
                GetDefaultModelDelegate = () => new()
                {
                    AccountObjectId = parentId
                }
            };

            e = null;
            return true;
        }
    }
}
