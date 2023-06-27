using System.Collections.Generic;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    public interface IAccountProfileTest
    {
        /// <summary>
        /// Verify an entity instance mapped from a DTO instance has all mapped properties equal 
        /// to the source.
        /// </summary>
        /// <returns>A task representing an asynchronous test operation.</returns>
        Task Entity_MapFrom_Dto_MappedProperties_AreEqual();

        /// <summary>
        /// Verify an DTO instance mapped from an entity instance has all mapped properties equal 
        /// to the source.
        /// </summary>
        /// <returns>A task representing an asynchronous test operation.</returns>
        Task Dto_MapFrom_Entity_MappedProperties_AreEqual();
    }
}