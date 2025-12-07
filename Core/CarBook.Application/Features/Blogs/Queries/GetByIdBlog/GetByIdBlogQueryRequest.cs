using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetByIdBlog
{
    public class GetByIdBlogQueryRequest : IRequest<GetByIdBlogQueryResponse>   
    {
        public int Id { get; set; }

        public GetByIdBlogQueryRequest(int id)
        {
            Id = id;
        }
    }
}
