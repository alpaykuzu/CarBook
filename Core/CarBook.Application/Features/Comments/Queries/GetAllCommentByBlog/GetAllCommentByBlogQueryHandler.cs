using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Queries.GetAllCommentByBlog
{
    public class GetAllCommentByBlogQueryHandler : IRequestHandler<GetAllCommentByBlogQueryRequest, List<GetAllCommentByBlogQueryResponse>>
    {
        private readonly IRepository<Comment> _repository;

        public GetAllCommentByBlogQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllCommentByBlogQueryResponse>> Handle(GetAllCommentByBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllAsync(c => c.BlogID == request.BlogID);
            return comments.Select(x => new GetAllCommentByBlogQueryResponse
            {
                BlogID = x.BlogID,
                CommentID = x.CommentID,
                Content = x.Content,
                Email = x.Email,
                CreatedDate = x.CreatedDate,
                Name = x.Name,
            }).ToList();
        }
    }
}
