using AutoMapper;
using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Ozym.ChangeTracking;
using Ozym.DataTransfer;
using Ozym.DataTransfer.Common;
using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using Ozym.EntityModelService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using Asp.Versioning;

namespace Ozym.Api.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/v{version:apiVersion}/accounts/{id1}/performance/{id2}")]
    [Route("api/v{version:apiVersion}/composites/{id1}/performance/{id2}")]
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
        /// <param name="expressionBuilder">The expression builder for this controller.</param>
        /// <param name="mapper">The mapping service for this controller.</param>
        /// <param name="modelService">The model service for this controller.</param>
        /// <param name="queryService">The query service for this controller.</param>
        /// <param name="logger">The logging service for this controller.</param>
        public InvestmentPerformanceCategoryController(
            IExpressionBuilder expressionBuilder,
            IMapper mapper,
            IModelCollectionService<InvestmentPerformanceAttributeMemberEntry> modelService,
            IQueryService queryService,
            ILogger logger) : base(expressionBuilder, mapper, modelService, queryService, logger)
        {
        }

        /// <summary>
        /// Gets the <see cref="InvestmentPerformanceAttributeDto"/> records, limited to the page 
        /// index and size, the composite key derived from the values for <paramref name="id1"/> and 
        /// <paramref name="id2"/>.
        /// </summary>
        /// <param name="id1">First element of the key value for the parent record.</param>
        /// <param name="id2">Second element of the key value for the parent record.</param>
        /// <param name="pageNumber">The index of page to retrieve.</param>
        /// <param name="pageSize">The record limit for each page.</param>
        /// <returns>An <see cref="ActionResult{TValue}"/> whose value is an enumerable collection 
        /// of <see cref="InvestmentPerformanceAttributeDto"/> instances paired with a 
        /// <see cref="AccountSimpleDto"/> record.</returns>
        [HttpGet]
        public virtual async Task<ActionResult<(
                IEnumerable<InvestmentPerformanceAttributeDto>, AccountBaseSimpleDto)>> 
            IndexAsync(
            int id1, int id2, int pageNumber = 1, int pageSize = 20)
        {
            var parent = new CompositeKeyParameter() { Id1 = id1, Id2 = id2 };

            Expression<Func<InvestmentPerformanceAttributeMemberEntry, bool>> entityPredicate = 
                ParentPredicate(parent);
            
            var (items, parentEntity, pagination) = await SelectAsync(
                                                entityPredicate, parent, pageNumber, pageSize);

            Response.Headers[PackageConstant.PaginationHeaderKey] = JsonSerializer.Serialize(pagination);

            var dtoItems = Mapper.Map<IEnumerable<InvestmentPerformanceAttributeDto>>(items);
            var parentItem = Mapper.Map<AccountBaseSimpleDto>(parentEntity);

            return Ok(new { Entries = dtoItems, Parent = parentItem });
        }

        /// <inheritdoc/>
        protected override Expression<Func<InvestmentPerformanceAttributeMemberEntry, bool>> 
            ParentPredicate(CompositeKeyParameter id) => x => 
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
        protected override bool TryParse(
            IReadOnlyDictionary<string, object?> routeValues, out CompositeKeyParameter key)
        {
            if (routeValues.TryGetValue("id1", out object? value1) &&
                routeValues.TryGetValue("id2", out object? value2) &&
                value1 is not null && value2 is not null &&
                int.TryParse(value1.ToString(), out int id1) &&
                int.TryParse(value2.ToString(), out int id2))
            {
                key = new() { Id1 = id1, Id2 = id2 };
                return true;
            }

            key = default;
            return false;
        }

        /// <inheritdoc/>
        protected override bool VerifyParent(
            IEnumerable<InvestmentPerformanceAttributeDto> changes,
            CompositeKeyParameter parent)
                => changes.All(x => x.AccountBaseId == parent.Id1);
    }
}
