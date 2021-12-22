using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("AccountGroup", Schema = "EulerApp")]
    public partial class AccountGroup
    {
        public AccountGroup()
        {
            AccountGroupMembers = new HashSet<AccountGroupMember>();
        }

        [Key]
        [Column("AccountGroupID")]
        public int AccountGroupId { get; set; }
        public int DisplayOrder { get; set; }

        [ForeignKey(nameof(AccountGroupId))]
        [InverseProperty(nameof(AccountObject.AccountGroup))]
        public virtual AccountObject AccountGroupNavigation { get; set; }
        [InverseProperty(nameof(AccountGroupMember.AccountGroup))]
        public virtual ICollection<AccountGroupMember> AccountGroupMembers { get; set; }
    }
}
