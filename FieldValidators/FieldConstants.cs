using System;
using System.Collections.Generic;
using System.Text;

namespace IqraPearls.FieldValidators
{
   public class FieldConstants
    {
        public enum UserRegistrationField
        { 
            EmailAddress,
            FirstName,
            LastName,
            Password,
            PasswordCompare,
            PhoneNumber,
            Address,
            AddressCity,
            Required,
            PostCode
        }
    }
}