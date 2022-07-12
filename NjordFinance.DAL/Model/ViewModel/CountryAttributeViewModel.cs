using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    public class CountryAttributeViewModel :
        AttributeEntryViewModel<CountryAttributeMemberEntry, Country>
    {
        public CountryAttributeViewModel(Country country, DateTime effectiveDate)
            : base(country, effectiveDate)
        {
        }

        public override CountryAttributeMemberEntry ToEntryEntity() =>
            new()
            {
                AttributeMemberId = AttributeMemberId,
                CountryId = ParentObject.CountryId,
                EffectiveDate = EffectiveDate,
                Weight = 100M
            };
    }
}
