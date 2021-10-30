using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class SecurityType
    {
        public SecurityType()
        {
            Securities = new HashSet<Security>();
        }

        public int SecurityTypeId { get; set; }
        public int SecurityTypeGroupId { get; set; }
        public string SecurityTypeName { get; set; }
        public decimal ValuationFactor { get; set; }
        public bool CanHaveDerivative { get; set; }
        public bool CanHavePosition { get; set; }
        public byte DisplayOrder { get; set; }

        public virtual SecurityTypeGroup SecurityTypeGroup { get; set; }
        public virtual ICollection<Security> Securities { get; set; }
    }
}
