using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedLibrary
{
    public class EmailRule : Attribute, IModelRule
    {
        public ValidationResult Validate(string fieldName, object fieldValue)
        {
            var message = "Valid email address is required";
            if (fieldValue == null) { return new ValidationResult() { IsValid = false, Message = message }; }

            if (Regex.IsMatch(fieldValue.ToString(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
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
