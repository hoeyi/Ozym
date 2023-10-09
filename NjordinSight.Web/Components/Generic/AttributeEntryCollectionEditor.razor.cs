using NjordinSight.EntityModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System;
using NjordinSight.DataTransfer.Common.Generic;
using NjordinSight.EntityModelService.Query;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModel.ConstraintType;
using NjordinSight.Web.Components.Common;
using NjordinSight.DataTransfer.Common;
using NjordinSight.DataTransfer.Common.Collections;
using NjordinSight.Web.Services;
using NjordinSight.DataTransfer.Common.Query;
using System.Net.Http;

namespace NjordinSight.Web.Components.Generic
{
    /// <summary>
    /// Base component for pages responsible for performaning CRUD operations on a collection 
    /// of <typeparamref name="TModelChild"/> as children of <typeparamref name="TModel"/> using 
    /// <typeparamref name="TViewModelParent"/> and <typeparamref name="TViewModelChild"/> view models.
    /// </summary>
    /// <typeparam name="TViewModelParent">The view model representing the 
    /// <typeparamref name="TModel"/> entity.</typeparam>
    /// <typeparam name="TViewModelChild">The view model that is a grouping of 
    /// <typeparamref name="TModelChild"/> entries.</typeparam>
    /// <typeparam name="TModel">The entity that is parent of this attribute entry collection.
    /// </typeparam>
    /// <typeparam name="TModelChild">The entity that represents a single entry in this collection.
    /// </typeparam>
    public partial class AttributeEntryCollectionEditor<
        TViewModelParent, TViewModelChild, TModel, TModelChild>: LocalizableComponent
        where TModel: class, new()
        where TModelChild : class, new()
        where TViewModelChild: IAttributeEntryWeightedGrouping<TModel, TModelChild>
        where TViewModelParent: IAttributeEntryWeightedCollection<TModel, TModelChild, TViewModelChild>
    {
        /// <summary>
        /// Gets or sets <see cref="IQueryService"/> used to query lookup and reference 
        /// data for this component.
        /// </summary>
        [Inject]
        IQueryService QueryService { get; set; }

        /// <summary>
        /// Gets or sets the current <typeparamref name="TViewModelChild"/> instance.
        /// </summary>
        protected TViewModelChild? CurrentViewModelChild { get; set; }

        /// <summary>
        /// Gets or sets the valid entries to the currently selected attribute.
        /// </summary>
        protected IEnumerable<ModelAttributeMemberDto> CurrentAttributeMemberLookup { get; set; }
            = new List<ModelAttributeMemberDto>();

        /// <summary>
        /// Gets or sets the allowable model attributes for this attribute entry view model.
        /// </summary>
        protected IEnumerable<ModelAttributeDto> AllowableModelAttributes { get; set; } =
            new List<ModelAttributeDto>();

        /// <summary>
        /// Gets or sets whether the modal editor for the current <typeparamref name="TViewModelChild"/>  
        /// is drawn. Default is <see cref="false"/>.
        /// </summary>
        protected bool DrawViewModelChildModelEditor { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            if (QueryService is null)
                throw new ArgumentNullException(paramName: nameof(QueryService));

            AllowableModelAttributes = await QueryService.BuiltIn
                                                .GetSupportedAttributesAsync<TViewModelParent>();

            IsLoading = AllowableModelAttributes is null;
        }

        /// <summary>
        /// Adds a new <typeparamref name="TViewModelChild"/> to the <typeparamref name="TViewModelParent"/> 
        /// instance for this component for the given <see cref="ModelAttributeDtoBase"/>.
        /// </summary>
        /// <param name="attributeId"></param>
        /// <returns></returns>
        private void AddEntryForGrouping(int attributeId)
        {
            var forModelAttribute = AllowableModelAttributes.First(x => x.AttributeId == attributeId);

            CurrentViewModelChild = ModelDto.AddNew(forModelAttribute);

            CurrentAttributeMemberLookup = forModelAttribute.AttributeValues;

            DrawViewModelChildModelEditor = 
                CurrentViewModelChild is not null && CurrentAttributeMemberLookup is not null;
        }

        /// <summary>
        /// Moves focus of the omponent to a view for the given <typeparamref name="TViewModelChild"/> 
        /// instance.
        /// </summary>
        /// <param name="childViewModel"></param>
        /// <returns></returns>
        private void OnChildViewSelect(TViewModelChild childViewModel)
        {
            CurrentViewModelChild = childViewModel;
            CurrentAttributeMemberLookup = AllowableModelAttributes
                .First(x => x.AttributeId == childViewModel.ParentAttribute.AttributeId)
                .AttributeValues;

            DrawViewModelChildModelEditor =
                CurrentViewModelChild is not null && CurrentAttributeMemberLookup is not null;
        }

        /// <summary>
        /// Handles the close event of the modal editor form for a 
        /// <typeparamref name="TViewModelChild"/> instance.
        /// </summary>
        /// <param name="modalEventArgs">The event arguments.</param>
        /// <exception cref="NotSupportedException"></exception>
        private void OnModalEditor_ForChildView_Close(
            ModalEventArgs<TViewModelChild> modalEventArgs)
        {
            DrawViewModelChildModelEditor = false;

            switch (modalEventArgs.Result)
            {
                case DialogResult.Delete:
                    if(modalEventArgs.Model is not null)
                        ModelDto.RemoveExising(modalEventArgs.Model);
                    break;
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    throw new NotSupportedException();
            };

            StateHasChanged();
        }

        /// <summary>
        /// Gets or sets whether the modal dialog for selecting an attribute is drawn. Default is
        /// <see cref="false" />.
        /// </summary>
        private bool DrawAttributeSelectorDialog { get; set; } = false;

        /// <summary>
        /// Gets the <see cref="Guid"/> uniquely identifying the form element for this control.
        /// </summary>
        private Guid FormGuid { get; } = Guid.NewGuid();

        /// <summary>
        /// Handles the close event of the modal form used to select a <see cref="ModelAttributeDto"/> 
        /// for adding a new <typeparamref name="TViewModelChild" />.
        /// </summary>
        private void OnModalAttributeSelectorClosed(ModalEventArgs<ModelAttributeDto> modalEventArgs)
        {
            DrawAttributeSelectorDialog = false;

            switch (modalEventArgs.Result)
            {
                case DialogResult.OK:
                    if (modalEventArgs.Model != default)
                        AddEntryForGrouping(modalEventArgs.Model.AttributeId);
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    throw new NotSupportedException();
            }

            // Redraw the component.
            StateHasChanged();
        }
    }
}
