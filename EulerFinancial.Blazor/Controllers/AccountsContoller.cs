﻿using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EulerFinancial.Model;
using EulerFinancial.Controllers;
using EulerFinancial.ModelService;
using EulerFinancial.Resources;

namespace EulerFinancial.Blazor.Controllers
{
    /// <summary>
    /// A derived MVC controller for <see cref="Account"/> objects.
    /// </summary>
    public partial class AccountsController : ControllerBase, IController<Account>
    {
        private readonly IModelService<Account> accountService;
        private readonly ILogger logger;
        public AccountsController(IModelService<Account> accountService, ILogger logger)
        {
            this.accountService = accountService;
            this.logger = logger;

            this.logger.LogInformation(
                message: DebugMessage.Controller_Created, nameof(AccountsController));
        }

        /// <inheritdoc/>
        public async Task<Account> GetDefault()
        {
            return await accountService.GetDefault();

        }

        /// <inheritdoc/>
        public async Task<ActionResult<Account>> CreateAsync(Account model)
        {
            try
            {
                var account = await accountService.CreateAsync(model);

                return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
            }
            catch (DbUpdateException)
            {
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

            if(account is null)
            {
                return NotFound();
            }

            return account;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<Account>> UpdateAsync(int? id, Account model)
        {
            if(id != model.AccountId)
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
            catch(DbUpdateConcurrencyException)
            {
                if(!accountService.ModelExists(id))
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
            if(!accountService.ModelExists(model))
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
        public async Task<ActionResult<Account>> SelectOneAsync(Expression<Func<Account, bool>> predicate)
        {
            var account = await accountService.SelectOneAsync(predicate: predicate);

            if(account is null)
            {
                return NotFound();
            }

            return account;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<Account>>> SelectWhereAysnc(
            Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            return await accountService.SelectWhereAysnc(predicate, maxCount);
        }
    }
}
