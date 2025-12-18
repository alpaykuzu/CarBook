using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetLastBlogsWithAuthors
{
    public class GetLastBlogsWithAuthorsQueryHandler : IRequestHandler<GetLastBlogsWithAuthorsQueryRequest, List<GetLastBlogsWithAuthorsQueryResponse>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetLastBlogsWithAuthorsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLastBlogsWithAuthorsQueryResponse>> Handle(GetLastBlogsWithAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetLastBlogsWithAuthorsAsync(request.Number);
            return blogs.Select(b => new GetLastBlogsWithAuthorsQueryResponse
            {
                BlogID = b.BlogID,
                Title = b.Title,
                Description = b.Description,
                AuthorID = b.AuthorID,
                AuthorName = b.Author.Name,
                CategoryID = b.CategoryID,
                CategoryName = b.Category.Name,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate,
                AuthorDescription = b.Author.Description,
                AuthorImageUrl = b.Author.ImageUrl,
                CommentCount = b.Comments.Where(x => x.BlogID == b.BlogID).Count()
            }).ToList();
        }
    }
}
