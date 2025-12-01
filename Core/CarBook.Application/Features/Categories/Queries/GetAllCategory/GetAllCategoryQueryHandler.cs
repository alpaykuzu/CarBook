using CarBook.Application.Features.Cars.Queries.GetAllCar;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetAllCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetAllCategoryQueryResponse>> Handle()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(c => new GetAllCategoryQueryResponse
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
        }
    }
}
