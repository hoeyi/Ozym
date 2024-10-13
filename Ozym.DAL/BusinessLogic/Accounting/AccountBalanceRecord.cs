﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozym.BusinessLogic.Accounting
{
    public record AccountBalanceRecord
    {
        public int AccountId { get; init; }

        public string DisplayName { get; init; }

        public float? Balance { get; init; }

        public DateTime? AsOfDate { get; init; }
    }
}
