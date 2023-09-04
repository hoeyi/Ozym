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
using Microsoft.AspNetCore.Routing;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Identity;
using NjordinSight.DataTransfer.Common.Query;
using AutoMapper.Extensions.ExpressionMapping;
using Ichosys.DataModel.Exceptions;
using NjordinSight.EntityModelService;

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
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
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
        public async Task<ActionResult> PatchCollectionAsync(
            IEnumerable<(TObject, TrackingState)> changes)
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
        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<TObject>>> PostSearchAsync(
            [FromBody] ParameterDto<TObject> paramDto, int pageNumber = 1, int pageSize = 20)
        {
            if (!paramDto.IsValid)
            {
                return BadRequest(ResponseString.PostSearch_InvalidBodyParameter_BadRequestResponse);
            }

            var dtoPredicate = _expressionBuilder.GetExpression(paramDto);

            var entityPredicate = _mapper
                .MapExpression<Expression<Func<TEntity, bool>>>(dtoPredicate);

            var (items, pagination) = await _modelService
                                                .SelectAsync(entityPredicate, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<TObject>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TObject>>> GetAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            var (items, pagination) = await _modelService
                                                .SelectAsync(x => true, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<TObject>>(items);

            return Ok(dtoItems);
        }

        /// <inheritdoc/>
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<TObject>>> GetAllAsync()
        {
            var items = await _modelService.SelectAsync();

            return Ok(items);
        }
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
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApiCollectionController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<TEntity> modelService,
            IQueryService queryService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        protected override bool TryParse(
            IReadOnlyDictionary<string, object?> routeValues, out int key)
        {
            if (routeValues.TryGetValue("id", out object? value) &&
                value is not null &&
                int.TryParse(value?.ToString(), out int result))
            {
                key = result;
                return true;
            }

            key = default;
            return false;
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
    public abstract partial class ApiCollectionController<
        TObject, TEntity, TParent, TParentEntity, TParentKey>
        : ControllerBase
        where TEntity : class, new()
        where TParentEntity : class, new()
        where TParentKey : struct
    {
        /// <summary>
        /// Creates a new instance of <see 
        /// cref="ApiCollectionController{TObject, TEntity, TParent, TParentEntity, TParentKey}"/>.
        /// </summary>
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected ApiCollectionController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<TEntity> modelService,
            IQueryService queryService,
            ILogger logger)
        {
            if (expressionBuilder is null)
                throw new ArgumentNullException(paramName: nameof(expressionBuilder));

            if (mapper is null)
                throw new ArgumentNullException(paramName: nameof(mapper));

            if (modelService is null)
                throw new ArgumentNullException(paramName: nameof(modelService));

            if (queryService is null)
                throw new ArgumentNullException(paramName: nameof(queryService));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            ExpressionBuilder = expressionBuilder;
            Mapper = mapper;
            ModelService = modelService;
            QueryService = queryService;
            Logger = logger;
        }

        /// <inheritdoc/>
        [HttpGet]
        public async Task<ActionResult<(IEnumerable<TObject>, TParent)>> IndexAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            if (!TryParse(RouteData.Values, out TParentKey parent))
            {
                return NotFound();
            }
            else
            {
                Expression<Func<TEntity, bool>> entityPredicate = ParentPredicate(parent);

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
        }

        /// <inheritdoc/>
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<TObject>>> GetAllAsync()
        {
            var items = await ModelService.SelectAsync();

            return Ok(items);
        }

        /// <inheritdoc/>
        [HttpPatch]
        public async Task<ActionResult> PatchCollectionAsync(IEnumerable<(TObject, TrackingState)> changes)
        {
            if (!TryParse(RouteData.Values, out TParentKey parent))
            {
                return NotFound();
            }

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

        /// <inheritdoc/>
        [HttpPost]
        [Route("search")]
        public async Task<ActionResult<(IEnumerable<TObject>, TParent)>> PostSearchAsync(
            [FromBody] ParameterDto<TObject> paramDto, int pageNumber = 1, int pageSize = 20)
        {
            if (!TryParse(RouteData.Values, out TParentKey parent))
            {
                return NotFound();
            }

            if (!paramDto.IsValid)
            {
                return BadRequest(ResponseString.PostSearch_InvalidBodyParameter_BadRequestResponse);
            }

            Expression<Func<TObject, bool>> dtoPredicate = x => false;
            bool invalidParameter = false;

            // TODO: Open a ticket to have the null reference bug in IExpressionBuilder.GetExpression
            // resolved.
            try
            {
                dtoPredicate = ExpressionBuilder.GetExpression(paramDto);
            }
            catch (NullReferenceException)
            {
                invalidParameter = true;
            }
            catch (ParseException)
            {
                invalidParameter = true;
            }
            
            if (invalidParameter)
            {
                return BadRequest(ResponseString.PostSearch_InvalidBodyParameter_BadRequestResponse);
            }

            var entityPredicate = ParentPredicate(parent)
                .AndAlso(Mapper.MapExpression<Expression<Func<TEntity, bool>>>(dtoPredicate));

            var (items, parentEntity, pagination) = await SelectAsync(
                                                entityPredicate, parent, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = Mapper.Map<IEnumerable<TObject>>(items);
            var parentItem = Mapper.Map<TParent>(parentEntity);

            return Ok(new{ Entries = dtoItems, Parent = parentItem });
        }

    }

    public abstract partial class ApiCollectionController<
        TObject, TEntity, TParent, TParentEntity, TParentKey>
    {
        /// <summary>
        /// Gets the <see cref="IExpressionBuilder"/> for this controller instance.
        /// </summary>
        protected IExpressionBuilder ExpressionBuilder { get; init; }

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

        /// <summary>
        /// Verifies the parent is properly set for all entries in the proposed changes.
        /// </summary>
        /// <param name="changes"></param>
        /// <param name="parent"></param>
        /// <returns>True if the proposed changes are valid, else false.</returns>
        protected abstract bool VerifyParent(
            IEnumerable<(TObject, TrackingState)> changes, TParentKey parent);

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
        /// Attempts to extract the key values for the requested collection from the route values.
        /// </summary>
        /// <param name="routeValues"></param>
        /// <param name="key">The parsed key value.</param>
        /// <returns>True if the key exists and is the correct type, else false.</returns>
        protected abstract bool TryParse(
            IReadOnlyDictionary<string, object?> routeValues, out TParentKey key);
    }
}
