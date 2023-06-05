using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.ChangeTracking
{
    internal interface IChangeTracker<T>
    {
        ISet<T> Added();

        ISet<T> Removed();

        ISet<T> Updated();

        bool HasChanges { get; }
    }
}
