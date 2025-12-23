using CarBook.Application.Features.Brands.Commands.RemoveBrand;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Commands.RemoveCar
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IStatisticsHubService _carHubService;
        public RemoveCarCommandHandler(IRepository<Car> repository, IStatisticsHubService carHubService)
        {
            _repository = repository;
            _carHubService = carHubService;
        }
        public async Task Handle(RemoveCarCommandRequest request)
        {
            var brand = await _repository.GetByIdAsync(request.Id);
            if (brand != null)
            {
                await _repository.RemoveAsync(brand);
                var value = await _repository.GetCountAsync();
                await _carHubService.SendCarCountAsync(value);
                await _carHubService.SendAutomaticCarCountUpdateNotification();
                await _carHubService.SendMostBrandUpdateNotification();
                await _carHubService.SendCarCountByKmUpdateNotification();
                await _carHubService.SendCarCountByFuelUpdateNotification();
                await _carHubService.SendCarModelAndBrandMaxOrMinDailyPriceUpdateNotification();
            }
        }
    }
}
