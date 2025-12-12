using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarCountByTransmission
{
    public class GetCarCountByTransmissionQueryHandler : IRequestHandler<GetCarCountByTransmissionQueryRequest, GetCarCountByTransmissionQueryResponse>
    {
        private readonly IRepository<Car> repository;

        public GetCarCountByTransmissionQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCarCountByTransmissionQueryResponse> Handle(GetCarCountByTransmissionQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await repository.GetQueryable()
                .Where(t => t.Transmission == request.TransmissionType)
                .CountAsync();
            return new GetCarCountByTransmissionQueryResponse
            {
                CarCount = count
            };
        }
    }
}
