﻿using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="CountryAttributeMemberEntry"/> 
    /// data store.
    /// </summary>
    internal class CountryAttributeService : ModelBatchService<CountryAttributeMemberEntry>
    {
        /// <summary>
        /// Creates a new <see cref="CountryAttributeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public CountryAttributeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        public override bool ForParent(int parentId)
        {
            Reader = new ModelReaderService<CountryAttributeMemberEntry>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.CountryId == parentId
            };

            Writer = new ModelWriterBatchService<CountryAttributeMemberEntry>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.CountryId == parentId,
                GetDefaultModelDelegate = () => new CountryAttributeMemberEntry()
                {
                    CountryId = parentId
                }
            };

            return true;
        }
    }
}