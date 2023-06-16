using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.BusinessLogic.MarketFeed
{
    /// <summary>
    /// Represents a market quote for an exchange-traded security or an index.
    /// </summary>
    public record Quote
    {
        /// <summary>
        /// Gets or sets the exchange identifier of the security/index.
        /// </summary>
        public string Symbol { get; init; }

        /// <summary>
        /// Gets or sets the description of the security/index.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Gets or sets the last price observed.
        /// </summary>
        public double LastPrice { get; set; }

        /// <summary>
        /// Gets or sets the signed change from the previous quote.
        /// </summary>
        public double Change { get; set; }

        /// <summary>
        /// Gets the signed percent change from the previous quote.
        /// </summary>
        public double PercentChange => Change / (LastPrice - Change) * 100.0;
    }
}
