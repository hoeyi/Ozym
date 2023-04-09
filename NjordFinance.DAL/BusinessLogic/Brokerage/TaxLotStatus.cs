using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.BusinessLogic.Brokerage
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
}
