using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetAllBlog
{
    public class GetAllBlogQueryRequest : IRequest<List<GetAllBlogQueryResponse>>
    {
    }
}
