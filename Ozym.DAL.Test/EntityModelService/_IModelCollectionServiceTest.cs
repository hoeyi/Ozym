using System.Threading.Tasks;
using Ozym.EntityModelService.Abstractions;

namespace Ozym.Test.EntityModelService
{
    /// <summary>
    /// Required tests for classes implementing <see cref="IModelCollectionService{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelCollectionServiceTest<T>
    {
        /// <summary>
        /// Verifies the unit of work for generating the default <typeparamref name="T"/> model.
        /// </summary>
        /// <returns></returns>
        Task GetDefault_Yields_Model_Instance();

        /// <summary>
        /// Verifies the unit of work for checking a model exists using a key value.
        /// </summary>
        void ModelExists_KeyIsPresent_Returns_True();

        /// <summary>
        /// Verifies the unit of work for checking a model exists using a single 
        /// <typeparamref name="T"/> instance.
        /// </summary>
        void ModelExists_ModelIsPresent_Returns_True();

        /// <summary>
        /// Verifies the unit of work for reading a single <typeparamref name="T"/> model.
        /// </summary>
        /// <returns></returns>
        Task ReadAsync_Returns_Single_Model();

        /// <summary>
        /// Verifies the method used to return all <typeparamref name="T"/> models.
        /// </summary>
        Task SelectAllAsync_Returns_Model_List();

        /// <summary>
        /// Verifies the method used to return all <typeparamref name="T"/> models matching 
        /// the given predicate.
        /// </summary>
        Task SelectWhereAsync_Returns_Model_ExpectedCollection();
    }
}
