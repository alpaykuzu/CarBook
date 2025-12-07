using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Authors.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest : IRequest<List<GetAllAuthorQueryResponse>>
    {
    }
}
