using System.Collections.Generic;

namespace NjordFinance.Model.Validation
{
    public interface IDomainValidator
    {
        bool ModelIsValid(object model, out IList<string> validationErrors);
    }
}
