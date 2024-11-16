using MathNet.Numerics.Distributions;
using Ozym.BusinessLogic.Functions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.MethodParams
{
    /// <summary>
    /// Represents parameters that are bound to user controls and passed to 
    /// <see cref="IFinancialCalculator.FutureValueSimulation"/>.
    /// </summary>
    public record FutureValueSimulationInput
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
        [Range(1, 100)]
        public int Periods { get; set; } = 10;

        [Display(
            Name = nameof(DisplayString.FutureValueInput_PresentValue_Name),
            Description = nameof(DisplayString.FutureValueInput_PresentValue_Description),
            ResourceType = typeof(DisplayString))]
        public float PresentValue { get; set; } = 10000;

        [Display(
            Name = nameof(DisplayString.FutureValueInput_GrowthDistribution_Name),
            Description = nameof(DisplayString.FutureValueInput_GrowthDistribution_Description),
            ResourceType = typeof(DisplayString))]
        [Required]
        public IContinuousDistribution GrowthDistribution { get; set; }

        [Display(
            Name = nameof(DisplayString.FutureValueInput_DepositDistribution_Name),
            Description = nameof(DisplayString.FutureValueInput_DepositDistribution_Description),
            ResourceType = typeof(DisplayString))]
        [Required]
        public IContinuousDistribution DepositDistribution { get; set; }

        [Display(
            Name = nameof(DisplayString.FutureValueInput_PeriodType_Name),
            Description = nameof(DisplayString.FutureValueInput_PeriodType_Description),
            ResourceType = typeof(DisplayString))]
        public PeriodType PeriodType { get; set; } = PeriodType.Annual;

        [Display(
            Name = nameof(DisplayString.FutureValueSimulation_SimulationCount_Name),
            Description = nameof(DisplayString.FutureValueSimulation_SimulationCount_Description),
            ResourceType = typeof(DisplayString))]
        [Range(100, 1000)]
        public int SimulationCount { get; set; } = 100;
    }
}
