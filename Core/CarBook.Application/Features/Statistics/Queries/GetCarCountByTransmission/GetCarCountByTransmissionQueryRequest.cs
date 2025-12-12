using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarCountByTransmission
{
    public class GetCarCountByTransmissionQueryRequest : IRequest<GetCarCountByTransmissionQueryResponse>
    {
        public string TransmissionType { get; set; }

        public GetCarCountByTransmissionQueryRequest(string transmissionType)
        {
            TransmissionType = transmissionType;
        }
    }
}
