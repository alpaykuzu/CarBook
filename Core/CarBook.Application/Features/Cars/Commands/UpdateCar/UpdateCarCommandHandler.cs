using CarBook.Application.Features.Brands.Commands.UpdateBrand;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IStatisticsHubService _carHubService;
        public UpdateCarCommandHandler(IRepository<Car> repository, IStatisticsHubService carHubService)
        {
            _repository = repository;
            _carHubService = carHubService;
        }
        public async Task Handle(UpdateCarCommandRequest request)
        {
            var car = await _repository.GetByIdAsync(request.CarID);
            if (car != null)
            {
                car.BrandID = request.BrandID;
                car.Model = request.Model;
                car.CoverImageUrl = request.CoverImageUrl;
                car.Km = request.Km;
                car.Transmission = request.Transmission;
                car.Seat = request.Seat;
                car.Luggage = request.Luggage;
                car.Fuel = request.Fuel;
                car.BigImageUrl = request.BigImageUrl;
                await _repository.UpdateAsync(car);
                await _carHubService.SendMostBrandUpdateNotification();
                await _carHubService.SendCarCountByKmUpdateNotification();
                await _carHubService.SendCarCountByFuelUpdateNotification();
                await _carHubService.SendCarModelAndBrandMaxOrMinDailyPriceUpdateNotification();
                await _carHubService.SendAutomaticCarCountUpdateNotification();
            }
        }
    }
}
