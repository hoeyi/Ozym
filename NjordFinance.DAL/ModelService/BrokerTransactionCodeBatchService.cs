using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="BrokerTransactionCode"/> 
    /// data store.
    /// </summary>
    internal class BrokerTransactionCodeBatchService : ModelBatchService<BrokerTransactionCode>
    {
        /// <summary>
        /// Creates a new <see cref="BrokerTransactionCodeBatchService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public BrokerTransactionCodeBatchService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
                : base(contextFactory, modelMetadata, logger)
        {
            ForParent(parentId: default, out _);
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            Reader = new ModelReaderService<BrokerTransactionCode>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => true
            };

            Writer = new ModelWriterBatchService<BrokerTransactionCode>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => true,
                GetDefaultModelDelegate = () => new BrokerTransactionCode()
            };

            e = null;
            return true;
        }
    }
}
