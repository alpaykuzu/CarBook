using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetByIdCar
{
    public class GetByIdCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetByIdCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdCarQueryResponse> Handle(GetByIdCarQueryRequest query)
        {
            var car = await _repository.GetByIdAsync(query.Id);
            if (car is null)
                return null;

            return new GetByIdCarQueryResponse
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
            };
        }
    }
}
