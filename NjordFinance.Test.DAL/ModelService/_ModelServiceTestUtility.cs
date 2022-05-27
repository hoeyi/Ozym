using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Test.ModelService
{
    /// <summary>
    /// Helper methods for the use by model service tests.
    /// </summary>
    internal static class ModelServiceTestUtility
    {
        /// <summary>
        /// Gets the <typeparamref name="TKey"/> key value for the given 
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TKey GetKey<T, TKey>(T model)
        {
            if (model is null)
                return default;

            Type modelType = typeof(T);
            Type keyType = typeof(TKey);

            var firstKey = modelType.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() is not null
                && p.PropertyType == keyType);

            var keyValue = firstKey?.GetValue(model);

            if (keyValue is null) return default;

            return (TKey)firstKey.GetValue(model);
        }
    }
}
