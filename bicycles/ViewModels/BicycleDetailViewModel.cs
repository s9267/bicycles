using System;
using System.Diagnostics;
using System.Threading.Tasks;
using bicycles.Services;
using Xamarin.Forms;

namespace bicycles
{
    public class BicycleDetailViewModel : BaseViewModel
    {
        public Bicycle Bicycle { get; set; }


        private DownloadImageServices DownloadImageServices = new DownloadImageServices();

        public Command SaveImage { get; set; }
        public BicycleDetailViewModel(Bicycle bicycle = null)
        {
            Title = bicycle?.Name;
            Bicycle = bicycle;
            SaveImage = new Command(async () => await ExecuteSaveImageCommand());
        }

        async Task ExecuteSaveImageCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var image = await DownloadImageServices.GetImage(Bicycle.Picture);
                DependencyService.Get<ISaveImageServices>().Save(Bicycle.Name, image);  
                await Application.Current.MainPage.DisplayAlert("Zapisany", "Plik został zapisany", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
