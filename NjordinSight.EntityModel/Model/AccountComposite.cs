using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordinSight.EntityModel
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

        [ForeignKey(nameof(AccountCompositeId))]
        [InverseProperty(nameof(AccountObject.AccountComposite))]
        public virtual AccountObject AccountCompositeNavigation { get; set; }
        [InverseProperty(nameof(AccountCompositeMember.AccountComposite))]
        public virtual ICollection<AccountCompositeMember> AccountCompositeMembers { get; set; }
    }
}
