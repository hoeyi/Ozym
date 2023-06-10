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
        /// <summary>
        /// Gets or sets the <see cref="IController{TModelDto}"/> for this component.
        /// </summary>
        [Inject]
        protected IController<TModelDto> Controller { get; init; } = default!;

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
        
        /// <summary>
        /// Checks the <see cref="SearchService"/> and <see cref="Controller"/> properties are 
        /// non-null, else throws an <see cref="ArgumentNullException" />.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        protected void CheckNullParameters()
        {
            if (SearchService is null)
                throw new ArgumentNullException(paramName: nameof(SearchService));

            if (Controller is null)
                throw new ArgumentNullException(paramName: nameof(Controller));
        }
                
        /// <inheritdoc/>   
        protected override async Task OnInitializedAsync()
        {
            CheckNullParameters();

            IsLoading = true;

            try
            {
                var refreshEntriesTask = RefreshResultsAsync(
                    predicate: SearchService.CurrentExpression,
                    pageNumber: PaginationHelper.PageIndex,
                    pageSize: PaginationHelper.PageSize);

                await refreshEntriesTask;
            }
            finally
            {
                IsLoading = GetLoadingState();
            }
        }

        /// <inheritdoc/>
        protected override async Task RefreshResultsAsync(
            Expression<Func<TModelDto, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var actionResult = await Controller.SelectAsync(predicate, pageNumber, pageSize);

            Entries = actionResult.Value.Item1;

            PaginationHelper.TotalItemCount = actionResult.Value.Item2.ItemCount;
            PaginationHelper.ItemCount = Entries.Count();
        }
    }
}
