using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarByCarPricing
{
    public class GetCarByCarPricingQueryRequest : IRequest<GetCarByCarPricingQueryResponse>
    {
        public string PricingType { get; set; }
        public bool IsMax { get; set; }
    }
}
