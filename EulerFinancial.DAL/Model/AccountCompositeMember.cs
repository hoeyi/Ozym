using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("AccountCompositeMember", Schema = "EulerApp")]
    [Index(nameof(EntryDate), nameof(AccountId), nameof(AccountCompositeId), Name = "UNI_AccountCompositeMember_RowDef")]
    public partial class AccountCompositeMember
    {
        [Key]
        [Column("MemberID")]
        public int MemberId { get; set; }
        [Column("AccountCompositeID")]
        public int AccountCompositeId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column(TypeName = "date")]
        public DateTime EntryDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExitDate { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AccountCompositeMembers")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey(nameof(AccountCompositeId))]
        [InverseProperty("AccountCompositeMembers")]
        public virtual AccountComposite AccountComposite { get; set; } = null!;
    }
}
