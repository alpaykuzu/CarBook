using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetAllBlog
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest, List<GetAllBlogQueryResponse>>
    {
        private readonly IRepository<Blog> _repository;
        public GetAllBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogQueryResponse>> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAllAsync();
            return blogs.Select(blog => new GetAllBlogQueryResponse
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                Description = blog.Description, 
                AuthorID = blog.AuthorID,
                CategoryID = blog.CategoryID,
                CoverImageUrl = blog.CoverImageUrl
            }).ToList();
        }
    }
}
