using System;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Web.Components
{
    /// <summary>
    /// Specifies indentifiers to indicate the return value of a dialog action.
    /// </summary>
    [Flags]
    public enum DialogResult
    {
        [Display(
            Name = nameof(Strings.DialogResult_None),
            ResourceType = typeof(Strings))]
        None = 1,

        [Display(
            Name = nameof(Strings.DialogResult_OK),
            ResourceType = typeof(Strings))]
        OK = 2,

        [Display(
            Name = nameof(Strings.DialogResult_Cancel),
            ResourceType = typeof(Strings))]
        Cancel = 4,

        [Display(
            Name = nameof(Strings.DialogResult_Abort),
            ResourceType = typeof(Strings))]
        Abort = 8,

        [Display(
            Name = nameof(Strings.DialogResult_Retry),
            ResourceType = typeof(Strings))]
        Retry = 16,

        [Display(
            Name = nameof(Strings.DialogResult_Ignore),
            ResourceType = typeof(Strings))]
        Ignore = 32,

        [Display(
            Name = nameof(Strings.DialogResult_Yes),
            ResourceType = typeof(Strings))]
        Yes = 64,

        [Display(
            Name = nameof(Strings.DialogResult_No),
            ResourceType = typeof(Strings))]
        No = 128,

        [Display(
            Name = nameof(Strings.DialogResult_TryAgain),
            ResourceType = typeof(Strings))]
        TryAgain = 256,

        [Display(
            Name = nameof(Strings.DialogResult_Continue),
            ResourceType = typeof(Strings))]
        Continue = 512,

        [Display(
            Name = nameof(Strings.DialogResult_Delete),
            ResourceType = typeof(Strings))]
        Delete = 1024
    }
}
