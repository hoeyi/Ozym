using System.Threading.Tasks;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight.Test.EntityModelService
{
    /// <summary>
    /// Required tests for classes implementing <see cref="IModelCollectionService{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelCollectionServiceTest<T>
    {
        /// <summary>
        /// Verifies that adding a model pending save sets the <em>HasChanges</em> value 
        /// to true.
        /// </summary>
        void AddPendingSave_HasChanges_Is_True();

        /// <summary>
        /// Verifies that removing a model pending save sets the <em>HasChanges</em> value 
        /// to true.
        /// </summary>
        Task DeletePendingSave_HasChanges_Is_True();

        /// <summary>
        /// Verifies that removing an added model pending save sets the <em>HasChanges</em> value 
        /// to true.
        /// </summary>
        void DeletePendingAdd_HasChanges_Is_True();

        /// <summary>
        /// Verifies that updating a model pending save sets the <em>HasChanges</em> value 
        /// to false. Update tracking is not yet supported.
        /// </summary>
        Task Update_PendingSave_HasChanges_IsFalse();

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
