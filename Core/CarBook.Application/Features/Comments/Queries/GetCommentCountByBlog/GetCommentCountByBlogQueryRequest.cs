using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Queries.GetCommentCountByBlog
{
    public class GetCommentCountByBlogQueryRequest : IRequest<GetCommentCountByBlogQueryResponse>
    {
        public int BlogId { get; set; }

        public GetCommentCountByBlogQueryRequest(int blogId)
        {
            BlogId = blogId;
        }
    }
}
