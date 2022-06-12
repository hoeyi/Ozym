using NjordFinance.Context;

namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Represents a shared <see cref="FinanceDbContext"/> space.
    /// </summary>
    internal interface ISharedContext
    {
        /// <summary>
        /// The shared context.
        /// </summary>
        FinanceDbContext Context { get; }
    }
}
