using System;
namespace bicycles.Validators
{
    public class ReservationValidator : BaseValidator
    {
        public static bool Validate(Reservation reservation)
        {
            return (ValidateNotNull(reservation.Bicycle)
                    && ValidateNotNull(reservation.User)
                    && ValidateDays(reservation.Days));
        }


        private static bool ValidateNotNull(Object o)
        {
            return o != null;
        }
    
        private static bool ValidateDays(int i)
        {
            return i > 0;
        }
    }
}
