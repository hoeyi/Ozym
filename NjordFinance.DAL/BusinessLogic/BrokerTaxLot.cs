using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;

namespace NjordFinance.BusinessLogic
{
    /// <summary>
    /// Represents a tax lot held in a brokerage/investment account.
    /// </summary>
    public record BrokerTaxLot
    {
        /// <summary>
        /// Gets the unique identifer for this tax lot record. Matches the id of the opening 
        /// transaction id.
        /// </summary>
        public int TaxLotId { get; init; }

        /// <summary>
        /// Gets the id of the <see cref="Security"/> instance for this tax lot.
        /// </summary>
        public int SecurityId { get; init; }

        /// <summary>
        /// Gets the id of the <see cref="Account" /> instance holding this tax lot.
        /// </summary>
        public int AccountId { get; init; }
        
        /// <summary>
        /// Gets the original acquisition date of this tax lot.
        /// </summary>
        public DateTime AcquisitionDate { get; init; }

        /// <summary>
        /// Gets the original cost basis for this tax lot.
        /// </summary>
        public decimal CostBasis { get; init; }

        /// <summary>
        /// Gets the origianl quantity for this tax lot.
        /// </summary>
        public decimal Quantity { get; init; }

        /// <summary>
        /// Gets the original unit cost basis for this tax lot.
        /// </summary>
        public decimal UnitCostBasis => CostBasis / Quantity;

    }
}
