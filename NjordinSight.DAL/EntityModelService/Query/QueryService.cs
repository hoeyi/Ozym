using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NjordinSight.BusinessLogic.Functions;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel.ConstraintType;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ichosys.DataModel;
using AutoMapper.Extensions.ExpressionMapping;
using NjordinSight.UserInterface;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.EntityModelService.Query
{
    public partial class QueryService : IQueryService
    {
        /// <inheritdoc/>
        public IBuiltInQuery BuiltIn => this;

        /// <inheritdoc/>
        public IDictionary<TKey, TValue> CreateEnumerableDisplayMap<TEnum, TKey, TValue>(
            Func<TEnum, bool> predicate,
            Expression<Func<TEnum, TKey>> key,
            Expression<Func<TEnum, TValue>> display,
            Func<KeyValuePair<TKey, TValue>> placeHolderDelegate = null)
            where TEnum : struct, Enum
        {
            var keyDeleg = key.Compile();
            var displayDeleg = display.Compile();

            var results = Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .Where(predicate)
                .ToDictionary(x => keyDeleg(x), x => displayDeleg(x));

            if (placeHolderDelegate is not null)
            {
                var placeHolder = placeHolderDelegate.Invoke();
                results.Add(placeHolder.Key, placeHolder.Value);
            }

            return results;
        }

        /// <inheritdoc/> 
        public IQueryBuilder<TSource> CreateQueryBuilder<TSource>()
            where TSource : class, new() =>
            new QueryBuilder<TSource>(context: NewDbContext());

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
    }

    public partial class QueryService
    {
        private readonly IDbContextFactory<FinanceDbContext> _contextFactory;
        private readonly IMapper _mapper;
        static readonly object _locker = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryService"/> class.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{TContext}"/> to use for 
        /// generating data contexts.</param>
        /// <param name="mapper">An <see cref="IMapper"/> instance for translating data store 
        /// entities to DTOs.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contextFactory"/> was null.</exception>
        public QueryService(
            IDbContextFactory<FinanceDbContext> contextFactory, 
            IMapper mapper)
        {
            if (contextFactory is null)
                throw new ArgumentNullException(paramName: nameof(contextFactory));

            if (mapper is null)
                throw new ArgumentNullException(paramName: nameof(mapper));

            _contextFactory = contextFactory;
            _mapper = mapper;
        }


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

       
    }

    #region IBuiltInQuery implementation
    public partial class QueryService : IBuiltInQuery
    {
        /// <inheritdoc/>
        async Task<(IEnumerable<AccountCustodianDto>, PaginationData)> IBuiltInQuery
            .GetAccountCustodianDTOsAsync(
                Expression<Func<AccountCustodianDto, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true : 
                _mapper.MapExpression<Expression<Func<AccountCustodian, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<AccountCustodian>();

            var (entities, pageData) = await queryBuilder.Build()
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<AccountCustodianDto>>(entities)
                .OrderBy(x => x.DisplayName);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<AccountSimpleDto>, PaginationData)> IBuiltInQuery
            .GetAccountDTOsAsync(
                Expression<Func<AccountSimpleDto, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<Account, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<Account>()
                .WithDirectRelationship(x => x.AccountNavigation);

            var (entities, pageData) = await queryBuilder.Build()
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<AccountSimpleDto>>(entities)
                .OrderBy(x => x.ShortCode);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<BankTransactionCodeDtoBase>, PaginationData)> IBuiltInQuery
            .GetBankTransactionCodeDTOsAsync(
                Expression<Func<BankTransactionCodeDtoBase, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<BankTransactionCode, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<BankTransactionCode>();

            var (entities, pageData) = await queryBuilder.Build()
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<BankTransactionCodeDtoBase>>(entities)
                .OrderBy(x => x.TransactionCode);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<BrokerTransactionCodeDtoBase>, PaginationData)> IBuiltInQuery
            .GetBrokerTransactionCodeDTOsAsync(
                Expression<Func<BrokerTransactionCodeDtoBase, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<BrokerTransactionCode, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<BrokerTransactionCode>();

            var (entities, pageData) = await queryBuilder.Build()
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<BrokerTransactionCodeDtoBase>>(entities)
                .OrderBy(x => x.TransactionCode);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<SecurityDtoBase>, PaginationData)> IBuiltInQuery
            .GetCashOrExternalSecurityDTOsAsync(int pageNumber, int pageSize)
        {
            using var queryBuilder = CreateQueryBuilder<Security>()
                .WithDirectRelationship(x => x.SecuritySymbols)
                .WithDirectRelationship(x => x.SecurityType)
                .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(x => x.SecurityTypeGroup);

            var (entities, pageData) = await queryBuilder.Build()
                    .SelectAsync(x => true, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<SecurityDtoBase>>(entities)
                .OrderBy(x => x.CurrentSymbol);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<SecurityDtoBase>, PaginationData)> IBuiltInQuery
            .GetCryptocurrencyDTOsAsync(int pageNumber, int pageSize)
        {
            using var queryBuilder = CreateQueryBuilder<Security>()
                .WithDirectRelationship(x => x.SecuritySymbols)
                .WithDirectRelationship(x => x.SecurityType);

            var (entities, pageData) = await queryBuilder.Build()
                    .SelectAsync(x => true, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<SecurityDtoBase>>(entities)
                .OrderBy(x => x.CurrentSymbol);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<string>, PaginationData)> IBuiltInQuery
            .GetIssuersAsync(string pattern, int pageNumber, int pageSize)
        {
            using var context = NewDbContext();

            IQueryable<string> issuerQueryable;

            if (string.IsNullOrEmpty(pattern))
                issuerQueryable = context.Set<Security>()
                    .Where(x => x.Issuer.Contains(pattern))
                    .Select(x => x.Issuer);
            else
                issuerQueryable = context.Set<Security>()
                    .Select(x => x.Issuer);


            issuerQueryable = issuerQueryable
                .OrderBy(x => x)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);

            var (records, count) = (
                await issuerQueryable.ToListAsync(),
                await issuerQueryable.CountAsync());

            PaginationData pageData = new()
            {
                ItemCount = count,
                PageIndex = pageNumber,
                PageSize = pageSize
            };

            return (records, pageData);
        }

        /// <inheritdoc/>
        async Task<IEnumerable<KeyValuePair<int, string>>> IBuiltInQuery
            .GetMarketIndexDTOsAsync(
                Expression<Func<MarketIndexDto, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<MarketIndex, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<MarketIndex>();

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    key: x => x.IndexId,
                    display: x => x.IndexCode,
                    defaultDisplay: UserInterface.StringTemplate.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        /// <inheritdoc/>
        IDictionary<string, string> IBuiltInQuery.GetMarketIndexPriceCodeDisplayMap(
            Func<KeyValuePair<string, string>> placeHolderDelegate)
        {
            var result = CreateEnumerableDisplayMap<MarketIndexPriceCode, string, string>(
                predicate: x => true,
                key: x => x.ConvertToStringCode(),
                display: x => x.GetAttribute<MarketIndexPriceCode, DisplayAttribute>().GetName(),
                placeHolderDelegate: placeHolderDelegate);

            return result;
        }

        /// <inheritdoc/>
        IDictionary<string, string> IBuiltInQuery.GetModelAttributeScopeDisplayMap(
            Func<KeyValuePair<string, string>> placeHolderDelegate)
        {
            var result = CreateEnumerableDisplayMap<ModelAttributeScopeCode, string, string>(
                predicate: x => true,
                key: x => x.ConvertToStringCode(),
                display: x => x.GetAttribute<ModelAttributeScopeCode, DisplayAttribute>().GetName(),
                placeHolderDelegate: placeHolderDelegate);

            return result;
        }

        /// <inheritdoc/>
        async Task<IEnumerable<KeyValuePair<int, string>>> IBuiltInQuery
            .GetModelAttributeMemberDTOsAsync(
                Expression<Func<ModelAttributeMemberDtoBase, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<ModelAttributeMember, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<ModelAttributeMember>()
                .WithDirectRelationship(x => x.Country)
                .WithDirectRelationship(x => x.SecurityType)
                .WithDirectRelationship(x => x.SecurityTypeGroup);

            // Select items and discard pagination data. We do not need it for now.
            var (items, _) = await queryBuilder.Build()
                .SelectDTOsAsync(
                    predicate: entityPredicate,
                    key: x => x.AttributeMemberId,
                    display: x => x.DisplayName,
                    defaultDisplay: UserInterface.StringTemplate.Caption_InputSelect_Placeholder,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

            return items.OrderByDescending(x => x.Key == default)
                    .ThenBy(x => x.Value);
        }

        /// <inheritdoc/>
        async Task<IEnumerable<KeyValuePair<int, string>>> IBuiltInQuery.GetSecurityDTOsAsync(
            Expression<Func<SecurityDtoBase, bool>> predicate, 
            int pageNumber, 
            int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<Security, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<Security>();

            return await queryBuilder.Build()
                .SelectDTOsAsync(
                    key: x => x.SecurityId,
                    display: x => $"[{x.SecuritySymbol}] {x.SecurityDescription}",
                    defaultDisplay: UserInterface.StringTemplate.Caption_InputSelect_Placeholder)
                .OrderByWithDefaultFirstAsync();
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<SecuritySymbolTypeDto>, PaginationData)> IBuiltInQuery
            .GetSecuritySymbolTypesAsync(
            int pageNumber, 
            int pageSize)
        {
            using var queryBuilder = CreateQueryBuilder<SecuritySymbolType>();

            var (entities, pageData) = await queryBuilder.Build()
                .SelectAsync(x => true, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<SecuritySymbolTypeDto>>(entities)
                .OrderBy(x => x.SymbolTypeName);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<SecurityTypeDto>, PaginationData)> IBuiltInQuery
            .GetSecurityTypeDTOsAsync(
                Expression<Func<SecurityTypeDto, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<SecurityType, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<SecurityType>();

            var (entities, pageData) = await queryBuilder.Build()
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<SecurityTypeDto>>(entities)
                .OrderBy(x => x.SecurityTypeName);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<SecurityTypeGroupDto>, PaginationData)> IBuiltInQuery
            .GetSecurityTypeGroupDTOsAsync(
                Expression<Func<SecurityTypeGroupDto, bool>> predicate, 
                int pageNumber, 
                int pageSize)
        {
            var entityPredicate = predicate is null ? x => true :
                _mapper.MapExpression<Expression<Func<SecurityTypeGroup, bool>>>(predicate);

            using var queryBuilder = CreateQueryBuilder<SecurityTypeGroup>();

            var (entities, pageData) = await queryBuilder.Build()
                .SelectAsync(entityPredicate, pageNumber, pageSize);

            var items = _mapper.Map<IEnumerable<SecurityTypeGroupDto>>(entities)
                .OrderBy(x => x.SecurityTypeGroupName);

            return (items, pageData);
        }

        /// <inheritdoc/>
        async Task<IEnumerable<ModelAttributeDto>> IBuiltInQuery.GetSupportedAttributesAsync<T>()
        {
            int[] exclusions = new int[2]
            {
                (int)ModelAttributeEnum.SecurityType,
                (int)ModelAttributeEnum.SecurityTypeGroup
            };

            var scopeCodes = IBuiltInQuery.GetSupportedAttributeScopeCodes<T>();

            using var queryBuilder = CreateQueryBuilder<ModelAttribute>()
                .WithDirectRelationship(x => x.ModelAttributeScopes)
                .WithDirectRelationship(x => x.ModelAttributeMembers);

            var query = queryBuilder.Build().SelectAsync(
                predicate: x => !exclusions.Contains(x.AttributeId) &&
                    x.ModelAttributeScopes.Any(y => scopeCodes.Contains(y.ScopeCode)),
                pageSize: int.MaxValue);

            var (entities, _) = await query;

            var items = _mapper.Map<IEnumerable<ModelAttributeDto>>(entities);

            return items;
        }

        /// <inheritdoc/>
        async Task<(IEnumerable<SecurityDtoBase>, PaginationData)> IBuiltInQuery
            .GetTransactableSecurityDTOsAsync(
                int pageNumber, 
                int pageSize)
            {
                using var queryBuilder = CreateQueryBuilder<Security>()
                    .WithDirectRelationship(x => x.SecuritySymbols)
                    .WithDirectRelationship(x => x.SecurityType)
                    .WithIndirectRelationship<SecurityType, SecurityTypeGroup>(x => x.SecurityTypeGroup);

                var (entities, pageData) = await queryBuilder.Build()
                    .SelectAsync(x => true, pageNumber, pageSize);

                var items = _mapper.Map<IEnumerable<SecurityDtoBase>>(entities)
                    .OrderBy(x => x.CurrentSymbol);

                return (items, pageData);
        }

        
    }
    #endregion
}
