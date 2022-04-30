using System;

namespace EulerFinancial.Web.Components.Shared
{
    public class Menu : AppMenuItem
    {
        public Guid MenuGuid { get; set; } = Guid.NewGuid();
    }
}
