using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// A serivce implementation responsible for reading and writing models. Edit requests 
    /// are processed once for each individual.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelService<T> : 
            IModelBaseService<T>,
            IModelReaderService<T>, 
            IModelWriterService<T>
        where T : class, new()
    {
    }
}
