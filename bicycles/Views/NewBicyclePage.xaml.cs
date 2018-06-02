using System;
using bicycles.ViewModels;
using Xamarin.Forms;

namespace bicycles
{
    public partial class NewBicyclePage : ContentPage
    {
        CreateBicycleViewModel viewModel;

        public NewBicyclePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CreateBicycleViewModel();
        }
    }
}
