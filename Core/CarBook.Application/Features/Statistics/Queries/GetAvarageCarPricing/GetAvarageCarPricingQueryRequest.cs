using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetAvarageCarPricing
{
    public class GetAvarageCarPricingQueryRequest : IRequest<GetAvarageCarPricingResponse>
    {
        public string PricingType { get; set; }

        public GetAvarageCarPricingQueryRequest(string pricingType)
        {
            PricingType = pricingType;
        }
    }
}
