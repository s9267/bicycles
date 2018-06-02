using System;
using bicycles.Services;
using Xamarin.Forms;

namespace bicycles
{
    public partial class BicycleDetailPage : ContentPage
    {
        BicycleDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public BicycleDetailPage()
        {
            //InitializeComponent();

            //var bicycle = new Bicycle
            //{
            //    Name = "Example Bicycle",
            //};

            //viewModel = new ItemDetailViewModel(bicycle);
            //BindingContext = viewModel;
        }

        public BicycleDetailPage(BicycleDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
