using System.Threading.Tasks;

namespace NjordFinance.Test.EntityModelService
{
    /// <summary>
    /// Required tests for classes implementing <see cref="IModelService{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelServiceTest<T>
    {
        /// <summary>
        /// Verifies the unit of work for creating a single <typeparamref name="T"/> model.
        /// </summary>
        /// <returns></returns>
        Task CreateAsync_ValidModel_Returns_Single_Model();

        /// <summary>
        /// Verifies attempting to delete an invalid model throws <see cref="ModelUpdateException"/>.
        /// </summary>
        /// <returns></returns>
        Task DeleteAsync_InvalidModel_ThrowsModelUpdateException();

        /// <summary>
        /// Verifies the unit of work for deleting a single <typeparamref name="T"/> model.
        /// </summary>
        /// <returns></returns>
        Task DeleteAsync_ValidModel_Returns_True();

        /// <summary>
        /// Verifies the unit of work for generating the default <typeparamref name="T"/> model.
        /// </summary>
        /// <returns></returns>
        Task GetDefaultAsync_Returns_Single_Model();

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
        /// the given predicate, limited to 1 result.
        /// </summary>
        Task SelectWhereAsync_Returns_Model_Single();

        /// <summary>
        /// Verifies the unit of work for updating a single <typeparamref name="T"/>.
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync_ValidModel_Returns_True();
    }
}