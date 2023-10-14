using AutoMapper;
using Ichosys.DataModel.Expressions;
using Ozym.DataTransfer.Common.Query;

namespace Ozym.DataTransfer.Profiles
{
    /// <summary>
    /// Defines mapping of <see cref="QueryParameter{TModel}"/> to <see cref="ParameterDto{T}"/>. 
    /// </summary>
    public class ParameterProfile : Profile
    {
        public ParameterProfile()
        {
            CreateMap(typeof(ParameterDto<>), typeof(IQueryParameter<>));

            CreateMap(typeof(IQueryParameter<>), typeof(ParameterDto<>));
        }
    }
}
