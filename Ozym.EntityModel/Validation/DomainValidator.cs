﻿using System.ComponentModel.DataAnnotations;

namespace Ozym.EntityModel.Validation
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

        protected virtual bool ModelIsValidDel(object model, out IList<string> errors)
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new(model);

            bool isValid = Validator.TryValidateObject(model, context, results);

            errors = results.Where(r => !string.IsNullOrEmpty(r.ErrorMessage))
                .Select(r => r.ErrorMessage!).ToList();

            return isValid;
        }
    }
}
