using System;
using System.Globalization;
using System.Windows.Controls;

namespace BussinessSolution
{
    public class RequiredValidator : ValidationRule
    {
        public string ErrorMessage { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty(value as String))
            {
                return new ValidationResult(false, ErrorMessage);
            }
            return new ValidationResult(true, String.Empty);
        }

  
    }
}
