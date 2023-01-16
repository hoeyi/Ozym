using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata;
using NjordFinance.Model;
using NjordFinance.Model.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.BusinessLogic
{
    /// <summary>
    /// Represents a single-line instructing the quantity to close against a <see cref="BrokerTaxLot"/> 
    /// record.
    /// </summary>
    public class AllocationInstruction
    {
        /// <summary>
        /// Gets the <see cref="BrokerTaxLot"/> to which this instruction applies.
        /// </summary>
        public BrokerTaxLot TaxLot { get; init; }

        /// <summary>
        /// Gets the quantity to of the <see cref="TaxLot"/> quantity to close.
        /// </summary>
        [Range(
            minimum: default, 
            maximum: double.MaxValue,
            ErrorMessageResourceName = nameof(ExceptionString.AllocationInstruction_Validation_ClosingQuantity),
            ErrorMessageResourceType = typeof(ExceptionString))]
        public decimal ClosingQuantity { get; set; }
    }

    [Display(
        Name = nameof(DisplayString.AllocationInstructionSet_Name),
        ResourceType = typeof(DisplayString))]
    /// <summary>
    /// Represents a collection of instructions closing against <see cref="BrokerTaxLot"/> records.
    /// </summary>
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
        /// Gets the <see cref="IList{T}"/> of <see cref="AllocationInstruction"/> records in this 
        /// table.
        /// </summary>
        public IList<AllocationInstruction> Instructions { get; init; }

        /// <summary>
        /// Gets the total quantity remaining to be closed. Calculated as the difference of the 
        /// <see cref="QuantityToClose"/> value and the sum of closing quantities from the 
        /// member <see cref="AllocationInstruction"/> records.
        /// </summary>
        [ExactValue(
            value: 0D,
            ErrorMessageResourceName = nameof(ExceptionString.AllocationInstructionTable_InstructionIsIncomplete),
            ErrorMessageResourceType = typeof(ExceptionString))]
        [Display(
            Name = nameof(DisplayString.AllocationInstructionSet_RemainingQuantity_Name),
            Description = nameof(DisplayString.AllocationInstructionSet_RemainingQuantity_Description),
            ResourceType = typeof(DisplayString))]
        public double RemainingTransactionQuantity =>
            (double)((Transaction.Quantity ?? default) - Instructions.Select(x => x.ClosingQuantity).Sum());
    }
}
