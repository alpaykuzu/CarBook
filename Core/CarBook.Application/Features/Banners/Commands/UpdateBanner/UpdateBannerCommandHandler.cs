using CarBook.Application.Features.Abouts.Commands.UpdateAbout;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommandRequest command)
        {
            var banner = await _repository.GetByIdAsync(command.BannerID);
            if (banner != null)
            {
                banner.Title = command.Title;
                banner.Description = command.Description;
                banner.VideoDescription = command.VideoDescription;
                banner.VideoUrl = command.VideoUrl;
                await _repository.UpdateAsync(banner);
            }
        }
    }
}
