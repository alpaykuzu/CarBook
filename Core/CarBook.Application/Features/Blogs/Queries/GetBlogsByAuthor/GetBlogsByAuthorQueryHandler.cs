using CarBook.Application.Features.Blogs.Queries.GetByIdBlogWithAuthor;
using CarBook.Application.Features.Blogs.Queries.GetLastBlogsWithAuthors;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetBlogsByAuthor
{
    public class GetBlogsByAuthorQueryHandler : IRequestHandler<GetBlogsByAuthorQueryRequest, List<GetBlogsByAuthorQueryResponse>>
    {
        private readonly IRepository<Blog> repository;

        public GetBlogsByAuthorQueryHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetBlogsByAuthorQueryResponse>> Handle(GetBlogsByAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = await repository.GetQueryable()
                .Include(a => a.Author).ThenInclude(u => u.AppUser)
                .Include(c => c.Category)
                .Where(x => x.Author.AppUserID == request.AppUserID)
                .ToListAsync();

            return blogs.Select(b => new GetBlogsByAuthorQueryResponse
            {
                BlogID = b.BlogID,
                Title = b.Title,
                Description = b.Description,
                AuthorID = b.AuthorID,
                AuthorName = $"{b.Author.AppUser.Name} {b.Author.AppUser.Surname}",
                CategoryID = b.CategoryID,
                CategoryName = b.Category.Name,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate,
                AuthorDescription = b.Author.Description,
                AuthorImageUrl = b.Author.ImageUrl,
            }).ToList();
        }
    }
}
