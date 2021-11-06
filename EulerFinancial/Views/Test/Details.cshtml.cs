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
    public class DetailsModel : PageModel
    {
        private readonly EulerFinancial.Data.Context.EulerFinancialContext _context;

        public DetailsModel(EulerFinancial.Data.Context.EulerFinancialContext context)
        {
            _context = context;
        }

        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = await _context.Accounts
                .Include(a => a.AccountCustodian)
                .Include(a => a.AccountNavigation).FirstOrDefaultAsync(m => m.AccountId == id);

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
