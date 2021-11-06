using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EulerFinancial.Data.Context;
using EulerFinancial.Data.Model;

namespace EulerFinancial.Views.Test
{
    public class IndexModel : PageModel
    {
        private readonly EulerFinancial.Data.Context.EulerFinancialContext _context;

        public IndexModel(EulerFinancial.Data.Context.EulerFinancialContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Accounts
                .Include(a => a.AccountCustodian)
                .Include(a => a.AccountNavigation).ToListAsync();
        }
    }
}
