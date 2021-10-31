using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EulerFinancial.Data.Context;
using EulerFinancial.Data.Model;

namespace EulerFinancial.Controllers
{
    public class AccountsController : Controller
    {
        private readonly EulerFinancialContext _context;

        public AccountsController(EulerFinancialContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var eulerFinancialContext = _context.Accounts.Include(a => a.AccountCustodian).Include(a => a.AccountNavigation);
            return View(await eulerFinancialContext.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.AccountCustodian)
                .Include(a => a.AccountNavigation)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["AccountCustodianId"] = new SelectList(_context.AccountCustodians, "AccountCustodianId", "CustodianCode");
            ViewData["AccountId"] = new SelectList(_context.AccountObjects, "AccountObjectId", "AccountObjectCode");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,AccountNumber,DisplayOrder,AccountCustodianId,BooksClosedDate,IsComplianceTradable,HasWallet,HasBankTransaction,HasBrokerTransaction")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountCustodianId"] = new SelectList(_context.AccountCustodians, "AccountCustodianId", "CustodianCode", account.AccountCustodianId);
            ViewData["AccountId"] = new SelectList(_context.AccountObjects, "AccountObjectId", "AccountObjectCode", account.AccountId);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["AccountCustodianId"] = new SelectList(_context.AccountCustodians, "AccountCustodianId", "CustodianCode", account.AccountCustodianId);
            ViewData["AccountId"] = new SelectList(_context.AccountObjects, "AccountObjectId", "AccountObjectCode", account.AccountId);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,AccountNumber,DisplayOrder,AccountCustodianId,BooksClosedDate,IsComplianceTradable,HasWallet,HasBankTransaction,HasBrokerTransaction")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountCustodianId"] = new SelectList(_context.AccountCustodians, "AccountCustodianId", "CustodianCode", account.AccountCustodianId);
            ViewData["AccountId"] = new SelectList(_context.AccountObjects, "AccountObjectId", "AccountObjectCode", account.AccountId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.AccountCustodian)
                .Include(a => a.AccountNavigation)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
