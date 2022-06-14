using Ichosys.DataModel;
using Ichosys.DataModel.Annotations;
using System;
using NjordFinance.Resources;
using Ichosys.Extensions.Common.Localization;

namespace NjordFinance.UserInterface
{
    /// <summary>
    /// Represents an object for retrieving model page titles.
    /// </summary>
    public interface IPageTitle
    {
        /// <summary>
        /// Gets the index title.
        /// </summary>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string Index();

        /// <summary>
        /// Gets the new model title.
        /// </summary>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string Create();

        /// <summary>
        /// Gets the details title.
        /// </summary>
        /// <param name="id">The identifier for the model.</param>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string Read(string id);

        /// <summary>
        /// Gets the modify title.
        /// </summary>
        /// <param name="id">The identifier for the model.</param>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string Update(string id);
    }

    class PageTitle<TModel> : IPageTitle
    {
        private readonly NounAttribute _noun;
        public PageTitle()
        {
            _noun = typeof(TModel).AttributeFor<NounAttribute>();

            if (_noun is null)
                throw new InvalidOperationException(
                    Exceptions.ExceptionString.ModelNoun_NotFound.Format(typeof(TModel).Name));
        }

        /// <inheritdoc/>
        public string Create()
        {
            return UserInterfaceString.CreateModel.Format(_noun.GetSingular());
        }

        /// <inheritdoc/>
        public string Index()
        {
            return UserInterfaceString.IndexModel.Format(_noun.GetPlural()?.ToTitleCase());
        }

        /// <inheritdoc/>   
        public string Read(string id)
        {
            id ??= string.Empty;

            return UserInterfaceString.ReadModel.Format(_noun.GetSingular()?.ToTitleCase(), id);
        }

        /// <inheritdoc/>
        public string Update(string id)
        {
            id ??= string.Empty;

            return UserInterfaceString.UpdateModel.Format(_noun.GetSingular(), id);
        }

    }
}
