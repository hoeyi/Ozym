using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;

namespace NjordFinance.Context.Configuration
{
    /// <summary>
    /// Represents the seed data for test versions of transaction data in <see cref="FinanceDbContext"/>.
    /// <list type="bullet">Includes test models for the following:
    /// <item><see cref="BankTransactionCode"/></item>
    /// <item><see cref="BankTransaction"/></item>
    /// <item><see cref="BrokerTransactionCode"/></item>
    /// <item><see cref="BrokerTransaction"/></item>
    /// </list>
    /// </summary>
    internal class TestTransactionDataModel
    {
        /// <summary>
        /// Creates a new instance of <see cref="TestTransactionDataModel"/>.
        /// </summary>
        public TestTransactionDataModel()
        {
        }
        /// <summary>
        /// Gets the <see cref="BankTransaction"/> test models.
        /// </summary>
        public BankTransaction[] BankTransactions => throw new NotImplementedException();
        
        /// <summary>
        /// Gets the <see cref="BankTransactionCode"/> test models.
        /// </summary>
        public BankTransactionCode[] BankTransactionCodes { get; } =
        {
            new() { TransactionCode = "401k", DisplayName = "401k Contribution" },
            new() { TransactionCode = "auto", DisplayName = "Automotive" },
            new() { TransactionCode = "balance", DisplayName = "Initial Balance" },
            new() { TransactionCode = "salary", DisplayName = "Salary/Wage" },
            new() { TransactionCode = "statetax", DisplayName = "State Tax Paid" },
            new() { TransactionCode = "timeoff", DisplayName = "Unused Paid Time-Off" },
            new() { TransactionCode = "travel", DisplayName = "Travel" },
        };

        /// <summary>
        /// Gets the <see cref="BrokerTransaction"/> test models.
        /// </summary>
        public BrokerTransaction[] BrokerTransactions => throw new NotImplementedException();
    }
}
