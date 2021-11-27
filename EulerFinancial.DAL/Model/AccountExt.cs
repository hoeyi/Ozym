using System;
using System.ComponentModel.DataAnnotations.Schema;
using EulerFinancial.Model.Annotations;

namespace EulerFinancial.Model
{

    [Searchable(new string[]
    {
        nameof(AccountNumber),
        nameof(CloseDate),
        nameof(DisplayName),
        nameof(Description),
        nameof(StartDate),
    }
    )]
    public partial class Account
    {
        [NotMapped]
        public DateTime StartDate
        {
            get{ return AccountNavigation?.StartDate ?? default; }
        }

        [NotMapped]
        public DateTime? CloseDate
        {
            get{ return AccountNavigation?.CloseDate; }
        }

        [NotMapped]
        public string DisplayName
        {
            get{ return AccountNavigation?.ObjectDipslayName; }
        }

        [NotMapped]
        public string Description
        {
            get{ return AccountNavigation?.ObjectDescription; }
        }
    }
}
