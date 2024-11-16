using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.BusinessLogic.Accounting
{
    /// <summary>
    /// Represents the account balance result.
    /// </summary>
    public record AccountBalanceResult
    {
        /// <summary>
        /// Gets or sets the account ID.
        /// </summary>
        public int AccountId { get; init; }

        /// <summary>
        /// Gets or sets the display name of the account.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.AccountBalanceResult_DisplayName_Name),
            Description = nameof(DisplayString.AccountBalanceResult_DisplayName_Description),
            ResourceType = typeof(DisplayString))]
        public string DisplayName { get; init; }

        /// <summary>
        /// Gets or sets the balance of the account.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.AccountBalanceResult_Balance_Name),
            Description = nameof(DisplayString.AccountBalanceResult_Balance_Description),
            ResourceType = typeof(DisplayString))]
        public double? Balance { get; init; }

        /// <summary>
        /// Gets or sets the date of the account balance.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.AccountBalanceResult_AsOfDate_Name),
            Description = nameof(DisplayString.AccountBalanceResult_AsOfDate_Description),
            ResourceType = typeof(DisplayString))]
        public DateTime? AsOfDate { get; init; }
    }
}
