﻿using Ozym.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozym.EntityModel
{
    [Table("ModelAttribute", Schema = "FinanceApp")]
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
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(ModelAttributeMember.Attribute))]
        public virtual ICollection<ModelAttributeMember> ModelAttributeMembers { get; set; }
        [InverseProperty(nameof(ModelAttributeScope.Attribute))]
        public virtual ICollection<ModelAttributeScope> ModelAttributeScopes { get; set; }
    }
}
