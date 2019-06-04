using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class MaxLengthRule : Attribute, IModelRule
    {
        private int _maxLength = 0;
        public MaxLengthRule(int maxLength) { _maxLength = maxLength; }

        public ValidationResult Validate(string fieldName, object fieldValue)
        {
            var message = $"Cannot be longer than {_maxLength} characters";
            if (fieldValue == null) { return new ValidationResult() { IsValid = true }; }

            var stringvalue = fieldValue.ToString();
            if (stringvalue.Length > _maxLength )
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
