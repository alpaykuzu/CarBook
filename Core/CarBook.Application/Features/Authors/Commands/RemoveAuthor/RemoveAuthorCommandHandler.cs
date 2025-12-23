using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Authors.Commands.RemoveAuthor
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommandRequest>
    {
        private readonly IRepository<Author> _repository;
        private readonly IStatisticsHubService _statisticsHubService;

        public RemoveAuthorCommandHandler(IRepository<Author> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }

        public async Task Handle(RemoveAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author != null)
            {
                await _repository.RemoveAsync(author);
                var value = await _repository.GetCountAsync();
                await _statisticsHubService.SendAuthorCountAsync(value);
            }
                
        }
    }
}
