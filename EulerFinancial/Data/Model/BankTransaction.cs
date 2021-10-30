using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class BankTransaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionCodeId { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public byte[] TransactionVersion { get; set; }

        public virtual Account Account { get; set; }
        public virtual BankTransactionCode TransactionCode { get; set; }
    }
}
