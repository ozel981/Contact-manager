using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ValidationInterface;

namespace PhoneValidation
{
    public class PhoneValidator : ValidationRule, IValidation
    {
        public string Name
        {
            get
            {
                return "Phone validation";
            }
        }

        public string Description
        {
            get
            {
                return "Invalid phone number";
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string phone = (string)value;
                char[] separators = { '-' };
                string[] splitPhone = phone.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if(splitPhone.Length != 3) return new ValidationResult(false, $"{Description}");
                for (int i = 0; i < 3; i++)
                {
                    if (splitPhone[i].Length != 3) return new ValidationResult(false, $"{Description}");
                    int number;
                    try
                    {
                        number = int.Parse(splitPhone[i]);
                    }
                    catch
                    {
                        return new ValidationResult(false, $"{Description}");
                    }
                }


            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"{e.Message}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
