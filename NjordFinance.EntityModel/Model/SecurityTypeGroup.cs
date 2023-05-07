using NjordFinance.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.EntityModel
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
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string SecurityTypeGroupName { get; set; }
        public bool Transactable { get; set; } = true;
        public bool DepositSource { get; set; } = false;
        [ForeignKey(nameof(SecurityTypeGroupId))]
        [InverseProperty(nameof(ModelAttributeMember.SecurityTypeGroup))]
        public virtual ModelAttributeMember AttributeMemberNavigation { get; set; }
        [InverseProperty(nameof(SecurityType.SecurityTypeGroup))]
        public virtual ICollection<SecurityType> SecurityTypes { get; set; }
    }
}
