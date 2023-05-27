using System;

namespace NjordinSight.Web.Components.Shared
{
    public class MenuRoot : MenuItem
    {
        public MenuRoot() : base(isRoot: true)
        {
            MenuGuid = Guid.NewGuid();
        }

        public Guid MenuGuid { get; init; }
    }
}
