using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.BusinessLogic
{
    public record AllocationInstruction
    {
        public BrokerTaxLot TaxLot { get; init; }

        public decimal ClosingQuantity { get; init; }
    }
}
