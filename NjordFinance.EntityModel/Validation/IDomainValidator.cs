﻿using System.Collections.Generic;

namespace NjordFinance.EntityModel.Validation
{
    public interface IDomainValidator
    {
        bool ModelIsValid(object model, out IList<string> validationErrors);
    }
}