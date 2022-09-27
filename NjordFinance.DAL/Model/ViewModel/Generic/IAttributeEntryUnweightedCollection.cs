using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel.Generic
{
    public interface IAttributeEntryUnweightedCollection<
        TParentEntity, TChildEntity, TGroupModel>
        : IAttributeEntryCollection<TParentEntity, TChildEntity, TGroupModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupModel : IAttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        IEnumerable<TChildEntity> CurrentEntries { get; }
    }
}
