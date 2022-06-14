using System;

namespace NjordFinance.Web.Components.Shared
{
    public class Menu : MenuItem
    {
        public Guid MenuGuid { get; set; } = Guid.NewGuid();
    }
}
