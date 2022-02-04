﻿using EulerFinancial.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EulerFinancial.Reference
{
    public interface IReferenceDataService
    {
        Task<IList<Account>> GetAccountsAsync();

        Task<IList<AccountCustodian>> GetAccountCustodiansAsync();

        Task<IList<BankTransactionCode>> GetBankTransactionCodesAsync();

        Task<IList<BrokerTransactionCode>> GetBrokerTransactionCodesAsync();

        Task<IList<BrokerTransactionTaxLot>> GetBrokerTransactionTaxLotsAsync();

        Task<IList<Country>> GetCountriesAsync();

        Task<IList<MarketHoliday>> GetMarketHolidaysAsync();

        Task<IList<SecurityExchange>> GetSecurityExchangesAsync();

        Task<IList<Security>> GetSecuritiesAsync();

        Task<IList<SecurityType>> GetSecurityTypesAsync();

        Task<IList<SecurityTypeGroup>> GetSecurityTypeGroupsAsync();

    }
}
