using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordinSight.Logging;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using NjordinSight.EntityModelService.Abstractions;
using NjordinSight.DataTransfer;

namespace NjordinSight.Web.Controllers.Abstractions
{
    public class ModelCollectionController<T, TParent> 
        : ModelCollectionController<T>, ICollectionController<T, TParent>
        where T : class, new()
    {
        public ModelCollectionController(
            IModelCollectionService<T, TParent> modelService, 
            IQueryService queryService, ILogger logger) 
            : base(modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        public virtual async Task<IActionResult> ForParent(TParent parent)
        {
            IActionResult RegisterParent()
            {
                ((IModelCollectionService<T, TParent>)_modelService)
                    .SetParent(parent);

                return Ok();
            }

            var result = await Task.Run(() => RegisterParent());

            return result;
        }
    }

    // TODO: Move the use of <T, TParent> collection service into a separate class.
    //       Use here causes issues with the DI service collection resolution because 
    //       some collections are not children of a parent object.
    public class ModelCollectionController<T> : ControllerBase, ICollectionController<T>
        where T : class, new()
    {
        protected readonly IModelCollectionService<T> _modelService;
        private readonly IQueryController _queryController;
        private readonly ILogger _logger;


        public ModelCollectionController(
            IModelCollectionService<T> modelService,
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
                if (_modelService.GetKey<int>(model) != default && !_modelService.ModelExists(model))
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
        public async Task<ActionResult<IEnumerable<T>>> SelectAllAsync()
        {
            var results = await _modelService.SelectAsync();

            return results.ToList();
        }

        /// <inheritdoc/>
        public async Task<ActionResult<(IEnumerable<T>, PaginationData)>> SelectAsync(
            Expression<Func<T, bool>> predicate, int pageNumber = 1, int pageSize = 20)
        {
            var query = await _modelService.SelectAsync(predicate, pageNumber, pageSize);

            return (query.Item1, query.Item2);
        }

        /// <inheritdoc/>
        public async Task<ActionResult<bool>> ModelExistsAsync(T model)
        {
            bool result = await Task.Run(() => _modelService.ModelExists(model));

            return result;
        }

    }
}