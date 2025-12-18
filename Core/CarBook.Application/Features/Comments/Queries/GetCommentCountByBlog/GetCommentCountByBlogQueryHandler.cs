using CarBook.Application.Features.Comments.Queries.GetAllCommentByBlog;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Comments.Queries.GetCommentCountByBlog
{
    public class GetCommentCountByBlogQueryHandler : IRequestHandler<GetCommentCountByBlogQueryRequest, GetCommentCountByBlogQueryResponse>
    {
        private readonly IRepository<Comment> repository;

        public GetCommentCountByBlogQueryHandler(IRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCommentCountByBlogQueryResponse> Handle(GetCommentCountByBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var comments = await repository.GetAllAsync(c => c.BlogID == request.BlogId);
            return new GetCommentCountByBlogQueryResponse
            {
                CommentCount = comments.Count
            };
        }
    }
}
