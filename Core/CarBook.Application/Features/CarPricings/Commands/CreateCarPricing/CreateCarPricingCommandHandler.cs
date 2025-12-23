using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Commands.CreateCarPricing
{
    public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommandRequest>
    {
        private readonly IRepository<CarPricing> repository;
        private readonly IStatisticsHubService _statisticsHubService;

        public CreateCarPricingCommandHandler(IRepository<CarPricing> repository, IStatisticsHubService statisticsHubService)
        {
            this.repository = repository;
            _statisticsHubService = statisticsHubService;
        }

        public async Task Handle(CreateCarPricingCommandRequest request, CancellationToken cancellationToken)
        {
            var carPricing = new CarPricing
            {
                CarID = request.CarID,
                PricingID = request.PricingID,
                Amount = request.Amount,
            };
            await repository.CreateAsync(carPricing);
            await _statisticsHubService.SendCarPricingUpdateNotification();
        }
    }
}
