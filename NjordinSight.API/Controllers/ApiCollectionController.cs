using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Ichosys.DataModel.Expressions;
using System.Text.Json;
using NjordinSight.ChangeTracking;
using NjordinSight.EntityModelService.Abstractions;
using System.Linq;
using NjordinSight.DataTransfer;
using NjordinSight.EntityModelService.Query;

namespace NjordinSight.Api.Controllers
{
    /// <summary>
    /// Implements <see cref="IApiCollectionController{TObject}"/>.
    /// </summary>
    /// <typeparam name="TObject">The view model.</typeparam>
    /// <typeparam name="TEntity">The data store model.</typeparam>
    public abstract class ApiCollectionController<TObject, TEntity>
        : ControllerBase, IApiCollectionController<TObject>
        where TEntity : class, new()
    {
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IModelCollectionService<TEntity> _modelService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes required parameters for <see cref="ApiController{TObject, TEntity}"/>.
        /// </summary>
        /// <param name="expressionBuilder"></param>
        /// <param name="mapper"></param>
        /// <param name="modelService"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApiCollectionController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<TEntity> modelService,
            ILogger logger)
        {
            if (expressionBuilder is null)
                throw new ArgumentNullException(paramName: nameof(expressionBuilder));

            if (mapper is null)
                throw new ArgumentNullException(paramName: nameof(mapper));

            if (modelService is null)
                throw new ArgumentNullException(paramName: nameof(modelService));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            _expressionBuilder = expressionBuilder;
            _mapper = mapper;
            _modelService = modelService;
            _logger = logger;
        }

        /// <inheritdoc/>
        [HttpPatch]
        public async Task<ActionResult> PatchCollectionAsync(IEnumerable<(TObject, TrackingState)> changes)
        {
            var itemsAdded = changes.Where(x => x.Item2 == TrackingState.Added).ToList();
            var itemsModified = changes.Where(x => x.Item2 == TrackingState.Updated).ToList();
            var itemsRemoved = changes.Where(x => x.Item2 == TrackingState.Removed).ToList();

            var entitiesAdded = _mapper.Map<IEnumerable<TEntity>>(itemsAdded);
            var entitiesModified = _mapper.Map<IEnumerable<TEntity>>(itemsModified);
            var entitiesRemoved = _mapper.Map<IEnumerable<TEntity>>(itemsRemoved);
            
            var affectedRecordCount = await _modelService.AddUpdateDeleteAsync(
                insert: entitiesAdded,
                updates: entitiesModified,
                deletes: entitiesRemoved);

            return Ok(affectedRecordCount);
        }

        /// <inheritdoc/>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TObject>>> GetAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            Expression<Func<TEntity, bool>> entityPredicate = x => true;

            var (items, pagination) = await _modelService
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<TObject>>(items);

