using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        public GetByIdBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request)
        {
            var brand = await _repository.GetByIdAsync(request.Id);
            if (brand == null)
            {
                return null; 
            }
            return new GetByIdBrandQueryResponse
            {
                BrandID = brand.BrandID,
                Name = brand.Name,
            };
        }
    }
}
