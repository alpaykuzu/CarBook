using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Rentals.Queries.GetRentalByAppUser
{
    public class GetRentalByAppUserQueryRequest : IRequest<List<GetRentalByAppUserQueryResponse>>
    {
        public int AppUserID { get; set; }

        public GetRentalByAppUserQueryRequest(int appUserID)
        {
            AppUserID = appUserID;
        }
    }
}
