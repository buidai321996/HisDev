using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using DeveloperModules.Vadilation;

namespace DeveloperModules.Vadilation
{
    class RequiredValidationRule : ValidationRule
    {
        public string FieldName { get; set; }
        public static string GetErrorMessage(string fieldName, object fieldValue, object nullValue = null)
        {
            string errorMessage = string.Empty;
            if (nullValue != null && nullValue.Equals(fieldValue))
                errorMessage = string.Format("You cannot leave the {0} field empty.", fieldName);
            if (fieldValue == null || string.IsNullOrEmpty(fieldValue.ToString()))
                errorMessage = string.Format("You cannot leave the {0} field empty.", fieldName);
            switch (fieldName)
            {

                case "Mail":
                    if (fieldValue == null || string.IsNullOrEmpty(fieldValue.ToString()))
                        errorMessage = string.Format("You cannot leave the {0} field empty.", fieldName);
                    else
                    if (ValidationEmail((string)fieldValue) == false)
                    {
                        return errorMessage = string.Format("You cannot leave the {0} field email .", fieldName);
                    }

                    break;
                case "Number":
                    if (fieldValue == null || string.IsNullOrEmpty(fieldValue.ToString()))
                        errorMessage = string.Format("You cannot leave the {0} field empty.", fieldName);
                    else
                    if (ValidationNumber((string)fieldValue) == false)
                    {
                        return errorMessage = string.Format("You cannot leave the {0} field email .", fieldName);
                    }

                    break;
            }
            return errorMessage;
        }

        private static bool ValidationNumber(string fieldValue)
        {
            string pattern = @"[0-9]";
            if (Regex.IsMatch(fieldValue, pattern))
            {
                return true;
            }
            return false;
        }

        private static bool ValidationEmail(string fieldValue)
        {
            string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}";
            if (Regex.IsMatch(fieldValue, pattern))
            {
                return true;
            }
            return false;

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string error = GetErrorMessage(FieldName, value);
            if (!string.IsNullOrEmpty(error))
                return new ValidationResult(false, error);
            return ValidationResult.ValidResult;
        }
    }
}
