using System;
using Ichosoft.DataModel;
using Ichosoft.DataModel.Annotations;

namespace EulerFinancial.ModelMetadata
{
    /// <summary>
    /// Extensions methods useful for accessing model metadata.
    /// </summary>
    public static class Extensions
    {  
        /// <summary>
        /// Gets the <see cref="NounAttribute"/> applied to the given type.
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="type">The type decorated with a noun attribute.</param>
        /// <returns>A <see cref="NounAttribute"/> if applied to the type, else null.</returns>
        public static NounAttribute NounFor(this IModelMetadataService metadata, Type type)
        {
            if (type is null)
                return null;

            return metadata?.AttributeFor<NounAttribute>(type);
        }
    }
}
