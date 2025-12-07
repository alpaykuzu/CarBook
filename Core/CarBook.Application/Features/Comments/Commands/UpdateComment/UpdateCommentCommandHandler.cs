using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.CommentID);
            if (comment == null)
                throw new Exception("Pricing not found");

            comment.Name = request.Name;
            comment.CreatedDate = request.CreatedDate;
            comment.Content = request.Content;
         
            await _repository.UpdateAsync(comment);
        }
    }
}
