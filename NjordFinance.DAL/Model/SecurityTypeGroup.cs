using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("SecurityTypeGroup", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_SecurityTypeGroup_AttributeMemberID")]
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
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.SecurityTypeGroups))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [InverseProperty(nameof(SecurityType.SecurityTypeGroup))]
        public virtual ICollection<SecurityType> SecurityTypes { get; set; }
    }
}
