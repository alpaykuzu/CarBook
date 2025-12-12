using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarOrderByKm
{
    public class GetCarCountByKmQueryHandler : IRequestHandler<GetCarCountByKmQueryRequest, GetCarCountByKmQueryResponse>
    {
        private readonly IRepository<Car> repository;

        public GetCarCountByKmQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCarCountByKmQueryResponse> Handle(GetCarCountByKmQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await repository.GetQueryable()
                .Where(k => k.Km < request.TopKm)
                .CountAsync();

            return new GetCarCountByKmQueryResponse
            {
                CarCount = count
            };
        }
    }
}
