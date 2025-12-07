using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Authors.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, List<GetAllAuthorQueryResponse>>
    {
        private readonly IRepository<Author> _repository;

        public GetAllAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllAuthorQueryResponse>> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();
            return authors.Select(a => new GetAllAuthorQueryResponse
            {
                AuthorID = a.AuthorID,
                Name = a.Name,
                ImageUrl = a.ImageUrl,
                Description = a.Description
            }).ToList();
        }
    }
}
