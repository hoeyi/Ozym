﻿using Ozym.BusinessLogic.Functions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.MethodParams
{
    /// <summary>
    /// Represents parameters that are bound to user controls and passed to 
    /// <see cref="IFinancialCalculator.FutureValue"/>.
    /// </summary>
    public record FutureValueInput
    {
        [Display(
            Name = nameof(DisplayString.FutureValueInput_StartDate_Name),
            Description = nameof(DisplayString.FutureValueInput_StartDate_Description),
            ResourceType = typeof(DisplayString))]
        public DateTime StartDate { get; set; } = DateTime.UtcNow.Date;

        [Display(
            Name = nameof(DisplayString.FutureValueInput_Periods_Name),
            Description = nameof(DisplayString.FutureValueInput_Periods_Description),
            ResourceType = typeof(DisplayString))]
        [Range(0, 100)]
        public int Periods { get; set; } = 10;

        [Display(
            Name = nameof(DisplayString.FutureValueInput_PresentValue_Name),
            Description = nameof(DisplayString.FutureValueInput_PresentValue_Description),
            ResourceType = typeof(DisplayString))]
        public float PresentValue { get; set; } = 10000;

        [Display(
            Name = nameof(DisplayString.FutureValueInput_GrowthRate_Name),
            Description = nameof(DisplayString.FutureValueInput_GrowthRate_Description),
            ResourceType = typeof(DisplayString))]
        public float GrowthRate { get; set; } = 0.0500F;

        [Display(
            Name = nameof(DisplayString.FutureValueInput_RegularDeposit_Name),
            Description = nameof(DisplayString.FutureValueInput_RegularDeposit_Description),
            ResourceType = typeof(DisplayString))]
        public float RegularDeposit { get; set; } = 1000;

        [Display(
            Name = nameof(DisplayString.FutureValueInput_PeriodType_Name),
            Description = nameof(DisplayString.FutureValueInput_PeriodType_Description),
            ResourceType = typeof(DisplayString))]
        public PeriodType PeriodType { get; set; } = PeriodType.Annual;
    }
}
