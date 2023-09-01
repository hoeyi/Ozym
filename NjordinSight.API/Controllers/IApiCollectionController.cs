using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModelService;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Ichosys.DataModel.Expressions;
using NjordinSight.DataTransfer.Common.Query;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;
using NjordinSight.ChangeTracking;
using NjordinSight.EntityModelService.Abstractions;
using NjordinSight.EntityModelService.Query;
using NjordinSight.DataTransfer;
using System.Linq;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.Api.Controllers
{
    /// <summary>
    /// Represents an API endpoint that facilitates searching and modifying collections of records.
    /// </summary>
    /// <typeparam name="TObject">Record type for the collection.</typeparam>
    /// <typeparam name="TParent">Record type for the parent.</typeparam>
    public interface IApiCollectionController<TObject, TParent>
    {
        /// <summary>
        /// Posts the search expression in the request body and returns the <typeparamref name="TObject"/> 
        /// records matching the expression, limited to the page index and size.
        /// </summary>
        /// <param name="queryParameter">The <see cref="ParameterDto{T}"/> describing the operation 
        /// to filter results.</param>
        /// <param name="parent">Value uniquely identifying the parent record for the modified collection.</param>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <typeparamref name="TObject"/> instances.</returns>
        /// <remarks>This method works around using GET methods with filters defined in the URI.
        /// Use this method to pass search parameters to the endpoint [controller]/search, where the
        /// response content gives the filtered result set.</remarks>
        Task<ActionResult<(IEnumerable<TObject>, TParent)>> PostSearchAsync(
            int parent, 
            int pageNumber = 1, 
            int pageSize = 20);

        /// <summary>
        /// Modifies the collection in the data store by applying the given inserts, updates, and 
        /// deletes.
        /// </summary>
        /// <param name="changes">Enumerable collection of models being inserted, modified, or deleted.</param>
        /// <param name="parent">Value uniquely identifying the parent record for the modified collection.</param>
        /// <returns>An <see cref="ActionResult"/>.</returns>
        Task<ActionResult> PatchCollectionAsync(IEnumerable<(TObject, TrackingState)> changes, int parent);
    }

    /// <summary>
    /// Represents an API endpoint that facilitates searching and modifying collections of records.
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IApiCollectionController<TObject>
    {
        /// <summary>
        /// Posts the search expression in the request body and returns the <typeparamref name="TObject"/> 
        /// records matching the expression, limited to the page index and size
        /// </summary>
        /// <param name="queryParameter">The <see cref="ParameterDto{T}"/> describing the operation 
        /// to filter results.</param>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <typeparamref name="TObject"/> instances.</returns>
        /// <remarks>This method works around using GET methods with filters defined in the URI.
        /// Use this method to pass search parameters to the endpoint [controller]/search, where the
        /// response content gives the filtered result set.</remarks>
        Task<ActionResult<IEnumerable<TObject>>> PostSearchAsync(
            [FromBody] ParameterDto<TObject> queryParameter, int pageNumber = 1, int pageSize = 20);

        /// <summary>
        /// Modifies the collection in the data store by applying the given inserts, updates, and 
        /// deletes.
        /// </summary>
        /// <param name="changes">Enumerable collection of models being inserted, modified, or deleted.</param>
        /// <returns>An <see cref="ActionResult"/>.</returns>
        Task<ActionResult> PatchCollectionAsync(IEnumerable<(TObject, TrackingState)> changes);
    }

    /// <summary>
    /// Implements <see cref="IApiCollectionController{TObject, TParent}"/>.
    /// </summary>
    /// <typeparam name="TObject">The DTO type.</typeparam>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TParent">The parent DTO type to <typeparamref name="TObject"/>.</typeparam>
    /// <typeparam name="TParentEntity">The parent entity type to <typeparamref name="TEntity"/>.</typeparam>
    public abstract class ApiCollectionController<TObject, TEntity, TParent, TParentEntity>
        : ControllerBase, IApiCollectionController<TObject, TParent>
        where TEntity : class, new()
        where TParentEntity : class, new()
    {
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of <see 
        /// cref="ApiCollectionController{TObject, TEntity, TParent, TParentEntity}"/>.
        /// </summary>
        /// <param name="expressionBuilder"></param>
        /// <param name="mapper"></param>
        /// <param name="modelService"></param>
        /// <param name="queryService"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApiCollectionController(
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

            _expressionBuilder = expressionBuilder;
            _mapper = mapper;
            _logger = logger;
            
            ModelService = modelService;
            QueryService = queryService;
        }

        /// <summary>
        /// Gets the <see cref="IModelCollectionService{T, TParent}"/> for this instance.
        /// </summary>
        protected IModelCollectionService<TEntity> ModelService { get; init; }

        /// <summary>
        /// Gets the <see cref="IQueryService"/> for this instance.
        /// </summary>
        protected IQueryService QueryService { get; init; }

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

            var dtoItems = _mapper.Map<IEnumerable<TObject>>(items);
            var parentItem = _mapper.Map<TParent>(parentEntity);

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

            var entitiesAdded = _mapper.Map<IEnumerable<TEntity>>(itemsAdded);
            var entitiesModified = _mapper.Map<IEnumerable<TEntity>>(itemsModified);
            var entitiesRemoved = _mapper.Map<IEnumerable<TEntity>>(itemsRemoved);

            var affectedRecordCount = await ModelService.AddUpdateDeleteAsync(
                insert: entitiesAdded,
                updates: entitiesModified,
                deletes: entitiesRemoved);

            return Ok(affectedRecordCount);
        }

        /// <summary>
        /// Verifies the parent is properly set for all entries in the proposed changes.
        /// </summary>
        /// <param name="changes"></param>
        /// <param name="parent"></param>
        /// <returns>True if the proposed changes are valid, else false.</returns>
        protected abstract bool VerifyParent(IEnumerable<(TObject, TrackingState)> changes, int parent);

        /// <inheritdoc/>
        protected Task<ActionResult> PatchAsync(IEnumerable<(TObject, TrackingState)> changes, int parent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Internal search method that is wrapped by <see cref="PostSearchAsync"/>.
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <param name="parent"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        protected async Task<ActionResult<(IEnumerable<TObject>, TParent)>> SearchAsync(
            int parent, 
            int pageNumber = 1, 
            int pageSize = 20)
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

            var dtoItems = _mapper.Map<IEnumerable<TObject>>(items);
            var parentItem = _mapper.Map<TParent>(parentEntity);

            return Ok((dtoItems, parentItem));
        }

        /// <summary>
        /// Returns the required parent expression for the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An <see cref="Expression{TDelegate}"/> for filtering <typeparamref name="TEntity"/>
        /// records that are children of the given <paramref name="id"/> value.</returns>
        protected abstract Expression<Func<TEntity, bool>> ParentPredicate(int id);

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
            Expression<Func<TEntity, bool>> predicate, int parentId, int pageNumber, int pageSize);
    }


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
        public async Task<ActionResult<IEnumerable<TObject>>> PostSearchAsync(
            [FromBody] ParameterDto<TObject> queryParameter, int pageNumber = 1, int pageSize = 20)
        {
            Expression<Func<TEntity, bool>> entityPredicate;

            // If query parameter is invalid use the default filter expression.
            if (!queryParameter.IsValid)
            {
                return BadRequest(ResponseString.PostSearch_InvalidBodyParameter_BadRequestResponse);
            }
            else
            {
                var dtoPredicate = _expressionBuilder.GetExpression(queryParameter);

                entityPredicate = _mapper
                    .MapExpression<Expression<Func<TEntity, bool>>>(dtoPredicate);
            }

            var (items, pagination) = await _modelService
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<TObject>>(items);

            return Ok(dtoItems);
        }
    }
}
