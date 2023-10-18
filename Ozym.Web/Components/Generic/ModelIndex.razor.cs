using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ozym.Web.Components.Common;
using Ozym.UserInterface;
using Ichosys.DataModel;
using Microsoft.AspNetCore.Http;
using Ozym.EntityModelService.Abstractions;
using Ozym.DataTransfer;
using System.Drawing.Drawing2D;
using System.Linq;
using Ozym.EntityModel;
using Ozym.Web.Services;

namespace Ozym.Web.Components.Generic
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
                    Caption = Strings.Caption_CreateNew.Format(ModelNoun?.GetSingular() ?? typeof(TModelDto).Name),
                    UriRelativePath = FormatCreateUri(Guid.NewGuid())
                }
            }
        };
    }
}
