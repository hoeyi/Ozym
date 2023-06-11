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
    /// <see cref="InvestmentPerformanceAttributeMemberEntry"/> data store.
    /// </summary>
    internal class InvestmentPerformanceAttributeService : 
        ModelCollectionService<InvestmentPerformanceAttributeMemberEntry,
            (AccountObject, ModelAttributeMember)>
    {
        /// <summary>
        /// Creates a new <see cref="InvestmentPerformanceAttributeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public InvestmentPerformanceAttributeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public override void SetParent((AccountObject, ModelAttributeMember) parent)
        {

            if (ParentCompositeKey is null)
            {
                ParentCompositeKey = new ParentKey
                {
                    AccountObjectId = parent.Item1.AccountObjectId,
                    AttributeMemberId = parent.Item2.AttributeMemberId
                };
            }
            else
            {
                throw new InvalidOperationException(
                    message: ExceptionString.ModelService_ParentKeyAlreadySet);
            }

            Reader = new ModelReaderService<InvestmentPerformanceAttributeMemberEntry>(
                ContextFactory, ModelMetadata, Logger)
            {
                ParentExpression = x => x.AccountObjectId == ParentCompositeKey.AccountObjectId
                    && x.AttributeMemberId == ParentCompositeKey.AttributeMemberId
            };

            GetDefaultModelDelegate = () => new()
            {
                AccountObjectId = ParentCompositeKey.AccountObjectId,
                AttributeMemberId = ParentCompositeKey.AttributeMemberId
            };
        }

        private ParentKey ParentCompositeKey { get; set; }

        private record ParentKey
        {
            public int AccountObjectId { get; init; }

            public int AttributeMemberId { get; init; }
        }
    }
}
