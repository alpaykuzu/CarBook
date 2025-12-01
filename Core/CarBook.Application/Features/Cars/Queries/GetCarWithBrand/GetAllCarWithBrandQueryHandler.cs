using CarBook.Application.Features.Cars.Queries.GetAllCar;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetCarWithBrand
{
    public class GetAllCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetAllCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetAllCarWithBrandQueryResponse>> Handle()
        {
            var cars = await _repository.GetCarsListWithBrandAsync();
            return cars.Select(car => new GetAllCarWithBrandQueryResponse
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
