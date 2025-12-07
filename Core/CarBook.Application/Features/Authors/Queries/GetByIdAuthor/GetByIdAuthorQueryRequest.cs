using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Authors.Queries.GetByIdAuthor
{
    public class GetByIdAuthorQueryRequest : IRequest<GetByIdAuthorQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdAuthorQueryRequest(int id)
        {
            Id = id;
        }
    }
}
