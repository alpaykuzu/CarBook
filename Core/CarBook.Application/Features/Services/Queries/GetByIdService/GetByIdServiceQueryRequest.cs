using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Services.Queries.GetByIdService
{
    public class GetByIdServiceQueryRequest : IRequest<GetByIdServiceQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdServiceQueryRequest(int id)
        {
            Id = id;
        }
    }
}
