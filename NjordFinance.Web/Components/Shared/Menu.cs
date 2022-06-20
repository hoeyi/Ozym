using System;

namespace NjordFinance.Web.Components.Shared
{
    public class Menu : MenuItem
    {
        public Menu()
        {
            IsRoot = true;
        }

        public Guid MenuGuid { get; set; } = Guid.NewGuid();
    }
}
