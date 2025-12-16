using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reservations.Queries.GetAllReservation
{
    public class GetAllReservationQueryRequest : IRequest<List<GetAllReservationQueryResponse>>
    {
    }
}
