using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Authors.Commands.RemoveAuthor
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommandRequest>
    {
        private readonly IRepository<Author> _repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author != null)
                await _repository.RemoveAsync(author);
        }
    }
}
