using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Queries.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQueryRequest, List<GetAllCommentQueryResponse>>
    {
        private readonly IRepository<Comment> _repository;

        public GetAllCommentQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllCommentQueryResponse>> Handle(GetAllCommentQueryRequest request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllAsync();
            return results.Select(c => new GetAllCommentQueryResponse
            {
                BlogID = c.BlogID,
                CommentID = c.CommentID,
                Content = c.Content,
                Email = c.Email,
                CreatedDate = c.CreatedDate,
                Name = c.Name
            }).ToList();
        }
    }
}
