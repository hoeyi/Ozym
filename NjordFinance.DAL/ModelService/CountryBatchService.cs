using System;
using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.Model.ConstraintType;
using NjordFinance.ModelService.Abstractions;
using NjordFinance.ModelService.CustomWriters;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="Country"/> 
    /// data store.
    /// </summary>
    internal class CountryBatchService : ModelBatchService<Country>
    {
        /// <summary>
        /// Creates a new <see cref="CountryBatchService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public CountryBatchService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
                : base(contextFactory, modelMetadata, logger)
        {
            ForParent(parentId: default, out _);
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            Reader = new ModelReaderService<Country>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => true,
                IncludeDelegate = (queryable) => queryable.Include(a => a.AttributeMemberNavigation)
            };

            Writer = new CountryBatchWriterService(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = x => true,
                GetDefaultModelDelegate = () => new Country()
                {
                    AttributeMemberNavigation = new()
                    {
                        AttributeId = (int)ModelAttributeEnum.CountryExposure
                    }
                }
            };

            e = null;
            return true;
        }
    }
}
