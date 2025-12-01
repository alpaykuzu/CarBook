using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommandRequest command)
        {
            var category = await _repository.GetByIdAsync(command.CategoryID);
            if (category == null)
                throw new Exception("Category not found");

            category.Name = command.Name;
            await _repository.UpdateAsync(category);
        }
    }
}
