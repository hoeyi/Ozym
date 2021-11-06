using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerFinancial.Context;
using EulerFinancial.Model;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly EulerFinancialContext context;
        public ReferenceDataService(EulerFinancialContext context)
        {
            this.context = context;
        }

        public async Task<IList<Account>> GetAccountsAsync()
        {
            return await SelectAllOfTypeAsync<Account>();
        }

        public async Task<IList<AccountCustodian>> GetAccountCustodiansAsync()
        {
            return await SelectAllOfTypeAsync<AccountCustodian>();
        }

        public async Task<IList<BankTransactionCode>> GetBankTransactionCodesAsync()
        {
            return await SelectAllOfTypeAsync<BankTransactionCode>();
        }

        public async Task<IList<BrokerTransactionCode>> GetBrokerTransactionCodesAsync()
        {
            return await SelectAllOfTypeAsync<BrokerTransactionCode>();
        }

        public async Task<IList<BrokerTransactionTaxLot>> GetBrokerTransactionTaxLotsAsync()
        {
            return await SelectAllOfTypeAsync<BrokerTransactionTaxLot>();
        }

        public async Task<IList<Country>> GetCountriesAsync()
        {
            return await SelectAllOfTypeAsync<Country>();
        }

        public async Task<IList<MarketHoliday>> GetMarketHolidaysAsync()
        {
            return await SelectAllOfTypeAsync<MarketHoliday>();
        }

        public async Task<IList<Security>> GetSecuritiesAsync()
        {
            return await SelectAllOfTypeAsync<Security>();
        }

        public async Task<IList<SecurityExchange>> GetSecurityExchangesAsync()
        {
            return await SelectAllOfTypeAsync<SecurityExchange>();
        }

        public async Task<IList<SecurityTypeGroup>> GetSecurityTypeGroupsAsync()
        {
            return await SelectAllOfTypeAsync<SecurityTypeGroup>();
        }

        public async Task<IList<SecurityType>> GetSecurityTypesAsync()
        {
            return await SelectAllOfTypeAsync<SecurityType>();
        }

        private async Task<IList<T>> SelectAllOfTypeAsync<T>()
            where T : class, new()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}
