using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest>
    {
        private readonly IRepository<Author> _repository;

        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            Author author = new Author
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Description = request.Description
            };
            await _repository.CreateAsync(author);
        }
    }
}
