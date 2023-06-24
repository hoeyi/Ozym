using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordinSight.Test.DataTransfer.Mapping
{
    public abstract class ProfileBaseTest
    {
        public ProfileBaseTest(MapperConfiguration configuration)
        {
            if (configuration is null)
                throw new ArgumentNullException(paramName: nameof(configuration));

            Configuration = configuration;

            Mapper = new Mapper(Configuration);
        }

        protected MapperConfiguration Configuration { get; private init; }

        protected IMapper Mapper { get; private init; }
        
    }
}
