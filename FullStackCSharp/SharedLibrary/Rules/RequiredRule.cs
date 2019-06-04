using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class RequiredRule : Attribute, IModelRule
    {
        public ValidationResult Validate(string fieldName, object fieldValue)
        {
            var message = $"Required";
            if (fieldValue == null) { return new ValidationResult() { IsValid = false, Message=message }; }

            if (String.IsNullOrWhiteSpace(fieldValue.ToString()))
            {
                return new ValidationResult() { IsValid = false, Message = message };
            }
            else
            {
                return new ValidationResult() { IsValid = true };
            }
        }
    }
}
