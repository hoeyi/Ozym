namespace NjordFinance.ModelService.Abstractions
{
    public interface IModelBaseService<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets the integer key value given a model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The integer key if it exists, else null.</returns>
        int? GetKey(T model);
    }
}
