using NjordFinance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
