using System;
using System.Collections.Generic;
using bicycles.Models;
using bicycles.ViewModels;
using Xamarin.Forms;

namespace bicycles.Views
{
    public partial class ClientsPage : ContentPage
    {
        UsersViewModel viewModel;

        public ClientsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UsersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Users.Count == 0)
                viewModel.LoadUsersCommand.Execute(null);
        }
    }
}
