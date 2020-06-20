using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ValidationInterface;

namespace EmailValidation
{
    public class EmailValidator : ValidationRule, IValidation
    {
        public string Name
        {
            get
            {
                return "Email validation";
            }
        }

        public string Description
        {
            get
            {
                return "Invalid email address";
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string email = (string)value;
                if(!email.Contains('@')) return new ValidationResult(false, $"{Description}");
                if (!email.Contains('.')) return new ValidationResult(false, $"{Description}");
                int index1 = email.LastIndexOf('@');
                if (index1 != email.IndexOf('@')) return new ValidationResult(false, $"{Description}");
                int index2 = email.LastIndexOf('.');
                if(index1 > index2) return new ValidationResult(false, $"{Description}");

            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"{e.Message}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
