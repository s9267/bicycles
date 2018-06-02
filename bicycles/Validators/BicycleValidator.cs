using System;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
namespace bicycles.Validators
{

    public class BicycleValidator : BaseValidator
    {
        public static bool Validate(Bicycle bicycle)
        {
            return (ValidateNotNullOrEmptyString(bicycle.Name)
                    && ValidateUrlImage(bicycle.Picture)
                    && ValidatePrice(bicycle.Price));
        }

        private static bool ValidateUrlImage(string url)
        {
            if (url == null || String.IsNullOrEmpty(url))
                return false;
            try
            {
                var req = WebRequest.Create(url);
                req.Method = "HEAD";
                using (var resp = req.GetResponse())
                    return resp.ContentType.ToLower(CultureInfo.InvariantCulture).StartsWith("image/", StringComparison.CurrentCulture);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ValidatePrice(decimal price) {
            return price > 0;
        }
    }
}
