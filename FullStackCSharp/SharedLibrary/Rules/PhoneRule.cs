using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedLibrary
{
    public class PhoneRule : Attribute, IModelRule
    {
        public ValidationResult Validate(string fieldName, object fieldValue)
        {
            var message = "Valid phone number is required";
            if (fieldValue == null) { return new ValidationResult() { IsValid = false, Message = message }; }

            if (Regex.IsMatch(fieldValue.ToString(), @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase))
            {
                return new ValidationResult() { IsValid = true };
            }
            else
            {
                return new ValidationResult() { IsValid = false, Message = message };
            }
        }
    }
}
