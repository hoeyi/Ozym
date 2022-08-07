using NjordFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// Extension method class for converting <see cref="IEnumerable{T}"/> to <see cref="IList{T}"/> 
    /// collections of <see cref="LookupModel"/> instances.
    /// </summary>
    public static class ReferenceDataServiceHelper
    {
        /// <summary>
        /// Converts this collection of <see cref="AccountCustodian"/> instances to a new list 
        /// of <see cref="LookupModel"/> instances.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>An <see cref="IList{T}"/> containing <see cref="LookupModel"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<LookupModel> ToLookups(this IEnumerable<AccountCustodian> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            var result = collection.Select(model => new LookupModel()
            {
                Key = model.AccountCustodianId,
                Display = model.DisplayName
            })
            .ToList();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        /// <summary>
        /// Converts this collection of <see cref="Account"/> instances to a new list 
        /// of <see cref="LookupModel"/> instances.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>An <see cref="IList{T}"/> containing <see cref="LookupModel"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<LookupModel> ToLookups(this IEnumerable<Account> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            var result = collection.Select(model => new LookupModel()
            {
                Key = model.AccountId,
                Display = model.AccountCode
            })
            .ToList();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        /// <summary>
        /// Converts this collection of <see cref="ModelAttribute"/> instances to a new list 
        /// of <see cref="LookupModel"/> instances.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>An <see cref="IList{T}"/> containing <see cref="LookupModel"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<LookupModel> ToLookups(this IEnumerable<ModelAttribute> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            var result = collection.Select(model => new LookupModel()
            {
                Key = model.AttributeId,
                Display = model.DisplayName
            })
            .ToList();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        /// <summary>
        /// Converts this collection of <see cref="ModelAttributeMember"/> instances to a new list 
        /// of <see cref="LookupModel"/> instances.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>An <see cref="IList{T}"/> containing <see cref="LookupModel"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<LookupModel> ToLookups(this IEnumerable<ModelAttributeMember> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            var result = collection.Select(model => new LookupModel()
            {
                Key = model.AttributeMemberId,
                Display = model.DisplayName
            })
            .ToList();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        /// <summary>
        /// Converts this collection of <see cref="Security"/> instances to a new list 
        /// of <see cref="LookupModel"/> instances.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>An <see cref="IList{T}"/> containing <see cref="LookupModel"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<LookupModel> ToLookups(this IEnumerable<Security> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            var result = collection.Select(model => new LookupModel()
            {
                Key = model.SecurityId,
                Display = $"({model.SecuritySymbol ?? "----"}) {model.SecurityDescription}"
            })
            .ToList();

            result.Insert(0, LookupModel.PlaceHolder());

            return result;
        }

        /// <summary>
        /// Inserts a place-holder <see cref="LookupModel"/>. Use where a foreign key relationship 
        /// is optional, or for new entries on required relationships.
        /// </summary>
        /// <param name="lookupList"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<LookupModel> WithPlaceHolder(this IList<LookupModel> lookupList)
        {
            if (lookupList is null)
                throw new ArgumentNullException(paramName: nameof(lookupList));

            int defaultKey = default;
            string defaultDisplay = UserInterface.Strings.Caption_InputSelect_Placeholder ?? "<Select>";

            if (!lookupList.Any(i => i.Key == defaultKey || i.Display == defaultDisplay))
                lookupList.Insert(0, new() { Key = defaultKey, Display = defaultDisplay });

            return lookupList;
        }
    }
}