using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class SecuritySymbolMap
    {
        public int SymbolMapId { get; set; }
        public int AccountCustodianId { get; set; }
        public string CustodianSymbol { get; set; }
        public int SecuritySymbolId { get; set; }

        public virtual AccountCustodian AccountCustodian { get; set; }
        public virtual SecuritySymbol SecuritySymbol { get; set; }
    }
}
