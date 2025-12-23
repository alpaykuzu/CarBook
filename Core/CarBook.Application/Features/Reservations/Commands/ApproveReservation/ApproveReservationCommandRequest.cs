using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reservations.Commands.ApproveReservation
{
    public class ApproveReservationCommandRequest : IRequest
    {
        public int ReservationID { get; set; }

        public ApproveReservationCommandRequest(int reservationID)
        {
            ReservationID = reservationID;
        }
    }
}
