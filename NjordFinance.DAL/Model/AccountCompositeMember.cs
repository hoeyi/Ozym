using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("AccountCompositeMember", Schema = "FinanceApp")]
    [Index(nameof(AccountCompositeId), Name = "IX_AccountCompositeMember_AccountCompositeID")]
    [Index(nameof(AccountId), Name = "IX_AccountCompositeMember_AccountID")]
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
        public int DisplayOrder { get; set; }
        [StringLength(72)]
        public string Comment { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AccountCompositeMembers")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(AccountCompositeId))]
        [InverseProperty("AccountCompositeMembers")]
        public virtual AccountComposite AccountComposite { get; set; }
    }
}
