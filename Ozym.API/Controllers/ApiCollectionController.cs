using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Ichosys.DataModel.Expressions;
using System.Text.Json;
using Ozym.ChangeTracking;
using Ozym.EntityModelService.Abstractions;
using System.Linq;
using Ozym.DataTransfer;
using Ozym.EntityModelService.Query;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Identity;
using Ozym.DataTransfer.Common.Query;
using AutoMapper.Extensions.ExpressionMapping;
using Ichosys.DataModel.Exceptions;
using Ozym.EntityModelService;
using Ozym.DataTransfer.Common.Collections;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Ozym.Api.Controllers
{
    #region IApiCollectionController{Object}
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
        [HttpPost]
        public async Task<ActionResult> PostChangesAsync(
            [FromBody] IDictionary<TrackingState, IEnumerable<TObject>> changeDocument)
        {
            IEnumerable<TObject> itemsAdded = Array.Empty<TObject>();
            IEnumerable<TObject> itemsModified = Array.Empty<TObject>();
            IEnumerable<TObject> itemsRemoved = Array.Empty<TObject>();

            foreach (var key in changeDocument.Keys)
            {
                switch (key)
                {
                    case TrackingState.Added:
                        itemsAdded = changeDocument[key];
                        break;
                    case TrackingState.Updated:
                        itemsModified = changeDocument[key];
                        break;
                    case TrackingState.Removed:
                        itemsRemoved = changeDocument[key];
                        break;
                    default:
                        throw new InvalidOperationException(
                            $"Field {typeof(TrackingState).Name}.{key} is not valid for this method.");
                }
            }

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
    #endregion

    #region IApiCollectionController{TObject, TParent, int}
    /// <summary>
    /// Implements <see cref="IApiCollectionController{TObject, TParent, TParentKey}"/> where the parent is 
    /// uniquely identifier by an <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TObject">The DTO to/from which entities are mapped.</typeparam>
    /// <typeparam name="TEntity">The entity type used by the databse/ORM.</typeparam>
    /// <typeparam name="TParent">The DTO to/from which the parent entity is mapped.</typeparam>
    /// <typeparam name="TParentEntity">The entity type that is the parent to 
    /// <typeparamref name="TEntity"/>.</typeparam>
    public abstract partial class ApiCollectionController<TObject, TEntity, TParent, TParentEntity>
        : ApiCollectionController<TObject, TEntity, TParent, TParentEntity, int>
        
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
    #endregion

    /// <summary>
    /// Base class for implementations of 
    /// <see cref="IApiCollectionController{TObject, TParent, TParentKey}"/>.
    /// </summary>
    /// <typeparam name="TObject">The DTO to/from which entities are mapped.</typeparam>
    /// <typeparam name="TEntity">The entity type used by the databse/ORM.</typeparam>
    /// <typeparam name="TParent">The DTO to/from which the parent entity is mapped.</typeparam>
    /// <typeparam name="TParentEntity">The entity type that is the parent to 
    /// <typeparamref name="TEntity"/>.</typeparam>
    /// <typeparam name="TParentKey">The type for the <typeparamref name="TParentEntity"/> member 
    /// that uniquely identifies a record.</typeparam>
    public abstract partial class ApiCollectionController<
        TObject, TEntity, TParent, TParentEntity, TParentKey>
        : ControllerBase, IApiCollectionController<TObject, TParent, TParentKey>
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

        #region IApiCollectionController<TObject, TParent> implementation
        /// <inheritdoc/>
        [HttpGet]
        public async Task<ActionResult<(IEnumerable<TObject>, TParent)>> IndexAsync(
            TParentKey parentKey, int pageNumber = 1, int pageSize = 20)
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

                return Ok(new { Entries = dtoItems, Parent = parentItem });
            }
        }

        /// <inheritdoc/>
        [HttpGet]
        [Route("all")]
        [Obsolete($"Superseded by method: {nameof(IndexAsync)}.")]
        public async Task<ActionResult<IEnumerable<TObject>>> GetAllAsync()
        {
            var items = await ModelService.SelectAsync();

            return Ok(items);
        }

        /// <inheritdoc/>
        [HttpPost]
        public async Task<ActionResult> PostChangesAsync(
            [FromBody] IDictionary<TrackingState, IEnumerable<TObject>> changeDocument)
        {
            if (!TryParse(RouteData.Values, out TParentKey parent))
            {
                return NotFound();
            }

            bool parentIsValid = VerifyParent(changeDocument.Values.SelectMany(x => x), parent);
            if (!parentIsValid)
                return BadRequest(new
                {
                    ErrorMessage = ResponseString.PatchCollection_ParentIdMismatch_BadRequest
                });

            IEnumerable<TObject> itemsAdded = Array.Empty<TObject>();
            IEnumerable<TObject> itemsModified = Array.Empty<TObject>();
            IEnumerable<TObject> itemsRemoved = Array.Empty<TObject>();

            foreach (var key in changeDocument.Keys)
            {
                switch (key)
                {
                    case TrackingState.Added:
                        itemsAdded = changeDocument[key];
                        break;
                    case TrackingState.Updated:
                        itemsModified = changeDocument[key];
                        break;
                    case TrackingState.Removed:
                        itemsRemoved = changeDocument[key];
                        break;
                    default:
                        throw new InvalidOperationException(
                            $"Field {typeof(TrackingState).Name}.{key} is not valid for this method.");
                }
            }

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

            return Ok(new { Entries = dtoItems, Parent = parentItem });
        }
        #endregion

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
        protected abstract bool VerifyParent(IEnumerable<TObject> changes, TParentKey parent);

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
