using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.EntityModel.RoutineTypes
{
    /// <summary>
    /// Represents the result of the routine: <b>pReportBankTransactions</b>.
    /// </summary>
    [NotMapped]
    public record ReportBankTransaction
    {
        /// <summary>
        /// Gets or sets account identifier.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the code of the transaction.
        /// </summary>
        public string TransactionCode { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the comment for the transaction.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the name of the first attribute.
        /// </summary>
        public string Attribute1Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the first attribute.
        /// </summary>
        public string Attribute1Value { get; set; }

        /// <summary>
        /// Gets or sets the name of the second attribute.
        /// </summary>
        public string Attribute2Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the second attribute.
        /// </summary>
        public string Attribute2Value { get; set; }
    }
}
