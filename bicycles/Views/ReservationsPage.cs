using System;

using Xamarin.Forms;

namespace bicycles.Views
{
    public class ReservationsPage : ContentPage
    {
        public ReservationsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

