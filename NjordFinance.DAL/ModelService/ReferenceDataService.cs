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
    public class ReferenceDataService<T> : IReferenceDataService<IDictionary<int, string>>
    {
        private readonly FinanceDbContext _context;
        public ReferenceDataService(FinanceDbContext context)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            _context = context;   
        }

        public async Task<IDictionary<int, string>> AccountCustodianListAsync()
        {
            var result = await _context.AccountCustodians
                .ToDictionaryAsync(a => a.AccountCustodianId, b => b.CustodianCode);

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }

        public async Task<IDictionary<int, string>> AccountListAsync()
        {
            var result = await _context.Accounts
                .Include(a => a.AccountNavigation)
                .ToDictionaryAsync(a => a.AccountId, b => b.AccountNavigation.AccountObjectCode);

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }

        public async Task<IDictionary<int, string>> CashOrExternalSecurityListAsync()
        {
            var result = await _context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .ThenInclude(s => s.SecurityTypeGroup)
                .Where(s => s.SecurityType.SecurityTypeGroup.Transactable)
                .ToDictionaryAsync(a => a.SecurityId, b => b.SecuritySymbol);

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }

        public async Task<IDictionary<int, string>> CountryListAsync()
        {
            var result = await _context.Countries
                .ToDictionaryAsync(a => a.CountryId, a => $"{a.DisplayName}");

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }

        public async Task<IDictionary<int, string>> CryptocurrencyListAsync()
        {
            var result = await _context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .Where(s => s.SecurityType.HeldInWallet)
                .ToDictionaryAsync(a => a.SecurityId, b => b.SecuritySymbol);

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }

        public async Task<IDictionary<int, string>> ModelAttributeMemberListAsync(int attributeId)
        {
            var result = await _context.ModelAttributeMembers
                .Where(a => a.AttributeId == attributeId)
                .ToDictionaryAsync(a => a.AttributeMemberId, b => b.DisplayName);

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }

        public async Task<IDictionary<int, string>> ModelAttributeListAsync(ModelAttributeScopeCode scopeCode)
        {
            var result = await _context.ModelAttributes
                .Include(a => a.ModelAttributeScopes)
                .Where(a => a.ModelAttributeScopes.Any(
                    b => b.ScopeCode == scopeCode.ConvertToStringCode()))
                .ToDictionaryAsync(a => a.AttributeId, b => b.DisplayName);

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }

        public async Task<IDictionary<int, string>> TransactableSecurityListAsync()
        {
            var result = await _context.Securities
                .Include(s => s.SecuritySymbols)
                .Include(s => s.SecurityType)
                .ThenInclude(s => s.SecurityTypeGroup)
                .Where(s => s.SecurityType.SecurityTypeGroup.Transactable)
                .ToDictionaryAsync(a => a.SecurityId, b => b.SecuritySymbol);

            result.Add(0, Resources.UserInterfaceString.Caption_InputSelect_Placeholder);

            return result;
        }
    }
}
