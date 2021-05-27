using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(ValidationResult result)
        {
            ValidationErrors = new List<string>();

            foreach (var error in result.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
        public List<string> ValidationErrors { get; set; }


    }
}
