using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using bicycles.Services;
using bicycles.Validators;
using bicycles.ViewModels;
using bicycles.Views;
using Xamarin.Forms;

namespace bicycles
{
    public class ReservationsViewModel : BaseViewModel
    {
        public ObservableCollection<Reservation> Reservations { get; set; }
        public Command LoadReservationsCommand { get; set; }
        public IDataStore<Reservation> DataStore;
        public ReservationsViewModel()
        {
            Title = "Rezerwacje";
            DataStore = ReservationDataStore.getInstance();
            Reservations = new ObservableCollection<Reservation>();
            LoadReservationsCommand = new Command(async () => await ExecuteLoadReservationsCommand());

            MessagingCenter.Subscribe<CreateReservationViewModel, Reservation>(this, "AddReservation", (obj, reservation) =>
            {
                var _reservation = reservation as Reservation;
                Reservations.Add(_reservation);
            });
        }


        async Task ExecuteLoadReservationsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Reservations.Clear();
                var reservations = await DataStore.FindAllAsync(true);
                foreach (var reservation in reservations)
                {
                    Reservations.Add(reservation);
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
