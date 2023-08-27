using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordinSight.Web.Components.Common;
using NjordinSight.UserInterface;
using NjordinSight.Web.Controllers;
using Ichosys.DataModel;
using Microsoft.AspNetCore.Http;
using NjordinSight.EntityModelService.Abstractions;
using NjordinSight.DataTransfer;
using System.Drawing.Drawing2D;
using System.Linq;
using NjordinSight.EntityModel;
using NjordinSight.Web.Services;

namespace NjordinSight.Web.Components.Generic
{
    /// <summary>
    /// A component for interacting with a model index.
    /// </summary>
    public partial class ModelIndex<TModelDto> : ModelPagedIndex<TModelDto>
        where TModelDto : class, new()
    {
        /// <inheritdoc/>
        protected override MenuRoot CreateSectionNavigationMenu() => new()
        {
            Children = new()
            {
                new MenuItem()
                {
                    IconKey = "create",
                    Caption = Strings.Caption_CreateNew.Format(ModelNoun.GetSingular()),
                    UriRelativePath = FormatCreateUri(Guid.NewGuid())
                }
            }
        };
    }
}
