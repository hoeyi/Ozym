using Ichosys.DataModel;
using System;
using System.Linq.Expressions;

namespace NjordinSight.UserInterface
{
    /// <summary>
    /// Type-based wrapper class for <see cref="IModelMetadataService"/>, supporting simpler 
    /// syntax for querying metadata for type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type for which metadata is retrieved.</typeparam>
    public class ViewHelper<T> : IViewHelper<T>
    {
        private readonly IModelMetadataService _metadataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewHelper{T}"/> class.
        /// </summary>
        /// <param name="metadataService">The <see cref="IModelMetadataService"/> service for the 
        /// new instance.</param>
        /// <exception cref="ArgumentNullException">Parameter <paramref name="metadataService"/> was null.</exception>
        public ViewHelper(IModelMetadataService metadataService)
        {
            if (metadataService is null)
                throw new ArgumentNullException(paramName: nameof(metadataService));

            _metadataService = metadataService;
        }

        /// <inheritdoc/>
        public TAttribute AttributeFor<TAttribute>(
            Expression<Func<T, object>> expression)
            where TAttribute : Attribute
            => _metadataService.AttributeFor<TAttribute, T>(expression);

        /// <inheritdoc/>
        public string DescriptionFor(Expression<Func<T, object>> expression)
            => _metadataService.DescriptionFor(expression);

        /// <inheritdoc/>
        public TAttribute GetAttribute<TAttribute>() where TAttribute : Attribute
            => _metadataService.GetAttribute<T, TAttribute>();

        /// <inheritdoc/>
        public string GroupNameFor(Expression<Func<T, object>> expression)
            => _metadataService.GroupNameFor(expression);

        /// <inheritdoc/>
        public string NameFor(Expression<Func<T, object>> expression)
            => _metadataService.NameFor(expression);

        /// <inheritdoc/>
        public int? OrderFor(Expression<Func<T, object>> expression)
            => _metadataService.OrderFor(expression);

        /// <inheritdoc/>
        public string PromptFor(Expression<Func<T, object>> expression)
            => _metadataService.PromptFor(expression);

        /// <inheritdoc/>
        public string ShortNameFor(Expression<Func<T, object>> expression)
            => _metadataService.ShortNameFor(expression);
    }
}
