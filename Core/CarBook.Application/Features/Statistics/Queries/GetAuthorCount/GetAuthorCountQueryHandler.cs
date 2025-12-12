using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetAuthorCount
{
    internal class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQueryRequest, GetAuthorCountQueryResponse>
    {
        private readonly IRepository<Author> repository;

        public GetAuthorCountQueryHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task<GetAuthorCountQueryResponse> Handle(GetAuthorCountQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await repository.GetCountAsync();
            return new GetAuthorCountQueryResponse
            {
                AuthorCount = count,
            };
        }
    }
}
