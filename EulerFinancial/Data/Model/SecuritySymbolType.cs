using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class SecuritySymbolType
    {
        public SecuritySymbolType()
        {
            SecuritySymbols = new HashSet<SecuritySymbol>();
        }

        public int SymbolTypeId { get; set; }
        public string SymbolTypeName { get; set; }

        public virtual ICollection<SecuritySymbol> SecuritySymbols { get; set; }
    }
}
