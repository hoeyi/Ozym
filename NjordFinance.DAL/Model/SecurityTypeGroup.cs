﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("SecurityTypeGroup", Schema = "FinanceApp")]
    public partial class SecurityTypeGroup
    {
        public SecurityTypeGroup()
        {
            SecurityTypes = new HashSet<SecurityType>();
        }

        [Key]
        [Column("SecurityTypeGroupID")]
        public int SecurityTypeGroupId { get; set; }
        [Required]
        [StringLength(72)]
        public string SecurityTypeGroupName { get; set; }

        [ForeignKey(nameof(SecurityTypeGroupId))]
        [InverseProperty(nameof(ModelAttributeMember.SecurityTypeGroup))]
        public virtual ModelAttributeMember AttributeMemberNavigation { get; set; }
        [InverseProperty(nameof(SecurityType.SecurityTypeGroup))]
        public virtual ICollection<SecurityType> SecurityTypes { get; set; }
    }
}
