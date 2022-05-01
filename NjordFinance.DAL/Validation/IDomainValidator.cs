using System.Collections.Generic;

namespace NjordFinance.Validation
{
    public interface IDomainValidator
    {
        bool ModelIsValid(object model, out IList<string> validationErrors);
    }
}
