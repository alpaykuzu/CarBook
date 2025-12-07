using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Queries.GetLastBlogsWithAuthors
{
    public class GetLastBlogsWithAuthorsQueryRequest : IRequest<List<GetLastBlogsWithAuthorsQueryResponse>>
    {
        public int Number { get; set; }

        public GetLastBlogsWithAuthorsQueryRequest(int number)
        {
            Number = number;
        }
    }
}
