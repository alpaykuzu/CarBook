using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest>
    {
        private readonly IRepository<Location> _repository;
        private readonly IStatisticsHubService _statisticsHubService;

        public CreateLocationCommandHandler(IRepository<Location> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }

        public async Task Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = new Location
            {
                Name = request.Name
            };
            await _repository.CreateAsync(location);
            var value = await _repository.GetCountAsync();
            await _statisticsHubService.SendLocationCountAsync(value);
        }
    }
}
