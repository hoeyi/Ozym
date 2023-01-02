using NjordFinance.Model;

namespace NjordFinance.BusinessLogic
{
    public interface IBrokerTransactionBLL
    {
        /// <summary>
        /// Gets the read-only collection of <see cref="BrokerTransaction"/> entries 
        /// for this instance.
        /// </summary>
        IReadOnlyCollection<BrokerTransaction> Entries { get; }

        /// <summary>
        /// Gets the collection of <see cref="BrokerTaxLot"/> for this instance, subject to the 
        /// value(s) of <see cref="TaxLotStatus"/> provided.
        /// </summary>
        /// <param name="taxLotStatus">The status of the tax lot to return.
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="BrokerTaxLot"/>.</returns>
        /// <exception cref="NotSupportedException">The value of passed to 
        /// <paramref name="taxLotStatus"/> is not valid for this method.</exception>
        IEnumerable<BrokerTaxLot> GetTaxLots(TaxLotStatus taxLotStatus);

        void UpdateTransactionCode(BrokerTransaction model, int newId);

        BrokerTransaction AddTransaction();

        void RevertRemoveTransaction(BrokerTransaction model);

        void RemoveTransaction(BrokerTransaction model);

    }
}