using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ichosys.DataModel.Expressions;
using NjordinSight.DataTransfer.Common.Query;

namespace NjordinSight.DataTransfer.Profiles
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
