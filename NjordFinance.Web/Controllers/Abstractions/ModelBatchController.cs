using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordFinance.Exceptions;
using NjordFinance.Logging;
using NjordFinance.EntityModelService;
using NjordFinance.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Web.Controllers.Abstractions
{
    public class ModelBatchController<T> : ControllerBase, IBatchController<T>
        where T : class, new()
    {
        private readonly IModelBatchService<T> _modelService;
        private readonly IQueryController _queryController;
        private readonly ILogger _logger;


        public ModelBatchController(
            IModelBatchService<T> modelService,
            IQueryService queryService,
            ILogger logger)
        {
            if (modelService is null)
                throw new ArgumentNullException(paramName: nameof(modelService));
            if (queryService is null)
                throw new ArgumentNullException(paramName: nameof(queryService));
            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            _modelService = modelService;
            _queryController = new QueryController(queryService, logger);
            _logger = logger;
        }

        /// <inheritdoc/>
        public IQueryController ReferenceQueries => _queryController;

        /// <inheritdoc/>
        public virtual async Task<IActionResult> AddAsync(T model)
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
        public virtual async Task<IActionResult> DeleteOrDetachAsync(T model)
        {
            IActionResult Delete()
            {
                if (_modelService.GetKey(model) != default && !_modelService.ModelExists(model))
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
        public virtual async Task<IActionResult> ForParent(int parentId)
        {
            IActionResult RegisterParent()
            {
                if (_modelService.ForParent(parentId, out Exception e))
                    return Ok();
                else
                {
                    _logger.ModelServiceParentSetFailed(service: new
                    {
                        Service = _modelService.GetType().Name,
                        KeyType = parentId.GetType().Name,
                        KeyValue = parentId,
                        Message = e?.Message ?? string.Empty
                    });

                    return Conflict();
                }
            }

            var result = await Task.Run(() => RegisterParent());

            return result;
        }

        /// <inheritdoc/>
        public virtual async Task<ActionResult<T>> GetDefaultAsync()
        {
            return await _modelService.GetDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<ActionResult> SaveChangesAsync()
        {
            try
            {
                var result = await _modelService.SaveChangesAsync();

                return NoContent();
            }
            catch (ModelUpdateException mue)
            {
                return StatusCode(500, mue);
            }
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<T>>> SelectAllAsync()
            => await SelectWhereAysnc(predicate: x => true, maxCount: -1);

        /// <inheritdoc/>
        public async Task<ActionResult<IList<T>>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            return await _modelService.SelectWhereAysnc(predicate, maxCount);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<bool>> ModelExistsAsync(T model)
        {
            bool result = await Task.Run(() => _modelService.ModelExists(model));

            return result;
        }
    }
}