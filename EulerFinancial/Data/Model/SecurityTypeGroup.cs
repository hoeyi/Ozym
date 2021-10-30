using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class SecurityTypeGroup
    {
        public SecurityTypeGroup()
        {
            SecurityTypes = new HashSet<SecurityType>();
        }

        public int SecurityTypeGroupId { get; set; }
        public string SecurityTypeGroupName { get; set; }
        public byte DisplayOrder { get; set; }

        public virtual ICollection<SecurityType> SecurityTypes { get; set; }
    }
}
