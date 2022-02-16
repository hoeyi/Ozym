using EulerFinancial.Model;
using EulerFinancial.ModelService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Controllers
{
    /// <summary>
    /// A derived MVC controller for <see cref="Account"/> objects.
    /// </summary>
    public partial class AccountsController : ControllerBase, IAccountController
    {
        private readonly IAccountService accountService;
        private readonly ILogger logger;
        public AccountsController(IAccountService accountService, ILogger logger)
        {
            this.accountService = accountService;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<Account>> GetDefaultAsync()
        {
            return await accountService.GetDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<ActionResult<Account>> CreateAsync(Account model)
        {
            try
            {
                var account = await accountService.CreateAsync(model);
                
                return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
            }
            catch (DbUpdateException due)
            {
                logger.LogError(exception: due, message: due.Message);

                if (accountService.ModelExists(model?.AccountId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<ActionResult<Account>> ReadAsync(int? id)
        {
            var account = await accountService.ReadAsync(id);

            if (account is null)
            {
                return NotFound();
            }

            return account;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<Account>> UpdateAsync(int? id, Account model)
        {
            if (id != model.AccountId)
            {
                return BadRequest();
            }

            try
            {
                var updateTask = accountService.UpdateAsync(model);

                bool success = await updateTask;

                if (success) return model;
                else throw updateTask.Exception;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountService.ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        /// <inheritdoc/>
        public async Task<IActionResult> DeleteAsync(Account model)
        {
            if (!accountService.ModelExists(model))
            {
                return NotFound();
            }

            var deleteTask = accountService.DeleteAsync(model);

            var success = await deleteTask;

            if (success) return NoContent();
            else throw deleteTask.Exception;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<Account>>> SelectAllAsync()
        {
            return await accountService.SelectAllAsync();
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<Account>>> SelectWhereAysnc(
            Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            return await accountService.SelectWhereAysnc(predicate, maxCount);
        }
    }
}
