using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetBlogCount
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQueryRequest, GetBlogCountQueryResponse>
    {
        private readonly IRepository<Blog> repository;

        public GetBlogCountQueryHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }

        public async Task<GetBlogCountQueryResponse> Handle(GetBlogCountQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await repository.GetCountAsync();
            return new GetBlogCountQueryResponse
            {
                BlogCount = count,
            };
        }
    }
}
