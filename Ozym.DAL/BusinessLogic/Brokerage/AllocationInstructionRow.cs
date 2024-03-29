﻿using Ichosys.DataModel.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ozym.BusinessLogic.Brokerage
{
    /// <summary>
    /// Represents a single-line instructing the quantity to close against a <see cref="BrokerTaxLot"/> 
    /// record.
    /// </summary>

    [Noun(
        Plural = nameof(DisplayString.AllocationInstructionRow_Noun_Plural),
        PluralArticle = nameof(DisplayString.AllocationInstructionRow_Noun_PluralArticle),
        Singular = nameof(DisplayString.AllocationInstructionRow_Noun_Singular),
        SingularArticle = nameof(DisplayString.AllocationInstructionRow_Noun_SingularArticle),
        ResourceType = typeof(DisplayString))]
    public class AllocationInstructionRow
    {
        /// <summary>
        /// Gets the <see cref="BrokerTaxLot"/> to which this instruction applies.
        /// </summary>
        public BrokerTaxLot TaxLot { get; init; }

        /// <summary>
        /// Gets the quantity to of the <see cref="TaxLot"/> quantity to close.
        /// </summary>

        [Display(
            Name = nameof(DisplayString.AllocationInstructionRow_ClosingQuantity_Name),
            Description = nameof(DisplayString.AllocationInstructionRow_ClosingQuantity_Description),
            ResourceType = typeof(DisplayString))]
        [Range(
            minimum: default,
            maximum: double.MaxValue,
            ErrorMessageResourceName = nameof(ExceptionString.AllocationInstruction_Validation_ClosingQuantity),
            ErrorMessageResourceType = typeof(ExceptionString))]
        public decimal ClosingQuantity { get; set; }
    }
}
