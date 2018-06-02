using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace bicycles.Validators.Behaviors
{
    public class NameValidationBehavior : BaseValidationBehavior
    {

        public const string namePattern = "^[A-Za-z0-9-._ ]{3,25}$";

        protected override void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var name = e.NewTextValue;
            var nameEntry = sender as Entry;

            if (Regex.IsMatch(name, namePattern)) {
                nameEntry.BackgroundColor = Color.Transparent;
            }
            else {
                nameEntry.BackgroundColor = Color.Red;
            }
        }
    }
}
