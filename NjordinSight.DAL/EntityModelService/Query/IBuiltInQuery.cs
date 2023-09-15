using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.Logging;
using NjordinSight.DataTransfer.Common;
using NjordinSight.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NjordinSight.DataTransfer;
using NjordinSight.DataTransfer.Common.Generic;
using NjordinSight.EntityModel.Annotations;
using System.Reflection;
using NjordinSight.EntityModel.ConstraintType;
using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.Context;
using Ichosys.DataModel;

namespace NjordinSight.EntityModelService.Query
{
    public interface IBuiltInQuery
    {
        Task<(IEnumerable<AccountCustodianDto>, PaginationData)> GetAccountCustodianDTOsAsync(
            Expression<Func<AccountCustodianDto, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);
        
        Task<(IEnumerable<AccountSimpleDto>, PaginationData)> GetAccountDTOsAsync(
            Expression<Func<AccountSimpleDto, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);
        
        Task<(IEnumerable<BankTransactionCodeDtoBase>, PaginationData)> GetBankTransactionCodeDTOsAsync(
            Expression<Func<BankTransactionCodeDtoBase, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);
        
        Task<(IEnumerable<BrokerTransactionCodeDtoBase>, PaginationData)> GetBrokerTransactionCodeDTOsAsync(
            Expression<Func<BrokerTransactionCodeDtoBase, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);
        
        Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetCashOrExternalSecurityDTOsAsync(
            int pageNumber = 1, 
            int pageSize = 20);

        Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetCryptocurrencyDTOsAsync(
            int pageNumber = 1, 
            int pageSize = 20);

        /// <summary>
        /// Gets a subset of the currently defined issuers in the security information file.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<(IEnumerable<string>, PaginationData)> GetIssuersAsync(
            string? pattern = null, int pageNumber = 1, int pageSize = 20);

        Task<IEnumerable<KeyValuePair<int, string>>> GetMarketIndexDTOsAsync(
            Expression<Func<MarketIndexDto, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetModelAttributeMemberDTOsAsync(
            Expression<Func<ModelAttributeMemberDtoBase, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);
        
        Task<IEnumerable<KeyValuePair<int, string>>> GetSecurityDTOsAsync(
            Expression<Func<SecurityDtoBase, bool>> predicate = null,
            int pageNumber = 1,
            int pageSize = 20);

        Task<(IEnumerable<SecuritySymbolTypeDto>, PaginationData)> GetSecuritySymbolTypesAsync(
            int pageNumber = 1, int pageSize = 20);

        Task<(IEnumerable<SecurityTypeDto>, PaginationData)> GetSecurityTypeDTOsAsync(
            Expression<Func<SecurityTypeDto, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);

        Task<(IEnumerable<SecurityTypeGroupDto>, PaginationData)> GetSecurityTypeGroupDTOsAsync(
            Expression<Func<SecurityTypeGroupDto, bool>> predicate = null, 
            int pageNumber = 1, 
            int pageSize = 20);

        /// <summary>
        /// Gets <see cref="ModelAttributeDto"/> records that are applicabe for the given 
        /// <typeparamref name="T"/> variant of <see cref="IAttributeEntryViewModel"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<ModelAttributeDto>> GetSupportedAttributesAsync<T>() 
            where T : IAttributeEntryViewModel;

        Task<(IEnumerable<SecurityDtoBase>, PaginationData)> GetTransactableSecurityDTOsAsync(
            int pageNumber = 1, 
            int pageSize = 20);

        /// <summary>
        /// Gets the display map for the <see cref="MarketIndexPriceDto"/> price code constraint.
        /// </summary>
        /// <param name="placeHolderDelegate"></param>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> where the key is the bound 
        /// string and the value is the display string.</returns>
        IDictionary<string, string> GetMarketIndexPriceCodeDisplayMap(
            Func<KeyValuePair<string, string>> placeHolderDelegate = null);

        /// <summary>
        /// Gets the array of string codes representing the supported <see cref="ModelAttributeScope"/> 
        /// for this type.
        /// </summary>
        /// <typeparam name="T"/>The class to be checked.</typeparam>
        /// <returns>A <see cref="string[]"/> containing the codes representing each supported 
        /// <see cref="ModelAttributeScopeCode"/> member, or an empty array.</returns>
        public static string[] GetSupportedAttributeScopeCodes<T>()
            where T : IAttributeEntryViewModel =>
            typeof(T).GetCustomAttribute<ModelAttributeSupportAttribute>()
            ?.SupportedScopes.ToStringArray() ?? Array.Empty<string>();
    }
}
