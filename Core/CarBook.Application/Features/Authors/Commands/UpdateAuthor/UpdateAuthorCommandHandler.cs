using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.AuthorID);
            if (author == null)
                throw new Exception("Author not found");
            
            author.AuthorID = request.AuthorID;
            author.ImageUrl = request.ImageUrl;
            author.Description = request.Description;
            await _repository.UpdateAsync(author);
        }
    }
}
