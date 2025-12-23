using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int AppUserID { get; set; }
        public int CarID { get; set; }
        public int? PickUpLocationID { get; set; }
        public int? DropOffLocationID { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly DropOffDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        public TimeOnly DropOffTime { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public Car Car { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public AppUser AppUser { get; set; }
        public Rental Rental { get; set; }
    }
}
