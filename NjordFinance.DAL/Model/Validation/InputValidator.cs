using System;
using System.Globalization;

namespace NjordFinance.Model.Validation
{
    public static class InputValidator
    {
        /// <summary>
        /// Validates the given string input against the given expected type.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="expectedType">The desintation type to which the string will be converted.</param>
        /// <param name="parsedValue">The resulting object if parsing is successful, else null.</param>
        /// <param name="updateValue">A boolean indicating whether the value should be udpated to ensure the data is commited.</param>
        /// <returns>True if the string 's' was parsed successful or if null (if nullabel type is expected),
        /// else false.</returns>
        /// <exception cref="NotImplementedException">The given type is not supported.</exception>
        public static bool InputIsValid(string s, Type expectedType, out object parsedValue, out bool updateValue)
        {
            Type underlying = Nullable.GetUnderlyingType(expectedType);
            bool isNullable = underlying is not null;
            updateValue = false;
            parsedValue = null;

            // Handle the nullable case. Valid if string is null or empty => set to null.
            if (isNullable && string.IsNullOrEmpty(s))
            {
                return true;
            }
            // Handle the non-nullable case. Valid for nullable types where string is not null or empty.
            else
            {
                bool inputIsValid;
                string typeFullName = (underlying ?? expectedType).FullName;
                switch (typeFullName)
                {
                    case "System.String":
                        inputIsValid = true;
                        parsedValue = s;
                        break;
                    case "System.Int16":
                        inputIsValid = InputValueIsShort(s, out short @short);
                        parsedValue = @short;
                        break;
                    case "System.Int32":
                        inputIsValid = InputValueIsInteger(s, out int @int);
                        parsedValue = @int;
                        break;
                    case "System.Int64":
                        inputIsValid = InputValueIsLong(s, out long @long);
                        parsedValue = @long;
                        break;
                    case "System.Single":
                        inputIsValid = InputValueIsFloat(s, out float @float);
                        parsedValue = @float;
                        break;
                    case "System.Double":
                        inputIsValid = InputValueIsDouble(s, out double @double);
                        parsedValue = @double;
                        break;
                    case "System.Decimal":
                        inputIsValid = InputValueIsDecimal(s, out decimal @decimal);
                        parsedValue = @decimal;
                        break;
                    case "System.Boolean":
                        inputIsValid = InputValueIsBoolean(s, out bool @bool);
                        parsedValue = @bool;
                        break;
                    case "System.DateTime":
                        inputIsValid = InputValueIsDateTime(s, out DateTime dateTime);
                        if (inputIsValid)
                        {
                            parsedValue = dateTime;
                            updateValue = false;
                            break;
                        }
                        else
                        {
                            string[] alternateFormats = new string[3]
                            {
                                "MMddyyyy",
                                "yyyyMMdd",
                                "ddMMyyyy"
                            };
                            inputIsValid =
                                InputValueIsAlternateFormatDateTime(s, alternateFormats, out DateTime altDateTime);
                            parsedValue = altDateTime;
                            updateValue = true;
                            break;
                        }
                    default:
                        throw new NotImplementedException(typeFullName);
                }

                return inputIsValid;
            }

        }
        /// <summary>
        /// Tries to convert the given string to a valid Int16 object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="@short">The Int16 object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the s parameter could be converted, else false.</returns>
        private static bool InputValueIsShort(string s, out short @short)
        {
            if (short.TryParse(s, out short result))
            {
                @short = result;
                return true;
            }
            else
            {
                @short = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid Int32 object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="int">The Int32 object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsInteger(string s, out int @int)
        {
            if (int.TryParse(s, out int result))
            {
                @int = result;
                return true;
            }
            else
            {
                @int = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid Int64 object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="long">The Int64 object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsLong(string s, out long @long)
        {
            if (long.TryParse(s, out long result))
            {
                @long = result;
                return true;
            }
            else
            {
                @long = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid float object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="float">The float object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsFloat(string s, out float @float)
        {
            if (float.TryParse(s, out float result))
            {
                @float = result;
                return true;
            }
            else
            {
                @float = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid double object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="double">The double object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsDouble(string s, out double @double)
        {
            if (double.TryParse(s, out double result))
            {
                @double = result;
                return true;
            }
            else
            {
                @double = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid decimal object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="decimal">The decimal object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsDecimal(string s, out decimal @decimal)
        {
            if (decimal.TryParse(s, out decimal result))
            {
                @decimal = result;
                return true;
            }
            else
            {
                @decimal = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid boolean object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="bool">The boolean object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsBoolean(string s, out bool @bool)
        {
            if (bool.TryParse(s, out bool result))
            {
                @bool = result;
                return true;
            }
            else
            {
                @bool = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid DateTime object.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dateTime">The datetime object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsDateTime(string s, out DateTime @dateTime)
        {
            if (DateTime.TryParse(s, out DateTime result))
            {
                @dateTime = result;
                return true;
            }
            else
            {
                @dateTime = default;
                return false;
            }
        }

        /// <summary>
        /// Tries to convert the given string to a valid DateTime object, given an array of allowable formats.
        /// </summary>
        /// <param name="s">A string to be converted to a datetime object.</param>
        /// <param name="formats">An array of string representations of valid date formats.</param>
        /// <param name="dateTime">The datetime object converted from the string. Default if parsing failed.</param>
        /// <returns>True if the 's' parameter could be converted, else false.</returns>
        private static bool InputValueIsAlternateFormatDateTime(string s, string[] formats, out DateTime @dateTime)
        {
            foreach (string f in formats)
            {
                if (DateTime.TryParseExact(
                    s, f, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime altResult))
                {
                    @dateTime = altResult;
                    return true;
                }
            }
            @dateTime = default;
            return false;
        }
    }
}
