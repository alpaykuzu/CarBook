using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Banners.Queries.GetByIdBanner
{
    public class GetByIdBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetByIdBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdBannerQueryResponse> Handle(GetByIdBannerQueryRequest query)
        {
            var banner = await _repository.GetByIdAsync(query.Id);
            if (banner is null)
                return null;
            return new GetByIdBannerQueryResponse
            {
                BannerID = banner.BannerID,
                Description = banner.Description,
                Title = banner.Title,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl
            };
        }
    }
}
