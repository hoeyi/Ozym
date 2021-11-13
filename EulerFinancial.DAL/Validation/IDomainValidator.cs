using System.Collections.Generic;

namespace EulerFinancial.Validation
{
    public interface IDomainValidator
    {
        bool ModelIsValid(object model, out IList<string> validationErrors);

        string GetModelGeneralValidationFailedMessage<T>(IEnumerable<string> validationErrors);
    }
}
