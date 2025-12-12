using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarOrderByKm
{
    public class GetCarCountByKmQueryRequest : IRequest<GetCarCountByKmQueryResponse>
    {
        public int TopKm { get; set; }

        public GetCarCountByKmQueryRequest(int topKm)
        {
            TopKm = topKm;
        }
    }
}
