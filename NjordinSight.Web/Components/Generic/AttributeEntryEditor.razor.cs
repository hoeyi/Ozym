using Microsoft.AspNetCore.Components;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService;
using NjordinSight.EntityModelService.Query;
using NjordinSight.DataTransfer.Common.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NjordinSight.Web.Components.Common;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.Web.Components.Generic
{
    public partial class AttributeEntryEditor<
        TViewModelParent, TViewModelChild, TModel, TModelChild> : LocalizableComponent
        where TModel : class, new()
        where TModelChild : class, new()
        where TViewModelChild : IAttributeEntryUnweightedGrouping<TModel, TModelChild>
        where TViewModelParent : IAttributeEntryUnweightedCollection<TModel, TModelChild, TViewModelChild>
    {
        /// <summary>
        /// Gets or sets <see cref="IQueryService"/> used to query lookup and reference 
        /// data for this component.
        /// </summary>
        [Inject]
        IQueryService? QueryService { get; set; }

        /// <summary>
        /// Gets or sets the allowable model attributes for this attribute entry view model.
        /// </summary>
        protected IEnumerable<ModelAttributeDto> AllowableModelAttributes { get; set; } =
            new List<ModelAttributeDto>();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            if (QueryService is null)
                throw new ArgumentNullException(paramName: nameof(QueryService));

            AllowableModelAttributes = await QueryService
                                                .GetSupportedAttributesAsync<TViewModelParent>();

            IsLoading = AllowableModelAttributes is null || !AllowableModelAttributes.Any();
        }

        private IEnumerable<ModelAttributeMemberDtoBase> GetAttributeMembers(
            ModelAttributeDtoBase attribute)
            => AllowableModelAttributes
                .FirstOrDefault(x => x.AttributeId == attribute.AttributeId)
                ?.AttributeValues;

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
                    if (modalEventArgs.Model is not null)
                        AddEntryForGrouping(modalEventArgs.Model);
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    throw new NotSupportedException();
            }

            // Redraw the component.
            StateHasChanged();
        }

        /// <summary>
        /// Adds a new <typeparamref name="TViewModelChild"/> to the <typeparamref name="TViewModelParent"/>
        /// instance for this component for the given <see cref="ModelAttributeDto"/>.
        /// </summary>
        /// <param name="forModelAttribute"></param>
        /// <returns></returns>
        protected void AddEntryForGrouping(ModelAttributeDto forModelAttribute)
        {
            ModelDto.AddEntryForGrouping(forModelAttribute);
        }
    }
}
