using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class MarketIndexPrice
    {
        public int IndexPriceId { get; set; }
        public int MarketIndexId { get; set; }
        public DateTime PriceDate { get; set; }
        public string PriceCode { get; set; }
        public decimal Price { get; set; }

        public virtual MarketIndex MarketIndex { get; set; }
    }
}
