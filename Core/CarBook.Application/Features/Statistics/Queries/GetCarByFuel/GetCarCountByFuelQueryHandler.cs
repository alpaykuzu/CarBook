using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarByFuel
{
    internal class GetCarCountByFuelQueryHandler : IRequestHandler<GetCarCountByFuelQueryRequest, GetCarCountByFuelQueryResponse>
    {
        private readonly IRepository<Car> repository;

        public GetCarCountByFuelQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCarCountByFuelQueryResponse> Handle(GetCarCountByFuelQueryRequest request, CancellationToken cancellationToken)
        {
            var cars = await repository.GetAllAsync(f => f.Fuel == request.FuelType);
            var count = cars.Count();
            return new GetCarCountByFuelQueryResponse
            {
                CarCount = count,
            };
        }
    }
}
