using System;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace bicycles.Validators
{
    public class Validator
    {

        public static bool ValidateReservation(string name)
        {
            return ValidateString(name, RegexPatterns.teamNamePattern);
        }
    }
}
}
