using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel.Generic
{
    public abstract partial class AttributeEntryUnweightedCollection<
        TParentEntity, TChildEntity, TGroupViewModel, TGroupKey> :
        AttributeEntryCollection<TParentEntity, TChildEntity, TGroupViewModel, TGroupKey>,
        IAttributeEntryUnweightedCollection<TParentEntity, TChildEntity, TGroupViewModel>
        where TParentEntity : class, new()
        where TChildEntity : class, new()
        where TGroupViewModel : IAttributeEntryGrouping<TParentEntity, TChildEntity>
    {
        private readonly Func<TChildEntity, bool> _currencyPredicate;
        protected AttributeEntryUnweightedCollection(
            TParentEntity parentEntity, 
            Func<TParentEntity, TGroupKey, TGroupViewModel> groupConstructor, 
            Func<IGrouping<TGroupKey, TChildEntity>, TParentEntity, TGroupViewModel> groupConverter, 
            Func<IEnumerable<TChildEntity>, IEnumerable<IGrouping<TGroupKey, TChildEntity>>> groupingFunc, 
            Func<TParentEntity, IEnumerable<TChildEntity>> entryMemberSelector,
            Func<TChildEntity, bool> currencyPredicate) 
            : base(parentEntity, groupConstructor, groupConverter, groupingFunc, entryMemberSelector)
        {
            if (currencyPredicate is null)
                throw new ArgumentNullException(paramName: nameof(currencyPredicate));

            _currencyPredicate = currencyPredicate;
        }

        public IEnumerable<TChildEntity> CurrentEntries => Entries.Where(_currencyPredicate);
    }
}
