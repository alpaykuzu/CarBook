using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Abouts.Commands.CreateAbout
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAboutCommandRequest command)
        {
            var about = new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            };
            await _repository.CreateAsync(about);
        }
    }
}
