using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public interface IModelRule
    {
        ValidationResult Validate(String fieldName, object fieldValue);
    }
}
