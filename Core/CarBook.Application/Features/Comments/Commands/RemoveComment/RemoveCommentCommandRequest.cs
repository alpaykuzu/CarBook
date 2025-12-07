using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Commands.RemoveComment
{
    public class RemoveCommentCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveCommentCommandRequest(int id)
        {
            Id = id;
        }
    }
}
