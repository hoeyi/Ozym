using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EulerFinancial.Model;

namespace EulerFinancial.Blazor.Views.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly EulerFinancial.Context.EulerFinancialContext _context;

        public CreateModel(EulerFinancial.Context.EulerFinancialContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountCustodianId"] = new SelectList(_context.AccountCustodians, "AccountCustodianId", "CustodianCode");
        ViewData["AccountId"] = new SelectList(_context.AccountObjects, "AccountObjectId", "AccountObjectCode");
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
