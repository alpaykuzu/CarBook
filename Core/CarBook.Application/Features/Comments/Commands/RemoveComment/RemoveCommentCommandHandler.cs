using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Commands.RemoveComment
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommandRequest>
    {
        private readonly IRepository<Comment> _repository;

        public RemoveCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if (comment == null) 
                return;

            await _repository.RemoveAsync(comment);
        }
    }
}
