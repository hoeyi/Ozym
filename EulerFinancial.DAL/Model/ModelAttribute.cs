﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("ModelAttribute", Schema = "EulerApp")]
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
        [Required]
        [StringLength(32)]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(ModelAttributeMember.Attribute))]
        public virtual ICollection<ModelAttributeMember> ModelAttributeMembers { get; set; }
        [InverseProperty(nameof(ModelAttributeScope.Attribute))]
        public virtual ICollection<ModelAttributeScope> ModelAttributeScopes { get; set; }
    }
}
