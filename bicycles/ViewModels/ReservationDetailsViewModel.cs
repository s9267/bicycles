using System;
namespace bicycles.ViewModels
{
    public class ReservationDetailsViewModel : BaseViewModel
    {
        public Reservation Reservation { get; set; }
        public ReservationDetailsViewModel(Reservation reservation = null)
        {
            Title = reservation?.User.Name;
            Reservation = reservation;
        }
    }
}
