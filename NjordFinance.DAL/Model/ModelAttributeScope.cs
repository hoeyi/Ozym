using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("ModelAttributeScope", Schema = "EulerApp")]
    [Index(nameof(AttributeId), nameof(ScopeCode), Name = "UNI_ModelAttributeScope_AttributeID_ScopeCode", IsUnique = true)]
    public partial class ModelAttributeScope
    {
        [Key]
        [Column("AttributeScopeID")]
        public int AttributeScopeId { get; set; }
        [Column("AttributeID")]
        public int AttributeId { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string ScopeCode { get; set; } = null!;

        [ForeignKey(nameof(AttributeId))]
        [InverseProperty(nameof(ModelAttribute.ModelAttributeScopes))]
        public virtual ModelAttribute Attribute { get; set; } = null!;
    }
}
