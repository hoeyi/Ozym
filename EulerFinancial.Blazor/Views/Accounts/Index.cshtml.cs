using EulerFinancial.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EulerFinancial.Blazor.Views.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly EulerFinancial.Context.EulerFinancialContext _context;

        public IndexModel(EulerFinancial.Context.EulerFinancialContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get; set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Accounts
                .Include(a => a.AccountCustodian)
                .Include(a => a.AccountNavigation).ToListAsync();
        }
    }
}
