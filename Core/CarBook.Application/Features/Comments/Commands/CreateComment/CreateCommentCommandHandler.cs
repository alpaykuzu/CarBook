using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IStatisticsHubService _statisticsHubService;

        public CreateCommentCommandHandler(IRepository<Comment> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }

        public async Task Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Name = request.Name,
                Email = request.Email,
                BlogID = request.BlogID,
                Content = request.Content,
                CreatedDate = request.CreatedDate
            };
            await _repository.CreateAsync(comment);
            await _statisticsHubService.SendMostBlogWithCommentUpdateNotification();
        }
    }
}
