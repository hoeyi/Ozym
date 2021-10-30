using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class MarketIndex
    {
        public MarketIndex()
        {
            MarketIndexPrices = new HashSet<MarketIndexPrice>();
        }

        public int IndexId { get; set; }
        public string IndexCode { get; set; }
        public string IndexDescription { get; set; }

        public virtual ICollection<MarketIndexPrice> MarketIndexPrices { get; set; }
    }
}
