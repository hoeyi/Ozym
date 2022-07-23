using Microsoft.EntityFrameworkCore;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ModelService
{
    
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly FinanceDbContext _context;
        public ReferenceDataService(FinanceDbContext context)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            _context = context;   
        }

        public async Task<IList<LookupModel>> AccountCustodianListAsync()
        {
            var result = await _context.AccountCustodians
                .Select(c => new LookupModel(c.AccountCustodianId, c.DisplayName))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        public async Task<IList<LookupModel>> AccountListAsync()
        {
            var result = await _context.Accounts
                .Include(a => a.AccountNavigation)
                .Select(a => new LookupModel(a.AccountId, a.AccountNavigation.AccountObjectCode))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        public async Task<IList<LookupModel>> CashOrExternalSecurityListAsync()
        {
            var result = await _context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .ThenInclude(s => s.SecurityTypeGroup)
                .Where(s => s.SecurityType.SecurityTypeGroup.Transactable)
                .Select(s => new LookupModel(s.SecurityId, s.SecuritySymbol))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        public async Task<IList<LookupModel>> CountryListAsync()
        {
            var result = await _context.Countries
                .Select(c => new LookupModel(c.CountryId, c.DisplayName))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        public async Task<IList<LookupModel>> CryptocurrencyListAsync()
        {
            var result = await _context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .Where(s => s.SecurityType.HeldInWallet)
                .Select(s => new LookupModel(s.SecurityId, s.SecuritySymbol))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        public async Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
            where T : class, new()
        {
            if (include is null)
                return await _context.Set<T>()
                                .SingleAsync();
            else
                return await _context.Set<T>()
                                .Include(include)
                                .SingleAsync(predicate);
        }

        public async Task<IList<LookupModel>> ModelAttributeMemberListAsync(int attributeId)
        {
            var result = await _context.ModelAttributeMembers
                .Where(a => a.AttributeId == attributeId)
                .Select(a => new LookupModel(a.AttributeMemberId, a.DisplayName))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        public async Task<IList<LookupModel>> ModelAttributeListAsync(ModelAttributeScopeCode scopeCode)
        {
            // Convert the enum from a bit field to an array of string codes.
            var scopeCodes = Enum
                .GetValues(typeof(ModelAttributeScopeCode))
                .Cast<Enum>()
                .Where(scopeCode.HasFlag)
                .Cast<ModelAttributeScopeCode>()
                .Select(m => m.ConvertToStringCode())
                .ToArray();

            // Check model attribute scope codes against scope codes dervied from bit field.
            var result = await _context.ModelAttributes
                .Include(a => a.ModelAttributeScopes)
                .Where(a => a.ModelAttributeScopes.Any(b => scopeCodes.Contains(b.ScopeCode)))
                .Select(a => new LookupModel(a.AttributeId, a.DisplayName))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        public async Task<IList<LookupModel>> TransactableSecurityListAsync()
        {
            var result = await _context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .ThenInclude(s => s.SecurityTypeGroup)
                .Where(s => s.SecurityType.SecurityTypeGroup.Transactable)
                .Select(s => new LookupModel(s.SecurityId, s.SecuritySymbol))
                .ToListAsync();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }
    }
}
