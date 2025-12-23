using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var author = await _repository.GetQueryable()
                .Include(u => u.AppUser).Where(x => x.AuthorID == request.Id).FirstOrDefaultAsync();
            if (author == null)
                return null;

            return new GetByIdAuthorQueryResponse
            {
                AuthorID = author.AuthorID,
                AppUserID = author.AppUserID,
                Name = $"{author.AppUser.Name} {author.AppUser.Surname}",
                ImageUrl = author.ImageUrl,
                Description = author.Description,
            };
        }
    }
}
