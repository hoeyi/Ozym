using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace NjordFinance.BusinessLogic
{
    public partial class BrokerTransactionBLL : IBrokerTransactionBLL
    {
        /// <inheritdoc/>
        public IReadOnlyCollection<BrokerTransaction> Entries => _brokerTransactions;
        
        /// <inheritdoc/>
        public BrokerTransaction AddTransaction()
        {
            BrokerTransaction newTransaction = new()
            {
                TransactionCodeId = default,
                TransactionCode = _brokerTransactionCodes
                    .FirstOrDefault(x => x.TransactionCodeId == default),
                TradeDate = DateTime.UtcNow.Date,
                AccountId = _parentAccount.AccountId
            };

            _brokerTransactions.Insert(0, newTransaction);

            return newTransaction;
        }

        /// <inheritdoc/>
        public ITransactionUpdateResponse UpdateTransactionCode(BrokerTransaction model, int newId)
        {
            if (model is null)
                throw new ArgumentNullException(paramName: nameof(model));

            // Check if any action is required.
            if (model.TransactionCodeId != newId)
                model.TransactionCodeId = newId;
            
            // 1. Scenario: Transaction is incomplete.
            //              Required infortmation:
            //              - SecurityId
            //              - Quantity
            // 1. Action:   Return pending status.
            if (model.TransactionCodeId == default || 
                model.SecurityId == default || 
                (model.Quantity ?? default) == default)
                return new TransactionUpdateResponse<object>()
                {
                    UpdateStatus = TransactionUpdateStatus.PendingAdditionalDetail,
                    ResponseObject = null
                };

            if((model.TransactionCode?.TransactionCodeId ?? newId * -1) != newId)
                model.TransactionCode = _brokerTransactionCodes
                    .FirstOrDefault(x => x.TransactionCodeId == newId);

            // If a closing action, we need to know which lots to close against.
            if (model.TransactionCode.QuantityEffect < 0)
            {

                var openLots = GetOpenTaxLots().Where(x => x.SecurityId == model.SecurityId);

                // 2. Scenario: Transaction is complete, but no lots are available.
                // 2. Action:   Return faulted status with invalid operation exception.
                if (!openLots.Any())
                    return new TransactionUpdateResponse<InvalidOperationException>()
                    {
                        UpdateStatus = TransactionUpdateStatus.Faulted,
                        ResponseObject = new InvalidOperationException(
                            message: ExceptionString.BrokerTransactionBLL_NoAvailableTaxLotsToClose)
                    };

                // 3. Scenario: Transaction is complete, but transaction quantity is greater than 
                //              available quantity.
                // 3. Action:   Return faulted status with invalid operation exception.
                decimal availableQuantity = openLots.Sum(x => x.UnclosedQuantity);
                decimal requestedQuantity = model.Quantity ?? default;

                if (availableQuantity < requestedQuantity)
                    return new TransactionUpdateResponse<InvalidOperationException>()
                    {
                        UpdateStatus = TransactionUpdateStatus.Faulted,
                        ResponseObject = new(message: string.Format(
                            ExceptionString.BrokerTransactionBLL_InsufficientQuantityToCloseAgainst,
                            availableQuantity,
                            requestedQuantity))
                    };
                
                // 4. Scenario: Transaction is complete, but only tax lot is available to close
                //              against.
                // 4. Action:   Apply update and return completed status.
                if(openLots.Count() == 1)
                {
                    var taxLot = openLots.First();

                    model.TaxLotId = openLots.First().TaxLotId;

                    // No further action is needed. Return a completed response.
                    return new TransactionUpdateResponse<object>()
                    {
                        UpdateStatus = TransactionUpdateStatus.Completed,
                        ResponseObject = null
                    };
                }

                // 5. Scenario: Transaction is complete, but multiple tax lots are available to
                //              close against.
                // 5. Action:   Return pending status with instruction table object for the client
                //              to complete.
                return new TransactionUpdateResponse<AllocationInstructionTable>()
                {
                    UpdateStatus = TransactionUpdateStatus.PendingLotClosure,
                    ResponseObject = InitAllocationInstructionTable(model, openLots)
                };
            }
            else
            {
                // 6. Scenario: Transaction is complete, but it is not a closing action.
                // 6. Action:   Clear tax lot id and return completed status.
                model.TaxLotId = null;
                model.TaxLot = null;

                return new TransactionUpdateResponse<object>()
                {
                    UpdateStatus = TransactionUpdateStatus.Completed,
                    ResponseObject = null
                };
            }
        }

        /// <inheritdoc/>
        public void RemoveTransaction(BrokerTransaction model) => _brokerTransactions.Remove(model);
        
        /// <inheritdoc/>
        public void RevertRemoveTransaction(BrokerTransaction model) 
            => _brokerTransactions.Add(model);

        /// <inheritdoc/>
        public IEnumerable<BrokerTaxLot> GetTaxLots(TaxLotStatus taxLotStatus)
        {
            return taxLotStatus switch
            {
                TaxLotStatus.Open | TaxLotStatus.Closed => GetAllTaxLots(),
                TaxLotStatus.Open => GetOpenTaxLots(),
                TaxLotStatus.Closed => GetClosedTaxLots(),
                _ => throw new NotSupportedException(
                    message: string.Format(
                        ExceptionString.BrokerTransactionBLL_TaxLotStatus_NotSupported,
                        taxLotStatus))
            };
        }
    }

    /// <summary>
    /// Represents the collection of business rules for modifying <see cref="BrokerTransaction"/> 
    /// records as children of an <see cref="Account"/> record.
    /// </summary>
    public partial class BrokerTransactionBLL
    {
        private readonly BindingList<BrokerTransaction> _brokerTransactions;
        private readonly IEnumerable<BrokerTransactionCode> _brokerTransactionCodes;
        private readonly Account _parentAccount;

        public BrokerTransactionBLL(
            IList<BrokerTransaction> brokerTransactions,
            IEnumerable<BrokerTransactionCode> transactionCodes,
            Account parentAccount)
        {
            if (brokerTransactions is null)
                throw new ArgumentNullException(paramName: nameof(brokerTransactions));

            if (transactionCodes is null)
                throw new ArgumentNullException(paramName: nameof(transactionCodes));

            if (parentAccount is null)
                throw new ArgumentNullException(paramName: nameof(parentAccount));

            if (brokerTransactions.Any(x => x.TransactionCode is null))
                throw new InvalidOperationException(message:
                    string.Format(
                        ExceptionString.BrokerTransactionBLL_IncompleteObjectGraph,
                        nameof(BrokerTransaction.TransactionCode)));

            if (brokerTransactions.Any(x => x.AccountId != parentAccount.AccountId))
                throw new InvalidOperationException(
                    message: ExceptionString.BrokerTransactionBLL_InvalidCollectionParent);

            _brokerTransactions = new(brokerTransactions);
            _brokerTransactionCodes = transactionCodes;
            _parentAccount = parentAccount;
        }

        /// <summary>
        /// Gets an enumeration of <see cref="BrokerTransaction"/> records that create tax lots.
        /// </summary>
        private IEnumerable<BrokerTransaction> OpeningTransactions =>
            _brokerTransactions
                .Where(x => (x.TransactionCode?.QuantityEffect ?? 0D) > 0D
                    && x.AccountId != default
                    && x.SecurityId != default);

        /// <summary>
        /// Gets an enumeration of <see cref="BrokerTransaction"/> records that close against
        /// tax lots.
        /// </summary>
        private IEnumerable<BrokerTransaction> ClosingTransactions =>
            _brokerTransactions
                .Where(x => (x.TransactionCode?.QuantityEffect ?? 0D) < 0D
                    && x.AccountId != default
                    && x.SecurityId != default
                    && x.TaxLotId is not null);

        /// <summary>
        /// Gets the collection of <see cref="BrokerTaxLot"/> constructed from 
        /// <see cref="_brokerTransactions"/>, ignoring the effect of closing activity.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        private IEnumerable<BrokerTaxLot> GetAllTaxLots() =>
            from x in OpeningTransactions
            select new BrokerTaxLot
            {
                TaxLotId = x.TransactionId,
                SecurityId = x.SecurityId,
                AccountId = x.AccountId,
                AcquisitionDate = x.AcquisitionDate ?? x.TradeDate,
                OriginalCostBasis = x.Amount,
                OriginalQuantity = x.Quantity ?? default
            };

        /// <summary>
        /// Gets the collection of tax lots for which the quantity is closed.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        private IEnumerable<BrokerTaxLot> GetClosedTaxLots() =>
            GetTaxLotsWithUnclosedQuantity()
                .Where(x => x.UnclosedQuantity == 0);

        /// <summary>
        /// Gets the collection of tax lots for which there is an unclosed quantity.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        private IEnumerable<BrokerTaxLot> GetOpenTaxLots() =>
            GetTaxLotsWithUnclosedQuantity()
                .Where(x => x.UnclosedQuantity > 0);

        /// <summary>
        /// Gets a collection of <see cref="BrokerTaxLotActivitySummary"/> representing each tax
        /// lot observed in the <see cref="BrokerTransaction"/> collection, combined with closing 
        /// activity derived from that same collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLotActivitySummary"/>.</returns>
        private IEnumerable<BrokerTaxLot> GetTaxLotsWithUnclosedQuantity()
        {
            var taxLots = GetAllTaxLots();

            var closingActivity = ClosingTransactions
                .GroupBy(x => x.TaxLotId)
                .Select(x => new
                {
                    TaxLotId = x.Key,
                    QuantityClosed = x.Sum(y => y.Quantity * y.TransactionCode.QuantityEffect)
                });

            return from tl in taxLots
                   join ca in closingActivity on tl.TaxLotId equals ca.TaxLotId into ir
                   from summary in ir.DefaultIfEmpty()
                   select new BrokerTaxLot()
                   {
                       TaxLotId = tl.TaxLotId,
                       AccountId = tl.AccountId,
                       SecurityId = tl.SecurityId,
                       AcquisitionDate = tl.AcquisitionDate,
                       OriginalCostBasis = tl.OriginalCostBasis,
                       OriginalQuantity = tl.OriginalQuantity,
                       UnclosedQuantity = tl.OriginalQuantity + (summary?.QuantityClosed ?? 0)
                   };

        }

        /// <summary>
        /// Initializes a new <see cref="AllocationInstructionTable" /> from the given 
        /// <see cref="BrokerTransaction"/> record.
        /// </summary>
        /// <param name="model">The record that is initiating closing action.</param>
        /// <returns>A new instance of <see cref="AllocationInstructionTable" />.</returns>
        private static AllocationInstructionTable InitAllocationInstructionTable(
            BrokerTransaction model, IEnumerable<BrokerTaxLot> availableTaxLots)
        {
            return new()
                {
                    Instructions = availableTaxLots
                                    .Select(x => new AllocationInstructionRow()
                                    {
                                        TaxLot = x,
                                        ClosingQuantity = 0M
                                    })
                                    .ToList(),
                    AvailableTaxLots = availableTaxLots.ToList(),
                    Transaction = model
                };
        }
    }
}
