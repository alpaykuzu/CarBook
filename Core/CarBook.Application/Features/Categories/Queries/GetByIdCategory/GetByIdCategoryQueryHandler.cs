using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;
        public GetByIdCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest query)
        {
            var category = await _repository.GetByIdAsync(query.Id);
            if (category == null)
                return null; 

            return new GetByIdCategoryQueryResponse
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            };
        }
    }
}
