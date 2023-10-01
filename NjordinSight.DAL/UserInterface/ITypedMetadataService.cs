using Ichosys.DataModel;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NjordinSight.UserInterface
{
    public static class MetadataServiceExtension
    {
        public static TAttribute GetAttribute<TEnum, TAttribute>(this TEnum @enum)
            where TAttribute : Attribute
        {
            var enumType = typeof(TEnum);
            var fieldName = Enum.GetName(enumType, @enum);

            return enumType.GetField(fieldName).GetCustomAttribute<TAttribute>();
        }
    }

    /// <summary>
    /// Helpers class for simplifying calls to metadata get methods on a given type.
    /// </summary>
    /// <typeparam name="T">The model type in which metadata is defined.</typeparam>
    public interface ITypedMetadataService<T>
        where T : class
    {
        /// <summary>
        /// Gets the first <typeparamref name="TAttribute"/> associated with the 
        /// <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type to retreive.</typeparam>
        /// <returns>An instance of <typeparamref name="TAttribute"/> if defined, else null.</returns>
        TAttribute GetAttribute<TAttribute>() where TAttribute : Attribute;

        /// <summary>
        /// Gets the <typeparamref name="TAttribute"/> associated with the <typeparamref name="T"/> 
        /// member indicated by the given expression.
        /// </summary>
        /// <typeparam name="TAttribute">A type derived from <see cref="Attribute"/>.</typeparam>
        /// <param name="expression"></param>
        /// <returns>An instance of <typeparamref name="TAttribute"/> if defined, else null.</returns>
        TAttribute AttributeFor<TAttribute>(Expression<Func<T, object>> expression)
            where TAttribute : Attribute;
        /// <summary>
        /// Gets the description text associated with the <typeparamref name="T"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="T"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string DescriptionFor(Expression<Func<T, object>> expression);

        /// <summary>
        /// Gets the group name associated with the <typeparamref name="T"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="T"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string GroupNameFor(Expression<Func<T, object>> expression);

        /// <summary>
        /// Gets the display name associated with the <typeparamref name="T"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="T"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string NameFor(Expression<Func<T, object>> expression);

        /// <summary>
        /// Gets the display order associated with the <typeparamref name="T"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="T"/> member.</param>
        /// <returns>An <see cref="int"/> if the metadata property is defined, else null.</returns>
        int? OrderFor(Expression<Func<T, object>> expression);

        /// <summary>
        /// Gets the input prompt associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="T"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string PromptFor(Expression<Func<T, object>> expression);

        /// <summary>
        /// Gets the short name associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="T"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string ShortNameFor(Expression<Func<T, object>> expression);
    }
}
