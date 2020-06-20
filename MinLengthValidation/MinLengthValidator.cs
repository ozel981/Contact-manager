using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ValidationInterface;

namespace MinLengthValidation
{
    public class MinTextLength : ValidationRule, IValidation
    {
        public string Name
        {
            get
            {
                return "Min text length";
            }
        }

        public string Description
        {
            get
            {
                return "Text is too short";
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (((string)value).Length < 5) return new ValidationResult(false, $"{Description}");
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"{e.Message}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
