using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Queries.GetByBlogIdTagCloud
{
    public class GetByBlogIdTagCloudQueryHandler : IRequestHandler<GetByBlogIdTagCloudQueryRequest, List<GetByBlogIdTagCloudQueryResponse>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetByBlogIdTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetByBlogIdTagCloudQueryResponse>> Handle(GetByBlogIdTagCloudQueryRequest request, CancellationToken cancellationToken)
        {
            var tagClouds = await _repository.GetAllAsync(x => x.BlogID == request.BlogID);
            return tagClouds.Select(tc => new GetByBlogIdTagCloudQueryResponse
            {
                TagCloudID = tc.TagCloudID,
                Title = tc.Title,
                BlogID = tc.BlogID
            }).ToList();
        }
    }
}
