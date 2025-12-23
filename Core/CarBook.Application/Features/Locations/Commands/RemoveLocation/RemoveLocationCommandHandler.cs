using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Commands.RemoveLocation
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommandRequest>
    {
        private readonly IRepository<Location> _repository;
        private readonly IStatisticsHubService _statisticsHubService;

        public RemoveLocationCommandHandler(IRepository<Location> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }

        public async Task Handle(RemoveLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id);
            if (location != null)
            {
                await _repository.RemoveAsync(location);
                var value = await _repository.GetCountAsync();
                await _statisticsHubService.SendLocationCountAsync(value);
            }            
        }
    }
}
