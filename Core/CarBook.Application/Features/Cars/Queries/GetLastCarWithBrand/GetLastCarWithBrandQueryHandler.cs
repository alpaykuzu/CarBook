using CarBook.Application.Features.Cars.Queries.GetCarWithBrand;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetLastCarWithBrand
{
    public class GetLastCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLastCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetLastCarWithBrandQueryResponse>> Handle(GetLastCarWithBrandQueryRequest query)
        {
            var cars = await _repository.GetLastCarsListWithBrandAsync(query.Number);
            return cars.Select(car => new GetLastCarWithBrandQueryResponse
            {
                CarID = car.CarID,
                BrandID = car.BrandID,
                BrandName = car.Brand.Name,
                Model = car.Model,
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
