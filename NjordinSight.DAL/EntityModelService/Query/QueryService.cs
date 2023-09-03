using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.BusinessLogic.Functions;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Common.Generic;
using NjordinSight.EntityModel.ConstraintType;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.Query
{
    public partial class QueryService : IQueryService
    {
        public async Task<IEnumerable<string>> GetIssuersAsync(string pattern, int pageNumber = 1, int pageSize = 20)
        {
            using var context = NewDbContext();

            var issuers = await context.Set<Security>()
                .Where(x => x.Issuer != null && x.Issuer != string.Empty)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Select(x => x.Issuer)
                .OrderBy(x => x)
                .ToListAsync();

            return issuers;
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> GetRecordSetAsync<T, TKey>(
            Expression<Func<T, bool>> predicate,
            int pageNumber = 1,
            int pageSize = 20,
            Expression<Func<T, TKey>> sortBy = null,
            SortOrder sortOrder = SortOrder.Unspecified)
            where T : class, new()
        {
            int limitPageSize = BusinessMath.Clamp(pageSize, 0, 100);

            using var context = await _contextFactory.CreateDbContextAsync();

            var queryable = context.Set<T>().Where(predicate);

            if (sortBy is not null)
                queryable = sortOrder switch
                {
                    SortOrder.Unspecified => queryable,
                    SortOrder.Ascending => queryable.OrderBy(sortBy),
                    SortOrder.Descending => queryable.OrderByDescending(sortBy),
                    _ => throw new InvalidOperationException($"{typeof(SortOrder)} = {nameof(sortOrder)}")
                };

            PaginationData pageData = new()
            {
                ItemCount = await queryable.CountAsync(),
                PageIndex = pageNumber,
                PageSize = pageSize
            };

            // TODO: This needs an ORDER BY clause in order to generate consistent results.
            var result = await queryable
                .Skip(limitPageSize * (pageNumber - 1))
                .Take(limitPageSize)
                .ToListAsync();

            return (result, pageData);
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, PaginationData)> GetRecordSetAsync<T>(
            Expression<Func<T, bool>> predicate, int pageNumber = 1, int pageSize = 20) 
            where T : class, new()
        {
            return await GetRecordSetAsync<T, object>(
                predicate, pageNumber, pageSize, null, SortOrder.Unspecified);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ModelAttributeDto>> GetSupportedAttributesAsync<T>() 
            where T : IAttributeEntryViewModel
        {
            int[] exclusions = new int[2]
            {
                (int)ModelAttributeEnum.SecurityType,
                (int)ModelAttributeEnum.SecurityTypeGroup
            };

            var scopeCodes = IQueryService.GetSupportedAttributeScopeCodes<T>();

            using var queryBuilder = CreateQueryBuilder<ModelAttribute>()
                .WithDirectRelationship(x => x.ModelAttributeScopes)
                .WithDirectRelationship(x => x.ModelAttributeMembers);

            var query = queryBuilder.Build().SelectWhereAsync(
                predicate: x => !exclusions.Contains(x.AttributeId) &&
                    x.ModelAttributeScopes.Any(y => scopeCodes.Contains(y.ScopeCode)),
                maxCount: 0);

            var entities = await query;

            return _mapper.Map<IEnumerable<ModelAttributeDto>>(entities);
        }
    }


    /// <summary>
    /// Represents an implementation of <see cref="IQueryService"/>, providing features 
    /// for querying varying data stores and conversion to DTOs.
    /// </summary>
    public partial class QueryService : IQueryService
    {
        private readonly IDbContextFactory<FinanceDbContext> _contextFactory;
        private readonly IMapper _mapper;
        static readonly object _locker = new();

        /// <summary>
        /// Initializes a new instance of <see cref="FinanceDbContext"/> from the factory instance
        /// assigned to <see cref="_contextFactory"/>.
        /// </summary>
        /// <returns></returns>
        private FinanceDbContext NewDbContext()
        {
            lock (_locker)
            {
                return _contextFactory.CreateDbContext();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryService"/> class.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{TContext}"/> to use for 
        /// generating data contexts.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contextFactory"/> was null.</exception>
        public QueryService(IDbContextFactory<FinanceDbContext> contextFactory, IMapper mapper)
        {
            if (contextFactory is null)
                throw new ArgumentNullException(paramName: nameof(contextFactory));

            if (mapper is null)
                throw new ArgumentNullException(paramName: nameof(mapper));

            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        /// <inheritdoc/> 
        public IQueryBuilder<TSource> CreateQueryBuilder<TSource>()
        where TSource : class, new() =>
            new QueryBuilder<TSource>(context: NewDbContext());

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetManyAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
            where T : class, new()
        {
            using var context = _contextFactory.CreateDbContext();

            if (include is null)
                return await context.Set<T>().Where(predicate).ToListAsync();
            else
                return await context.Set<T>().Where(predicate).Include(include).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
            where T : class, new()
        {
            using var context = _contextFactory.CreateDbContext();

            if (include is null)
                return await context.Set<T>()
                                .SingleAsync(predicate);
            else
                return await context.Set<T>()
                                .Include(include)
                                .SingleAsync(predicate);
        }
    }

    /// <summary>
    /// Extension method class for collections of <see cref="LookupModel{TKey, TDisplay}"/>.
    /// </summary>
    public static partial class ReferenceDataServiceHelper
    {
        /// <summary>
        /// Gets the display <typeparamref name="TValue"/> value for the first DTO in the 
        /// collection matching the given <typeparamref name="TKey"/> key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dtos"></param>
        /// <param name="key"></param>
        /// <returns></returns>
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public static TValue? GetDisplayName<TKey, TValue>(
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            this IEnumerable<LookupModel<TKey, TValue>> dtos,
            TKey key)
        {
            if (dtos is null || key is null)
                return default;

            // Match the first or default result. Use of object.Equals could be problematic, 
            // but need more information. May be fine since TKey will almost always be an integer.
            var firstMatchDTO = dtos?.FirstOrDefault(x => x.Key.Equals(key));

            if (firstMatchDTO is null)
                return default;
            else
                return firstMatchDTO.Display;
        }
    }
}
