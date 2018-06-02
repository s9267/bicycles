using System;
using System.Text.RegularExpressions;

namespace bicycles.Validators
{
    public class BaseValidator
    {
        public BaseValidator()
        {
        }

        protected static bool ValidateString(string value, string pattern)
        {
            if (value == null || String.IsNullOrEmpty(value))
                return false;
            else if (Regex.IsMatch(value, pattern))
                return true;
            else
                return false;
        }

        protected static bool ValidateNotNullOrEmptyString(string value)
        {
            return !String.IsNullOrEmpty(value);
        }
    }
}
