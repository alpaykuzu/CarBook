using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.SocialMedias.Queries.GetByIdSocialMedia
{
    public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQueryRequest, GetByIdSocialMediaQueryResponse>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetByIdSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdSocialMediaQueryResponse> Handle(GetByIdSocialMediaQueryRequest request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.Id);
            if (socialMedia == null)
                return null; 
            
            return new GetByIdSocialMediaQueryResponse
            {
                SocialMediaID = socialMedia.SocialMediaID,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Icon = socialMedia.Icon
            };
        }
    }
}
