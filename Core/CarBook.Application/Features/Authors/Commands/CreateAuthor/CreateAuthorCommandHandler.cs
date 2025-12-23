using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
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
        private readonly IStatisticsHubService _statisticsHubService;

        public CreateAuthorCommandHandler(IRepository<Author> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }

        public async Task Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            Author author = new Author
            {
                AppUserID = request.AppUserID,
                ImageUrl = request.ImageUrl,
                Description = request.Description
            };
            await _repository.CreateAsync(author);
            var value = await _repository.GetCountAsync();
            await _statisticsHubService.SendAuthorCountAsync(value);
        }
    }
}
