using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.ChangeTracking
{
    /// <summary>
    /// Represents a single action taken on a stateful object.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Gets a string describing this command.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Executes this command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Reverts this command.
        /// </summary>
        void Undo();
    }
}
