using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class SecurityExchange
    {
        public SecurityExchange()
        {
            Securities = new HashSet<Security>();
        }

        public int ExchangeId { get; set; }
        public string ExchangeCode { get; set; }
        public string ExchangeDescription { get; set; }

        public virtual ICollection<Security> Securities { get; set; }
    }
}
