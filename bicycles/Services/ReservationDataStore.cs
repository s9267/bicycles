using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bicycles.Services
{
    public class ReservationDataStore : IDataStore<Reservation>
    {

        private static ReservationDataStore Instance = null;

        static List<Reservation> reservations = new List<Reservation>();

        private ReservationDataStore()
        {
        }

        public static ReservationDataStore getInstance()
        {
            if (Instance == null)
            {
                Instance = new ReservationDataStore();
            }
            return Instance;
        }

        public async Task<bool> AddAsync(Reservation reservation)
        {
            reservation.Id = Guid.NewGuid().ToString();
            reservations.Add(reservation);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var _reservation = reservations.Where((Reservation arg) => arg.Id == id).FirstOrDefault();
            reservations.Remove(_reservation);

            return await Task.FromResult(true);
        }

        public async Task<Reservation> GetAsync(string id)
        {
            return await Task.FromResult(reservations.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Reservation>> FindAllAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(reservations);
        }

        public async Task<bool> UpdateAsync(Reservation reservation)
        {
            var _reservation = reservations.Where((Reservation arg) => arg.Id == reservation.Id).FirstOrDefault();
            reservations.Remove(_reservation);
            reservations.Add(reservation);

            return await Task.FromResult(true);
        }
    }
}
