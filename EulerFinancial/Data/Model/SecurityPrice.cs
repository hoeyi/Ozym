using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class SecurityPrice
    {
        public int PriceId { get; set; }
        public int SecurityId { get; set; }
        public DateTime PriceDate { get; set; }
        public decimal PriceClose { get; set; }
        public decimal? PriceOpen { get; set; }
        public decimal? PriceHigh { get; set; }
        public decimal? PriceLow { get; set; }
        public long? Volume { get; set; }

        public virtual Security Security { get; set; }
    }
}
