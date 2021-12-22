using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("BrokerTransactionCode", Schema = "EulerApp")]
    [Index(nameof(DisplayName), Name = "UNI_BrokerTransactionCode_DisplayName", IsUnique = true)]
    [Index(nameof(TransactionCode), Name = "UNI_BrokerTransactionCode_TransactionCode", IsUnique = true)]
    public partial class BrokerTransactionCode
    {
        public BrokerTransactionCode()
        {
            BrokerTransactionCodeAttributeMemberEntries = new HashSet<BrokerTransactionCodeAttributeMemberEntry>();
            BrokerTransactions = new HashSet<BrokerTransaction>();
        }

        [Key]
        [Column("TransactionCodeID")]
        public int TransactionCodeId { get; set; }
        [Required]
        [StringLength(3)]
        public string TransactionCode { get; set; }
        [Required]
        [StringLength(32)]
        public string DisplayName { get; set; }
        public byte CashEffect { get; set; }
        public byte ContributionWithdrawalEffect { get; set; }
        public byte QuantityEffect { get; set; }

        [InverseProperty(nameof(BrokerTransactionCodeAttributeMemberEntry.TransactionCode))]
        public virtual ICollection<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(BrokerTransaction.TransactionCode))]
        public virtual ICollection<BrokerTransaction> BrokerTransactions { get; set; }
    }
}
