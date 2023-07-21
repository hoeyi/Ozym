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

namespace NjordinSight.Api.Controllers
{
    /// <summary>
    /// Represents a RESTful API controller for <typeparamref name="TObject"/> classes 
    /// that are mapped to <typeparamref name="TEntity"/> classes.
    /// </summary>
    /// <typeparam name="TObject">The type representing a business object record.</typeparam>
    /// <typeparam name="TEntity">The type representing a data store record.</typeparam>
    public class ApiController<TObject, TEntity> : 
        ControllerBase, IApiController<TObject> 
        where TEntity : class, new()
    {
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IModelService<TEntity> _modelService;
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
        public ApiController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelService<TEntity> modelService,
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

        /// <summary>
        /// Submits a deletion request for the resource identified by the given id.
        /// </summary>
        /// <param name="id">The unique identifier for the resource to delete.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            if (!_modelService.ModelExists(id))
                return NotFound();

            var entity = await _modelService.ReadAsync(id);
            var deleteTask = _modelService.DeleteAsync(entity);

            try
            {
                var success = await deleteTask;

                if (success)
                    return NoContent();

                else
                    return StatusCode(
                        statusCode: StatusCodes.Status500InternalServerError,
                        value: ResponseString.DeleteResource_FailedResult_InternalErrorResponse);
            }
            catch(ModelUpdateException me)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status409Conflict,
                    value: new { me.Message, Detail = me.InnerException?.Message ?? string.Empty });
            }
        }

        /// <summary>
        /// Retrieves the resource identified by the given id.
        /// </summary>
        /// <param name="id">The unique identifier for the resource to retrieve.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TObject>> GetAsync(int id)
        {
            var entity = await _modelService.ReadAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            return _mapper.Map<TObject>(entity);
        }

        /// <summary>
        /// Retrieves the collection matching the given query parameter, limited to the given 
        /// page attributes.
        /// </summary>
        /// <param name="queryParameter">The <see cref="ParameterDto{T}"/> describing the operation 
        /// to filter results.</param>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TObject>>> GetAsync(
            [FromBody] ParameterDto<TObject> queryParameter, int pageNumber = 1, int pageSize = 20)
        {
            Expression<Func<TEntity, bool>> entityPredicate;

            // If query parameter is invalid use the default filter expression.
            if (!(queryParameter?.IsValid ?? false))
            {
                entityPredicate = x => true;
            }
            else
            {
                var dtoPredicate = _expressionBuilder.GetExpression(queryParameter);

                entityPredicate = _mapper
                    .MapExpression<Expression<Func<TEntity, bool>>>(dtoPredicate);
            }

            var (items, pagination) = await _modelService
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagination));

            var dtoItems = _mapper.Map<IEnumerable<TObject>>(items);

            return Ok(dtoItems);
        }

        /// <summary>
        /// Initializes a default instance for use in a post action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("init")]
        public virtual async Task<ActionResult<TObject>> InitDefaultAsync()
        {
            var entity = await _modelService.GetDefaultAsync();

            return _mapper.Map<TObject>(entity);
        }

        /// <summary>
        /// Submits a post request for the given resource.
        /// </summary>
        /// <param name="model">The instance to create.</param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<TObject>> PostAsync(TObject model)
        {
            var entity = _mapper.Map<TEntity>(model);

            try
            {

                entity = await _modelService.CreateAsync(entity);

                var createdDto = _mapper.Map<TObject>(entity);

                var id = _modelService.GetKey<int>(entity);

                return CreatedAtAction(
                    actionName: nameof(GetAsync), routeValues: new { id }, value: createdDto);
            }

            // TODO: This code may not be reachable. ModelServices are capturing the
            // DbUpdateException and wrapping its message in a ModelUpdateException.
            catch (DbUpdateException due)
            {
                _logger.LogError(exception: due, message: due.Message);

                if (_modelService.ModelExists(_modelService.GetKey<int>(entity)))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Submits a put request replacing the resource matching the given id with the model
        /// instance given.
        /// </summary>
        /// <param name="id">The unique identifier for the resource to replace.</param>
        /// <param name="model">The instance to replace the existing resource.</param>
        /// <returns></returns>
        /// <remarks>Only PUT methods are supported for updating records. PATCH method is 
        /// planned.</remarks>
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TObject>> PutAsync(int id, TObject model)
        {
            var entity = _mapper.Map<TEntity>(model);

            if (id != _modelService.GetKey<int>(entity))
            {
                return BadRequest();
            }

            try
            {
                var updateTask = _modelService.UpdateAsync(entity);

                bool success = await updateTask;

                // If success or soft-fail (no records modified) return model.
                // Else throw the AggregateException.
                if (success ^ (!success && updateTask.Exception is null))
                    return _mapper.Map<TObject>(entity);

                if (updateTask?.Exception is null)
                    throw new InvalidOperationException();

                else
                    throw updateTask.Exception;
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
