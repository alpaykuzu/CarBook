using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetByIdBlogWithAuthor
{
    public class GetByIdBlogWithAuthorQueryRequest : IRequest<GetByIdBlogWithAuthorQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdBlogWithAuthorQueryRequest(int id)
        {
            Id = id;
        }
    }
}
