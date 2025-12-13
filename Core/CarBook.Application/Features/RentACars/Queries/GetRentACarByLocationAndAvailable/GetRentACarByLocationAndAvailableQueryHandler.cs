using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RentACars.Queries.GetRentACarByLocationAndAvailable
{
    public class GetRentACarByLocationAndAvailableQueryHandler : IRequestHandler<GetRentACarByLocationAndAvailableQueryRequest, List<GetRentACarByLocationAndAvailableQueryResponse>>
    {
        private readonly IRepository<RentACar> repository;

        public GetRentACarByLocationAndAvailableQueryHandler(IRepository<RentACar> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetRentACarByLocationAndAvailableQueryResponse>> Handle(GetRentACarByLocationAndAvailableQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync(r => r.IsAvailable == true && r.LocationID == request.LocationID);
            return result.Select(x => new GetRentACarByLocationAndAvailableQueryResponse
            {
                RentACarID = x.RentACarID,
                CarID = x.CarID,
                IsAvailable = x.IsAvailable,
                LocationID = x.LocationID,
            }).ToList();
        }
    }
}
