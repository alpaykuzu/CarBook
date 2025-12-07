using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Queries.GetAllComment
{
    public class GetAllCommentQueryRequest : IRequest<List<GetAllCommentQueryResponse>>
    {
    }
}
