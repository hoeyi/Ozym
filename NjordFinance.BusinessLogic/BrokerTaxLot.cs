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
        public decimal OriginalCostBasis { get; init; }

        /// <summary>
        /// Gets the origianl quantity for this tax lot.
        /// </summary>
        public decimal OriginalQuantity { get; init; }

        /// <summary>
        /// Gets the remaining unclosed quantity for this tax lot.
        /// </summary>
        public decimal UnclosedQuantity { get; init; }

        /// <summary>
        /// Gets the original cost basis less the effect of closing activity.
        /// </summary>
        public decimal? UnclosedCostBasis => UnitCostBasis * UnclosedQuantity;

        /// <summary>
        /// Gets the original unit cost basis for this tax lot. Returns null if 
        /// <see cref="OriginalQuantity"/> is zero.
        /// </summary>
        public decimal? UnitCostBasis => OriginalCostBasis / (OriginalQuantity == 0 ? null : OriginalQuantity);

    }
}
