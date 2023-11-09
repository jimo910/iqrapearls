using System;
using System.Collections.Generic;
using System.Text;

namespace IqraPearls.FieldValidators
{
    public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue,  out string fieldInvalidMessage);
    public interface IFieldValidator
    {
        void InitialiseValidatorDelegates();
        string[] FieldArray { get; }
        FieldValidatorDel ValidatorDel { get; }

  
    }
}
