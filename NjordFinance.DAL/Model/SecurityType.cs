using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("SecurityType", Schema = "FinanceApp")]
    [Index(nameof(SecurityTypeName), Name = "UNI_SecurityType_SecurityTypeName", IsUnique = true)]
    public partial class SecurityType
    {
        public SecurityType()
        {
            Securities = new HashSet<Security>();
        }

        [Key]
        [Column("SecurityTypeID")]
        public int SecurityTypeId { get; set; }
        [Column("SecurityTypeGroupID")]
        public int SecurityTypeGroupId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string SecurityTypeName { get; set; } = null!;
        [Column(TypeName = "decimal(7, 4)")]
        public decimal ValuationFactor { get; set; }
        public bool CanHaveDerivative { get; set; }
        public bool CanHavePosition { get; set; }
        public byte DisplayOrder { get; set; }

        [ForeignKey(nameof(SecurityTypeGroupId))]
        [InverseProperty("SecurityTypes")]
        public virtual SecurityTypeGroup SecurityTypeGroup { get; set; } = null!;
        [InverseProperty(nameof(Security.SecurityType))]
        public virtual ICollection<Security> Securities { get; set; }
    }
}
