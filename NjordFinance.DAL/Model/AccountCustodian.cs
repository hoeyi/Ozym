using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        [Required]
        [StringLength(32)]
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
