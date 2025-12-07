using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Queries.GetByBlogIdTagCloud
{
    public class GetByBlogIdTagCloudQueryRequest : IRequest<List<GetByBlogIdTagCloudQueryResponse>>
    {
        public int BlogID { get; set; }

        public GetByBlogIdTagCloudQueryRequest(int blogID)
        {
            BlogID = blogID;
        }
    }
}
