using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IStatisticsHubService _statisticsHubService;

        public CreateBrandCommandHandler(IRepository<Brand> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }
        public async Task Handle(CreateBrandCommandRequest request)
        {
            var brand = new Brand
            {
                Name = request.Name,
            };
            await _repository.CreateAsync(brand);
            var value = await _repository.GetCountAsync();
            await _statisticsHubService.SendBrandCountAsync(value);
        }
    }
}
