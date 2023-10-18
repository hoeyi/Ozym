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
