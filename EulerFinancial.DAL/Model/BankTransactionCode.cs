using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("BankTransactionCode", Schema = "EulerApp")]
    [Index(nameof(DisplayName), Name = "UNI_BankTransactionCode_DisplayName", IsUnique = true)]
    [Index(nameof(TransactionCode), Name = "UNI_BankTransactionCode_TransactionCode", IsUnique = true)]
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
        [StringLength(16)]
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
