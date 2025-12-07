using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Queries.GetByIdTagCloud
{
    public class GetByIdTagCloudQueryHandler : IRequestHandler<GetByIdTagCloudQueryRequest, GetByIdTagCloudQueryResponse>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetByIdTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdTagCloudQueryResponse> Handle(GetByIdTagCloudQueryRequest request, CancellationToken cancellationToken)
        {
            var tagCloud = await _repository.GetByIdAsync(request.Id);
            if (tagCloud == null)
                return null;
            
            return new GetByIdTagCloudQueryResponse
            {
                TagCloudID = tagCloud.TagCloudID,
                Title = tagCloud.Title,
                BlogID = tagCloud.BlogID
            };
        }
    }
}
