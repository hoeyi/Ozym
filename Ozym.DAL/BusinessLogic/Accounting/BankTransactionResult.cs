using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.BusinessLogic.Accounting
{
    /// <summary>
    /// Represents the result of the routine: <b>pReportBankTransactions</b>.
    /// </summary>
    public record BankTransactionResult
    {
        /// <summary>
        /// Gets or sets account identifier.
        /// </summary>
        public int AccountId { get; init; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_AccountName_Name),
            Description = nameof(DisplayString.BankTransactionResult_AccountName_Description),
            ResourceType = typeof(DisplayString))]
        public string AccountName { get; init; }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_TransactionDate_Name),
            Description = nameof(DisplayString.BankTransactionResult_TransactionDate_Description),
            ResourceType = typeof(DisplayString))]
        public DateTime TransactionDate { get; init; }

        /// <summary>
        /// Gets or sets the code of the transaction.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_TransactionCode_Name),
            Description = nameof(DisplayString.BankTransactionResult_TransactionCode_Description),
            ResourceType = typeof(DisplayString))]
        public string TransactionCode { get; init; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_Amount_Name),
            Description = nameof(DisplayString.BankTransactionResult_Amount_Description),
            ResourceType = typeof(DisplayString))]
        public decimal Amount { get; init; }

        /// <summary>
        /// Gets or sets the comment for the transaction.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_Comment_Name),
            Description = nameof(DisplayString.BankTransactionResult_Comment_Description),
            ResourceType = typeof(DisplayString))]
        public string Comment { get; init; }

        /// <summary>
        /// Gets or sets the name of the first attribute.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_Attribute1Name_Name),
            Description = nameof(DisplayString.BankTransactionResult_Attribute1Name_Description),
            ResourceType = typeof(DisplayString))]
        public string Attribute1Name { get; init; }

        /// <summary>
        /// Gets or sets the value of the first attribute.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_Attribute1Value_Name),
            Description = nameof(DisplayString.BankTransactionResult_Attribute1Value_Description),
            ResourceType = typeof(DisplayString))]
        public string Attribute1Value { get; init; }

        /// <summary>
        /// Gets or sets the name of the second attribute.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_Attribute2Name_Name),
            Description = nameof(DisplayString.BankTransactionResult_Attribute2Name_Description),
            ResourceType = typeof(DisplayString))]
        public string Attribute2Name { get; init; }

        /// <summary>
        /// Gets or sets the value of the second attribute.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.BankTransactionResult_Attribute2Value_Name),
            Description = nameof(DisplayString.BankTransactionResult_Attribute2Value_Description),
            ResourceType = typeof(DisplayString))]
        public string Attribute2Value { get; init; }
    }
}
