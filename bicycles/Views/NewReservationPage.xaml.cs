
using System;
using System.Collections.Generic;
using bicycles.Models;
using bicycles.ViewModels;
using Xamarin.Forms;

namespace bicycles.Views
{
    public partial class NewReservationPage : ContentPage
    {
        public CreateReservationViewModel CreateReservationViewModel { get; set; }
        public NewReservationPage()
        {
            BindingContext = CreateReservationViewModel = new CreateReservationViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (CreateReservationViewModel.Users.Count == 0 || 
                CreateReservationViewModel.Bicycles.Count == 0) {
                CreateReservationViewModel.LoadDataCommand.Execute(null);
            }

        }
    }
}
