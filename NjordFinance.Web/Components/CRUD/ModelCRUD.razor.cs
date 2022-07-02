using System;
using System.Linq;
using System.Reflection;

namespace NjordFinance.Web.Components.CRUD
{
    /// <summary>
    /// Represents a component for presentingd the user a form for creating, reading, 
    /// updated, or deleting a single model instance.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class ModelCRUD<TModel> : LocalizableComponent
    {
        protected string[] GetEditableMemberNames() =>
            typeof(TModel).GetProperties()
                .Where(p => p.GetGetMethod() is not null && p.GetSetMethod() is not null)
                .Select(p => p.Name)
                .ToArray();
    }
}
