using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.DataTransfer.MethodParams
{
    public record BankTransactionInput
    {
        [Display(
            Name = nameof(DisplayString.BankTransactionInput_AccountId_Name),
            Description = nameof(DisplayString.BankTransactionInput_AccountId_Description),
            ResourceType = typeof(DisplayString))]
        public int AccountId { get; set; }

        [Display(
            Name = nameof(DisplayString.BankTransactionInput_AsOfDate_Name),
            Description = nameof(DisplayString.BankTransactionInput_AsOfDate_Description),
            ResourceType = typeof(DisplayString))]
        public DateTime AsOfDate { get; set; } = DateTime.Now;

        [Display(
            Name = nameof(DisplayString.BankTransactionInput_DayOffset_Name),
            Description = nameof(DisplayString.BankTransactionInput_DayOffset_Description),
            ResourceType = typeof(DisplayString))]
        [Range(0, 365)]
        public int DayOffset { get; set; } = 30;

        [Display(
            Name = nameof(DisplayString.BankTransactionInput_Attribute1_Name),
            Description = nameof(DisplayString.BankTransactionInput_Attribute1_Description),
            ResourceType = typeof(DisplayString))]
        public int? AttributeId1 { get; set; }

        [Display(
            Name = nameof(DisplayString.BankTransactionInput_Attribute2_Name),
            Description = nameof(DisplayString.BankTransactionInput_Attribute2_Description),
            ResourceType = typeof(DisplayString))]
        public int? AttributeId2 { get; set; }
    }
}
