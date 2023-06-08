namespace NjordinSight.EntityModelService.Abstractions
{
    public interface IModelBaseService<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets the <typeparamref name="TKey"/> key value for the given model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <typeparamref name="TKey"/> if it exists, else null.</returns>
        TKey GetKey<TKey>(T model);
    }
}
