using Microsoft.EntityFrameworkCore;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.ModelService.Query;

namespace NjordFinance.ModelService
{

    public partial class ReferenceDataService : IReferenceDataService
    {
        private readonly IDbContextFactory<FinanceDbContext> _contextFactory;
        public ReferenceDataService(IDbContextFactory<FinanceDbContext> contextFactory)
        {
            if (contextFactory is null)
                throw new ArgumentNullException(paramName: nameof(contextFactory));

            _contextFactory = contextFactory;   
        }

        public async Task<IEnumerable<AccountCustodian>> AccountCustodianListAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.AccountCustodians
                .ToListAsync();
        }

        public async Task<IEnumerable<Account>> AccountListAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Accounts
                .Include(a => a.AccountNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Security>> CashOrExternalSecurityListAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .ThenInclude(s => s.SecurityTypeGroup)
                .Where(s => s.SecurityType.SecurityTypeGroup.Transactable)
                .ToListAsync();
        }

        public async Task<IEnumerable<Country>> CountryListAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Countries.ToListAsync();
        }

        public IQueryBuilder<TSource> CreateQueryBuilder<TSource>()
            where TSource : class, new() => 
                new QueryBuilder<TSource>(_contextFactory.CreateDbContext());

        public async Task<IEnumerable<Security>> CryptocurrencyListAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .Where(s => s.SecurityType.HeldInWallet)
                .ToListAsync();
        }

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

        public async Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
            where T : class, new()
        {
            using var context = _contextFactory.CreateDbContext();

            if (include is null)
                return await context.Set<T>()
                                .SingleAsync();
            else
                return await context.Set<T>()
                                .Include(include)
                                .SingleAsync(predicate);
        }
        
        public async Task<IEnumerable<ModelAttribute>> ModelAttributeListAsync(
            ModelAttributeScopeCode scopeCode)
        {
            using var context = _contextFactory.CreateDbContext();

            // Convert the enum from a bit field to an array of string codes.
            var scopeCodes = Enum
                .GetValues(typeof(ModelAttributeScopeCode))
                .Cast<Enum>()
                .Where(scopeCode.HasFlag)
                .Cast<ModelAttributeScopeCode>()
                .Select(m => m.ConvertToStringCode())
                .ToArray();

            // Check model attribute scope codes against scope codes dervied from bit field.
            return await context.ModelAttributes
                .Include(a => a.ModelAttributeScopes)
                .Where(a => a.ModelAttributeScopes.Any(b => scopeCodes.Contains(b.ScopeCode)))
                .ToListAsync();
        }
        
        public async Task<IEnumerable<ModelAttributeMember>> ModelAttributeMemberListAsync(
            int attributeId)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.ModelAttributeMembers
                .Where(a => a.AttributeId == attributeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Security>> TransactableSecurityListAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .ThenInclude(sectype => sectype.SecurityTypeGroup)
                .Where(s => s.SecurityType.SecurityTypeGroup.Transactable)
                .ToListAsync();
        }
    }
}
