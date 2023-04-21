using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NjordFinance.BusinessLogic.Brokerage
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
                
                // 4. Scenario: Transaction is complete, but only one tax lot is available to close
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

        /// <inheritdoc/>
        public ITransactionUpdateResponse PostAllocation(AllocationInstructionTable allocationTable)
        {
            // Applies an instruction row to a broker transaction.
            static void ApplyInstruction(BrokerTransaction brokerTransaction, AllocationInstructionRow instruction)
            {
                decimal proportion = instruction.ClosingQuantity / brokerTransaction.Quantity ?? 0M;

                brokerTransaction.Quantity = ProRate(brokerTransaction.Quantity, proportion, 6);
                brokerTransaction.Fee = ProRate(brokerTransaction.Fee, proportion, 2); ;
                brokerTransaction.Withholding = ProRate(brokerTransaction.Withholding, proportion, 2);
                brokerTransaction.Amount = ProRate(brokerTransaction.Amount, proportion, 2) ?? default;

                brokerTransaction.TaxLotId = instruction.TaxLot.TaxLotId;
            }
            
            // Copies all attributes of the source broker transaction to the destination broker 
            // transaction, except for TaxLot and TaxLotId.
            static BrokerTransaction CopyTo(BrokerTransaction source, BrokerTransaction destination)
            {
                destination.AccountId = source.AccountId;
                destination.SecurityId = source.SecurityId;
                destination.TradeDate = source.TradeDate;
                destination.SettleDate = source.SettleDate;
                destination.AcquisitionDate = source.AcquisitionDate;
                destination.Quantity = source.Quantity;
                destination.Amount = source.Amount;
                destination.Fee = source.Fee;
                destination.Withholding = source.Withholding;
                destination.DepSecurityId = source.DepSecurityId;
                destination.TransactionCodeId = -source.TransactionCodeId;

                return destination;
            };

            // Returns the originalAmount pro-rated based on factor and decimal precision, 
            // or null if the originalAmount is null.
            static decimal? ProRate(decimal? originalAmount, decimal factor, int decimals) =>
                originalAmount is null ? 
                    null : Math.Round((originalAmount ?? default) * factor, decimals);

            var initTransaction = allocationTable.Transaction;

            // Verify the quantity value is set.
            if ((initTransaction.Quantity ?? default) == 0M)
                throw new ArgumentException(
                    message: string.Format(
                            ExceptionString.BrokerTransactionBLL_ClosingField_NotSet,
                            nameof(BrokerTransaction.Quantity)));

            // Verify the amount value is set.  
            if(initTransaction.Amount == 0M)
                throw new ArgumentException(
                    message: string.Format(
                            ExceptionString.BrokerTransactionBLL_ClosingField_NotSet,
                            nameof(BrokerTransaction.Amount)));

            var splitTransactions = Enumerable.Repeat(
                element: CopyTo(source: initTransaction, destination: AddTransaction()),
                count: allocationTable.Instructions.Count - 1)
                .Append(initTransaction)
                .ToList();

            for(int i = 0; i < allocationTable.Instructions.Count; i++)
            {
                var transaction = splitTransactions[i];
                var instruction = allocationTable.Instructions[i];

                ApplyInstruction(transaction, instruction);

                transaction.TaxLotId = instruction.TaxLot.TaxLotId;
            }

            return new TransactionUpdateResponse<object>()
            {
                UpdateStatus = TransactionUpdateStatus.Completed
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
        private readonly IEnumerable<BrokerTransactionCode>_brokerTransactionCodes;
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
        /// Gets a collection of <see cref="BrokerTaxLot"/> representing each tax
        /// lot observed in the <see cref="BrokerTransaction"/> collection, combined with closing 
        /// activity derived from that same collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
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
