using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.ChangeTracking
{
    internal interface IChangeTracker<T>
    {
        IEnumerable<T> Added();

        IEnumerable<T> Removed();

        IEnumerable<T> Updated();

        bool HasChanges { get; }
    }
}
