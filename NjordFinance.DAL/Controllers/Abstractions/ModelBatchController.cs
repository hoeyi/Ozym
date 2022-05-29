using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordFinance.Exceptions;
using NjordFinance.Logging;
using NjordFinance.ModelService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Controllers.Abstractions
{
    public class ModelBatchController<T> : ControllerBase, IBatchController<T>
        where T : class, new()
    {
        protected readonly IModelBatchService<T> _modelService;
        protected readonly ILogger _logger;
        public ModelBatchController(
            IModelBatchService<T> modelService,
            ILogger logger)
        {
            if (modelService is null)
                throw new ArgumentNullException(paramName: nameof(modelService));
            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            _modelService = modelService;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IActionResult> AddAsync(T model)
        {
            IActionResult Add()
            {
                if (_modelService.AddPendingSave(model))
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
        public async Task<IActionResult> DeleteAsync(T model)
        {
            IActionResult Delete()
            {
                if (!_modelService.ModelExists(model))
                {
                    return BadRequest();
                }

                if (_modelService.DeletePendingSave(model))
                    return Ok();
                else
                    return Conflict();
            }

            var result = await Task.Run(() => Delete());

            return result;
        }

        /// <inheritdoc/>
        public IActionResult ForParent(int parentId)
        {
            if (_modelService.ForParent(parentId))
                return Ok();
            else
            {
                _logger.ModelServiceParentSetFailed(service: new
                {
                    Service = _modelService.GetType().Name,
                    KeyType = parentId.GetType().Name,
                    KeyValue = parentId
                });

                return Conflict();
            }
        }

        /// <inheritdoc/>
        public async Task<ActionResult<T>> GetDefaultAsync()
        {
            return await _modelService.GetDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<ActionResult> SaveChangesAsync()
        {
            try
            {
                var result = await _modelService.SaveChanges();

                return NoContent();
            }
            catch (ModelUpdateException mue)
            {
                return StatusCode(500, mue);
            }
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<T>>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            return await _modelService.SelectWhereAysnc(predicate, maxCount);
        }
    }
}