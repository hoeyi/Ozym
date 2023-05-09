using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModelService.Query;

namespace NjordinSight.Web.Controllers.Abstractions
{
    /// <summary>
    /// Base class for controllers responsible for directing application flow when 
    /// working <typeparamref name="T"/> models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class ModelController<T> : ControllerBase, IController<T>
        where T : class, new()
    {
        private readonly IModelService<T> _modelService;
        private readonly IQueryController _queryController;
        private readonly ILogger _logger;
        public ModelController(
            IModelService<T> modelService,
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
        public async Task<ActionResult<T>> CreateAsync(T model)
        {
            try
            {
                var createdModel = await _modelService.CreateAsync(model);

                return CreatedAtAction(
                    nameof(ReadAsync),
                    new { id = _modelService.GetKey(createdModel) },
                    createdModel);
            }
            // TODO: This code may not be reachable. ModelServices are capturing the
            // DbUpdateException and wrapping its message in a ModelUpdateException.
            catch (DbUpdateException due)
            {
                _logger.LogError(exception: due, message: due.Message);

                if (_modelService.ModelExists(_modelService.GetKey(model)))
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
        public async Task<IActionResult> DeleteAsync(T model)
        {
            if (!_modelService.ModelExists(model))
            {
                return NotFound();
            }

            var deleteTask = _modelService.DeleteAsync(model);

            var success = await deleteTask;

            if (success) return NoContent();
            else throw deleteTask.Exception;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<T>> GetDefaultAsync()
        {
            return await _modelService.GetDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<ActionResult<T>> ReadAsync(int? id)
        {
            var model = await _modelService.ReadAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return model;
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<T>>> SelectAllAsync()
        {
            return await _modelService.SelectAllAsync();
        }

        /// <inheritdoc/>
        public async Task<ActionResult<IList<T>>> SelectWhereAysnc(
            Expression<Func<T, bool>> predicate, int maxCount = 0)
        {
            return await _modelService.SelectWhereAysnc(predicate, maxCount);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<T>> UpdateAsync(int? id, T model)
        {
            if (id != _modelService.GetKey(model))
            {
                return BadRequest();
            }

            try
            {
                var updateTask = _modelService.UpdateAsync(model);

                bool success = await updateTask;

                // If success or soft-fail (no records modified) return model.
                // Else throw the AggregateException.
                if (success ^ (!success && updateTask.Exception is null)) return model;
                else throw updateTask.Exception;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_modelService.ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
    }


}
