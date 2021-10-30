using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class ModelAttributeScope
    {
        public int AttributeScopeId { get; set; }
        public int AttributeId { get; set; }
        public string ScopeCode { get; set; }

        public virtual ModelAttribute Attribute { get; set; }
    }
}
