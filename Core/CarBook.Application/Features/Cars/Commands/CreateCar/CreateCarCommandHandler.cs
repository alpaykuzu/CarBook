using CarBook.Application.Features.Brands.Commands.CreateBrand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommandRequest request)
        {
            var car = new Car
            {
                BrandID = request.BrandID,
                Model = request.Model,
                CoverImageUrl = request.CoverImageUrl,
                Km = request.Km,
                BigImageUrl = request.BigImageUrl,
                Fuel = request.Fuel,
                Luggage = request.Luggage,
                Seat = request.Seat,
                Transmission = request.Transmission
            };
            await _repository.CreateAsync(car);
        }
    }
}
