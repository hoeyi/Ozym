using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("BankTransactionCode", Schema = "FinanceApp")]
    public partial class BankTransactionCode
    {
        public BankTransactionCode()
        {
            BankTransactionCodeAttributeMemberEntries = new HashSet<BankTransactionCodeAttributeMemberEntry>();
            BankTransactions = new HashSet<BankTransaction>();
        }

        [Key]
        [Column("TransactionCodeID")]
        public int TransactionCodeId { get; set; }
        [Required]
        [StringLength(12)]
        public string TransactionCode { get; set; }
        [Required]
        [StringLength(32)]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(BankTransactionCodeAttributeMemberEntry.TransactionCode))]
        public virtual ICollection<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(BankTransaction.TransactionCode))]
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
    }
}
