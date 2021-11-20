using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
