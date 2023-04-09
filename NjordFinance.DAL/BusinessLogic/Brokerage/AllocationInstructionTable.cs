using Ichosys.DataModel.Annotations;
using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NjordFinance.BusinessLogic.Brokerage
{
    /// <summary>
    /// Represents a collection of instructions closing against <see cref="BrokerTaxLot"/> records.
    /// </summary>
    [Display(
        Name = nameof(DisplayString.AllocationInstructionTable_Name),
        ResourceType = typeof(DisplayString))]
    public class AllocationInstructionTable
    {
        /// <summary>
        /// Gets the <see cref="BrokerTransaction" /> record representing the closing action for 
        /// which instruction is needed.
        /// </summary>
        public BrokerTransaction Transaction { get; init; }

        /// <summary>
        /// Gets the collection of <see cref="BrokerTaxLot" /> records to close against.
        /// </summary>
        public IReadOnlyCollection<BrokerTaxLot> AvailableTaxLots { get; init; }

        /// <summary>
        /// Gets the <see cref="IList{T}"/> of <see cref="AllocationInstructionRow"/> records in this 
        /// table.
        /// </summary>
        public IList<AllocationInstructionRow> Instructions { get; init; }

        /// <summary>
        /// Gets the total quantity remaining to be closed. Calculated as the difference of the 
        /// <see cref="QuantityToClose"/> value and the sum of closing quantities from the 
        /// member <see cref="AllocationInstructionRow"/> records.
        /// </summary>
        [ExactValue(
            value: 0D,
            ErrorMessageResourceName = nameof(ExceptionString.AllocationInstructionTable_InstructionIsIncomplete),
            ErrorMessageResourceType = typeof(ExceptionString))]
        [Display(
            Name = nameof(DisplayString.AllocationInstructionTable_RemainingQuantity_Name),
            Description = nameof(DisplayString.AllocationInstructionTable_RemainingQuantity_Description),
            ResourceType = typeof(DisplayString))]
        public double RemainingTransactionQuantity =>
            (double)((Transaction.Quantity ?? default) - Instructions.Select(x => x.ClosingQuantity).Sum());
    }
}
