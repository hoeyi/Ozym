using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using NjordFinance.EntityModel.Metadata;

namespace NjordFinance.EntityModel
{
    [Table("BrokerTransactionCodeAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_BrokerTransactionCodeAttributeMemberEntry_AttributeMemberID")]
    [Index(nameof(TransactionCodeId), Name = "IX_BrokerTransactionCodeAttributeMemberEntry_TransactionCodeID")]
    [Noun(
        Plural = nameof(ModelNoun.BrokerTransactionCodeAttributeMemberEntry_Plural),
        PluralArticle = nameof(ModelNoun.BrokerTransactionCodeAttributeMemberEntry_PluralArticle),
        Singular = nameof(ModelNoun.BrokerTransactionCodeAttributeMemberEntry_Singular),
        SingularArticle = nameof(ModelNoun.BrokerTransactionCodeAttributeMemberEntry_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class BrokerTransactionCodeAttributeMemberEntry
    {
        [Key]
        [Column("AttributeMemberID", Order = 0)]
        public int AttributeMemberId { get; set; }
        [Key]
        [Column("TransactionCodeID", Order = 1)]
        public int TransactionCodeId { get; set; }
        [Key]
        [Column(TypeName = "date", Order = 2)]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.BrokerTransactionCodeAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [ForeignKey(nameof(TransactionCodeId))]
        [InverseProperty(nameof(BrokerTransactionCode.BrokerTransactionCodeAttributeMemberEntries))]
        public virtual BrokerTransactionCode TransactionCode { get; set; }
    }
}
