using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SharedLibrary
{
    public class RegistrationData : ModelBase
    {
        [RequiredRule]
        [MaxLengthRule(50)]
        public String FirstName { get; set; }

        [RequiredRule]
        [MaxLengthRule(50)]
        public String LastName { get; set; }

        [EmailRule]
        public String Email { get; set; }

        [PhoneRule]
        public String Phone { get; set; }

    }
}
