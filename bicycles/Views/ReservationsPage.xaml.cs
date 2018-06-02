using System;
using System.Collections.Generic;
using bicycles.ViewModels;
using Xamarin.Forms;

namespace bicycles.Views
{
    public partial class ReservationsPage : ContentPage
    {
        ReservationsViewModel ReservationsViewModel;

        public ReservationsPage()
        {
            InitializeComponent();
            BindingContext = ReservationsViewModel = new ReservationsViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewReservationPage());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var reservation = args.SelectedItem as Reservation;
            if (reservation == null)
                return;

            await Navigation.PushAsync(new ReservationDetailPage(new ReservationDetailsViewModel(reservation)));

            // Manually deselect item
            ReservationsListView.SelectedItem = null;
        }

    }
}
