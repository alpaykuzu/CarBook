using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetLocationCount
{
    public class GetLocationCountQueryRequest : IRequest<GetLocationCountQueryResponse>
    {
    }
}
