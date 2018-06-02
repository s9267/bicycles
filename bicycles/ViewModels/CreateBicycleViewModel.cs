using System;
using bicycles.Validators;
using Xamarin.Forms;

namespace bicycles.ViewModels
{
    public class CreateBicycleViewModel
    {

        public Bicycle Bicycle { get; set; }
        public IDataStore<Bicycle> BicycleDS = BicycleDataStore.getInstance();


        public CreateBicycleViewModel()
        {
            Bicycle = new Bicycle();
        }

        public Command SaveBicycleCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (BicycleValidator.Validate(Bicycle))
                    {
                        await BicycleDS.AddAsync(Bicycle);
                        MessagingCenter.Send(this, "AddBicycle", Bicycle);
                        await Application.Current.MainPage.DisplayAlert("Zapisano!", "Nowy rower został utworzony", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Błąd!", "Dane rowera są niepoprawne", "OK");
                    }
                });
            }
        }
    }
}
