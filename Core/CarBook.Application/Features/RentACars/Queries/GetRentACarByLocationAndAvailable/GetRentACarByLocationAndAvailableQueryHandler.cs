using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var result = await repository.GetQueryable()
                .Include(c => c.Car).ThenInclude(b => b.Brand)
                .Include(c => c.Car).ThenInclude(cp => cp.CarPricings).ThenInclude(p => p.Pricing)
                .Where(f => f.IsAvailable == true && f.LocationID == request.LocationID).ToListAsync();

            return result.Select(x => new GetRentACarByLocationAndAvailableQueryResponse
            {
                RentACarID = x.RentACarID,
                CarID = x.CarID,
                BrandID = x.Car.BrandID,
                BrandName = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                PricingName = "Günlük",
                PricingAmount = x.Car.CarPricings.FirstOrDefault(pricing => pricing.Pricing.Name == "Günlük").Amount.ToString()
            }).ToList();
        }
    }
}
