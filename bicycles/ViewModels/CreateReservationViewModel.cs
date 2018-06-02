using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using bicycles.Models;
using bicycles.Services;
using bicycles.Validators;
using Xamarin.Forms;

namespace bicycles.ViewModels
{
    public class CreateReservationViewModel : BaseViewModel
    {

        public ObservableCollection<Bicycle> Bicycles { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public Reservation Reservation { get; set; }
        public IDataStore<Bicycle> BicycleDS = BicycleDataStore.getInstance();
        public IDataStore<Reservation> ReservationDS = ReservationDataStore.getInstance();
        public Command LoadDataCommand { get; set; }
        public UserServices userServices = new UserServices();
        public CreateReservationViewModel()
        {
            Bicycles = new ObservableCollection<Bicycle>();
            Users = new ObservableCollection<User>();
            Reservation = new Reservation();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());
        }

        public async Task RetrieveUsers()
        {
            var users = await userServices.GetAll();
            Users.Clear();

            foreach (User user in users)
            {
                Users.Add(user);
            }
        }

        async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Bicycles.Clear();
                var bicycles = await BicycleDS.FindAllAsync(true);
                foreach (var bicycle in bicycles)
                {
                    Bicycles.Add(bicycle);
                }

                await RetrieveUsers();


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

        public Command SaveReservationCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (ReservationValidator.Validate(Reservation))
                    {
                        await ReservationDS.AddAsync(Reservation);
                        MessagingCenter.Send(this, "AddReservation", Reservation);
                        await Application.Current.MainPage.DisplayAlert("Zapisano!", "Nowa rezerwacja została utworzona", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Błąd!", "Dane rezerwacji są niepoprawne", "OK");
                    }
                });
            }
        }
    }
}