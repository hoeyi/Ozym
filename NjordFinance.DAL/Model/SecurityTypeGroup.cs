using System.Collections.Generic;
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
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
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
