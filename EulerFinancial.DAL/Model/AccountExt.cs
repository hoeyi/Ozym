using System;

namespace EulerFinancial.Model
{
    public partial class Account
    {
        public DateTime StartDate
        {
            get{ return AccountNavigation?.StartDate ?? default; }
        }
    }
}
