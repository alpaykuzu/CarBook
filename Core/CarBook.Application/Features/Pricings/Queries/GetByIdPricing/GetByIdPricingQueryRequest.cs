using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Queries.GetByIdPricing
{
    public class GetByIdPricingQueryRequest : IRequest<GetByIdPricingQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdPricingQueryRequest(int id)
        {
            Id = id;
        }
    }
}
