using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("AccountCustodian", Schema = "FinanceApp")]
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
        [StringLength(16)]
        [Unicode(false)]
        public string CustodianCode { get; set; } = null!;
        [StringLength(72)]
        [Unicode(false)]
        public string DisplayName { get; set; } = null!;

        [InverseProperty(nameof(Account.AccountCustodian))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(SecuritySymbolMap.AccountCustodian))]
        public virtual ICollection<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
    }
}
