using CarBook.Application.Features.Abouts.Queries.GetAllAbout;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Banners.Queries.GetAllBanner
{
    public class GetAllBannerQueryHandler
    {
        private readonly IRepository<Banner> _repositories;

        public GetAllBannerQueryHandler(IRepository<Banner> repositories)
        {
            _repositories = repositories;
        }
        public async Task<IEnumerable<GetAllBannerQueryResponse>> Handle()
        {
            var banners = await _repositories.GetAllAsync();
            return banners.Select(a => new GetAllBannerQueryResponse
            {
                BannerID = a.BannerID,
                Title = a.Title,
                Description = a.Description,
                VideoDescription = a.VideoDescription,
                VideoUrl = a.VideoUrl
            }).ToList();
        }
    }
}
