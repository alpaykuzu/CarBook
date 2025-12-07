using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetByIdBlog
{
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQueryRequest, GetByIdBlogQueryResponse>
    {
        private readonly IRepository<Blog> _repository;
        public GetByIdBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdBlogQueryResponse> Handle(GetByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
                return null;
            
            return new GetByIdBlogQueryResponse
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                Description = blog.Description,
                AuthorID = blog.AuthorID,
                CategoryID = blog.CategoryID,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate
            };
        }
    }
}
