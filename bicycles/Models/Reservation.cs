using System;
using bicycles.Models;

namespace bicycles
{
    public class Reservation
    {
        public string Id { get; set; }
        public Bicycle Bicycle { get; set; }
        public User User { get; set; }
        public int Days { get; set; }


        public decimal Price { get { return Days * Bicycle.Price; } }
    }
}
