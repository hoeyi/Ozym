using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.ModelMetadata;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// Represents a read-only service for extracting common reference lists.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReferenceDataService<T>
    {
        /// <summary>
        /// Gets the collection of <see cref="AccountCustodian"/> models as a reference list.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> representing allowable selections.</returns>
        Task<T> AccountCustodianListAsync();

        /// <summary>
        /// Gets the collection of <see cref="Account"/> models as a reference list.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing allowable selections.</returns>
        Task<T> AccountListAsync();

        /// <summary>
        /// Gets the collection of <see cref="Security"/> models as a reference list, 
        /// restricted to securities that are valid end-points for brokerage transactions.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing allowable selections.</returns>
        Task<T> CashOrExternalSecurityListAsync();

        /// <summary>
        /// Gets the collection of <see cref="Country"/> models as a reference list.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing allowable selections.</returns>
        Task<T> CountryListAsync();

        /// <summary>
        /// Gets the collection of <see cref="Security"/> models as a reference list, 
        /// restricted to securities that are crypto-currencies or storable in a digital wallet.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing allowable selections.</returns>
        Task<T> CryptocurrencyListAsync();

        /// <summary>
        /// Gets the collection of <see cref="ModelAttribute"/> models as a reference list, 
        /// restricted to entries with the given <see cref="ModelAttributeScopeCode"/>.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing allowable selections.</returns>
        Task<T> ModelAttributeListAsync(ModelAttributeScopeCode scopeCode);

        /// <summary>
        /// Gets the collection of <see cref="ModelAttributeMember"/> models as a reference list, 
        /// restricted to the given <see cref="ModelAttribute.AttributeId"/>.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing allowable selections.</returns>
        Task<T> ModelAttributeMemberListAsync(int attributeId);

        /// <summary>
        /// Gets the collection of <see cref="Security"/> models as a reference list, restricted to 
        /// securities that are valid subjects for brokerage transactions.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing allowable selections.</returns>
        Task<T> TransactableSecurityListAsync();
    }
}
