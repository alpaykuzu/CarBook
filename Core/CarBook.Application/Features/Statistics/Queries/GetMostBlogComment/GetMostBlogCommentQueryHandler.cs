using CarBook.Application.Features.Statistics.Queries.GetMostCarBrand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetMostBlogComment
{
    public class GetMostBlogCommentQueryHandler : IRequestHandler<GetMostBlogCommentQueryRequest, GetMostBlogCommentQueryResponse>
    {
        private readonly IRepository<Comment> repository;

        public GetMostBlogCommentQueryHandler(IRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<GetMostBlogCommentQueryResponse> Handle(GetMostBlogCommentQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await repository.GetQueryable()
                .GroupBy(c => new { c.BlogID, c.Blog.Title })
                .Select(g => new
                {
                    BlogTitle = g.Key.Title,
                    CommentCount = g.Count()
                })
                .OrderByDescending(x => x.CommentCount)
                .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
            {
                return new GetMostBlogCommentQueryResponse
                {
                    BlogTitle = "Veri bulunamadı"
                };
            }

            return new GetMostBlogCommentQueryResponse
            {
                BlogTitle = result.BlogTitle
            };
        }
    }
}
