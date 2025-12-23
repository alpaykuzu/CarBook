using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int CarID { get; set; }
        public int ReservationID { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropUpLocationID { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly DropOffDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        public TimeOnly DropOffTime { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public Car Car { get; set; }
        public Reservation Reservation { get; set; }
    }
}
