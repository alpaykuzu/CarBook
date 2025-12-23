using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.Hubs;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommandRequest>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IStatisticsHubService _statisticsHubService;
        public CreateBlogCommandHandler(IRepository<Blog> repository, IStatisticsHubService statisticsHubService)
        {
            _repository = repository;
            _statisticsHubService = statisticsHubService;
        }
        public async Task Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            Blog blog = new Blog()
            {
                Title = request.Title,
                AuthorID = request.AuthorID,
                CategoryID = request.CategoryID,
                CoverImageUrl = request.CoverImageUrl,
                Description = request.Description,
                CreatedDate = request.CreatedDate,
            };
            await _repository.CreateAsync(blog);
            var value = await _repository.GetCountAsync();
            await _statisticsHubService.SendBlogCountAsync(value);
        }
    }
}
