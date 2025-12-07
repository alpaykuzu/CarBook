using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Queries.GetAllTagCloud
{
    public class GetAllTagCloudQueryHandler : IRequestHandler<GetAllTagCloudQueryRequest, List<GetAllTagCloudQueryResponse>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetAllTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllTagCloudQueryResponse>> Handle(GetAllTagCloudQueryRequest request, CancellationToken cancellationToken)
        {
            var tagClouds = await _repository.GetAllAsync();
            return tagClouds.Select(tc => new GetAllTagCloudQueryResponse
            {
                TagCloudID = tc.TagCloudID,
                Title = tc.Title,
                BlogID = tc.BlogID
            }).ToList();
        }
    }
}
