using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using bicycles.Validators;
using bicycles.ViewModels;
using Xamarin.Forms;

namespace bicycles
{
    public class BicyclesViewModel : BaseViewModel
    {
        public ObservableCollection<Bicycle> Bicycles { get; set; }
        public Command LoadBicyclesCommand { get; set; }
        public IDataStore<Bicycle> DataStore { get; set; }
        public BicyclesViewModel()
        {
            Title = "Rowery";
            DataStore = BicycleDataStore.getInstance();
            Bicycles = new ObservableCollection<Bicycle>();
            LoadBicyclesCommand = new Command(async () => await ExecuteLoadBicyclesCommand());

            MessagingCenter.Subscribe<CreateBicycleViewModel, Bicycle>(this, "AddBicycle", (obj, bicycle) =>
            {
                var _bicycle = bicycle as Bicycle;
                Bicycles.Add(_bicycle);
            });
        }

        async Task ExecuteLoadBicyclesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Bicycles.Clear();
                var bicycles = await DataStore.FindAllAsync(true);
                foreach (var bicycle in bicycles)
                {
                    Bicycles.Add(bicycle);
                }
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
