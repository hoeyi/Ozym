using EulerFinancial.Model;
using EulerFinancial.ModelService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.Controllers
{
    /// <summary>
    /// A derived MCV controller for <see cref="AccountWallet"/> objects.
    /// </summary>
    public partial class AccountWalletsController 
        : ControllerBase, IAccountWalletsController
    {
        private readonly IAccountWalletService walletService;
        private readonly ILogger logger;
        public AccountWalletsController(
            IAccountWalletService walletService,
            ILogger logger)
        {
            this.walletService = walletService;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IActionResult> Add(AccountWallet model)
        {
            IActionResult Add()
            {
                if(walletService.AddPendingSave(model))
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }

            var result = await Task.Run(() => Add());

            return result;
        }

        /// <inheritdoc/>
        public async Task<IActionResult> Delete(AccountWallet model)
        {
            IActionResult Delete()
            {
                if (!walletService.ModelExists(model))
                {
                    return BadRequest();
                }

                if (walletService.DeletePendingSave(model))
                    return Ok();
                else
                    return Conflict();
            }

            var result = await Task.Run(() => Delete());

            return result;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<AccountWallet>> GetDefault()
        {
            return await walletService.GetDefault();
        }

        /// <inheritdoc/>
        public IActionResult Initialize(int parentKey)
        {
            if (walletService.Initialize(parentKey))
                return Ok();
            else
                return Conflict();
        }

        /// <inheritdoc/>
        public async Task<ActionResult<int>> SaveChanges()
        {
            var result = await walletService.SaveChanges();

            return Ok(result);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<AccountWallet>>> SelectWhereAysnc(
            Expression<Func<AccountWallet, bool>> predicate, int maxCount = 0)
        {
            return await walletService.SelectWhereAysnc(predicate, maxCount);
        }
    }
}
