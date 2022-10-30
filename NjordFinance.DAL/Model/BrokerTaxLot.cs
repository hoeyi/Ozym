using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model
{
    /// <summary>
    /// Represents a brokerage account tax lot.
    /// </summary>
    public record BrokerTaxLot
    {
        /// <summary>
        /// Gets the identifier of this tax lot, which is also the identifer of the transaction 
        /// that created it.
        /// </summary>
        public int TaxLotId { get; init; }

        /// <summary>
        /// Gets the account that holds this tax lot.
        /// </summary>
        public int AccountId { get; init; }

        /// <summary>
        /// Gets the date this tax lot was opened.
        /// </summary>
        public DateTime OpenDate { get; init; }

        /// <summary>
        /// Gets the quantity held in this tax lot.
        /// </summary>
        public decimal Quantity { get; init; }

        /// <summary>
        /// Gets the security held in this tax lot.
        /// </summary>
        public int SecurityId { get; init; }
    }
}
