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

namespace NjordinSight.Api.Controllers
{

    /// <summary>
    /// Represents a RESTful API controller for <typeparamref name="TObject"/> classes 
    /// that are mapped to <typeparamref name="TEntity"/> classes.
    /// </summary>
    /// <typeparam name="TObject">The type representing a business object record.</typeparam>
    /// <typeparam name="TEntity">The type representing a data store record.</typeparam>
    [ApiController]
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

        /// <inheritdoc/>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            if (!_modelService.ModelExists(id))
                return NotFound();

            var entity = await _modelService.ReadAsync(id);

            try
            {
                var deleteTask = _modelService.DeleteAsync(entity);
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
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: new { me.Message, Detail = me.InnerException?.Message ?? string.Empty });
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        [Obsolete("Retained for backwards compatability. Use PostSearchAsync instead.")]
        [ExcludeFromCodeCoverage]
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


        /// <inheritdoc/>
        [HttpGet]
        [Route("init")]
        public virtual async Task<ActionResult<TObject>> InitDefaultAsync()
        {
            var entity = await _modelService.GetDefaultAsync();

            return _mapper.Map<TObject>(entity);
        }

        /// <inheritdoc/>
        [HttpPost]
        public virtual async Task<ActionResult<TObject>> PostAsync(TObject model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var entity = _mapper.Map<TEntity>(model);

            try
            {
                entity = await _modelService.CreateAsync(entity);

                var createdDto = _mapper.Map<TObject>(entity);

                int id = _modelService.GetKey<int>(entity);

                return CreatedAtAction(
                    actionName: nameof(GetAsync), routeValues: new { id }, value: createdDto);
            }
            catch(ModelUpdateException mue)
            {
                _logger.LogError(exception: mue, message: mue.Message);

                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: new { Detail = mue.Message });
            }
        }

        /// <inheritdoc/>
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
                await _modelService.UpdateAsync(entity);

                return Ok(model);
            }
            catch(ModelUpdateException mue)
            {
                return StatusCode(
                        statusCode: StatusCodes.Status500InternalServerError,
                        value: new { Detail = mue.Message });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_modelService.ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    // TODO: Add list of differences in the response body.
                    return Conflict();
                }
            }
        }

        /// <inheritdoc/>
        [HttpPost]
        [Route("search")]
        public virtual async Task<ActionResult<IEnumerable<TObject>>> PostSearchAsync(
            [FromBody] ParameterDto<TObject> queryParameter, int pageNumber = 1, int pageSize = 20)
        {
            Expression<Func<TEntity, bool>> entityPredicate;

            // If query parameter is invalid use the default filter expression.
            if (!queryParameter.IsValid)
            {
                return BadRequest(ResponseString.PostSearch_InvalidParameter_BadRequestResponse);
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
    }
}
