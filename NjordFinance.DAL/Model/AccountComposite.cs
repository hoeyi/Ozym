using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("AccountComposite", Schema = "FinanceApp")]
    public partial class AccountComposite
    {
        public AccountComposite()
        {
            AccountCompositeMembers = new HashSet<AccountCompositeMember>();
        }

        [Key]
        [Column("AccountCompositeID")]
        public int AccountCompositeId { get; set; }
        public int DisplayOrder { get; set; }

        [ForeignKey(nameof(AccountCompositeId))]
        [InverseProperty(nameof(AccountObject.AccountComposite))]
        public virtual AccountObject AccountCompositeNavigation { get; set; } = null!;
        [InverseProperty(nameof(AccountCompositeMember.AccountComposite))]
        public virtual ICollection<AccountCompositeMember> AccountCompositeMembers { get; set; }
    }
}
