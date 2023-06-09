namespace NjordinSight.EntityModelService.Abstractions
{
    /// <summary>
    /// Represents an entity model service that works a collection of <typeparamref name="T"/> 
    /// in a single session.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelCollectionService<T> :
            IModelBaseService<T>,
            IModelReaderService<T>, 
            IModelCollectionWriterService<T>
        where T : class, new()
    {
    }

    /// <summary>
    /// Represents an entity model service that works a collection of <typeparamref name="T"/> with 
    /// parent <typeparamref name="TParent"/> in a single session.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelCollectionService<T, TParent>
        : IModelCollectionService<T>
        where T : class, new()
    {
        /// <summary>
        /// Sets the given <typeparamref name="TParent"/> as the parent object to  the collection 
        /// worked by this service.
        /// </summary>
        /// <param name="parent"></param>
        void SetParent(TParent parent);
    }
}
