﻿using System;

namespace Ozym.Web.Components.Common;

public class MenuRoot : MenuItem
{
    public MenuRoot() : base(isRoot: true)
    {
        MenuGuid = Guid.NewGuid();
    }

    public Guid MenuGuid { get; init; }
}
