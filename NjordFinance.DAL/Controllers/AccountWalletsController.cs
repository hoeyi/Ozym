using NjordFinance.Model;
using NjordFinance.ModelService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.Exceptions;
using NjordFinance.Logging;

namespace NjordFinance.Controllers
{
    /// <summary>
    /// A derived MCV controller for <see cref="AccountWallet"/> objects.
    /// </summary>
    public partial class AccountWalletsController 
        : ControllerBase, IBatchController<AccountWallet>
    {
        private readonly IBatchModelService<AccountWallet> walletService;
        private readonly ILogger logger;
        public AccountWalletsController(
            IBatchModelService<AccountWallet> walletService,
            ILogger logger)
        {
            this.walletService = walletService;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IActionResult> AddAsync(AccountWallet model)
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
        public async Task<IActionResult> DeleteAsync(AccountWallet model)
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
        public async Task<ActionResult<AccountWallet>> GetDefaultAsync()
        {
            return await walletService.GetDefault();
        }

        /// <inheritdoc/>
        public IActionResult Initialize(object parentKey)
        {
            if (walletService.Initialize(parentKey))
                return Ok();
            else
            {
                logger.ModelServiceInitializationFailed(service: new
                {
                    Service = walletService.GetType().Name,
                    KeyType = parentKey.GetType().Name,
                    KeyValue = parentKey
                });

                return Conflict();
            }
        }

        /// <inheritdoc/>
        public async Task<ActionResult> SaveChangesAsync()
        {
            try
            {
                var result = await walletService.SaveChanges();

                return NoContent();
            }
            catch(ModelUpdateException mue)
            {
                return StatusCode(500, mue);
            }
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<AccountWallet>>> SelectWhereAysnc(
            Expression<Func<AccountWallet, bool>> predicate, int maxCount = 0)
        {
            return await walletService.SelectWhereAysnc(predicate, maxCount);
        }
    }
}
