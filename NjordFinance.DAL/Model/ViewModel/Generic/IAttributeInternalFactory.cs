using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel.Generic
{
    internal interface IAttributeInternalFactory
        <TParentEntity, TGroupKey, TChildEntity, TGroupViewModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupViewModel : IAttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        TParentEntity ParentEntity { get; }

        TGroupViewModel ConstructGroup(TParentEntity parentEntity, TGroupKey groupKey);

        TGroupViewModel ConvertGroup(
            TParentEntity parentEntity, IGrouping<TGroupKey, TChildEntity> grouping);

        IEnumerable<IGrouping<TGroupKey, TChildEntity>> GroupEntries(
            IEnumerable<TChildEntity> entries);



    }
}
