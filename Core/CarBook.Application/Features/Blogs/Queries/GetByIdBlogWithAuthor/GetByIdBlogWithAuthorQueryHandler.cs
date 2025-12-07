using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetByIdBlogWithAuthor
{
    public class GetByIdBlogWithAuthorQueryHandler : IRequestHandler<GetByIdBlogWithAuthorQueryRequest, GetByIdBlogWithAuthorQueryResponse>
    {
        private readonly IBlogRepository _blogRepository;

        public GetByIdBlogWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetByIdBlogWithAuthorQueryResponse> Handle(GetByIdBlogWithAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetByIdBlogWithAuthorAsync(request.Id);
            return new GetByIdBlogWithAuthorQueryResponse
            {
                BlogID = blogs.BlogID,
                Title = blogs.Title,
                Description = blogs.Description,
                AuthorID = blogs.AuthorID,
                AuthorName = blogs.Author.Name,
                CategoryID = blogs.CategoryID,
                CategoryName = blogs.Category.Name,
                CoverImageUrl = blogs.CoverImageUrl,
                CreatedDate = blogs.CreatedDate,
                AuthorDescription = blogs.Author.Description,
                AuthorImageUrl = blogs.Author.ImageUrl
            };
        }
    }
}
