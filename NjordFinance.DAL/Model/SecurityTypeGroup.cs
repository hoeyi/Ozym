using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("SecurityTypeGroup", Schema = "EulerApp")]
    [Index(nameof(SecurityTypeGroupName), Name = "UNI_SecurityTypeGroup_SecurityTypeGroupName", IsUnique = true)]
    public partial class SecurityTypeGroup
    {
        public SecurityTypeGroup()
        {
            SecurityTypes = new HashSet<SecurityType>();
        }

        [Key]
        [Column("SecurityTypeGroupID")]
        public int SecurityTypeGroupId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string SecurityTypeGroupName { get; set; } = null!;
        public byte DisplayOrder { get; set; }

        [InverseProperty(nameof(SecurityType.SecurityTypeGroup))]
        public virtual ICollection<SecurityType> SecurityTypes { get; set; }
    }
}
