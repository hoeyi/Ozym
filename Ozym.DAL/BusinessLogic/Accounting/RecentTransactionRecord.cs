using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.BusinessLogic.Accounting
{
    public record RecentTransactionRecord
    {
        public int AccountId { get; init; }
        public string AccountName { get; init; }

        public DateTime TransactionDate { get; init; }

        public decimal Amount { get; init; }

        public string Comment { get; init; }

        public string Category { get; init; }
    }
}
