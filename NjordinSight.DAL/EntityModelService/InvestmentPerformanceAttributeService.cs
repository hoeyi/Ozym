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
        ModelBatchService<InvestmentPerformanceAttributeMemberEntry>, 
        IModelBatchService<InvestmentPerformanceAttributeMemberEntry, (AccountObject, ModelAttributeMember)>
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

        public override bool ForParent(int parentId, out Exception e)
        {
            e = new(message: ExceptionString.ModelService_ParentNotSupported);
            return false;
        }

        public bool ForParent(
            (AccountObject, ModelAttributeMember) parent, out Exception e)
        {
            if (ParentCompositeKey is null)
                ParentCompositeKey = new(parent.Item1.AccountObjectId, parent.Item2.AttributeMemberId);
            else
            {
                e = new(message: ExceptionString.ModelService_ParentKeyAlreadySet);
                return false;
            }

            Reader = new ModelReaderService<InvestmentPerformanceAttributeMemberEntry>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountObjectId == ParentCompositeKey.AccountObjectId
                    && x.AttributeMemberId == ParentCompositeKey.AttributeMemberId
            };

            Writer = new ModelWriterBatchService<InvestmentPerformanceAttributeMemberEntry>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountObjectId == ParentCompositeKey.AccountObjectId
                    && x.AttributeMemberId == ParentCompositeKey.AttributeMemberId,
                GetDefaultModelDelegate = () => new()
                {
                    AccountObjectId = ParentCompositeKey.AccountObjectId,
                    AttributeMemberId = ParentCompositeKey.AttributeMemberId
                }
            };


            e = null;
            return true;
        }

        private ParentKey ParentCompositeKey { get; set; }

        private record ParentKey
        {
            public ParentKey(int accountObjectId, int attributeMemberId)
            {
                AccountObjectId = accountObjectId;
                AttributeMemberId = attributeMemberId;
            }

            public int AccountObjectId { get; }

            public int AttributeMemberId { get; }
        }
    }
}
