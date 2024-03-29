﻿using AutoMapper;
using Ozym.EntityModel;
using Ozym.DataTransfer.Common;

namespace Ozym.DataTransfer.Profiles
{
    /// <summary>
    /// Maps report configuration entities to DTOs and vice versa.
    /// </summary>
    /// <remarks>The default constructor for this profile applies the following mappings:
    /// <list type="bullet">
    /// <item><see cref="ReportConfiguration"/> - <see cref="ReportConfigurationDto"/></item>
    /// </list>
    /// </remarks>
    public class ReportConfigurationProfile : Profile
    {
        public ReportConfigurationProfile()
        {
            #region Entity-DTO
            CreateMap<ReportConfiguration, ReportConfigurationDto>();
            #endregion

            #region DTO-Entity
            CreateMap<ReportConfigurationDto, ReportConfiguration>();
            #endregion
        }
    }
}
