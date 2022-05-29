using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("BrokerTransactionCode", Schema = "FinanceApp")]
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
        public short CashEffect { get; set; }
        public short ContributionWithdrawalEffect { get; set; }
        public short QuantityEffect { get; set; }

        [InverseProperty(nameof(BrokerTransactionCodeAttributeMemberEntry.TransactionCode))]
        public virtual ICollection<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(BrokerTransaction.TransactionCode))]
        public virtual ICollection<BrokerTransaction> BrokerTransactions { get; set; }
    }
}
