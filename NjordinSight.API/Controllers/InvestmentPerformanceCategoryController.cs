using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NjordinSight.ChangeTracking;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using NjordinSight.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace NjordinSight.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/investment-category-performance")]
    [ApiVersion("1.0")]
    public class InvestmentPerformanceCategoryController : ApiCollectionController<
        InvestmentPerformanceAttributeDto, 
        InvestmentPerformanceAttributeMemberEntry,
        AccountBaseSimpleDto, 
        AccountObject, CompositeKeyParameter>
    {
        /// <summary>
        /// Creates a new instance of <see cref="InvestmentPerformanceCategoryController"/>.
        /// </summary>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public InvestmentPerformanceCategoryController(
            IMapper mapper,
            IModelCollectionService<InvestmentPerformanceAttributeMemberEntry> modelService,
            IQueryService queryService,
            ILogger logger) : base(mapper, modelService, queryService, logger)
        {
        }

        /// <inheritdoc/>
        [HttpPost("search")]
        public async Task<ActionResult<(
            IEnumerable<InvestmentPerformanceAttributeDto>, AccountBaseSimpleDto)>> PostSearchAsync(
            int id1,
            int id2,
            int pageNumber,
            int pageSize)
        {
            Expression<Func<InvestmentPerformanceAttributeMemberEntry, bool>> entityPredicate;

            // TODO: Determine if its possible to conver URI parameters to a complex 
            // property.
            var parent = new CompositeKeyParameter() { Id1 = id1, Id2 =  id2 };

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

            var dtoItems = Mapper.Map<IEnumerable<InvestmentPerformanceAttributeDto>>(items);
            var parentItem = Mapper.Map<AccountBaseSimpleDto>(parentEntity);

            var responseObject = new
            {
                Entries = dtoItems,
                Parent = parentItem
            };

            return Ok(responseObject);
        }

        /// <inheritdoc/>
        protected override Expression<Func<InvestmentPerformanceAttributeMemberEntry, bool>> ParentPredicate(
            CompositeKeyParameter id) => x => 
                x.AccountObjectId == id.Id1 && x.AttributeMember.AttributeId == id.Id2;

        /// <inheritdoc/>
        protected override async
            Task<(IEnumerable<InvestmentPerformanceAttributeMemberEntry>, AccountObject, PaginationData)> 
            SelectAsync(
                Expression<Func<InvestmentPerformanceAttributeMemberEntry, bool>> predicate,
                CompositeKeyParameter parentId,
                int pageNumber,
                int pageSize)
        {
            var (items, pagination) = await ModelService.SelectAsync(predicate, pageNumber, pageSize);
            var parent = await QueryService.GetSingleAsync<AccountObject>(
                predicate: x => x.AccountObjectId == parentId.Id1);

            return (items, parent, pagination);
        }

        /// <inheritdoc/>
        protected override bool VerifyParent(
            IEnumerable<(InvestmentPerformanceAttributeDto, TrackingState)> changes,
            CompositeKeyParameter parent)
                => changes.Any(x => x.Item1.AccountBaseId != parent.Id1);
    }
}
