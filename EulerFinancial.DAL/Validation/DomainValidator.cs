using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EulerFinancial.Extensions;
using EulerFinancial.Resources;

namespace EulerFinancial.Validation
{

    class DomainValidator : IDomainValidator
    {
        protected delegate bool ModelIsValidFunc(object model, out IList<string> errors);
        protected ModelIsValidFunc modelValidationDelegate;

        public DomainValidator()
        {
            modelValidationDelegate = new ModelIsValidFunc(ModelIsValidDel);
        }

        public bool ModelIsValid(object model, out IList<string> errors)
        {
            if (modelValidationDelegate is null)
            {
                throw new InvalidOperationException($"Could not find value for '{nameof(modelValidationDelegate)}'");
            }

            return modelValidationDelegate(model, out errors);
        }

        public string GetModelGeneralValidationFailedMessage<T>(IEnumerable<string> validationErrors)
        {
            var nounMetadata = ResourceHelper.GetNounMetadata($"Model.{typeof(T).Name}");

            string msg = string.Format("{0} {1}",
                nounMetadata?.SingularArticle?.ToTitleCase(),
                nounMetadata?.Singular ?? typeof(T).Name);

            string errors = string.Join("\n", validationErrors);
            return validationErrors?.Count() > 0 ? $"{msg}\n\r\n\r{errors}" : msg;
        }

        protected virtual bool ModelIsValidDel(object model, out IList<string> errors)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new(model);

            bool isValid = Validator.TryValidateObject(model, context, results);

            errors = results.Select(r => r.ErrorMessage).ToList();

            return isValid;
        }
    }
}
