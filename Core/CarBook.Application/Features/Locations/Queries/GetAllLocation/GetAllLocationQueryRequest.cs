using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Queries.GetAllLocation
{
    public class GetAllLocationQueryRequest : IRequest<List<GetAllLocationQueryResponse>>
    {
    }
}
