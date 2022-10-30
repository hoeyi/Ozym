using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Model.Metadata;

namespace NjordFinance.Model
{
    [Table("BrokerTransaction", Schema = "FinanceApp")]
    [Index(nameof(AccountId), Name = "IX_BrokerTransaction_AccountID")]
    [Index(nameof(DepSecurityId), Name = "IX_BrokerTransaction_DepSecurityID")]
    [Index(nameof(SecurityId), Name = "IX_BrokerTransaction_SecurityID")]
    [Index(nameof(TaxLotId), Name = "IX_BrokerTransaction_TaxLotID")]
    [Index(nameof(TransactionCodeId), Name = "IX_BrokerTransaction_TransactionCodeID")]
    [Noun(
        Plural = nameof(ModelNoun.BrokerTransaction_Plural),
        PluralArticle = nameof(ModelNoun.BrokerTransaction_PluralArticle),
        Singular = nameof(ModelNoun.BrokerTransaction_Singular),
        SingularArticle = nameof(ModelNoun.BrokerTransaction_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class BrokerTransaction
    {
        public BrokerTransaction()
        {
            InverseTaxLot = new HashSet<BrokerTransaction>();
        }

        [Key]
        [Column("TransactionID")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_TransactionCodeID_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_TransactionCodeID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int TransactionId { get; set; }
        
        [Column("AccountID")]
        public int AccountId { get; set; }
        
        [Column("TransactionCodeID")]
        public int TransactionCodeId { get; set; }
        
        [Column(TypeName = "date")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_TradeDate_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_TradeDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime TradeDate { get; set; }
        
        [Column(TypeName = "date")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_SettleDate_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_SettleDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime? SettleDate { get; set; }
        
        [Column(TypeName = "date")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_AcquisitionDate_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_AcquisitionDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime? AcquisitionDate { get; set; }
        
        [Column("SecurityID")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_SecurityID_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_SecurityID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int SecurityId { get; set; }
        
        [Column(TypeName = "decimal(19, 6)")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_Quantity_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_Quantity_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal? Quantity { get; set; }
        
        [Column(TypeName = "decimal(19, 4)")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_Amount_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_Amount_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal Amount { get; set; }
        
        [Column(TypeName = "decimal(9, 4)")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_Fee_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_Fee_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal? Fee { get; set; }
        
        [Column(TypeName = "decimal(9, 4)")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_Withholding_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_Withholding_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal? Withholding { get; set; }

        [Column("DepSecurityID")]
        [Display(
            Name = nameof(ModelDisplay.BrokerTransaction_DepSecurityId_Name),
            Description = nameof(ModelDisplay.BrokerTransaction_DepSecurityID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int DepSecurityId { get; set; }
        
        [Column("TaxLotID")]
        public int? TaxLotId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("BrokerTransactions")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(DepSecurityId))]
        [InverseProperty("BrokerTransactionDepSecurities")]
        public virtual Security DepSecurity { get; set; }
        [ForeignKey(nameof(SecurityId))]
        [InverseProperty("BrokerTransactionSecurities")]
        public virtual Security Security { get; set; }
        [ForeignKey(nameof(TaxLotId))]
        [InverseProperty(nameof(InverseTaxLot))]
        public virtual BrokerTransaction TaxLot { get; set; }
        [ForeignKey(nameof(TransactionCodeId))]
        [InverseProperty(nameof(BrokerTransactionCode.BrokerTransactions))]
        public virtual BrokerTransactionCode TransactionCode { get; set; }
        [InverseProperty(nameof(TaxLot))]
        public virtual ICollection<BrokerTransaction> InverseTaxLot { get; set; }
    }
}
