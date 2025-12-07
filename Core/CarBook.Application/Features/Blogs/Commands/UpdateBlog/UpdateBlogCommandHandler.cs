using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommandRequest>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.BlogID);
            if (blog == null)
                throw new Exception("Blog not found");
            
            blog.Title = request.Title;
            blog.AuthorID = request.AuthorID;
            blog.CategoryID = request.CategoryID;
            blog.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(blog);
        }
    }
}
