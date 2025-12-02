using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Queries.GetByIdFeature
{
    public class GetByIdFeatureQueryRequest : IRequest<GetByIdFeatureQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdFeatureQueryRequest(int id)
        {
            Id = id;
        }
    }
}
