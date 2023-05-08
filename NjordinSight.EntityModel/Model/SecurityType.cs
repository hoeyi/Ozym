using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.Metadata;

namespace NjordinSight.EntityModel
{
    [Table("SecurityType", Schema = "FinanceApp")]
    [Index(nameof(SecurityTypeGroupId), Name = "IX_SecurityType_SecurityTypeGroupID")]
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
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string SecurityTypeName { get; set; }
        [Column(TypeName = "decimal(7, 4)")]
        public decimal ValuationFactor { get; set; }
        public bool CanHaveDerivative { get; set; }
        public bool CanHavePosition { get; set; }
        public bool HeldInWallet { get; set; } = false;
        [ForeignKey(nameof(SecurityTypeGroupId))]
        [InverseProperty("SecurityTypes")]
        public virtual SecurityTypeGroup SecurityTypeGroup { get; set; }
        [ForeignKey(nameof(SecurityTypeId))]
        [InverseProperty(nameof(ModelAttributeMember.SecurityType))]
        public virtual ModelAttributeMember AttributeMemberNavigation { get; set; }
        [InverseProperty(nameof(Security.SecurityType))]
        public virtual ICollection<Security> Securities { get; set; }
    }
}
