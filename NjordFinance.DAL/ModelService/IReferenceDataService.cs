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
    public interface IReferenceDataService
    {
        /// <summary>
        /// Gets the collection representing <see cref="AccountCustodian"/> models as a reference list.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> AccountCustodianListAsync();

        /// <summary>
        /// Gets the collection representing <see cref= "Account" /> models as a reference list.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> AccountListAsync();

        /// <summary>
        /// Gets the collection representing <see cref="Security"/> models as a reference list, 
        /// restricted to securities that are valid end-points for brokerage transactions.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> CashOrExternalSecurityListAsync();

        /// <summary>
        /// Gets the collection representing <see cref="Country"/> models as a reference list.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> CountryListAsync();

        /// <summary>
        /// Gets the collection representing <see cref="Security"/> models as a reference list, 
        /// restricted to securities that are crypto-currencies or storable in a digital wallet.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> CryptocurrencyListAsync();

        /// <summary>
        /// Returns a single <typeparamref name="T"/> from the data store, or throws an exception 
        /// if the sequence does not return a single result.
        /// </summary>
        /// <typeparam name="T">The model type to return.</typeparam>
        /// <param name="predicate">The expression to match the <typeparamref name="T"/>.</param>
        /// <param name="includeNavigationPath">The path for the navigation property to include. 
        /// The default is null, which does not load related data.</param>
        /// <returns>The <typeparamref name="T"/> instance that matches the 
        /// <paramref name="predicate"/>.</returns>
        Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
            where T : class, new();

        /// <summary>
        /// Gets the collection representing <see cref="ModelAttribute"/> models as a reference list, 
        /// restricted to entries with the given <see cref="ModelAttributeScopeCode"/>.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> ModelAttributeListAsync(ModelAttributeScopeCode scopeCode);

        /// <summary>
        /// Gets the collection representing <see cref="ModelAttributeMember"/> models as a reference list, 
        /// restricted to the given <see cref="ModelAttribute.AttributeId"/>.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> ModelAttributeMemberListAsync(int attributeId);

        /// <summary>
        /// Gets the collection representing <see cref="Security"/> models as a reference list, restricted to 
        /// securities that are valid subjects for brokerage transactions.
        /// </summary>
        /// <returns>An <see cref="IList{T}"/> of <see cref="LookupModel"/> models, including 
        /// a default lookup entry.</returns>
        Task<IList<LookupModel>> TransactableSecurityListAsync();

    }

    /// <summary>
    /// Represents a database record that is referenced in a foreign key relationship.
    /// </summary>
    public record LookupModel
    {
        internal LookupModel(int key, string display)
        {
            Key = key;
            Display = display;
        }

        /// <summary>
        /// Gets the key value associated with the record.
        /// </summary>
        public int Key { get; }

        /// <summary>
        /// Gets the display text hen selecting a value.
        /// </summary>
        public string Display { get; }

        internal static LookupModel PlaceHolder()
        {
            return new LookupModel(
                key: default,
                display: UserInterface.Strings.Caption_InputSelect_Placeholder);
        }
    }
}
