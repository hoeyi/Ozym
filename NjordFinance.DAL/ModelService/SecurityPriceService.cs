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
    /// The class for servicing single CRUD requests against the <see cref="SecurityPrice"/> 
    /// data store.
    /// </summary>
    internal class SecurityPriceService : ModelBatchService<SecurityPrice>
    {
        /// <summary>
        /// Creates a new <see cref="SecurityPriceService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecurityPriceService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<SecurityPrice>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = null
            };

            Writer = new ModelWriterBatchService<SecurityPrice>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = null,
                GetDefaultModelDelegate = () => new()
            };
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            e = new NotSupportedException(
                message: Exceptions.ExceptionString.ModelService_ParentNotSupported);
            return false;
        }
    }
}
