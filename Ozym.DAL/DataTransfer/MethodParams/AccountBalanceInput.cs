using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.DataTransfer.MethodParams
{
    public record AccountBalanceInput
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
    }
}
