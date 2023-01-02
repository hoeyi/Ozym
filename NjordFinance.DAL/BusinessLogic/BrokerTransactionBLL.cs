using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace NjordFinance.BusinessLogic
{
    /// <summary>
    /// Represents the allowable states for a <see cref="BrokerTaxLot"/> record.
    /// </summary>
    [Flags]
    public enum TaxLotStatus
    {
        None = 0,

        /// <summary>
        /// The tax lot has non-zero unclosed quantity.
        /// </summary>
        Open = 1,

        /// <summary>
        /// The tax lot has zero unclosed quantity.
        /// </summary>
        Closed = 2
    }
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
                AccountId = _parentAccount.AccountId
            };

            _brokerTransactions.Insert(0, newTransaction);

            return newTransaction;
        }

        /// <inheritdoc/>
        public void UpdateTransactionCode(BrokerTransaction model, int newId)
        {
            if (model is null)
                throw new ArgumentNullException(paramName: nameof(model));

            if (model.TransactionCodeId == newId &&
                (model.TransactionCode?.TransactionCodeId ?? newId * -1) == newId)
                return;

            model.TransactionCodeId = newId;
            model.TransactionCode = _brokerTransactionCodes
                .FirstOrDefault(x => x.TransactionCodeId == newId);
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

            //_brokerTransactions.CollectionChanged += BrokerTransactions_OnCollectionChanged;
            //_brokerTransactions.ListChanged += BrokerTransactions_ListChanged;
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
            GetBrokerTaxLotsWithUnclosedQuantity()
                .Where(x => x.UnclosedQuantity == 0);

        /// <summary>
        /// Gets the collection of tax lots for which there is an unclosed quantity.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        private IEnumerable<BrokerTaxLot> GetOpenTaxLots() =>
            GetBrokerTaxLotsWithUnclosedQuantity()
                .Where(x => x.UnclosedQuantity > 0);

        /// <summary>
        /// Gets a collection of <see cref="BrokerTaxLotActivitySummary"/> representing each tax
        /// lot observed in the <see cref="BrokerTransaction"/> collection, combined with closing 
        /// activity derived from that same collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLotActivitySummary"/>.</returns>
        private IEnumerable<BrokerTaxLot> GetBrokerTaxLotsWithUnclosedQuantity()
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
    }

    /// <summary>
    /// Represents a intermediate query result summarizing a <see cref="BrokerTaxLot"/> and 
    /// the closing activity against it.
    /// </summary>
    class BrokerTaxLotActivitySummary
    {
        /// <summary>
        /// Gets the <see cref="BrokerTaxLot"/> for which activity is summarized.
        /// </summary>
        public BrokerTaxLot TaxLot { get; init; }

        /// <summary>
        /// Gets the total quantity closed against the <see cref="TaxLot"/> for this instance.
        /// </summary>
        public decimal? QuantityClosed { get; init; }
    }
}
