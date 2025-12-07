using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Authors.Commands.RemoveAuthor
{
    public class RemoveAuthorCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveAuthorCommandRequest(int id)
        {
            Id = id;
        }
    }
}
