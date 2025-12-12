using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Queries.GetAllCommentByBlog
{
    public class GetAllCommentByBlogQueryRequest : IRequest<List<GetAllCommentByBlogQueryResponse>>
    {
        public int BlogID { get; set; }

        public GetAllCommentByBlogQueryRequest(int blogID)
        {
            BlogID = blogID;
        }
    }
}
