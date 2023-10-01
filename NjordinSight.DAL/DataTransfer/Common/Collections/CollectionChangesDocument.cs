using NjordinSight.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NjordinSight.DataTransfer.Common.Collections
{
    /// <summary>
    /// Dto
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionChangesDocument<T>
    {
        [JsonConstructor]
        public CollectionChangesDocument()
        {
        }

        public CollectionChangesDocument(IEnumerable<(T, TrackingState)> collectionChanges)
        {
            var groupedEntries = collectionChanges.GroupBy(x => x.Item2, y => y.Item1);

            foreach(var group in groupedEntries)
            {
                Changes.Add(group.Key, group);
            }
        }

        /// <summary>
        /// Gets the collection of changes to apply.
        /// </summary>
        public IDictionary<TrackingState, IEnumerable<T>> Changes { get; set; } 
            = new Dictionary<TrackingState, IEnumerable<T>>();
    }
}
