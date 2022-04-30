using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("AccountAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(EffectiveDate), nameof(AccountObjectId), nameof(AttributeMemberId), Name = "UNI_AccountAttributeMemberEntry_RowDef", IsUnique = true)]
    public partial class AccountAttributeMemberEntry
    {
        [Key]
        [Column("EntryID")]
        public int EntryId { get; set; }
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Column("AccountObjectID")]
        public int AccountObjectId { get; set; }
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AccountObjectId))]
        [InverseProperty("AccountAttributeMemberEntries")]
        public virtual AccountObject AccountObject { get; set; } = null!;
        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.AccountAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; } = null!;
    }
}
