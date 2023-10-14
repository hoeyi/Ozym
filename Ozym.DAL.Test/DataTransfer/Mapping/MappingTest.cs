using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.Test.DataTransfer.Mapping
{
    public abstract class MappingTest
    {
        /// <summary>
        /// Base initializer for <see cref="MappingTest"/>.
        /// </summary>
        /// <param name="mapper">The <see cref="IMapper"/> instance to use for testing.</param>
        /// <exception cref="ArgumentNullException"><paramref name="mapper"/> is null.</exception>
        public MappingTest(IMapper mapper)
        {
            if (mapper is null)
                throw new ArgumentNullException(paramName: nameof(mapper));

            Mapper = mapper;
        }
        /// <summary>
        /// Gets the <see cref="IMapper"/> instance used to perform actions being tested.
        /// </summary>
        protected IMapper Mapper { get; private init; }

        /// <summary>
        /// Verify a DTO instance mapped from an entity instance has all built-in mapped
        /// properties equal to the source. Complex members and collections of complex members are
        /// ignored.
        /// </summary>
        public abstract void Dto_MapFrom_Entity_MappedProperties_AreEqual();

        /// <summary>
        /// Verify an entity instance mapped from a DTO instance has all mapped properties equal 
        /// to the source.
        /// </summary>
        public abstract void Entity_MapFrom_Dto_MappedProperties_AreEqual();
    }
}
