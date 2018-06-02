using System;
using System.Collections.Generic;
using bicycles.ViewModels;
using Xamarin.Forms;

namespace bicycles.Views
{
    public partial class ReservationDetailPage : ContentPage
    {

        public ReservationDetailsViewModel viewModel;

        public ReservationDetailPage()
        {
            InitializeComponent();

            viewModel = new ReservationDetailsViewModel(new Reservation());
            BindingContext = viewModel;
        }

        public ReservationDetailPage(ReservationDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
