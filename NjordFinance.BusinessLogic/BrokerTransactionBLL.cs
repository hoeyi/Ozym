using NjordFinance.Model;

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

    public class BrokerTransactionBLL
    {
        private readonly IList<BrokerTransaction> _brokerTransactions;
        public BrokerTransactionBLL(IList<BrokerTransaction> brokerTransactions)
        {
            if (brokerTransactions is null)
                throw new ArgumentNullException(paramName: nameof(brokerTransactions));

            if (brokerTransactions.Any(x => x.TransactionCode is null))
                throw new InvalidOperationException(message:
                    string.Format(
                        ExceptionString.BrokerTransactionBLL_IncompleteObjectGraph, 
                        nameof(BrokerTransaction.TransactionCode)));

            _brokerTransactions = brokerTransactions;
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
        /// Gets the collection of <see cref="BrokerTaxLot"/> for this instance, subject to the 
        /// value(s) of <see cref="TaxLotStatus"/> provided.
        /// </summary>
        /// <param name="taxLotStatus">The status of the tax lot to return.
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        /// <exception cref="NotSupportedException">The value of passed to 
        /// <paramref name="taxLotStatus"/> is not valid for this method.</exception>
        public IEnumerable<BrokerTaxLot> GetTaxLots(TaxLotStatus taxLotStatus)
        {
            return taxLotStatus switch
            {
                TaxLotStatus.Open | TaxLotStatus.Closed => GetAllTaxLots(),
                TaxLotStatus.Open => GetOpenTaxLots(),
                TaxLotStatus.Closed => GetClosedTaxLots(),
                _ => throw new NotSupportedException(
                    message: string.Format(
                    ExceptionString.BrokerTransactionBLL_TaxLotStatus_NotSupported, taxLotStatus))
            };
        }

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
