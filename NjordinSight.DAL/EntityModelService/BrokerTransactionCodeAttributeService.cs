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
    /// The class for servicing single CRUD requests against the 
    /// <see cref="BrokerTransactionCodeAttributeMemberEntry"/> data store.
    /// </summary>
    internal class BrokerTransactionCodeAttributeService 
        : ModelBatchService<BrokerTransactionCodeAttributeMemberEntry>
    {
        /// <summary>
        /// Creates a new <see cref="BrokerTransactionCodeAttributeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public BrokerTransactionCodeAttributeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            Reader = new ModelReaderService<BrokerTransactionCodeAttributeMemberEntry>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => x.TransactionCodeId == parentId
            };

            Writer = new ModelWriterBatchService<BrokerTransactionCodeAttributeMemberEntry>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => x.TransactionCodeId == parentId,
                GetDefaultModelDelegate = () => new BrokerTransactionCodeAttributeMemberEntry()
                {
                    TransactionCodeId = parentId
                }
            };

            e = null;
            return true;
        }
    }
}
