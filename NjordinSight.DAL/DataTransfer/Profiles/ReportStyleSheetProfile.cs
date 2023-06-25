using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.DataTransfer.Profiles
{
    /// <summary>
    /// Maps report style sheet entities to DTOs and vice versa.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="ReportStyleSheet"/> - <see cref="ReportStyleSheetDto"/></item>
    /// </list>
    /// </remarks>
    public class ReportStyleSheetProfile : Profile
    {
        public ReportStyleSheetProfile()
        {
            #region Entity-DTO
            CreateMap<ReportStyleSheet, ReportStyleSheetDto>();
            #endregion

            #region DTO-Entity
            CreateMap<ReportStyleSheetDto, ReportStyleSheet>();
            #endregion
        }
    }
}
