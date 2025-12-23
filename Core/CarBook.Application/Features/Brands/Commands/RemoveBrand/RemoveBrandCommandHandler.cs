using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Brands.Commands.RemoveBrand
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IStatisticsHubService _statisticsHubService;
        public RemoveBrandCommandHandler(IRepository<Brand> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }
        public async Task Handle(RemoveBrandCommandRequest request)
        {
            var brand = await _repository.GetByIdAsync(request.Id);
            if (brand != null)
            {
                await _repository.RemoveAsync(brand);
                var value = await _repository.GetCountAsync();
                await _statisticsHubService.SendBrandCountAsync(value);
            }
        }
    }
}
