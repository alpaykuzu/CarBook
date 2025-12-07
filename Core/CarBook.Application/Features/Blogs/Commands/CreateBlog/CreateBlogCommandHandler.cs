using CarBook.Application.Interfaces;
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
        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            Blog blog = new Blog()
            {
                Title = request.Title,
                AuthorID = request.AuthorID,
                CategoryID = request.CategoryID,
                CoverImageUrl = request.CoverImageUrl
            };
            await _repository.CreateAsync(blog);
        }
    }
}
