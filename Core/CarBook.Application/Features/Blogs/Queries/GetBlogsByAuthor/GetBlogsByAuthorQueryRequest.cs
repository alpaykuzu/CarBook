using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetBlogsByAuthor
{
    public class GetBlogsByAuthorQueryRequest : IRequest<List<GetBlogsByAuthorQueryResponse>>
    {
        public int AppUserID { get; set; }

        public GetBlogsByAuthorQueryRequest(int appUserID)
        {
            AppUserID = appUserID;
        }
    }
}
