using CarBook.Application.Features.Brands.Commands.RemoveBrand;
using CarBook.Application.Interfaces;
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
        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarCommandRequest request)
        {
            var brand = await _repository.GetByIdAsync(request.Id);
            if (brand != null)
                await _repository.RemoveAsync(brand);
        }
    }
}
