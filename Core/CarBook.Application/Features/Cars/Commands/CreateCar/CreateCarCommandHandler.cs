using CarBook.Application.Features.Brands.Commands.CreateBrand;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IStatisticsHubService _carHubService;

        public CreateCarCommandHandler(IRepository<Car> repository, IStatisticsHubService carHubService)
        {
            _repository = repository;
            _carHubService = carHubService;
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
            var value = await _repository.GetCountAsync();
            await _carHubService.SendCarCountAsync(value);
            await _carHubService.SendMostBrandUpdateNotification();
            await _carHubService.SendCarCountByKmUpdateNotification();
            await _carHubService.SendCarCountByFuelUpdateNotification();
            await _carHubService.SendCarModelAndBrandMaxOrMinDailyPriceUpdateNotification();
            await _carHubService.SendAutomaticCarCountUpdateNotification();
        }
    }
}