            return Ok(dtoItems);
        }
    }

    /// <summary>
    /// Abstract generic class definign commmon behavior for 
    /// <see cref="IApiCollectionController{TObject, TParent}"/> implementations.
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TParent"></typeparam>
    /// <typeparam name="TParentEntity"></typeparam>
    /// <typeparam name="TParentKey"></typeparam>
    public abstract partial class ApiCollectionController<TObject, TEntity, TParent, TParentEntity, TParentKey>
        : ControllerBase
        where TEntity : class, new()
        where TParentEntity : class, new()
    {
        /// <summary>
        /// Creates a new instance of <see 
        /// cref="ApiCollectionController{TObject, TEntity, TParent, TParentEntity, TParentKey}"/>.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="modelService"></param>
        /// <param name="queryService"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected ApiCollectionController(
            IMapper mapper,
            IModelCollectionService<TEntity> modelService,
            IQueryService queryService,
            ILogger logger)
        {
            if (mapper is null)
                throw new ArgumentNullException(paramName: nameof(mapper));

            if (modelService is null)
                throw new ArgumentNullException(paramName: nameof(modelService));

            if (queryService is null)
                throw new ArgumentNullException(paramName: nameof(queryService));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            Mapper = mapper;
            ModelService = modelService;
            QueryService = queryService;
            Logger = logger;
        }

        /// <summary>
        /// Verifies the parent is properly set for all entries in the proposed changes.
        /// </summary>
        /// <param name="changes"></param>
        /// <param name="parent"></param>
        /// <returns>True if the proposed changes are valid, else false.</returns>
        protected abstract bool VerifyParent(IEnumerable<(TObject, TrackingState)> changes, TParentKey parent);

        /// <inheritdoc/>
        protected Task<ActionResult> PatchAsync(IEnumerable<(TObject, TrackingState)> changes, TParentKey parent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Internal search method that is wrapped by <see cref="PostSearchAsync"/>.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        protected async Task<ActionResult<(IEnumerable<TObject>, TParent)>> SearchAsync(
            TParentKey parent,
            int pageNumber = 1,
            int pageSize = 20)
        {
            Expression<Func<TEntity, bool>> entityPredicate;

            if (parent is null)
                return BadRequest(
                    string.Format(
                        ResponseString.PostSearch_InvalidUrlParameter_BadRequestResponse,
                        parent,
                        nameof(parent)));

            entityPredicate = ParentPredicate(parent);

            var (items, parentEntity, pagination) = await SelectAsync(
                                                entityPredicate, parent, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = Mapper.Map<IEnumerable<TObject>>(items);
            var parentItem = Mapper.Map<TParent>(parentEntity);

            return Ok((dtoItems, parentItem));
        }

        /// <summary>
        /// Returns the required parent expression for the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An <see cref="Expression{TDelegate}"/> for filtering <typeparamref name="TEntity"/>
        /// records that are children of the given <paramref name="id"/> value.</returns>
        protected abstract Expression<Func<TEntity, bool>> ParentPredicate(TParentKey id);

        /// <summary>
        /// Abstract method describing the method by which the <typeparamref name="TEntity"/> 
        /// collection and the parent <typeparamref name="TParentEntity"/> are retrieved from 
        /// the data store.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="parentId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        protected abstract Task<(IEnumerable<TEntity>, TParentEntity, PaginationData)> SelectAsync(
            Expression<Func<TEntity, bool>> predicate, TParentKey parentId, int pageNumber, int pageSize);

        /// <summary>
        /// Gets the <see cref="IModelCollectionService{T, TParent}"/> for this controller instance.
        /// </summary>
        protected IModelCollectionService<TEntity> ModelService { get; init; }

        /// <summary>
        /// Gets the <see cref="IQueryService"/> for this controller instance.
        /// </summary>
        protected IQueryService QueryService { get; init; }

        /// <summary>
        /// Gets the <see cref="ILogger"/> for this controller instance.
        /// </summary>
        protected ILogger Logger { get; init; }

        /// <summary>
        /// Gets the <see cref="IMapper"/> for this controller instance.
        /// </summary>
        protected IMapper Mapper { get; init; }
    }

    /// <summary>
    /// Implements <see cref="IApiCollectionController{TObject, TParent}"/>.
    /// </summary>
    /// <typeparam name="TObject">The DTO type.</typeparam>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TParent">The parent DTO type to <typeparamref name="TObject"/>.</typeparam>
    /// <typeparam name="TParentEntity">The parent entity type to <typeparamref name="TEntity"/>.</typeparam>
    public abstract partial class ApiCollectionController<TObject, TEntity, TParent, TParentEntity>
        : ApiCollectionController<TObject, TEntity, TParent, TParentEntity, int>,
        IApiCollectionController<TObject, TParent>
        where TEntity : class, new()
        where TParentEntity : class, new()
    {
        /// <summary>
        /// Creates a new instance of <see 
        /// cref="ApiCollectionController{TObject, TEntity, TParent, TParentEntity}"/>.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="modelService"></param>
        /// <param name="queryService"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApiCollectionController(
            IMapper mapper,
            IModelCollectionService<TEntity> modelService,
            IQueryService queryService,
            ILogger logger) : base(mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        [HttpPost("search")]
        public async Task<ActionResult<(IEnumerable<TObject>, TParent)>> PostSearchAsync(
            int parent,
            int pageNumber,
            int pageSize)
        {
            Expression<Func<TEntity, bool>> entityPredicate;

            if (parent == default)
                return BadRequest(
                    string.Format(
                        ResponseString.PostSearch_InvalidUrlParameter_BadRequestResponse,
                        parent,
                        nameof(parent)));

            entityPredicate = ParentPredicate(parent);

            var (items, parentEntity, pagination) = await SelectAsync(
                                                entityPredicate, parent, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = Mapper.Map<IEnumerable<TObject>>(items);
            var parentItem = Mapper.Map<TParent>(parentEntity);

            var responseObject = new
            {
                Entries = dtoItems,
                Parent = parentItem
            };

            return Ok(responseObject);
        }

        /// <inheritdoc/>
        [HttpPatch]
        public async Task<ActionResult> PatchCollectionAsync(
            IEnumerable<(TObject, TrackingState)> changes, int parent)
        {
            if (!VerifyParent(changes, parent))
                return BadRequest(new
                {
                    ErrorMessage = ResponseString.PatchCollection_ParentIdMismatch_BadRequest
                });

            var itemsAdded = changes.Where(x => x.Item2 == TrackingState.Added).ToList();
            var itemsModified = changes.Where(x => x.Item2 == TrackingState.Updated).ToList();
            var itemsRemoved = changes.Where(x => x.Item2 == TrackingState.Removed).ToList();

            var entitiesAdded = Mapper.Map<IEnumerable<TEntity>>(itemsAdded);
            var entitiesModified = Mapper.Map<IEnumerable<TEntity>>(itemsModified);
            var entitiesRemoved = Mapper.Map<IEnumerable<TEntity>>(itemsRemoved);

            var affectedRecordCount = await ModelService.AddUpdateDeleteAsync(
                insert: entitiesAdded,
                updates: entitiesModified,
                deletes: entitiesRemoved);

            return Ok(affectedRecordCount);
        }
    }
}
