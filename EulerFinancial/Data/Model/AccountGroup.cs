using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class AccountGroup
    {
        public AccountGroup()
        {
            AccountGroupMembers = new HashSet<AccountGroupMember>();
        }

        public int AccountGroupId { get; set; }
        public int DisplayOrder { get; set; }

        public virtual AccountObject AccountGroupNavigation { get; set; }
        public virtual ICollection<AccountGroupMember> AccountGroupMembers { get; set; }
    }
}
