using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.SocialMedias.Queries.GetAllSocialMedia
{
    public class GetAllSocialMediaQueryHandler : IRequestHandler<GetAllSocialMediaQueryRequest, List<GetAllSocialMediaQueryResponse>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetAllSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllSocialMediaQueryResponse>> Handle(GetAllSocialMediaQueryRequest request, CancellationToken cancellationToken)
        {
            var socialMedias = await _repository.GetAllAsync();
            return socialMedias.Select(sm => new GetAllSocialMediaQueryResponse
            {
                SocialMediaID = sm.SocialMediaID,
                Name = sm.Name,
                Url = sm.Url,
                Icon = sm.Icon
            }).ToList();
        }
    }
}
