using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Abouts.Commands.UpdateAbout
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommandRequest command)
        {
            var about = await _repository.GetByIdAsync(command.AboutID);
            if (about != null)
            {
                about.Title = command.Title;
                about.Description = command.Description;
                about.ImageUrl = command.ImageUrl;
                await _repository.UpdateAsync(about);
            }
        }
    }
}
