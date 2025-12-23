using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandQuery : IRequest
    {
        public int AppUserID { get; set; }
        public int CarID { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly DropOffDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        public TimeOnly DropOffTime { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
    }
}
