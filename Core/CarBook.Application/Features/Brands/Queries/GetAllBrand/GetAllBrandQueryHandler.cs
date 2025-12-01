using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Queries.GetAllBrand
{
    public class GetAllBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetAllBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllBrandQueryResponse>> Handle()
        {
            var brands = await _repository.GetAllAsync();
            return brands.Select(brand => new GetAllBrandQueryResponse
            {
                BrandID = brand.BrandID,
                Name = brand.Name,
            }).ToList();
        }
    }
}
