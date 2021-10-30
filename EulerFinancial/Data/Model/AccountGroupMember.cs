using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class AccountGroupMember
    {
        public int MemberId { get; set; }
        public int AccountGroupId { get; set; }
        public int AccountId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual AccountGroup AccountGroup { get; set; }
    }
}
