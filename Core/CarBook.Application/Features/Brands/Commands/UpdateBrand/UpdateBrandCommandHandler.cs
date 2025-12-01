using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommandRequest request)
        {
            var brand = await _repository.GetByIdAsync(request.BrandID);
            if (brand != null)
            {
                brand.Name = request.Name;
                await _repository.UpdateAsync(brand);
            }
        }   
    }
}
