using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("AccountCustodian", Schema = "EulerApp")]
    [Index(nameof(CustodianCode), Name = "UNI_AccountCustodian_CustodianCode", IsUnique = true)]
    [Index(nameof(DisplayName), Name = "UNI_AccountCustodian_DisplayName", IsUnique = true)]
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
        [Required]
        [StringLength(16)]
        public string CustodianCode { get; set; }
        [Required]
        [StringLength(72)]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(Account.AccountCustodian))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(SecuritySymbolMap.AccountCustodian))]
        public virtual ICollection<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
    }
}
