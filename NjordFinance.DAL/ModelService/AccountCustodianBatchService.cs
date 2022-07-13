using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="AccountWallet"/> 
    /// data store.
    /// </summary>
    internal class AccountCustodianBatchService : ModelBatchService<AccountCustodian>
    {
        /// <summary>
        /// Creates a new <see cref="AccountWalletService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public AccountCustodianBatchService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
                : base(contextFactory, modelMetadata, logger)
        {
            ForParent(parentId: default, out _);
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            Reader = new ModelReaderService<AccountCustodian>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => true
            };

            Writer = new ModelWriterBatchService<AccountCustodian>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => true,
                GetDefaultModelDelegate = () => new AccountCustodian()
            };

            e = null;
            return true;
        }

        //public override bool ForParent(int parentId, out Exception e)
        //{
        //    Reader = new ModelReaderService<AccountWallet>(
        //        this, _modelMetadata, _logger)
        //    {
        //        ParentExpression = x => x.AccountId == parentId
        //    };

        //    Writer = new ModelWriterBatchService<AccountWallet>(
        //        this, _modelMetadata, _logger)
        //    {
        //        ParentExpression = x => x.AccountId == parentId,
        //        GetDefaultModelDelegate = () => new AccountWallet() { AccountId = parentId }
        //    };

        //    e = null;
        //    return true;
        //}
    }
}
