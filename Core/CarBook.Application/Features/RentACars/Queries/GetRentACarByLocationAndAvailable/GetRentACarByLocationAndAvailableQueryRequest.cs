using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RentACars.Queries.GetRentACarByLocationAndAvailable
{
    public class GetRentACarByLocationAndAvailableQueryRequest : IRequest<List<GetRentACarByLocationAndAvailableQueryResponse>>
    {
        public int LocationID { get; set; }

        public GetRentACarByLocationAndAvailableQueryRequest(int locationID)
        {
            LocationID = locationID;
        }
    }
}
