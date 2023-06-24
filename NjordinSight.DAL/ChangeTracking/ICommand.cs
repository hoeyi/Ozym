using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.ChangeTracking
{
    /// <summary>
    /// Represents a single action action affecting the state of a <typeparamref name="T"/> object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommand<T>
    {
        /// <summary>
        /// Gets a string describing this command.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Executes this command.
        /// </summary>
        bool Execute();

        /// <summary>
        /// Reverts this command.
        /// </summary>
        bool Undo();

        /// <summary>
        /// The <typeparamref name="T"/> instance modified by the action this command represents.
        /// </summary>
        T TrackedItem { get; }
    }
}
