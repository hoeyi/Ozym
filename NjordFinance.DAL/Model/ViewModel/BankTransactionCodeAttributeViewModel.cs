using NjordFinance.Model.ViewModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.Model.ViewModel
{
    public class BankTransactionCodeAttributeViewModel
        : AttributeEntryViewModel<
            BankTransactionCode,
            BankTransactionCodeAttributeMemberEntry,
            BankTransactionCodeAttriubeEntryViewModel>
    {
        public BankTransactionCodeAttributeViewModel(BankTransactionCode transactionCode) 
            : base(
                  parentEntity: transactionCode,
                  groupConstructor: (parent, attriubte, date) =>
                  {
                      return new BankTransactionCodeAttriubeEntryViewModel(parent, attriubte, date);
                  },
                  groupingConverterFunc: (grouping, parent) =>
                  {
                      var firstEntry = grouping.Where(x => x.AttributeMember is not null).First();

                      return new(
                          parentEntity: parent,
                          modelAttribute: firstEntry.AttributeMember.Attribute,
                          effectiveDate: firstEntry.EffectiveDate);
                  },
                  groupingFunc: (entries) =>
                  {
                      return entries.GroupBy(e => (e.AttributeMember.AttributeId, e.EffectiveDate));
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.BankTransactionCodeAttributeMemberEntries;
                  })
        {
            // Check child entry records were included in the given model.
            if (transactionCode.BankTransactionCodeAttributeMemberEntries is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.BankTransactionCodeAttributeMemberEntries));

            // Check all child records have the ModelAttributeMember related record.
            if (transactionCode.BankTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (transactionCode.BankTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }
    }
}
