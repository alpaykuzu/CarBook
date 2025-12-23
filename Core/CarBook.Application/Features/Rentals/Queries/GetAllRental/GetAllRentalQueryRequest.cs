using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Rentals.Queries.GetAllRental
{
    public class GetAllRentalQueryRequest : IRequest<List<GetAllRentalQueryResponse>>
    {
    }
}
