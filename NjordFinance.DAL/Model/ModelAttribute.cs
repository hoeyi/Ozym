using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("ModelAttribute", Schema = "FinanceApp")]
    [Index(nameof(DisplayName), Name = "UNI_ModelAttribute_DisplayName", IsUnique = true)]
    public partial class ModelAttribute
    {
        public ModelAttribute()
        {
            ModelAttributeMembers = new HashSet<ModelAttributeMember>();
            ModelAttributeScopes = new HashSet<ModelAttributeScope>();
        }

        [Key]
        [Column("AttributeID")]
        public int AttributeId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string DisplayName { get; set; } = null!;

        [InverseProperty(nameof(ModelAttributeMember.Attribute))]
        public virtual ICollection<ModelAttributeMember> ModelAttributeMembers { get; set; }
        [InverseProperty(nameof(ModelAttributeScope.Attribute))]
        public virtual ICollection<ModelAttributeScope> ModelAttributeScopes { get; set; }
    }
}
