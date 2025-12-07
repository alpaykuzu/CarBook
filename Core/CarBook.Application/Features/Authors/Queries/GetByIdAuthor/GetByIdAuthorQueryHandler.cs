using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Authors.Queries.GetByIdAuthor
{
    public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQueryRequest, GetByIdAuthorQueryResponse>
    {
        private readonly IRepository<Author> _repository;

        public GetByIdAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdAuthorQueryResponse> Handle(GetByIdAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author == null)
                return null;

            return new GetByIdAuthorQueryResponse
            {
                AuthorID = author.AuthorID,
                Name = author.Name,
                ImageUrl = author.ImageUrl,
                Description = author.Description,
            };
        }
    }
}
