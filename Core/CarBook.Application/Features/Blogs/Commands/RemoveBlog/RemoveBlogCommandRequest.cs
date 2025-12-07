using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Commands.RemoveBlog
{
    public class RemoveBlogCommandRequest :IRequest
    {
        public int Id { get; set; }

        public RemoveBlogCommandRequest(int id)
        {
            Id = id;
        }
    }
}
