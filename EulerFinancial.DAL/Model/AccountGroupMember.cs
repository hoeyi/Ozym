using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("AccountGroupMember", Schema = "EulerApp")]
    [Index(nameof(EntryDate), nameof(AccountId), nameof(AccountGroupId), Name = "UNI_AccountGroupMember_RowDef")]
    public partial class AccountGroupMember
    {
        [Key]
        [Column("MemberID")]
        public int MemberId { get; set; }
        [Column("AccountGroupID")]
        public int AccountGroupId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column(TypeName = "date")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExitDate { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AccountGroupMembers")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(AccountGroupId))]
        [InverseProperty("AccountGroupMembers")]
        public virtual AccountGroup AccountGroup { get; set; }
    }
}
