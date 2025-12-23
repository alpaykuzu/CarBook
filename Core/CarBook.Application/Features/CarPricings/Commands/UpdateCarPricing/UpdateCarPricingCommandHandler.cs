using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Commands.UpdateCarPricing
{
    public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommandRequest>
    {
        private readonly IRepository<CarPricing> repository;
        private readonly IStatisticsHubService _statisticsHubService;

        public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository, IStatisticsHubService statisticsHubService)
        {
            this.repository = repository;
            _statisticsHubService = statisticsHubService;
        }

        public async Task Handle(UpdateCarPricingCommandRequest request, CancellationToken cancellationToken)
        {
            var carPricing = await repository.GetByIdAsync(request.CarPricingID);
            if (carPricing == null)
            {
                throw new Exception("CarPricing not found for the specified CarID and PricingID.");
            }
            carPricing.PricingID = request.PricingID;
            carPricing.Amount = request.Amount;
            await repository.UpdateAsync(carPricing);
            await _statisticsHubService.SendCarPricingUpdateNotification();
        }
    }
}
