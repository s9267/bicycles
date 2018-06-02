using System;

using Xamarin.Forms;

namespace bicycles.Views
{
    public class ReservationDetailPage : ContentPage
    {
        public ReservationDetailPage()
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

