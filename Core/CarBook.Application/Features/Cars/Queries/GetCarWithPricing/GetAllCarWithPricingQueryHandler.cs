using CarBook.Application.Features.Cars.Queries.GetCarWithBrand;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetCarWithPricing
{
    public class GetAllCarWithPricingQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetAllCarWithPricingQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetAllCarWithPricingQueryResponse>> Handle(GetAllCarWithPricingQueryRequest query)
        {
            var carList = await _repository.GetCarsListWithPricingAsync(query.PricingType);
            return carList.Select(car => new GetAllCarWithPricingQueryResponse
            {
                CarID = car.CarID,
                BrandID = car.BrandID,
                BrandName = car.Brand?.Name ?? string.Empty, 
                Model = car.Model,
                PricingName = car.CarPricings
                    .FirstOrDefault(x => x.Pricing?.Name == query.PricingType)?.Pricing?.Name ?? string.Empty, 
                PricingAmount = car.CarPricings
                    .FirstOrDefault(x => x.Pricing?.Name == query.PricingType)?.Amount.ToString() ?? "0", 
                CoverImageUrl = car.CoverImageUrl,
                Km = car.Km,
                BigImageUrl = car.BigImageUrl,
                Fuel = car.Fuel,
                Luggage = car.Luggage,
                Seat = car.Seat,
                Transmission = car.Transmission
            }); 
        }
    }
}
