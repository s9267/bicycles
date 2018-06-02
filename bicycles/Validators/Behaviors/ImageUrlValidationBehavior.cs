using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace bicycles.Validators.Behaviors
{
    public class ImageUrlValidationBehavior : BaseValidationBehavior {

        public const string namePattern = "/(https?:.*(?:png|jpg))/i";

        protected override void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var name = e.NewTextValue;
            var nameEntry = sender as Entry;

            if (Regex.IsMatch(name, namePattern))
            {
                nameEntry.
                nameEntry.TextColor = Color.Black;
            }
            else
            {
                nameEntry.TextColor = Color.Red;
            }
        }
    }
}
