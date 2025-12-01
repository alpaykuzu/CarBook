using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetAllCar
{
    public class GetAllCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetAllCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetAllCarQueryResponse>> Handle()
        {
            var cars = await _repository.GetAllAsync();
            return cars.Select(car => new GetAllCarQueryResponse
            {
                CarID = car.CarID,
                BrandID = car.BrandID,
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
