using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace bicycles
{
    public partial class BicyclesPage : ContentPage
    {
        BicyclesViewModel viewModel;

        public BicyclesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BicyclesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var bicycle = args.SelectedItem as Bicycle;
            if (bicycle == null)
                return;

            await Navigation.PushAsync(new BicycleDetailPage(new BicycleDetailViewModel(bicycle)));

            // Manually deselect item
            BicyclesListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewBicyclePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Bicycles.Count == 0)
                viewModel.LoadBicyclesCommand.Execute(null);
        }
    }
}
