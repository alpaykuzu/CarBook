using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Queries.GetByIdTagCloud
{
    public class GetByIdTagCloudQueryRequest : IRequest<GetByIdTagCloudQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdTagCloudQueryRequest(int id)
        {
            Id = id;
        }
    }
}
