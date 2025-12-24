using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reservations.Queries.GetReservationByUserApp
{
    public class GetReservationByUserAppQueryRequest : IRequest<List<GetReservationByUserAppQueryResponse>>
    {
        public int AppUserID { get; set; }

        public GetReservationByUserAppQueryRequest(int appUserID)
        {
            AppUserID = appUserID;
        }
    }
}
