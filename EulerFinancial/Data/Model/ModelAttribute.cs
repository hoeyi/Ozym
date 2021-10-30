using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class ModelAttribute
    {
        public ModelAttribute()
        {
            ModelAttributeMembers = new HashSet<ModelAttributeMember>();
            ModelAttributeScopes = new HashSet<ModelAttributeScope>();
        }

        public int AttributeId { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<ModelAttributeMember> ModelAttributeMembers { get; set; }
        public virtual ICollection<ModelAttributeScope> ModelAttributeScopes { get; set; }
    }
}
