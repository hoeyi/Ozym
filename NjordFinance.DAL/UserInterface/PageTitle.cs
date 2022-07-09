using Ichosys.DataModel;
using Ichosys.DataModel.Annotations;
using System;
using Ichosys.Extensions.Common.Localization;

namespace NjordFinance.UserInterface
{
    /// <summary>
    /// Represents an object for retrieving model page titles.
    /// </summary>
    public interface IPageTitle
    {
        /// <summary>
        /// Gets the title indicating a many records are being read.
        /// </summary>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string ReadMany();

        /// <summary>
        /// Gets the title indicating a single record is being created.
        /// </summary>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string CreateSingle();

        /// <summary>
        /// Gets the title indicating a single record is being read.
        /// </summary>
        /// <param name="heading">The display text for the model.</param>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string ReadSingle(string heading);

        /// <summary>
        /// Gets the title indicating a single record is being edited.
        /// </summary>
        /// <param name="heading">The display text for the model.</param>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string UpdateSingle(string heading);

        /// <summary>
        /// Gets the title indicating editing a records as a batch.
        /// </summary>
        /// <param name="id">The display text for the parent of the collection.</param>
        /// <returns>A <see cref="string"/> for use as a page or section title.</returns>
        string UpdateMany(string parentHeading);
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
        public string CreateSingle()
        {
            return Strings.CreateModel.Format(_noun.GetSingular());
        }

        /// <inheritdoc/>
        public string ReadMany()
        {
            return Strings.IndexModel.Format(_noun.GetPlural()?.ToTitleCase());
        }

        /// <inheritdoc/>   
        public string ReadSingle(string heading)
        {
            heading ??= string.Empty;

            return Strings.ReadModel.Format(_noun.GetSingular()?.ToTitleCase(), heading);
        }

        public string UpdateMany(string parentHeading)
        {
            parentHeading ??= string.Empty;

            return Strings.UpdateModel.Format(_noun.GetPlural(), parentHeading);
        }

        /// <inheritdoc/>
        public string UpdateSingle(string heading)
        {
            heading ??= string.Empty;

            return Strings.UpdateModel.Format(_noun.GetSingular(), heading);
        }

    }
}
