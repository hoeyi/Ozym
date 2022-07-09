using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using NjordFinance.ModelMetadata.Resources;
using System.Globalization;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Validation attribute that requires decorated members to have an exact <see cref="int"/> 
    /// or <see cref="double"/> value.
    /// </summary>
    public class ExactValueAttribute : ValidationAttribute
    {
        private readonly string _errorMessage;

        /// <summary>
        /// Creates a new instance of <see cref="ExactValueAttribute" /> for an <see cref="int"/> 
        /// require value.
        /// </summary>
        /// <param name="value">The required value.</param>
        /// <param name="errorMessage">The validation error message or template.</param>
        /// <param name="ErrorMessageResourceName">The name of the string resource or the template.</param>
        /// <param name="ErrorMessageResourceType">The type containing <paramref name="ErrorMessageResourceName"/>.</param>
        public ExactValueAttribute(
            int value,
            string errorMessage = null,
            string ErrorMessageResourceName = null,
            Type ErrorMessageResourceType = null) :
            this (errorMessage, ErrorMessageResourceName, ErrorMessageResourceType)
        {
            RequiredValue = value;
            OperandType = typeof(int);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExactValueAttribute" /> for a <see cref="double"/> 
        /// require value.
        /// </summary>
        /// <param name="value">The required value.</param>
        /// <param name="errorMessage">The validation error message or template.</param>
        /// <param name="ErrorMessageResourceName">The name of the string resource or the template.</param>
        /// <param name="ErrorMessageResourceType">The type containing <paramref name="ErrorMessageResourceName"/>.</param>
        public ExactValueAttribute(
            double value, 
            string errorMessage = null,
            string ErrorMessageResourceName = null,
            Type ErrorMessageResourceType = null) :
            this (errorMessage, ErrorMessageResourceName, ErrorMessageResourceType)
        {
            RequiredValue = value;
            OperandType = typeof(double);
        }


        private ExactValueAttribute(
            string errorMessage = null,
            string ErrorMessageResourceName = null,
            Type ErrorMessageResourceType = null)
        {
            errorMessage ??= "{0} must be equal to {1}.";

            if (string.IsNullOrEmpty(ErrorMessageResourceName) || ErrorMessageResourceType is null)
                _errorMessage = errorMessage;
            else
            {
                ResourceManager rm = new(resourceSource: ErrorMessageResourceType);
                _errorMessage = rm.GetString(ErrorMessageResourceName);
            }
        }

        /// <summary>
        /// Gets the required value for the member.
        /// </summary>
        public object RequiredValue { get; private set; }

        /// <summary>
        /// Gets the type of the <see cref="RequiredValue"/>, e.g., <see cref="int"/> or 
        /// <see cref="double"/>.
        /// </summary>
        public Type OperandType { get; private set; }

        private Func<object, object> Conversion { get; set; }

        public override bool IsValid(object value)
        {
            // Set-up the converter, if not already defined.
            if(Conversion is null)
                SetupConverter();

            // Used RequiredAttribute to test for empty, if applicable.
            if (value is null)
                return true;

            // Try to convert the given value.
            object convertedValue = null;

            try
            {
                convertedValue = Conversion(value);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }

            // Test the converted value against the required value.
            IComparable requiredValue = (IComparable)RequiredValue;

            return requiredValue.CompareTo(convertedValue) == 0;
        }

        public override string FormatErrorMessage(string name)
            => string.Format(CultureInfo.CurrentCulture, _errorMessage, name, RequiredValue);
        
        /// <summary>
        /// Initializes the <see cref="RequiredValue"/> and <see cref="Conversion"/> members.
        /// </summary>
        /// <param name="requiredValue"></param>
        /// <param name="conversion"></param>
        private void Initialize(IComparable requiredValue, Func<object, object> conversion)
        {
            RequiredValue = requiredValue;
            Conversion = conversion;
        }
        
        /// <summary>
        /// Configures the <see cref="Conversion"/> and <see cref="RequiredValue" /> members 
        /// based on the <see cref="OperandType"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void SetupConverter()
        {
            if (OperandType == typeof(int))
                Initialize((int)RequiredValue, v => Convert.ToInt32(v, CultureInfo.InvariantCulture));
            else if (OperandType == typeof(double))
                Initialize((double)RequiredValue, v => Convert.ToDouble(v, CultureInfo.InvariantCulture));
            else
                throw new InvalidOperationException(
                    message: ModelValidation.ExactValueAttribute_OperandType_MustBeSet);
        }

    }
}
