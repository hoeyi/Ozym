using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModel.Context;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;

namespace NjordinSight.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="InvestmentStrategyTarget"/> 
    /// data store.
    /// </summary>
    internal class InvestmentStrategyTargetService : ModelBatchService<InvestmentStrategyTarget>
    {
        /// <summary>
        /// Creates a new <see cref="InvestmentStrategyTargetService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public InvestmentStrategyTargetService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            Reader = new ModelReaderService<InvestmentStrategyTarget>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => x.InvestmentStrategyId == parentId
            };

            Writer = new ModelWriterBatchService<InvestmentStrategyTarget>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => x.InvestmentStrategyId == parentId,
                GetDefaultModelDelegate = () => new()
                {
                    InvestmentStrategyId = parentId
                }
            };

            e = null;
            return true;
        }
    }
}
