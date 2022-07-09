using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("AccountCustodian", Schema = "FinanceApp")]
    public partial class AccountCustodian
    {
        public AccountCustodian()
        {
            Accounts = new HashSet<Account>();
            SecuritySymbolMaps = new HashSet<SecuritySymbolMap>();
        }

        [Key]
        [Column("AccountCustodianID")]
        public int AccountCustodianId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string CustodianCode { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(Account.AccountCustodian))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(SecuritySymbolMap.AccountCustodian))]
        public virtual ICollection<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
    }
}
